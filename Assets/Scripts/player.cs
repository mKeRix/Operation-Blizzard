using UnityEngine;
using System.Collections;
using Leap;

public class player : MonoBehaviour {
	public Vector2 jumpForce = new Vector2(0, 1000);
	private Transform groundCheck;
	public AudioClip jumpSound;
	private Controller controller;
	private Frame frame; 
	private HandList hands;
	private Hand firstHand;
	public Vector handVelocity;
	public float jumpTrigger;

	void Awake() {
		groundCheck = transform.Find ("groundCheck");
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		controller = new Controller();
		frame = controller.Frame();
		hands = frame.Hands;
		firstHand = hands [0];
		handVelocity = firstHand.PalmVelocity;

        if((Input.GetKeyDown(KeyCode.Space) || handVelocity.z > 200) && IsGrounded()) {
			Jump();
		}

         Vector2 playerPos = Camera.main.WorldToScreenPoint(transform.position);
         if (playerPos.x < -(UnityEngine.Screen.width/2))
         {
             Die();
         }
    } 

	void OnCollisionEnter2D(Collision2D collider) {
		Animator anim = GetComponent<Animator>();

		if (collider.gameObject.tag == "Snow") {
			Die ();
		}
		else if (collider.gameObject.tag == "Ground") {
			audio.Play ();
			anim.speed = 0.8f;
		}
	}

	void Jump() {
		Animator anim = GetComponent<Animator>();

		rigidbody2D.AddForce (jumpForce);
		audio.PlayOneShot(jumpSound);
		audio.Pause ();
		anim.speed = 0f;
	}

    void Die() {
        Application.LoadLevel(0);
    }

	bool IsGrounded () {
		return Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
	}

}
