using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }
}
