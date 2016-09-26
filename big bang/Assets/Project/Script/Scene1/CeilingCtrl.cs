using UnityEngine;
using System.Collections;

public class CeilingCtrl : MonoBehaviour {
	private float y;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		y=0.5f+Camera.main.orthographicSize;
		transform.localPosition=new Vector3(0,y,10);
	
	}
}
