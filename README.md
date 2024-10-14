# RGB Nuke

Will turn all facility lights into a rainbow when the alpha warhead is activated and play a song.

By default, we expect the song to be a file named "warhead.ogg" located in the <code>SCP Secret
Laboratory/PluginAPI/Plugins/Global/Rainbow Nuke/Audio</code> directory, the Audio directory is next to the config file.

## Requirements

This plugin requires the following plugins to be installed on the server:

- [SCPSLAudioApi](https://github.com/CedModV2/SCPSLAudioApi)
- (optional) [NWAPIPermissionSystem](https://github.com/CedModV2/NWAPIPermissionSystem) for commands

## Config

<code>ColorChangeTime</code> - this will change the time between color changes of the lights.

<code>NukeChance</code> - This is an integer from 0 to 100 that indicates the chance the warhead will be RGB during a
round. 0 means never and 100 means always.

<code>Volume</code> - The volume at which the music will be played (as an integer).

<code>File name</code> - The name of the audio file to use. The default is "warhead.ogg".

<code>Display name</code> - The name that is being displayed by the fake player. The default is "Alpha warhead".

## Audio file

For the SCP:SL Audio API to work the audio file needs to be a <code>.ogg</code> file with <code>mono</code> audio and a
refresh rate of <code>48000hz</code>.

The plugin will search for the audio file in the same folder as the config is located (<code>SCP Secret
Laboratory/PluginAPI/Plugins/Global</code> or <code>SCP Secret Laboratory/PluginAPI/Plugins/{port}</code>), as well as
an <code>Audio</code> subfolder (<code>SCP Secret Laboratory/PluginAPI/Plugins/Global/Audio</code>  or <code>SCP Secret
Laboratory/PluginAPI/Plugins/{port}/Audio</code>). In both cases <code>{port}</code> will be replaced with the port of
the server running the plugin.

## Command

You can start or stop the effect by using the commands:

- <code>disco start</code>
- <code>disco stop</code>

For these commands to work [NWAPIPermissionSystem](https://github.com/CedModV2/NWAPIPermissionSystem) needs to be
installed and you need the <code>rgbnuke.commands</code> permission to use the commands.

## Example video

https://github.com/gamendegamer321/RgbNuke/assets/74590966/1549019a-c9cd-477e-b428-c1ec82acff96

