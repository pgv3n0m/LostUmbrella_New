using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollowScript : MonoBehaviour
{
    public Transform player;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.position.x, this.transform.position.y, this.transform.position.z);
    }
}
