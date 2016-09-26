using UnityEngine;
using System.Collections;

public class SceneCtrl : MonoBehaviour {
	public GameObject Part1;
	public GameObject Part2;
	public GameObject Part3;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
	
	}
	
	// Update is called once per frame
	void Update () {
		P1Ctrl();
		P2Ctrl();
	
	}

	void P1Ctrl(){
		float x=player.transform.position.x;
		if(x>=-10&&x<=-5){
			Part1.transform.position=new Vector3(Part1.transform.position.x,x+5,0);
		}
	}

	void P2Ctrl(){
		float x=player.transform.position.x;
		if(x>=-5&&x<=0){
			Part2.transform.position=new Vector3(Part2.transform.position.x,x,0);
		}
	}
}
