using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{
    //public GameObject nodeL;
    //public GameObject nodeC;
    //public GameObject nodeR;

    public float speed;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Input.GetAxis("Horizontal")*speed * Time.deltaTime, Input.GetAxis("Vertical")*speed*Time.deltaTime, 0.0f);
    }
}
