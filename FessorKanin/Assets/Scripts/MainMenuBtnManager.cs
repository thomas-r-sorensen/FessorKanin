using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuBtnManager : MonoBehaviour {

	public void goToNewLevel(string newLevel)
	{
		SceneManager.LoadScene(newLevel);
	}

    public void goToAlphabetGame()
    {
        SceneManager.LoadScene("AlphabetGame");
    }

    public void goToMemoryGame()
    {
        SceneManager.LoadScene("VendeSpilGame");
    }
}
