using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrustBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;   
    
    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            RocketMovement.instance.Thrusting();
        }        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        RocketMovement.instance.OnThrustStart();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        RocketMovement.instance.StopThrusting();
    }

}
