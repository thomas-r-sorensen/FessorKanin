﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Sprite[] cardFace;
    public Sprite[] cardBack;
    public Sprite[] icons;
    public GameObject[] cards;
    public Text matchText;

    private bool _init = false;
    private int _matches = 8;

    private bool _BlockInput = false;

    public bool BlockInput
    {
        get { return _BlockInput; }
        set { _BlockInput = value; }
    }

    // Update is called once per frame
    void Update ()
    {
        if (!_init)
        {
            initializeCards();
            matchText.text = "Number of Matches: " + _matches;
        }
            
        if (Input.GetMouseButtonUp(0))
            checkCards();
	}

    void initializeCards()
    {
        for(int id = 0; id < 2; id++)
        {
            for (int i = 1; i < 9; i++)
            {
                bool test = false;
                int choice = 0;

                while(!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>().initialized);
                }
                cards[choice].GetComponent<Card>().leafType = Random.Range(0, 3);
                cards[choice].GetComponent<Card>().cardValue = i;
                cards[choice].GetComponent<Card>().initialized = true;
            }
        }

        foreach(GameObject c in cards)
        {
            c.GetComponent<Card>().setupGraphics();
        }

        if(!_init)
        {
            _init = true;
        }

    }

    public Sprite getCardBack(int i)
    {
        return cardBack[i];
    }

    public Sprite getCardFace(int i)
    {
        return cardFace[i];
    }

    public Sprite getIcon(int i)
    {
        return icons[i];
    }

    void checkCards()
    {
        List<int> c = new List<int>();

        for (int i = 0; i < cards.Length; i++)
        {
            if(cards[i].GetComponent<Card>().state == 1)
            {
                c.Add(i);
            }

            if (c.Count== 2)
            {
                cardComparison(c);
            }
        }
    }

    void cardComparison(List<int> c)
    {
        BlockInput = true;
        bool StopCheck = false;
        int x = 0;

        if (!StopCheck && cards[c[0]].GetComponent<Card>().cardValue == cards[c[1]].GetComponent<Card>().cardValue)
        {
            StopCheck = true;

            x = 2;
            _matches--;
            matchText.text = "Number of Matches: " + _matches;
            if(_matches == 0)
            {
                SceneManager.LoadScene("Menu");
            }
        }

        for (int i = 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().state = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }
    }
}
