//Authored by saban mete turkay demirkiran
//follow: https://github.com/sbmeteturkay

using UnityEngine;
using System;
using System.Collections.Generic;
namespace MeteTurkay{
    [CreateAssetMenu(fileName = "Level", menuName = "Level Generation/Level", order = 0)]
    public class Level : ScriptableObject
    {
        public TextAsset levelTextAsset;
        public GameObject defaultButton;
        public GameObject pressButton;
        private int width, height;
        private string[] levelStrings;
        public float spacingX = 1;
        public float spacingY = 1;
        public void Initialization()
        {
            string widthT = levelTextAsset.text[0].ToString() + levelTextAsset.text[1].ToString();
            string heightT = levelTextAsset.text[4].ToString() + levelTextAsset.text[5].ToString();
            width = Int32.Parse(widthT);
            height = Int32.Parse(heightT);
            levelStrings = levelTextAsset.text.Split('\n');
        }

        public (int, int) GetWidthAndHeight()
        {
            return (width, height);
        }

        public string[] GetLevelStrings()
        {
            return levelStrings;
        }
    }
}
