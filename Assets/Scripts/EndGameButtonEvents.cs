using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndGameButtonEvents : MonoBehaviour {

	public void restartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
