using System;
using System.Linq;
using System.Collections.Generic;
using Assets.Scripts.Common;
using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts
{
    public class Profile
    {
        private static Profile _instance;
        private const string ProfileKey = "ST";

        public List<int> ActiveCatigories { get; private set; }
        public Dictionary<int, Word> Words { get; private set; }
        public List<Category> Categories { get; private set; }

        public static Profile Instance
        {
            get
            {
                if (_instance == null)
                {
                    Load();
                }

                return _instance;
            }
        }

        private Profile()
        {
        }

        public static void Load() // TODO: Make private
        {
            GameLog.Write("Loading profile...");

            //PlayerPrefs.DeleteAll(); // TODO: WARNING!
            //PlayerPrefs.Save();

            //if (PlayerPrefs.HasKey(ProfileKey))
            if(false)
            {
                Debug.Log("Load old profile");
                var profile = PlayerPrefs.GetString(ProfileKey);

                GameLog.Write("Serialized profile: {0}", profile);

                _instance = Serializer.Deserialize<Profile>(profile);
            }
            else
            {
                Debug.Log("Create new profile");
                _instance = new Profile
                {
                    Words = new Dictionary<int,Word>(),
                    Categories = new List<Category>(),
                    ActiveCatigories = new List<int>()
                };

                _instance.Words.Add(0, new Word
                    {
                        Id = 0,
                        TextEn = "to be/is/are",
                        TextRu = "быть",
                        ActionVerb = "being",
                        Transcription = "[ be ]",
                        Verb2 = "was/were",
                        Verb3 = "been"
                    });

                _instance.Words.Add(1, new Word
                {
                    Id = 1,
                    TextEn = "house",
                    TextRu = "дом",
                    Transcription = "[ house ]",
                });

                _instance.Words.Add(2, new Word
                {
                    Id = 2,
                    TextEn = "car",
                    TextRu = "машина",
                    Transcription = "[ car ]",
                });

                _instance.Categories.Add(new Category
                    {
                        Id = 0,
                        Name = "Test",
                        Words = _instance.Words.Values.ToList()
                    });

                _instance.Categories.Add( new Category
                {
                    Id = 1,
                    Name = "Test 1",
                    Words = _instance.Words.Values.ToList()
                });

                _instance.Categories.Add( new Category
                {
                    Id = 2,
                    Name = "Test 2",
                    Words = _instance.Words.Values.ToList()
                });

                _instance.ActiveCatigories = new List<int>() { 0 };
            }
        }

        public void Save()
        {
            GameLog.Write("Saving profile...");

            var profile = Serializer.Serialize(this);

            GameLog.Write("Serialized profile: {0}", profile);

            PlayerPrefs.SetString(ProfileKey, profile);
            PlayerPrefs.Save();
        }
    }
}