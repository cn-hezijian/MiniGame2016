using UnityEngine;
using System.Collections;

public class BoxKey : MonoBehaviour {
	//public GameObject Box;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//对于boxkey碰撞到死亡版的行为
	void OnTriggerEnter(Collider d){
		if(d.tag=="deadboard"){
			//Instantiate(Box,new Vector3(70,-7.5f,0),transform.rotation);
			//Destroy(gameObject);
			transform.position=new Vector3(70,-7.5f,0);
		}
	}
}
