#region Libraries
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] TextMeshProUGUI ui_Translation;
        [SerializeField] Toggle showHideTranslation;
        [SerializeField] Image blockImage;//block the view of the translation
        [SerializeField] GameObject hitUI, missUI;
        [SerializeField] Canvas canvas;
        #endregion



        [SerializeField] string language;

        public List<string> finalListRomaji = new List<string>();
        public List<string> finalListKana = new List<string>();
        public List<string> finalPTTranslationList = new List<string>();
        public List<string> finalENTranslationList = new List<string>();
        List<WordDatabase> finalDatabase = new List<WordDatabase>();


        string textGivenByUser = "";
        int wordCount;
        int points;
        int chosenIndex, lastChosenIndex;
        #endregion

        #region MonoBehaviour methods
        void Awake()
        {
            Debug.Log(kanaDatabase.tempList.Count);
            language = "english";
        }
        void Start()
        {
            GetLists();
            Randomize();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
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
        void GetLists()
        {
            #region Clearing lists 
            finalListKana.Clear();
            finalListRomaji.Clear();
            #endregion

            for (int i = 0; i < kanaDatabase.tempList.Count; i++)
            {
                finalDatabase.Add(kanaDatabase.tempList[i]);
            }
            for (int j = 0; j < kanaDatabase.tempList.Count; j++)
            {
                for (int i = 0; i < kanaDatabase.tempList.Count; i++)
                {
                    wordCount++;

                    finalListKana.AddRange(finalDatabase[i].kanaWord);

                    finalListRomaji.AddRange(finalDatabase[i].romajiWord);

                    if (language == "portuguese")
                    {
                        finalPTTranslationList.AddRange(finalDatabase[i].translatedToPT);
                    }
                    if (language == "english")
                    {
                        finalENTranslationList.AddRange(finalDatabase[i].translatedToEN);
                    }
                }
            }
            for (int i = 0; i < finalListKana.Count; i++)
            {
                finalListKana[i] = finalListKana[i].Replace("、", "\n");
            }

            finalDatabase.Clear();
        }
        public void SetString()
        {
            textGivenByUser = inputText.text.ToLower();
            inputText.text = null;
        }
        public void Randomize()
        {
            chosenIndex = Random.Range(0, finalListKana.Count);
            Debug.Log(chosenIndex);
            if (chosenIndex == lastChosenIndex)
            {
                Randomize();
            }
            else
            {
                kanaText.text = finalListKana[chosenIndex];
                if (language == "portuguese")
                {
                    ui_Translation.text = finalPTTranslationList[chosenIndex];
                }
                if (language == "english")
                {
                    ui_Translation.text = finalENTranslationList[chosenIndex];
                }
            }
            lastChosenIndex = chosenIndex;
        }
        public void Verification()
        {
            if (textGivenByUser == "") return;
            Debug.Log(textGivenByUser);

            if (textGivenByUser == finalListRomaji[chosenIndex])
            {
                Hit();
            }
            else
            {
                Miss();
            }
        }

        public void Hit()
        {
            GameObject newUIHit =
            GameObject.Instantiate(hitUI, new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0), Quaternion.identity, canvas.transform);
        }
        public void Miss()
        {
            GameObject newUIHit =
            GameObject.Instantiate(missUI, new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0), Quaternion.identity, canvas.transform);
        }
        #endregion
    }
}
