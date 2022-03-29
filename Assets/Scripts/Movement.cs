using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float upThrust = 1f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip engine;
    
    Rigidbody rb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        UpwardThrust();
        ProcessRotation();
    }

    void UpwardThrust()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.up * Time.deltaTime * upThrust);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(engine);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotatingThrust(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotatingThrust(-rotationThrust);
        }
    }

    void RotatingThrust(float rotationPower)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationPower);
        rb.freezeRotation = false;
    }
}
