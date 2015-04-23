using UnityEngine;
using System.Collections;
/// <summary>
/// Move fundo infinitamente para a esquerda.
/// </summary>
public class MoveFundoInfinitamente : MonoBehaviour {

	public float velocidade;
	float tamanhoDoAsset, posicaoInicial;

	void Start () {
		//Seta a posição inicial do Asset
		posicaoInicial = transform.localPosition.x;
		//Pega o tamanho do asset
		SpriteRenderer sr = transform.GetChild (0).GetComponent<SpriteRenderer> ();
		if (sr != null) {
			tamanhoDoAsset = sr.sprite.textureRect.width / sr.sprite.pixelsPerUnit;
		} else {
			Debug.LogError ("Primeiro filho não tem componente SpriteRenderer!");
		}

		//Clona e posiciona o asset
		GameObject clone = GameObject.Instantiate (transform.GetChild(0).gameObject);
		clone.transform.SetParent (this.transform);
		clone.transform.localPosition = new Vector3 (tamanhoDoAsset, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3((-velocidade * Time.deltaTime), 0, 0));
		if(transform.localPosition.x <= posicaoInicial - tamanhoDoAsset){
			transform.localPosition = new Vector3(posicaoInicial,0,0);
		}
	}
}
