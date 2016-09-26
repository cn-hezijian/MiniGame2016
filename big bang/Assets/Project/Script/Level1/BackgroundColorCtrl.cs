using UnityEngine;
using System.Collections;

public class BackgroundColorCtrl : MonoBehaviour {
	public float SpringPoint;
	public float SummerPoint;
	public float AutumnPoint;
	public float WinterPoint;

	public Vector3 SpringColor;
	public Vector3 SummerColor;
	public Vector3 AutumnColor;
	public Vector3 WinterColor;


	public bool Back;               //开启的画，当渐变到冬天后继续前进还会渐变回春天
	public float Dis;               //用来表示两段间距离，即冬天到下一个春天间的距离
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float CameraPoint=StateCtrlLevel1.gTime1;
		if(CameraPoint>=SpringPoint&&CameraPoint<SummerPoint){
			Vector3 a = (SpringColor+((SummerColor-SpringColor)*(CameraPoint-SpringPoint)/(SummerPoint-SpringPoint)))/255;
			Camera.main.backgroundColor=new Color(a.x,a.y,a.z,0.02f);
		}
		if(CameraPoint>=SummerPoint&&CameraPoint<AutumnPoint){
			Vector3 a = (SummerColor+((AutumnColor-SummerColor)*(CameraPoint-SummerPoint)/(AutumnPoint-SummerPoint)))/255;
			Camera.main.backgroundColor=new Color(a.x,a.y,a.z,0.02f);
		}
		if(CameraPoint>=AutumnPoint&&CameraPoint<WinterPoint){
			Vector3 a = (AutumnColor+((WinterColor-AutumnColor)*(CameraPoint-AutumnPoint)/(WinterPoint-AutumnPoint)))/255;
			Camera.main.backgroundColor=new Color(a.x,a.y,a.z,0.02f);
		}

		if(Back==true){
			float d = Dis+WinterPoint;
			if(CameraPoint>=WinterPoint&&CameraPoint<SpringPoint+d){
				Vector3 a = (WinterColor+((AutumnColor-WinterColor)*(CameraPoint-WinterPoint)/(SpringPoint+d-WinterPoint)))/255;
				Camera.main.backgroundColor=new Color(a.x,a.y,a.z,0.02f);
			}
			if(CameraPoint>=SpringPoint+d&&CameraPoint<SummerPoint+d){
				Vector3 a = (AutumnColor+((SummerColor-AutumnColor)*(CameraPoint-(SpringPoint+d))/((SummerPoint+d)-(SpringPoint+d))))/255;
				Camera.main.backgroundColor=new Color(a.x,a.y,a.z,0.02f);
			}
			if(CameraPoint>=SummerPoint+d&&CameraPoint<AutumnPoint+d){
				Vector3 a = (SummerColor+((SpringColor-SummerColor)*(CameraPoint-(SummerPoint+d))/((AutumnPoint+d)-(SummerPoint+d))))/255;
				Camera.main.backgroundColor=new Color(a.x,a.y,a.z,0.02f);
			}
		}
	
	}
}
