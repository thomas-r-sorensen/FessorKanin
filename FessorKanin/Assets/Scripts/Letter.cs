using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Letter : MonoBehaviour {

    [SerializeField]
    private Sprite _thing;
    

    private GameObject _manager;

    // Use this for initialization
    void Start () {
        _manager = GameObject.FindGameObjectWithTag("Manager");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setupGraphics(int i)
    {
        _thing = _manager.GetComponent<AlphabetGameManger>().getLetter(i);
        GetComponent<Image>().sprite = _thing;
    }
}
