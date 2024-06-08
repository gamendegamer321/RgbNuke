# RGB Nuke

Will turn all facility lights into a rainbow when the alpha warhead is activated and play a song.

By default, we expect the song to be a file named "warhead.ogg" located in the <code>SCP Secret
Laboratory/PluginAPI/Plugins/Global/Rainbow Nuke/Audio</code> directory, the Audio directory is next to the config file.

## Requirements

This plugin requires the following plugins to be installed on the server:

- [SCPSLAudioApi](https://github.com/CedModV2/SCPSLAudioApi)
- (optional) [NWAPIPermissionSystem](https://github.com/CedModV2/NWAPIPermissionSystem) for commands

## Config

You can change the directory to look for the "warhead.ogg" file in the config. Here <code>{global}</code> points to the
<code>SCP Secret Laboratory/PluginAPI/Plugins/Global</code> directory and you can navigate from there if desired.

<code>ColorChangeTime</code> - this will change the time between color changes of the lights.

<code>NukeChance</code> - This is an integer from 0 to 100 that indicates the chance the warhead will be RGB during a
round. 0 means never and 100 means always.

<code>Volume</code> - The volume at which the music will be played (as an integer).

<code>Display name</code> - The name that is being displayed by the fake player. The default is "Alpha warhead".

## Command

You can start or stop the effect by using the commands:

- <code>disco start</code>
- <code>disco stop</code>

For these commands to work [NWAPIPermissionSystem](https://github.com/CedModV2/NWAPIPermissionSystem) needs to be
installed and you need the <code>rgbnuke.commands</code> permission to use the commands.

## Example video

https://github.com/gamendegamer321/RgbNuke/assets/74590966/1549019a-c9cd-477e-b428-c1ec82acff96

