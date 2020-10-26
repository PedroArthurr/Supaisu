#region Libraries
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
#endregion
namespace PedroArthur
{
    public class Backuo : MonoBehaviour
    {
        #region Variables
        [SerializeField] Database database;
        [Space(10)]
        [SerializeField] TextMeshProUGUI tmpCorrectHiragana, pontuation, hits, misses;
        [Space(10)]
        [SerializeField] Button button1, button2, button3, button4;
        [Space(10)]
        [SerializeField] float startTimer = 10, timeToSkip = 1.5f;
        [Space(10)]
        [SerializeField] Slider slider;
        [SerializeField] GameObject hitUI, missUI;
        [HideInInspector] public int chosenButton;

        GameObject canvas;

        public List<int> alreadyChosenIndexes = new List<int>();
        public List<int> drawn = new List<int>();
        public int points;

        string key, fake1, fake2, fake3;
        int keyNumber, randNumber1, randNumber2, randNumber3, chosenNumber;
        int indexPosition;
        int hiraganaCount;
        int hitCount, missCount, lastHitCount, lastMissCount;
        float time;


        #endregion

        #region MonoBehaviour methods
        void Start()
        {
            canvas = GameObject.Find("Canvas");
            if (!canvas) { Debug.LogError("Cadê o canvas krl ??"); }
            time = startTimer;
            hiraganaCount = database.listLenght;
            chosenButton = 0;
            Randomize();
        }
        void GetLists(){
            
        }
        void Update()
        {
            time = time - Time.deltaTime;
            slider.value = time;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                alreadyChosenIndexes.Clear();
                drawn.Clear(); Randomize();
            }
            pontuation.text = points.ToString() + " Points";
            hits.text = "Hits: " + hitCount.ToString();
            misses.text = "Misses: " + missCount.ToString();
        }
        #endregion

        #region Custom methods
        #region Checking what button were clicked
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
        public void Five()
        {
            chosenButton = 5;
        }
        #endregion
        public void Verification() //*Verify what button was chosen, add or subtract points and call Randomize
        {
            alreadyChosenIndexes.Clear();
            drawn.Clear();
            if (chosenButton == indexPosition) //isCorrect on clic
            {
                Hit();
                if (time <= 0) { points += 0; Randomize(); }
                else
                {
                    hitCount++;
                    points += Mathf.RoundToInt(time);
                    slider.value = startTimer;
                    time = startTimer;
                    Randomize();
                }
            }
            else
            {
                Miss();
                missCount++;
                if (time <= 0) { points -= 10; }
                points -= Mathf.RoundToInt(time);
                slider.value = startTimer;
                time = startTimer;
                Randomize();
            }


        }


        public void Randomize()
        {
            #region //*DONE veriicar se continua repetindo


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


            #endregion

            //*index -> string
            key = database.portuguese[keyNumber];
            fake1 = database.portuguese[randNumber1];
            fake2 = database.portuguese[randNumber2];
            fake3 = database.portuguese[randNumber3];

            tmpCorrectHiragana.text = database.japanese[keyNumber];
            #endregion
            #region button position

            indexPosition = Random.Range(1, 5);

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


            #endregion
        }
        void Hit()
        {   
            GameObject newUIHit =
            GameObject.Instantiate(hitUI, new Vector3 (Screen.width * 0.5f, Screen.height * 0.5f, 0), Quaternion.identity, canvas.transform);
        }
        void Miss()
        {
            GameObject newMissUI =
            GameObject.Instantiate(missUI, new Vector3 (Screen.width * 0.5f, Screen.height * 0.5f, 0), Quaternion.identity, canvas.transform);
        }

    }
}
