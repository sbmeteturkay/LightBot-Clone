//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

using UnityEngine;

using System;
namespace MeteTurkay{
	public class PushButton : MonoBehaviour
	{
		[SerializeField]private bool isPushed=false;
        MeshRenderer meshRenderer;
        GameObject touchedPlayer;
        [SerializeField]Color defaultColor;
        public static event Action<PushButton> buttonPressed;
        private void Start()
        {
            PlayerUnit.playerPush += PlayerUnit_playerPush;
            ActionController.resetButtons += ActionController_resetButtons;
            meshRenderer = GetComponent<MeshRenderer>();
            defaultColor = meshRenderer.material.color;
        }
        private void OnDestroy()
        {
            PlayerUnit.playerPush -= PlayerUnit_playerPush;
            ActionController.resetButtons -= ActionController_resetButtons;
        }

        private void ActionController_resetButtons()
        {
            ResetAll();
        }

        private void PlayerUnit_playerPush(GameObject player)
        {
            if (touchedPlayer == player && !isPushed)
            {
                meshRenderer.material.color = Color.blue;
                isPushed = true;
                buttonPressed?.Invoke(this);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                touchedPlayer = other.gameObject;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                touchedPlayer = null;
            }
        }
        public void ResetAll()
        {
            isPushed = false;
            meshRenderer.material.color = defaultColor;
        }
    }
}
