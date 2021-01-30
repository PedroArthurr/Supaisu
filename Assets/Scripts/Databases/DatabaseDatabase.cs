#region bibliotecas
using UnityEngine; using System.Collections; using System.Collections.Generic; 
#endregion
namespace PedroArthur { 
[CreateAssetMenu(fileName = "Novo DatabaseDatabase", menuName = ("DatabaseDatabase"))]
public class DatabaseDatabase : ScriptableObject
  {
        #region Dados:

        public List<Database> tempList = new List<Database>();
        #endregion
        
    }
}