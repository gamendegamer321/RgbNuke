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
        _isEnabled = random.Next(0, 100) < Chance;

        // Make sure leftovers from previous round are gone
        NukeHandler.Stop();
        AudioPlayer.RemoveDummy();

        if (_isEnabled)
        {
            Log.Info("Rgb nuke is active this round!");
        }
    }

    [PluginEvent(ServerEventType.RoundEnd)]
    public void OnRoundEnd(RoundEndEvent _)
    {
        NukeHandler.Stop();
        AudioPlayer.RemoveDummy();
    }

    [PluginEvent(ServerEventType.WarheadStart)]
    public void OnWarheadStart(WarheadStartEvent _)
    {
        if (!_isEnabled) return;

        NukeHandler.Start();
        AudioPlayer.PlayAudio();
    }

    [PluginEvent(ServerEventType.WarheadDetonation)]
    public void OnWarheadDetonation()
    {
        NukeHandler.Stop();
        AudioPlayer.StopAudio();
    }

    [PluginEvent(ServerEventType.WarheadStop)]
    public void OnWarheadStop(WarheadStopEvent _)
    {
        NukeHandler.Stop();
        AudioPlayer.StopAudio();
    }
}