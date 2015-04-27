using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControladorArvores : MonoBehaviour {
	List<GameObject> arvores = new List<GameObject>();

	public float velocidade;
	float velocidadeVerdadeira;
	public Vector2 randomRange = new Vector2();
	public int fimCamera, inicioCamera;
	public static int fimCameraVerdadeiro, inicioCameraVerdadeiro;
	
	void Start () {
		//
		fimCameraVerdadeiro = fimCamera;
		inicioCameraVerdadeiro = inicioCamera;

		//Adiciona filhas em uma lista
		foreach (Transform child in transform) {
			arvores.Add(child.gameObject);
		}
		
		//Valida velocidade
		if (velocidade < 0) {
			velocidade = -velocidade;
			if(velocidade<0){
				Debug.LogError("?!?");
			}
		}

		// Multiplica velocidade do fundo pela velocidade dos tiles
		velocidadeVerdadeira = ControladorColunas.velocidade * velocidade;

		if (velocidadeVerdadeira == 0) {
			velocidadeVerdadeira = 2 * velocidade;
		}
		
		//Valida randomRange
		if (randomRange.x > randomRange.y) {
			Debug.LogError("Range inválido!");
		}
	}
	
	void Update(){
		transform.Translate (new Vector3((-velocidadeVerdadeira * Time.deltaTime), 0, 0));
		foreach(GameObject arvore in arvores){
			if(arvore.transform.position.x <= -fimCamera){
				arvore.transform.Translate(new Vector3(inicioCamera + Random.Range (randomRange.x, randomRange.y),0,0));
			}
		}
	}
}
