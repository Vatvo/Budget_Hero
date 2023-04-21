using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{

    public int health = 1;

    public void takeDamage(GameObject other, int damage, float knockback) {
        
        Debug.Log("HIT! " + gameObject);
        if (health >= 1) {
            health -= 1;
            takeDamageAnim();
            knockBack(other, knockback);
        } else {
            Destroy(gameObject);
        }
    }

    private void takeDamageAnim() {


    }

    public void knockBack(GameObject other, float mag) {
    
        Vector2 dist = transform.position - other.transform.position;
        dist = dist.normalized * mag;

        gameObject.GetComponent<Rigidbody2D>().AddForce(dist, ForceMode2D.Impulse);

    }
}
