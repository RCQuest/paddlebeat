using UnityEngine;
using System.Collections;
using Rhythmify;
using System;

public class Brick : MonoBehaviour {

    public int brokenStage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
            brokenStage--;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball") && brokenStage <= 0)
            Destroy(this.gameObject);       
    }


}
