#region Libraries
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#endregion
namespace PedroArthur
{
    public class ListTest : MonoBehaviour
    {
        #region Variables
        public Database[] database;
        public List<string> finalListPT = new List<string>();
        public List<string> finalListJP = new List<string>();
        #endregion

        #region MonoBehaviour methods
        void Start()
        {
            for (int i = 0; i < database.Length; i++)
            {
              finalListPT.AddRange(database[i].portuguese);
              finalListJP.AddRange(database[i].japanese);
            }

        }
        void Update()
        {

        }
        #endregion

        #region Custom methods

        #endregion
    }
}