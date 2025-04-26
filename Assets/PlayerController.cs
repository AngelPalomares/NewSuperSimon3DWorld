using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private float MoveSpeed;
    [SerializeField]public float Jumpforce;
    [SerializeField]public float GravityScale = 5f;

    public CharacterController Controller;

    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movingthecharacter();
    }

    public void Movingthecharacter()
    {
        float ystore = moveDirection.y;
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        moveDirection = moveDirection * MoveSpeed;
        moveDirection.y = ystore;

        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = Jumpforce;
        }

        moveDirection.y += Physics.gravity.y * Time.deltaTime * GravityScale;

        //transform.position = transform.position + (moveDirection * Time.deltaTime * MoveSpeed);

        Controller.Move(moveDirection * Time.deltaTime);
    }

}
