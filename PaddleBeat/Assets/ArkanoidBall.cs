using UnityEngine;
using System.Collections;

public class ArkanoidBall : MonoBehaviour {

    public Vector3 speed;
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + speed*Time.deltaTime;
	}

    public void reflectX(float refraction,float spread)
    {
        speed.x = -speed.x;
        speed.y = speed.y + refraction + spread;
    }
    public void reflectY(float refraction, float spread)
    {
        speed.y = -speed.y;
        speed.x = speed.x + refraction + spread;
    }

    
}
