using UnityEngine;
using System.Collections;

public class BoxCtrl : MonoBehaviour {
	public BoxCollider Left;
	public BoxCollider Right;
	private GameObject player;
	public GameObject Key;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
	
	}
	
	// Update is called once per frame
	void Update () {
		//在左侧的推拉
		if(player.transform.position.x>transform.position.x-1&&player.transform.position.x<transform.position.x&&player.transform.position.y<transform.position.y+0.6f&&player.transform.position.y>transform.position.y-0.6f&&Input.GetButton("Pull")){
			//Debug.Log("aaa");
			Left.enabled=true;
			gameObject.tag="box";
		}
		else{
			Left.enabled=false;
			//gameObject.tag="wall";
		}
		//在右侧的推拉
		if(player.transform.position.x<transform.position.x+1&&player.transform.position.x>transform.position.x&&player.transform.position.y<transform.position.y+0.6f&&player.transform.position.y>transform.position.y-0.6f&&Input.GetButton("Pull")){
			//Debug.Log("aaa");
			Right.enabled=true;
			gameObject.tag="box";
		}
		else{
			Right.enabled=false;
			//gameObject.tag="wall";
		}

		if(Left.enabled==false&&Right.enabled==false)
			gameObject.tag="Untagged";

		if(((player.transform.position.x>transform.position.x-1&&player.transform.position.x<transform.position.x&&player.transform.position.y<transform.position.y+0.6f&&player.transform.position.y>transform.position.y-0.6f)||(player.transform.position.x<transform.position.x+1&&player.transform.position.x>transform.position.x&&player.transform.position.y<transform.position.y+0.6f&&player.transform.position.y>transform.position.y-0.6f))&&!Input.GetButton("Pull")){
			Key.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,((Mathf.Abs(Mathf.Sin(Time.time)))/4)*3+0.25f);
		}
		else{
			Key.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
		}
	
	}
}
