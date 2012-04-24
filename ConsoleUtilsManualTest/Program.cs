using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleUtils;

namespace ConsoleUtilsManualTest
{
    class Program : ConsoleCommandMapper
    {
        private const string HEADER = "This is a test application.";

        public Program() : base( HEADER )
        {
            MapAction( DoAction, "This is a doaction command!!", "D", "Do" );
        }

        private void DoAction( IEnumerable<string> args )
        {
            args.ToList().ForEach( Console.WriteLine );
        }

        static void Main( string[] args )
        {
            Program program = new Program();

            if( args.Length == 0 )
            {
                program.StartCommandLoop();
                Console.ReadLine();
                return;
            }

            program.ExecuteCmd( args );
        }
    }
}
