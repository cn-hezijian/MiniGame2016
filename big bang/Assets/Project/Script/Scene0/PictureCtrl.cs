using UnityEngine;
using System.Collections;

public class PictureCtrl : MonoBehaviour {
	public GameObject Picture1;
	public GameObject Picture2;
	public GameObject Picture3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		P1();
		P2();
		P3();
	
	}



	void P1(){
		if(transform.position.x<5.5f)
			Picture1.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
		if(transform.position.x>=5.5f&&transform.position.x<=8.5f)
			Picture1.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,(transform.position.x-5.5f)/3);
		if(transform.position.x>8.5f&&transform.position.x<15.5f)
			Picture1.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,1);
		if(transform.position.x>=15.5f&&transform.position.x<=18.5f)
			Picture1.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,(18.5f-transform.position.x)/3);
		if(transform.position.x>18.5f)
			Picture1.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
	}

	void P2(){
		if(transform.position.x<15.5f)
			Picture2.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
		if(transform.position.x>=15.5f&&transform.position.x<=18.5f)
			Picture2.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,(transform.position.x-15.5f)/3);
		if(transform.position.x>18.5f&&transform.position.x<25.5f)
			Picture2.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,1);
		if(transform.position.x>=25.5f&&transform.position.x<=28.5f)
			Picture2.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,(28.5f-transform.position.x)/3);
		if(transform.position.x>28.5f)
			Picture2.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
	}

	void P3(){
		if(transform.position.x<25.5f)
			Picture3.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
		if(transform.position.x>=25.5f&&transform.position.x<=28.5f)
			Picture3.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,(transform.position.x-25.5f)/3);
		if(transform.position.x>28.5f&&transform.position.x<35.5f)
			Picture3.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,1);
		if(transform.position.x>=35.5f&&transform.position.x<=38.5f)
			Picture3.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,(38.5f-transform.position.x)/3);
		if(transform.position.x>38.5f)
			Picture3.GetComponent<SpriteRenderer>().color=new Vector4(1,1,1,0);
	}

}
