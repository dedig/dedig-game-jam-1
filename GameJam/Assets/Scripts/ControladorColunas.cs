using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ControladorColunas : MonoBehaviour {

	private float pontuacaoLocal;
	private Text t,b;

	public int velocidadeDasColunas, localDaMorte, LocalDoNascimento;
	public float pontuaocaoRatio;
	public GameObject texto,best;


	public static int velocidade;
	public static int morte;
	public static int nascimento;
	public static float pontuacao;
	public static float multiplicadorDaPontucao;
	



	public static int ultimaAltura,penultimaAltura,AntiPenultimaAltura;

	void Start () {
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


	}

	public static void step(int p){
		AntiPenultimaAltura = penultimaAltura;
		penultimaAltura = ultimaAltura;
		ultimaAltura = p;
	}
}
