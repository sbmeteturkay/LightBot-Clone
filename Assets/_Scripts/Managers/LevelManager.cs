//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;
using TMPro;
using UnityEngine.UI;
namespace MeteTurkay{
	public class LevelManager : MonoBehaviour
	{
		[SerializeField] LevelGenerator levelGenerator;
		[SerializeField] int pressNeededButton = 0;
        List<PushButton> pushButtons = new();
        public static event Action finished;
        //[Header("UI")]
        //[SerializeField] GameObject levelButton;
        //[SerializeField] GameObject gridParentForButtons;
        //List<Level> levels = new();
        private void Start()
        {
            PushButton.buttonPressed += PushButton_buttonPressed;
            ActionController.resetButtons += ActionController_resetButtons;
            //CreateLevelButtons();
        }

        private void ActionController_resetButtons()
        {
            pressNeededButton= levelGenerator.numbersOfPressObject;
        }

        private void PushButton_buttonPressed(PushButton obj)
        {
            if (!pushButtons.Contains(obj))
            {
                pushButtons.Add(obj);
            }
            if (pushButtons.Count == pressNeededButton)
            {
                finished?.Invoke();
            }
        }

        public void StartLevel(int i)
        {
            Level level = Resources.Load<Level>("Levels/" + i.ToString());
            levelGenerator.level = level;
			levelGenerator.Initialization();
			pressNeededButton = levelGenerator.numbersOfPressObject;
        }
        //We can Create buttons dynamically, but i will look it later

        //void CreateLevelButtons()
        //{
        //    string filePath = Application.dataPath + "/Resources/Levels";
        //    int fileCount = Directory.GetFiles(filePath).Length / 2;
        //    Debug.Log(fileCount);
        //    for (int i = 0; i < fileCount; i++)
        //    {
        //        levels.Add(Resources.Load<Level>("Levels/" + i.ToString()));
        //        var button = Instantiate(levelButton, gridParentForButtons.transform);
        //        button.transform.GetChild(0).GetComponent<TMP_Text>().text = (i + 1).ToString();
        //        button.GetComponent<Button>().onClick.AddListener(delegate { StartLevel(i); gridParentForButtons.transform.parent.gameObject.SetActive(false);gridParentForButtons.transform.parent.gameObject.transform.parent.GetChild(1).gameObject.SetActive(true); });
        //    }
        //} 

	}
}
