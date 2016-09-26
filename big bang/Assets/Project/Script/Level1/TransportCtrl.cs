using UnityEngine;
using System.Collections;

public class TransportCtrl : MonoBehaviour {
	public Vector2 TO;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnTriggerStay(Collider p){
		if(p.tag=="player"){
			if(Input.GetButton("In")){
				p.transform.position=new Vector3(transform.position.x,transform.position.y,p.transform.position.z);
				PlayerTrans();
			}
		}

	}

	void PlayerTrans(){
		if(TO.x==1&&TO.y==0)
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StateCtrlLevel1>().outWorld1();
		if(TO.x==2&&TO.y==0)
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StateCtrlLevel1>().outWorld2();
		if(TO.x==3&&TO.y==0)
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StateCtrlLevel1>().outWorld3();
		if(TO.x==0&&TO.y==1)
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StateCtrlLevel1>().inWorld1();
		if(TO.x==0&&TO.y==2)
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StateCtrlLevel1>().inWorld2();
		if(TO.x==0&&TO.y==3)
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<StateCtrlLevel1>().inWorld3();


	}
}
