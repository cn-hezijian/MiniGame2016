using UnityEngine;
using System.Collections;

public class PlamCtrl : MonoBehaviour {
	private bool isPause;//是否接触时间结界
	private bool isback;
	public float Speed;   //移动速度
	public float OX;      //初始位置
	public float X;       //移动到多少以前消失
	public GameObject Ob1;//碰撞物体消失
	public GameObject Ob2;//碰撞物体消失
	// Use this for initialization
	void Start () {
		isPause=false;
		isback=false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isPause==false){
			transform.Translate(Vector3.left*Time.deltaTime*Speed);
		}

		if(GetComponent<Collider>().bounds.Intersects(Ob1.GetComponent<Collider>().bounds)||GetComponent<Collider>().bounds.Intersects(Ob2.GetComponent<Collider>().bounds)||transform.localPosition.x<=X)
			isback=true;

		if(isback==true){
			transform.localPosition=new Vector3(OX,transform.localPosition.y,transform.localPosition.z);
			isback=false;
		}

		//判断是否碰到了时间停止结界，所有加开关运动的物体，必须加一个碰撞，用来表示自身边界
		if(GameObject.FindGameObjectWithTag("pause")!=null&&GetComponent<Collider>().bounds.Intersects(GameObject.FindGameObjectWithTag("pause").GetComponent<Collider>().bounds))
			isPause=true;
		else
			isPause=false;

	
	}



}
