using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskScript : MonoBehaviour
{
    public Transform player;
    private SpriteRenderer spriteRenderer;
    private Color defaultColor = new Color(111,111,111);
    private float playerProgression = 0;
    private float offSet = 235f;
    
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerProgression = (player.position.x + offSet) / 600f;
        spriteRenderer.color = new Color(
            defaultColor.r*playerProgression, 
            defaultColor.g*playerProgression, 
            defaultColor.b*playerProgression);
    }
}
