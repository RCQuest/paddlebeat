using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour 
{

	public GameObject nodeNext;
	public float speed;
	void Update() 
	{
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, nodeNext.transform.position, step);
	}
}
