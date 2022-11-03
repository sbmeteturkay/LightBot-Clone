//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System;

namespace MeteTurkay
{
    public class PlayerUnit : MonoBehaviour
    {
        [SerializeField] Animator animator;
        Vector3 start;
        [SerializeField] float oneSquareLenght = 1f;
        [SerializeField] float animationTime = 1f;
        [SerializeField] MoveCheck jumpCheck;
        [SerializeField] MoveCheck walkCheck;
        [SerializeField] MoveCheck jumpDownCheck;
        public bool canAct = false;
        public static event Action<GameObject> playerPush; 
        private void Start()
        {
            start = transform.position;
        }
        public void Jump()
        {
            canAct = false;
            print("jump");
            animator.SetTrigger("jump");
            AudioManager.Play(AudioClipName.Jump);
            if (jumpCheck.canDo)
            {
                transform.DOLocalJump(new Vector3((transform.forward * oneSquareLenght).x + transform.localPosition.x, transform.localPosition.y + 1, (transform.forward * oneSquareLenght).z + transform.localPosition.z), 3f, 1, animationTime).OnComplete(() => {
                    canAct = true;
                });
            }
            else
            {
                //jump without move
                transform.DOLocalJump(transform.localPosition, 3f, 1, animationTime).OnComplete(() => {
                    canAct = true;
                });
            }
            
        }
        public void MoveFoward(Direction side)
        {
            canAct = false;
            animator.SetTrigger("walk");
            if (walkCheck.canDo&&!jumpCheck.canDo)
            {
                //scary
                transform.DOLocalMove(new Vector3((transform.forward * oneSquareLenght).x + transform.localPosition.x, transform.localPosition.y, (transform.forward * oneSquareLenght).z + transform.localPosition.z), animationTime).OnComplete(() => {
                    canAct = true;
                });
            }else if (jumpDownCheck.canDo && !jumpCheck.canDo)
            {
                animator.SetTrigger("jump");
                AudioManager.Play(AudioClipName.Jump);
                transform.DOLocalJump(new Vector3((transform.forward * oneSquareLenght).x + transform.localPosition.x, transform.localPosition.y - 1, (transform.forward * oneSquareLenght).z + transform.localPosition.z), 3f, 1, animationTime).OnComplete(() => {
                    canAct = true;
                });
            }

        }
        public void PressAction()
        {
            canAct = false;
            print("press");
            animator.SetTrigger("press");
            this.Wait(1f, () => {playerPush?.Invoke(gameObject); canAct = true; });
            
        }
        public void TurnAction(Direction side)
        {
            canAct = false;
            print("turn" + side.ToString()) ;
            animator.SetTrigger("walk");
            int way = side == Direction.Right ? 1 : -1;
            float rotation = transform.localEulerAngles.y;
            transform.DORotate(new Vector3(0,rotation+(90*way),0), animationTime).OnComplete(()=> {
                canAct = true;
            });
        }
        public void ResetPlayer()
        {
            transform.DOKill();
            canAct = false;
            animator.SetTrigger("jump");
            AudioManager.Play(AudioClipName.Jump);
            transform.DORotate(Vector3.zero, animationTime);
            AudioManager.Play(AudioClipName.Jump);
            transform.DOJump(start,3,1,1f).OnComplete(() => {
                canAct = true;
            });
        }
        public void CharSelection(GameObject gameObject)
        {
            gameObject.SetActive(true);
            animator = gameObject.GetComponent<Animator>();
        }
    }
}
