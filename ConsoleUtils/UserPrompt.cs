using System;

namespace ConsoleUtils
{
    public class UserPrompt
    {
        public static int GetInteger( string requestMessage = "Enter a valid integer." )
        {
            int output = 0;
            bool isValid = false;
            while( !isValid )
            {
                ConsoleOutput.ReturnWriteLine( requestMessage );
                isValid = int.TryParse( Console.ReadLine(), out output );
                if( !isValid )
                    Console.WriteLine( "Invalid integer format." + Environment.NewLine );
            }
            return output;
        }

        public static string GetString( string requestMessage = "Enter a string." )
        {
            string output = string.Empty;
            bool isValid = false;
            while( !isValid )
            {
                ConsoleOutput.ReturnWriteLine( requestMessage );
                output = Console.ReadLine();
                isValid = !string.IsNullOrEmpty( output );
                if( !isValid )
                    Console.WriteLine( "No string was entered." );
            }
            return output;
        }

        public static void BlockExit( string msg = "Press enter to exit." )
        {
            ConsoleOutput.ReturnWriteLine( msg );
            Console.ReadLine();
        }
    }
}
