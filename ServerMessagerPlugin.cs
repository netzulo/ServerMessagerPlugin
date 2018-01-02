using Oxide.Game.TheForest.Libraries.Covalence;


namespace Oxide.Plugins
{
    [Info("ServerMessagerPlugin", "Netzulo.com", "0.0.1")]
    [Description("Show messages when players connect/disconnect")]
    class ServerMessagerPlugin : TheForestPlugin
    {

        void OnPlayerSpawn(BoltEntity entity)
        {
            string msg = PlayerPrintInfo(entity, "OnPlayerDisconnected", "player leave join ");
            //Send ChatEvent what it's received by server console too
            covalence.Server.Broadcast(msg, "", "");
        }

        void OnPlayerDisconnected(BoltEntity entity)
        {
            string msg = PlayerPrintInfo(entity, "OnPlayerDisconnected", "player leave named ");
            //Send ChatEvent what it's received by server console too
            covalence.Server.Broadcast(msg, "", "");
        }

        string PlayerPrintInfo(BoltEntity entity, string event_name, string message)
        {
            string msg = "";
            TheForestPlayer player;
            try
            {
                ulong id = entity.source.RemoteEndPoint.SteamId.Id;
                player = (TheForestPlayer)covalence.Players.FindPlayerById(id.ToString());
                msg = $"{message}'{player.Name}'";

                PrintWarning($"{event_name}: player, getting information..."); // debug
                Puts($"player.Id={player.Id}"); // debug
                Puts($"player.Name={player.Name}"); // debug
                Puts($"player.Address={player.Address}"); // debug
                Puts($"player.Ping={player.Ping}"); // debug
                Puts($"player.IsAdmin={player.IsAdmin}"); // debug
                Puts($"player.Language={player.Language}"); // debug
                Puts($"player.IsBanned={player.IsBanned}"); // debug
                Puts($"player.IsSleeping={player.IsSleeping}"); // debug
                Puts($"player.IsConnected={player.IsConnected}"); // debug
                Puts($"player.IsServer={player.IsServer}"); // debug
            }
            catch (System.Exception ex)
            {
                PrintError($" Error found at event named '{event_name}': message={ex.Message}");
            }
            return msg;
        }
    }
}
