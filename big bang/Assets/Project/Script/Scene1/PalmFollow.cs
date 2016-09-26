using UnityEngine;
using System.Collections;

public class PalmFollow : MonoBehaviour {
	private GameObject player;
	//private bool follow;
	public GameObject Father;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
		//follow=false;
	
	}
	
	// Update is called once per frame
	void Update () {
		//if(follow==false)
		//	player.transform.parent=null;
		//if(follow==true)
		//	player.transform.parent=Father.transform;
	
	}

	void OnTriggerStay(Collider p){
		if(p.tag=="player")
			player.transform.parent=Father.transform;
			//follow=true;
	}

	void OnTriggerExit(Collider p){
		if(p.tag=="player")
			player.transform.parent=null;
			//follow=false;
	}
}
