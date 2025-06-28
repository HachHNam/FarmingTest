using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour
{

    [SerializeField] private Camera mainCam;
    private Vector3 lastPosition;
    public LayerMask farmLayer;

    public event Action OnClicked, OnExit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClicked?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnExit?.Invoke();
        }
    }
    
    public bool IsPointerOverUI()
        => EventSystem.current.IsPointerOverGameObject();
    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        RaycastHit2D hit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(mousePos), Vector2.zero,Mathf.Infinity, farmLayer);
        if (hit)
        {
            lastPosition = hit.point;
        }
        else{
            lastPosition = new Vector3(-100,0,0);
        }
        return lastPosition;
    }
}
