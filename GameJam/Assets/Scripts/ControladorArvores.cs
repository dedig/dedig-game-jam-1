using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControladorArvores : MonoBehaviour {

	List<GameObject> arvores = new List<GameObject>();
	public float velocidade;
	public Vector2 randomRange = new Vector2();

	void Start () {
		//Adiciona filhas em uma lista
		foreach (Transform child in transform) {
			arvores.Add(child.gameObject);
		}

		//Valida velocidade
		velocidade *= ControladorColunas.velocidade;

		if (velocidade < 0) {
			velocidade = -velocidade;
			if(velocidade<0){
				Debug.LogError("?!?");
			}
		}

		//Valida randomRange
		if (randomRange.x > randomRange.y) {
			Debug.LogError("");
		}
	}

	void Update(){
		transform.Translate (new Vector3((-velocidade * Time.deltaTime), 0, 0));
		foreach(GameObject arvore in arvores){
			if(arvore.transform.position.x <= -12){
				arvore.transform.Translate(new Vector3(24 + Random.Range (randomRange.x, randomRange.y),0,0));
			}
		}
	}
}
