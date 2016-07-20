using UnityEngine;
using System.Collections;

public class Soldier : BaseObject {

    private int frameCnt;
    private float height;
    private float speed;
    private Vector3 distance;

    public GameObject target;

    // Use this for initialization
    void Start () {
        frameCnt = 0;
        height = Random.Range(2f, 4f);
        speed = 0.1f;
        distance = Vector3.one;
    }
	
	// Update is called once per frame
	void Update () {
        //Invoke("Chase", 1.0f);
        Chase();
    }

    private void Chase() {
        distance = target.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(distance), 0.1f / target.transform.localScale.x);

        transform.position += transform.forward * speed;
    }

	public override void GetCaught(GameObject controller){}

	public override void Release(){}

	public override void TouchPad(Vector2 position){}
}
