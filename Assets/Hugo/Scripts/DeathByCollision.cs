using UnityEngine;
using System.Collections;

public class DeathByCollision : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Bullet(Clone)" || col.gameObject.name == "Character")
            Destroy(col.gameObject);
    }

}
