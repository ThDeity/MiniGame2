using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace TechJuego
{
	public class SwipeAction : MonoBehaviour
	{
		public Text m_Text;
		private void OnEnable()
		{
			StartCoroutine(DestroyOverTime(0, 1));
			StartCoroutine(MoveOverSeconds(GetComponent<RectTransform>(), new Vector3(0, 300, 0), 1));
		}
		public IEnumerator DestroyOverTime(float endValue, float seconds)
		{
			float elapsedTime = 0;
			float startingVal = m_Text.color.a;
			while (elapsedTime < seconds)
			{
				float value = Mathf.Lerp(startingVal, endValue, (elapsedTime / seconds));
				m_Text.color = new Color(m_Text.color.r, m_Text.color.g, m_Text.color.b, value);
				elapsedTime += Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
			m_Text.color = new Color(m_Text.color.r, m_Text.color.g, m_Text.color.b, endValue);
		}
		public IEnumerator MoveOverSeconds(RectTransform objectToMove, Vector3 end, float seconds)
		{
			float elapsedTime = 0;
			while (elapsedTime < seconds)
			{
				objectToMove.anchoredPosition = Vector3.Lerp(Vector3.zero, end, (elapsedTime / seconds));
				elapsedTime += Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
			objectToMove.anchoredPosition = end;
			Destroy(this.gameObject);
		}
	}
}