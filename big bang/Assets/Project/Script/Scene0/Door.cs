using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public GameObject B;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Collider>().bounds.Contains(player.transform.position)){
			B.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,((Mathf.Abs(Mathf.Sin(Time.time)))/4)*3+0.25f);
			if(Input.GetButtonDown("ONLADDER")){
				Application.LoadLevel(2);
			}
				
		}
		if(!GetComponent<Collider>().bounds.Contains(player.transform.position)){
			B.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
		}
	
	}

}
