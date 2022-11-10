using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

namespace Skymare
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;
        [SerializeField] Text m_scoreList;
        [SerializeField] Text m_totalScore;
        public Text ScoreList => m_scoreList;
        public Text TotalScore => m_totalScore;
        void Awake()
        {
            MakeSingleton();
        }


        void MakeSingleton()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        void Update()
        {

        }
    }
}
