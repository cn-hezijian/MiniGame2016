using UnityEngine;
using System.Collections;

public class ExampleSceneBias : MonoBehaviour {
	//该脚本用来抵消主角的移动，保证场景中物体相对于世界是不变的。场景中所有物体均为其子物体
	public float speed = 6.0F;
	private Vector3 moveDirection = Vector3.zero;
	public void Awake() {

		GetComponent<CharacterController>().detectCollisions = false;
	}
	void Start(){

	}

	void Update(){
		//给x轴一个相反与主角的速度，使其相对师姐坐标不变，又能跟随主角放大缩小
		CharacterController controller = GetComponent<CharacterController>();
		moveDirection=new Vector3(-Input.GetAxis("Horizontal")*speed,moveDirection.y,0);
		moveDirection = transform.TransformDirection(moveDirection);
		controller.Move(moveDirection * Time.deltaTime);
		//保持y轴不变
		gameObject.transform.position=new Vector3(gameObject.transform.position.x,0,0);
	}


}
