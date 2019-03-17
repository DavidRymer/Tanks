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

    public void LoadScene(string scene)
    {
        PhotonNetwork.ConnectUsingSettings("1.0");
        PhotonNetwork.LoadLevel(scene);
    }

    public void Logger()
    {
        Debug.Log("Checking for Rooms");
        if (PhotonNetwork.insideLobby)
        {
            Debug.Log("Inside a Lobby");
            var rooms = PhotonNetwork.GetRoomList();
            foreach (var room in rooms)
                Debug.Log("Found room: " + room.ToString());
        }
    }

    public void CreateRoom(string roomName)
    {
        Debug.Log(roomName);
        PhotonNetwork.CreateRoom(roomName);
        PhotonNetwork.LoadLevel("Main");
    }


    public void JoinRoom(string roomName)
    {
        if (DoesRoomExist(roomName))
        {
            PhotonNetwork.JoinRoom(roomName);
            PhotonNetwork.LoadLevel("Main");
        }
        else
        {
            ErrorMessages.RoomNotFound(roomName, canvas);
        }
    }

    private static bool DoesRoomExist(string room)
    {
        return PhotonNetwork.GetRoomList().Any(roomInfo => roomInfo.Name == room);
    }

    public void RenderRoomList()
    {
        foreach (var roomInfo in PhotonNetwork.GetRoomList())
        {
        }
    }


    public void LeaveGame()
    {
        SceneManager.LoadScene(0);
        PhotonNetwork.Disconnect();
        PhotonNetwork.LeaveLobby();
    }
}