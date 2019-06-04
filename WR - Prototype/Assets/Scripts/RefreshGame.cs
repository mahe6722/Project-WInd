using UnityEngine.SceneManagement;
using UnityEngine;

public class RefreshGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && SceneManager.GetActiveScene().name == "GameScene") {
            SceneManager.LoadScene("NewMainMenu");
        }
    }
}