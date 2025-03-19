using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using HintServiceMeow.Core.Utilities;
using Hint = HintServiceMeow.Core.Models.Hints.Hint;

namespace NeoHint
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "NeoHint";
        public override string Author => "Arshiavir";
        public override string Prefix => "NeoHint";
        public override Version Version => new Version(1, 0, 0);
        public static Plugin Singleton { get; private set; }

        public override void OnEnabled()
        {
            Log.Info("NeoHint has been enabled!");
            Singleton = this;

            Exiled.Events.Handlers.Player.Verified += EventHandler.OnVerified;
            Exiled.Events.Handlers.Server.WaitingForPlayers += OnWaitingForPlayer;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Log.Info("NeoHint has been disabled!");

            Exiled.Events.Handlers.Player.Verified -= OnVerified;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= OnWaitingForPlayer;

            base.OnDisabled();
        }
        public override void OnReloaded()
        {
            Log.Info("NeoHint has been reloaded!");
        }

        private void OnVerified(VerifiedEventArgs ev)
        {
        }

        private void OnWaitingForPlayer()
        {
        }
        public static class EventHandler
        {
            public static void OnVerified(VerifiedEventArgs ev)
            {
                Hint hint = new Hint
                {
                    Text = Singleton.Config.HintText,
                };

                hint.FontSize = Singleton.Config.FontSize;
                hint.YCoordinate = Singleton.Config.YCoordinate;
                hint.XCoordinate = Singleton.Config.XCoordinate;
                hint.Alignment = Singleton.Config.Alignment;

                PlayerDisplay playerDisplay = PlayerDisplay.Get(ev.Player);
                playerDisplay.AddHint(hint);
            }
        }
    }
}
