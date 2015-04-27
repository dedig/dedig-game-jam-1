using UnityEngine;
using System.Collections;

public class UIMenuDePausa : MonoBehaviour {

	public GameObject pauseMenu;

	public void Pause(){
		Time.timeScale = 0;
		pauseMenu.SetActive (true);
	}

	public void Unpause(){
		Time.timeScale = 1;
		pauseMenu.SetActive (false);
	}

	public void GoToMainMenu(){
		Time.timeScale = 1;
		Application.LoadLevel (0);
	}
}
