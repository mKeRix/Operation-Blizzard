using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {
    public GameObject snowObject;
    int score = 0;

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateSnow", 0.5f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.color = Color.black;
        GUILayout.Label("Score: " + score.ToString());
    }

    void CreateSnow()
    {
		if (Random.Range (0, 2) == 0) {
			Instantiate (snowObject);
			score++;
		}
    }
}
