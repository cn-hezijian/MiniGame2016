using UnityEngine;
using System.Collections;

public class TimeUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<UILabel>().text="Time:"+(int)StateCtrlLevel1.gTime1;
	
	}
}
