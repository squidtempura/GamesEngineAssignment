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
        Renderer render = spherePrefab.GetComponent<Renderer>();
        for(int i = 0; i < 512; i++)
        {
            for (int j = 0; j<7;j++)
            {
                if(spheres != null)
                {
                    render.sharedMaterial = materials[j];
                }
            }
        }
        
    }
}
