using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    AudioSource audioSource;
    public static float[] cubes = new float[512];
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void GetAudioSource()
    {
        audioSource.GetSpectrumData(cubes,0,FFTWindow.Blackman);
    }

    // Update is called once per frame
    void Update()
    {
        GetAudioSource();
    }
}
