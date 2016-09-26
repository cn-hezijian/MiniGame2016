using UnityEngine;
using System.Collections;

public class RollCtrl : MonoBehaviour {
	public float Speed;
	private bool isPause;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isPause==false){
			transform.Rotate(Vector3.forward*Time.deltaTime*Speed);
		}

		if(GameObject.FindGameObjectWithTag("pause")!=null&&GetComponent<Collider>().bounds.Intersects(GameObject.FindGameObjectWithTag("pause").GetComponent<Collider>().bounds))
			isPause=true;
		else
			isPause=false;
	
	}
}
