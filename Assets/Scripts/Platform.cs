using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Transform cameraTransform;
    public int magicCameraHeight;
    public int complexityGame;
    void Start()
    {
        cameraTransform = GameObject.Find("Camera").GetComponent<Camera>().transform; 
    }
     
    void Update()
    {
        UpdatePlatformPosition();
    }

    void UpdatePlatformPosition()
    { 
        if (cameraTransform.position.y - transform.position.y > magicCameraHeight)
        {
            // ! можно переделать просто на смену позиции)
            float xRan = Random.Range(-6, 6);
            float yRan = Random.Range(-2, -1);
            float complexityRan = Random.Range(0, 100);

            if(complexityGame < complexityRan)
                Instantiate(gameObject, new Vector2(cameraTransform.position.x + xRan, cameraTransform.position.y + magicCameraHeight + yRan), transform.rotation); 
            Destroy(gameObject);

        }
    }
}
