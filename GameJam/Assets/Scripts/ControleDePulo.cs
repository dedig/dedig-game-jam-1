using UnityEngine;
using System.Collections;
/// <summary>
/// Pulo. faz o personagem pular
/// esse script vai no gameobject do personagem (o gameobject q tiver o rigidbody dele)
/// bug bug hue hue br
/// </summary>
public class ControleDePulo : MonoBehaviour {

	private CharacterController myRigid;
	private float lastJumpHeight;
	[SerializeField]
	private float jumpForce = 6;

	private bool grounded = true;

	// Use this for initialization
	void Start () {
		myRigid = GetComponent<CharacterController> ();
		myRigid.attachedRigidbody.useGravity = true;
	}
	
	// Update is called once per frame
	void Update () {
		//confere se teve os toque
		myRigid.SimpleMove (Vector3.zero);
		if(myRigid.isGrounded && (Input.touchCount > 0 || Input.GetButtonDown("Fire1"))) {

			//TODO tem q conferir q nao esta apertando o botao de pause ou coisa parecida
			//myRigid.Move(Vector3.up * jumpForce);
			//myRigid.velocity = (Vector2.up * jumpForce);
			grounded = false;
			StartCoroutine(getGrounded());


		}

		/*if (myRigid.velocity.y == 0 || Physics.Raycast(transform.position,Vector2.up * -1, 0.8f)) {
			if(!grounded){
				//Debug.Log ("ground");
				grounded = true;


			}

		} else
			grounded = false;

		*/
	}

	IEnumerator getGrounded(){
		Debug.Log (Mathf.Abs((jumpForce / (Physics.gravity.y))).ToString ());
		yield return new WaitForSeconds (Mathf.Abs((jumpForce / (Physics.gravity.y))));
		grounded = true;
	}
}
