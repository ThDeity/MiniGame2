using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Play(int index)
    {
        SceneManager.LoadScene(index);
        Time.timeScale = 1;
    }

    public void Pause() => Time.timeScale = Time.timeScale == 0 ? 1 : 0;
}
