using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S;
    private GameObject _lastTriggerGo = null;

    [Header("Set in Inspector")]
    //These movements control the movement of the ship
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;

    void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        else
        {
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!");
        }
    }

    void Update()
    {
        //Pull information from the Input class 
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        //Change transform.position based on the axes 
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        //Rotate the ship to make it feel more dynamic 
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * pitchMult, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        //checks if game object has tag that tells them it is a pickup object
        if (other.gameObject.CompareTag("Enemy"))
        {
            //deactivate the object for remainder of game
            other.gameObject.SetActive(false);
        }
    }
}
