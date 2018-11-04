using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour {

	public float fuerzaSalto = 10f;
	private float tiempo = 0f, tiempoAtaque = 0f, tiempoWarning = 0f;
	public Rigidbody2D player;
	public Animator animator, animatorSombraErrante;
	private bool isInTheFloor = true;
	public Transform floorChecked;
	public GameObject sombraErrante, warning; 
	float radiusChecked = 0.1f;
	public LayerMask floor; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		tiempo++;

		if(Input.GetKeyDown(KeyCode.Q))
		{
			animator.SetTrigger("isRunning");
		}
		if(isInTheFloor && Input.GetKeyDown(KeyCode.Space))
		{
			player.AddForce(new Vector2(0, fuerzaSalto));
			animator.SetTrigger("isJumping");
			
		}

		if(tiempo == 300f)
		{
			bool isWarning = true;
			print("ss");
			do
			{
				warning.SetActive(isWarning);
				isWarning = !isWarning;
				tiempoWarning++;
			}
			while(tiempoWarning != 70f);
			warning.SetActive(false);
			sombraErrante.SetActive(true);
			do
			{
				tiempoAtaque++;
			}
			while(tiempoAtaque != 100f);
			animatorSombraErrante.SetTrigger("isAttacking");

		}

		if(isInTheFloor)
		{
			animator.SetTrigger("isRunning");
			//tiempo = 0f;
		}
	}

	void FixedUpdate() {
		isInTheFloor = Physics2D.OverlapCircle(floorChecked.position, radiusChecked, floor);
	}

}
