using UnityEngine;
using System.Collections;

public class ReflectBall : MonoBehaviour {

    public bool reflectX;
    public bool reflectY;
    public bool refract;
    public float spread;
    public float refractionMultiplier;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            float refraction = 0f;
            if (reflectX)
            {
                
                if (refract)
                    refraction=other.transform.position.x - transform.position.x;
                other.GetComponent<ArkanoidBall>().reflectX(refraction*refractionMultiplier, spread * Random.Range(-1f, 1f));
            }
                

            if (reflectY)
            {
                if (refract)
                    refraction = other.transform.position.y - transform.position.y;
                other.GetComponent<ArkanoidBall>().reflectY(refraction * refractionMultiplier, spread * Random.Range(-1f, 1f));
            }
        }
    }

}
