using System;
using System.Collections.Generic;
using System.Linq;

using Assets.Scripts.Common;
using Assets.Scripts.Data;
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


        private List<Word> _activeWords = new List<Word>();
        private int _activeIndex = -1;
        public void Awake()
        {
            TextButton.Up += TextButton_Up;
            PrevButton.Up += PrevButton_Up;
            NextButton.Up += NextButton_Up;

            _textEn = GetComponent<TextEN>();
            _textRu = GetComponent<TextRU>();

            GenerateWords();
            RenderActiveWord();

            Debug.Log(_textRu.MainText.text);
        }


        void NextButton_Up()
        {
            Debug.Log("next");
            _activeIndex++;
            if (_activeIndex >= _activeWords.Count)
                _activeIndex = 0;

            RenderActiveWord();
        }

        void PrevButton_Up()
        {
            Debug.Log("next");
            _activeIndex--;
            if (_activeIndex <0)
                _activeIndex = _activeWords.Count-1;

            RenderActiveWord();
        }

        void TextButton_Up()
        {
            if(_textEn.Control.activeSelf)
            {
                ShowRuText();
            }
            else
            {
                ShowEnText();
            }
        }

        private void ShowRuText()
        {
            _textEn.Control.SetActive(false);
            _textRu.Control.SetActive(true);
        }
        private void ShowEnText()
        {
            _textEn.Control.SetActive(true);
            _textRu.Control.SetActive(false);
        }

        private void GenerateWords()
        {
            var rnd = new System.Random();

            _activeWords.Clear();
            var wordSource = Profile.Instance.Categories.Where(c => Profile.Instance.ActiveCatigories.Contains(c.Id)).SelectMany(c => c.Words)
                .OrderBy(c=> CRandom.GetRandom()).ToList();

            _activeWords.AddRange(wordSource);
            _activeIndex = 0;
        }

        private void RenderActiveWord()
        {
            ShowRuText();

            Word item = _activeWords[_activeIndex];

            _textRu.MainText.text = item.TextRu;

            _textEn.MainText.text = item.TextEn;
            _textEn.TranscriptionText.text = item.Transcription;
        }
    }
}
