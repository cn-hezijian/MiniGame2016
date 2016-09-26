using UnityEngine;
using System.Collections;

public class Tri : MonoBehaviour {
	private GameObject player;
	public int Egg;
	public GameObject Flash;
	public GameObject TriMesh;
	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
	
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Collider>()!=null&&GetComponent<Collider>().bounds.Contains(player.transform.position)){
			if(Egg==1){
				if(ColorEggState.Egg1==false)
					ColorEggState.Egg1=true;
			}
			if(Egg==2){
				if(ColorEggState.Egg2==false)
					ColorEggState.Egg2=true;
			}
			if(Egg==3){
				if(ColorEggState.Egg3==false)
					ColorEggState.Egg3=true;
			}

			Flash.SetActive(true);
			TriMesh.SetActive(false);
		}
	
	}
}
