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
    
    //CACHE
    public static RocketMovement instance;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private AudioSource thrustAudioSrc;

    //public event Action onThrustStart;

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

        //add event listeners
        //onThrustStart += Thrust;
        GameManager.instance.onExplosion += StopThrusting;
    }

    private void OnDisable()
    {
        //onThrustStart -= Thrust;
        GameManager.instance.onExplosion -= StopThrusting;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void OnThrustStart()
    //{
    //    onThrustStart?.Invoke();
    //}

    public void Thrusting()
    {        
        //add force
        rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);

        //play audio
        if(!thrustAudioSrc.isPlaying)
            thrustAudioSrc.Play();
    }

    public void StopThrusting()
    {
        thrustAudioSrc.Stop();
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
}
