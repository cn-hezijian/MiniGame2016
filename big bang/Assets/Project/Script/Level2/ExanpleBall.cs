using UnityEngine;
using System.Collections;

public class ExanpleBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position=new Vector3(9,Mathf.Sin(2*Time.time),2);
	
	}
}
