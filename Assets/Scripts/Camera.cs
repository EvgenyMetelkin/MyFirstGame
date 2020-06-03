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
    float deltaTimeScale;
    float deltaTimeSpeedCamera;

    void Start()
    { 
        position.x = 0f;
        position.y = 0f;
        position.z = -9f;
        transform.position = position;

        previosY = 0f;
        curSpeedCamerToUp = 0f;

        isFoalFieldOfView = true;
        deltaTimeScale = 0f;
        deltaTimeSpeedCamera = 0f;
    }
     
    void Update()
    {
        deltaTimeScale += Time.deltaTime;
        deltaTimeSpeedCamera += Time.deltaTime;

        //ChangeScale();
        MoveCamera();
    }

    void ChangeScale()
    {
        float duration = 1.0f; // времянной промяжуток (1с) увеличения приближения/отдоления
        if (isFoalFieldOfView)
        {
            UnityEngine.Camera.main.fieldOfView = Mathf.Lerp(114.0f, 100.0f, deltaTimeScale / duration);
            if (deltaTimeScale >= duration)
            {
                isFoalFieldOfView = false;
                deltaTimeScale = 0f;
            }
        }
        else
        {
            UnityEngine.Camera.main.fieldOfView = Mathf.Lerp(100.0f, 114.0f, deltaTimeScale / duration); 
            if (deltaTimeScale >= duration)
            {
                isFoalFieldOfView = true;
                deltaTimeScale = 0f;
            }
        }
    }

    void MoveCamera()
    {
        float duration = 10.0f; // времянной промяжуток (100с) увеличения скорости камеры вверх
        curSpeedCamerToUp = Mathf.Lerp(0, maxSpeedCamerToUp, deltaTimeSpeedCamera / duration); 

        position = playerPosition.position;
        position.x = 0f;
        position.z = -9f;
        if (position.y < 0)
            position.y = 0f;
        if (position.y < previosY)
            position.y = previosY;

        position.y += curSpeedCamerToUp;
        previosY = position.y;
        transform.position = Vector3.Lerp(transform.position, position, speedCamerToPlayer * Time.deltaTime);
    }
}
