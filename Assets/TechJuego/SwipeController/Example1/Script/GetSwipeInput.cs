using UnityEngine;
using System.Collections;
using TechJuego.InputControl;
using System;

namespace TechJuego
{ 
    public class GetSwipeInput : MonoBehaviour
    {
        public SwipeAction m_SwipeAction;
        public RectTransform m_Parent;
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
            var inst = Instantiate(m_SwipeAction, m_Parent);
            inst.m_Text.text = "Swipe Right";
        }
        private void SwipeController_OnSwipeLeft()
        {
            var inst = Instantiate(m_SwipeAction, m_Parent);
            inst.m_Text.text = "Swipe Left";
        }
        private void SwipeController_OnSwipeDown()
        {
            var inst = Instantiate(m_SwipeAction, m_Parent);
            inst.m_Text.text = "Swipe Down";
        }
        private void SwipeController_OnSwipeUp()
        {
            var inst = Instantiate(m_SwipeAction, m_Parent);
            inst.m_Text.text = "Swipe Up";
        }
    }
}