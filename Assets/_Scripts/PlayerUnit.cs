//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

using UnityEngine;
using DG.Tweening;
namespace MeteTurkay
{
    public class PlayerUnit : MonoBehaviour
    {
        [SerializeField] Animator animator;
        Transform start;
        [SerializeField] float oneSquareLenght = 1f;
        [SerializeField] float animationTime = 1f;
        public bool canAct = false;
        private void Start()
        {
            start = transform;
        }
        public void Jump()
        {
            canAct = false;
            print("jump");
            transform.DOLocalJump(new Vector3(transform.localPosition.x, oneSquareLenght, transform.localPosition.z), 3f, 1, animationTime).OnComplete(() => {
                canAct = true;
            });
        }
        public void MoveFoward(Direction side)
        {
            canAct = false;
            print("move"+transform.forward);
            //scary
            transform.DOLocalMove(new Vector3((transform.forward * oneSquareLenght).x + transform.localPosition.x,transform.localPosition.y, (transform.forward * oneSquareLenght).z + transform.localPosition.z), animationTime).OnComplete(() => {
                canAct = true;
            });
        }
        public void PressAction()
        {
            canAct = false;
            print("press");
            canAct = true;
        }
        public void TurnAction(Direction side)
        {
            canAct = false;
            print("turn" + side.ToString()) ;
            int way = side == Direction.Right ? 1 : -1;
            float rotation = transform.localEulerAngles.y;
            transform.DORotate(new Vector3(0,rotation+(90*way),0), animationTime).OnComplete(()=> {
                canAct = true;
            });
        }
        public void ResetPlayer()
        {
            transform.DOKill();
            transform.DOJump(start.position,1,1,2f).OnComplete(() => {
                canAct = true;
            });
        }
    }
}
