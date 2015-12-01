using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{
    public GameObject nodeL;
    public GameObject nodeC;
    public GameObject nodeR;

    public float speed;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow)&& Input.GetKey(KeyCode.RightArrow))
            transform.position=Vector3.MoveTowards(transform.position,nodeC.transform.position,Time.deltaTime*speed);
        else if (Input.GetKey(KeyCode.LeftArrow))
            transform.position = Vector3.MoveTowards(transform.position, nodeL.transform.position, Time.deltaTime * speed);
        else if (Input.GetKey(KeyCode.RightArrow))
            transform.position = Vector3.MoveTowards(transform.position, nodeR.transform.position, Time.deltaTime * speed);
        else
            transform.position = Vector3.MoveTowards(transform.position, nodeC.transform.position, Time.deltaTime * speed);
    }
}
