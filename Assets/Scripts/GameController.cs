using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	private bool isPaused;

	// Use this for initialization
	void Start () {
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("p")) {
			if (!isPaused)
				pause ();
			else
				unpause ();
		} else if (Input.GetKeyDown ("q")) {
			Application.Quit ();
		} else if (Input.GetKeyDown ("r")) {
			restart ();
		}
	}

	private void pause() {
		Time.timeScale = 0;
		isPaused = true;
	}

	private void unpause() {
		Time.timeScale = 1;
		isPaused = false;
	}

	private void restart() {
		SceneManager.LoadScene (1);
	}
}
