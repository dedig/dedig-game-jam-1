using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class ControladorColunas : MonoBehaviour {

	private float pontuacaoLocal;
	private Text t,b;

	public int velocidadeDasColunas, localDaMorte, LocalDoNascimento;
	public float pontuaocaoRatio;
	public GameObject texto,best;
	public List<GameObject> Colunas;
	public int incrementoDaVelocidade;

	public static int velocidade;
	public static int morte;
	public static int nascimento;
	public static float pontuacao = 0;
	public static float multiplicadorDaPontucao;
	



	public static int ultimaAltura,penultimaAltura,AntiPenultimaAltura;

	void Start () {
		//gerar tiles
		int TileRandom = Random.Range (0, Colunas.Count);
		for (byte i = 0; i <=18; i++) {
			Instantiate(Colunas[TileRandom],new Vector3(i,0,0),Quaternion.identity);
		}

		//
		ultimaAltura = 1;
		penultimaAltura = 1;
		AntiPenultimaAltura = 1;


		t = texto.GetComponent<Text> ();
		b = best.GetComponent<Text> ();
		velocidade = velocidadeDasColunas;
		morte = localDaMorte;
		nascimento = LocalDoNascimento;
		//pegar best anterior
		if (PlayerPrefs.HasKey ("best")) {
			b.text = "Recorde: "+PlayerPrefs.GetInt ("best").ToString();
		} 
		else {
			b.text = "Recorde: 0";
		}
	}
	
	void Update () {
		multiplicadorDaPontucao = pontuaocaoRatio;
		velocidade = velocidadeDasColunas;
		morte = localDaMorte;
		nascimento = LocalDoNascimento;
		pontuacaoLocal += Time.deltaTime;
		pontuacao = Mathf.Floor(pontuacaoLocal*pontuaocaoRatio);
		t.text = pontuacao.ToString();
		if (pontuacao % 50 == 0) {
			velocidadeDasColunas += incrementoDaVelocidade;
			pontuacaoLocal++;
		}

	}

	public static void step(int p){
		AntiPenultimaAltura = penultimaAltura;
		penultimaAltura = ultimaAltura;
		ultimaAltura = p;
	}
}
