using UnityEngine;
using System.Collections;

public class KitGlass : MonoBehaviour {
	private float Vy;       //箱子y轴上的速度
	public GameObject Glass;
	public GameObject Kitglass;
	public AudioSource BG;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vy=GetComponent<Rigidbody>().velocity.y;
		if(Kitglass.GetComponent<ParticleEmitter>().emit==true)
			Ani();
	
	}

	void OnCollisionEnter(Collision glass){
		if(glass.gameObject==Glass&&Vy<=-5f){
			Glass.SetActive(false);
			BG.Play();
			Kitglass.GetComponent<ParticleEmitter>().emit=true;
			//Kitglass.particleEmitter.emit=false;
			GameObject[] gos;
			gos=GameObject.FindGameObjectsWithTag("crackle");
			foreach(GameObject go in gos){
				Destroy(go);
			}
		}
	}

	void Ani(){
		StartCoroutine(wait1(0.5f));
	}
	IEnumerator wait1(float i){
		yield return new WaitForSeconds(i);
		Kitglass.GetComponent<ParticleEmitter>().emit=false;
	}
}
