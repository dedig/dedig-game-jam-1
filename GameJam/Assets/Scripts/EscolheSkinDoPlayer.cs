using UnityEngine;
using System.Collections;
/// <summary>
/// Escolhe skin do player. As skins sao animadores diferentes.
/// </summary>
public class EscolheSkinDoPlayer : MonoBehaviour {

	public RuntimeAnimatorController[] skins;

	// Use this for initialization
	void Start () {
	
		GetComponent<Animator> ().runtimeAnimatorController = skins [Random.Range (0, skins.Length)];

	}

}
