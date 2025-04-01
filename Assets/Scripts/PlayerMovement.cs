using System.Collections;
using System.Collections.Generic;
using TechJuego.InputControl;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected float _moveTime, _jumpForce, _timeOfJump;
    [SerializeField] protected AnimationCurve _jumpCurve;
    [Tooltip("0 - left, 1 - center, 2 - right")]
    [SerializeField] protected List<Transform> _points;

    protected int _currentPoint;
    protected Rigidbody _rigidbody;
    protected bool _isMoving, _isJump;

    protected virtual void Awake()
    {
        _currentPoint = 1;
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        if (_isJump)
        {
            _timeOfJump += Time.deltaTime;
            _rigidbody.AddForce(new Vector3(0, _jumpCurve.Evaluate(_timeOfJump) * _jumpForce, 0), ForceMode.VelocityChange);
        }
    }

    protected virtual void OnCollisionEnter() => _isJump = false;

    private void OnEnable()
    {
        SwipeController.OnSwipeLeft += SwipeController_OnSwipeLeft;
        SwipeController.OnSwipeRight += SwipeController_OnSwipeRight;
        SwipeController.OnSwipeUp += SwipeController_OnSwipeUp;
    }

    private void OnDisable()
    {
        SwipeController.OnSwipeLeft -= SwipeController_OnSwipeLeft;
        SwipeController.OnSwipeRight -= SwipeController_OnSwipeRight;
        SwipeController.OnSwipeUp -= SwipeController_OnSwipeUp;
    }

    protected virtual void SwipeController_OnSwipeRight()
    {
        Vector3 newPos;
        if (_currentPoint < 2)
            newPos = _points[_currentPoint + 1].position;
        else
            return;
        _currentPoint += 1;

        StartCoroutine(MoveOverSeconds(gameObject, newPos, _moveTime));
    }

    protected virtual void SwipeController_OnSwipeLeft()
    {
        Vector3 newPos;
        if (_currentPoint > 0)
            newPos = _points[_currentPoint - 1].position;
        else
            return;
        _currentPoint -= 1;

        StartCoroutine(MoveOverSeconds(gameObject, newPos, _moveTime));
    }

    protected virtual void SwipeController_OnSwipeUp()
    {
        if (_isJump) return;

        _timeOfJump = 0;
        _isJump = true;
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        _isMoving = true;
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
        _isMoving = false;
    }
}