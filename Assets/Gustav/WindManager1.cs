using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WindManager1 : MonoBehaviour
{
    public Umbrella_Movement1 umbrella;
    public Vector2 windDirection;
    public Vector2 direction;
    
    public LineRenderer line;

    public float angleWithWind;

    public float forceIntensity;
    public float maxForce;
    public float intensity;

    public AudioSource windSFX;
    void Update()
    {
        forceIntensity = Mathf.Abs( (90 - angleWithWind)/ 90.0f );


        direction = windDirection - Vector2.zero;

        line.SetPosition(0, Vector2.zero);
        line.SetPosition(1, windDirection);

        angleWithWind = Vector2.Angle(umbrella.transform.up, direction);

        //if (forceIntensity > 0.9f)
        //{
        //    umbrella.GlobalWind = true;
        //    windSFX.volume += Time.deltaTime * 0.5f ;


        //}
        //else
        //{
        //    umbrella.GlobalWind = false;
        //    windSFX.volume -= Time.deltaTime * 0.5f;

        //}
        //umbrella.GlobalWind = true;
        //windSFX.volume += Time.deltaTime * 0.5f;
    }



}
