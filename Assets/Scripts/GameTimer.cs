using UnityEngine;
using System.Collections;

public class GameTimer : BaseObject {

    private float playTime;
    private bool startTime;
    
    public bool StartTime { get { return startTime; } set { startTime = value; } }
    public GameObject spawnTextObj;
    public GameObject spawnPutPlace;

	// Use this for initialization
	void Start () {
        playTime = 60.0f;
        startTime = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (startTime)
        {
            if (playTime < 0) playTime = 60.0f;
            playTime -= Time.deltaTime;
            GetComponent<TextMesh>().text = "" + (int)playTime;
        }
	}

    public override void GetCaught(GameObject controller) {
        if (!startTime)
        {
            spawnTextObj.GetComponent<SpawnText>().SpawnTextObj();
            spawnPutPlace.GetComponent<SpawnPutBox>().PutBox();
        }
        startTime = true;
    }
}
