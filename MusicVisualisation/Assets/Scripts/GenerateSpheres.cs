using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpheres : MonoBehaviour
{
    public GameObject spherePrefab;
    // array that contains 256 spheres
    GameObject[] spheres = new GameObject[256];
    public float [] angles = new float[256];
    // materials with different colors for the sphere
    public Material[] materials;
    // variable that use to calculate new coordinate of the sphere
    public float shift = 1f;
    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        //radius of the big sphere
        float radius = 100;
        //iterate 256 times to instantiate the spheres
        for (int i = 0; i < 256; i ++)
        {
            // make a copy of the prefab
            GameObject sphere = Instantiate(spherePrefab);
            // assign every copy to the repective array position
            spheres[i] = sphere;
            // name every sphere 
            sphere.name = "Sphere" +i;
            // set the parent to the object
            sphere.transform.parent = this.transform;
            // calculate how much degree the sphere should move and the new coordinate
            float angle =(360f/256)*i;
            angles[i] = angle;
            float xPos = radius*Mathf.Cos(angle);
            float zPos = radius*Mathf.Sin(angle);
            // rotate around the x axis
            transform.eulerAngles = new Vector3(angle,0,0);
            // make the x,z coordinate shift to generate a sphere.
            shift = shift*(-1);
            sphere.transform.position = new Vector3(shift*xPos,0,shift*zPos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 256; i++)
        {
            if (spheres != null) {
				GameObject sphere = spheres [i];
				Renderer rend = sphere.GetComponent<Renderer>();
				rend.enabled = true;
                int j;                          
                // every 32 spheres in a group
                if(i<=32)
                {
                    j = 0;
                }
                else if(i <= 64)
                {
                    j = 1;
                }
                else if(i<=128)
                {
                    j = 2;
                }

                else if(i <= 160)
                {
                    j = 3;
                }
                else if(i <= 192)
                {
                    j = 4;
                }
                else if(i <= 224)
                {
                    j = 5;
                }
                else 
                {
                    j = 6;
                }
                
                // every 32 spheres will be a kind of color
                rend.sharedMaterial = materials[j]; 
                // scale the sphere
                if(sphere != null)
                {
                    GameObject ss = spheres[i];
                    ss.transform.localScale = new Vector3(1.5f+scale*Mathf.Abs(Audios.samplesSphere[i]),1.5f+scale*Mathf.Abs(Audios.samplesSphere[i]),1.5f+scale*Mathf.Abs(Audios.samplesSphere[i]));
                }
                
            }
        }
    }
}
