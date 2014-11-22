using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
    public float moveSpeed = 2f;
    private float movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        movement = Input.GetAxis("Horizontal") * moveSpeed;  
        movement *= Time.deltaTime;        
        transform.Translate(movement,0.0f, 0.0f); // move player along X axis  
    } 
}
