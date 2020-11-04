using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //creates header in inspector
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f;  //speed in m/s
    public float direction;


    //occurs when the game is first started
    private void Start()
    {
        //generates a random number between 1 or 2 that will indicate the driection (left of right) Enemy_2
        direction = Random.Range(1, 3);
    }

    private BoundsCheck _bndCheck;

    //check bounds before start
    void Awake()
    {
        _bndCheck = GetComponent<BoundsCheck>();
    }

    //This is a Property: A method that acts like a field 
    public Vector3 pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

    //
    void Update()
    {
        //call move funtion every update
        Move();

        if (_bndCheck != null && _bndCheck.offDown)
        //Check to make sure it's gone off the bottom of the screen 
        {
            //We're off the bottom, so destroy this GameObject 
            Destroy(gameObject);
        }
    }

    //move function 
    public virtual void Move()
    {
        //moves vertically downward
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
}
