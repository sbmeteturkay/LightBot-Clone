//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

using UnityEngine;
using UnityEngine.EventSystems;
namespace MeteTurkay{
    public class DragDrop : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IBeginDragHandler, IDragHandler
    {
        [SerializeField] bool clone = false;
        [SerializeField] private Canvas canvas;
        [SerializeField] private GameObject putContainer;
        private CanvasGroup canvasGroup;
        RectTransform rectTransform;
        private void Awake()
        {
           rectTransform= GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }
        public void OnBeginDrag(PointerEventData eventData)
        {

            canvasGroup.alpha = .8f;
            canvasGroup.blocksRaycasts = false;
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
            else if(eventData.pointerCurrentRaycast.gameObject.tag=="CommandPut"&& eventData.pointerCurrentRaycast.gameObject.transform.childCount<5)
            {
                gameObject.transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                print(eventData.pointerCurrentRaycast.gameObject.name);
                canvasGroup.alpha = 1f;
                canvasGroup.blocksRaycasts = true;
                clone = false;
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
            }

        }
    }
}