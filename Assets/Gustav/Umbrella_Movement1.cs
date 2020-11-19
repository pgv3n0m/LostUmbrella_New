using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella_Movement1 : MonoBehaviour
{
    // TODO: Remove
    // ------------
    public WindManager1 wm;
    public bool GlobalWind;
    // ------------

    // 'UI/Game' umbrella elements to manipulate
    public Rigidbody2D _cacheRigidbody;
    public Transform _centerOfMass;

    // Forces acting upon umbrella, gravity is handled by Unity
    private Dictionary<int, float> magnitudes;
    private Dictionary<int, Vector2> directions;

    // Start is called before the first frame update
    void Awake() { _cacheRigidbody.centerOfMass = _centerOfMass.localPosition; }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Rotates/angles the umbrella based on user input
        _cacheRigidbody.AddTorque(-200.0f * Input.GetAxis("Horizontal"));

        // TODO: Remove
        // ------------
        if (GlobalWind)
        {
            //if (_cacheRigidbody.velocity.magnitude < 10.0f)
            //    _cacheRigidbody.velocity += (Vector2)this.transform.up * wm.forceIntensity * wm.maxForce;
            if (_cacheRigidbody.velocity.magnitude < 10.0f)
                _cacheRigidbody.velocity += (Vector2)wm.direction * wm.forceIntensity * wm.maxForce * Time.deltaTime;   // v=a*dt
        }
        // ------------

        if (magnitudes != null && directions != null)
        {
            foreach (int k in magnitudes.Keys)
            {
                if (directions.ContainsKey(k)) applyForce(magnitudes[k], directions[k]);
            }
        }
    }

    public void addForce(int id, float intensity, Vector2 force)
    {
        if (force == null) return;
        if (magnitudes == null) magnitudes = new Dictionary<int, float>();
        if (directions == null) directions = new Dictionary<int, Vector2>();
        magnitudes.Add(id, intensity);

        Vector2 newF = new Vector2(force.x, force.y);
        newF.Normalize();
        directions.Add(id, newF);
    }

    public void removeForce(int id)
    {
        if (magnitudes == null || directions == null) return;
        magnitudes.Remove(id);
        directions.Remove(id);
    }

    private void applyForce(float magnitude, Vector2 direction)
    {
        if (direction == null) return;
        
        //Mimics wind resistant of an umbrella
        float parallelity = Vector2.Angle(gameObject.transform.up, direction);
        
        
        if (_cacheRigidbody.velocity.magnitude < 10.0f)
            _cacheRigidbody.velocity += (Vector2)direction * parallelity * magnitude * Time.deltaTime;
    }
}
