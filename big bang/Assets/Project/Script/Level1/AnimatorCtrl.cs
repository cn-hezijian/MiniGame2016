using UnityEngine;
using System.Collections;

public class AnimatorCtrl : MonoBehaviour {
	public GameObject Body;
	public GameObject Head;
	private float JumpSpeed;
	// Use this for initialization
	void Start () {
		JumpSpeed=gameObject.GetComponent<PlayerCtrl>().jumpSpeed;
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 speed=gameObject.GetComponent<CharacterController>().velocity;
		Moving(speed.x);
		Jumping(speed.y);
		FaceTo();
		//Debug.Log(""+gameObject.GetComponent<CharacterController>().velocity);
	}


	void Moving(float v){
		Body.transform.localEulerAngles=new Vector3(0,0,-v*2);
	}

	void Jumping(float v){
		if(!gameObject.GetComponent<CharacterController>().isGrounded){
			if(v>0){
				Body.transform.localScale=new Vector3(0.8f+v/JumpSpeed/5,1,0.8f+v/JumpSpeed/5);
			}
			if(v<0){
				Body.transform.localScale=new Vector3(1.2f,1,1.2f);
			}
		}
		else{
			Body.transform.localScale=new Vector3(1,1,1);
		}
	}
	void FaceTo(){
		if(Input.GetAxis("Horizontal")<0){
			Head.transform.localEulerAngles=new Vector3(0,180,0);
		}
		if(Input.GetAxis("Horizontal")>0){
			Head.transform.localEulerAngles=new Vector3(0,0,0);
		}
	}
}
