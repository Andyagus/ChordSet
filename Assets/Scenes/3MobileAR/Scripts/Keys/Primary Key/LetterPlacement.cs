using System;
using TMPro;
using UnityEngine;

namespace Scenes._3MobileAR.Scripts.Keys.Primary_Key
{
    /// <summary>
    /// Placement for all of the main primary keys (A,B,C, etc…), setting their GameObject Keyboard Key
    /// to the name of the primary key.
    /// TODO: Refactor - not great if primary key name is different than what you want to display on key 
    /// </summary>
    public class LetterPlacement : MonoBehaviour
    {

        public bool hasEffect;
        public GameObject canvas1;
        public GameObject canvas2;
        private GameObject currentCanvas;

        public GameObject backgroundCube;
        private Material _cubeMat;
        
        public Color black;
        public Color blue;
        public Color orange;
        public Color purple;
        public Color pink;
        public Color yellow;
        public Color red;

        public enum MyColors
        {
            BLACK,
            BLUE,
            ORANGE,
            PURPLE,
            PINK,
            YELLOW,
            RED
        }

        public MyColors preferredColor;
        private MyColors _currentColor;

        private void Awake()
        {
            _cubeMat = backgroundCube.GetComponent<MeshRenderer>().material;
            // _currentColor = preferredColor;
        }

        private void Update()
        {
            
            if (hasEffect)
            {
                canvas1.SetActive(true);
                canvas2.SetActive(false);
                
                SwitchColor(preferredColor);
            }
            else
            {
                canvas2.SetActive(true);
                canvas1.SetActive(false);
                
                SwitchColor(MyColors.BLACK);
                
            }
        }

        private void SwitchColor(MyColors color)
        {
            switch (color)
            {
                case MyColors.BLACK:
                    _cubeMat.color = black;
                    break;
                case MyColors.BLUE:
                    _cubeMat.color = blue;
                    break;
                case MyColors.ORANGE:
                    _cubeMat.color = orange;
                    break;
                case MyColors.PURPLE:
                    _cubeMat.color = purple;
                    break;
                case MyColors.PINK:
                    _cubeMat.color = pink;
                    break;
                case MyColors.YELLOW:
                    _cubeMat.color = yellow;
                    break;
                case MyColors.RED:
                    _cubeMat.color = red;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        

    }
}
