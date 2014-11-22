using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour {
    public GameObject snowObject;
    int score = 0;

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateSnow", 0.5f, 3f);
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
        Instantiate(snowObject);
        score++;
    }
}
