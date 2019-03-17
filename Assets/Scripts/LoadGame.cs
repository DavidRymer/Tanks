using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour
{
    public Canvas canvas;
    public GameObject roomNameBox;
    public GameObject maxPlayersDropDown;
    private String roomName;
    private byte maxPlayers;

    public void LoadScene(string scene)
    {
        if (!PhotonNetwork.connected)
        {
            PhotonNetwork.ConnectUsingSettings("1.0");
        }

        PhotonNetwork.LoadLevel(scene);
    }

    public void CreateRoom()
    {
        SetRoomName();
        SetMaxPlayers();

        if (!DoesRoomExist(roomName))
        {
            RoomOptions roomOptions = new RoomOptions {MaxPlayers = maxPlayers};
            PhotonNetwork.CreateRoom(roomName, roomOptions, TypedLobby.Default);
            PhotonNetwork.LoadLevel("Main");
        }
        else
        {
            var roomAlreadyExists = gameObject.AddComponent<RoomAlreadyExists>();
            roomAlreadyExists.SetCanvas(canvas);
            roomAlreadyExists.SetRoomName(roomName);
            roomAlreadyExists.ThrowError();
        }
    }

    public void SetRoomName()
    {
        this.roomName = roomNameBox.GetComponent<InputField>().text;
    }

    public void SetMaxPlayers()
    {
        this.maxPlayers = (byte) (maxPlayersDropDown.GetComponent<Dropdown>().value + 2);
    }


    public void JoinRoom()
    {
        SetRoomName();

        if (DoesRoomExist(roomName))
        {
            PhotonNetwork.JoinRoom(roomName);
            PhotonNetwork.LoadLevel("Main");
        }
        else
        {
            var roomNotFound = gameObject.AddComponent<RoomNotFound>();
            roomNotFound.SetCanvas(canvas);
            roomNotFound.SetRoomName(roomName);
            roomNotFound.ThrowError();
        }
    }

    private static bool DoesRoomExist(string room)
    {
        return PhotonNetwork.GetRoomList().Any(roomInfo => roomInfo.Name == room);
    }


    public void LeaveGame()
    {
        SceneManager.LoadScene(0);
        PhotonNetwork.Disconnect();
        PhotonNetwork.LeaveLobby();
    }
}