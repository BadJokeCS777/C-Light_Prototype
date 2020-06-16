using UnityEngine;
using UnityEngine.SceneManagement;
public class BossFightLoader : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.transform.position = new Vector3();
            SceneManager.LoadScene("bossArena");
        }
    }
}
