using UnityEngine;
using System.Collections;

public class WorldDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		VortexEffect c = (VortexEffect)gameObject.GetComponent("VortexEffect");
		//c.angle=gameObject.transform.position.x*20;
		c.angle=Time.time*50;
		c.radius=new Vector2(gameObject.transform.position.x*0.0108f,gameObject.transform.position.x*0.0192f);
	
	}
}
