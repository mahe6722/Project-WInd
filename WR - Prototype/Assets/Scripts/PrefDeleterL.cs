using UnityEngine.SceneManagement;
using UnityEngine;

public class PrefDeleterL : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && SceneManager.GetActiveScene().name == "GameScene") {
            PlayerPrefs.DeleteAll();
        }
    }
}