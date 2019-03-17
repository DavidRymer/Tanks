using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorMessages : MonoBehaviour
{
    public static void RoomNotFound(String roomName, Canvas canvas)
    {
        GameObject text = new GameObject("ErrorMessage");

        Text textContent = text.AddComponent<Text>();
        textContent.text = "No room found with name: " + roomName;

        Font arialFont = (Font) Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        textContent.font = arialFont;
        textContent.material = arialFont.material;

        RectTransform rectTransform = textContent.rectTransform;
        rectTransform.position = new Vector3(50, 30, 0);
        rectTransform.sizeDelta = new Vector2(300, 100);

        text.transform.SetParent(canvas.transform);
    }
}