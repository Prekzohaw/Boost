using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float upThrust = 1f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip engine;
    [SerializeField] ParticleSystem mainThruster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;
    
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
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }

    private void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * upThrust);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(engine);
        }
        if (!mainThruster.isPlaying)
        {
            mainThruster.Play();
        }
    }

    private void StopThrusting()
    {
        audioSource.Stop();
        mainThruster.Stop();
    }

    private void RotateLeft()
    {
        RotatingThrust(rotationThrust);
        if (!rightBooster.isPlaying)
        {
            rightBooster.Play();
        }
    }

    private void RotateRight()
    {
        RotatingThrust(-rotationThrust);
        if (leftBooster.isPlaying)
        {
            leftBooster.Play();
        }
    }

    private void StopRotating()
    {
        rightBooster.Stop();
        leftBooster.Stop();
    }

    void RotatingThrust(float rotationPower)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationPower);
        rb.freezeRotation = false;
    }
}
