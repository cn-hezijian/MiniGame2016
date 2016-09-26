using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		StateCtrl();
		InputCtrl();
	
	}

	//场景状态对脚本针对元素的控制
	void StateCtrl(){
		switch (StateCtrlMain.gStartButtonOn){
		case false:
			gameObject.GetComponent<UIPanel>().alpha=((Mathf.Abs(Mathf.Sin(Time.time)))/4)*3+0.25f;
			break;
		case true:
			gameObject.GetComponent<UIPanel>().alpha=0;
			break;
		}
	}
	//按键输入对脚本针对元素的控制
	void InputCtrl(){
		if(Input.GetButton("Start"))
			StateCtrlMain.gStartButtonOn=true;
	}
}
