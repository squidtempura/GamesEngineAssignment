using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    AudioSource audioSource;
    public static float[] samples = new float[512];
	public static float[] samplesCube = new float[64];
	public static float[] samplesSphere = new float[256];
    public static float[] audioBandBuffers = new float[8];
    static float[] freqBandHighest = new float[8];

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
		for (int i = 0; i < 64; i ++)
		{
			samplesCube[i] = samples[i];
		}
		for (int j = 0; j < 256; j ++)
		{
			samplesSphere[j] = samples[j];
		}
    }

    void GetAudioSource()
    {
        audioSource.GetSpectrumData(samplesCube,0,FFTWindow.Blackman);
		audioSource.GetSpectrumData(samplesSphere,0,FFTWindow.Blackman);
    }

    // Update is called once per frame
    void Update()
    {
        GetAudioSource();
        getAvgMaxFrequency();
    }
    public static float getAvgMaxFrequency() {
		float avg = 0;

		for (int k = 0; k < 8; k++) {
			avg += freqBandHighest[k];
		}
		avg /= 8f;
		return avg;
	}
}
