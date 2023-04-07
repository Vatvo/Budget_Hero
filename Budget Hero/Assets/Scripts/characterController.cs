using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

    public static int health = 3;
    public static int money = 10;
    public float moveSpeed;
    public float damage;
    public GameObject headband;


    public GameObject weapon;
    public Animator animator;
    private Vector2 moveDir;
   
    void Update()
    {
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal",  moveDir.x);
        animator.SetFloat("Vertical", moveDir.y);
        animator.SetFloat("Speed", moveDir.magnitude);

        if (moveDir.y == -1 || moveDir.magnitude == 0) {
            headband.transform.localScale = new Vector3(1f,1f,1f);
        } else if (moveDir.y == 1) {
            headband.transform.localScale = new Vector3(-1f,1f,1f);
        } else if (moveDir.x == 1) {
            headband.transform.localScale = new Vector3(1f,1f,1f);
        } else if (moveDir.x == -1) {
            headband.transform.localScale = new Vector3(-1f,1f,1f);
        } else {

            Debug.Log("Invalid Attack Direction");
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine(Attack(moveDir));
        }
    }

    private void FixedUpdate() {

        transform.Translate(new Vector3(moveSpeed * moveDir.x, moveSpeed * moveDir.y, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Hazard") {
            takeDamage();
        }
    }
    private void takeDamage() {
        health -= 1;
        Debug.Log("Health: " + health);
    }

    public void changeMoney(int inputMoney) {
        money += inputMoney;
    }

    private IEnumerator Attack(Vector2 Direction) {
        animator.SetBool("Attack", true);

        if (moveDir.y == -1 || moveDir.magnitude == 0) {
            weapon.transform.localPosition = new Vector3(0f, -1.16f, 0f);
        } else if (moveDir.y == 1) {
            weapon.transform.localPosition = new Vector3(0f, 1.22f, 0f);
        } else if (moveDir.x == 1) {
            weapon.transform.localPosition = new Vector3(1f, 0f, 0f);
        } else if (moveDir.x == -1) {
            weapon.transform.localPosition = new Vector3(-1f, 0f, 0f);
        } else {

            Debug.Log("Invalid Attack Direction");
        }

        yield return new WaitForSeconds(0.325f);
        animator.SetBool("Attack", false);

        weapon.transform.localPosition = new Vector3(0f, 0f, 0f);
    }
}
