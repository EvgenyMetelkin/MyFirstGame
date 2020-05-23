using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    Camera m_MainCamera;
    public int magicCameraHeight; 
    void Start()
    {
        m_MainCamera = GameObject.Find("Camera").GetComponent<Camera>();
    }
     
    void Update()
    {
        UpdateWallPosition(); 
    }

    void UpdateWallPosition()
    {
        if (m_MainCamera.transform.position.y - transform.position.y > magicCameraHeight)
        {
            Instantiate(gameObject, new Vector2(transform.position.x, m_MainCamera.transform.position.y), transform.rotation);
            Destroy(gameObject);
        }
    }
}
