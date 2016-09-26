using UnityEngine;
using System.Collections;

public class MosterKill : MonoBehaviour {

	private GameObject player;
	//private bool pdead;         //主角是否触碰死亡板
	public Vector3 Pos;         //主角复活时的位置
	public float T;             //动画持续多少秒
	public Vector3 MPos;
	//private float deadtime;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
	
		
	}
	
	// Update is called once per frame
	void Update () {
		if(LastReplay.gLastReplay==true)
			transform.localPosition=MPos;
		//if(LastReplay.gPdead==true){
		//	Ani ();
			
			//PReturn();
		//}
		//if(pdead==false)
		//	Camera.main.GetComponent<TwirlEffect>().angle=0;
		
		
	}
	
	void OnTriggerEnter(Collider p){
		if(p.tag=="player"&&LastReplay.gPdead==false){
			//LastReplay.gLastReplay=true;
			LastReplay.gPdead=true;
			LastReplay.gDeadtime=Time.time;
			PReturn();
		}
		
	}
	
	void PReturn(){
		StartCoroutine(wait1(5*T/10));
	}
	
	IEnumerator wait1(float i){
		yield return new WaitForSeconds(i);
		//pdead=false;
		player.transform.position=Pos;
		LastReplay.gLastReplay=true;
		StartCoroutine(wait2(5*T/10));
	}
	IEnumerator wait2(float i){
		yield return new WaitForSeconds(i);
		LastReplay.gPdead=false;
		//LastReplay.gLastReplay=true;
	}
	
	
	//IEnumerator wait1(float i){
	//	yield return new WaitForSeconds(i);
	//	pdead=false;
	//	player.transform.position=Pos;
	//}
	
	//void Ani(){
		
		
	//	Camera.main.GetComponent<TwirlEffect>().angle=Mathf.Lerp(0,360,(Time.time-deadtime)/T);
		
	//}
}
