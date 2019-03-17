using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListComponent : MonoBehaviour
{

    public RoomInfo roomInfo;
    public GameObject holderPrefab;
    private GameObject newHolder;
    public Canvas canvas;

    public void AddComponent(int index)
    {
        newHolder = Instantiate(holderPrefab, transform.position, Quaternion.identity);
        AddNameToHolder();
        AddNumberOfPlayersToHolder();
        UpdateHolderButton();
        newHolder.transform.SetParent(canvas.transform.Find("Scroll View").Find("Contents"));
        newHolder.transform.localPosition = new Vector3(2.5f, 324 - 31 * index);

    }
    
    private void AddNameToHolder()
    {
        newHolder.transform.Find("RoomName").GetComponent<Text>().text = roomInfo.Name;
    }
    
    private void AddNumberOfPlayersToHolder()
    {
        newHolder.transform.Find("NumberOfPlayers").GetComponent<Text>().text = roomInfo.PlayerCount.ToString();
    }

    private void UpdateHolderButton()
    {
        newHolder.transform.Find("JoinButton").GetComponent<Button>().onClick.AddListener(() =>
        {
            PhotonNetwork.JoinRoom(roomInfo.Name);
            PhotonNetwork.LoadLevel("Main");
        });
    }
    


}
