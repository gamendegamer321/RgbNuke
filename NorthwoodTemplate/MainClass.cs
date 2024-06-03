using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;
using System.Collections.Generic;
using TemplatePlugin.Configs;

namespace TemplatePlugin
{
    public class MainClass
    {
        public static MainClass Singleton { get; private set; }


        // ReSharper disable MemberCanBePrivate.Global
        public const string PluginName = "Template Plugin";
        public const string PluginVersion = "1.0.0";
        public const string PluginDescription = "Just a template plugin.";
        public const string PluginAuthor = "Northwood";
        // ReSharper restore MemberCanBePrivate.Global

        [PluginConfig] public MainConfig PluginConfig;

        [PluginConfig("configs/another-config.yml")]
        public AnotherConfig AnotherConfig;

        [PluginPriority(LoadPriority.Highest)]
        [PluginEntryPoint(PluginName, PluginVersion, PluginDescription, PluginAuthor)]
        private void LoadPlugin()
        {
            Singleton = this;
            Log.Info("Loaded plugin, register events...");
            EventManager.RegisterEvents(this);
            Log.Info($"Registered events, config &2&b{PluginConfig.IntValue}&B&r, register factory...");

            var handler = PluginHandler.Get(this);

            Log.Info(handler.PluginName);
            Log.Info(handler.PluginFilePath);
            Log.Info(handler.PluginDirectoryPath);

            List<string> modules = new List<string>
            {
                "something1",
            };

            foreach (var module in modules)
            {
                if (!PluginConfig.DictionaryValue.ContainsKey(module))
                {
                    PluginConfig.DictionaryValue.Add(module, "yes");
                    handler.SaveConfig(this, nameof(PluginConfig));
                }
            }

            PluginConfig.StringValue = "test Value";
            handler.SaveConfig(this, nameof(PluginConfig));

            AnotherConfig.TestList = new List<string> { "Template0" };
            handler.SaveConfig(this, nameof(AnotherConfig));

            if (Player.TryGet("hubert@northwood", out Player plr))
            {
                plr.Role = RoleTypeId.NtfCaptain;
            }
        }

        [PluginEvent(ServerEventType.PlayerJoined)]
        private void OnPlayerJoin(Player player)
        {
            Log.Info($"Player &6{player.UserId}&r joined this server");

            foreach (var plr in Player.GetPlayers())
            {
                Log.Info($"Player online &6{plr.Nickname}&r, role &6{plr.Role}&r");
            }
        }

        [PluginEvent(ServerEventType.PlayerLeft)]
        private void OnPlayerLeave(Player player)
        {
            Log.Info($"Player &6{player.UserId}&r left this server");
        }
    }
}