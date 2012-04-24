using System;
using System.Collections.Generic;
using ConsoleUtils;

namespace ConsoleUtilsManualTest
{
    class Program
    {
        public Program( string[] args )
        {
            ConsoleCommandMapper commandMapper = new ConsoleCommandMapper( "Test Application" );
            commandMapper.MapAction( DoAction, "This is a doaction command!!", "D", "Do" );
            commandMapper.StartCommandLoop();
            
        }

        private void DoAction( IEnumerable<string> args )
        {
            foreach( var s in args )
            {
                Console.WriteLine( s );   
            }
        }

        static void Main( string[] args )
        {
            new Program();
            Console.ReadLine();
        }
    }
}
