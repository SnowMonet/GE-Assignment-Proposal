using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]

public class AudioData : MonoBehaviour
{
    AudioSource audioSource;
    public static float[] samples = new float[256];
    public static float[] freqBand = new float[8];
    public static float[] bandBuffer = new float[8];
    public static float[] bandBufferPosition = new float[8];

    float[] freqBandHighest = new float[8];
    public static float[] audioBand = new float[8];
    public static float[] audioBandBuffer = new float[8];

    public static float amplitude, amplitudeBuffer;
    float amplitudeHightest;

    float[] bufferDecrease = new float[8];

    public float averageMultiplier;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        BandBufferPosition();
        CreateAudioBands();
        GetAmplitude();
    }

    void GetAmplitude()
    {
        float currentAmplitude = 0;
        float currentAmplitudeBuffer = 0;

        for(int i = 0; i < 8; i++)
        {
            currentAmplitude += audioBand[i];
            currentAmplitudeBuffer += audioBandBuffer[i];
        }

        if(currentAmplitude > amplitudeHightest)
        {
            amplitudeHightest = currentAmplitude;
        }

        amplitude = currentAmplitude / amplitudeHightest;
        amplitudeBuffer = currentAmplitudeBuffer / amplitudeHightest;
    }

    void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqBand[i] > freqBandHighest[i])
            {
                freqBandHighest[i] = freqBand[i];
            }

            audioBand[i] = (freqBand[i] / freqBandHighest[i]);
            audioBandBuffer[i] = (bandBuffer[i] / freqBandHighest[i]);
        }
    }

    void GetSpectrumAudioSource()
    {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void MakeFrequencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i);

            for (int j = 0; j < sampleCount; j++)
            {
                average += samples [count] * (count + 1);
                count++;
            }

            average /= count;

            freqBand [i] = average * averageMultiplier;
        }
    }

    void BandBuffer()
    {
        for (int g = 0; g < 8; g++)
        {
            if (freqBand [g] > bandBuffer [g])
            {
                bandBuffer[g] = freqBand[g];
                bufferDecrease[g] = 0.5f;
            }

            if (freqBand[g] < bandBuffer[g])
            {
                bandBuffer[g] -= bufferDecrease[g];
                bufferDecrease[g] *= 1.2f;
            }
        }
    }

    void BandBufferPosition()
    {
        for (int g = 0; g < 8; g++)
        {
            if (freqBand[g] > bandBufferPosition[g])
            {
                bandBufferPosition[g] = freqBand[g];
                bufferDecrease[g] = 0.005f;
            }

            if (freqBand[g] < bandBufferPosition[g])
            {
                bandBufferPosition[g] -= bufferDecrease[g];
                bufferDecrease[g] *= 1.2f;
            }
        }
    }
}
