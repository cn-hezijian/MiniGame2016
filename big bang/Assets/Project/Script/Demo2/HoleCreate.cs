using UnityEngine;
using System.Collections;

public class HoleCreate : MonoBehaviour {
	private int holenum = 0;    //表示目前要创造的洞的序号
	public GameObject Hole1;
	public GameObject Hole2;
	private float nextTime;  
	private float rate=0.5f;     //两次生成黑洞最短时间间隔
	public float HoleDis = 1;    //生成的虫洞离主角的距离
    private float pressCancleTime = 1.0f; // 按住多长取消
    private float pressBeginTime;
    private PlayerCtrl playerCtrl;
    private float JoyInputX;
    private float JoyInputY;
	// Use this for initialization
	void Start () 
    {
        playerCtrl = GetComponent<PlayerCtrl>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        #region 在移动端不需要
#if UNITY_EDITOR || UNITY_STANDALONE
        if (holenum == 0)
        {
            if (Input.GetAxis("RY") > 0 && Time.time >= nextTime)
            {
                nextTime = Time.time + rate;
                Destroy(GameObject.FindGameObjectWithTag("hole1"));
                Instantiate(Hole1, new Vector3(transform.position.x, transform.position.y + HoleDis, transform.position.z), Quaternion.identity);
                holenum = 1;
            }
            if (Input.GetAxis("RY") < 0 && Time.time >= nextTime)
            {
                nextTime = Time.time + rate;
                Destroy(GameObject.FindGameObjectWithTag("hole1"));
                Instantiate(Hole1, new Vector3(transform.position.x, transform.position.y - HoleDis, transform.position.z), Quaternion.identity);
                holenum = 1;
            }
            if (Input.GetAxis("RX") < 0 && Time.time >= nextTime)
            {
                nextTime = Time.time + rate;
                Destroy(GameObject.FindGameObjectWithTag("hole1"));
                Instantiate(Hole1, new Vector3(transform.position.x - HoleDis, transform.position.y, transform.position.z), Quaternion.identity);
                holenum = 1;
            }
            if (Input.GetAxis("RX") > 0 && Time.time >= nextTime)
            {
                nextTime = Time.time + rate;
                Destroy(GameObject.FindGameObjectWithTag("hole1"));
                Instantiate(Hole1, new Vector3(transform.position.x + HoleDis, transform.position.y, transform.position.z), Quaternion.identity);
                holenum = 1;
            }
        }

        if (holenum == 1)
        {
            if (Input.GetAxis("RY") > 0 && Time.time >= nextTime)
            {
                nextTime = Time.time + rate;
                Destroy(GameObject.FindGameObjectWithTag("hole2"));
                Instantiate(Hole2, new Vector3(transform.position.x, transform.position.y + HoleDis, transform.position.z), Quaternion.identity);
                holenum = 0;
            }
            if (Input.GetAxis("RY") < 0 && Time.time >= nextTime)
            {
                nextTime = Time.time + rate;
                Destroy(GameObject.FindGameObjectWithTag("hole2"));
                Instantiate(Hole2, new Vector3(transform.position.x, transform.position.y - HoleDis, transform.position.z), Quaternion.identity);
                holenum = 0;
            }
            if (Input.GetAxis("RX") < 0 && Time.time >= nextTime)
            {
                nextTime = Time.time + rate;
                Destroy(GameObject.FindGameObjectWithTag("hole2"));
                Instantiate(Hole2, new Vector3(transform.position.x - HoleDis, transform.position.y, transform.position.z), Quaternion.identity);
                holenum = 0;
            }
            if (Input.GetAxis("RX") > 0 && Time.time >= nextTime)
            {
                nextTime = Time.time + rate;
                Destroy(GameObject.FindGameObjectWithTag("hole2"));
                Instantiate(Hole2, new Vector3(transform.position.x + HoleDis, transform.position.y, transform.position.z), Quaternion.identity);
                holenum = 0;
            }
        }
#endif
        #endregion
    }
	
	public void JoyStick_OnMove(Vector2 move)
    {
        JoyInputX = move.x;
        JoyInputY = move.y;
    }

