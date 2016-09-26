using UnityEngine;
using System.Collections;


public class StateCtrlLevel1 : MonoBehaviour {
	public static float gTime1;                 //世界1时间轴，也是主世界时间轴
	public static float gTime2;
	public static float gTime3;
	public static float gTimeScale;             //时间尺度，整个游戏共用一个时间尺度，随着道具搜集，慢慢变小
	public static int gWorld;                   //处在哪个世界
	private GameObject player;
	private float out1;           //离开世界1时的坐标
	private float in1;            //进入1时的坐标
	private float lose1;          //1世界失去的时间，即在虫洞中走过的时间，等于每次的out1-in1之和
	private float out2;
	private float in2;
	private float lose2;
	private float out3;
	private float in3;
	private float lose3;
	//private float entertime;       
	//private float waittime;
	//private bool waitfinish;

	public GameObject BlackHoleCamera;


	// Use this for initialization
	void Awake(){
		player=GameObject.FindGameObjectWithTag("player");
		gTime1=0;
		gTime2=0;
		gTime3=0;
		gTimeScale=1;
		gWorld=1;
		in1=0;
		in2=0;
		in3=0;
		out1=0;
		out2=0;
		out3=0;
		lose1=0;
		lose2=0;
		lose3=0;
		//entertime=0;
		//waittime=0;
		//waitfinish=true;
	}

	
	// Update is called once per frame
	void Update () {
		//Debug.Log(""+gTime1);
		if(gWorld==1)
			OnWorld1();
		if(gWorld==2)
			OnWorld2();
		if(gWorld==3)
			OnWorld3();
		if(gWorld==0)
			player.transform.position=new Vector3(player.transform.position.x,player.transform.position.y,100);

		//if(Time.time>=entertime+waittime)
		//	waitfinish=true;


	
	}

	void OnWorld1(){
		gTime1=(player.transform.position.x+lose1)*gTimeScale;
		player.transform.position=new Vector3(player.transform.position.x,player.transform.position.y,0);
	}
	void OnWorld2(){
		gTime2=(player.transform.position.x+lose2)*gTimeScale;
	}
	void OnWorld3(){
		gTime3=(player.transform.position.x+lose3)*gTimeScale;
	}
	//进入虫洞
	public void outWorld1(){
		player.GetComponent<CharacterController>().enabled=false;      //先让角色控制器消失，取消角色控制，让其静止
		StartCoroutine(wait1(2));                                      //此处为等待时间，在这段时间之前可以加入动画效果
	}
	IEnumerator wait1(float i){
		yield return new WaitForSeconds(i);
		player.GetComponent<CharacterController>().enabled=true;       //恢复角色控制器，回去对角色的控制
		Blur blur = (Blur)gameObject.GetComponent("Blur");             
		out1=player.transform.position.x;                              //记录离开世界1的时间
		//player.transform.position=new Vector3(player.transform.position.x,player.transform.position.y,100);//将角色送到虫洞的坐标系
		blur.enabled=true;                                             //世界1变模糊
		BlackHoleCamera.GetComponent<Camera>().enabled=true;                           //虫洞世界摄像机开启
		gWorld=0;                                                      //标记此时已经进入虫洞
		
	}
	//离开虫洞回到世界1
	public void inWorld1(){
		player.GetComponent<CharacterController>().enabled=false;
		StartCoroutine(wait2(2));                                         
	}
	IEnumerator wait2(float i){
		yield return new WaitForSeconds(i);
		player.GetComponent<CharacterController>().enabled=true;
		Blur blur = (Blur)gameObject.GetComponent("Blur");
		//player.transform.position=new Vector3(player.transform.position.x,player.transform.position.y,0);
		in1=player.transform.position.x;
		lose1+=out1-in1;                                           //记录虫洞之旅丢失的时间
		blur.enabled=false;
		BlackHoleCamera.GetComponent<Camera>().enabled=false;
		gWorld=1;
	}
	//以下待修改，没有加特效，修改方式见world1的进入和退出，即上面两个函数
	public void outWorld2(){
		out2=player.transform.position.x;
		gWorld=0;
		player.transform.position=new Vector3(player.transform.position.x,player.transform.position.y,100);
	}
	public void inWorld2(){
		player.transform.position=new Vector3(player.transform.position.x,player.transform.position.y,200);
		in2=player.transform.position.x;
		lose2+=out2-in2;
		gWorld=2;
	}
	public void outWorld3(){
		out3=player.transform.position.x;
		gWorld=0;
		player.transform.position=new Vector3(player.transform.position.x,player.transform.position.y,100);
	}
	public void inWorld3(){
		player.transform.position=new Vector3(player.transform.position.x,player.transform.position.y,300);
		in3=player.transform.position.x;
		lose3+=out3-in3;
		gWorld=3;
	}

	//void Wait(float t){
	//	entertime=Time.time;
	//	waittime=t;
	//	waitfinish=false;
	//}
}
