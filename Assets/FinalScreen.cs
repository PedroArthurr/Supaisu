#region Libraries
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System.Collections.Generic;
#endregion
namespace PedroArthur
{
    public class FinalScreen : MonoBehaviour
    {
        #region Variables
        [SerializeField] FinalInfo mistakeString;
        [SerializeField] TextMeshProUGUI message;
        #endregion

        #region MonoBehaviour methods
        void Awake()
        {
            message.text = mistakeString.mostMistaken;
        }
        void Start()
        {
            mistakeString.mostMistaken = "";
        }
        void Update()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.GetKeyDown(KeyCode.Escape))

                {
                    SceneManager.LoadScene("Main Menu");
                }
            }
        }
        #endregion

        #region Custom methods
        public void GoToMenu()
        {
            SceneManager.LoadScene("Main Menu");
        }
        #endregion
    }
}