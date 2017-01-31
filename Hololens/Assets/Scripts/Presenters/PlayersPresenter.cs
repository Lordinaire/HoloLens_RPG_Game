using System.Collections.Generic;
using Assets.Scripts.Models;
using Assets.Scripts.ReactiveModels;
using HoloToolkit.Unity;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts.Presenters
{
    public class PlayersPresenter : Singleton<PlayersPresenter>
    {
        #region Properties

        [HideInInspector]
        public readonly List<RxPlayer> Players = new List<RxPlayer>();

        [HideInInspector]
        public RxPlayer CurrentPlayer;

        #endregion

        #region Bindings

        public Transform PlayersNode;

        #endregion

        #region Main methods

        void Start()
        {
            this.ObserveEveryValueChanged(x => x.Players).Subscribe(DisplayPlayers);
        }

        #endregion

        #region Methods

        private void DisplayPlayers(List<RxPlayer> players)
        {
            
        }

        public void AddPlayer(NetworkConnection conn)
        {
            var rxPlayer = new RxPlayer(new Player
            {
                Id = conn.connectionId,
                Name = string.Format("Player {0}", conn.connectionId)
            });

            Players.Add(rxPlayer);
        }

        public void RemovePlayer(NetworkConnection conn)
        {
            if (Players == null)
                return;
            
            for (int i = Players.Count - 1; i >= 0; i--)
            {
                if (Players[i].Data.Id == conn.connectionId)
                {
                    Players.Remove(Players[i]);
                    break;
                }
            }
        }

        #endregion


    }
}
