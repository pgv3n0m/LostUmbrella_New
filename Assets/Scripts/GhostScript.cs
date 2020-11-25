using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public GameObject _Ragdoll;
    public float ragdoll_startX;
    private Rigidbody2D[] bodyparts;

    public Rigidbody2D _Umbrella;
    private float umbrella_startX;

    private Vector3 speed = new Vector3(-10f,0f, 0f);
    private Color ghostMode = new Color(255f, 255f, 255f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        bodyparts = _Ragdoll.GetComponentsInChildren<Rigidbody2D>();
        ragdoll_startX = _Ragdoll.transform.position.x;
        umbrella_startX = _Umbrella.transform.position.x;
    }

    private bool kinematic = false;
    // Update is called once per frame
    void Update()
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
            moveLeft();
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

    private void moveLeft()
    {
        _Ragdoll.transform.position += speed * Time.deltaTime;
        _Umbrella.transform.position += speed * Time.deltaTime;

        float ragDif = ragdoll_startX - _Ragdoll.transform.position.x;
        if (ragDif > 0)
        {
            _Ragdoll.transform.position += new Vector3(ragDif, 0f, 0f);
            _Umbrella.transform.position += new Vector3(ragDif, 0f, 0f);
        }

        float umbDif = umbrella_startX - _Umbrella.transform.position.x;
        if (umbDif > 0)
        {
            _Ragdoll.transform.position += new Vector3(umbDif, 0f, 0f);
            _Umbrella.transform.position += new Vector3(umbDif, 0f, 0f);
        }
    }
}
