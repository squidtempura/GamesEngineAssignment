using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCubes : MonoBehaviour
{
    public GameObject CubePrefab;
    public float scale = 80;
    GameObject[] cubes = new GameObject[128];

    // Start is called before the first frame update
    void Start()
    {
        float radius =  100;
        for(int i = 0; i < 128; i++)
        {
            GameObject cube = Instantiate(CubePrefab);
            cubes[i] = cube;
            cube.name = "Cube" + i;
            cube.transform.parent = this.transform;
            float angle = (360f/128)*i;
            float xPos = radius*Mathf.Cos(angle*Mathf.Deg2Rad);
            float zPos = radius*Mathf.Sin(angle*Mathf.Deg2Rad);
            cube.transform.eulerAngles = new Vector3(0,-1f*angle,0);
            cube.transform.position = new Vector3(xPos,0,zPos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 128; i ++)
        {
            if(cubes != null && i <64)
            {
                GameObject cube = cubes[i];
                cube.transform.localScale = new Vector3(1,1+scale*Mathf.Abs(Audios.samplesCube[i]),1);
            }
            else
            {
                GameObject cube = cubes[i];
                cube.transform.localScale = new Vector3(1,1+scale*Mathf.Abs(Audios.samplesCube[i-64]),1);
            }
        }
    }
}
