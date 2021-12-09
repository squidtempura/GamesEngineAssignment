using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSpheres : MonoBehaviour
{
    public GameObject spherePrefab;
    GameObject[] spheres = new GameObject[512];
    public float [] angles = new float[512];

    public Material[] materials;

    public float shift = 1f;

    public float scale = 100;

    // Start is called before the first frame update
    void Start()
    {
        float radius = 100;
        for (int i = 0; i < 512; i ++)
        {
            GameObject sphere = Instantiate(spherePrefab);
            spheres[i] = sphere;
            sphere.name = "Sphere" +i;
            sphere.transform.parent = this.transform;
            float angle =(360f/512f)*i;
            angles[i] = angle;
            float xPos = radius*Mathf.Cos(angle);
            float zPos = radius*Mathf.Sin(angle);
            transform.eulerAngles = new Vector3(angle,0,0);
            shift = shift*(-1);
            sphere.transform.position = new Vector3(shift*xPos,0,shift*zPos);

        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 512; i++)
        {
            if (spheres != null) {
				GameObject sphere = spheres [i];
				Renderer rend = sphere.GetComponent<Renderer>();
				rend.enabled = true;
                int j;
                
                if(i<=64)
                {
                    j = 0;
                }else if(i <= 128)
                {
                    j = 1;
                }
                else if(i <= 192)
                {
                    j = 2;
                }
                else if(i <= 256)
                {
                    j = 3;
                }
                else if(i <= 320)
                {
                    j = 4;
                }
                else if(i <= 384)
                {
                    j = 5;
                }
                else if(i <= 448)
                {
                    j = 6;
                }
                else
                {
                    j = 7;
                }
                
                rend.sharedMaterial = materials[j]; 
                Transform s = sphere.transform;
            }

        }
    }
}
