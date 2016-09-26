using UnityEngine;
using System.Collections;

public class BackgroundCtrl : MonoBehaviour {
	private GameObject player;
	public float BeginPos;              //这个控制从时间轴到几时开始
	public float EndPos;                //这个控制从时间轴到几时结束
	public Vector2 Posx;                 //控制元素在x轴移动的位置，x为起始位置，y为结束位置
	public Vector2 Posy;                 //控制元素在y轴移动的位置，x为其实位置，y为结束位置
	public Vector2 RotZ;                 //从x度转到y度
	private float pos;

	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
	
	}
	
	// Update is called once per frame
	void Update () {
		pos=player.transform.position.x;

		if(pos>=BeginPos&&pos<=EndPos){
			transform.localPosition=new Vector3(((Posx.y-Posx.x)/(EndPos-BeginPos))*(pos-BeginPos)+Posx.x,transform.localPosition.y,transform.localPosition.z); 
			transform.localPosition=new Vector3(transform.localPosition.x,((Posy.y-Posy.x)/(EndPos-BeginPos))*(pos-BeginPos)+Posy.x,transform.localPosition.z);  
			transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,((RotZ.y-RotZ.x)/(EndPos-BeginPos))*(pos-BeginPos)+RotZ.x);
		}
	
	}
}
