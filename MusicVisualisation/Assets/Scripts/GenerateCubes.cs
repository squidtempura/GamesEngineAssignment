using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCubes : MonoBehaviour
{
    //prefab to instantiate
    public GameObject CubePrefab;
    //scales the height of each cube 
    public float scale = 100;
    //store 128 cubes into an array of game objects
    GameObject[] cubes = new GameObject[128];

    // Start is called before the first frame update
    // instantiate 128 cubes in a circle of radius 100
    void Start()
    {
        // radius of the circle of cubes instantiated
        float radius =  150;
        // iterate 128 times to instantiate cubes
        for(int i = 0; i < 128; i++)
        {
            // spawns a copy of the cube
            GameObject cube = Instantiate(CubePrefab);
            // assign the copy to the cubes array
            cubes[i] = cube;
            //name the cube
            cube.name = "Cube" + i;
            // set the parent to the object
            cube.transform.parent = this.transform;
            // calculate the new x coordinate and z coordinate using Sin Cos
            float angle = (360f/128)*i;
            float xPos = radius*Mathf.Cos(angle*Mathf.Deg2Rad);
            float zPos = radius*Mathf.Sin(angle*Mathf.Deg2Rad);
            // rotate around the y axis
            cube.transform.eulerAngles = new Vector3(0,-1f*angle,0);
            // the new coordinate of the cube
            cube.transform.position = new Vector3(xPos,0,zPos);
        }
    }

    // Update is called once per frame
    // take the data collected in Audios class. every data in the array will be used 
    // to set the heights of the cubes. if some of the value are equal to 0, then set a small value 
    // to make the cube not disappear.
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
