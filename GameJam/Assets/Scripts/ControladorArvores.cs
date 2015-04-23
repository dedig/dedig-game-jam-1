using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControladorArvores : MonoBehaviour {

	List<GameObject> arvores = new List<GameObject>();
	public static float velocidade;

	void Start () {
		//Adiciona filhas em uma lista
		foreach (Transform child in transform) {
			arvores.Add(child.gameObject);
			print (child.name);
		}

		//Valida velocidade
		if (velocidade < 0) {
			velocidade = -velocidade;
			if(velocidade<0){
				Debug.LogError("?!?");
			}
		}
	}

	void Update(){
		transform.Translate (new Vector3((-velocidade * Time.deltaTime), 0, 0));
	}
}
