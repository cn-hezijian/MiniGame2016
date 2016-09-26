using UnityEngine;
using System.Collections;

public class PauseCtrl : MonoBehaviour {
	public GameObject PauseSpace;
	private GameObject space;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		space=GameObject.FindGameObjectWithTag("pause");
		if(space==null&&Input.GetButtonDown("Pause"))
			space=(GameObject)Instantiate(PauseSpace,transform.position,Quaternion.identity);

		if(space!=null&&space.GetComponent<Collider>().bounds.Contains(transform.position)==false)
			Destroy(space);
	
	}
}
