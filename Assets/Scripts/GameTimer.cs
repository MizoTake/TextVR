using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {

    private float playTime;

	// Use this for initialization
	void Start () {
        playTime = 60.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (playTime < 0) playTime = 60.0f; 
        playTime -= Time.deltaTime;
        GetComponent<TextMesh>().text = "" + (int)playTime;
	}
}
