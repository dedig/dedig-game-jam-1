using UnityEngine;
using System.Collections;
/// <summary>
/// Pulo. faz o personagem pular
/// esse script vai no gameobject do personagem (o gameobject q tiver o rigidbody dele)
/// bug bug hue hue br
/// </summary>
public class ControleDePulo : MonoBehaviour {

	private CharacterController myController;
	//private Rigidbody myRigid;
	private Vector3 moveDir;
	private float gravity;
	[SerializeField]
	private float jumpForce = 6;


	// Use this for initialization
	void Start () {
		myController = GetComponent<CharacterController> ();
		//myRigid = GetComponent<Rigidbody> ();
		gravity = Physics.gravity.y;
	}
	
	// Update is called once per frame
	void Update () {
		//confere se teve os toque

		if(myController.isGrounded && (Input.touchCount > 0 || Input.GetButtonDown("Fire1"))) {

			//TODO tem q conferir q nao esta apertando o botao de pause ou coisa parecida

			moveDir.y = jumpForce;


		}


		moveDir.y += gravity * Time.deltaTime;
		
		myController.Move(moveDir * Time.deltaTime);


		
	}
	
}
