using UnityEngine;
using System.Collections;

public class BaseObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//トリガーが引かれたら
	public virtual void GetCaught(GameObject controller){}

	//トリガーが放されたら、呼ばれる
	public virtual void Release(){}

	//タッチパッドの指の位置が代入される
	public virtual void TouchPad(Vector2 position){}
}
