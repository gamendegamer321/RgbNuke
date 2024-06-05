using System;
using System.IO;
using Mirror;
using PluginAPI.Helpers;
using SCPSLAudioApi.AudioCore;
using VoiceChat;
using Object = UnityEngine.Object;

namespace RgbNuke;

public static class AudioPlayer
{
    private static ReferenceHub _audioBot;

    private static string AudioPath => MainClass.Singleton.PluginConfig.MusicDirectory
        .Replace("{global}", Paths.GlobalPlugins.Plugins);

    private static int Volume => MainClass.Singleton.PluginConfig.Volume;

    public static void PlayAudio()
    {
        if (_audioBot == null) AddDummy();

        StopAudio();

        var path = Path.Combine(AudioPath, "warhead.ogg");
        var audioPlayer = AudioPlayerBase.Get(_audioBot);
        audioPlayer.Enqueue(path, -1);
        audioPlayer.LogDebug = false;
        audioPlayer.BroadcastChannel = VoiceChatChannel.Intercom;
        audioPlayer.Volume = Volume / 100f;
        audioPlayer.Loop = true;
        audioPlayer.Play(0);
    }

    public static void StopAudio()
    {
        if (_audioBot == null) return;

        var audioPlayer = AudioPlayerBase.Get(_audioBot);
        if (audioPlayer.CurrentPlay != null)
        {
            audioPlayer.Stoptrack(true);
            audioPlayer.OnDestroy();
        }
    }

    private static void AddDummy()
    {
        var newPlayer = Object.Instantiate(NetworkManager.singleton.playerPrefab);
        var fakeConnection = new FakeConnection(0);
        _audioBot = newPlayer.GetComponent<ReferenceHub>();

        NetworkServer.AddPlayerForConnection(fakeConnection, newPlayer);
        _audioBot.authManager.InstanceMode = CentralAuth.ClientInstanceMode.Unverified;

        try
        {
            _audioBot.nicknameSync.SetNick("Alpha warhead");
        }
        catch (Exception)
        {
        }
    }

    public static void RemoveDummy()
    {
        if (_audioBot == null) return;

        var audioPlayer = AudioPlayerBase.Get(_audioBot);
        if (audioPlayer.CurrentPlay != null)
        {
            audioPlayer.Stoptrack(true);
            audioPlayer.OnDestroy();
        }

        _audioBot.OnDestroy();
        CustomNetworkManager.TypedSingleton.OnServerDisconnect(_audioBot.connectionToClient);
        Object.Destroy(_audioBot.gameObject);
    }
}