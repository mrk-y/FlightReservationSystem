Guidelines:

* Variables:
	- Use controlA, controlB, and etc. for naming objects or items of a collection type object if the item type is not custom made. 
		Used only if there are multiple collections used in the same loop or code block. If only one collection with no custom type then
		it should be the same but with no trailing letters.

* Logs:
	- Entry is for items in a collection.
	- Entry means it is an entry or item of a collection, entries means it has multiple entry.
	- When a collection does not use a custom made type for it's items then do this do represent the items: [type] ([index of the object. 0-based]).
		For example: 
			List<Control> list = new List<Control>(); -- Control (0)
			List<Control, Control, string> list = new List<Control, Control, string>(); -- Control (0), Control (1), string (2) 
	- When there are multiple parameters specificy each of them that they are a parameter
	
* Logic:
	- Do not put a property on a variable with the same name as the property even if it improves readability if it is only used once.
	- If something is used more than once then put it in a variable except for count.
	- Everything that is a count should not be in a variable