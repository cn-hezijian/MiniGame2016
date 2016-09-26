 using UnityEngine;
using System.Collections;

public class Push : MonoBehaviour {

	public float pushPower = 2.0F;
	void Start(){
	}
	void Update(){
	}
	void OnControllerColliderHit(ControllerColliderHit hit) {
		if(hit.gameObject.tag!="box")
			return;
		//hit.transform.parent=null;
		//hit.transform.localScale=new Vector3(2,2,2);
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;
		
		if (hit.moveDirection.y < -0.3F)
			return;
		
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, 0);
		body.velocity = pushDir * pushPower;

	}


}
