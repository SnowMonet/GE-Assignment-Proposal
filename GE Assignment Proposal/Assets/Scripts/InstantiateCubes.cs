using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateCubes : MonoBehaviour
{
    public GameObject sampleCubePrefab;
    GameObject[] sampleCube = new GameObject[256];

    public float maxScale;
    public float anglesDirection;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 256; i++)
        {
            GameObject instanceSampleCube = (GameObject)Instantiate (sampleCubePrefab);
            instanceSampleCube.transform.position = this.transform.position;
            instanceSampleCube.transform.parent = this.transform;
            instanceSampleCube.name = "Sample Cube " + i;
            this.transform.eulerAngles = new Vector3(0, anglesDirection * i, 0);
            instanceSampleCube.transform.position = Vector3.forward * 100;
            sampleCube[i] = instanceSampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 256; i++)
        {
            if (sampleCube != null)
            {
               
                sampleCube[i].transform.localScale = new Vector3(10, (AudioData.samples[i] * maxScale) + 2, 10);
                
            }
        }

        
    }
}
