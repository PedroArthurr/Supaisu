#region bibliotecas
using UnityEngine; using System.Collections; using System.Collections.Generic; 
#endregion
namespace PedroArthur { 
[CreateAssetMenu(fileName = "New Kana Database", menuName = ("Kana Database"))]
public class KanaDatabase : ScriptableObject
  {
        #region Dados:
        public List<WordDatabase> tempList = new List<WordDatabase>();
        #endregion
        #region Comentarios e créditos
        /*
          ■
          ╔══════════════════════════════════════════════════════|>
          ║IG: @pedro.arthur.pa 
          ║Twitter: @PedroArthurDev
          ║Itch.io: PedroArthur
          ╚══════════════════════════════════════════════════════|>
          ■
        */
        #endregion
    }
}