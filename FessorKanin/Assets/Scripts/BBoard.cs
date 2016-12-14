using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BBoard : MonoBehaviour {

    private bool _activated = false;
    public AudioClip chain;

    private AudioSource source;
    private float vol = 1;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    
    

	// Update is called once per frame
	void Update () {
	    if(_activated)
        {
            if(transform.position.y >= 550)
            {
                transform.position -= new Vector3(0.0f, 12.0f, 0.0f);
                if(!source.isPlaying)
                {
                    source.PlayOneShot(chain, vol);
                }
            }
        }
        else if(!_activated)
        {
            if (transform.position.y <= 1700)
            {
                transform.position += new Vector3(0.0f, 12.0f, 0.0f);
                if (!source.isPlaying)
                {
                    source.PlayOneShot(chain, vol);
                }
            }
        }
	}

    public void activate()
    {
        _activated = true;
    }

    public void deactivate()
    {
        _activated = false;
    }

}
