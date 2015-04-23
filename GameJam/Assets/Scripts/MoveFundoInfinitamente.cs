using UnityEngine;
using System.Collections;
/// <summary>
/// Move fundo infinitamente para a esquerda.
/// </summary>
public class MoveFundoInfinitamente : MonoBehaviour {

	public float velocidade;
	static float tamanhoDoAsset, posicaoInicial;

	void Start () {
		//
		SpriteRenderer sr = transform.GetChild (0).GetComponent<SpriteRenderer> ();
		if (sr != null) {
			tamanhoDoAsset = sr.sprite.textureRect.width / sr.sprite.pixelsPerUnit;
		} else {
			Debug.LogError ("Primeiro filho não tem componente SpriteRenderer!");
		}

		//Seta a posição inicial do Asset
		posicaoInicial = transform.localPosition.x;

		// Valida o valor de velocidade
		velocidade *= ControladorColunas.velocidade;

		if (velocidade < 0) {
			velocidade = -velocidade;
			if(velocidade<0){
				Debug.LogError("?!?");
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3((-velocidade * Time.deltaTime), 0, 0));
		if(transform.localPosition.x <= posicaoInicial - tamanhoDoAsset){
			transform.localPosition = new Vector3(posicaoInicial,0,0);
		}
	}
}
