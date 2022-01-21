 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField]
    float thrust = 1000;

    [SerializeField]
    float rotationThrust = 100;
    [SerializeField]
    AudioClip engineSound;

    [SerializeField]
    ParticleSystem engineParticles;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * thrust); //(0, 1, 0)
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(engineSound);
            }
            if(!engineParticles.isPlaying)
            {
                engineParticles.Play();
            }
        }
        else
        {
            engineParticles.Stop();
            audioSource.Stop();
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.back * Time.deltaTime * rotationThrust);
            rb.freezeRotation = false;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationThrust);
            rb.freezeRotation = false;
        }
    }
}
