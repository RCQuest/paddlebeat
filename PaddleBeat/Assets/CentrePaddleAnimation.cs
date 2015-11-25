using UnityEngine;
using System.Collections;

public class CentrePaddleAnimation : MonoBehaviour
{
    private float positionDistance = 0.5f;
    private Vector3 startingPosition;
    private float speed=2f;
    // Use this for initialization
    void Start()
    {
        //startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

       // transform.position = Vector3.MoveTowards(transform.position, startingPosition, speed*Time.deltaTime);

    }

    public void startAnimation()
    {
        //transform.position= new Vector3(startingPosition.x, startingPosition.y + positionDistance, 0.0f);
    }
}
