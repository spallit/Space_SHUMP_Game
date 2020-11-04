using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Keeps a GameObject on screen.
/// Note that this ONLY works or an orthographic Main Camera at [0, 0, 0].
/// </summary>

public class BoundsCheck : MonoBehaviour
{
    //creates header in inspector
    [Header("Set in Inspector")]
    public float radius = 1f;
    /// <summary>
    //allows the player and enemy to behave differently
    /// </summary>
    //determines whether the GO should stay on screen or not
    public bool keepOnScreen = true;

    [Header("Set Dynamically")]
    //is the game object on screen
    public bool isOnScreen = true;
    public float camWidth;
    public float camHeight;

    [HideInInspector]
    //is the hero offscreen
    public bool offRight, offLeft, offUp, offDown;


    void Awake()
    {
        //size of camera from the camera inspector
        //variable of the distance btw the origin of the world and the top or bottom edges of the screen
        camHeight = Camera.main.orthographicSize;
        //gets aspect ration defined in game pane
        //variable of the distance btw the origin of the world and the left or right edges of the screen
        camWidth = camHeight * Camera.main.aspect;
    }


    void LateUpdate()
    {
        //normal conditions for player (hero)
        Vector3 pos = transform.position;
        isOnScreen = true;
        offRight = offLeft = offUp = offDown = false;

        //position is aadjusted to keep game object on screen
        if (pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
            isOnScreen = false;
            offRight = true;
        }
        if (pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
            isOnScreen = false;
            offLeft = true;
        }
        if (pos.y > camHeight - radius)
        {
            pos.y = camHeight - radius;
            isOnScreen = false;
            offUp = true;
        }
        if (pos.y < -camHeight + radius)
        {
            pos.y = -camHeight + radius;
            isOnScreen = false;
            offDown = true;
        }
        isOnScreen = !(offRight || offLeft || offUp || offDown);
        //if hero is offscreen, then keepOnScreen is tru and position is readjusted
        if (keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
            offRight = offLeft = offUp = offDown = false;
        }
    }

    //Draws the bounds in the scene pane
    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
