/*
 * This program will revert scrolling for all mouse devices 
 */

using Microsoft.Win32;

const string PropName = "FlipFlopWheel";

Console.WriteLine("Hello from grom-games.com!");

var key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Enum\HID", false);

RevertScroll(key);

Console.WriteLine("DONE!");

void RevertScroll(RegistryKey key)
{
	var value = (int)key.GetValue(PropName, -1);
	if (value == 0)
	{
		Console.WriteLine(key.Name);
	}
	
	var names = key.GetSubKeyNames();
	foreach (var name in names)
	{
		RegistryKey? subKey = null;

		try
		{
			subKey = key.OpenSubKey(name, false);
		}
		catch (Exception)
		{
			//Console.WriteLine("Couldn't open sub key {0}", name);
		}

		if (subKey != null)
		{
			RevertScroll(subKey);
			subKey.Close();
		}
	}
}










