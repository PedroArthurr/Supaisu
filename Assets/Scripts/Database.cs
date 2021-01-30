#region bibliotecas
using UnityEngine; using System.Collections; using System.Collections.Generic; 
#endregion
namespace PedroArthur
{ 
[CreateAssetMenu(fileName = "New Database", menuName = ("Database"))]
public class Database : ScriptableObject
  {
    public string language;
        #region Dados:
        //[Header(language)]   
        
        public List<string> japanese = new List<string>();
        public List<string> portuguese = new List<string>();

        public int listLenght;


        #endregion
        #region Comentarios e créditos
        /*
          ■
          ╔══════════════════════════════════════════════════════|>
          ║IG: @pedro.arthur.pa 
          ║Twitter: @PedroArthurPA
          ║Itch.io: PedroArthur
          ╚══════════════════════════════════════════════════════|>
          ■
        */
        #endregion
    }
}


//
//
//
//