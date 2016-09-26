using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	private GameObject player;
	public float xleft;
	public float xright;
	public float yup;
	public float ydown;
	public float zback;
	public float zforward;
	private float caz;
	// Use this for initialization
	void Start () {
		player=GameObject.FindWithTag("player");

		caz=transform.position.z;

	
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x>xleft&&player.transform.position.x<xright)
		    transform.position=new Vector3(player.transform.position.x,transform.position.y,transform.position.z);
		    
		
		if(player.transform.position.y>ydown&&player.transform.position.y<yup)
			transform.position=new Vector3(transform.position.x,player.transform.position.y+5.5f,transform.position.z);

		if(player.transform.position.z>zback&&player.transform.position.z<zforward)
			transform.position=new Vector3(transform.position.x,transform.position.y,player.transform.position.z+caz);

	}



}
