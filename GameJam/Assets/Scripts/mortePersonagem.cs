using UnityEngine;
using System.Collections;

public class mortePersonagem : MonoBehaviour {

	public GameObject UIDerrota;

	void OnTriggerEnter(Collider other) {
		if (PlayerPrefs.HasKey ("best")) {
			int oldbest = PlayerPrefs.GetInt ("best");
			if (oldbest < ControladorColunas.pontuacao) {
				PlayerPrefs.SetInt ("best", (int)ControladorColunas.pontuacao);
			}
		} else {
			PlayerPrefs.SetInt ("best", 0);
		}

		if (UIDerrota != null) {
			print ("bunda");
			UIDerrota.transform.GetComponent<UIMenuDeDerrota> ().Derrota ();
		} else {
			Debug.LogError("Não há UIDerrota aqui");
		}
	}
}