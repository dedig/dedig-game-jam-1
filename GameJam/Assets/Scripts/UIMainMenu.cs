using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour {

	public GameObject pauseMenu, scoreCanvas, highScores, credits, mainMenu;
	public GameObject somHabilitado, somDesabilitado;
	public float tempoDeTrocaDeTela = 15;
	static bool audioHabilitado = true;
	int telaAtual = 0;
	float deltaTime;

	void Start(){
		// Validação de menu de pausa
		if (pauseMenu == null) {
			Debug.LogError("Está faltando um gameobject");
			Debug.Break();
		}
		ControladorColunas.multiplicadorDaPontucao = 0;
		if(PlayerPrefs.GetInt("som") == 0){
			DesativarSom();
		} else {
			AtivarSom();
		}
	}

	public void IniciaJogo(){
		scoreCanvas.SetActive (true);
		pauseMenu.SetActive (true);
		gameObject.SetActive (false);
		ControladorColunas.jogando = true;
		ControladorColunas.multiplicadorDaPontucao = 5;
	}

	public void AlternarSom(){
		if (audioHabilitado) {
			DesativarSom();
		} else {
			AtivarSom();
		}
	}

	void DesativarSom(){
		AudioListener.volume = 0;
		audioHabilitado = false;
		somHabilitado.SetActive(false);
		somDesabilitado.SetActive(true);
		PlayerPrefs.SetInt("som", 0);
	}

	void AtivarSom(){
		AudioListener.volume = 1;
		audioHabilitado = true;
		somHabilitado.SetActive(true);
		somDesabilitado.SetActive(false);
		PlayerPrefs.SetInt("som", 1);
	}

	void TrocarTela(){
		switch(telaAtual){
		case 0:
			mainMenu.SetActive(false);
			credits.SetActive(true);
			break;
		case 1:
			credits.SetActive(false);
			highScores.SetActive(true);
			highScores.GetComponent<HighScoreController>().Animar();
			break;
		case 2:
			highScores.SetActive(false);
			mainMenu.SetActive(true);
			telaAtual = -1;
			break;
		default:
			telaAtual = 0;
			break;
		}
		telaAtual++;
	}

	void Update(){
		/* CHAMAR UMA COROUTINE PRA ISSO AQUI !!111 */
		deltaTime += Time.deltaTime;
		if(deltaTime > tempoDeTrocaDeTela){
			deltaTime = 0;
			TrocarTela();
		}
	}
}
