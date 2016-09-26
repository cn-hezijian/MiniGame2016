using UnityEngine;
using System.Collections;

public class DoorCtrl : MonoBehaviour {
	private GameObject p;
	// Use this for initialization
	void Start () {
		p=GameObject.FindGameObjectWithTag("player");
	
	}
	
	// Update is called once per frame
	void Update () {
		NoiseAndGrain c = (NoiseAndGrain)Camera.main.GetComponent("NoiseAndGrain");
		if(p.transform.position.x>=gameObject.transform.position.x-0.8f&&p.transform.position.x<=gameObject.transform.position.x+0.8f&&Input.GetButton("In")){
			//c.intensityMultiplier=Time.time;
			c.enabled=true;
		}

	
	}

}
