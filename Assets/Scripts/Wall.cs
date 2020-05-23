using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    Transform cameraTransform;
    public int magicCameraHeight; 
    void Start()
    {
        cameraTransform = GameObject.Find("Camera").GetComponent<Camera>().transform;
    }
     
    void Update()
    {
        UpdateWallPosition(); 
    }

    void UpdateWallPosition()
    {
        if (cameraTransform.position.y - transform.position.y > magicCameraHeight)
        {
            // ! можно переделать просто на смену позиции)
            Instantiate(gameObject, new Vector2(transform.position.x, cameraTransform.position.y), transform.rotation);
            Destroy(gameObject);
        }
    }
}
