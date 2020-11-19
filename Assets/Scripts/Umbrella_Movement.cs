using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella_Movement : MonoBehaviour
{
    public WindManager wm;
    public bool GlobalWind;
    public Rigidbody2D _cacheRigidbody;

    public Transform _centerOfMass;
    // Start is called before the first frame update
    void Awake()
    {
        _cacheRigidbody.centerOfMass = _centerOfMass.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _cacheRigidbody.AddTorque(-200.0f * Input.GetAxis("Horizontal"));


        //if (GlobalWind)
       // {
            //if (_cacheRigidbody.velocity.magnitude < 10.0f)
            //    _cacheRigidbody.velocity += (Vector2)this.transform.up * wm.forceIntensity * wm.maxForce;
            if (_cacheRigidbody.velocity.magnitude < 10.0f)
                _cacheRigidbody.velocity += (Vector2)wm.direction * wm.forceIntensity * wm.maxForce * Time.deltaTime;   // v=a*dt
        //}
    }
}
