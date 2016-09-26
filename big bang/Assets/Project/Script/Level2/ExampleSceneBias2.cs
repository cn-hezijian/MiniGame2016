using UnityEngine;
using System.Collections;

public class ExampleSceneBias2 : MonoBehaviour {

	private GameObject player;
	private Vector3 V=Vector3.zero;
	// Use this for initialization
	void Awake(){
		GetComponent<Rigidbody>().detectCollisions = false;
	}
	void Start () {

		player=GameObject.FindGameObjectWithTag("player");
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		V=player.GetComponent<CharacterController>().velocity;
		gameObject.GetComponent<Rigidbody>().velocity=-V;
	
	}
}
