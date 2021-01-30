#region Libraries
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

#endregion
namespace PedroArthur
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        [SerializeField] string hiraganaScene, katakanaScnene;
        [SerializeField] Dropdown dropdown;
        int dropdownValue;
        public string lang;
        #endregion

        #region MonoBehaviour methods
        void Awake()
        {
            lang = "english";
        }
        #endregion

        #region Custom methods
        public void MenuScene()
        {
            SceneManager.LoadScene("Main Menu");
        }
        public void HiraganaScene()
        {
            SceneManager.LoadScene(hiraganaScene);
        }
        public void KatakanaScene()
        {
            SceneManager.LoadScene(katakanaScnene);
        }
        public void FuriganaScene()
        {
            SceneManager.LoadScene("Japanese Input Text");
        }
        public void HandleDropdown(int value)
        {
            if (value == 0)
            {
                lang = "english";
                PlayerPrefs.SetString("lang", "english");
            }
            else
            {
                lang = "portuguese";
                PlayerPrefs.SetString("lang", "portuguese");
            }
        }
        #endregion
    }
}