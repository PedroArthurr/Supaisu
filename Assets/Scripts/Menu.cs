#region Libraries
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#endregion
namespace PedroArthur
{
    //TODO Fazer botãoa ativar todos os toggles
    public class Menu : MonoBehaviour
    {
        #region Variables

        public List<Database> databaseList = new List<Database>();
        public List<Database> newDatabaseList = new List<Database>();
        [SerializeField] List<GameObject> toggles = new List<GameObject>();
        [SerializeField] DatabaseDatabase temporayDatabase;
        int clicks;
        public string scene1, scene2;
        public GameObject panel;
        [Space(20)]
        
        [SerializeField] Database smallDB1, smallDB2, smallDB3, smallDB4, smallDB5, smallDB6, smallDB7, smallDB8, smallDB9, smallDB10, smallDB11, smallDB12, smallDB13;
        // int state;

        // [SerializeField] DatabaseDatabase toggleAll;
        #endregion

        #region MonoBehaviour methods
        void Start()
        {
            foreach (GameObject toggle in GameObject.FindGameObjectsWithTag("Toggle"))
            {
                //toggles.Add(toggle);

                //toggle.gameObject.GetComponent<Toggle>().isOn = true;
            }

        }
        #endregion
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

            }

        }
        #region Custom methods
        public void Right()
        {
            LeanTween.move(panel.gameObject.GetComponent<RectTransform>(), new Vector3(-1928, -0, 0f), 0.2f);
        }
        public void Left()
        {
            LeanTween.move(panel.gameObject.GetComponent<RectTransform>(), new Vector3(0, 0, 0f), 0.2f);
        }
        public void OnPlay()
        {
            for (int i = 0; i < databaseList.Count; i++)
            {
                temporayDatabase.tempList.Add(databaseList[i]);
            }

            if (databaseList.Contains(smallDB1) || databaseList.Contains(smallDB2) || databaseList.Contains(smallDB2) || databaseList.Contains(smallDB3) || databaseList.Contains(smallDB3) || databaseList.Contains(smallDB4) || databaseList.Contains(smallDB5) || databaseList.Contains(smallDB6) || databaseList.Contains(smallDB7) || databaseList.Contains(smallDB8) || databaseList.Contains(smallDB9) || databaseList.Contains(smallDB10) || databaseList.Contains(smallDB11) || databaseList.Contains(smallDB12)|| databaseList.Contains(smallDB13))
            {
                if (databaseList.Count == 1) { SceneManager.LoadScene(scene1); } else { SceneManager.LoadScene(scene2); }
            }

            else
            {
                if (databaseList.Count > 0) { SceneManager.LoadScene(scene2); }
                else
                {
                    return;
                }

            }
        }
        public void AddItem(Database itemToAdd)
        {
            string toggleName = EventSystem.current.currentSelectedGameObject.name;
            if (GameObject.Find(toggleName).GetComponent<Toggle>().isOn)
            {
                databaseList.Add(itemToAdd);
            }
            else
            {
                databaseList.Remove(itemToAdd);
            }
        }
        public void TurnAllTogglesOn()
        {
            // Toggle[] toggles = FindObjectsOfType<Toggle>();;
            // List<Toggle> t = new List<Toggle>();
            // t.AddRange(FindObjectsOfType<Toggle>());
            // if (state == 0)
            // {
            //     for (int i = 0; i < toggleAll.tempList.Count; i++)
            //     {Debug.Log("gjhg");
            //         t[i].isOn = true;

            //         databaseList.Add(toggleAll.tempList[i]);
            //         // toggles[i].isOn = true;
            //     }
            //     for (int i = 0; i < toggles.Length; i++)
            //     {

            //     }
            // }else{return;}
            // state = 1;

        }
        public void TurnallTogglesOff()
        {
            // if (state == 1)
            // {
            //     for (int i = 0; i < toggleAll.tempList.Count; i++)
            //     {
            //         databaseList.Remove(toggleAll.tempList[i]);
            //     }
            // }

            // state = 0;
        }
        #endregion
    }
}