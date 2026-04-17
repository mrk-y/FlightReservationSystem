using FlightReservationSystem.Helpers;
using FlightReservationSystem.UserControls.AircraftModelsUI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FlightReservationSystem.UserControls.Reservation_Agent
{
    /// <summary>
    /// Handles all database operations for bookings and booking passengers.
    /// </summary>
    internal static class BookingRepository
    {
        // ── Save a completed booking ──────────────────────────────────────────
        public static int SaveBooking(
            string referenceNo,
            int flightId,
            decimal baseFare,
            decimal tax,
            decimal serviceFee,
            List<RAPassengerDetails> passengers,
            Dictionary<int, string> seatAssignments)
        {
            const string insertBooking = @"
                INSERT INTO Bookings
                    (ReferenceNo, FlightID, TotalAmount, BaseFare, Tax, ServiceFee)
                VALUES
                    (@ref, @fid, @total, @base, @tax, @fee);
                SELECT SCOPE_IDENTITY();";

            const string insertPassenger = @"
                INSERT INTO BookingPassengers
                    (BookingID, PassengerNo, FirstName, LastName, MiddleName,
                     Nationality, IDType, IDNumber, PassportNo,
                     Email, Phone, Gender, Age,
                     SeatClass, SeatLabel,
                     HasPeanutAllergy, NeedsWheelchair, IsUnaccompaniedMinor,
                     GuardianName, GuardianPhone, GuardianRelation)
                VALUES
                    (@bid, @pno, @fn, @ln, @mn,
                     @nat, @idt, @idn, @ppn,
                     @em, @ph, @gn, @age,
                     @cls, @seat,
                     @pnt, @wch, @umn,
                     @gnm, @gph, @grl)";

            try
            {
                using (var conn = DatabaseConnection.Get())
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        int bookingId;

                        // Insert booking
                        using (var cmd = new SqlCommand(insertBooking, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@ref", referenceNo);
                            cmd.Parameters.AddWithValue("@fid", flightId);
                            cmd.Parameters.AddWithValue("@total", baseFare + tax + serviceFee);
                            cmd.Parameters.AddWithValue("@base", baseFare);
                            cmd.Parameters.AddWithValue("@tax", tax);
                            cmd.Parameters.AddWithValue("@fee", serviceFee);

                            bookingId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // Insert passengers
                        foreach (var p in passengers)
                        {
                            seatAssignments.TryGetValue(p.PassengerNumber, out string seatLabel);

                            using (var cmd = new SqlCommand(insertPassenger, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@bid", bookingId);
                                cmd.Parameters.AddWithValue("@pno", p.PassengerNumber);
                                cmd.Parameters.AddWithValue("@fn", p.FirstName);
                                cmd.Parameters.AddWithValue("@ln", p.LastName);
                                cmd.Parameters.AddWithValue("@mn", (object)p.MiddleName ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@nat", (object)p.Nationality ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@idt", (object)p.IDType ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@idn", (object)p.IDNumber ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@ppn", (object)p.PassportNo ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@em", (object)p.Email ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@ph", (object)p.Phone ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@gn", (object)p.Gender ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@age", p.Age);
                                cmd.Parameters.AddWithValue("@cls", p.SeatClass);
                                cmd.Parameters.AddWithValue("@seat", (object)seatLabel ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@pnt", p.HasPeanutAllergy);
                                cmd.Parameters.AddWithValue("@wch", p.NeedsWheelchair);
                                cmd.Parameters.AddWithValue("@umn", p.IsUnaccompaniedMinor);
                                cmd.Parameters.AddWithValue("@gnm", (object)p.GuardianName ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@gph", (object)p.GuardianPhone ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@grl", (object)p.GuardianRelation ?? DBNull.Value);

                                cmd.ExecuteNonQuery();
                            }
                        }

                        tx.Commit();
                        return bookingId;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to save booking:\n{ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return -1;
            }
        }

        // ── Load saved passengers ─────────────────────────────────────────────
        public static List<SavedPassengerInfo> LoadSavedPassengers(int flightId)
        {
            var list = new List<SavedPassengerInfo>();

            const string sql = @"
                SELECT
                    bp.PassengerNo,
                    bp.FirstName,
                    bp.LastName,
                    bp.MiddleName,
                    bp.Nationality,
                    bp.Gender,
                    bp.Age,
                    bp.Email,
                    bp.Phone,
                    bp.SeatClass,
                    bp.SeatLabel,
                    bp.HasPeanutAllergy,
                    bp.NeedsWheelchair,
                    bp.IsUnaccompaniedMinor,
                    b.ReferenceNo
                FROM BookingPassengers bp
                INNER JOIN Bookings b ON b.BookingID = bp.BookingID
                WHERE b.FlightID = @fid
                  AND b.IsActive = 1
                ORDER BY b.BookingID, bp.PassengerNo";

            try
            {
                using (var conn = DatabaseConnection.Get())
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@fid", flightId);
                    conn.Open();

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            list.Add(new SavedPassengerInfo
                            {
                                PassengerNo = (int)rdr["PassengerNo"],
                                FirstName = rdr["FirstName"].ToString(),
                                LastName = rdr["LastName"].ToString(),
                                MiddleName = rdr["MiddleName"] == DBNull.Value ? string.Empty : rdr["MiddleName"].ToString(),
                                Nationality = rdr["Nationality"] == DBNull.Value ? string.Empty : rdr["Nationality"].ToString(),
                                Gender = rdr["Gender"] == DBNull.Value ? string.Empty : rdr["Gender"].ToString(),
                                Age = rdr["Age"] == DBNull.Value ? 0 : Convert.ToInt32(rdr["Age"]),
                                Email = rdr["Email"] == DBNull.Value ? string.Empty : rdr["Email"].ToString(),
                                Phone = rdr["Phone"] == DBNull.Value ? string.Empty : rdr["Phone"].ToString(),
                                SeatClass = rdr["SeatClass"].ToString(),
                                SeatLabel = rdr["SeatLabel"].ToString(),
                                HasPeanutAllergy = (bool)rdr["HasPeanutAllergy"],
                                NeedsWheelchair = (bool)rdr["NeedsWheelchair"],
                                IsUnaccompaniedMinor = (bool)rdr["IsUnaccompaniedMinor"],
                                ReferenceNo = rdr["ReferenceNo"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to load saved passengers:\n{ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            return list;
        }
    }
}