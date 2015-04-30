using UnityEngine;
using System.Collections;

public class GeradorDeTiles : MonoBehaviour {

	public int altura;
	private float erro;

	void Start () {
		this.transform.Translate (Vector3.up);
	}
	
	void Update () {
		if (this.transform.position.x <= ControladorColunas.morte) {
			erro = Mathf.Abs(this.transform.position.x - ControladorColunas.morte);

			if(ControladorColunas.jogando){
				respawn();
			} else {
				var posicao = new Vector3(ControladorColunas.nascimento,1,0);
				this.transform.position = posicao;
			}
		}
		this.transform.Translate ((Vector3.left * ControladorColunas.velocidade) * Time.deltaTime);

	}

	void respawn(){

		var posicao = new Vector3(ControladorColunas.nascimento,0,0);
		this.transform.position = posicao;
		posicionar ();
		this.transform.Translate (Vector3.left * erro);

	}

	void posicionar(){
		altura = calcularProximo ();
		this.transform.Translate (Vector3.up * altura);
		ControladorColunas.step(altura);
	}



	int calcularProximo(){
		if (Random.Range (0, 100) >= 90) {
			if (ControladorColunas.ultimaAltura == 0 && ControladorColunas.penultimaAltura == 0){
				if(Random.Range(0,2)==0){
					return 1;
				}
				else{
					if(ControladorColunas.AntiPenultimaAltura > 0){
						return ControladorColunas.AntiPenultimaAltura -1;
					}
					else{
						return 0;
					}
				}
			}
			else{
				return 0;
			}
		} else {
			switch (ControladorColunas.ultimaAltura) {
			case 5:
				return Random.Range (3, 5);
			case 4:
				return Random.Range (2, 5);
			case 3:
				return Random.Range (1, 5);
			case 2:
				return Random.Range (1, 4);
			case 1:
				return Random.Range (1, 3);
			case 0:
				return Random.Range (1, 3);
			}
		}
		return 0;
	}
}
