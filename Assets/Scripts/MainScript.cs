#region Libraries
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
#endregion
namespace PedroArthur
{
    public class MainScript : MonoBehaviour
    {
        [Header("Is the Hiragana scene  ?")]
        [SerializeField] bool hiraganaScene;
        [Header("'Results' Scene name")]
        [SerializeField] string nextSceneName;

        [Tooltip("Sriptable Objects for next Scene")]
        [SerializeField] FinalInfo mistakeString;
        [SerializeField] DatabaseDatabase mistakesList;

        [Tooltip("'TMPro' assets in-scene")]
        [SerializeField] TextMeshProUGUI tmpCorrectHiragana, hits, misses;
        [Tooltip("Buttons in-game")]
        [SerializeField] Button button1, button2, button3, button4;

        [Space(10)]
        [SerializeField] float startTimer = 10;
        [Space(10)]
        [SerializeField] GameObject hitUI, missUI;
        [Space(20)]
        [SerializeField] DatabaseDatabase tmpDatabase;
        [Space(20)]
        [HideInInspector] public int chosenButton;

        GameObject canvas;

        public List<int> alreadyChosenIndexes = new List<int>();
        public List<int> drawn = new List<int>();
        public List<string> finalListPT = new List<string>();
        public List<string> finalListJP = new List<string>();
        public List<string> mostMistaken = new List<string>();
        public List<string> lista = new List<string>();
        public List<Database> databases = new List<Database>();
        [Header("End of group")]



        string output;
        string key, fake1, fake2, fake3;
        int keyNumber, randNumber1, randNumber2, randNumber3, chosenNumber;
        int indexPosition;
        int hiraganaCount;
        int hitCount, missCount, lastHitCount, lastMissCount;
        float time;
        public int points;
        bool small;

        void Awake()
        {
            Debug.Log(this.gameObject.name);
            Debug.Log(tmpDatabase.tempList[0].language);
            if (tmpDatabase.tempList[0].language == "Hiragana")
            {
                hiraganaScene = true;
            }
            else
            {
                hiraganaScene = false;
            }
        }
        void Start()
        {
            Debug.Log(hiraganaScene);
            GetLists();
            canvas = GameObject.Find("Canvas");
            if (!canvas) { Debug.LogError("Cadê o canvas porra ??"); }
            time = startTimer;
            hiraganaCount = finalListJP.Count;
            chosenButton = 0;
            Randomize();
        }
        void GetLists()
        {
            hiraganaCount = tmpDatabase.tempList.Count;

            for (int i = 0; i < tmpDatabase.tempList.Count; i++)
            {
                databases.Add(tmpDatabase.tempList[i]);
            }
            for (int i = 0; i < databases.Count; i++)
            {
                finalListPT.AddRange(databases[i].portuguese);
                finalListJP.AddRange(databases[i].japanese);
            }

            if (finalListJP.Count < 4)
            {
                small = true;
            }
            tmpDatabase.tempList.Clear();
        }
        void Update()
        {
            hits.text = hitCount.ToString();
            misses.text = missCount.ToString();

            if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.GetKeyDown(KeyCode.Escape))

