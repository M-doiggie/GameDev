using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MultiplayerOptionsController : MonoBehaviourPunCallbacks
{
    #region Private Serializable Fields

    [SerializeField]
    private byte maxPlayersPerRoom = 2;

    #endregion

    #region Private Fields

    string gameVersion = "1";

    bool isConnecting;

    #endregion


    #region Public Fields

    public Canvas multiplayerScreen;
    public Canvas startScreen;

    [SerializeField]
    private GameObject controlPanel;

    [SerializeField]
    private GameObject progressLabel;

    #endregion

    #region MonoBehaviour Callbacks

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start()
    {
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
    }

    #endregion


    #region Public Methods

    public void Connect()
    {
        progressLabel.SetActive(true);
        controlPanel.SetActive(false);

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            isConnecting = PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    public void goBackToStartMenu() 
    {
        multiplayerScreen.gameObject.SetActive(false);
        startScreen.gameObject.SetActive(true);
    }

    #endregion

    #region MonoBehaviourPunCallbacks Callbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("PunBasics Tutorial: OnConnectedToMaster was called by PUN");
        if (isConnecting){
            PhotonNetwork.JoinRandomRoom();
            isConnecting = false;
        }
        
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("Pun basics: OnDisconnected was caled by pun because {0}", cause);
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
        isConnecting = false;
    }

    public override void OnJoinRandomFailed(short returnCode, string message){
        Debug.Log("Pun basics: OnJoinRandomFailed called by Pun. No random room availble.");

        PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayers = maxPlayersPerRoom});
    }

    public override void OnJoinedRoom(){
        Debug.Log("Pun basics: OnJoinedRoom called by pun.");

        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("We load the 'Tutorial'");

            PhotonNetwork.LoadLevel("Tutorial");
        }

    }

    #endregion
}
