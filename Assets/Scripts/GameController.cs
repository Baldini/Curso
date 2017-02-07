using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text recorde;

    void Start()
    {
        recorde.text = PlayerPrefs.GetInt("Recorde").ToString();
    }
    public void Jogar()
    {
        SceneManager.LoadScene("Main");
    }
}
