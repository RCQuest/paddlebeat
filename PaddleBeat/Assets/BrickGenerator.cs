using UnityEngine;
using System.Collections;
using Rhythmify;

public class BrickGenerator : _AbstractRhythmObject {

    public GameObject lowPointNodeL;
    public GameObject lowPointNodeC;
    public GameObject lowPointNodeR;

    public GameObject brickContainerL;
    public GameObject brickContainerC;
    public GameObject brickContainerR;

    public GameObject brickPrefab;

    public float frequencyPerBeat;

    public float topLineY;

    private float counter=0f;

    override protected void rhythmUpdate(int beat)
    {
        counter += frequencyPerBeat;
        if(counter>1.0f)
        {
            brickContainerL.transform.position =
                new Vector3(brickContainerL.transform.position.x,
                            brickContainerL.transform.position.y
                            - brickPrefab.GetComponent<Renderer>().bounds.size.y,
                            0.0f);
            brickContainerC.transform.position =
                new Vector3(brickContainerC.transform.position.x,
                            brickContainerC.transform.position.y
                            - brickPrefab.GetComponent<Renderer>().bounds.size.y,
                            0.0f);
            brickContainerR.transform.position =                
                new Vector3(brickContainerR.transform.position.x,
                            brickContainerR.transform.position.y
                            - brickPrefab.GetComponent<Renderer>().bounds.size.y,
                            0.0f);
            counter = 0.0f;
            (Instantiate(brickPrefab, 
                new Vector3(lowPointNodeL.transform.position.x,topLineY,0.0f),
                Quaternion.identity) as GameObject)
                .transform.parent = brickContainerL.transform;
            (Instantiate(brickPrefab, 
                new Vector3(lowPointNodeC.transform.position.x, topLineY, 0.0f), 
                Quaternion.identity) as GameObject)
                .transform.parent = brickContainerC.transform;
            (Instantiate(brickPrefab, 
                new Vector3(lowPointNodeR.transform.position.x, topLineY, 0.0f), 
                Quaternion.identity) as GameObject)
                .transform.parent = brickContainerR.transform;
        }
    }
}
