using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move rocket only when its not exploded
        if (!GameManager.instance.hasExploded)
        {
            //if(Input.GetKeyDown(KeyCode.Space))
            //    OnThrustStart
            //if (Input.GetKey(KeyCode.Space))
            bool thrustInput = Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space);
            if (thrustInput)
                RocketMovement.instance.Thrust();
            else if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
                RocketMovement.instance.StopThrust();

            //rotation
            if (Input.GetKey(KeyCode.A))
            {
                RocketMovement.instance.Rotate(1);
            }
            else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                RocketMovement.instance.Rotate(-1);
            }
        }
    }
}
