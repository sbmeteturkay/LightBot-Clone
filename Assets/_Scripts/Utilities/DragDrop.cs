//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace MeteTurkay{
    public class DragDrop : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IBeginDragHandler, IDragHandler
    {
        [SerializeField] bool clone = false;
        [SerializeField] private Canvas canvas;
        [SerializeField] Outline outline;
        private CanvasGroup canvasGroup;
        RectTransform rectTransform;
        private void Awake()
        {
           rectTransform= GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }
        public void OnBeginDrag(PointerEventData eventData)
        {

            canvasGroup.alpha = .9f;
            canvasGroup.blocksRaycasts = false;
            transform.DOScale(1.5f, 0.2f);
            outline.enabled = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.pointerCurrentRaycast.gameObject == null)
            {
                Destroy(gameObject);
            }
            //10 is limit, we can set it from somewhere in game manager, it stays for now
            else if(eventData.pointerCurrentRaycast.gameObject.tag=="CommandPut"&& eventData.pointerCurrentRaycast.gameObject.transform.childCount<10&&clone)
            {
                gameObject.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                canvasGroup.alpha = 1f;
                canvasGroup.blocksRaycasts = true;
                clone = false;
                outline.enabled = false;
                transform.DOScale(1, 0.2f);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (clone)
            {
                var obj = Instantiate(gameObject, transform.parent);
                obj.transform.SetSiblingIndex(transform.GetSiblingIndex());
                //to prevent be lower than other drag buttons
                transform.SetAsLastSibling();
            }

        }
    }
}
