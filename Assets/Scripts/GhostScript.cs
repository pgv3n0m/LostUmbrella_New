using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour,IUpdateable
{
    public GameObject _Ragdoll;
    private Rigidbody2D[] bodyparts;

    public Rigidbody2D _Umbrella;
    private float umbrella_startX;

    private Vector3 speed = new Vector3(-10f,0f, 0f);
    private Color ghostMode = new Color(255f, 255f, 255f, 0.5f);

    public GameLogic gl;

    // Start is called before the first frame update
    void Start()
    {
        bodyparts = _Ragdoll.GetComponentsInChildren<Rigidbody2D>();
        umbrella_startX = _Umbrella.transform.position.x;
        gl.RegisterUpdateObject(this);
    }

    private bool kinematic = false;
    // Update is called once per frame
    public virtual void OnUpdate(float dt)
    {
            if (Input.GetKey(KeyCode.Q))
        {
            if (!kinematic)
            {
                foreach(Rigidbody2D rb in bodyparts)
                {
                    rb.isKinematic = true;
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = 0f;

                    rb.GetComponent<SpriteRenderer>().color = ghostMode;
                }
                _Umbrella.isKinematic = true;
                _Umbrella.velocity = Vector3.zero;
                _Umbrella.angularVelocity = 0f;

                _Umbrella.GetComponent<SpriteRenderer>().color = ghostMode;

                kinematic = true;
            }
            moveLeft(dt);
        }
        else
        {
            kinematic = false;
            foreach (Rigidbody2D rb in bodyparts)
            {
                rb.isKinematic = false;
                rb.GetComponent<SpriteRenderer>().color = Color.white;
            }
            _Umbrella.isKinematic = false;
            _Umbrella.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void moveLeft(float dt)
    {
        if (umbrella_startX < _Umbrella.transform.position.x)
        {
            _Ragdoll.transform.position += speed * dt;
            _Umbrella.transform.position += speed * dt;
        }
    }
}
