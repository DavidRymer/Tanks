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
//		PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions (){ MaxPlayers = 2 }, TypedLobby.Default);
		
		foreach (var room in PhotonNetwork.GetRoomList())
		{
			Debug.Log(room.Name);
		}

		
	}

	private void OnConnectedToMaster()
	{
		Debug.Log("connected to master david");
		PhotonNetwork.JoinLobby();
	}

	
	void OnJoinedRoom(){
		GameObject b =PhotonNetwork.Instantiate ("Player",transform.position,Quaternion.identity,0);
//		GameObject a = PhotonNetwork.Instantiate ("Player",transform.position + new Vector3(10,  0, 0),Quaternion.identity,0);
//		a.GetComponent<TankMovement>().speed = 0;


	}
	
}
