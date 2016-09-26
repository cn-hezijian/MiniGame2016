using UnityEngine;
using System.Collections;

public class BoxKeyOnOff : MonoBehaviour {
	private bool Switch;
	public GameObject Key;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(Key.transform.position.x-transform.position.x)<=0.1&&Mathf.Abs(Key.transform.position.y-transform.position.y)<=0.1){
			Key.transform.position=transform.position;
			//Destroy(Key.GetComponentInChildren<PullPush>());
			Destroy(Key.GetComponent<Rigidbody>());
			Switch=true;
		}

	



		gameObject.GetComponent<OnOff>().Switch=Switch;
	}
}
