using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangentCircles : CircleTangent
{
    public GameObject circlePrefab;
    private GameObject innerCircleObject, outerCircleObject;
    public Vector4 innerCircle, outerCircle;

    private Vector4[] tangentCircle;
    private GameObject[] tangentObject;

    [Range(1,64)]
    public int circleAmount;

    private Vector2 thumbstickL, thumbstickLSmooth;

    [Range(0, 1)]
    public float distanceToOuterTangent;
    [Range(0, 1)]
    public float movementSmooth;
    public bool useSmoothMovement;

    private float radiusChange;
    [Range(0.1f, 10f)]
    public float radiusChangeSpeed;


    
    public int band;
    public float startScale, scaleMultiplier;
    public bool useBuffer;
    


    // Start is called before the first frame update
    void Start()
    {
        innerCircleObject = (GameObject)Instantiate(circlePrefab);
        outerCircleObject = (GameObject)Instantiate(circlePrefab);

        tangentCircle = new Vector4[circleAmount];
        tangentObject = new GameObject[circleAmount];

        for (int i = 0; i < circleAmount; i++)
        {
            GameObject tangentInstance = (GameObject)Instantiate(circlePrefab);
            tangentObject[i] = tangentInstance;
            tangentObject[i].transform.parent = this.transform;
        }
    }

    void PlayerInput()
    {
        thumbstickL = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        thumbstickLSmooth = new Vector2(thumbstickLSmooth.x * (1 - movementSmooth) + thumbstickL.x * movementSmooth, 
                                        thumbstickLSmooth.y * (1 - movementSmooth) + thumbstickL.y * movementSmooth);

        radiusChange = Input.GetAxis("TriggerL") - Input.GetAxis("TriggerR");

        if (useSmoothMovement)
        {
            innerCircle = new Vector4((thumbstickLSmooth.x * (outerCircle.w - innerCircle.w) * (1 - distanceToOuterTangent)) + outerCircle.x, 
                                        0.0f, 
                                        (thumbstickLSmooth.y * (outerCircle.w - innerCircle.w) * (1 - distanceToOuterTangent)) + outerCircle.z,
                                        (AudioData.bandBuffer[band] * scaleMultiplier) + startScale);
        }
        else
        {
            innerCircle = new Vector4((thumbstickL.x * (outerCircle.w - innerCircle.w) * (1 - distanceToOuterTangent)) + outerCircle.x, 
                                        0.0f, 
                                        (thumbstickL.y * (outerCircle.w - innerCircle.w) * (1 - distanceToOuterTangent)) + outerCircle.z,
                                        (AudioData.bandBuffer[band] * scaleMultiplier) + startScale);
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        innerCircleObject.transform.position = new Vector3(innerCircle.x, innerCircle.y, innerCircle.z);
        innerCircleObject.transform.localScale = new Vector3(innerCircle.w, innerCircle.w, innerCircle.w) * 2;

        outerCircleObject.transform.position = new Vector3(outerCircle.x, outerCircle.y, outerCircle.z);
        outerCircleObject.transform.localScale = new Vector3(outerCircle.w, outerCircle.w, outerCircle.w) * 2;

        for (int i = 0; i < circleAmount; i++)
        {
            tangentCircle[i] = FindTangentCircle(outerCircle, innerCircle, (360f / circleAmount) * i);
            tangentObject[i].transform.position = new Vector3(tangentCircle[i].x, tangentCircle[i].y, tangentCircle[i].z);
            tangentObject[i].transform.localScale = new Vector3(tangentCircle[i].w, tangentCircle[i].w, tangentCircle[i].w) * 2;
        }
    }
}
