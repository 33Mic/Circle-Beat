using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BeatMover : MonoBehaviour
{

    public float beatTempo = 120;

    public bool hasStarted;
    float angleConstant;


    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
        angleConstant = SelectLaunchAngle();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            
        }
        else
        {
            transform.position += LaunchBeatAtAngle(angleConstant);
            transform.rotation = BeatRotation();
        }
    }

    private float SelectLaunchAngle()
    {
        float beatStartingAngle = UnityEngine.Random.Range(0f, 360f) * Mathf.Deg2Rad; // Calculate Launch Angle
        return beatStartingAngle;
    }

    private Vector3 LaunchBeatAtAngle(float beatStartingAngle)
    {
        float radiusVelocity = beatTempo * Time.deltaTime;
        Vector3 LaunchAngle = new Vector3((float)Math.Cos(beatStartingAngle) * radiusVelocity, (float)Math.Sin(beatStartingAngle) * radiusVelocity, 0f);
        // calculate x and y pos 
        return LaunchAngle;
    }

    private Quaternion BeatRotation()
    {
        Quaternion beatRot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (angleConstant * Mathf.Rad2Deg) + 90);
        return beatRot;
    }

}
