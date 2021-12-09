using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    AudioSource audioSource;
    public static float[] cubes = new float[512];
    
    public static float[] freqBand = new float[8];

    public static float[] bufferBand = new float[8];

    public float[] bufferDecrease = new float[8];
    public static float[] audioBands = new float[8];
    public static float[] audioBandBuffers = new float[8];
    static float[] freqBandHighest = new float[8];

    // Start is called before the first frame update

    void CreateAudioBands() {
		for (int k = 0; k < 8; k++) {
			if (freqBand[k] > freqBandHighest[k]) {
				freqBandHighest[k] = freqBand[k];
			}
			audioBands [k] = freqBand [k] / freqBandHighest[k];
			audioBandBuffers [k] = bufferBand [k] / freqBandHighest[k];

		}
	}

    void BufferBands(){
		for (int k = 0; k < 8; k++) {
			if (freqBand[k] > bufferBand[k]){
				bufferBand [k] = freqBand [k];
				bufferDecrease [k] = 0.005f;
			}
			if (freqBand[k] < bufferBand[k] && (bufferBand[k] - bufferDecrease [k]) > 0){
				bufferBand [k] -= bufferDecrease [k];
				bufferDecrease [k] *= 1.4f;
			}
		}
	}

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
        BufferBands();
        CreateAudioBands();
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

    public static float getAvgFrequency() {
		float avg = 0;

		for (int k = 0; k < 8; k++) {
			avg += freqBand[k];
		}

		avg /= 8f;
		return avg;
	}
}
