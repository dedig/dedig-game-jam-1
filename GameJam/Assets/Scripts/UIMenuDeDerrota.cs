using UnityEngine;
using System.Collections;

public class UIMenuDeDerrota : MonoBehaviour {

	public GameObject pauseMenu;

	void Start(){
		Derrota();
	}

	public static void Derrota(){
		int bestScore = PlayerPrefs.GetInt ("best");
		print (bestScore);
	}
}
