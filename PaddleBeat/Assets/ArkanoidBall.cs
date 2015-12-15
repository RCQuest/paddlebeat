using UnityEngine;
using System.Collections;

public class ArkanoidBall : MonoBehaviour {

    public Vector3 speed;
    public float respawnYLevel;
    private Vector3 startPosition;
	// Update is called once per frame
	void Update () {
        transform.position = transform.position + speed*Time.deltaTime;
        if (transform.position.y < respawnYLevel) transform.position = startPosition;
	}

    void Start()
    {
        startPosition = transform.position;
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
