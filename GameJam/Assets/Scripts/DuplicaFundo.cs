using UnityEngine;
using System.Collections;

public class DuplicaFundo : MonoBehaviour {

	float tamanhoDoAsset;

	// Use this for initialization
	void Start () {
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
	
	}
}
