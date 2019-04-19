using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetShake : MonoBehaviour {


    private Vector3 originPosition;
    private Quaternion originRotation;
    float shake_decay = 0.02f;
    float shake_intensity = 0.2f;
    private float temp_shake_intensity = 0;
	

	Vector3 OriginalPosition;


	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (temp_shake_intensity > 0)
        {
            transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
            transform.rotation = new Quaternion(
                originRotation.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.y + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.z + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
                originRotation.w + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f);
            temp_shake_intensity -= shake_decay;
        }      
	}


    public void Shake()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
        temp_shake_intensity = shake_intensity;

    }
}
