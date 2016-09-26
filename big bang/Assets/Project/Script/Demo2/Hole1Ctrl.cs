using UnityEngine;
using System.Collections;

public class Hole1Ctrl : MonoBehaviour {
	private GameObject player;
	private GameObject mainCamera;
	public static bool Role1Protect;       //是否处于洞中保护状态，刚被传送到另外一个洞的位置时，有一个保护状态，离开一点后保护状态结束，当状态结束后才可以再次穿越
	public static  float r1;              //矩形半径，用来表示在矩形世界中，主角到黑洞中心的距离，即主角到黑洞中心坐标分量中较大的一个
	public static bool R1inWall;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
		mainCamera=GameObject.FindGameObjectWithTag("MainCamera");

	}
	
	// Update is called once per frame
	void Update () {
		//判断虫洞是否在障碍物中
		//if(collider.bounds.Intersects(GameObject.FindGameObjectWithTag("wall").collider.bounds))
		//	R1inWall=true;
		//else
		//	R1inWall=false;
		R1inWall=InWall();
		HoleStop();
		r1 = Mathf.Max(Mathf.Abs(transform.position.x-player.transform.position.x),Mathf.Abs(transform.position.y-player.transform.position.y));
		WorldBlur();
		if(GameObject.FindGameObjectWithTag("hole2")==true&&r1<0.2f&&Role1Protect==false&&Hole2Ctrl.R2inWall==false&&R1inWall==false)
			PassThrough();



	}
	//解锁洞中保护
	void OnTriggerExit(Collider p){
		if(p.tag=="player")
			Role1Protect=false;
	}
	//画面模糊效果
	void WorldBlur(){
		Blur blur = (Blur)mainCamera.GetComponent("Blur"); 
		//黑洞范围之外
		if(r1>=1&&(Hole2Ctrl.r2>=1||GameObject.FindGameObjectWithTag("hole2")==null)){
			blur.enabled=false;
		}
		//进入黑洞范围
		if(r1<1){
			blur.enabled=true;
			blur.blurSize=(1-r1)*10;
		}
		
	}
	
	void PassThrough(){

		Hole2Ctrl.Role2Protect=true;
		//传送后的x坐标与y坐标
		//float tx=GameObject.FindGameObjectWithTag("hole2").transform.position.x+2*(transform.position.x-player.transform.position.x);
		//float ty=GameObject.FindGameObjectWithTag("hole2").transform.position.y+2*(transform.position.y-player.transform.position.y);
		float tx=GameObject.FindGameObjectWithTag("hole2").transform.position.x;
		float ty=GameObject.FindGameObjectWithTag("hole2").transform.position.y;
		player.transform.position=new Vector3(tx,ty,transform.position.z);

	}

	void HoleStop(){
		if(R1inWall==true)
		    gameObject.GetComponentInChildren<ParticleSystem>().GetComponent<Renderer>().enabled=false;
		if(R1inWall==false)
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
