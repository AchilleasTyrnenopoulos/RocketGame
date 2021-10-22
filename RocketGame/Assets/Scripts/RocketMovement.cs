using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public static RocketMovement instance;

    //public event Action onThrustStart;

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float thrustSpeed;
    [SerializeField]
    private AudioSource thrustAudioSrc;

    [SerializeField]
    private float rotationSpeed;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        thrustAudioSrc = GetComponent<AudioSource>();

        //add event listeners
        //onThrustStart += Thrust;
        GameManager.instance.onExplosion += StopThrust;
    }

    private void OnDisable()
    {
        //onThrustStart -= Thrust;
        GameManager.instance.onExplosion -= StopThrust;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void OnThrustStart()
    //{
    //    onThrustStart?.Invoke();
    //}

    public void Thrust()
    {        
        rb.AddRelativeForce(Vector3.up * thrustSpeed * Time.deltaTime);

        if(!thrustAudioSrc.isPlaying)
            thrustAudioSrc.Play();
    }

    public void StopThrust()
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
