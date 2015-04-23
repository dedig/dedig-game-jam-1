using UnityEngine;
using System.Collections;
/// <summary>
/// Pulo. faz o personagem pular
/// esse script vai no gameobject do personagem (o gameobject q tiver o rigidbody dele)
/// </summary>
public class Pulo : MonoBehaviour {

	private Rigidbody2D myRigid;

	[SerializeField]
	private float jumpForce = 6;

	private bool grounded = false;

	// Use this for initialization
	void Start () {
		myRigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//confere se teve os toque
		if(grounded && (Input.touchCount > 0 || Input.GetButtonDown("Fire1"))) {

			//TODO tem q conferir q nao esta apertando o botao de pause ou coisa parecida
		
			myRigid.velocity = (Vector2.up * jumpForce);


		}

		if (myRigid.velocity.y == 0) {
			if(!grounded){
				//Debug.Log ("ground");
				grounded = true;
			}

		} else
			grounded = false;
	}
}
