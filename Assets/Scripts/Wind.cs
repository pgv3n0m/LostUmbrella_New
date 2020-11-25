using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public UmbrellaScript _Umbrella;
    public AudioSource windSFX;

    public int id;
    //public Transform windDirection;
    public Vector2 direction;
    public Magnitude magnitude; //To have a non-primitive float value; i.e. give it a pointer.

    // Start is called before the first frame update
    public bool isWindOn;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Umbrella") && !isWindOn)
        {
            isWindOn = true;
            _Umbrella.addForce(id, magnitude, direction); //Adds Wind to Map
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Umbrella") && isWindOn)
        {
            isWindOn = false;
            _Umbrella.removeForce(id); //Removes Wind from Dictionary
        }
    }

    // Update is called once per frame
    void Update()
    {
        direction = (Vector2)this.transform.right;
        if(isWindOn) _Umbrella.updateForce(id, magnitude, direction);
    }
}
