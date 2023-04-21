using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waspController : MonoBehaviour
{
    public GameObject target;
    public float speed = 1;

    void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player") {
            other.gameObject.GetComponent<characterController02>().takeDamage(gameObject, 1, 50);
        }
    }
    void FixedUpdate() {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
