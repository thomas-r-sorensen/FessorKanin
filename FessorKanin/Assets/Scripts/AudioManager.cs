using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public AudioClip success;
    public AudioClip failure;

    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playSuccess()
    {
        if(!source.isPlaying)
        {
            source.PlayOneShot(success, 1);
        }
    }

    public void playFailure()
    {
        if (!source.isPlaying)
        {
            source.PlayOneShot(failure, 1);
        }
    }

}
