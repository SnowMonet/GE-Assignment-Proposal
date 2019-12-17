using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAmplitude : MonoBehaviour
{
    public float startScale, maxScale;
    public bool useBuffer;
    public float red, green, blue;
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
        if(useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, (AudioData.amplitudeBuffer * maxScale) + startScale);
            Color color = new Color(red * AudioData.amplitude, green * AudioData.amplitude, blue * AudioData.amplitude);
            material.SetColor("EmissionColor", color);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, (AudioData.amplitude * maxScale) + startScale);
            Color color = new Color(red * AudioData.amplitude, green * AudioData.amplitude, blue * AudioData.amplitude);
            material.SetColor("EmissionColor", color);
        }
    }
}
