using UnityEngine;
using System.Collections;

public class GeradorDeTiles : MonoBehaviour {

	public int altura;
	public int velocidade;
	public int morrer;
	public int nascer;

	void Start () {
		posicionar ();
	}
	
	void Update () {
		this.transform.Translate ((Vector3.left * Time.deltaTime)*velocidade);
		if (this.transform.position.x <= morrer) {
			respawn();
		}
	}

	void respawn(){
		var posicao = new Vector3(nascer,0,0);
		this.transform.position = posicao;
		posicionar ();
	}

	void posicionar(){
		altura = Random.Range (0, 5);
		this.transform.Translate (Vector3.up * altura);
	}
}
