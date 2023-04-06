using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carSpawner : MonoBehaviour
{
    [SerializeField] GameObject carPrefab;
    void Start()
    {
        StartCoroutine(randomTimeSpawn());
    }

    public void Spawn() {
        Instantiate(carPrefab, transform.position, transform.rotation);
    }

    private IEnumerator randomTimeSpawn() {
        while (true) {

            float waitTime = Random.Range(1f, 5f);
            yield return new WaitForSeconds(waitTime);

            Spawn();
        }
    }
}
