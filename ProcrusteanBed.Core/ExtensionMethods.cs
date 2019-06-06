using ProcrusteanBed.Architecture;
using System;

namespace ProcrusteanBed.Core
{
	public static class ExtensionMethods
	{
		public static DirectiveType ToDirectiveType(this Type type)
		{
			switch(type.FullName)
			{
				case "System.Byte":					
						return DirectiveType.Byte;

				case "System.Int16":
					return DirectiveType.Short;

				case "System.UInt16":
					return DirectiveType.UShort;

				case "System.Single":
					return DirectiveType.Float;

				case "System.Net.IPAddress":
					return DirectiveType.IPAddress;;

				default:
					throw new NotImplementedException();
			}
		}
	}
}
