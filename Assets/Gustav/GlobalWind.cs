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
    public ParticleSystem _rainParticle;

    public float currentX_direction = 0;

    // Update is called once per frame
    void Start()
    {
        direction = (Vector2)windDirection.position - Vector2.zero; // Get wind direction in first frame

        umbrella.addForce(id, m, direction);
        StartCoroutine("RandomWindDirection_Set");

    }



    void Update() {

        // Debug Visualization of Global Wind Direction
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, windDirection.position);


        // Apply velocity to rain particles along x based on the wind direction
        var velocityOverLifetime = _rainParticle.velocityOverLifetime;
        velocityOverLifetime.xMultiplier = windDirection.position.x;

        // TODO: Randomize wind changes, keep in mind to change it gradually since this is Update()
        windDirection.transform.position = Vector3.Lerp(windDirection.transform.position, new Vector3(currentX_direction, 27.0f, 0), Time.deltaTime * 0.5f);

        //direction = (Vector2)windDirection.position - Vector2.zero;
        m.val = magnitude;

    }

    public IEnumerator RandomWindDirection_Set()
    {
        yield return new WaitForSeconds(Random.Range(10f,15f));
        currentX_direction = Random.Range(-25.0f,25.0f);
        StartCoroutine("RandomWindDirection_Set");
    }
}
