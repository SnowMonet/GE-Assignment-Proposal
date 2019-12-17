using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAmplitude : MonoBehaviour
{
    public float startScale, maxScale;
    public bool useBuffer;
    //public float red, green, blue;
    //Material material;

    // Start is called before the first frame update
    void Start()
    {
        //material = GetComponent<Renderer>().materials[0];
        //material.EnableKeyword("Emission");
    }

    // Update is called once per frame
    void Update()
    {
        if(useBuffer)
        {
            transform.localScale = new Vector3((AudioData.amplitudeBuffer * maxScale) + startScale, (AudioData.amplitudeBuffer * maxScale) + startScale, (AudioData.amplitudeBuffer * maxScale) + startScale);
            //Color color = new Color(red * AudioData.amplitude, green * AudioData.amplitude, blue * AudioData.amplitude);
            //material.SetColor("Color", color);
        }
        else
        {
            transform.localScale = new Vector3((AudioData.amplitudeBuffer * maxScale) + startScale, (AudioData.amplitudeBuffer * maxScale) + startScale, (AudioData.amplitude * maxScale) + startScale);
            //Color color = new Color(red * AudioData.amplitude, green * AudioData.amplitude, blue * AudioData.amplitude);
            //material.SetColor("Color", color);
        }
    }
}
