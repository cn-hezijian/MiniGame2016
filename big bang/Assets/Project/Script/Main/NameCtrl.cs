using UnityEngine;
using System.Collections;

public class NameCtrl : MonoBehaviour {
	public GameObject Name;
	public GameObject Star;
	public GameObject Option;
	// Use this for initialization
	void Start () {
		Name.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
	
	}
	
	// Update is called once per frame
	void Update () {

		 Name.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,Mathf.Lerp(0, 1, 0.2f*(Time.time-6)));
		if(Name.GetComponent<SpriteRenderer>().color.a==1){
			Star.GetComponent<UILabel>().enabled=true;
		}

		if(StateCtrlMain.gStartButtonOn==true){
			Option.SetActive(true);
		}
	
	}
}
