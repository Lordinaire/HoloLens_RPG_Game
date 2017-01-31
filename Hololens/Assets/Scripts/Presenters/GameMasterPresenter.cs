using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Assets.Scripts.Presenters
{
    public class GameMasterPresenter : NetworkBehaviour
    {
        #region Properties

        #endregion

        #region Bindings

        public MapPresenter MapPresenter;

        #endregion

        #region Main methods

        private void Start()
        {
            
        }

        #endregion
    }
}