namespace RPGSaga.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ConfigController
    {
        public (IInputConfig, bool) ChooseConfiguration(string[] args)
        {
            List<string> arguments = args.ToList();

            if (!arguments.Any())
            {
                return (new KeyboardConfig(), false);
            }

            if (arguments.Contains("-k") && arguments.Contains("-s"))
            {
                int numberOfPlayers = int.Parse(arguments[arguments.FindIndex(w => w == "-k") + 1]);
                PlayerListSerializer.FileNameToSave = arguments[arguments.FindIndex(w => w == "-s") + 1];
                return (new LineArgumentsConfig(numberOfPlayers), true);
            }

            if (arguments.Contains("-i") && arguments.Contains("-s"))
            {
                PlayerListSerializer.FileNameToGet = arguments[arguments.FindIndex(w => w == "-i") + 1];
                PlayerListSerializer.FileNameToSave = arguments[arguments.FindIndex(w => w == "-s") + 1];
                return (new FileConfig(), true);
            }

            if (arguments.Contains("-s"))
            {
                PlayerListSerializer.FileNameToSave = arguments[arguments.FindIndex(w => w == "-s") + 1];
                return (new KeyboardConfig(), true);
            }

            if (arguments.Contains("-i"))
            {
                PlayerListSerializer.FileNameToGet = arguments[arguments.FindIndex(w => w == "-i") + 1];
                return (new FileConfig(), false);
            }

            if (arguments.Contains("-k"))
            {
                int numberOfPlayers = int.Parse(arguments[arguments.FindIndex(w => w == "-k") + 1]);
                return (new LineArgumentsConfig(numberOfPlayers), false);
            }
            else
            {
                throw new ArgumentException("You used wrong line argument(s)!\n Arguments available to use:\n" +
                    "\"-s filename.json\" - saves the list of players to the filename.ext located on your desktop;\n" +
                    "\"-i filename.json\" - loads list of players from the filename.ext located on your desktop;\n" +
                    "\"-k numberofplayers\" - starts the game with specified number of players;\n\n" +
                    "These line arguments can be mixed, e.g.:\n" +
                    "\"-i inputfile.json -s outputfile.json\"\n" +
                    "\"-k 20 -s outputfile.json\"");
            }
        }
    }
}
