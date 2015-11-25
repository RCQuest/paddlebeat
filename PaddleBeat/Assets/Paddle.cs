using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Paddle : MonoBehaviour
{
    public KeyCode paddleKeyCode;
    public PlayerStats playerStats;
    public bool isTouchingABrick=false;
    public GraceManager grace;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Brick"))
        {
            isTouchingABrick = true;
            if (Input.GetKey(paddleKeyCode)&&!grace.isGraced())
            {
                other.GetComponent<Brick>().degrade();
                if (other.GetComponent<Brick>().isBroken())
                {
                    
                    other.GetComponent<Brick>().assertDestruction();

                }
                Debug.Log(paddleKeyCode + " pressed.");
            }
        }
        else
        {
            isTouchingABrick = false;
        }
    }


}
