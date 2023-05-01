using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneTransition : MonoBehaviour
{

    public void transition(int index) {
        SceneManager.LoadScene(index);
    }
    public int sceneIndex = 0;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            transition(sceneIndex);
        }
    }
}
