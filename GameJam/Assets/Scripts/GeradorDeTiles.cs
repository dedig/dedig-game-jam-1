using UnityEngine;
using System.Collections;

public class GeradorDeTiles : MonoBehaviour {

	public int altura;

	void Start () {
		posicionar ();
	}
	
	void FixedUpdate () {
		this.transform.Translate ((Vector3.left * ControladorColunas.velocidade)* Time.deltaTime);
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
		altura = calcularProximo ();//Random.Range (0, 5);

		//Trabalhar com o algoritimo para gerar as colunas de maneira harmoica
		
		//

		this.transform.Translate (Vector3.up * altura);
		ControladorColunas.step(altura);

	}

	int calcularProximo(){
		if (Random.Range (0, 100) >= 90) {
			if (ControladorColunas.ultimaAltura == 0 && ControladorColunas.penultimaAltura == 0){
				if(Random.Range(0,2)==0){
					return ControladorColunas.AntiPenultimaAltura;
				}
				else{
					if(ControladorColunas.AntiPenultimaAltura > 1){
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
