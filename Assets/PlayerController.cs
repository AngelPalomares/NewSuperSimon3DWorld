using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float moveSpeed;
    [SerializeField]public float jumpforce;
    [SerializeField]public float gravityScale = 5f;

    [SerializeField]private CharacterController controller;

    [SerializeField] private Camera theCam;

    private Vector3 moveDirection;

    private void Start()
    {
        theCam = Camera.main;
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movingthecharacter();
    }

    private void Movingthecharacter()
    {
        float ystore = moveDirection.y;
        //moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
        moveDirection = moveDirection * moveSpeed;
        moveDirection.y = ystore;

        if (Input.GetButtonDown("Jump"))
            moveDirection.y = jumpforce;

        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

        controller.Move(moveDirection * Time.deltaTime);

        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") !=0)
            transform.rotation = Quaternion.Euler(0f, theCam.transform.rotation.eulerAngles.y, 0f);
    }

}
