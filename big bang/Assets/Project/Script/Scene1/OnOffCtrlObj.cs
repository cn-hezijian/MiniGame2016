using UnityEngine;
using System.Collections;

public class OnOffCtrlObj : MonoBehaviour {
	public GameObject OnOffObj;
	public float Speed;
	public bool PosxCtrl;
	public Vector2 Posx;
	public bool PosyCtrl;
	public Vector2 Posy;
	public bool RotCtrl;
	public Vector2  RotZ;
	private bool onoff;
	private bool isPause;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		if(isPause==false){
			if(OnOffObj!=null)
				onoff=OnOffObj.GetComponentInChildren<OnOff>().Switch;
			else
				onoff=true;
			//onoff=OnOffObj.GetComponentInChildren<OnOff>().Switch;
			if(PosxCtrl==true){
				if(onoff==false)
					transform.localPosition=new Vector3(Mathf.MoveTowards(transform.localPosition.x,Posx.x,Time.deltaTime*Speed),transform.localPosition.y,transform.localPosition.z);
				if(onoff==true)
					transform.localPosition=new Vector3(Mathf.MoveTowards(transform.localPosition.x,Posx.y,Time.deltaTime*Speed),transform.localPosition.y,transform.localPosition.z);
			}
			if(PosyCtrl==true){
				if(onoff==false)
					transform.localPosition=new Vector3(transform.localPosition.x,Mathf.MoveTowards(transform.localPosition.y,Posy.x,Time.deltaTime*Speed),transform.localPosition.z);
				if(onoff==true)
					transform.localPosition=new Vector3(transform.localPosition.x,Mathf.MoveTowards(transform.localPosition.y,Posy.y,Time.deltaTime*Speed),transform.localPosition.z);
			}
			if(RotCtrl==true){
				if(onoff==false)
					transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,Mathf.MoveTowardsAngle(transform.localEulerAngles.z,RotZ.x,Time.deltaTime*Speed));
				if(onoff==true)
					transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,Mathf.MoveTowardsAngle(transform.localEulerAngles.z,RotZ.y,Time.deltaTime*Speed));
				
			}
		}

		//判断是否碰到了时间停止结界，所有加开关运动的物体，必须加一个碰撞，用来表示自身边界
		if(GameObject.FindGameObjectWithTag("pause")!=null&&GetComponent<Collider>().bounds.Intersects(GameObject.FindGameObjectWithTag("pause").GetComponent<Collider>().bounds))
			isPause=true;
		else
			isPause=false;



	}





}
