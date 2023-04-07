using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

    public float moveSpeed;

    private Vector2 moveDir;
    void Start()
    {
        
    }

    void Update()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {

        transform.Translate(new Vector3(moveSpeed * moveDir.x, moveSpeed * moveDir.y, 0) * Time.deltaTime);
    }
}
