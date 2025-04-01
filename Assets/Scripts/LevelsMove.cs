using UnityEngine;

public class LevelsMove : MonoBehaviour
{
    [SerializeField] protected float _speed, _acelleration;
    protected float _currentSpeed;
    protected Vector3 _velocity;

    protected virtual void FixedUpdate()
    {
        _currentSpeed = _speed + _acelleration * Time.time;
        _velocity.z = -_currentSpeed;
        transform.Translate(_velocity * Time.fixedDeltaTime);
    }
}
