using UnityEngine;
using System.Collections;
using Rhythmify;
using System;

public class RhythmPaddle : MonoBehaviour
{
    public float width;
    private Vector3 movingTowards;
    public float movementSpeed;

    void Start()
    {
        this.movingTowards = transform.position;
    }

	void Update()
    {
        transform.position=Vector3.MoveTowards(transform.position, movingTowards, movementSpeed);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            movingTowards = new Vector3(transform.position.x - width, transform.position.y, 0.0f);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            movingTowards = new Vector3(transform.position.x + width, transform.position.y, 0.0f);
    }
}
