using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider p){
		if(p.tag=="player")
			Application.LoadLevel(1);
	}
}
