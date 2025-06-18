using System;
using LabApi.Features;
using LabApi.Features.Console;
using LabApi.Loader.Features.Plugins;
using RgbNuke.Configs;
using SCPSLAudioApi;

namespace RgbNuke;

public class MainClass : Plugin<Config>
{
    public static MainClass Singleton { get; private set; }

    public override string Name => "Rainbow Nuke";
    public override string Description => "Random chance the nuke turns disco for a round.";
    public override string Author => "gamendegamer";
    public override Version Version => new(1, 3, 0);
    public override Version RequiredApiVersion => new(LabApiProperties.CompiledVersion);

    public override void Enable()
    {
        Singleton = this;
        Logger.Info("Loading RGB Nuke");
        EventHandler.RegisterEvents();
        Startup.SetupDependencies();
    }

    public override void Disable()
    {
        EventHandler.RegisterEvents();
    }
}