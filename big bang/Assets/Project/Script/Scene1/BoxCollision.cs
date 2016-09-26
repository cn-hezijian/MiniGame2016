using UnityEngine;
using System.Collections;

public class BoxCollision : MonoBehaviour {
	public bool IsHitRight;    //判断箱子右侧是否顶着障碍
	public bool IsHitLeft;     //判断箱子左侧是否顶着障碍
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log("1"+IsHitLeft);
		//Debug.Log("2"+IsHitRight);
	
	}


	void OnCollisionEnter(Collision other) {

		if(other.contacts[0].normal.x==-1)
			IsHitRight=true;
		if(other.contacts[0].normal.x==1)
			IsHitLeft=true;
		

	}

	void OnCollisionExit(Collision other) {
	
		if(other.contacts[0].normal.x==-1)
			IsHitRight=false;
		if(other.contacts[0].normal.x==1)
			IsHitLeft=false;
	

	}

}
