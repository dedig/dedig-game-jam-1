using UnityEngine;
using System.Collections;

public class HighScoreController : MonoBehaviour {

	int[] highScorePoints = new int[15];
	string[] highScoreNames = new string[15];

	public void Animar(){
		Animator anim = gameObject.GetComponent<Animator>();
		anim.Play("Move High Score");
		anim.Play("HighScores");
	}

	void Start(){

	}

	void GetMySavedScores(){
		for(int i = 0; i < 15; i++){
			highScorePoints[i] = PlayerPrefs.GetInt(i.ToString());
			highScoreNames[i] = PlayerPrefs.GetString (i.ToString());
		}
	}

	void SortScores(){

	}

	public static void SetHighScore(string name, int points){

	}
}