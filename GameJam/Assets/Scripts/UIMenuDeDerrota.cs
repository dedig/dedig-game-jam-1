using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMenuDeDerrota : MonoBehaviour {

	public GameObject pauseMenu, derrotaMenu;
	public Text pontuacaoAtual, melhorPontuacao;

	void Start(){
		// Validação de menu de pausa
		if (pauseMenu == null || derrotaMenu == null) {
			Debug.LogError("Não há ligação com os menus de pausa ou derrota");
			Debug.Break();
		}
	}

	public void Derrota(){
		Time.timeScale = 0;
		pauseMenu.SetActive (false);
		derrotaMenu.SetActive (true);
		pontuacaoAtual.text = ControladorColunas.pontuacao.ToString();
		melhorPontuacao.text = PlayerPrefs.GetInt ("best").ToString ();
	}

	public void ReiniciaJogo(){
		//TODO reiniciar jogo sem voltar pro menu
	}

	public void VoltaProMenu(){
		Time.timeScale = 1;
		Application.LoadLevel (0);
	}
}
