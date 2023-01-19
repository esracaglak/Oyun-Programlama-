using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;
    [SerializeField] bool isWalking;
    public float speed;
    public float turnSmoothTime ;
    float turnSmoothVelocity;
    public Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; 

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x,direction.z)* Mathf.Rad2Deg +cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, angle, 0f)*Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
            isWalking = true;
            animator.SetBool("IsWalking", isWalking);
        }
        else
        {
            isWalking = false;
            animator.SetBool("IsWalking", isWalking);
        }

        gameObject.transform.position = new Vector3(transform.position.x,0,transform.position.z);






    }
}
