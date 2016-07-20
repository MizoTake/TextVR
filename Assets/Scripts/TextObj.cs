using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TextObj : BaseObject {

	private Vector3 keepPos;
	public Vector3 KeepPosition{ get{ return keepPos; } set{ if(caughtCount != 2) keepPos = value; }}
	private bool caught;
	public bool CaughtStatus{ get{ return caught; } }
	private TextMesh tm;
	private int caughtCount;
	private bool alphabetStop;

	// Use this for initialization
	void Start () {
		caught = false;
		if(GetComponent<TextMesh>()) tm = GetComponent<TextMesh> ();
		//Scene is Flow : Active
		if(SceneManager.GetActiveScene().name == "Flow") Destroy (this.gameObject, 4.0f);
		caughtCount = 0;
		alphabetStop = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(caught || caughtCount == 2){
			transform.localPosition = keepPos;
		}
		//if(GetComponent<TextMesh>() && !alphabetStop) tm.text = SpawnText.self.alphabetList[(int)Random.Range(0, SpawnText.self.alphabetList.Count)];
	}

	public override void GetCaught(GameObject controller){
		transform.parent = controller.transform;
        //GetComponent<BoxCollider> ().enabled = false;
        //GetComponent<Rigidbody> ().useGravity = false;
        Destroy(GetComponent<Rigidbody>());
		keepPos = transform.localPosition;
		caught = true;
		alphabetStop = true;
		caughtCount += 1;
		if(caughtCount >= 3){
			caughtCount = 1;
		}
		if(caughtCount == 2){
			keepPos = transform.position;
			transform.parent = null;
		}
	}

	public override void Release(){
		if (caughtCount != 2) {
            //GetComponent<BoxCollider> ().enabled = true;
            //GetComponent<Rigidbody> ().useGravity = true;
            gameObject.AddComponent<Rigidbody>();
			transform.parent = null;
			caught = false;
			alphabetStop = false;
			caughtCount -= 1;
			if(caughtCount < 0){
				caughtCount = 0;
			}
		}
	}

	public override void TouchPad(Vector2 position){
		KeepPosition += (Vector3.forward * position.y) / 30;
	}
}
