using UnityEngine;
using System.Collections;

public class ThirdEgg : MonoBehaviour {
	private GameObject player;
	public GameObject Egg;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
	
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x>=493&&ColorEggState.Egg3==false)
			Egg.SetActive(true);
	
	}
}
