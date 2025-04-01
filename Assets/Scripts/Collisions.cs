using UnityEngine;
using UnityEngine.UI;

public class Collisions : MonoBehaviour
{
    [SerializeField] protected float _speed, _acelleration;
    [SerializeField] protected GameObject _panel;
    [SerializeField] protected Text _counter;

    public static int Score;

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Obstacle") return;

        _panel.SetActive(true);
        _counter.text = "Your distance: " + ((int)(Score + _speed * Time.time + _acelleration *  Time.timeSinceLevelLoad * Time.time)).ToString();

        Time.timeScale = 0;
    }
}
