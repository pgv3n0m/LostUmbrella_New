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

    // Update is called once per frame
    void Update() { direction = windDirection - Vector2.zero; }

    void OnTriggerEnter2D(Collider2D other) { umbrella.addForce(id, magnitude, direction); }

    void OnTriggerExit2D(Collider2D other) { umbrella.removeForce(id); }
}
