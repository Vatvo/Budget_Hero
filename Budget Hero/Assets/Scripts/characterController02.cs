using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController02 : MonoBehaviour
{

    //Public Player Stats
    public static int playerHealth = 3;
    public static int money = 100;
    public int stamina = 5;
    public float walkSpeed = 5;
    public float sprintSpeed = 7;
    public float playerKnockback = 10;

    public LayerMask enemyLayers;
    public LayerMask interactLayers;
    
    //Private Player Stats
    private Vector2 moveDir;
    private float currentSpeed;
    private int facing;

    //Attached objects
    public GameObject headband;
    public GameObject weapon;

    //Animator
    public Animator animator;

    void Start()
    {

        currentSpeed = walkSpeed;
    }
    void Update() {

        attack();
        moveAnim();
    }
    void FixedUpdate() {

        checkDir();
        checkSprint();
        move();
    }

    //Basic Movement Functions
    public void checkDir() {

        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");

        if (moveDir.y == -1) {
            facing = 1;
        } else if (moveDir.y == 1) {
            facing = 0;
        } else if (moveDir.x == 1) {
            facing = 2;
        } else if (moveDir.x == -1) {
            facing = 3;
        }
    }

    public void move() {

        transform.Translate(new Vector3(currentSpeed * moveDir.x, currentSpeed * moveDir.y, 0) * Time.deltaTime);
    }

    public void checkSprint() {

        if(Input.GetKey("p")) {
            currentSpeed = sprintSpeed;
        } else {
            currentSpeed = walkSpeed;
        }
    }

    //Animation Functions
    public void moveAnim() {

        animator.SetFloat("Speed", moveDir.magnitude);

        if(moveDir.magnitude > 0) {
        animator.SetFloat("Horizontal",  moveDir.x);
        animator.SetFloat("Vertical", moveDir.y);
        }
    }

    public void attackAnim() {
        animator.SetTrigger("Attack");
    }

    public void attack() {

        if(Input.GetKeyDown("k")) {
            attackAnim();  

            GameObject hitBox = weapon.transform.GetChild(facing).gameObject;
            Collider2D hitCollider = hitBox.GetComponent<Collider2D>();

            Collider2D[] otherColliders = new Collider2D[3];

            ContactFilter2D enemyFilter = new ContactFilter2D();
            enemyFilter.SetLayerMask(enemyLayers);
            int num = hitCollider.OverlapCollider(enemyFilter, otherColliders);
            
            for(int i = 0; i < otherColliders.Length; i++) {
                otherColliders[i].gameObject.GetComponent<enemyController>().takeDamage(gameObject, 1, playerKnockback);
            }
        }
    }

    public void interact() {
        if(Input.GetKeyDown("o")) {
            
            GameObject hitBox = weapon.transform.GetChild(facing).gameObject;
            Collider2D hitCollider = hitBox.GetComponent<Collider2D>();

            Collider2D otherCollider;

            ContactFilter2D interactFilter = new ContactFilter2D();
            interactFilter.SetLayerMask(interactLayers);
        }
    }

    void takeDamageAnim() {

    }

    public void knockBack(GameObject other, float mag) {

        Vector2 dist = transform.position - other.transform.position;
        dist = dist.normalized * mag;

        gameObject.GetComponent<Rigidbody2D>().AddForce(dist, ForceMode2D.Impulse);
    }

    public void takeDamage(GameObject other, int damage, float knockback) {

        playerHealth -= damage;
        takeDamageAnim();
        knockBack(other, knockback);
    }
}