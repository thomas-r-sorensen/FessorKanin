using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour {

	public void triggerMenuBehavior(int i)
    {
        switch(i)
        {
            default:
            case(0):
                SceneManager.LoadScene("Game");
                break;
            case (1):
                Application.Quit();
                break;
        }
    }
}
