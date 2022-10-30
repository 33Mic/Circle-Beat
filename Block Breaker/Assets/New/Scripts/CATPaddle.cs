using System.Collections;
using System.Collections.Generic;
using System; // This is my own little feature!!!
using UnityEngine;

public class CATPaddle : MonoBehaviour
{
    // Paddle config parameters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float screenHeightInUnits = 12f;
    [SerializeField] float  radius = 5f;
    [SerializeField] float minX = -5f;
    [SerializeField] float maxX = 5f;
    [SerializeField] float minY = -5f;
    [SerializeField] float maxY = 5f;

    //Paddle sound params
    [SerializeField] AudioClip paddleSounds;

    // Paddle sprite parameters
    private SpriteRenderer theSR;
    [SerializeField] Sprite defaultImage;
    [SerializeField] Sprite pressedImage;

    // Paddle click controls
    public KeyCode keyToPress1 = KeyCode.S;
    public KeyCode keyToPress2 = KeyCode.D;

    // Mapping Process WITH STRINGS (COMMENT OUT WHEN NOT IN USE)
    String mapNotes = "";


    // cached references
    GameSession theGameSession;
    Ball theBall;
    GameManager theGM;
    AudioSource myAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theSR = GetComponent<SpriteRenderer>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2 (transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(CircularMovement().x, minX, maxX);
        paddlePos.y = Mathf.Clamp(CircularMovement().y, minY, maxY);

        // These 2 will set the transformations
        transform.position = paddlePos;
        transform.rotation = PaddleRotation();
        CircularMovement();

        // Paddle Pressed
        PaddleClick();

        //Debug.Log(GameObject.Find("Bad Apple").GetComponent<AudioSource>().time); // Check if it is updating
    }

    private float GetPosX()
    {
        if(theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x; // Might have to remove, since I'm not using this part anymore
        }
        else
        {
            // paddle X coords
            return (Input.mousePosition.x / Screen.width * screenWidthInUnits) - (screenWidthInUnits / 2); 
        }
    }

    private float GetPosY()
    {
        if(theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x; // Might have to remove, since I'm not using this part anymore
        }
        else
        {
            // paddle Y coords
            return (Input.mousePosition.y / Screen.height * screenHeightInUnits) - (screenHeightInUnits / 2);
        }
    }

    private float GetAngle()
    {
        return (float)Math.Atan2(GetPosY(), GetPosX()); // Calculate the angle (in radians)
    }

    private Vector2 CircularMovement()
    {
        Vector2 circularPos = new Vector2 (transform.position.x, transform.position.y);
        double angleOfCursor = GetAngle();

                                                                        /*if(angleOfCursor > 0)
                                                                        {
                                                                            if(angleOfCursor < (Math.PI / 2)) // Quadrant 1 (x, y)
                                                                            {
                                                                                circularPos.x = radius * (float)Math.Cos(angleOfCursor);
                                                                                circularPos.y = radius * (float)Math.Sin(angleOfCursor);
                                                                            }
                                                                            else if(angleOfCursor > (Math.PI / 2)) // Quadrant 2 (-x, y)
                                                                            {
                                                                                circularPos.x = radius * (float)Math.Cos(angleOfCursor); 
                        THIS WAS ALL POINTLESS                                  circularPos.y = radius * (float)Math.Sin(angleOfCursor);
                                                                            }
                                                                        }
                                                                        else if(angleOfCursor < 0)
                                                                        {
                                                                            if(angleOfCursor < -(Math.PI / 2)) // Quadrant 3 (-x, -y)
                                                                            {
                                                                                circularPos.x = radius * (float)Math.Cos(angleOfCursor);
                                                                                circularPos.y = radius * (float)Math.Sin(angleOfCursor);
                                                                            }
                                                                            else if(angleOfCursor > -(Math.PI / 2)) // Quadrant 4  (x, -y)
                                                                            {
                                                                                circularPos.x = radius * (float)Math.Cos(angleOfCursor);
                                                                                circularPos.y = radius * (float)Math.Sin(angleOfCursor);
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            Debug.Log("I'm sorry, that's not humanly possible!!");
                                                                        }*/

        circularPos.x = radius * (float)Math.Cos(angleOfCursor);
        circularPos.y = radius * (float)Math.Sin(angleOfCursor);
        return circularPos;
        

    }

    private Quaternion PaddleRotation()
    {
        Quaternion paddleRot = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (GetAngle() * Mathf.Rad2Deg) + 90);
        return paddleRot;
    }

    private void PaddleClick()
    {
        if(Input.GetKeyDown(keyToPress1) || Input.GetKeyDown(keyToPress2) || Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            theSR.sprite  = pressedImage;
            myAudioSource.PlayOneShot(paddleSounds);
            //Debug.Log(GameObject.Find("Bad Apple").GetComponent<AudioSource>().time);           //Mapping Process
            //mapNotes = mapNotes + ", " + GameObject.Find("CruelAngelsThesis").GetComponent<AudioSource>().time;  // Mapping With Strings
        }
        if(Input.GetKeyUp(keyToPress1) || Input.GetKeyUp(keyToPress2) || Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Mouse1))
        {
            theSR.sprite = defaultImage;
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(mapNotes);
        }
    }
}
