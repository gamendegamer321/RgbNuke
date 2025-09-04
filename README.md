[![GitHub release](https://flat.badgen.net/github/release/gamendegamer321/RgbNuke/)](https://github.com/gamendegamer321/RgbNuke/releases/latest)
![LabAPI Version](https://flat.badgen.net/static/LabAPI%20Version/v1.1.1)
[![License](https://flat.badgen.net/github/license/gamendegamer321/RgbNuke/)](https://github.com/gamendegamer321/RgbNuke/blob/master/LICENSE)

# About RGB Nuke

https://github.com/gamendegamer321/RgbNuke/assets/74590966/1549019a-c9cd-477e-b428-c1ec82acff96

Will turn all facility lights into a rainbow when the alpha warhead is activated and play a song.

# Installation

> [!IMPORTANT]
> **Required dependencies:**
> - [SCPSLAudioApi](https://github.com/gamendegamer321/SCPSLAudioApi)

Place the [latest release](https://github.com/gamendegamer321/RgbNuke/releases/latest) in the LabAPI plugin folder.

You will need to provide the music that plays when the warhead is activated. The music file needs to be placed in the
config folder created for this plugin, any of the following paths will work:

- <code>SCP Secret Laboratory/LabAPI/configs/global/Rainbow Nuke</code>
- <code>SCP Secret Laboratory/LabAPI/configs/{port}/Rainbow Nuke</code>
- <code>SCP Secret Laboratory/LabAPI/configs/global/Rainbow Nuke/Audio</code>
- <code>SCP Secret Laboratory/LabAPI/configs/{port}/Rainbow Nuke/Audio</code>

> [!WARNING]
> For the SCP:SL Audio API to work the audio file needs to be a <code>.ogg</code> file with <code>mono</code> audio and
> a refresh rate of <code>48000hz</code>.
> **Make sure the audio files matches the file name from the config, default is <code>warhead.ogg</code>**

# Usage

When the round is started, it will determine whether RGB nuke will be activated based on the chance given in the config.
If RGB nuke is activated during a round, each time the nuke countdown is started the facility will get disco lights and
music will start playing.

You can also start or stop the effect by using the commands:

- <code>disco start</code>
- <code>disco stop</code>

For these commands you need the <code>rgbnuke.commands</code> permission.

# Config

<code>ColorChangeTime</code> - this will change the time between color changes of the lights.

<code>NukeChance</code> - This is an integer from 0 to 100 that indicates the chance the warhead will be RGB during a
round. 0 means never and 100 means always.

<code>Volume</code> - The volume at which the music will be played (as an integer).

<code>File name</code> - The name of the audio file to use. The default is "warhead.ogg".

<code>Display name</code> - The name that is being displayed by the fake player. The default is "Alpha warhead".
