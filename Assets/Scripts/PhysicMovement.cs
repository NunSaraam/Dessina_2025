using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;                                                  //이동속도
    public float jumpForce = 5f;                                                    //점프할 힘
    
    public Rigidbody rb;                                                            //rigidbody 컴포넌트를 받아올 변수

    private bool isGrounded = false;                                                //바닥에 닿았는지 확인할 변수

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");                                  //좌우 이동
        float moveY = Input.GetAxis("Vertical");                                    //앞뒤 이동

        Vector3 moveDirection = new Vector3(moveX, 0, moveY).normalized;            //이동 방향

        //Rigidbody에 힘을 주어 이동
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);

        //점프 처리
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)                          //%% and 연산ㄷ\자가 a가 참이고 b도 참일 때 / \\ or 연산자 a 또는 b가 참일때
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


    private void OnCollisionStay(Collision collision)                               //물체가 충돌할 때 
    {
     isGrounded = true;                                                             //바닥에 닿았다고 체크
    }

    private void OnCollisionExit(Collision collision)                               //물체가 서로 떨어질 때
    {
        isGrounded = false;                                                         //바닥에 떨어졌다고 체크
    }
}
