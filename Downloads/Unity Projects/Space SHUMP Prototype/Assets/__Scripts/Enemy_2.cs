using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inherited class of Enemy
public class Enemy_2 : Enemy
{
    private BoundsCheck _bndCheck;

    void Awake()
    {
        _bndCheck = GetComponent<BoundsCheck>();
    }

    //overrides update function from Enemy
    void Update()
    {
        //calls the move function of this class
        Move();

        //checks if reached boundaries either on right, left, or bottom of screen
        if (_bndCheck != null && (_bndCheck.offDown || _bndCheck.offLeft || _bndCheck.offRight))
        //Check to make sure it's gone off the bottom of the screen 
        {
            //We're off the bottom, so destroy this GameObject 
            Destroy(gameObject);
        }
    }

    //overriden move function
    public override void Move()
    {
        //moves downward at a constant rate
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;

        //uses random number generator from Enemy class to determine either left or right direction to make it move on a 45 degree angle
        if(direction == 1)
        {
            tempPos.x += speed * Time.deltaTime;
        }
        if(direction == 2)
        {
            tempPos.x -= speed * Time.deltaTime;
        }

        pos = tempPos;
    }
}
