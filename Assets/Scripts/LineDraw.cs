using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Skymare
{
    public class LineDraw : MonoBehaviour
    {
        public static LineDraw instance;
        private LineRenderer lineRenderer;
        private Vector2 MousePos;
        private Vector2 StartPos;
        public  List<Vector2> posCells = new List<Vector2>();
        public  List<int>pointCells = new List<int>();
        void Awake()
        {
            MakeSingleton();
           
        }
        void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
        }


        void Update()
        {
            DrawLine();
        }
        
        void DrawLine()
        {
            lineRenderer.positionCount = posCells.Count;
            if (posCells.Count == 0) return;
            for(int i=0;i<posCells.Count;i++)
            {
                lineRenderer.SetPosition(i,new Vector3(posCells[i].x, posCells[i].y, 0f));
            }    
        }
        public int ExpressionList()
        {
            int sum = 0;
            for(int i=0;i<pointCells.Count;i++)
            {
                sum += pointCells[i];
            }
            float temp = Mathf.Log(sum, 2);
            int temp1 = (int)Mathf.Round((float)temp);
            sum = (int)Mathf.Pow(2, temp1);
            return sum;
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
    }
}
