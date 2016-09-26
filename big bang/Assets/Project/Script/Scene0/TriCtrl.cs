using UnityEngine;
using System.Collections;

public class TriCtrl : MonoBehaviour {
	public int Num;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Num==1&&ColorEggState.Egg1==true)
			gameObject.GetComponent<TriRoll>().enabled=true;
		if(Num==2&&ColorEggState.Egg2==true)
			gameObject.GetComponent<TriRoll>().enabled=true;
		if(Num==3&&ColorEggState.Egg3==true)
			gameObject.GetComponent<TriRoll>().enabled=true;
	
	}
}
