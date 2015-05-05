using UnityEngine;
using System.Collections;
/// <summary>
/// Camera screen shake. deve ser ligado ao objeto da camera
/// possui uma funcao chamada shakeScreen(float intensidade)
/// </summary>
public class CameraScreenShake : MonoBehaviour {


	private float tempoShake;
	private float intensShake;
	private Vector3 posCamOriginal;
	private Transform camTrans;
	// Use this for initialization
	void Start () {
		camTrans = transform;
	}
	


	/// <summary>
	/// Shakes the screen. Chacoalha a tela com a intensidade e tempo fornecidos
	/// </summary>
	/// <param name="intensidade">Intensidade, força com que chacoalha a tela.</param>
	/// <param name="tempo">Duraçao de tempo do efeito de chacoalhar a tela.</param>
	public void ShakeScreen(float intensidade, float tempo){
		tempoShake = tempo;
		intensShake = intensidade;
		posCamOriginal = camTrans.position;
		StartCoroutine ("chacoalhaPorTempo");

	}

	/// <summary>
	/// Shakes the screen. Chacoalha a tela com intensidade 0.15 e tempo 0.35
	/// </summary>
	public void ShakeScreen(){
		tempoShake = 0.35f;
		intensShake = 0.15f;
		posCamOriginal = camTrans.position;
		StartCoroutine ("chacoalhaPorTempo");
		
	}

	IEnumerator chacoalhaPorTempo(){
		float tempoPassado = 0;

		while (tempoPassado < tempoShake) {
			Vector3 shakePos = posCamOriginal + new Vector3(
											   Random.Range(-intensShake, intensShake),
			                                   Random.Range(-intensShake, intensShake),
			                                   0);
			camTrans.position = shakePos;
			yield return new WaitForSeconds(0.05f);
			tempoPassado += 0.05f;

		}

		camTrans.position = posCamOriginal;


	}



}
