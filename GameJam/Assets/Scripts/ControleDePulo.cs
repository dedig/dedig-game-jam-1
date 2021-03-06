﻿using UnityEngine;
using System.Collections;
/// <summary>
/// Pulo. faz o personagem pular, emitir particulas ao andar e pular e piscar ao ser
/// arrastado para tras. Esse script controla a maioria dos outros relacionados a acoes
/// realizadas pelo jogador ou sobre ele.
/// esse script vai no gameobject do personagem (o gameobject que tiver o rigidbody dele)
/// </summary>
public class ControleDePulo : MonoBehaviour {
	
	private CharacterController myController;
	public ParticleSystem jumpParticle;
	public ParticleSystem runParticle;
	public Particle particle;
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

	private SpriteFlashBranco flashScript;

	private float ultimaPosX;

	public float posXAtual;
	
	// Use this for initialization
	void Start () {
		myController = GetComponent<CharacterController> ();


		
		myController.Move (Vector3.zero);
		anim = GetComponentInChildren<Animator> ();
		supportsTouch = Input.touchSupported;
		jumpParticle = GetComponentInChildren<ParticleSystem> ();

		flashScript = GetComponentInChildren<SpriteFlashBranco> ();

		posXAtual = transform.position.x;
		ultimaPosX = posXAtual;
	}
	
	// Update is called once per frame
	void Update () {
		isGrounded = myController.isGrounded;

		posXAtual = transform.position.x;

		if (ultimaPosX != posXAtual)
			flashScript.Piscar (0.5f, 0.25f);

		ultimaPosX = posXAtual;
		
		
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
			runParticle.enableEmission = false;
		}
		
		
		
		myController.Move(moveDir * Time.deltaTime);
		
		//checa de novo se nao mudou a situacao do grounded
		if (myController.isGrounded && !isGrounded) {
			isGrounded = true;
			runParticle.enableEmission = true;
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
			runParticle.enableEmission = false;
			moveDir.y = baseJumpForce;
			puloSound.Play();
			anim.Play("jump");
			anim.SetBool("air", true);


			jumpParticle.Emit(30);

		}
		
	}

	

	
	
}