using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//get spectrum data from audio source
public class Audios : MonoBehaviour
{
    AudioSource audioSource;
    // divide the range of human audible sounds into 512 parts
    public static float[] samples = new float[512];
    // for the circle of cube, divide the range of the sounds into 64
	public static float[] samplesCube = new float[64];
    // for the spheres, divide the range of the sounds into 256
	public static float[] samplesSphere = new float[256];

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // for the cube, take the first 64 values of the samples array
		for (int i = 0; i < 64; i ++)
		{
			samplesCube[i] = samples[i];
		}
        // for the spheres, take the first 256 values of the samples array
		for (int j = 0; j < 256; j ++)
		{
			samplesSphere[j] = samples[j];
		}
    }

    //listen to the audio source and get all samples from spectrum data into the respective array
    void GetAudioSource()
    {
        audioSource.GetSpectrumData(samplesCube,0,FFTWindow.Blackman);
		audioSource.GetSpectrumData(samplesSphere,0,FFTWindow.Blackman);
    }

    // Update is called once per frame
    void Update()
    {
        GetAudioSource();
    } 
}
