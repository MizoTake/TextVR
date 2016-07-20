using UnityEngine;
using System.Collections;

public class ViveController : MonoBehaviour {

	private GameObject child;
	private BaseObject targetScript;
	private float firstPos;

	// Use this for initialization
	void Start () {
		child = transform.GetChild (0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		SteamVR_TrackedObject trackedObject = GetComponent<SteamVR_TrackedObject> ();
		var device = SteamVR_Controller.Input ((int)trackedObject.index);
		if (device.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			RayCastController ();
		}
		if(device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)){
			targetScript.Release ();
		}
		if (targetScript != null) {
			targetScript.TouchPad (device.GetAxis());
		}
	}

	void RayCastController(){
		Ray ray = new Ray (child.transform.position, child.transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 1000)){
			if (hit.transform.gameObject.tag != "Floor") {
				targetScript = hit.transform.gameObject.GetComponent<BaseObject>();
				targetScript.GetCaught (child);
			}
		}
		//Debug.DrawRay (child.transform.position, child.transform.forward, Color.green, 10.0f);
	}
}
