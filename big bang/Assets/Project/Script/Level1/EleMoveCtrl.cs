using UnityEngine;
using System.Collections;

public class EleMoveCtrl : MonoBehaviour {
	public GameObject Player;            //玩家
	public int WorldChoose;              //选择这个脚本控制的是哪个世界的元素，0表示使用真实时间，4表示记录自身的位置为time
	public float BeginTime;              //这个控制从时间轴到几时开始
	public float EndTime;                //这个控制从时间轴到几时结束
	public bool PosXCtrl;                //是否对元素的x轴移动控制
	public Vector2 Posx;                 //控制元素在x轴移动的位置，x为起始位置，y为结束位置
	public bool PosYCtrl;                //是否对元素的y轴移动控制
	public Vector2 Posy;                 //控制元素在y轴移动的位置，x为其实位置，y为结束位置
	public bool RotateCtrl;              //是否对元素的旋转进行控制
	public Vector2 RotZ;                 //从x度转到y度
	public bool First = true;            //表示是否为一段连续变换的第一个变换，默认为是
	public bool Last = true;             //表示是否为一段连续变换的最后一个变换，默认为是
	public bool isCycle;                 //是否为循环运动，与之前的fisrt、last冲突，选中这个则无视first与last是否勾选
	public float Cycle;                  //循环周期
	private float time;
	public float Speed=3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//世界选择
		if(WorldChoose==1)
			time=StateCtrlLevel1.gTime1;
		if(WorldChoose==2)
			time=StateCtrlLevel1.gTime2;
		if(WorldChoose==3)
			time=StateCtrlLevel1.gTime3;
		if(WorldChoose==0)
			time=Time.time*Speed;
		if(WorldChoose==4)
			time=Player.transform.position.x;

		//元素控制
		if(isCycle==false){
			if(PosXCtrl==true){
				if(time<BeginTime&&First==true)
					transform.localPosition=new Vector3(Posx.x,transform.localPosition.y,transform.localPosition.z);
				if(time>=BeginTime&&time<=EndTime)
					transform.localPosition=new Vector3(((Posx.y-Posx.x)/(EndTime-BeginTime))*(time-BeginTime)+Posx.x,transform.localPosition.y,transform.localPosition.z);  
				if(time>EndTime&&Last==true)
					transform.localPosition=new Vector3(Posx.y,transform.localPosition.y,transform.localPosition.z);
			}
			
			if(PosYCtrl==true){
				if(time<BeginTime&&First==true)
					transform.localPosition=new Vector3(transform.localPosition.x,Posy.x,transform.localPosition.z);
				if(time>=BeginTime&&time<=EndTime)
					transform.localPosition=new Vector3(transform.localPosition.x,((Posy.y-Posy.x)/(EndTime-BeginTime))*(time-BeginTime)+Posy.x,transform.localPosition.z);  
				if(time>EndTime&&Last==true)
					transform.localPosition=new Vector3(transform.localPosition.x,Posy.y,transform.localPosition.z);
			}
			
			if(RotateCtrl==true){
				if(time<BeginTime&&First==true)
					transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,RotZ.x);
				if(time>=BeginTime&&time<=EndTime)
					transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,((RotZ.y-RotZ.x)/(EndTime-BeginTime))*(time-BeginTime)+RotZ.x);
				if(time>EndTime&&Last==true)
					transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,RotZ.y);
			}
		}
		if(isCycle==true){
			if(PosXCtrl==true){
				if((time-BeginTime)%Cycle>=0&&(time-BeginTime)%Cycle<=EndTime-BeginTime)
					transform.localPosition=new Vector3(((Posx.y-Posx.x)/(EndTime-BeginTime))*((time-BeginTime)%Cycle)+Posx.x,transform.localPosition.y,transform.localPosition.z);  
			}
			if(PosYCtrl==true){
				if((time-BeginTime)%Cycle>=0&&(time-BeginTime)%Cycle<=EndTime-BeginTime)
					transform.localPosition=new Vector3(transform.localPosition.x,((Posy.y-Posy.x)/(EndTime-BeginTime))*((time-BeginTime)%Cycle)+Posy.x,transform.localPosition.z);  
			}
			if(RotateCtrl==true){
				if((time-BeginTime)%Cycle>=0&&(time-BeginTime)%Cycle<=EndTime-BeginTime)
					transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,((RotZ.y-RotZ.x)/(EndTime-BeginTime))*((time-BeginTime)%Cycle)+RotZ.x);
			}
		}


	
	}
}
