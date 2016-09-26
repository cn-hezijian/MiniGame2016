using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,Mathf.Lerp(0, 1, 0.2f*Time.time));
		Go();

	
	}

	void Go(){
		StartCoroutine(wait1(6));
	}
	
	IEnumerator wait1(float i){
		yield return new WaitForSeconds(i);
		Application.LoadLevel(1);

	}
}
