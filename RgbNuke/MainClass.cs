using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;
using RgbNuke.Configs;

namespace RgbNuke;

public class MainClass
{
    public static MainClass Singleton { get; private set; }


    // ReSharper disable MemberCanBePrivate.Global
    public const string PluginName = "Rainbow Nuke";
    public const string PluginVersion = "1.0.0";
    public const string PluginDescription = "Random chance the nuke turns gay for a round.";
    public const string PluginAuthor = "gamendegamer";
    // ReSharper restore MemberCanBePrivate.Global

    [PluginConfig] public RgbNukeConfig PluginConfig;

    private EventHandler _handler = new();

    [PluginEntryPoint(PluginName, PluginVersion, PluginDescription, PluginAuthor)]
    private void LoadPlugin()
    {
        Singleton = this;
        Log.Info("Loading RGB Nuke");
        EventManager.RegisterEvents(_handler);
    }

    [PluginUnload]
    private void UnloadPlugin()
    {
        EventManager.UnregisterEvents(_handler);
    }
}