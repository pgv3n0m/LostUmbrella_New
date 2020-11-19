using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalWind : MonoBehaviour
{
    public Umbrella_Movement1 umbrella;
    public AudioSource windSFX;

    public int id;
    public Transform windDirection;
    public Vector2 direction;
    public float magnitude;
    public Magnitude m; //To have a non-primitive float value; i.e. give it a pointer.

    public LineRenderer line;



    // Update is called once per frame
    void Start()
    {
        umbrella.addForce(id, m, direction);

    }
    void Update() {
        //umbrella.removeForce(id);


        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, windDirection.position);

        // TODO: Randomize wind changes, keep in mind to change it gradually since this is Update()

        direction = (Vector2)windDirection.position - Vector2.zero;

        m.val = magnitude;
    }
}
