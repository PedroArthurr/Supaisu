#region Libraries
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
#endregion
namespace PedroArthur
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        [SerializeField] string hiraganaScene, katakanaScnene;
        #endregion

        #region MonoBehaviour methods
        #endregion

        #region Custom methods
        public void HiraganaScene()
        {
            SceneManager.LoadScene(hiraganaScene);
        }
        public void KatakanaScene()
        {
            SceneManager.LoadScene(katakanaScnene);
        }
        #endregion
    }
}