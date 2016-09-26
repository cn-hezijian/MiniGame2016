using UnityEngine;
using System.Collections;

public class PullPush : MonoBehaviour {
	private GameObject  player;

	private GameObject box;

	//private bool isPullorPush;   

	private bool isPull;     
	private bool isPush;

	public bool isLeftHandle;     //是否为箱子左把手，如果把手在左边置为true，在右边置为false
	private float a;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("player");

		box = gameObject.transform.parent.gameObject;

		isPull=false;
		isPush=false;

		if(isLeftHandle==true){
			a=box.transform.localScale.x/2+0.6f;
		}
		if(isLeftHandle==false){
			a=-box.transform.localScale.x/2-0.6f;
		}
	
	}
	
	// Update is called once per frame
	void Update () {




		//主角不推拉箱子
		if(Input.GetKeyUp(KeyCode.Z)||GetComponent<Collider>().bounds.Contains(player.transform.position)==false){
			player.GetComponent<PlayerCtrl>().speed=6;   //角色正常速度

			isPull=false;
			isPush=false;

		}



		//左把手的情况
		if(isLeftHandle==true){
			if(Input.GetButtonUp("LEFT"))
				isPull=false;
			if(Input.GetButtonUp("RIGHT"))
				isPush=false;
			if(Input.GetButton("LEFT")&&Input.GetButton("RIGHT")){
				isPull=false;
				isPush=false;
			}
			
			
			//主角拉箱子
			if(GetComponent<Collider>().bounds.Contains(player.transform.position)==true&&Input.GetKey(KeyCode.Z)&&Input.GetButton("LEFT")&&!Input.GetButton("RIGHT")){
				//player.GetComponent<PlayerCtrl>().speed=2;

				isPull=true;
			}
			//主角拉箱子时的箱子位移变化
			if(isPull==true){
				player.GetComponent<PlayerCtrl>().speed=2;
				box.transform.position=new Vector3(player.transform.position.x+a,box.transform.position.y,0);
				
			}
			
			//主角推箱子
			if(GetComponent<Collider>().bounds.Contains(player.transform.position)==true&&Input.GetKey(KeyCode.Z)&&Input.GetButton("RIGHT")&&!Input.GetButton("LEFT")){
				player.GetComponent<PlayerCtrl>().speed=2;

				isPush=true;
			}
			//主角推箱子时的箱子位移变化
			if(isPush==true){
				
				//box.transform.position=new Vector3(player.transform.position.x+a,box.transform.position.y,0);
				box.GetComponent<Rigidbody>().velocity=new Vector3(2,0,0);
				
			}
		}

		//右把手的情况
		if(isLeftHandle==false){
			if(Input.GetButtonUp("RIGHT"))
				isPull=false;
			if(Input.GetButtonUp("LEFT"))
				isPush=false;
			if(Input.GetButton("LEFT")&&Input.GetButton("RIGHT")){
				isPull=false;
				isPush=false;
			}
			
			
			//主角拉箱子
			if(GetComponent<Collider>().bounds.Contains(player.transform.position)==true&&Input.GetKey(KeyCode.Z)&&Input.GetButton("RIGHT")&&!Input.GetButton("LEFT")){
				//player.GetComponent<PlayerCtrl>().speed=2;

				isPull=true;
			}
			//主角拉箱子时的箱子位移变化
			if(isPull==true){
				player.GetComponent<PlayerCtrl>().speed=2;
				box.transform.position=new Vector3(player.transform.position.x+a,box.transform.position.y,0);
				
			}
			
			//主角推箱子
			if(GetComponent<Collider>().bounds.Contains(player.transform.position)==true&&Input.GetKey(KeyCode.Z)&&Input.GetButton("LEFT")&&!Input.GetButton("RIGHT")){
				player.GetComponent<PlayerCtrl>().speed=2;

				isPush=true;
			}
			//主角推箱子时的箱子位移变化
			if(isPush==true){
				
				//box.transform.position=new Vector3(player.transform.position.x+a,box.transform.position.y,0);
				box.GetComponent<Rigidbody>().velocity=new Vector3(-2,0,0);
				
			}
		}


		//受结界影响效果
		if(box.GetComponent<Rigidbody>()!=null){
			if(GameObject.FindGameObjectWithTag("pause")!=null&&GetComponent<Collider>().bounds.Intersects(GameObject.FindGameObjectWithTag("pause").GetComponent<Collider>().bounds))
				box.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezePositionY|RigidbodyConstraints.FreezePositionZ|RigidbodyConstraints.FreezeRotation;
			else
				box.GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezePositionZ|RigidbodyConstraints.FreezeRotation;

		}



	
	}




}
