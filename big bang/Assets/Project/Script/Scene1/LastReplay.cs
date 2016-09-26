using UnityEngine;
using System.Collections;

public class LastReplay : MonoBehaviour {
	public static bool gLastReplay;
	public static bool gPdead;
	public static float gDeadtime;
	// Use this for initialization
	void Start () {
		gLastReplay=false;
		gPdead=false;
	
	}
	
	// Update is called once per frame
	void LateUpdate () {


		if(gPdead==true)
			Ani ();

		if(gLastReplay==true)
			StartCoroutine(wait1(1));


	
	}
	IEnumerator wait1(float i){
		yield return new WaitForSeconds(i);
		gLastReplay=false;
	}

	void Ani(){
		
		
		Camera.main.GetComponent<TwirlEffect>().angle=Mathf.Lerp(0,360,(Time.time-gDeadtime)/2);
		
	}
}
