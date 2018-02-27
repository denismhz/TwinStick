using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidBody;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.recording)
        {
           Record();
        } else
        {
            PlayBack();
        }
       
	}

    void PlayBack()
    {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        Debug.Log("Reading frame: " + frame);
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    void Record()
    {
        rigidBody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        Debug.Log("Writing frame: " + frame);

        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

public struct MyKeyFrame
{
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float aTime, Vector3 pos, Quaternion rot)
    {
        frameTime = aTime;
        position = pos;
        rotation = rot;
    }
}
