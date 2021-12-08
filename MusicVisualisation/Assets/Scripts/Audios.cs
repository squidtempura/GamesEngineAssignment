using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    AudioSource audioSource;
    public static float[] cubes = new float[512];
    public static float[] freqBand = new float[8];
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
        MakeFrequencyBands();
    }

    void MakeFrequencyBands() {
		int count = 0;

		for (int i = 0; i < 8; i++)  {
			float average = 0;
			int sampleCount = (int)Mathf.Pow (2, i + 1);

			if (i == 7) {
				sampleCount += 2;
			}

			for (int j = 0; j < sampleCount; j++) {
				average += cubes [count];
				count++;
			}

			average /= count;
			freqBand[i] = (i+1) * 100 * average;
		}
	}
}
