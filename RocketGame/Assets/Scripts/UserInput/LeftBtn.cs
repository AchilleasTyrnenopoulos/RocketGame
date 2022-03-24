using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (isPressed && RocketMovement.instance.GetRbVelocity() > 1f)
            RocketMovement.instance.Rotate(1);
    }
}
