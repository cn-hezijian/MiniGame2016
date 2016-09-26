using UnityEngine;
using System.Collections;

public class BossFloat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.localPosition=new Vector3(0,0.1f*Mathf.Sin(2*Time.time),0);
	
	}
}
