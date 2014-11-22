using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public Vector2 jumpForce = new Vector2(0, 400);
	private Transform groundCheck;
	public AudioClip jumpSound;

	void Awake() {
		groundCheck = transform.Find ("groundCheck");
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
         if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
			Jump();
		}
    } 

	void Jump() {
		rigidbody2D.AddForce (jumpForce);
		audio.PlayOneShot(jumpSound);
	}

	bool IsGrounded () {
		return Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
	}

}
