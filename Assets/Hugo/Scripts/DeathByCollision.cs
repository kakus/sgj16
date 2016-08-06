using UnityEngine;
using System.Collections;

public class DeathByCollision : MonoBehaviour {

    public int health = 1;
    void OnCollisionEnter2D(Collision collision)
    {
        health--;
    }
    void Update() {
        if (health <= 0)
            Destroy(gameObject);
    }
}
