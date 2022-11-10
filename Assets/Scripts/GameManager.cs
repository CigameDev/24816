using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skymare
{

    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public GameObject cell = null;
        private bool isPointerDown =false;

        public bool IsPointerDown { get => isPointerDown; set => isPointerDown = value; }

        void Awake()
        {
            MakeSingleton();
        }

        void MakeSingleton()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }    
        

    }
}