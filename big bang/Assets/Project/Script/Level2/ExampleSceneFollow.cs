using UnityEngine;
using System.Collections;

public class ExampleSceneFollow : MonoBehaviour {
	private GameObject flag;
	// Use this for initialization
	void Start () {
		flag=GameObject.FindGameObjectWithTag("scenepos");
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position=flag.transform.position;
	
	}
}
