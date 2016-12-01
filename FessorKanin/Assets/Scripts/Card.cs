using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Card : MonoBehaviour {

    

    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;

    private Sprite _cardBack;
    private Sprite _cardFace;
    private int _leafType;

    private GameObject _manager;

    void Start()
    {
        _state = 1;
        _manager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void setupGraphics()
    {
        _cardBack = _manager.GetComponent<GameManager>().getCardBack(_leafType);
        _cardFace = _manager.GetComponent<GameManager>().getCardFace(_leafType);
        transform.FindChild("Icon").GetComponent<Image>().sprite = _manager.GetComponent<GameManager>().getIcon(_cardValue);

        flipCard();
    }

    public void flipCard()
    {
        if(_state == 0)
        {
            _state = 1;
        }
        else if (_state == 1)
        {
            _state = 0;
        }

        if(_state == 0 && !_manager.GetComponent<GameManager>().BlockInput)
        {
            transform.FindChild("Icon").gameObject.SetActive(false);
            GetComponent<Image>().sprite = _cardBack;
        }
        else if(_state == 1 && !_manager.GetComponent<GameManager>().BlockInput)
        {
            GetComponent<Image>().sprite = _cardFace;
            transform.FindChild("Icon").gameObject.SetActive(true);
        }
    }

    public int cardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    public int state
    {
        get { return _state; }
        set { _state = value; }
    }

    public bool initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }

    public int leafType
    {
        get { return _leafType; }
        set { _leafType = value; }
    }

    public void falseCheck()
    {
        StartCoroutine(pause());
    }

    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if (_state == 0)
        {
            GetComponent<Image>().sprite = _cardBack;
            transform.FindChild("Icon").gameObject.SetActive(false);
        }
        else if (_state == 1)
        {
            GetComponent<Image>().sprite = _cardFace;
            transform.FindChild("Icon").gameObject.SetActive(true);
        }
        _manager.GetComponent<GameManager>().BlockInput = false;
    }
}
