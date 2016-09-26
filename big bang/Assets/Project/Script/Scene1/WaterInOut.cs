using UnityEngine;
using System.Collections;

public class WaterInOut : MonoBehaviour {

	private GameObject hole1;
	private GameObject hole2;
	public GameObject WaterFall;


	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		hole1 =GameObject.FindGameObjectWithTag("hole1");
		hole2 =GameObject.FindGameObjectWithTag("hole2");
	
		//if((hole1!=null&&collider.bounds.Contains(hole1.transform.position)==true)||(hole2!=null&&collider.bounds.Contains(hole2.transform.position)))
		//	isWaterThrough=true;
		//else
		//	isWaterThrough=false;
		//if(isWaterThrough==true)
		//	WaterFall.GetComponent<ParticleEmitter>().maxEnergy=1.7f;
		//if(isWaterThrough=false)
		//	WaterFall.GetComponent<ParticleEmitter>().maxEnergy=3;

		//Debug.Log(""+isWaterThrough);
		if(hole1!=null&&hole2!=null){
			if(GetComponent<Collider>().bounds.Contains(hole1.transform.position)==true){
				WaterFall.GetComponent<ParticleEmitter>().maxEnergy=1.7f;
				hole2.GetComponentInChildren<ParticleEmitter>().emit=true;
				
			}
			
			else if(GetComponent<Collider>().bounds.Contains(hole2.transform.position)==true){
				WaterFall.GetComponent<ParticleEmitter>().maxEnergy=1.7f;
				hole1.GetComponentInChildren<ParticleEmitter>().emit=true;
			}
			else{
				WaterFall.GetComponent<ParticleEmitter>().maxEnergy=3;
				hole2.GetComponentInChildren<ParticleEmitter>().emit=false;
				hole1.GetComponentInChildren<ParticleEmitter>().emit=false;
			}
		}

			



	
	}
}
