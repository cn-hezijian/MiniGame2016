using UnityEngine;
using System.Collections;

public class ExampleGlobal : MonoBehaviour {
	//该脚本作为放缩坐标的轴，是主角的子物体，而世界是其子物体。
	private GameObject Player;
	private float Vx;
	private float Vy;
	private float MaxVx;
	private float MaxVy;

	// Use this for initialization
	void Start () {

		Player=GameObject.FindGameObjectWithTag("player");
		MaxVx=GameObject.FindGameObjectWithTag("player").GetComponent<PlayerCtrl>().speed;
		MaxVy=GameObject.FindGameObjectWithTag("player").GetComponent<PlayerCtrl>().jumpSpeed;
	
	}
	
	// Update is called once per frame
	void Update () {
		Vx=Player.GetComponent<CharacterController>().velocity.x;
		Vy=Player.GetComponent<CharacterController>().velocity.y;
		float x=1-(Mathf.Abs(Vx/MaxVx))*0.5f;
		float y=1-(Mathf.Abs(Vy/MaxVy))*0.5f;
		gameObject.transform.localScale=new Vector3(x,y,1);
		//gameObject.GetComponent<CharacterController>().velocity=new Vector3(-Vx,-Vy,0);
	
	}
}
