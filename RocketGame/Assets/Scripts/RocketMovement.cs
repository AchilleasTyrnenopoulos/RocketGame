using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    //PARAMETERS
    [SerializeField]
    private float thrustSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float currentFuel;
    [SerializeField]
    private float maxFuel;
    
    //CACHE
    public static RocketMovement instance;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private AudioSource thrustAudioSrc;
    [SerializeField]
    private float rbSpeed;
    [SerializeField]
    private GameObject thrustFireFX;
    [SerializeField]
    private GameObject exhaustFX;

    public event Action onThrustStart;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //cache components
        rb = GetComponentInChildren<Rigidbody>();
        thrustAudioSrc = GetComponent<AudioSource>();

        //set parameters
        currentFuel = maxFuel;

        //add event listeners
        //onThrustStart += Thrust;
        onThrustStart += StartThrusting;
        GameManager.instance.onExplosion += StopThrusting;
        GameManager.instance.onExplosion += StopExhaustFX;
        GameManager.instance.onPortalEnter += DeleteGO;        
    }

    private void OnDisable()
    {
        //onThrustStart -= Thrust;
        onThrustStart -= StartThrusting;
        GameManager.instance.onExplosion -= StopThrusting;
        GameManager.instance.onExplosion -= StopExhaustFX;
        GameManager.instance.onPortalEnter -= DeleteGO;
    }

    // Update is called once per frame
    void Update()
    {
        rbSpeed = rb.velocity.magnitude;
    }

    public void OnThrustStart()
    {
        onThrustStart?.Invoke();
    }

    public void Thrusting()
    {
        //check if the rocket has gas left
        if (currentFuel > 0)
        {
            //add force
            rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);

            //spend gas
            SpendGas();

            //play audio
            if (!thrustAudioSrc.isPlaying)
                thrustAudioSrc.Play();
        }
        else
        {
            StopThrusting();
        }
    }

    public void StartThrusting()
    {
        thrustFireFX.SetActive(true);
        exhaustFX.SetActive(true);
        Invoke("StopExhaustFX", .5f);
    }

    private void StopExhaustFX()
    {
        exhaustFX.SetActive(false);
    }

    public void StopThrusting()
    {
        thrustAudioSrc.Stop();
        thrustFireFX.SetActive(false);
        exhaustFX.SetActive(true);
        Invoke("StopExhaustFX", .5f);

    }

    public void DeleteGO()
    {
        Destroy(this.gameObject);
    }

    public void Rotate(int left)
    {
        //freeze physics system rotation
        rb.freezeRotation = true;

        //apply 'our' rotation
        this.transform.Rotate(Vector3.forward * left * rotationSpeed * Time.deltaTime);

        //unfreeze physics system rotation
        rb.freezeRotation = false;
    }

    public float GetRbVelocity()
    {
        return rb.velocity.magnitude;
    }

    private void SpendGas()
    {
        if (currentFuel > 0)
        {
            currentFuel -= Time.deltaTime;
        }
    }

    private void RegenerateGas(int amount)
    {
        if(currentFuel < maxFuel)
        {
            //add gas
            currentFuel += amount;
            //if gas has exceeded its max value, set it equal to max
            if (currentFuel > maxFuel)
                currentFuel = maxFuel;            
        }

    }
}
