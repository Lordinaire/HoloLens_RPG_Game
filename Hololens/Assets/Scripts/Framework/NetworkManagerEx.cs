using Assets.Scripts.Presenters;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Framework
{
    public class NetworkManagerEx : NetworkManager
    {
        public override void OnServerConnect(NetworkConnection conn)
        {
            base.OnServerConnect(conn);

            Debug.LogFormat("[SERVER] New connection {0} !", conn.connectionId);
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            base.OnServerDisconnect(conn);

            Debug.LogFormat("[SERVER] New disconnection {0} !", conn.connectionId);
        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            base.OnClientConnect(conn);

            if (conn.connectionId != 0)
            {
                PlayersPresenter.Instance.AddPlayer(conn);
            }

            Debug.LogFormat("[CLIENT] New connection {0} !", conn.connectionId);
        }

        public override void OnClientDisconnect(NetworkConnection conn)
        {
            base.OnClientDisconnect(conn);

            PlayersPresenter.Instance.RemovePlayer(conn);
            Debug.LogFormat("[CLIENT] New disconnection {0} !", conn.connectionId);
        }
    }
}
