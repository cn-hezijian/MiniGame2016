using UnityEngine;
using System.Collections;

public class BeginCameraCtrl : MonoBehaviour {
	private GameObject player;
	// Use this for initialization
	void Start () {
		player=GameObject.FindWithTag("player");
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		float c =(player.transform.position.x-8)>transform.position.x?(player.transform.position.x-8):transform.position.x;
		if(player.transform.position.x>8&&player.transform.position.x<60)
		    transform.position=new Vector3(c,transform.position.y,transform.position.z);
	
	}
}
