using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NoteMove : MonoBehaviour
{
    // Define keys
    public KeyCode keyToPress1 = KeyCode.S;
    public KeyCode keyToPress2 = KeyCode.D;

    [SerializeField] GameObject sparklesVFX;

    public bool canBePressed;
    public float angleConstant;
    float beatTempo; 

    // Start is called before the first frame update
    void Start()
    {
        float bpm = GameManager.instance.bpm;
        beatTempo = bpm / 60f;
        angleConstant = SelectLaunchAngle();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += LaunchBeatAtAngle(angleConstant);
        transform.rotation = BeatRotation();
        ClickAttempt();
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

    private void ClickAttempt()
    {
        if (Input.GetKeyDown(keyToPress1) || Input.GetKeyDown(keyToPress2) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (canBePressed)
            {
                TriggerSparklesVFX();
                Destroy(gameObject);        // used to be gameObject.SetActive(false);
                GameManager.instance.NoteHit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
            //Debug.Log(Time.time); // calculating the time it takes from the start to the paddle
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
        }
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(sparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1.0f);
    }
}
