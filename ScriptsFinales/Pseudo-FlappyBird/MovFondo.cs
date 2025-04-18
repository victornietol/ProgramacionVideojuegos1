using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovFondo : MonoBehaviour
{
    float mousePosX;
    float mousePosY;

    void Update()
    {
        mousePosX = Input.mousePosition.x;
        mousePosY = Input.mousePosition.y;

        this.GetComponent<RectTransform>().position = new Vector2(
            (mousePosX/Screen.width)*20 + (Screen.width/2),
            (mousePosY/Screen.height)*20 + (Screen.height/2)
        );
    }
}
