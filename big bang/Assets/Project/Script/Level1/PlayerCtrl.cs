using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	public static  bool onLadder;    //用来判断角色是否在梯子上，与LadderCtrl脚本有交互

	private float lastTime;

	void Start(){
		lastTime=Time.realtimeSinceStartup;
	}
	void Update() {
		//Debug.Log(""+Input.GetAxis("Horizontal"));
		float dtime = Time.realtimeSinceStartup-(float)lastTime;

		CharacterController controller = GetComponent<CharacterController>();
		//保证在没跳起之前，y轴上没有速度
		if(controller.isGrounded)
			moveDirection.y=0;

		//跳跃
		if (controller.isGrounded||onLadder==true) {

			if (Input.GetButton("Jump")){
				moveDirection.y = jumpSpeed;
				onLadder=false;
			}
		}

		//左右移动
		moveDirection.x=0;
		//if(Input.GetButton("LEFT")&&!Input.GetButton("RIGHT"))
		//	moveDirection.x=-speed;
		//if(Input.GetButton("RIGHT")&&!Input.GetButton("LEFT"))
		//	moveDirection.x=speed;

		moveDirection=new Vector3(Input.GetAxis("Horizontal") *speed,moveDirection.y,0);

		//梯子上移动
		if(onLadder==true){
			moveDirection.y=0;
			if(Input.GetButton("ONLADDER"))
				moveDirection.y=speed;
			if(Input.GetButton("OUTLADDER"))
				moveDirection.y=-speed;
			//if(Input.GetButtonUp("ONLADDER"))
			//	moveDirection.y=0;
			//if(Input.GetButtonUp("OUTLADDER"))
			//	moveDirection.y=0;
			//moveDirection.y = Input.GetAxis("Vertical")*speed;
		}
		moveDirection = transform.TransformDirection(moveDirection);
		if(onLadder==false){
			moveDirection.y -= gravity * dtime;
		}

		controller.Move(moveDirection * dtime);
		transform.position=new Vector3(transform.position.x,transform.position.y,0);

		lastTime=Time.realtimeSinceStartup;

		//if(Input.GetKeyDown(KeyCode.Q))
		//	Time.timeScale=0;
		//if(Input.GetKeyDown(KeyCode.E))
		//	Time.timeScale=1;


		//Debug.Log(""+controller.velocity.y);
		//Debug.Log(""+controller.isGrounded);
	}


}
