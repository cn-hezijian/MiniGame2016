using UnityEngine;
using System.Collections;

public class PalmBlock : MonoBehaviour {
	public GameObject OnOff;
	public GameObject Wall;          //被哪段藤条墙阻碍
	public float WallY;              //藤条强移动到多以上发生阻碍
	public Vector2 PalmX;                //分别代表平台在墙两侧的x坐标值
	private float StarY;              //藤条一开始应该移动到的位置
	// Use this for initialization
	void Start () {
		StarY=Wall.GetComponent<OnOffCtrlObj>().Posy.y;
	
	}
	
	// Update is called once per frame
	void Update () {
		//平台阻碍墙
		if(Wall.transform.localPosition.y<=WallY){
			gameObject.GetComponent<OnOffCtrlObj>().enabled=true;
			if(transform.localPosition.x>PalmX.x&&transform.localPosition.x<PalmX.y){
				//if(OnOff.GetComponentInChildren<OnOff>().Switch==true)
				//	Wall.GetComponent<OnOffCtrlObj>().enabled=false;
				//if(OnOff.GetComponentInChildren<OnOff>().Switch==false)
				//	Wall.GetComponent<OnOffCtrlObj>().enabled=true;
				Wall.GetComponent<OnOffCtrlObj>().Posy.y=WallY;
			}
			if(transform.localPosition.x<=PalmX.x||transform.localPosition.x>=PalmX.y)
				Wall.GetComponent<OnOffCtrlObj>().Posy.y=StarY;
		}
			

		//墙阻碍平台
		if(Wall.transform.localPosition.y>WallY){
			//平台右移受阻
			if(transform.localPosition.x>=PalmX.x&&transform.localPosition.x<(PalmX.x+PalmX.y)/2){
				if(OnOff.GetComponentInChildren<OnOff>().Switch==true)
					gameObject.GetComponent<OnOffCtrlObj>().enabled=false;
				if(OnOff.GetComponentInChildren<OnOff>().Switch==false)
					gameObject.GetComponent<OnOffCtrlObj>().enabled=true;
			}
			//平台左移受阻
			if(transform.localPosition.x<=PalmX.y&&transform.localPosition.x>(PalmX.x+PalmX.y)/2){
				if(OnOff.GetComponentInChildren<OnOff>().Switch==false)
					gameObject.GetComponent<OnOffCtrlObj>().enabled=false;
				if(OnOff.GetComponentInChildren<OnOff>().Switch==true)
					gameObject.GetComponent<OnOffCtrlObj>().enabled=true;
			}
		}
	
	}
}
