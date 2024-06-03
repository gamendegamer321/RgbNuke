# RGB Nuke

Will turn all facility lights into a rainbow when the alpha warhead is activated and play a song.

By default, we expect the song to be a file named "warhead.ogg" located in the <code>SCP Secret
Laboratory/PluginAPI/Plugins/Global/Rainbow Nuke/Audio</code> directory, the Audio directory is next to the config file.

## Config

You can change the directory to look for the "warhead.ogg" file in the config. Here <code>{global}</code> points to the
<code>SCP Secret Laboratory/PluginAPI/Plugins/Global</code> directory and you can navigate from there if desired.

<code>ColorChangeTime</code> - this will change the time between color changes of the lights.

<code>NukeChance</code> - This is an integer from 0 to 100 that indicates the chance the warhead will be RGB during a
round. 0 means never and 100 means always.

<code>Volume</code> - The volume at which the music will be played (as an integer).