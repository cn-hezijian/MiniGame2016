using UnityEngine;
using System.Collections;

public class SkyCtrl : MonoBehaviour {
	private float time;
	public int World;            //用来选择世界
	public float Cycle = 48;     //经过多久循环一圈
	public float BeginTime;      //从什么时刻开始
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if(World==1)
			time=StateCtrlLevel1.gTime1;
		if(World==2)
			time=StateCtrlLevel1.gTime2;
		if(World==3)
			time=StateCtrlLevel1.gTime3;
		//其中-61是第一张背景图的y坐标，144是两张背景图的坐标差
		if((time-BeginTime)%Cycle>=0&&(time-BeginTime)%Cycle<Cycle)
			transform.localPosition=new Vector3(transform.localPosition.x,(144/Cycle)*((time-BeginTime)%Cycle)-61,transform.localPosition.z); 

	
	}
}
