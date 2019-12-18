using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCubeDelay : MonoBehaviour
{

    public int band;
    public float startScale, scaleMultiplier;
    public bool useBuffer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (useBuffer)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, (AudioData.bandBufferPosition[band] * scaleMultiplier) - 50);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, (AudioData.freqBand[band] * scaleMultiplier) - 40);
        }
    }
}