using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AlphabetGameManger : MonoBehaviour {

    public Sprite[] Letters;
    public Sprite[] Objects;

    public GameObject letter;
    public GameObject[] options;

    public int numberOfMatches = 10;
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

        if(numberOfMatches <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    static void RandomizeArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int temp = arr[i];
            int randomIndex = Random.Range(i, arr.Length);
            arr[i] = arr[randomIndex];
            arr[randomIndex] = temp;
        }
    }

    void initializeGames()
    {
        int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28 };
        RandomizeArray(numbers);


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
        int[] selectedGame = (int[])selectedGames[numberOfMatches-1];
        letter.GetComponent<Letter>().setValue(selectedGame[0]);
        letter.GetComponent<Letter>().setupGraphics(selectedGame[0]);

        int[] numbers = { 2, 1, 0 };
        RandomizeArray(numbers);

        for (int i = 0; i < numbers.Length; i++)
        {
            options[numbers[i]].GetComponent<Option>().setupGraphics(selectedGame[i]);
            options[numbers[i]].GetComponent<Option>().setValue(selectedGame[i]);
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

    public void refreshPlayingField()
    {
        numberOfMatches--;
        createPlayingField();
    }

}
