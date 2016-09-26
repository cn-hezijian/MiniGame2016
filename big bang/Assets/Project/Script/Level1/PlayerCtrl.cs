#define CONTROL_BY_JOYSTICK
using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
    public bool bFacingRight = true;
    public bool bControllByMovie = false;

	public static  bool onLadder;    //用来判断角色是否在梯子上，与LadderCtrl脚本有交互

    private Vector3 moveDirection = Vector3.zero;
    private float JoyInputHorizontal;
    private bool bJoyInputJump;
    
	private float lastTime;

	void Start(){
		lastTime=Time.realtimeSinceStartup;
	}
	void Update() {
        
        if(bControllByMovie)
        {
            return;
        }

		//Debug.Log(""+Input.GetAxis("Horizontal"));
		float dtime = Time.realtimeSinceStartup-(float)lastTime;

		CharacterController controller = GetComponent<CharacterController>();
		//保证在没跳起之前，y轴上没有速度
		if(controller.isGrounded)
			moveDirection.y=0;
		//跳跃
		if (controller.isGrounded||onLadder==true) {

			if (bJoyInputJump || Input.GetButton("Jump")){
				moveDirection.y = jumpSpeed;
				onLadder = false;
			}
		}

		//左右移动
		moveDirection.x=0;
		//if(Input.GetButton("LEFT")&&!Input.GetButton("RIGHT"))
		//	moveDirection.x=-speed;
		//if(Input.GetButton("RIGHT")&&!Input.GetButton("LEFT"))
		//	moveDirection.x=speed;
        if(Input.GetAxis("Horizontal") > 0)
        {
            bFacingRight = true;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            bFacingRight = false;
        }
		moveDirection=new Vector3((Input.GetAxis("Horizontal") + JoyInputHorizontal) *speed,moveDirection.y,0);

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

    public void JoyStick_OnMove_MoveHorizontal(Vector2 move)
    {
        JoyInputHorizontal = move.x;
        if(JoyInputHorizontal > 0)
        {
            bFacingRight = true;
        }
        else if(JoyInputHorizontal < 0)
        {
            bFacingRight = false;
        }
    }

    // 不再触摸控制时重置速度
    public void JoyStick_OnTouchUp_MoveHorizontal()
    {
        JoyInputHorizontal = 0;
    }

    public void JumpButton_Down()
    {
        bJoyInputJump = true;
    }

    public void JumpButton_Up()
    {
        bJoyInputJump = false;
    }

}
