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
	private float jumpForce = 7;

	public bool isGrounded;
	public bool pulando = false;


	// Use this for initialization
	void Start () {
		myController = GetComponent<CharacterController> ();
		//myRigid = GetComponent<Rigidbody> ();
		gravity = Physics.gravity.y;
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = myController.isGrounded;

		if (isGrounded && pulando) {
			pulando = false;
			Debug.Log("cabou pulo");
		}


		//confere se teve os toque
		//TODO arrumar a queda livre (nao originaria de pulo, pq ta caindo mt rapido)

		if(isGrounded && (Input.touchCount > 0 || Input.GetButtonDown("Pular"))) {

			//TODO tem q conferir q nao esta apertando o botao de pause ou coisa parecida

			moveDir.y = jumpForce;
			pulando = true;
			isGrounded = false;
		}

		if(!isGrounded)
		moveDir.y += gravity * Time.deltaTime;



		myController.Move(moveDir * Time.deltaTime);

		//checa de novo se nao mudou a situacao do grounded
		if (myController.isGrounded && !isGrounded && !pulando) {
			Debug.Log("mudou");
			isGrounded = true;
			moveDir.y = 0;
		}
		
	}

	/*void LateUpdate(){
		Debug.Log ("leite");

		if(isGrounded && myController.isGrounded
	}*/

}
