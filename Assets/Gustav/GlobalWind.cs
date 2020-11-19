using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalWind : MonoBehaviour
{
    public Umbrella_Movement1 umbrella;
    public AudioSource windSFX;

    public int id;
    public Vector2 windDirection;
    public Vector2 direction;
    public float magnitude;

    // Update is called once per frame
    void Update() {
        umbrella.removeForce(id);
        
        // TODO: Randomize wind changes, keep in mind to change it gradually since this is Update()

        direction = windDirection - Vector2.zero;

        umbrella.addForce(id, magnitude, direction);
    }
}
