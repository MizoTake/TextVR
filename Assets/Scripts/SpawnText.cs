using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SpawnText : MonoBehaviour {

	public List<string> alphabetList;
	public GameObject _player;
	public static SpawnText self;

	private const int MAX_INSTANCE_OBJECT = 1000;
	private GameObject[] _textObjs;

	// Use this for initialization
	void Start () {
		_textObjs = new GameObject[MAX_INSTANCE_OBJECT];
		alphabetList = InitList ();
		if (SceneManager.GetActiveScene ().name == "Flow") {
			for (int i = 0; i < 10; i++) {
				StartCoroutine (InstanceText ());
			}
		}
        /*
		if (SceneManager.GetActiveScene ().name == "Test") {
			StartCoroutine (InstanceText ());
		}
        */
		self = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	List<string> InitList(){
		int alphabetSize = 'Z' - 'A';
		char first = 'A';

		List<string> result = new List<string>();
		for(int i = 0; i<= alphabetSize; i++){
			result.Add(first++.ToString());
		}
		return result;
	}

    public void SpawnTextObj() {
        StartCoroutine(InstanceText());
    }

	IEnumerator InstanceText(){
		int cnt = 0;
		while (true) {
			if(_textObjs[cnt] != null){
				if (_textObjs [cnt].GetComponent<TextObj> ().CaughtStatus) {
					cnt += 1;
					continue;
				} else {
					Destroy (this._textObjs[cnt]);
				}
			}

			Vector3 randomPos;
			randomPos = new Vector3 (Random.Range (transform.position.x - transform.localScale.x, transform.position.x + transform.localScale.x), 
				transform.position.y, 
				Random.Range (transform.position.z - transform.localScale.z, transform.position.z + transform.localScale.z));
			_textObjs[cnt] = Instantiate (Resources.Load ("Text"), randomPos, Quaternion.Euler (Vector3.zero)) as GameObject;
			_textObjs[cnt].GetComponent<TextMesh>().text = alphabetList[(int)Random.Range(0, alphabetList.Count)];
			_textObjs[cnt].transform.LookAt (_player.transform);
			_textObjs[cnt].transform.rotation = Quaternion.Euler (0, _textObjs[cnt].transform.rotation.y, 0);
			cnt += 1;

            if (cnt >= MAX_INSTANCE_OBJECT)
            {
                cnt = 0;
            }
            yield return new WaitForSeconds (0.0f);
		}
	}
}
