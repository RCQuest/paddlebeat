using UnityEngine;
using System.Collections;

public class SidePaddleAnimation : MonoBehaviour
{
    private float animState;
    private float animFrameDuration=0.5f;
    public bool isRight;
    private Vector3 rotationCentrepoint;
    public GameObject rotationCentrepointObject;
    private float angle=50f;
	// Use this for initialization
	void Start ()
    {
        //animState = 0f;
        //rotationCentrepoint = rotationCentrepointObject.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (animState > 0)
        //{
        //    animState -= Time.deltaTime;
        //    transform.RotateAround(rotationCentrepoint, Vector3.forward, isRight ? angle * Time.deltaTime/animFrameDuration : -angle * Time.deltaTime / animFrameDuration);
       // }
        //else animState = 0;
        
    }

    public void startAnimation()
    {
        //animState = animFrameDuration;
        //transform.RotateAround(rotationCentrepoint, Vector3.forward, isRight ? -angle : angle);
    }
}
