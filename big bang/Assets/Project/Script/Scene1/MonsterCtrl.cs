using UnityEngine;
using System.Collections;

public class MonsterCtrl : MonoBehaviour {
	public GameObject Target;
	public float MonsterSpeed;
	public float AlertDis;
	private bool isPause;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if(isPause==false){
			if(Mathf.Abs(transform.position.x-Target.transform.position.x)<=AlertDis&&Mathf.Abs(transform.position.y-Target.transform.position.y)<=2){
				transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, Target.transform.position.x, MonsterSpeed* Time.deltaTime), transform.position.y, transform.position.z);
			}
		}


		if(GameObject.FindGameObjectWithTag("pause")!=null&&GetComponent<Collider>().bounds.Intersects(GameObject.FindGameObjectWithTag("pause").GetComponent<Collider>().bounds))
			isPause=true;
		else
			isPause=false;


		if(isPause==true)
			gameObject.GetComponentInChildren<BossFloat>().enabled=false;
		else
			gameObject.GetComponentInChildren<BossFloat>().enabled=true;
	
	}




}
