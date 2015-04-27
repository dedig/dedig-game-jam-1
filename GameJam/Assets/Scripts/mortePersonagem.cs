using UnityEngine;
using System.Collections;

public class mortePersonagem : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (PlayerPrefs.HasKey ("best")) {
			int oldbest = PlayerPrefs.GetInt ("best");
			if (oldbest < ControladorColunas.pontuacao) {
				PlayerPrefs.SetInt ("best", (int)ControladorColunas.pontuacao);
			}
		}
		else{
				PlayerPrefs.SetInt("best",0);
			}
		GameObject go = GameObject.FindGameObjectWithTag ("Finish");
		go.transform.GetComponent<UIMenuDeDerrota>().Derrota();
	}
}