    public void JoyStick_OnTouchUp()
    {
        JoyInputX = 0;
        JoyInputY = 0;
    }

    public void ActionButton_Down()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        if(Input.GetAxis("Vertical") != 0)
        {
            JoyInputY = Input.GetAxis("Vertical");
        }
#endif
        pressBeginTime = Time.time;

        if (holenum == 0)
        {
            // 上
            if ((JoyInputY >0 && Mathf.Abs(JoyInputY - 1) < 0.1f)
                && Time.time >= nextTime)
            {
                nextTime = Time.time + rate;
                Destroy(GameObject.FindGameObjectWithTag("hole1"));
                Instantiate(Hole1, new Vector3(transform.position.x, transform.position.y + HoleDis, transform.position.z), Quaternion.identity);
                holenum = 1;
                JoyInputY = 0;
                return;
            }
            // 下
            if ((JoyInputY < 0 && Mathf.Abs(JoyInputY - 1) < 0.1f)
                && Time.time >= nextTime)
            {
                nextTime = Time.time + rate;
                Destroy(GameObject.FindGameObjectWithTag("hole1"));
                Instantiate(Hole1, new Vector3(transform.position.x, transform.position.y - HoleDis, transform.position.z), Quaternion.identity);
                holenum = 1;
                JoyInputY = 0;
                return;
            }
            // 根据朝向决定左右
            if (Time.time >= nextTime)
            {
                float HoleDistance = HoleDis;
                if(playerCtrl != null)
                {
                    if(!playerCtrl.bFacingRight)
                    {
                        HoleDistance = -HoleDis;
                    }
                }
                nextTime = Time.time + rate;
                Destroy(GameObject.FindGameObjectWithTag("hole1"));
                Instantiate(Hole1, new Vector3(transform.position.x + HoleDistance, transform.position.y, transform.position.z), Quaternion.identity);
                holenum = 1;
            }
        }

        if (holenum == 1)
        {
            // 上
            if ((JoyInputY > 0 && Mathf.Abs(JoyInputY - 1) < 0.1f)
                && Time.time >= nextTime)
            {
                nextTime = Time.time + rate;
                Destroy(GameObject.FindGameObjectWithTag("hole2"));
                Instantiate(Hole2, new Vector3(transform.position.x, transform.position.y + HoleDis, transform.position.z), Quaternion.identity);
                holenum = 0;
                JoyInputY = 0;
                return;
            }
            // 下
            if ((JoyInputY < 0 && Mathf.Abs(JoyInputY - 1) < 0.1f)
                && Time.time >= nextTime)
            {
                nextTime = Time.time + rate;
                Destroy(GameObject.FindGameObjectWithTag("hole2"));
                Instantiate(Hole2, new Vector3(transform.position.x, transform.position.y - HoleDis, transform.position.z), Quaternion.identity);
                holenum = 0;
                JoyInputY = 0;
                return;
            }

            if (Time.time >= nextTime)
            {
                float HoleDistance = HoleDis;
                if (playerCtrl != null)
                {
                    if (!playerCtrl.bFacingRight)
                    {
                        HoleDistance = -HoleDis;
                    }
                }
                nextTime = Time.time + rate;
                Destroy(GameObject.FindGameObjectWithTag("hole2"));
                Instantiate(Hole2, new Vector3(transform.position.x + HoleDistance, transform.position.y, transform.position.z), Quaternion.identity);
                holenum = 0;
            }
        }
		
    }

    //public void ActionButton_PressForSeconds()
    //{
    //    if (Time.time > pressBeginTime + pressCancleTime)
    //    {
    //        GameObject hole2 = GameObject.FindGameObjectWithTag("hole2");
    //        if(hole2 != null)
    //        {
    //            Destroy(hole2);
    //            holenum = 0;
    //        }
    //        GameObject hole1 = GameObject.FindGameObjectWithTag("hole1");
    //        if (hole1 != null)
    //        {
    //            Destroy(hole1);
    //            holenum = 1;
    //        }
    //    }
    //}
}
