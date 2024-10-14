using System.ComponentModel;

namespace RgbNuke.Configs;

public class RgbNukeConfig
{
    [Description("The amount of time between the color changes of the facility")]
    public float ColorChangeTime { get; set; } = 1f;

    [Description("The change in % that RGB nuke gets activated an round (100 = always, 50 = half of the rounds (50%))")]
    public int NukeChance { get; set; } = 20;

    [Description("The volume to play the audio at")]
    public int Volume { get; set; } = 500;

    [Description("The name of the audio file to play")]
    public string FileName { get; set; } = "warhead.ogg";

    [Description("The display name of the audio bot in the game")]
    public string DisplayName { get; set; } = "Alpha warhead";
}