                {
                    FinalResults();
                    SceneManager.LoadScene(nextSceneName);
                }
            }

        }
        public void FinalScene()
        {
            FinalResults();
                SceneManager.LoadScene(nextSceneName);
        }


        public void One()
        {
            chosenButton = 1;
        }
        public void Two()
        {
            chosenButton = 2;
        }
        public void Three()
        {
            chosenButton = 3;
        }
        public void Four()
        {
            chosenButton = 4;
        }
        // public void Five()
        // {
        //     chosenButton = 5;
        // }

        public void Verification() //*Verify what button was chosen, add or subtract points and call Randomize
        {
            alreadyChosenIndexes.Clear();
            drawn.Clear();
            if (chosenButton == indexPosition) //isCorrect on click
            {
                Hit();
                if (time <= 0) { points += 0; Randomize(); }
                else
                {
                    hitCount++;
                    time = startTimer;
                    Randomize();
                }
            }
            else
            {
                string mistake = finalListJP[keyNumber];
                mostMistaken.Add(mistake);
                Miss();
                missCount++;
                if (time <= 0) { points -= 10; }
                points -= Mathf.RoundToInt(time);
                time = startTimer;
                Randomize();
            }


        }


        public void Randomize()
        {
            // !===========================================================================================
            #region Three hiraganas
            if (small)

            {
                for (int x = 0; x < hiraganaCount; x++)
                {
                    drawn.Add(x);
                }
                for (int i = 0; i < hiraganaCount; i++)
                {
                    int index = Random.Range(0, drawn.Count);
                    chosenNumber = drawn[index];
                    alreadyChosenIndexes.Add(chosenNumber);
                    drawn.Remove(drawn[index]);
                }

                keyNumber = alreadyChosenIndexes[0];
                randNumber1 = alreadyChosenIndexes[1];
                randNumber2 = alreadyChosenIndexes[2];



                //*index -> string
                key = finalListPT[keyNumber];
                fake1 = finalListPT[randNumber1];
                fake2 = finalListPT[randNumber2];

                tmpCorrectHiragana.text = finalListJP[keyNumber];


                indexPosition = Random.Range(1, 3);

                //Buttons
                switch (indexPosition)
                {
                    case 1:
                        button1.GetComponentInChildren<TextMeshProUGUI>().text = key;
                        button2.GetComponentInChildren<TextMeshProUGUI>().text = fake1;
                        button3.GetComponentInChildren<TextMeshProUGUI>().text = fake2;
                        // button4.GetComponentInChildren<TextMeshProUGUI>().text = fake3;
                        break;
                    case 2:
                        button2.GetComponentInChildren<TextMeshProUGUI>().text = key;
                        button1.GetComponentInChildren<TextMeshProUGUI>().text = fake1;
                        button3.GetComponentInChildren<TextMeshProUGUI>().text = fake2;
                        // button4.GetComponentInChildren<TextMeshProUGUI>().text = fake3;

                        break;
                    case 3:
                        button3.GetComponentInChildren<TextMeshProUGUI>().text = key;
                        button2.GetComponentInChildren<TextMeshProUGUI>().text = fake1;
                        button1.GetComponentInChildren<TextMeshProUGUI>().text = fake2;
                        // button4.GetComponentInChildren<TextMeshProUGUI>().text = fake3;

                        break;
                }
                // !===========================================================================================
            }
            #endregion
            #region Four hiraganas
            if (!small)
            {
                for (int x = 0; x < hiraganaCount; x++)
                {
                    drawn.Add(x);
                }
                for (int i = 0; i < hiraganaCount; i++)
                {
                    int index = Random.Range(0, drawn.Count);
                    chosenNumber = drawn[index];
                    alreadyChosenIndexes.Add(chosenNumber);
                    drawn.Remove(drawn[index]);
                }

                keyNumber = alreadyChosenIndexes[0];
                randNumber1 = alreadyChosenIndexes[1];
                randNumber2 = alreadyChosenIndexes[2];
                randNumber3 = alreadyChosenIndexes[3];




                //*index -> string
                key = finalListPT[keyNumber];
                fake1 = finalListPT[randNumber1];
                fake2 = finalListPT[randNumber2];
                fake3 = finalListPT[randNumber3];

                tmpCorrectHiragana.text = finalListJP[keyNumber];



                indexPosition = Random.Range(1, 4);

                //Buttons
                switch (indexPosition)
                {
                    case 1:
                        button1.GetComponentInChildren<TextMeshProUGUI>().text = key;
                        button2.GetComponentInChildren<TextMeshProUGUI>().text = fake1;
                        button3.GetComponentInChildren<TextMeshProUGUI>().text = fake2;
                        button4.GetComponentInChildren<TextMeshProUGUI>().text = fake3;
                        break;
                    case 2:
                        button2.GetComponentInChildren<TextMeshProUGUI>().text = key;
                        button1.GetComponentInChildren<TextMeshProUGUI>().text = fake1;
                        button3.GetComponentInChildren<TextMeshProUGUI>().text = fake2;
                        button4.GetComponentInChildren<TextMeshProUGUI>().text = fake3;

                        break;
                    case 3:
                        button3.GetComponentInChildren<TextMeshProUGUI>().text = key;
                        button2.GetComponentInChildren<TextMeshProUGUI>().text = fake1;
                        button1.GetComponentInChildren<TextMeshProUGUI>().text = fake2;
                        button4.GetComponentInChildren<TextMeshProUGUI>().text = fake3;

                        break;
                    case 4:
                        button4.GetComponentInChildren<TextMeshProUGUI>().text = key;
                        button2.GetComponentInChildren<TextMeshProUGUI>().text = fake1;
                        button3.GetComponentInChildren<TextMeshProUGUI>().text = fake2;
                        button1.GetComponentInChildren<TextMeshProUGUI>().text = fake3;
                        break;
                }
            }
            #endregion
            // !===========================================================================================
        }

        void Hit()
        {
            GameObject newUIHit =
            GameObject.Instantiate(hitUI, new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0), Quaternion.identity, canvas.transform);
        }
        void Miss()
        {
            GameObject newMissUI =
            GameObject.Instantiate(missUI, new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0), Quaternion.identity, canvas.transform);
        }

        public void FinalResults()//* Mode
        {
            if (hiraganaScene)
            {
                var query = mostMistaken.GroupBy(x => x)
                      .OrderByDescending(y => y.Count() > 1)
                      .Select(y => new { Hiragana = y.Key, Missed = y.Count() })
                      .Take(5)
                      .ToList();


                mistakeString.mostMistaken = string.Join("", query).Replace('{', ' ').Replace(',', ' ').Replace('}', '\n');

                mostMistaken.Clear();
            }
            else
            {
                var query = mostMistaken.GroupBy(x => x)
                                        .OrderByDescending(y => y.Count() > 1)
                                        .Select(y => new { Katakana = y.Key, Missed = y.Count() })
                                        .Take(5)
                                        .ToList();


                mistakeString.mostMistaken = string.Join("", query).Replace('{', ' ').Replace(',', ' ').Replace('}', '\n');

                mostMistaken.Clear();

            }
        }

    }
}
