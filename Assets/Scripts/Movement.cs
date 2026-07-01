using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 100f;
    [SerializeField] float rotationStrength = 100f;
    Rigidbody rb;
    AudioSource audioSource;
    
    private void OnEnable() 
    {
        thrust.Enable();
        rotation.Enable();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        thrustProgress();
        thrustRotation();
        Debug.Log("Rot: " + rotation);
    }

    void thrustProgress()
    {
        if (thrust.IsPressed())
        {
             rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
             if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
        
    }
    void thrustRotation()
    {
         float rotationInput = rotation.ReadValue<float>();
         if(rotationInput < 0)
        {
            ApplyRotation(rotationStrength);
        }
        else if(rotationInput > 0)
         {
            ApplyRotation(-rotationStrength);
         }
    }

    private void ApplyRotation(float rotationFlag)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationFlag * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }

}
