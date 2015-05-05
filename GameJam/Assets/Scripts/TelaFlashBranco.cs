using UnityEngine;
using System.Collections;
/// <summary>
/// Tela flash branco. Faz a tela inteira ficar branca e, com o passar do tempo, voltar ao
/// normal (de acordo com um tempo padrao ou um fornecido)
/// Precisa estar ligado a um gameObject que estiver na posicao (0,0,0)
/// </summary>
public class TelaFlashBranco : MonoBehaviour {

	private Texture2D colorTex;
	private GUITexture flash;
	private bool emTransicao = false;
	private bool inOuOut = false;
	private float tempoParaTransicao = 0;
	public static TelaFlashBranco instancia;
	private Color transitionColor;

	// Use this for initialization
	void Awake () {
		instancia = this;
		colorTex = new Texture2D (1, 1);
		flash = gameObject.AddComponent<GUITexture>();
		flash.pixelInset = new Rect(0 , 0 , Screen.width , Screen.height );
		flash.color = Color.white;
		flash.texture = colorTex;
		flash.enabled = false;

	}


	/// <summary>
	/// Piscas the fade. Faz a transicao de ou para uma tela totalmente preenchida com a
	/// cor especificada no tempo especificado.
	/// </summary>
	/// <param name="corDaTela">Cor da tela.</param>
	/// <param name="tempoTransicao">Tempo transicao.</param>
	/// <param name="fadeInOuOut">If set to <c>true</c> fade in ou out.</param>
	public void PiscaFade(Color corDaTela, float tempoTransicao, bool fadeInOuOut){
		colorTex.SetPixel (0, 0, corDaTela);
		colorTex.Apply ();

		flash.enabled = true;

		tempoParaTransicao = tempoTransicao;

		Color newFlashColor = flash.color;

		if (fadeInOuOut) {
			newFlashColor.a = 0.0f;
			inOuOut = true;
		} else {
			newFlashColor.a = 0.5f;
			inOuOut = false;
		}

		flash.color = newFlashColor;
		emTransicao = true;
		transitionColor = flash.color;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (emTransicao) {
			if(inOuOut){
				transitionColor.a = Mathf.Lerp(transitionColor.a, 0.5f, Time.deltaTime / tempoParaTransicao);
			}else{
				transitionColor.a = Mathf.Lerp(transitionColor.a, 0.0f, Time.deltaTime / tempoParaTransicao);
			}


			flash.color = transitionColor;

		}
	}
}
