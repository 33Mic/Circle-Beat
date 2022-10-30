using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruelAngelsThesis : MonoBehaviour
{

    [SerializeField] GameObject BeatObject;
    public bool hasStarted;

    public double[] spawnTime = { 2.559977, 3.98932, 5.354649, 6.86932, 8.447982, 9.898663, 11.392, 12.90664, 16.23465, 17.19465, 18.09066, 19.05066, 20.01066, 20.92798, 21.84533, 22.31465, 22.74132, 23.14664, 25.53599, 27.45599, 28.37331, 29.33331, 30.20798, 31.14664, 33.08798, 34.90131, 36.75732, 37.46132, 37.69599, 38.65599, 40.49066, 42.34665, 43.30664, 44.22399, 46.10131, 46.99733, 47.97866, 49.81331, 50.752, 51.71199, 53.54664, 54.44265, 55.40265, 56.36265, 57.25866, 58.21866, 59.17866, 60.07465, 60.992, 61.93066, 62.91199, 63.78664, 64.70399, 65.64265, 66.55997, 68.94932, 70.74132, 71.74399, 72.68266, 73.57866, 74.51733, 75.47733, 76.39465, 77.29066, 78.272, 79.18932, 80.12798, 81.08798, 82.00533, 82.92265, 83.86131, 84.79998, 85.73866, 86.65598, 87.61599, 88.49065, 89.45066, 90.30399 };

    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            if (GameObject.Find("CruelAngelsThesis").GetComponent<AudioSource>().time >= spawnTime[i] - 1.3)
            {
                
                i += 1;
                //Debug.Log("Spawned!");
                Instantiate(BeatObject);
                
            }
            
        }

    }
};
