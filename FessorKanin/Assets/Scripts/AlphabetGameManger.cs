using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlphabetGameManger : MonoBehaviour {

    public Sprite[] Letters;
    public Sprite[] Objects;

    public GameObject letter;
    public GameObject[] options;

    private int numberOfMatches = 10;
    ArrayList tasks = new ArrayList();
    ArrayList selectedGames = new ArrayList();

    private bool _init = false;

    // Update is called once per frame
    void Update()
    {
        if (!_init)
        {
            initializeGames();
            createPlayingField();
        }
    }

    static void Shuffle<T>(T[] array)
    {
        
        int n = array.Length;
        for (int i = 0; i < n; i++)
        {
            // NextDouble returns a random number between 0 and 1.
            // ... It is equivalent to Math.random() in Java.
            int r = i + (int)(Random.Range(0,1) * (n - i));
            T t = array[r];
            array[r] = array[i];
            array[i] = t;
        }
    }

    void initializeGames()
    {
        
        int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 };
        Shuffle(numbers);

        
        int i = 0;
        while (i < numberOfMatches)
        {
            int j = Random.Range(0, 28);
            int k = Random.Range(0, 28);

            if (j != k && numbers[i] != j && numbers[i] != k)
            {
                int[] game = { numbers[i], j, k };
                selectedGames.Add(game);
                i++;
            }
        }

        _init = true;

        
        
    }

    void createPlayingField()
    {
        int[] selectedGame = (int[])selectedGames[numberOfMatches];
        letter.GetComponent<Letter>().setupGraphics(selectedGame[0]);

        int[] numbers = { 0, 1, 2 };
        Shuffle(numbers);

        foreach(int i in numbers)
        {
            options[i].GetComponent<Option>().setupGraphics(selectedGame[i]);
        }

    }

    public Sprite getLetter(int i)
    {
        return Letters[i];
    }

    public Sprite getObject(int i)
    {
        return Objects[i];
    }

}
