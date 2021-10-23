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
            
            //THRUSTING
            bool thrustInput = Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space);
            if (thrustInput)
                RocketMovement.instance.Thrusting();
            else if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
                RocketMovement.instance.StopThrusting();

            //ROTATION
            //rotate object only when velocity isnt zero
            if (RocketMovement.instance.GetRbVelocity() > 1f)
            {
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

#if DEBUG
        #region Inputs for development / testing
        //DEBUG / DEVELOPMENT 'CHEATS'
        if (Input.GetKeyDown(KeyCode.N))
        {
            GameManager.instance.LoadNextScene(0);
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            GameObject rocket = GameObject.FindGameObjectWithTag(Tags.Rocket);
            Collider[] colliders = rocket.GetComponents<Collider>();
            foreach (var col in colliders)
            {
                col.enabled = !col.enabled;
            }
        }
        #endregion
#endif
    }
}
