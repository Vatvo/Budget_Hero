using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

    public float moveSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate() {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(moveSpeed * horizontalInput, moveSpeed * verticalInput, 0) * Time.deltaTime);
    }
}
