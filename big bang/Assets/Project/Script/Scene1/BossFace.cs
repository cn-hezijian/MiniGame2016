using UnityEngine;
using System.Collections;

public class BossFace : MonoBehaviour {
	private GameObject player;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(transform.position.y-player.transform.position.y)<=2&&player.transform.position.x>=460){
			if(transform.position.x<player.transform.position.x)
				transform.localEulerAngles=new Vector3(0,180,0);
			if(transform.position.x>player.transform.position.x)
				transform.localEulerAngles=new Vector3(0,0,0);

		}

	
	}
}
