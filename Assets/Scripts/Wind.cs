using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour, IUpdateable
{
    public UmbrellaScript _Umbrella;
    public AudioSource windSFX;

    public int id;
    public Vector2 direction;
    public Magnitude magnitude; //To have a non-primitive float value; i.e. give it a pointer. In case we want dynamic changes later on

    public bool isWindOn;

    private void Start()
    {
        windSFX.Play();
        _Umbrella._gm.gl.RegisterUpdateObject(this);
    }

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
    public virtual void OnUpdate(float dt)
    {
        
            direction = (Vector2)this.transform.right;
        if(isWindOn) _Umbrella.updateForce(id, magnitude, direction);

        //Fade sound in and out based on umbrella proximity = 100% when player is inside, 0% when ofscreen
        float distanceToUmbrella = Mathf.Abs(this.transform.position.x - _Umbrella.transform.position.x);
        if (distanceToUmbrella >= 30f) windSFX.volume = 0;
        else windSFX.volume = 1.0f - (distanceToUmbrella / 30);
    }
}
