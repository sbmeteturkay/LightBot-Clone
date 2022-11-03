using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
/// <summary>
/// A static class for general helpful methods
/// </summary>
public static class Helpers
{
    /// <summary>
    /// Destroy all child objects of this transform (Unintentionally evil sounding).
    /// Use it like so:
    /// <code>
    /// transform.DestroyChildren();
    /// </code>
    /// </summary>
    public static void DestroyChildren(this Transform t)
    {
        foreach (Transform child in t) Object.Destroy(child.gameObject);
    }
    public static void Wait(this MonoBehaviour mono, float delay, UnityAction action)
    {
        mono.StartCoroutine(ExecuteAction(delay, action));
    }
    private static IEnumerator ExecuteAction(float delay, UnityAction action)
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
        yield break;
    }
    public static bool IsPointerOverUIObject()
    {
        // Referencing this code for GraphicRaycaster https://gist.github.com/stramit/ead7ca1f432f3c0f181f
        // the ray cast appears to require only eventData.position.
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    public static void StartCountdown(this MonoBehaviour mono,float countTime, TMPro.TMP_Text _timeText)
    {
        mono.StartCoroutine(CountdownTime(countTime, _timeText));
    }
    public static IEnumerator CountdownTime(float _currentTime, TMPro.TMP_Text _timeText)
    {
        while (_currentTime >= 0)
        {
            //_time.fillAmount = Mathf.InverseLerp(0, _duration, _currentTime);
            _timeText.text = _currentTime.ToString("0.00");
            yield return new WaitForSeconds(0.1f);
            _currentTime-=0.1f;
        }
        yield return null;
    }
}
