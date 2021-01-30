#region Libraries
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Serialization;

#endregion
namespace PedroArthur
{
    public class InputGame : MonoBehaviour
    {
        #region Variables
        [SerializeField] KanaDatabase kanaDatabase;
        [SerializeField] WordDatabase wordDatabase;



        #region UI
        [SerializeField] TextMeshProUGUI hits, misses, pontution;
        [SerializeField] Button comfirmButton;
        [SerializeField] TMP_InputField inputText;
        [SerializeField] TextMeshProUGUI kanaText;
        [FormerlySerializedAs("ui_Translation")] [SerializeField] TextMeshProUGUI uiTranslation;
        [SerializeField] Toggle showHideTranslation;
        [SerializeField] Image blockImage;//block the view of the translation
        [SerializeField] GameObject hitUI, missUI;
        [SerializeField] Canvas canvas;
        #endregion



        [SerializeField] string language;

        public List<string> finalListRomaji = new List<string>();
        public List<string> finalListKana = new List<string>();
        [FormerlySerializedAs("finalPTTranslationList")] public List<string> finalPtTranslationList = new List<string>();
        [FormerlySerializedAs("finalENTranslationList")] public List<string> finalEnTranslationList = new List<string>();
        List<WordDatabase> _finalDatabase = new List<WordDatabase>();


        string _textGivenByUser = "";
        int _wordCount;
        int _points;
        int _chosenIndex, _lastChosenIndex;

        TouchScreenKeyboard _keyboard;
        #endregion

        #region MonoBehaviour methods
        void Awake()
        {
            language = PlayerPrefs.GetString("lang");
        }
        void Start()
        {
            GetLists();
            Randomize();
            OpenKeyboard();
        }
        void Update()
        {
            if ((Input.GetKeyDown(KeyCode.Return)) || (Input.GetKeyDown(KeyCode.KeypadEnter)) || _keyboard.status == TouchScreenKeyboard.Status.Done)
            {
                inputText.ActivateInputField();
                SetString();
                Verification();
                Randomize();
            }
            if (showHideTranslation.GetComponent<Toggle>().isOn == true)
            {
                blockImage.enabled = true;
            }
            else { blockImage.enabled = false; }
        }
        #endregion

        #region Custom methods
        void OpenKeyboard()
        {
            _keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
            inputText.ActivateInputField();
            TouchScreenKeyboard.hideInput = true;
        }
        void GetLists()
        {
            #region Clearing lists 
            finalListKana.Clear();
            finalListRomaji.Clear();
            #endregion

            Debug.Log(kanaDatabase.tempList.Count);

            for (int i = 0; i < kanaDatabase.tempList.Count; i++)
            {
                _finalDatabase.Add(kanaDatabase.tempList[i]);
            }
            for (int i = 0; i < kanaDatabase.tempList.Count; i++)
            {
                    _wordCount++;

                    finalListKana.AddRange(_finalDatabase[i].kanaWord);

                    finalListRomaji.AddRange(_finalDatabase[i].romajiWord);

                    switch (language)
                    {
                        case "portuguese":
                            finalPtTranslationList.AddRange(_finalDatabase[i].translatedToPT);
                            break;
                        case "english":
                            finalEnTranslationList.AddRange(_finalDatabase[i].translatedToEN);
                            break;
                    }
            }
            for (int i = 0; i < finalListKana.Count; i++)
            {
                finalListKana[i] = finalListKana[i].Replace("、", "\n");
            }

            _finalDatabase.Clear();
        }
        void SetString()
        {
            _textGivenByUser = inputText.text.ToLower();
            inputText.text = null;
        }

        void Randomize()
        {
            _chosenIndex = Random.Range(0, finalListKana.Count);
            // Debug.Log(chosenIndex);
            if (_chosenIndex == _lastChosenIndex)
            {
                Randomize();
            }
            else
            {
                kanaText.text = finalListKana[_chosenIndex];
                switch (language)
                {
                    case "portuguese":
                        uiTranslation.text = finalPtTranslationList[_chosenIndex];
                        break;
                    case "english":
                        uiTranslation.text = finalEnTranslationList[_chosenIndex];
                        break;
                }
            }
            _lastChosenIndex = _chosenIndex;
        }

        void Verification()
        {
            if (_textGivenByUser == "") return;
            Debug.Log(_textGivenByUser);

            if (_textGivenByUser == finalListRomaji[_chosenIndex])
            {
                Hit();
            }
            else
            {
                Miss();
            }
        }

        void Hit()
        {
            GameObject newUIHit =
            GameObject.Instantiate(hitUI, new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0), Quaternion.identity, canvas.transform);
        }

        void Miss()
        {
            GameObject newUIHit =
            GameObject.Instantiate(missUI, new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0), Quaternion.identity, canvas.transform);
        }
        #endregion
    }
}
