using UnityEngine;
using System.Collections;

public class snow : MonoBehaviour {
    Vector2 speed = new Vector2(-4, 0);

	// Use this for initialization
	void Start () {
        rigidbody2D.velocity = speed;
	}
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.WorldToScreenPoint(transform.position).x < -Screen.width)
        {
            Destroy(this.gameObject);
        }
	}
}
