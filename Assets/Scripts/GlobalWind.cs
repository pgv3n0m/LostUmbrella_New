using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalWind : MonoBehaviour
{
    public UmbrellaScript umbrella;
    public AudioSource windSFX;

    public int id;
    public Transform windDirection;
    public Vector2 direction;
    public Magnitude magnitude; //To have a non-primitive float value; i.e. give it a pointer.

    public LineRenderer line;
    public ParticleSystem _rainParticle;

    public float currentX_direction = 0;

    public float maxWindDirection;

    public float minSoundVolume;
    public float maxSoundVolume;

    // Update is called once per frame
    void Start()
    {
        umbrella.addForce(id, magnitude, direction);
        StartCoroutine("RandomWindDirection_Set");
    }

    void Update() {

        // Debug Visualization of Global Wind Direction
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, windDirection.position);

        // Apply velocity to rain particles along x based on the wind direction
        var velocityOverLifetime = _rainParticle.velocityOverLifetime;
        velocityOverLifetime.xMultiplier = windDirection.position.x * -1.0f;

        // TODO: Randomize wind changes, keep in mind to change it gradually since this is Update()
        windDirection.transform.position = Vector3.Lerp(windDirection.position, new Vector3(currentX_direction, windDirection.position.y, 0), Time.deltaTime * 0.3f);

        direction = (Vector2)windDirection.position - Vector2.zero;
        umbrella.updateForce(id, magnitude, direction);

        //Fade sound in and out based on parallelity with umbrella
        if (umbrella.open())
        {
            float parallelityToUmbrella = Vector2.Angle(umbrella.transform.up, direction);
            parallelityToUmbrella = Mathf.Abs((90 - parallelityToUmbrella) / 90.0f);
            if(maxSoundVolume <= 1f && maxSoundVolume >= 0f)  windSFX.volume = parallelityToUmbrella * maxSoundVolume;
        }
        else if(minSoundVolume <= 1f && minSoundVolume >= 0f) windSFX.volume = minSoundVolume;
    }

    private IEnumerator RandomWindDirection_Set()
    {
        yield return new WaitForSeconds(Random.Range(1f,1.2f));

        float x = Random.Range(1f,10f);
        float y = Mathf.Log(x, 10f);

        currentX_direction = (2 * y - 1) * maxWindDirection; 
        StartCoroutine("RandomWindDirection_Set");
    }
}
