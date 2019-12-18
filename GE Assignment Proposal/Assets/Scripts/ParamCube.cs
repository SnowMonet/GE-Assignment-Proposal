using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{

    public int band;
    public float startScale, scaleMultiplier;
    public bool useBuffer;

    Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().materials[0];
        material.EnableKeyword("EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, (AudioData.bandBuffer[band] * scaleMultiplier) + startScale);
            Color color = new Color(AudioData.audioBandBuffer[band], AudioData.audioBandBuffer[band], AudioData.audioBandBuffer[band]);
            material.SetColor("EmissionColor", color);
        }
        else
        {
            //transform.localScale = new Vector3(transform.localScale.x, (AudioData.freqBand[band] * scaleMultiplier) + startScale, transform.localScale.z);
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, (AudioData.freqBand[band] * scaleMultiplier) + startScale);
            Color color = new Color(AudioData.audioBand[band], AudioData.audioBand[band], AudioData.audioBand[band]);
            material.SetColor("EmissionColor", color);
        }
    }
}
