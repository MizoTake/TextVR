using UnityEngine;
using System.Collections;

public class PutPlace : MonoBehaviour {

    private string answerText;
    private bool correct;
    private GameObject answerTextObj;
    private Vector3 randomRotation;

    public string AnswerText { get { return answerText; } set { answerText = value; } }

	// Use this for initialization
	void Start () {
        correct = false;
        answerTextObj = transform.parent.transform.FindChild("AnswerText").gameObject;
        answerTextObj.GetComponent<TextMesh>().text = answerText;
        randomRotation = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(randomRotation);
        answerTextObj.transform.Rotate(randomRotation);
	}

    public void CheckText(GameObject targetObject) {
        if (!correct) {
            if (targetObject.GetComponent<TextObj>().MineText.Equals(answerText)) {
                targetObject.transform.parent = gameObject.transform;
                StartCoroutine(LerpPosition(targetObject));
                correct = true;
            }
        }
    }

    IEnumerator LerpPosition(GameObject target) {
        float time = 0;
        while (time <= 60) {
            target.transform.position = Vector3.Lerp(target.transform.position, transform.position, time/60);
            time += Time.deltaTime;
        }
        target.transform.position = transform.position;
        yield return 0;
    }
}
