using UnityEngine;
using System.Collections;

public class SceneName : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.GetComponent<SpriteRenderer>().color.a<0.95f)
			gameObject.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,Mathf.Lerp(0, 1, 0.33f*Time.timeSinceLevelLoad));
		if(gameObject.GetComponent<SpriteRenderer>().color.a>=0.95f)
			gameObject.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,Mathf.Lerp(1, 0, 0.33f*(Time.timeSinceLevelLoad-3)));
	
	}
}
