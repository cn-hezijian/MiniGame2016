using UnityEngine;
using System.Collections;

public class HoleCreate : MonoBehaviour {
	private int holenum = 0;    //表示目前要创造的洞的序号
	public GameObject Hole1;
	public GameObject Hole2;
	private float nextTime;  
	private float rate=0.5f;     //两次生成黑洞最短时间间隔
	public float HoleDis = 1;    //生成的虫洞离主角的距离
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(holenum==0){
			if(Input.GetAxis("RY")>0&&Time.time>=nextTime){
				nextTime=Time.time+rate;
				Destroy(GameObject.FindGameObjectWithTag("hole1"));
				Instantiate(Hole1,new Vector3(transform.position.x,transform.position.y+HoleDis,transform.position.z),Quaternion.identity);
				holenum=1;
			}
			if(Input.GetAxis("RY")<0&&Time.time>=nextTime){
				nextTime=Time.time+rate;
				Destroy(GameObject.FindGameObjectWithTag("hole1"));
				Instantiate(Hole1,new Vector3(transform.position.x,transform.position.y-HoleDis,transform.position.z),Quaternion.identity);
				holenum=1;
			}
			if(Input.GetAxis("RX")<0&&Time.time>=nextTime){
				nextTime=Time.time+rate;
				Destroy(GameObject.FindGameObjectWithTag("hole1"));
				Instantiate(Hole1,new Vector3(transform.position.x-HoleDis,transform.position.y,transform.position.z),Quaternion.identity);
				holenum=1;
			}
			if(Input.GetAxis("RX")>0&&Time.time>=nextTime){
				nextTime=Time.time+rate;
				Destroy(GameObject.FindGameObjectWithTag("hole1"));
				Instantiate(Hole1,new Vector3(transform.position.x+HoleDis,transform.position.y,transform.position.z),Quaternion.identity);
				holenum=1;
			}
		}
		
		if(holenum==1){
			if(Input.GetAxis("RY")>0&&Time.time>=nextTime){
				nextTime=Time.time+rate;
				Destroy(GameObject.FindGameObjectWithTag("hole2"));
				Instantiate(Hole2,new Vector3(transform.position.x,transform.position.y+HoleDis,transform.position.z),Quaternion.identity);
				holenum=0;
			}
			if(Input.GetAxis("RY")<0&&Time.time>=nextTime){
				nextTime=Time.time+rate;
				Destroy(GameObject.FindGameObjectWithTag("hole2"));
				Instantiate(Hole2,new Vector3(transform.position.x,transform.position.y-HoleDis,transform.position.z),Quaternion.identity);
				holenum=0;
			}
			if(Input.GetAxis("RX")<0&&Time.time>=nextTime){
				nextTime=Time.time+rate;
				Destroy(GameObject.FindGameObjectWithTag("hole2"));
				Instantiate(Hole2,new Vector3(transform.position.x-HoleDis,transform.position.y,transform.position.z),Quaternion.identity);
				holenum=0;
			}
			if(Input.GetAxis("RX")>0&&Time.time>=nextTime){
				nextTime=Time.time+rate;
				Destroy(GameObject.FindGameObjectWithTag("hole2"));
				Instantiate(Hole2,new Vector3(transform.position.x+HoleDis,transform.position.y,transform.position.z),Quaternion.identity);
				holenum=0;
			}
		}
		
		
	}
	
	
	
	
	

}
