using LabApi.Events.Arguments.ServerEvents;
using LabApi.Events.Arguments.WarheadEvents;
using LabApi.Events.Handlers;
using LabApi.Features.Console;
using LabApi.Features.Wrappers;
using Random = System.Random;

namespace RgbNuke;

public static class EventHandler
{
    private static int Chance => MainClass.Singleton.Config.NukeChance;
    private static bool _isEnabled;

    public static void RegisterEvents()
    {
        ServerEvents.RoundStarted += OnRoundStart;
        ServerEvents.RoundEnded += OnRoundEnd;
        WarheadEvents.Started += OnWarheadStart;
        WarheadEvents.Detonated += OnWarheadDetonation;
        WarheadEvents.Stopped += OnWarheadStop;
    }

    public static void UnregisterEvents()
    {
        ServerEvents.RoundStarted -= OnRoundStart;
        ServerEvents.RoundEnded -= OnRoundEnd;
        WarheadEvents.Started -= OnWarheadStart;
        WarheadEvents.Detonated -= OnWarheadDetonation;
        WarheadEvents.Stopped -= OnWarheadStop;
    }

    private static void OnRoundStart()
    {
        var random = new Random(Map.Seed);
        _isEnabled = random.Next(0, 100) < Chance;

        // Make sure leftovers from previous round are gone
        NukeHandler.Stop();
        AudioPlayer.RemoveDummy();

        if (_isEnabled)
        {
            Logger.Info("Rgb nuke is active this round!");
        }
    }

    private static void OnRoundEnd(RoundEndedEventArgs _)
    {
        NukeHandler.Stop();
        AudioPlayer.RemoveDummy();
    }

    private static void OnWarheadStart(WarheadStartedEventArgs _)
    {
        if (!_isEnabled) return;

        NukeHandler.Start();
        AudioPlayer.PlayAudio();
    }

    private static void OnWarheadDetonation(WarheadDetonatedEventArgs _)
    {
        NukeHandler.Stop();
        AudioPlayer.StopAudio();
    }

    private static void OnWarheadStop(WarheadStoppedEventArgs _)
    {
        NukeHandler.Stop();
        AudioPlayer.StopAudio();
    }
}