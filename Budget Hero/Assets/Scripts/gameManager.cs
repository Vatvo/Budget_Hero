using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{

    GameObject scoreText;

    public int money = 0;

    void Awake() {

        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameManager");
        if (musicObj.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Update() {

        scoreText = GameObject.FindGameObjectWithTag("ScoreText");

        scoreText.GetComponent<TextMeshProUGUI>().text = "$" + money;
    }

    public void updateScore(int scoreMod) {
        money += scoreMod;
        Debug.Log(money);
    }
}
