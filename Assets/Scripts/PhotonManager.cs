using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonManager : Photon.MonoBehaviour {
	
	[SerializeField]private GameObject player;
	// Use this for initialization
	void Start () {

	}

	
	void OnJoinedLobby(){
		Debug.Log("lobby joined");
		PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions (){ MaxPlayers = 2 }, TypedLobby.Default);
		
	}

	private void OnConnectedToMaster()
	{
		PhotonNetwork.JoinLobby();
	}


	void OnLeftRoom()
	{
		Debug.Log("fefefe");
	}

	
	void OnJoinedRoom(){
		PhotonNetwork.Instantiate ("Player",transform.position,Quaternion.identity,0);
		
	}
	
}
