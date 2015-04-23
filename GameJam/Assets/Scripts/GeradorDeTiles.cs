using UnityEngine;
using System.Collections;

public class GeradorDeTiles : MonoBehaviour {

	public int altura;

	void Start () {
		posicionar ();
	}
	
	void Update () {
		this.transform.Translate ((Vector3.left * Time.deltaTime)* ControladorColunas.velocidade );
		if (this.transform.position.x <= ControladorColunas.morte) {
			respawn();
		}
	}

	void respawn(){
		var posicao = new Vector3(ControladorColunas.nascimento,0,0);
		this.transform.position = posicao;
		posicionar ();
	}

	void posicionar(){
		altura = Random.Range (0, 5);

		//Trabalhar com o algoritimo para gerar as colunas de maneira harmoica

		this.transform.Translate (Vector3.up * altura);
		ControladorColunas.step(altura);

	}
}
