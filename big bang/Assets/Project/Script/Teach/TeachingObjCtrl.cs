using UnityEngine;
using System.Collections;

public class TeachingObjCtrl : MonoBehaviour {
	public GameObject Teach1;
	public GameObject Teach2;
	public GameObject Teach3;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		T1();
		T2();
		T3();
	
	}


	void T1(){
		if(transform.position.x<0)
			Teach1.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
		if(transform.position.x>=0&&transform.position.x<=7.5f){
			Teach1.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,transform.position.x/7.5f);
		}
		if(transform.position.x>7.5f&&transform.position.x<=15){
			Teach1.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,(15-transform.position.x)/7.5f);
		}
		if(transform.position.x>15)
			Teach1.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
	}

	void T2(){
		if(transform.position.x<16)
			Teach2.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
		if(transform.position.x>=16&&transform.position.x<=25){
			Teach2.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,(transform.position.x-16)/9);
		}
		if(transform.position.x>25&&transform.position.x<=34){
			Teach2.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,(34-transform.position.x)/9);
		}
		if(transform.position.x>34)
			Teach2.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
	}

	void T3(){
		if(transform.position.x<40)
			Teach3.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
		if(transform.position.x>=40&&transform.position.x<=50){
			Teach3.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,(transform.position.x-40)/10);
		}
		if(transform.position.x>50&&transform.position.x<=60){
			Teach3.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,(60-transform.position.x)/10);
		}
		if(transform.position.x>60)
			Teach3.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
	}
}
