using System;

namespace ConsoleUtils
{
    public class ConsoleOutput
    {
        public static void KeyValueSpacer( object key, object value, int padding )
        {
            string keyString = key.ToString();
            string valueString = value.ToString();
            string whiteSpace = new string( ' ', Math.Max( padding - valueString.Length, 0 ) );
            Console.WriteLine( "{0}{1} : {2}", keyString, whiteSpace, valueString );
        }

        public static void ReturnWriteLine( string format, params object[] args )
        {
            Console.WriteLine( Environment.NewLine + format, args );
        }

        public static void WriteLineReturn( string format, params object[] args )
        {
            Console.WriteLine( format + Environment.NewLine, args );
        }
    }
}
