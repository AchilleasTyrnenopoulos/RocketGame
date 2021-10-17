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
        //if(Input.GetKeyDown(KeyCode.Space))
        //    OnThrustStart
        //if (Input.GetKey(KeyCode.Space))
        if(Input.GetMouseButton(0))
            RocketMovement.instance.Thrust();

        //rotation
        if (Input.GetKey(KeyCode.A) )
        {
            RocketMovement.instance.Rotate(1);
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            RocketMovement.instance.Rotate(-1);
        }
    }
}
