using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaScript : MonoBehaviour
{
   

    // 'UI/Game' umbrella elements to manipulate

    [Header("Important References")]
    public Rigidbody2D _cacheRigidbody;
    public Transform _centerOfMass;
    public SpriteRenderer _cacheSpriteRenderer;
    public PolygonCollider2D _polygonCollider;

    [Header("Umbrella Visuals")]

    public BoxCollider2D _closeUmbrella_collider;
    public Sprite _closeUmbrella;
    public Sprite _openUmbrella;
    public bool isOpen = true;


    // Forces acting upon umbrella, gravity is handled by Unity
    private Dictionary<int, Vector2> referenceForces;
    private Dictionary<int, Magnitude> magnitudes;
    private Dictionary<int, Vector2> directions;

    // Start is called before the first frame update
    void Awake() { _cacheRigidbody.centerOfMass = _centerOfMass.localPosition; }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isOpen)
            {
                isOpen = false;
                _cacheSpriteRenderer.sprite = _closeUmbrella;
                _closeUmbrella_collider.enabled = true;
                _polygonCollider.enabled = false;
            }
            else
            {
                isOpen = true;
                _cacheSpriteRenderer.sprite = _openUmbrella;
                _closeUmbrella_collider.enabled = false;
                _polygonCollider.enabled = true;
            }

        }
    }


    void FixedUpdate()
    {
        // Rotates/angles the umbrella based on user input
        _cacheRigidbody.AddTorque(-200.0f * Input.GetAxis("Horizontal"));

       

        if (referenceForces != null && magnitudes != null && directions != null && isOpen)
        {
            updateForces();

            foreach (int k in magnitudes.Keys)
            {
                if (directions.ContainsKey(k)) applyForce(magnitudes[k], directions[k]);
            }
        }
    }

    public void addForce(int id, Magnitude magnitude, Vector2 force)
    {
        if (force == null) return;
        if (referenceForces == null) referenceForces = new Dictionary<int, Vector2>();
        if (magnitudes == null) magnitudes = new Dictionary<int, Magnitude>();
        if (directions == null) directions = new Dictionary<int, Vector2>();
        referenceForces.Add(id, force);
        magnitudes.Add(id, magnitude);

        Vector2 newF = new Vector2(force.x, force.y);
        newF.Normalize();
        directions.Add(id, newF);
    }

    public void removeForce(int id)
    {
        if (referenceForces == null || magnitudes == null || directions == null) return;
        referenceForces.Remove(id);
        magnitudes.Remove(id);
        directions.Remove(id);
    }

    // Since we do changes to the directional vectors
    // when we normalize them, we have soft copies.
    // Soft copies needs to be updated
    // magnitude and referece is Hard copies so they update themselves.
    private void updateForces()
    {
        if (referenceForces == null) return;
        foreach(int k in referenceForces.Keys)
        {
            directions[k] = new Vector2(referenceForces[k].x, referenceForces[k].y);
            directions[k].Normalize();
        }
    }

    private void applyForce(Magnitude magnitude, Vector2 direction)
    {
        if (direction == null) return;
        
        //Mimics wind resistant of an umbrella
        float parallelity = Vector2.Angle(gameObject.transform.up, direction); // Give Angles in degree between Umbrella up direction and direction of wind
        
        parallelity = Mathf.Abs((90 - parallelity) / 90.0f); // Clamps Angles between 0 & 1 ... since this needs to be multiplied to magnitude

        if (_cacheRigidbody.velocity.magnitude < 10.0f)
        {
            _cacheRigidbody.velocity += (Vector2)direction * parallelity * magnitude.val * Time.deltaTime;

            // Much better behaviour and controls if we apply velocity towards umbrella transform.up instead of velocity to whole umbrella in wind direction
        }
    }
}
