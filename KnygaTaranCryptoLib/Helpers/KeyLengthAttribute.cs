using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KnygaTaranCryptoLib.Helpers
{
	public class KeyLengthAttribute : Attribute
	{
		public int KeyLength { get; set; }

		public override string ToString()
		{
			return KeyLength + "-bit";
		}
	}
}
