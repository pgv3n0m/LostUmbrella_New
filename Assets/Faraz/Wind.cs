using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{

    public int windId;
    public Umbrella_Movement1 _Umbrella;

    public Transform windDirection;
    public Vector2 direction;

    public LineRenderer line;
    public float forceIntensity;

    // Start is called before the first frame update
    public bool isWindOn;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Umbrella") && !isWindOn)
        
        {
            isWindOn = true;
            _Umbrella.addForce(windId,forceIntensity,direction); //Adds Wind to Map
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Umbrella") && isWindOn)
        {
            isWindOn = false;
            _Umbrella.removeForce(windId); //Removes Wind from Dictionary
        }

    }

    // Update is called once per frame
    void Update()
    {

        
            direction = (Vector2)windDirection.position - (Vector2)this.transform.position;

            line.SetPosition(0, this.transform.position);
            line.SetPosition(1, windDirection.position);
        

        
    }

  
}
