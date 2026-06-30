using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float thrustStrength = 100f;
    [SerializeField] float rotationStrength = 100f;
    Rigidbody rb;
    
    private void OnEnable() 
    {
        thrust.Enable();
        rotation.Enable();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        thrustProgress();
        thrustRotation();
    }

    void thrustProgress()
    {
        if (thrust.IsPressed())
        {
             rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
        }
    }
    void thrustRotation()
    {
         float rotationInput = rotation.ReadValue<float>();
         if(rotationInput < 0)
         {
            transform.Rotate(Vector3.forward * rotationStrength * Time.fixedDeltaTime);
         }
         if(rotationInput > 0)
         {
            transform.Rotate(Vector3.back * rotationStrength * Time.fixedDeltaTime);
         }
    }
}
