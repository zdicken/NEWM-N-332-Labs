using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMove : MonoBehaviour {
    public float speed = 4f;
    public Transform cam;

    private CharacterController cc;
    private float turnSmoothRatio = .1f;
    private float turnSmoothSpeed;

    void Start() {
        cc = this.GetComponent<CharacterController>();
    }

    void Update() {
        //get input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //create vector3 to apply as direction
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if(direction.magnitude >= .1f) {
            //find angles for smooth rotation
            float targAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, targAngle, 0);
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targAngle, ref turnSmoothSpeed, turnSmoothRatio);
            Vector3 moveDirection = Quaternion.Euler(0, targAngle, 0) * Vector3.forward;

            //apply direction as movement
            cc.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
    }
}
