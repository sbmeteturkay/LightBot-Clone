using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MoveSeamesly : MonoBehaviour
{
    [Header("Scale")]
    [SerializeField] bool scale = false;
    [SerializeField] float duration=1;
    [SerializeField] float strenght=1;
    //[SerializeField] float randomness = 0;
    [Header("Rotate")]
    [SerializeField] bool rotate = false;
    [SerializeField] float rotateStrenght = 30;
    [Header("Move")]
    [SerializeField] bool move = false;
    public float moveStrenght = 30;
    public float moveTime = 2;
    readonly Sequence moveSequence;

    // Start is called before the first frame update
    void Start()
    {
        if(scale)
            transform.DOScale(gameObject.transform.localScale*strenght, duration).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
        if (rotate)
            transform.DORotate(new Vector3(0, 0,rotateStrenght), 3f).SetEase(Ease.Linear).SetLoops(-1,LoopType.Incremental);
        if (move)
        {
            moveSequence.Append(transform.DOLocalPath(new Vector3[2] { new Vector3(0, 1, transform.localPosition.z), new Vector3(0, -1, transform.localPosition.z) }, moveTime, PathType.Linear).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo)).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }
    }
    public void MoveChange()
    {
        moveSequence.Kill();
        if (move)
            moveSequence.Append(transform.DOLocalPath(new Vector3[2]{ new Vector3(0,1, transform.localPosition.z),new Vector3(0,-1, transform.localPosition.z) }, moveTime, PathType.Linear).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo)).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
