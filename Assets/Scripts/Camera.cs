using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform playerPosition;
    Vector3 position;
    float previosY;
    public float speedCamerToPlayer;
    public float speedCamerToUp;

    // Start is called before the first frame update
    void Start()
    { 
        position.x = 0f;
        position.y = 0f;
        position.z = -10f;
        transform.position = position;

        previosY = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        position = playerPosition.position;
        position.x = 0f;
        position.z = -10f;
        if(position.y < 0) 
            position.y = 0f;
        if (position.y < previosY)
            position.y = previosY;

        position.y += speedCamerToUp;
        previosY = position.y;
        transform.position = Vector3.Lerp(transform.position, position, speedCamerToPlayer * Time.deltaTime);
    }
}
