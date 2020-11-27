using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour
{
    public AudioSource soundSFX;
    // Start is called before the first frame update
    void Start()
    {
        soundSFX.Play();
        this.GetComponent<Animator>().Play("lightning");
        Invoke("disable", 1.5f);
        Invoke("DisableAud",3.0f);
    }

    private void disable()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

    void DisableAud()
    {
        soundSFX.enabled = false;
    }
}
