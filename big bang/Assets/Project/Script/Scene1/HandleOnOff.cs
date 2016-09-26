using UnityEngine;
using System.Collections;

public class HandleOnOff : MonoBehaviour {
	private GameObject player;
	private bool Switch;
	public GameObject Yielf;
	public GameObject Key;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
	}
	
	// Update is called once per frame
	void Update () {
		if(Switch==true)
			Yielf.GetComponent<SpriteRenderer>().enabled=false;
			//transform.parent.renderer.material.color=Color.red;
		if(Switch==false)
			Yielf.GetComponent<SpriteRenderer>().enabled=true;
			//transform.parent.renderer.material.color=Color.black;
		gameObject.GetComponent<OnOff>().Switch=Switch;

		if(GetComponent<Collider>().bounds.Contains(player.transform.position)){
			Key.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,((Mathf.Abs(Mathf.Sin(Time.time)))/4)*3+0.25f);
			if(Input.GetButtonDown("ONLADDER"))
				Switch=!Switch;
		}
		if(!GetComponent<Collider>().bounds.Contains(player.transform.position)){
			Key.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
		}
			
	}
	
	//void OnTriggerStay(Collider c){
	//	if(c.tag=="player"){
	//		if(Input.GetButtonDown("ONLADDER"))
	//			Switch=!Switch;
			
	//	}
	//}
}
