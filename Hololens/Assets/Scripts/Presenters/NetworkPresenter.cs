using HoloToolkit.Unity;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkPresenter : Singleton<NetworkPresenter>
{
    #region Properties

    public NetworkClient Client;

    #endregion

    #region Bindings

    #endregion

    void Start()
    {
        NetworkManager.singleton.networkAddress = "10.0.1.36";
        NetworkManager.singleton.networkPort = 10027;
        NetworkManager.singleton.maxConnections = 20;
    }

    public void CreateHost()
    {
        if (Client != null)
            return;

        Client = NetworkManager.singleton.StartHost();
        Debug.LogFormat("New host ! {0}", Client.isConnected ? "OK" : "KO");
    }

    public void CreateClient()
    {
        if (Client != null)
            return;

        Client = NetworkManager.singleton.StartClient();
        Debug.LogFormat("New client ! {0}", Client.isConnected ? "OK" : "KO");
    }
}
