using UnityEngine;
using System.Collections;

public class PalmPatch : MonoBehaviour {
	//这个脚本是为了修补云移动平台bug

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.parent.transform.localPosition.x<34.3f)
			transform.localPosition=new Vector3(transform.localPosition.x,0,transform.localPosition.z);
		if(transform.parent.transform.localPosition.x>=34.3f)
			transform.localPosition=new Vector3(transform.localPosition.x,0.67f,transform.localPosition.z);
	
	}
}
