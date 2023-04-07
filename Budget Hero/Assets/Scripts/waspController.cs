using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waspController : MonoBehaviour
{
    public int health = 3;
    public GameObject target;
    public float speed = 1;

    void Update()
    {
        
    }

    void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Weapon") {
            health -= 1;

            if (health == 0f) {
                Destroy(gameObject);
            }
        }


    }
}
