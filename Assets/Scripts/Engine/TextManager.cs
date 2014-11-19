using System.Linq;

using Assets.Scripts.Common;
using Assets.Scripts.Data;
using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.Engine
{
    public class TextManager: Script
    {
        public GameButton TextRoot;

        public GameButton TextButton;
        public GameButton PrevButton;
        public GameButton NextButton;

        private TextEN _textEn;
        private TextRU _textRu;

        public void Awake()
        {
            TextButton.Up += TextButton_Up;
            PrevButton.Up += PrevButton_Up;
            NextButton.Up += NextButton_Up;

            _textEn = GetComponent<TextEN>();
            _textRu = GetComponent<TextRU>();

            _textEn.Control.SetActive(false);
            _textRu.Control.SetActive(true);

            Debug.Log(_textRu.MainText.text);
        }

        void NextButton_Up()
        {
            Debug.Log("next");
        }

        void PrevButton_Up()
        {
            Debug.Log("prev");
        }

        void TextButton_Up()
        {
            if(_textEn.Control.activeSelf)
            {
                _textEn.Control.SetActive(false);
                _textRu.Control.SetActive(true);
            }
            else
            {
                _textEn.Control.SetActive(true);
                _textRu.Control.SetActive(false);
            }
        }
    }
}
