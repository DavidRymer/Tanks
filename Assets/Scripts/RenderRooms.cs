using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderRooms : Photon.MonoBehaviour
{
    public GameObject holderPrefab;
    public Canvas canvas;
    private int index = -1;

    public void RenderRoomList()
    {
        foreach (var roomInfo in PhotonNetwork.GetRoomList())
        {
            index += 1;
            var listComponent = new GameObject("List").AddComponent<RoomListComponent>();
            listComponent.holderPrefab = holderPrefab;
            listComponent.roomInfo = roomInfo;
            listComponent.canvas = canvas;
            listComponent.AddComponent(index);
        }
    }

    void OnReceivedRoomListUpdate()
    {
        ResetList();
        RenderRoomList();
    }

    private void ResetList()
    {
        if (canvas.transform.Find("Scroll View").Find("Contents").childCount > 0)
        {
            foreach (Transform child in canvas.transform.Find("Scroll View").Find("Contents"))
            {
                Destroy(child.gameObject);
            }

            index = -1;
        }
    }
}