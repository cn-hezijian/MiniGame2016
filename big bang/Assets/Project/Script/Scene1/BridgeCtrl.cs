using UnityEngine;
using System.Collections;

public class BridgeCtrl : MonoBehaviour {
	public float BeginPos;
	public float EndPos;
	public Vector2 RotZ;
	private float pos;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
	
	}
	
	// Update is called once per frame
	void Update () {

	    pos=(player.transform.position.x>pos)?player.transform.position.x:pos;
		if(pos<BeginPos){
			transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,RotZ.x);
		}
		if(pos>=BeginPos&&pos<=EndPos){
			transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,((RotZ.y-RotZ.x)/(EndPos-BeginPos))*(pos-BeginPos)+RotZ.x);
		}
		if(pos>EndPos){
			transform.localEulerAngles=new Vector3(transform.localEulerAngles.x,transform.localEulerAngles.y,RotZ.y);
		}
	
	}
}
