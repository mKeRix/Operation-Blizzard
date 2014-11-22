using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public Vector2 jumpForce = new Vector2(0, 1000);
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

         Vector2 playerPos = Camera.main.WorldToScreenPoint(transform.position);
         if (playerPos.x < -(Screen.width/2))
         {
             Die();
         }
    } 

	void OnCollisionEnter2D(Collision2D collider) {
		if (collider.gameObject.tag == "Snow") {
			Die ();
		}
	}

	void Jump() {
		rigidbody2D.AddForce (jumpForce);
		audio.PlayOneShot(jumpSound);
	}

    void Die() {
        Application.LoadLevel(Application.loadedLevel);
    }

	bool IsGrounded () {
		return Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
	}

}
