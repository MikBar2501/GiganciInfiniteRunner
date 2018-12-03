using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float jumpForce;
	public float liftingForce;
	public bool jumped;
	public bool doubleJump;

	private Rigidbody2D rb;
	public float startingY;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		startingY = transform.position.y + 0.03f;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!GameManager.instance.inGame) {
			return;
		} else {
			if(jumped && transform.position.y <= startingY) {
				jumped = false;
				doubleJump = false;
			}

			if(Input.GetMouseButtonDown(0)) {
				if(!jumped) {
					rb.velocity = (new Vector2(0f, jumpForce));
					jumped = true;
				} else if (!doubleJump) {
					rb.velocity = (new Vector2(0f, jumpForce));
					doubleJump = true;
				}
			}

			if(Input.GetMouseButton(0) && rb.velocity.y < 0) {
				rb.AddForce(new Vector2(0f,liftingForce * Time.deltaTime));
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.CompareTag("Obstacle")) {
			PlayerDeath();
		}	
	}

	public void PlayerDeath() {
		GameManager.instance.GameOver();
	}
}
