using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    [SerializeField] int speed = 10;
    [SerializeField] int destroyTime = 10;

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Player") {
            other.gameObject.GetComponent<characterController02>().knockBack(gameObject, 60);
        }

        if (other.gameObject.layer == 6) {
            other.gameObject.GetComponent<enemyController>().knockBack(gameObject, 40);
        }
    }

    void Start() {
        StartCoroutine(autoDestroy());
    }
    void FixedUpdate() {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }

    private IEnumerator autoDestroy() {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
