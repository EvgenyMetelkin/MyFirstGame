using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Camera m_MainCamera;
    public int magicCameraHeight;
    public int complexityGame;
    void Start()
    {
        m_MainCamera = GameObject.Find("Camera").GetComponent<Camera>(); 
    }
     
    void Update()
    {
        UpdatePlatformPosition();
    }

    void UpdatePlatformPosition()
    { 
        if (m_MainCamera.transform.position.y - transform.position.y > magicCameraHeight)
        {

            float xRan = Random.Range(-6, 6);
            float yRan = Random.Range(-2, -1);
            float complexityRan = Random.Range(0, 100);

            if(complexityGame < complexityRan)
                Instantiate(gameObject, new Vector2(m_MainCamera.transform.position.x + xRan, m_MainCamera.transform.position.y + magicCameraHeight + yRan), transform.rotation); 
            Destroy(gameObject);

        }
    }
}
