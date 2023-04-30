using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace SmartParking
{
	internal class User
	{
		public string Username = "";
		public string Password = "";

		public void getPasswords()
		{
			var lines = File.ReadAllLines(@"PasswordFile.txt");

			Username = lines[0];
			Password = lines[1];
        }

	}
}


