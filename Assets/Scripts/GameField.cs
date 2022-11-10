using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace Skymare
{
    public class GameField : MonoBehaviour
    {
        //int row = 8, col = 5;
        const int row = 8;
        const int col = 5;
        [SerializeField] GameObject m_element;
        Vector2 posStart;
        float posStartY;
        float distance;
        public GameObject[,] cells= new GameObject[row,col];
        public int[,] squares = new int[row,col];
        public static GameField instance;
        public float Distance => distance;
        public GameObject Element => m_element;
        
        void Awake()
        {
            MakeSingleton();
            posStart= m_element.transform.position;
            distance = 2*Mathf.Abs(posStart.x)/(col-1);
            posStartY= posStart.y;
            Debug.Log(m_element.transform.position);
             
        }
        void Start()
        {
            for(int i=0; i < row; i++)
            {
                posStart.y = posStartY - i * distance;
                for(int j=0; j < col; j++)
                {
                    GameObject obj = Instantiate(m_element, new Vector2(posStart.x + j * distance, posStart.y), Quaternion.identity);
                    obj.transform.parent = gameObject.transform;
                    int number = Random.Range(1, 6);//random from 1 to 5
                    number = (int)Mathf.Pow(2, number);
                    obj.GetComponentInChildren<TextMesh>().text = number.ToString();
                    obj.SetActive(true);
                    squares[i, j] = number;
                    cells[i, j] = obj;


                }    
            }
           
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
        bool isFullCol(int k)
        {
            for(int i=0;i<row;i++)
            {
                if (squares[i, k] == 0) return false;
            }
            return true;
        }    
        void FillCol(int k)//lam day cot thu k
        {
            while(isFullCol(k) ==false)
            {
                if(squares[0,k] == 0)
                {
                    squares[0,k] = (int)Mathf.Pow(2, Random.Range(1, 6));
                }    
                for(int i=row -1;i>=1;i--)
                {
                    if (squares[i,k]==0)
                    {
                        for(int count=i;count>=1;count--)
                        {
                            squares[count, k] = squares[count - 1, k];
                        }
                        squares[0, k] = (int)Mathf.Pow(2, Random.Range(1, 6));
                    }    
                }    
            }    
                
        }   
        public void FillSquare()//lam day bang
        {
            for(int count =0; count < col;count++)
            {
                FillCol(count);
            }    
        }    
        public void FillCells()
        {
            for(int i=0;i<row;i++)
            {
                for(int j=0;j<col;j++)
                {
                    cells[i, j].GetComponentInChildren<TextMesh>().text = squares[i, j].ToString();
                }    
            }    
        }    

    }
    
}

