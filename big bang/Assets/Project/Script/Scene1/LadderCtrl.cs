using UnityEngine;
using System.Collections;

public class LadderCtrl : MonoBehaviour {
	private GameObject player;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
	
	}
	
	// Update is called once per frame
	void Update () {
		//PlayerCtrl.onLadder=false;
		//if(collider.bounds.Contains(player.transform.position)==true)
		//	PlayerCtrl.onLadder=true;
		//if(collider.bounds.Contains(player.transform.position)==false)
		//	PlayerCtrl.onLadder=false;
	
	}

	void OnTriggerStay(Collider c){
		if(c.tag=="player"){
			//if(Input.GetButton("ONLADDER")||Input.GetAxis("Horizontal")!=0)
			//	PlayerCtrl.onLadder=true;

			//if(GameObject.FindGameObjectWithTag("player").GetComponent<CharacterController>().isGrounded==true&&Input.GetButton("OUTLADDER"))
	    	//	PlayerCtrl.onLadder=false;
			PlayerCtrl.onLadder=true;
		}
	}

	void OnTriggerExit(Collider c){
		if(c.tag=="player")
			PlayerCtrl.onLadder=false;
	}
}
