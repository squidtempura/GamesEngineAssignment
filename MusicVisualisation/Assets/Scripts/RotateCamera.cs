using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pivotPoint  = new Vector3(0f,0f,0f); 
		transform.RotateAround(pivotPoint , Vector3.up, 0.02f + Audios.getAvgMaxFrequency()/20f);
    }
}
