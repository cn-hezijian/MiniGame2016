using UnityEngine;
using System.Collections;

public class FirstEgg : MonoBehaviour {
	private GameObject player;
	public GameObject FlashCloud;
	public GameObject Egg;
	public GameObject Cloud;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider p){
		if(p.tag=="player"){
			FlashCloud.SetActive(true);
			Cloud.SetActive(false);
			if(ColorEggState.Egg1==false)
				Egg.SetActive(true);
		}

	}
}
