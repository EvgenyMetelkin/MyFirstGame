using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform playerPosition;
    Vector3 position;
    float previosY;
    public float speedCamerToPlayer;
    public float maxSpeedCamerToUp;
    float curSpeedCamerToUp;
    bool isFoalFieldOfView;
    float t;

    void Start()
    { 
        position.x = 0f;
        position.y = 0f;
        position.z = -9f;
        transform.position = position;

        previosY = 0f;
        curSpeedCamerToUp = 0f;

        isFoalFieldOfView = true;
        t = 0f;
    }
     
    void Update()
    { 
        float duration = 1.0f; // скорость приближения/отдоления
        if(isFoalFieldOfView) 
        {  
            UnityEngine.Camera.main.fieldOfView = Mathf.Lerp(114.0f, 100.0f, t / duration);
            t += Time.deltaTime;
            if (t >= duration)
            {
                isFoalFieldOfView = false;
                t = 0f;
            }
        } 
        else
        { 
            UnityEngine.Camera.main.fieldOfView = Mathf.Lerp(100.0f, 114.0f, t / duration);
            t += Time.deltaTime;
            if (t >= duration)
            {
                isFoalFieldOfView = true;
                t = 0f;
            }
        }

        if (curSpeedCamerToUp < maxSpeedCamerToUp)
            curSpeedCamerToUp += maxSpeedCamerToUp / 100f;

        position = playerPosition.position;
        position.x = 0f;
        position.z = -9f;
        if(position.y < 0) 
            position.y = 0f;
        if (position.y < previosY)
            position.y = previosY;

        position.y += curSpeedCamerToUp;
        previosY = position.y;
        transform.position = Vector3.Lerp(transform.position, position, speedCamerToPlayer * Time.deltaTime);
    }
}
