using UnityEngine;
using System.Collections;

public class InWall : MonoBehaviour {
	private GameObject player;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Collider>().bounds.Contains(player.transform.position)==true)
			Debug.Log("aaa");


	
	}


}
