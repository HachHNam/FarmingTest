using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    [SerializeField] private Camera mainCam;
    private Vector3 lastPosition;
    public LayerMask farmLayer;
    
    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        RaycastHit2D hit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(mousePos), Vector2.zero,Mathf.Infinity, farmLayer);
        if (hit)
        {
            lastPosition = hit.point;
        }
        else{
            lastPosition = Vector3.zero;
        }
        return lastPosition;
    }
}
