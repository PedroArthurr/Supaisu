#region Libraries
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
#endregion
namespace PedroArthur
{
    public class Popup : MonoBehaviour
    {
        #region Variables
        [SerializeField] bool correct;
        #endregion

        #region MonoBehaviour methods
        void Start()
        {
            Destroy(gameObject, 2);
        }
        void Update()
        {
            if (correct)
            {
                LeanTween.moveLocalY(gameObject, 2000, 1);
                LeanTween.moveLocalX(gameObject, 2000, 1);
            }
            else
            {
                LeanTween.moveLocalY(gameObject, 2000, 1);
                LeanTween.moveLocalX(gameObject, -2000, 1);
            }
        }
        #endregion

        #region Custom methods

        #endregion
    }
}