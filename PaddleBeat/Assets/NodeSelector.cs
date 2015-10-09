using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tuple<T1, T2>
{
	public T1 First { get; private set; }
	public T2 Second { get; private set; }
	internal Tuple(T1 first, T2 second)
	{
		First = first;
		Second = second;
	}
}

public enum MoveType{
	DEFAULT
};

public class NodeSelector : MonoBehaviour {

	public float CURRENT_SPEED;
	public float timer;
	public List<GameObject> nodes;
	public List<Tuple<MoveType, int>> sequence;
	public int currentStep;
	public BallMovement movement;
	// Use this for initialization
	void Start () {

		sequence = new List<Tuple<MoveType, int>>(){
			new Tuple<MoveType, int>(MoveType.DEFAULT,1),
			new Tuple<MoveType, int>(MoveType.DEFAULT,0),
			new Tuple<MoveType, int>(MoveType.DEFAULT,1),
			new Tuple<MoveType, int>(MoveType.DEFAULT,2),
			new Tuple<MoveType, int>(MoveType.DEFAULT,3),
			new Tuple<MoveType, int>(MoveType.DEFAULT,5),
			new Tuple<MoveType, int>(MoveType.DEFAULT,10),
			new Tuple<MoveType, int>(MoveType.DEFAULT,9),
			new Tuple<MoveType, int>(MoveType.DEFAULT,8),
			new Tuple<MoveType, int>(MoveType.DEFAULT,7),
			new Tuple<MoveType, int>(MoveType.DEFAULT,6),
			new Tuple<MoveType, int>(MoveType.DEFAULT,5),
			new Tuple<MoveType, int>(MoveType.DEFAULT,4),
			new Tuple<MoveType, int>(MoveType.DEFAULT,3),
			new Tuple<MoveType, int>(MoveType.DEFAULT,1),
			new Tuple<MoveType, int>(MoveType.DEFAULT,3),
			new Tuple<MoveType, int>(MoveType.DEFAULT,0),
			new Tuple<MoveType, int>(MoveType.DEFAULT,2),
			new Tuple<MoveType, int>(MoveType.DEFAULT,10),
			new Tuple<MoveType, int>(MoveType.DEFAULT,0)
		};

		movement.nodeNext=nodes[sequence[currentStep].Second];
	}
	
	// Update is called once per frame
	void Update () {
		timer=timer+Time.deltaTime;
		if(timer>CURRENT_SPEED)
		{

			Debug.Log (sequence.Count);
			Vector3 lastNodePosition = nodes[sequence[currentStep].Second].transform.position;
			timer=0;
			currentStep++;
			if(currentStep==sequence.Count)
				currentStep=0;
			movement.nodeNext=nodes[sequence[currentStep].Second];
			movement.speed=Vector3.Distance(lastNodePosition, nodes[sequence[currentStep].Second].transform.position)/CURRENT_SPEED;
		}
	}
}
