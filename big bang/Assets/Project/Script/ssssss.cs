using UnityEngine;
using System.Collections;

public class ssssss : MonoBehaviour {


	
	//C#调用JS脚本范例
	void Update () {
		//调用卡通渲染官方脚本，将其定义为c
		EdgeDetectEffectNormals c = (EdgeDetectEffectNormals)gameObject.GetComponent("EdgeDetectEffectNormals");
		//修改卡通渲染脚本中的一个数值
		c.edgesOnly=0.5f;
	
	}
}
