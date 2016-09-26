using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {
	public GameObject Sky;
	private float time;
	private float t;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		ColorCorrectionCurves c = (ColorCorrectionCurves)gameObject.GetComponent("ColorCorrectionCurves");
		time=Sky.GetComponent<TOD_Sky>().Cycle.Hour;
		if(time>=12&&time<=24){
			t=24-time;
		}
		if(time>=0&&time<12){
			t=time;
		}
		c.selectiveToColor=new Vector4((t/12),(t/12),(t/12),1);
		//Debug.Log(""+c.selectiveToColor);
	
	}
}
