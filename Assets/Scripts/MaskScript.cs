using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskScript : MonoBehaviour,IUpdateable
{
    public Transform player;
    private SpriteRenderer spriteRenderer;
    private Color defaultColor = new Color(111,111,111);
    private float playerProgression = 0;
    public float offSet = 235f;

    public GameLogic gl;
    
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        gl.RegisterUpdateObject(this);
    }

    // Update is called once per frame
    public virtual void OnUpdate(float dt)
    {
        
            playerProgression = (player.position.x + offSet) / 600f;
        Debug.Log(playerProgression);
        spriteRenderer.color = new Color(
            defaultColor.r*playerProgression, 
            defaultColor.g*playerProgression, 
            defaultColor.b*playerProgression);
    }
}
