using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private bool moving = false;
	private float max_body_size;

	[SerializeField]
	private int last_state;
	[SerializeField]
	private float speed;
//	private float diagonal;
//	private float last_state_x;
//	private float last_state_y;

	private Vector2 direction;

	private Animator animator;

	private GameObject yoyoa;

	private Vector2 destination;

	// Use this for initialization
	void Start () {
		this.max_body_size = 1.5f;
		this.last_state = 1;
//		this.diagonal = 1f;
		animator = GetComponent<Animator> ();
		this.animateScale ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		Move ();
	}

	public void Move(){
		if (this.moving) { 
//			last_state_x = transform.position.x;
//			last_state_y = transform.position.y;
			speed = (this.max_body_size - ((transform.position.y + 5f) / 12f));
			this.direction = Direction.run (transform.position, this.destination);
			transform.Translate (this.direction.normalized * Time.deltaTime * speed);
			float distance = Vector3.Distance ((Vector3)destination, transform.position);
			if (distance <= 1.01f) {
				this.movement (false);
			}
		} 
	}

	public void AnimateMovement(Vector2 direction, int s = 1){
		animator.SetFloat ("x", direction.x);
		animator.SetFloat ("y", direction.y);
		animator.SetInteger ("s", s);
	}

	public void setMovement(Vector2 direc){
		Vector2 run = Direction.run (transform.position, direc);
		this.viewPoint (-Direction.sign (run.x));
		this.destination = direc;
		this.moving = true;
		AnimateMovement(run);
	}

	private void animateScale(){
		float x = (this.max_body_size - ((transform.position.y + 5f) / 15f)) * last_state;
		float y = this.max_body_size - ((transform.position.y + 5f) / 15f);
		float z = 1f;
		this.transform.localScale = new Vector3 (x, y, z);
	}

	private void viewPoint(int current_state){
		if (last_state != current_state) {
			last_state = current_state;
			transform.localScale = new Vector3(current_state * transform.localScale.y, transform.localScale.y, 1f);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Destroy(other.gameObject);
	}

	void OnCollisionEnter (Collision col)
	{
		Debug.Log ("asdas");
	}

	void movement(bool move){
		if (this.moving && !move) {
			this.AnimateMovement (Vector2.zero, 0);
		}
		this.moving = move;
	}
}
