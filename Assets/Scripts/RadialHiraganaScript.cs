#region Libraries
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
#endregion
namespace PedroArthur
{
    public class RadialHiraganaScript : MonoBehaviour
    {
        #region Variables
        [SerializeField] Database database;
        [SerializeField] TextMeshProUGUI tmpCorrectHiragana, pontuation;
        [SerializeField] Button button1, button2, button3, button4;
        [SerializeField] int startPoint;

        [HideInInspector] public int chosenButton;
        public int points;

        string key, fake1, fake2, fake3;
        int keyNumber, randNumber1, randNumber2, randNumber3, chosenNumber;
        int indexPosition;
        int hiraganaCount;

        public List<int> alreadyChosenIndexes = new List<int>();
        #endregion

        #region MonoBehaviour methods
        void Start()
        {
            hiraganaCount = database.listLenght;
            chosenButton = 0;
            Randomize();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                alreadyChosenIndexes.Clear();Randomize();
            }
            pontuation.text = points.ToString();
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
            if (chosenButton == indexPosition) //Onclick
            {
                points++; alreadyChosenIndexes.Clear();Randomize();
            }
            else { points--;alreadyChosenIndexes.Clear(); Randomize(); }
        }

        public void Randomize() //*Randomize the Key word/symbol, the buttons annd their order
        {
           
            //keyNumber = Random.Range(0, randomIndexList.Count);
            

            #region // !Prevents repetition
            for (int x = 0; x < hiraganaCount; x++)
            {
                alreadyChosenIndexes.Add(x);
            }
            for (int i = 0; i < 3; i++)
            {  
            int index = Random.Range(0, alreadyChosenIndexes.Count);
            chosenNumber = alreadyChosenIndexes[index];
            alreadyChosenIndexes.Add(chosenNumber);
            alreadyChosenIndexes.Remove(alreadyChosenIndexes[index]);
            keyNumber = chosenNumber;
            }
            keyNumber = alreadyChosenIndexes[0];
            randNumber1 = alreadyChosenIndexes[1];
            randNumber2 = alreadyChosenIndexes[2];
            randNumber3 = alreadyChosenIndexes[3];
            
            // !
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


    }
}