using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Option : MonoBehaviour {

    [SerializeField]
    private Sprite _thing;
    

    private int _value;

    private GameObject _manager;
    private GameObject _letter;
    private int lettervalue;

    // Use this for initialization
    void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("Manager");
        _letter = GameObject.FindGameObjectWithTag("Letter");
        
        
    }

    // Update is called once per frame
    void Update ()
    {
        lettervalue = _letter.GetComponent<Letter>().getValue();
    }

    public void setupGraphics(int i)
    {
        _thing = _manager.GetComponent<AlphabetGameManger>().getObject(i);
        GetComponent<Image>().sprite = _thing;
    }

    public void checkForAnswer()
    {
        if(_value == lettervalue)
        {
            _manager.GetComponent<AlphabetGameManger>().refreshPlayingField();
        }
    }

    public void setValue(int value)
    {
        _value = value;
    }
}
