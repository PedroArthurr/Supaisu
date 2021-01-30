#region bibliotecas
using UnityEngine; using System.Collections; using System.Collections.Generic; 
#endregion
namespace PedroArthur { 
[CreateAssetMenu(fileName = "New WordDatabase", menuName = ("WordDatabase"))]
public class WordDatabase : ScriptableObject
  {
        #region Dados:

        public string alphabet;
        
        public List<string> kanaWord = new List<string>();

        public List<string> romajiWord = new List<string>();
         
        public List<string> translatedToPT = new List<string>();

        public List<string> translatedToEN = new List<string>();
        
              
        #endregion
        void Start()
        {
          for (int i = 0; i < kanaWord.Count; i++)
          {
              kanaWord[i].Replace(">","\n");
          }
        }
  }
}