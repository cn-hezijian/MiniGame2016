using UnityEngine;
using System.Collections;

public class OptionCtrl : MonoBehaviour {
	private int i;        //用来表示选中第几个指令，目前0代表开始1代表教学
	public GameObject HighLight;  //高亮，用来表示选中了哪个选项
	// Use this for initialization
	void Start () {
		i=0;
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(""+i);
		if(i==0){
			HighLight.transform.localPosition=new Vector3(0,0,0.1f);
			if(Input.GetButtonDown("Pause")){
				Application.LoadLevel(4);
			}
			if(Input.GetAxis("Vertical")<0){
				i=1;
			}

		}
			
		if(i==1){
			HighLight.transform.localPosition=new Vector3(0,-0.8f,0.1f);
			if(Input.GetButtonDown("Pause")){
				Application.LoadLevel(3);
			}

			if(Input.GetAxis("Vertical")>0){
				i=0;
			}
		}


			
	
	}
}
