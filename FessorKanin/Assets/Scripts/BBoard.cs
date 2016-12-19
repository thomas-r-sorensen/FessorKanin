using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BBoard : MonoBehaviour {

    private bool _activated = false;
    public AudioClip chain;

    private AudioSource source;
    private float vol = 1;
    private float initPos;

    void Start()
    {
        source = GetComponent<AudioSource>();
        initPos = transform.position.y;
    }
    
    

	// Update is called once per frame
	void Update () {
	    if(_activated)
        {
            if(transform.position.y >= initPos - 1050)
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
            if (transform.position.y < initPos)
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
