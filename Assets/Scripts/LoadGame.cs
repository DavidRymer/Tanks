using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public GameObject photonManger;

    public void LoadScene(int level)
    {
        PhotonNetwork.ConnectUsingSettings("1.0");
        Debug.Log(PhotonNetwork.connecting);
        PhotonNetwork.LoadLevel(level);
        Debug.Log(PhotonNetwork.insideLobby);

    }

    public void LeaveGame()
    {
        SceneManager.LoadScene(0);
        PhotonNetwork.Disconnect();
        PhotonNetwork.LeaveLobby();
        
        
    }
}
