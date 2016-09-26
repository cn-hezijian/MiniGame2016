using UnityEngine;
using System.Collections;

public class MusicCtrl : MonoBehaviour {
	public GameObject Sky;
	public AudioSource Day;
	public AudioSource Night;
	public AudioSource Boss;
	public AudioSource PauseMusic;
	private float time;
	private float c;          //衰减系数，让背景音乐在接近传送门时越来越弱
	private float c1;         //第二个系数，被时间结界控制
	private GameObject player;


	// Use this for initialization
	void Start () {
		player=GameObject.FindGameObjectWithTag("player");
		c=1;
		c1=1;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(player.transform.position.x<=388)
			c=1;
		if(player.transform.position.x>388&&player.transform.position.x<=410)
			c=(410-player.transform.position.x)/22;
		if(player.transform.position.x>410)
			c=0;

		time=Sky.GetComponent<TOD_Sky>().Cycle.Hour;
		if(time>=0&&time<5){
			Day.volume=0;
			Night.volume=c*c1;
		}
		if(time>=5&&time<6){
			Day.volume=0;
			Night.volume=(6-time)*c*c1;
		}
		if(time>=6&&time<7){
			Day.volume=(time-6)*c*c1;
			Night.volume=0;
		}
		if(time>=7&&time<17){
			Day.volume=c*c1;
			Night.volume=0;
		}
		if(time>=17&&time<18){
			Day.volume=(18-time)*c*c1;
			Night.volume=0;
		}
		if(time>=18&&time<19){
			Day.volume=0;
			Night.volume=(time-18)*c*c1;
		}
		if(time>=19&&time<=24){
			Day.volume=0;
			Night.volume=c*c1;
		}

		if(player.transform.position.x>=460){
			Boss.enabled=true;
		}
		else
			Boss.enabled=false;

		if(GameObject.FindGameObjectWithTag("pause")!=null){
			c1=0;

			Boss.volume=0;
			PauseMusic.enabled=true;
		}
		else{
			c1=1;
			Boss.volume=1;
			PauseMusic.enabled=false;
		}

			
	



	
	}
}
