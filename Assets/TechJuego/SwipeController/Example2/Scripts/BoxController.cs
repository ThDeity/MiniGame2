using System.Collections;
using System.Collections.Generic;
using TechJuego.InputControl;
using UnityEngine;
namespace TechJuego
{
    public class BoxController : MonoBehaviour
    {
        private bool isMoving;
        public float moveTime;
        private void OnEnable()
        {
            SwipeController.OnSwipeUp += SwipeController_OnSwipeUp;
            SwipeController.OnSwipeDown += SwipeController_OnSwipeDown;
            SwipeController.OnSwipeLeft += SwipeController_OnSwipeLeft;
            SwipeController.OnSwipeRight += SwipeController_OnSwipeRight;
        }
        private void OnDisable()
        {
            SwipeController.OnSwipeUp -= SwipeController_OnSwipeUp;
            SwipeController.OnSwipeDown -= SwipeController_OnSwipeDown;
            SwipeController.OnSwipeLeft -= SwipeController_OnSwipeLeft;
            SwipeController.OnSwipeRight -= SwipeController_OnSwipeRight;
        }
        private void SwipeController_OnSwipeRight()
        {
            if (isMoving)
            {
                return;
            }
            Vector3 newPos = transform.position + Vector3.right;
            StartCoroutine(MoveOverSeconds(gameObject,newPos, moveTime));
        }
        private void SwipeController_OnSwipeLeft()
        {
            if (isMoving)
            {
                return;
            }
            Vector3 newPos = transform.position + Vector3.left;
            StartCoroutine(MoveOverSeconds(gameObject, newPos, moveTime));
        }
        private void SwipeController_OnSwipeDown()
        {
            if (isMoving)
            {
                return;
            }
            Vector3 newPos = transform.position + Vector3.down;
            StartCoroutine(MoveOverSeconds(gameObject, newPos, moveTime));
        }
        private void SwipeController_OnSwipeUp()
        {
            if (isMoving)
            {
                return;
            }
            Vector3 newPos = transform.position + Vector3.up;
            StartCoroutine(MoveOverSeconds(gameObject, newPos, moveTime));
        }
        public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
        {
            isMoving = true;
            float elapsedTime = 0;
            Vector3 startingPos = objectToMove.transform.position;
            while (elapsedTime < seconds)
            {
                objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            objectToMove.transform.position = end;
            isMoving = false;
        }
    }

   
}
