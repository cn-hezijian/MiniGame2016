using UnityEngine;
using System.Collections;

public class BoxClash : MonoBehaviour {
	public GameObject Box;
	private bool bdead;
	public Vector3 Pos;
	public float T; 
	private float deadtime;
	public GameObject BAni;
	// Use this for initialization
	void Start () {
		bdead=false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if(bdead==true){
			Ani ();
			//Box.transform.localPosition=Pos;
		}
		if(bdead==false)
			BAni.SetActive(false);
	
	}

	void OnTriggerEnter(Collider b){
		if(b.gameObject==Box){
			bdead=true;
			deadtime=Time.time;
			PReturn();
		}
		
	}

	void PReturn(){
		StartCoroutine(wait1(T));
	}
	
	IEnumerator wait1(float i){
		yield return new WaitForSeconds(i);
		bdead=false;
		Box.transform.localPosition=Pos;

	}

	void Ani(){
		BAni.SetActive(true);
	}
}
