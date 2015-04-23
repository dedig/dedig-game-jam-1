using UnityEngine;
using System.Collections;

public class ControladorColunas : MonoBehaviour {

	public int velocidadeDasColunas, localDaMorte, LocalDoNascimento;

	public static int velocidade;
	public static int morte;
	public static int nascimento;

	public static int ultimaAltura,penultimaAltura,AntiPenultimaAltura;

	void Start () {
	
	}
	
	void Update () {
		velocidade = velocidadeDasColunas;
		morte = localDaMorte;
		nascimento = LocalDoNascimento;
	}

	public static void step(int p){
		AntiPenultimaAltura = penultimaAltura;
		penultimaAltura = ultimaAltura;
		ultimaAltura = p;
	}
}
