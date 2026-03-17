using FlightReservationSystem.Debugging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Helpers
{
    internal class PasswordHelper
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 20_000; // PBKDF2 iterations

        public static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                DebugLogger.Log("[Dev] Parameter string (password) is null or whitespace. Hashing aborted.");
                return "";
            }

            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                DebugLogger.Log("[Dev] Parameter string (password) is null or whitespace. Verification aborted.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(storedHash))
            {
                DebugLogger.Log("[Dev] Parameter string (storedHash) is null or whitespace. Verification aborted.");
                return false;
            }

            byte[] hashBytes = Convert.FromBase64String(storedHash);

            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            byte[] storedHashBytes = new byte[HashSize];
            Array.Copy(hashBytes, SaltSize, storedHashBytes, 0, HashSize);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            if (hash.Length != storedHashBytes.Length) return false;

            for (int i = 0; i < hash.Length; i++)
            {
                var hashByte = hash[i];
                var storedHashByte = storedHashBytes[i];

                if (hashByte != storedHashByte) return false;
            }

            return true;
        }
    }
}
