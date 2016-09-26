using UnityEngine;
using System.Collections;

public class SeesawCtrl : MonoBehaviour {

	//绑在主角身上的脚本，用来控制跷跷板事件
	public GameObject Seesaw;           //控制哪一块跷跷板
	public float MaxAngle;              //最大可以转到多少角度
	private bool isPause;               //是否被时间结界罩住
	private float r;                    //角色的力臂
	private bool isOnSeesaw;            //是否在跷跷板上
	public float Speed;
	// Use this for initialization
	void Start () {
		isOnSeesaw=false;
		isPause=false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(isPause==false&&isOnSeesaw==true){
			if(Seesaw.transform.position.x-transform.position.x>=0){
				if(Seesaw.transform.localEulerAngles.z<=90+MaxAngle)
					Seesaw.transform.Rotate(new Vector3(0,0,Speed*(Seesaw.transform.position.x-transform.position.x)/10));
				if(Seesaw.transform.localEulerAngles.z>90+MaxAngle)
					Seesaw.transform.localEulerAngles=new Vector3(Seesaw.transform.localEulerAngles.x,Seesaw.transform.localEulerAngles.y,90+MaxAngle);
			}
			if(Seesaw.transform.position.x-transform.position.x<=0){
				if(Seesaw.transform.localEulerAngles.z>=90-MaxAngle)
					Seesaw.transform.Rotate(new Vector3(0,0,Speed*(Seesaw.transform.position.x-transform.position.x)/10));
				if(Seesaw.transform.localEulerAngles.z<90-MaxAngle)
					Seesaw.transform.localEulerAngles=new Vector3(Seesaw.transform.localEulerAngles.x,Seesaw.transform.localEulerAngles.y,90-MaxAngle);
			}
		}



		//被时间结界罩住的情况
		if(GameObject.FindGameObjectWithTag("pause")!=null&&Seesaw.GetComponent<Collider>().bounds.Intersects(GameObject.FindGameObjectWithTag("pause").GetComponent<Collider>().bounds))
			isPause=true;
		else
		    isPause=false;
	
	
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		if(hit.gameObject==Seesaw){
			isOnSeesaw=true;
		}
		else{
			isOnSeesaw=false;
		}
	}
}
