using UnityEngine;
using System.Collections;
/// <summary>
/// Pulo. faz o personagem pular
/// esse script vai no gameobject do personagem (o gameobject que tiver o rigidbody dele)
/// </summary>
public class ControleDePulo : MonoBehaviour {
	
	private CharacterController myController;
	//private Rigidbody myRigid;
	private Vector3 moveDir;
	public float gravity;
	
	private bool apertandoPulo;
	private float timeStartPulo;
	private float timeNowPulo;
	private float currentPuloIncrement;
	
	
	public float baseJumpForce = 4;
	public AudioSource puloSound;
	public float jumpForceIncrement = 20;
	
	private bool isGrounded;
	private bool noArPulando = false;
	
	private bool supportsTouch = false;
	private Touch theTouch;
	
	private Animator anim;
	
	
	// Use this for initialization
	void Start () {
		myController = GetComponent<CharacterController> ();
		
		
		myController.Move (Vector3.zero);
		anim = GetComponentInChildren<Animator> ();
		supportsTouch = Input.touchSupported;
		//Debug.Log ("Suporte a touch? " + supportsTouch.ToString());
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = myController.isGrounded;
		
		
		if (isGrounded && noArPulando) {
			noArPulando = false;
		}
		
		if (apertandoPulo) {
			timeNowPulo = Time.time - timeStartPulo;
			
			currentPuloIncrement = (jumpForceIncrement * Time.deltaTime) - timeNowPulo / 1.5f;
			
			if(currentPuloIncrement > 0){
				moveDir.y += currentPuloIncrement;
			}
		}
		
		if (Input.GetButtonUp ("Pular") || theTouch.phase == TouchPhase.Ended) {
			apertandoPulo = false;
		}
		
		if (!isGrounded) {
			moveDir.y += gravity * Time.deltaTime;
			anim.SetBool("air", true);
		}
		
		
		
		myController.Move(moveDir * Time.deltaTime);
		
		//checa de novo se nao mudou a situacao do grounded
		if (myController.isGrounded && !isGrounded) {
			isGrounded = true;
			anim.SetBool("air", false);
			moveDir.y = 0;
		}
		
		//confere se teve toque
		if(isGrounded && (Input.touchCount > 0 || Input.GetButtonDown("Pular"))) {
			
			if(supportsTouch) theTouch = Input.GetTouch(0);
			
			apertandoPulo = true;
			timeStartPulo = Time.time;
			noArPulando = true;
			isGrounded = false;
			moveDir.y = baseJumpForce;
			puloSound.Play();
			anim.Play("jump");
			anim.SetBool("air", true);
			
		}
		
	}
	
	
	
}