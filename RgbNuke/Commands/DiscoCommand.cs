using System;
using CommandSystem;
using NWAPIPermissionSystem;

namespace RgbNuke.Commands;

public class DiscoCommand
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class TestCommand : ICommand
    {
        public string Command => "disco";

        public string[] Aliases => ["rgbnuke", "disconuke"];

        public string Description => "Start or stop the RGB nuke effect, does not actually start/stop the nuke.";

        private const string Usage = "You can start or stop the RGB nuke effect:\n" +
                                     "Start the effect - disco start\n" +
                                     "Stop the effect - disco stop";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("rgbnuke.commands"))
            {
                response = "no permission";
                return false;
            }

            if (arguments.Count == 0)
            {
                response = Usage;
                return false;
            }

            if (arguments.At(0) == "start")
            {
                NukeHandler.Start();
                AudioPlayer.PlayAudio();
                response = "Started the effect";
                return true;
            }

            if (arguments.At(0) == "stop")
            {
                NukeHandler.Stop();
                AudioPlayer.RemoveDummy();
                response = "Stopped the effect";
                return true;
            }

            response = Usage;
            return false;
        }
    }
}