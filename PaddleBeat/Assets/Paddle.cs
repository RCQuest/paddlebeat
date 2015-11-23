using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Paddle : MonoBehaviour
{
    public KeyCode paddleKeyCode;
    public PlayerStats playerStats;
    public int isTouchingABrick=0;
    public List<Brick> touchingBricks;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Brick")&&Input.GetKeyDown(paddleKeyCode))
        {
            other.GetComponent<Brick>().degrade();
            if (other.GetComponent<Brick>().isBroken())
            {
                isTouchingABrick--;
                other.GetComponent<Brick>().assertDestruction();
                
            }
            Debug.Log("Got it!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Brick"))
        {
            isTouchingABrick++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Brick"))
        {
            isTouchingABrick--;
        }
    }
}
