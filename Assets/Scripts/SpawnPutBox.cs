using UnityEngine;
using System.Collections;

public class SpawnPutBox : MonoBehaviour {

    private string themeText;
    private const float INSTANCE_RANGE_X = 3.0f;
    private const float INSTANCE_RANGE_Z = 1.5f;

    // Use this for initialization
    void Start () {
        themeText = "test";
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PutBox() {
        StartCoroutine(InstancePutBox());
    }

    IEnumerator InstancePutBox() {
        float posX = INSTANCE_RANGE_X / themeText.Length;
        for (int i = 0; i < themeText.Length; i++)
        {
            //テキストの文字のサイズによって、位置を変える
            GameObject putObj = Instantiate(Resources.Load("PutPlace"), new Vector3(INSTANCE_RANGE_X / 2.0f - posX/2 - (posX * i), 5, INSTANCE_RANGE_Z), Quaternion.Euler(Vector3.zero)) as GameObject;
            putObj.transform.FindChild("Sphere").gameObject.GetComponent<PutPlace>().AnswerText = themeText.Substring(themeText.Length - (i + 1), 1);
            yield return new WaitForSeconds(0.3f);
        }
    }
}
