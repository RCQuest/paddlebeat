using UnityEngine;
using System.Collections;
using Rhythmify;
using System.Collections.Generic;

public class GameMarshaller : MonoBehaviour {

    public List<GameObject> topNodes;
    public List<GameObject> bumperNodes;
    public MoveToPositions ball;

    void Start()
    {
//        ball.xPositions = getRandomXPositions(200);
        ball.positions = getRandomPositions(200);

    }

    private List<float> getRandomXPositions(int bounces)
    {
        List<float> xPositions = new List<float>();
        for(int i = 0; i< bounces;i++)
        {
            xPositions.Add(topNodes[Random.Range(0,topNodes.Count)].transform.position.x);
            xPositions.Add(bumperNodes[Random.Range(0, bumperNodes.Count)].transform.position.x);
        }
        return xPositions;
    }

    private Vector3[] getRandomPositions(int bounces)
    {
        Vector3[] xPositions = {};
        for (int i = 0; i < bounces; i++)
        {
            xPositions.Add(topNodes[Random.Range(0, topNodes.Count)].transform.position);
            xPositions.Add(bumperNodes[Random.Range(0, bumperNodes.Count)].transform.position);
        }
        return xPositions;
    }

}
