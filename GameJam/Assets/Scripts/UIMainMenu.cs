using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour {

	public GameObject pauseMenu, scoreCanvas;
	public GameObject somHabilitado, somDesabilitado;
	public GameObject textoJogar;
	RectTransform textoRect;
	static bool audioHabilitado = true;
	float posicaoTexto = 1.0f;

	void Start(){
		// Validação de menu de pausa
		if (pauseMenu == null || textoJogar == null) {
			Debug.LogError("Está faltando um gameobject");
			Debug.Break();
		}
		textoRect = textoJogar.transform.GetComponent<RectTransform> ();
	}

	public void IniciaJogo(){
		scoreCanvas.SetActive (true);
		pauseMenu.SetActive (true);
		gameObject.SetActive (false);
	}

	public void AlternarSom(){
		if (audioHabilitado) {
			AudioListener.volume = 0;
			audioHabilitado = false;
			somHabilitado.SetActive(false);
			somDesabilitado.SetActive(true);
		} else {
			AudioListener.volume = 1;
			audioHabilitado = true;
			somHabilitado.SetActive(true);
			somDesabilitado.SetActive(false);
		}
	}

	void FixedUpdate(){
		posicaoTexto = Mathf.Sin (Time.time);
		textoRect.anchoredPosition = new Vector2 (textoRect.anchoredPosition.x, posicaoTexto);
	}

}
