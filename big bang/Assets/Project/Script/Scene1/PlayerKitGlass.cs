using UnityEngine;
using System.Collections;

public class PlayerKitGlass : MonoBehaviour {
	public GameObject Glass;
	public GameObject Crackle;
	public AudioSource PG;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(""+gameObject.GetComponent<CharacterController>().velocity.y);
	
	}

	void OnControllerColliderHit(ControllerColliderHit hit){
		if(hit.gameObject==Glass&&gameObject.GetComponent<CharacterController>().velocity.y<=-9){
			PG.Play ();
			float r;
			r=Random.Range(8,21);
			GameObject a;
			a=(GameObject)Instantiate(Crackle,new Vector3(transform.position.x,transform.position.y-0.5f,0),Quaternion.identity);
			a.transform.localScale=new Vector3(r/10,r/10,1);
		}
	}
}
