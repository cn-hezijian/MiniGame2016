using UnityEngine;
using System.Collections;

public class ObjThrough : MonoBehaviour {
	private float r1;  //到hole1的距离
	private float r2;  //到hole2的距离
	private GameObject h1;    //hole1
	private GameObject h2;    //hole2
	private bool objlock;     //物体进入黑洞的锁定保护，与人类似
	private GameObject hole1;
	private GameObject hole2;
	// Use this for initialization
	void Start () {
		objlock=false;

	
	}
	
	// Update is called once per frame
	void Update () {
		hole1=GameObject.FindGameObjectWithTag("hole1");
		hole2=GameObject.FindGameObjectWithTag("hole2");
		if(hole1!=null&&hole2!=null){
			if(hole1.GetComponent<Collider>().bounds.Contains(transform.position)==false&&hole2.GetComponent<Collider>().bounds.Contains(transform.position)==false)
				objlock=false;
		}



		if(GameObject.FindGameObjectWithTag("hole1")==null)
			r1=10;
		if(GameObject.FindGameObjectWithTag("hole1")!=null){
			h1=GameObject.FindGameObjectWithTag("hole1");
			r1=Mathf.Max(Mathf.Abs(transform.position.x-h1.transform.position.x),Mathf.Abs(transform.position.y-h1.transform.position.y));
		}
		if(GameObject.FindGameObjectWithTag("hole2")==null)
			r2=10;
		if(GameObject.FindGameObjectWithTag("hole2")!=null){
			h2=GameObject.FindGameObjectWithTag("hole2");
			r2=Mathf.Max(Mathf.Abs(transform.position.x-h2.transform.position.x),Mathf.Abs(transform.position.y-h2.transform.position.y));
		}

		if(GameObject.FindGameObjectWithTag("hole1")!=null&&GameObject.FindGameObjectWithTag("hole2")!=null&&objlock==false&&Hole1Ctrl.R1inWall==false&&Hole2Ctrl.R2inWall==false)
			Through();
	
	}

	void Through(){
		//objlock=true;
		if(r1<0.2f){
			float tx=h2.transform.position.x+5*(h1.transform.position.x-transform.position.x);
			//float ty=h2.transform.position.y+5*(h1.transform.position.y-transform.position.y);
			//float tx=h2.transform.position.x;
			float ty=h2.transform.position.y;
			transform.position=new Vector3(tx,ty,transform.position.z);
			objlock=true;
		}
		if(r2<0.2f){
			float tx=h1.transform.position.x+5*(h2.transform.position.x-transform.position.x);
			//float ty=h1.transform.position.y+5*(h2.transform.position.y-transform.position.y);
			//float tx=h1.transform.position.x;
			float ty=h1.transform.position.y;
			transform.position=new Vector3(tx,ty,transform.position.z);
			objlock=true;
		}
	}
}
