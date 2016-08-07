using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {

    System.Random rnd = new System.Random();
    int SpawnChooser;
    public int NumberOfBottles = 20;
    public float speed = -350;
    public GameObject enemy;
    public Rigidbody2D Bullet;
    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    public Transform SpawnPoint3;
    // Use this for initialization
    public void Start()
    {
        InvokeRepeating("Spawn", 3, 1.3f);
    }

    void Spawn()
    {
        NumberOfBottles--;
        SpawnChooser = rnd.Next(1, 4);
        Rigidbody2D BulletInstance;
        switch (SpawnChooser)
        {
            case 1:
                BulletInstance = Instantiate(Bullet, SpawnPoint1.position, SpawnPoint1.rotation) as Rigidbody2D;
                BulletInstance.AddForce(new Vector2(speed, 0));
                break;
            case 2:
                BulletInstance = Instantiate(Bullet, SpawnPoint2.position, SpawnPoint2.rotation) as Rigidbody2D;
                BulletInstance.AddForce(new Vector2(speed, 0));
                break;
            case 3:
                BulletInstance = Instantiate(Bullet, SpawnPoint3.position, SpawnPoint3.rotation) as Rigidbody2D;
                BulletInstance.AddForce(new Vector2(speed, 0));
                break;
        }
        if (NumberOfBottles <= 0)
        {
            CancelInvoke("Spawn");
            StartCoroutine(NextLevel());
        }
    }
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(2);
    }
}
