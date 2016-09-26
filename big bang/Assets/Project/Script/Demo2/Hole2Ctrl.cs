using UnityEngine;
using System.Collections;

public class Hole2Ctrl : MonoBehaviour {
	private GameObject player;
	private GameObject mainCamera;
	public static bool Role2Protect;
	public static  float r2;              //矩形半径，用来表示在矩形世界中，主角到黑洞中心的距离，即主角到黑洞中心坐标分量中较大的一个
	public static bool R2inWall;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
		mainCamera=GameObject.FindGameObjectWithTag("MainCamera");
		
	}
	
	// Update is called once per frame
	void Update () {
		//判断虫洞是否在障碍物中
		//if(collider.bounds.Intersects(GameObject.FindGameObjectWithTag("wall").collider.bounds))
		//	R2inWall=true;
		//else
		//	R2inWall=false;
		R2inWall=InWall();
		HoleStop();
		r2 = Mathf.Max(Mathf.Abs(transform.position.x-player.transform.position.x),Mathf.Abs(transform.position.y-player.transform.position.y));
		WorldBlur();
		if(GameObject.FindGameObjectWithTag("hole1")==true&&r2<0.2f&&Role2Protect==false&&Hole1Ctrl.R1inWall==false&&R2inWall==false)
			PassThrough();


		
	}
	//解锁洞中保护
	void OnTriggerExit(Collider p){
		if(p.tag=="player")
			Role2Protect=false;
	}
	//画面模糊效果
	void WorldBlur(){
		Blur blur = (Blur)mainCamera.GetComponent("Blur"); 
		//黑洞范围之外
		if(r2>=1&&(Hole1Ctrl.r1>=1||GameObject.FindGameObjectWithTag("hole1"))){
			blur.enabled=false;
		}
		//进入黑洞范围
		if(r2<1){
			blur.enabled=true;
			blur.blurSize=(1-r2)*10;
		}
		
	}
	
	void PassThrough(){

		Hole1Ctrl.Role1Protect=true;
		//传送后的x坐标与y坐标
		//float tx=GameObject.FindGameObjectWithTag("hole1").transform.position.x+2*(transform.position.x-player.transform.position.x);
		//float ty=GameObject.FindGameObjectWithTag("hole1").transform.position.y+2*(transform.position.y-player.transform.position.y);
		float tx=GameObject.FindGameObjectWithTag("hole1").transform.position.x;
		float ty=GameObject.FindGameObjectWithTag("hole1").transform.position.y;
		player.transform.position=new Vector3(tx,ty,transform.position.z);

	}
	
	void HoleStop(){
		if(R2inWall==true)
			gameObject.GetComponentInChildren<ParticleSystem>().GetComponent<Renderer>().enabled=false;
		if(R2inWall==false)
			gameObject.GetComponentInChildren<ParticleSystem>().GetComponent<Renderer>().enabled=true;
	}

	//判断洞是否造在墙中
	bool InWall(){
		GameObject[] gos;
		gos=GameObject.FindGameObjectsWithTag("wall");
		foreach(GameObject go in gos){
			if(GetComponent<Collider>().bounds.Intersects(go.GetComponent<Collider>().bounds))
				return true;
		}
		return false;
	}
}
