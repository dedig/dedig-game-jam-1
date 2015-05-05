using UnityEngine;
using System.Collections;
/// <summary>
/// Sprite flash branco. faz a sprite piscar na cor branca por um instante.
/// Para se conseguir um material branco, basta criar um material que usa 
/// o Shader Text Shader.
/// </summary>
public class SpriteFlashBranco : MonoBehaviour {

	SpriteRenderer myRenderer;
	private Material defaultMaterial;
	public Material materialBranco;
	private float tempoEntrePiscadas;
	private bool piscando = false;

	// Use this for initialization
	void Start () {
		myRenderer = GetComponent<SpriteRenderer>();
		defaultMaterial = myRenderer.material;
	}

	/// <summary>
	/// Piscar the specified tempo. Faz o sprite variar entre branco e original de acordo
	/// com o intervalo entre piscadas especificado, durante o tempo especificado
	/// </summary>
	/// <param name="tempo">Tempo.</param>
	public void Piscar (float tempoDuracaoDaSerie, float intervaloPiscadas) {
		tempoEntrePiscadas = intervaloPiscadas;
		if (!piscando) {
			StartCoroutine ("VoltaAoNormal", tempoDuracaoDaSerie);
		}
	}

	/// <summary>
	/// Piscar the specified tempo. Deixa o sprite branco por 0.05 segundo
	/// </summary>
	/// <param name="tempo">Tempo.</param>
	public void Piscar () {
		myRenderer.material = materialBranco;
		tempoEntrePiscadas = 0.05f;
		StartCoroutine ("VoltaAoNormal", 0.1f);
	}

	IEnumerator VoltaAoNormal(float tempoParaPiscar){
		piscando = true;
		float tempoPiscando = 0;
		while (tempoPiscando < tempoParaPiscar) {
			myRenderer.material = materialBranco;
			yield return new WaitForSeconds (tempoEntrePiscadas / 2);
			myRenderer.material = defaultMaterial;
			yield return new WaitForSeconds (tempoEntrePiscadas / 2);
			tempoPiscando += tempoEntrePiscadas;
		}

		piscando = false;

	}
}
