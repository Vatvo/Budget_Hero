using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carController : MonoBehaviour
{
    [SerializeField] int speed = 10;
    [SerializeField] int destroyTime = 10;
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
