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
	public Vector3 moveDir;
	private float gravity;

	public bool apertandoPulo;
	public float timeStartPulo;
	public float timeNowPulo;
	public float currentPuloIncrement;

	
	public float baseJumpForce = 6;

	public float jumpForceIncrement = 20;

	public bool isGrounded;
	public bool noArPulando = false;


	// Use this for initialization
	void Start () {
		myController = GetComponent<CharacterController> ();
		//myRigid = GetComponent<Rigidbody> ();
		gravity = Physics.gravity.y;

		// da um move soh pra pegar a situacao inicial de grounded
		myController.Move (Vector3.zero);
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = myController.isGrounded;


		if (isGrounded && noArPulando) {
			noArPulando = false;
			//Debug.Log("cabou pulo");
		}


		//confere se teve os toque
		//TODO o jogador deve poder controlar o seu pulo segurando o botao


		if (apertandoPulo) {
			Debug.Log("wiiii");
			timeNowPulo = Time.time - timeStartPulo;

			currentPuloIncrement = (jumpForceIncrement * Time.deltaTime) - timeNowPulo;

			//diminishing returns por continuar apertando o botao... ate que deixa de afetar
			if(currentPuloIncrement > 0){
				moveDir.y += currentPuloIncrement;
			}
		}

		if (Input.GetButtonUp ("Pular")) {
			apertandoPulo = false;
		}

		if(!isGrounded)
		moveDir.y += gravity * Time.deltaTime;



		myController.Move(moveDir * Time.deltaTime);

		//checa de novo se nao mudou a situacao do grounded
		if (myController.isGrounded && !isGrounded) {
			Debug.Log("mudou");
			isGrounded = true;
			moveDir.y = 0;
		}

		if(isGrounded && (Input.touchCount > 0 || Input.GetButtonDown("Pular"))) {
			
			//TODO tem q conferir q nao esta apertando o botao de pause ou coisa parecida
			apertandoPulo = true;
			timeStartPulo = Time.time;
			Debug.Log(timeStartPulo.ToString());
			noArPulando = true;
			isGrounded = false;
			moveDir.y = baseJumpForce;
		}
		
	}



}
