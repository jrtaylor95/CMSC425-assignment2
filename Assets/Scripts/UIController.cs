using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
	public void LoadByScene(int index) {
		SceneManager.LoadScene (index);
	}

	public void Quit() {
		Application.Quit();
	}
}
