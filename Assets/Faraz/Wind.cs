using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{

    public Umbrella_Movement _Umbrella;

    public Transform windDirection;
    public Vector2 direction;

    public LineRenderer line;

    public float angleWithWind;

    public float forceIntensity;
    public float maxForce;

    // Start is called before the first frame update
    public bool isWindOn;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Umbrella") && !isWindOn)
        
        {
            isWindOn = true;
            //Add Force to Umbrella
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Umbrella") && isWindOn)
        {
            isWindOn = false;
            //Remove Force to Umbrella
        }

    }

    // Update is called once per frame
    void Update()
    {
        
            forceIntensity = Mathf.Abs((90 - angleWithWind) / 90.0f);

            direction = (Vector2)windDirection.position - (Vector2)this.transform.position;

            line.SetPosition(0, this.transform.position);
            line.SetPosition(1, windDirection.position);

            angleWithWind = Vector2.Angle(_Umbrella.transform.up, direction);
        
    }

    //void FixedUpdate()
    //{
    //    if (isWindOn)
    //    {
    //        if (_Umbrella._cacheRigidbody.velocity.magnitude < 10.0f)
    //            _Umbrella._cacheRigidbody.velocity += (Vector2)direction * forceIntensity * maxForce * Time.deltaTime;
    //    }
    //}
}
