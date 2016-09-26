using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MovieClip
{
    public float delayBegin;
    public float lastTime;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale = new Vector3 (1.0f, 1.0f, 1.0f);
    public string animName;
    public bool bEnd;
}

public class MovieClipEditor : MonoBehaviour
{
    public List<MovieClip> movieClips;
    public GameObject actor;
    public float triggerTimes = 1;
    
    private float movieStartTime;
    private int curClipIndex;
    private bool bBegin;
    private Collider actorCollider;
    private CharacterController actorController;

    private int calculatedClipIndex = -1;
    private Vector3 positionStep;
    private Vector3 rotationStep;
    private Vector3 scaleStep;


    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        if (actor == null)
            return;
        actorCollider = actor.GetComponent<Collider>();
        actorController = actor.GetComponent<CharacterController>();

    }
	// Update is called once per frame
	void Update ()
    {

        if (!bBegin || !actorController.isGrounded)
            return;
	    if(movieClips.Count <= 0 || curClipIndex + 1 > movieClips.Count)
            return;

        actor.GetComponent<PlayerCtrl>().bControllByMovie = true;

        MovieClip tClip = movieClips[curClipIndex];
        if(tClip.scale == Vector3.zero)
        {
            tClip.scale = actor.transform.localScale;
        }
        if(Time.time - movieStartTime > tClip.delayBegin)
        {
            if (calculatedClipIndex != curClipIndex)
            {
                InitStepPerFrame();
            }
            if(tClip.bEnd)
            {
                RecoverPlayerController();
                bBegin = false;
                return;
            }
            
            // Calc Transform Lerp
            //float lerpRate = Time.deltaTime * 1 / tClip.lastTime;
            //Transform tTranstorm = actor.transform;
            //Quaternion newRotation = Quaternion.Euler(tClip.rotation);

            //actor.transform.position = Vector3.Lerp(tTranstorm.position, tClip.position, lerpRate);
            //actor.transform.rotation = Quaternion.Lerp(tTranstorm.rotation, newRotation, lerpRate);
            //actor.transform.localScale = Vector3.Lerp(tTranstorm.localScale, tClip.scale, lerpRate);
            actor.transform.position += positionStep * Time.deltaTime;
            actor.transform.rotation = Quaternion.Euler(actor.transform.rotation.eulerAngles + rotationStep * Time.deltaTime);
            actor.transform.localScale += scaleStep * Time.deltaTime;

            if (Time.time - movieStartTime > tClip.delayBegin + tClip.lastTime)
            {
                ++curClipIndex;
                movieStartTime = Time.time;
            }
        }

	}

    void InitStepPerFrame()
    {
        MovieClip tClip = movieClips[curClipIndex];
        positionStep = (tClip.position - actor.transform.position) / tClip.lastTime;
        rotationStep = (tClip.rotation - actor.transform.rotation.eulerAngles) / tClip.lastTime;
        scaleStep = (tClip.scale - actor.transform.localScale) / tClip.lastTime;
        calculatedClipIndex = curClipIndex;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other != actorCollider)
            return;
        if (triggerTimes == 0)
            return;
        triggerTimes--;
        StopPlayerController();
        bBegin = true;
        movieStartTime = Time.time;
        curClipIndex = 0;
    }

    void StopPlayerController()
    {
        
        GameObject.FindGameObjectWithTag("JoyStickCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("JoyStick").GetComponent<ETCJoystick>().activated = false;
        foreach(var button in GameObject.FindGameObjectsWithTag("Button"))
        {
            button.GetComponent<ETCButton>().activated = false;
        }
    }

    void RecoverPlayerController()
    {
        actor.GetComponent<PlayerCtrl>().bControllByMovie = false;
        GameObject.FindGameObjectWithTag("JoyStickCanvas").GetComponent<Canvas>().enabled = true;
        GameObject.FindGameObjectWithTag("JoyStick").GetComponent<ETCJoystick>().activated = true;
        foreach (var button in GameObject.FindGameObjectsWithTag("Button"))
        {
            button.GetComponent<ETCButton>().activated = true;
        }
    }
}
