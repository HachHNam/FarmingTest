using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    /*private float zoom;
    public float panMult = 2f;
    private float zoomMultiplier = 10f;
    private float minZoom = 7f;
    private float maxZoom = 10f;
    private float velocity = 0f;
    private float smoothTime = 0.25f;
    private CinemachineVirtualCamera virtualCam;
    public GameObject camTarget;
    public GameObject henry;


    // Start is called before the first frame update
    void Awake()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();
        zoom = virtualCam.m_Lens.OrthographicSize;
        
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        
        
        if (scroll != 0)
        {
             zoom -= scroll * zoomMultiplier;
             zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
             virtualCam.m_Lens.OrthographicSize = Mathf.SmoothDamp(virtualCam.m_Lens.OrthographicSize, zoom,ref velocity, smoothTime);
             if (scroll < 0)
             {
                 Vector3 direction = camTarget.transform.position - transform.position;
                 direction.z = -10;
                 transform.position = Vector3.Lerp(transform.position, transform.position + direction * zoom * panMult, Time.deltaTime);
             }
             if (scroll < 0)
             {
                 Vector3 direction = henry.transform.position - camTarget.transform.position;
                 direction.z = -10;
                 transform.position = Vector3.Lerp(transform.position, transform.position + direction * zoom * panMult, Time.deltaTime);
             }
             
        }
       
    }*/
}
