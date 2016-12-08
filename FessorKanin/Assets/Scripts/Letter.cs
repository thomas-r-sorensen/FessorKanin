using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Letter : MonoBehaviour {

    [SerializeField]
    private Sprite _thing;
    

    public int _value;

    public void setValue(int value)
    {
        _value = value;
    }

    public int getValue()
    {
        return _value;
    }

    private GameObject _manager;

    // Use this for initialization
    void Start ()
    {
        _manager = GameObject.FindGameObjectWithTag("Manager");
    }

    void Update()
    {
    }

    public void setupGraphics(int i)
    {
        _thing = _manager.GetComponent<AlphabetGameManger>().getLetter(i);
        GetComponent<Image>().sprite = _thing;
    }

    
}
