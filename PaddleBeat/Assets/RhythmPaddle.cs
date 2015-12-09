using UnityEngine;
using System.Collections;

public class RhythmPaddle : MonoBehaviour {
    public float width;
	void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            transform.position = new Vector3(transform.position.x - width, transform.position.y, 0.0f);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            transform.position = new Vector3(transform.position.x + width, transform.position.y, 0.0f);
    }
}
