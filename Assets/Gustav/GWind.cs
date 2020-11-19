using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GWind : MonoBehaviour
{
    public Umbrella_Movement1 umbrella;
    public AudioSource windSFX;

    public int id;
    public Vector2 windDirection;
    public Vector2 direction;
    public float magnitude;
    public Magnitude m; //To have a non-primitive float value; i.e. give it a pointer.

    // Update is called once per frame
    void Update() { 
        direction = windDirection - Vector2.zero;

        m.val = magnitude;
    }

    void OnTriggerEnter2D(Collider2D other) { umbrella.addForce(id, m, direction); }

    void OnTriggerExit2D(Collider2D other) { umbrella.removeForce(id); }
}
