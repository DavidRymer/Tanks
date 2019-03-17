using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessages : MonoBehaviour
{
    protected static void UpdateErrorMessage(GameObject errorMessage, string newMessage)
    {
        if (errorMessage != null)
        {
            errorMessage.GetComponent<Text>().text = newMessage;
        }
    }
}

public class RoomNotFound : ErrorMessages
{
    private string roomName;
    private Canvas canvas;

    public void ThrowError()
    {
        string message = "No room found with name: " + roomName;
        Transform roomNotFound = canvas.transform.Find("RoomNotFound");
        
        if (roomNotFound == null)
        {

            GameObject text = new GameObject("RoomNotFound");

            Text textContent = text.AddComponent<Text>();
            textContent.text = message;

            Font arialFont = (Font) Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            textContent.font = arialFont;
            textContent.material = arialFont.material;

            RectTransform rectTransform = textContent.rectTransform;
            rectTransform.anchoredPosition = new Vector3(528, 299);
            rectTransform.sizeDelta = new Vector2(300, 100);

            text.transform.SetParent(canvas.transform);
        }
        else
        {
            UpdateErrorMessage(roomNotFound.gameObject, message);
        }
    }

    public void SetRoomName(string newName)
    {
        this.roomName = newName;
    }
    
    public void SetCanvas(Canvas newCanvas)
    {
        this.canvas = newCanvas;
    }
}
//TODO work on duplication
public class RoomAlreadyExists : ErrorMessages
{
    private string roomName;
    private Canvas canvas;

    public void ThrowError()
    {
        string message = "The room name: " + roomName + ", is already taken.";
        Transform roomNotFound = canvas.transform.Find("RoomAlreadyExists");
        
        if (roomNotFound == null)
        {

            GameObject text = new GameObject("RoomAlreadyExists");

            Text textContent = text.AddComponent<Text>();
            textContent.text = message;

            Font arialFont = (Font) Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            textContent.font = arialFont;
            textContent.material = arialFont.material;

            RectTransform rectTransform = textContent.rectTransform;
            rectTransform.anchoredPosition = new Vector3(500, 330);
            rectTransform.sizeDelta = new Vector2(300, 100);

            text.transform.SetParent(canvas.transform);
        }
        else
        {
            UpdateErrorMessage(roomNotFound.gameObject, message);
        }
    }

    public void SetRoomName(string newName)
    {
        this.roomName = newName;
    }
    
    public void SetCanvas(Canvas newCanvas)
    {
        this.canvas = newCanvas;
    }
}