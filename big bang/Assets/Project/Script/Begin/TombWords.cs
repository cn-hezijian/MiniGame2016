using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TombWords : MonoBehaviour {
	public GameObject Tombwords;
	private GameObject p;
	// Use this for initialization
	void Start () {
		p=GameObject.FindGameObjectWithTag("player");
	
	}
	
	// Update is called once per frame
	void Update () {
		if(p.transform.position.x>=gameObject.transform.position.x-0.8f&&p.transform.position.x<=gameObject.transform.position.x+0.8f)
			Tombwords.GetComponent<Text>().enabled=true;
		else
			Tombwords.GetComponent<Text>().enabled=false;
				
	}


}
