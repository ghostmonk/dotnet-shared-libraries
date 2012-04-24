﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleUtils
{
    public class ConsoleCommandMapper
    {
        private const string EXIT = "exit";
        private readonly Dictionary<string, Action<string[]>> actionMap = new Dictionary<string, Action<string[]>>();
        private readonly StringBuilder helpMsg = new StringBuilder( string.Empty );

        public ConsoleCommandMapper( string header )
        {
            helpMsg.Append( header.Trim() ).AppendLine().AppendLine();
            MapAction( OutputExitMessage, "Exit the program.", EXIT );
            MapAction( Help, "Print out help message.", "help", "?", "h" );
            EnterPrompt = "Enter cmd...";
        }

        public string EnterPrompt { get; set; }

        public void MapAction( Action<string[]> action, string description, params string[] cmds )
        {
            string options = string.Empty;

            int cmdsLength = 0;
            foreach( string cmd in cmds )
            {
                actionMap.Add( cmd, action );
                cmdsLength += cmd.Length + 2;
                options += " /" + cmd;
            }

            if( string.IsNullOrEmpty( description ) ) return;

            string padding = new string( ' ', 20 - cmdsLength );
            helpMsg.Append( options ).Append(  padding ).Append( "-" ).Append( description ).AppendLine();       
        }

        public void ExecuteCmd( string option, params string[] args )
        {
            if( string.IsNullOrEmpty( option ) || !actionMap.ContainsKey( option ) )
            {
                ConsoleOutput.ReturnWriteLine( "Unknown command." );
                Help();
                return;
            }
            actionMap[ option ].Invoke( args );
        }

        public void StartCommandLoop()
        {
            string cmd = string.Empty;
            while( cmd != EXIT )
            {
                Console.WriteLine( "{1}{0}", EnterPrompt, Environment.NewLine );
                cmd = Console.ReadLine();
                string[] cmds = !string.IsNullOrEmpty( cmd ) ? cmd.Split( ' ' ) : new string[]{};

                string option = cmds.Length > 0 ? cmds[ 0 ] : string.Empty;

                List<string> args = cmds.ToList();
                args.Remove( option );
                ExecuteCmd( option, args.ToArray() );
            }
        }

        private void Help( string[] args = null )
        {
            ConsoleOutput.ReturnWriteLine( helpMsg.ToString() );
        }

        private static void OutputExitMessage( string[] args = null )
        {
            ConsoleOutput.ReturnWriteLine( "Stopping application." );
        }
    }
}
