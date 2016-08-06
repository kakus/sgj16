using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathByCollision : MonoBehaviour {

    public float ToWait = 1f;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Bullet(Clone)" /*|| col.gameObject.name == "Character"*/)
        {
            Destroy(col.gameObject);
            // Destroy(gameObject);
            GetComponent<Renderer>().enabled = false;
            //restartCurrentScene();
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0);
        restartCurrentScene();
    }
    
    public void restartCurrentScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
