using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {

	public void goToNewLevel(string newLevel)
	{
		SceneManager.LoadScene(newLevel);
	}
}
