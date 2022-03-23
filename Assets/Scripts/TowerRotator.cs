using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerRotator : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform rotationPoint;


    public void OnBeginDrag(PointerEventData eventData)
    {
       
    }
    public void OnDrag(PointerEventData eventData)
    {
        float x = Input.GetAxis("Mouse X");
        if(eventData.delta.x > 0.1f || eventData.delta.x < 0.1f)
        {
            rotationPoint.RotateAround(rotationPoint.position, new Vector3(0, 1, 0) * Time.deltaTime * -x, (0.3f * Mathf.Abs(eventData.delta.x)) * rotateSpeed);
        }
        
    }
}
