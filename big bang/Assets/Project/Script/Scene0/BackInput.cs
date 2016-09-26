using UnityEngine;
using System.Collections;

public class BackInput : MonoBehaviour {
	public int  Backto;        //0代表主界面 1代表命运神殿
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Back")){
			if(Backto==0)
				Application.LoadLevel(1);
			if(Backto==1)
				Application.LoadLevel(4);
		}
			
	
	}
}
