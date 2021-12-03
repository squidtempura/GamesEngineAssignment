using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCubes : MonoBehaviour
{
    public GameObject CubePrefab;
    GameObject[] cubes = new GameObject[512];

    // Start is called before the first frame update
    void Start()
    {
        float radius =  10;
        for(int i = 0; i < 512; i++)
        {
            GameObject cube = Instantiate(CubePrefab);
            cubes[i] = cube;
            cube.name = "Cube" + i;
            cube.transform.parent = this.transform;
            float angle = (360f/512f)*i;
            float xPos = radius*Mathf.Cos(angle*Mathf.Deg2Rad);
            float zPos = radius*Mathf.Sin(angle*Mathf.Deg2Rad);
            cube.transform.eulerAngles = new Vector3(0,-1f*angle,0);
            cube.transform.position = new Vector3(xPos,0,zPos);
        }
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
