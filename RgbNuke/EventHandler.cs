using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;
using Random = System.Random;

namespace RgbNuke;

public class EventHandler
{
    private static int Chance => MainClass.Singleton.PluginConfig.NukeChance;
    
    private bool _isEnabled;

    [PluginEvent(ServerEventType.RoundStart)]
    public void OnRoundStart()
    {
        var random = new Random(Map.Seed);
        _isEnabled = random.Next(1, 100) < Chance;

        if (_isEnabled)
        {
            Log.Info("Rgb nuke is active this round!");
        }
    }

    [PluginEvent(ServerEventType.WarheadStart)]
    public void OnWarheadStart(WarheadStartEvent _)
    {
        if (_isEnabled)
        {
            NukeHandler.Start();
        }
    }

    [PluginEvent(ServerEventType.WarheadDetonation)]
    public void OnWarheadDetonation()
    {
        NukeHandler.Stop();
    }

    [PluginEvent(ServerEventType.WarheadStop)]
    public void OnWarheadStop(WarheadStopEvent _)
    {
        NukeHandler.Stop();
    }
}