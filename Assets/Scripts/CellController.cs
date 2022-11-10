using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Skymare
{
    public class CellController : MonoBehaviour
    {
        [SerializeField] TextMesh txtNumber;
        [SerializeField] int cellPoint;
        public int CellPoint =>cellPoint;
        [SerializeField] int pX;//so hang
        [SerializeField] int pY;//so cot
        [SerializeField] bool isCellConnected;
        public bool IsCellConnected => isCellConnected;//xem co ket noi voi khoi khong
        private Vector2 cellPos;//vi tri cua o nay


        //public int pX;//hang thu pX ,cot pY
        //public int pY;
        public float posX;
        public float posY;
        void Awake()
        {
            
        }
        public void SetPositionXY(int x,int y)
        {
            pX = x;
            pY = y;
            float xx = GameField.instance.Element.transform.position.x + y * GameField.instance.Distance;
            float yy = GameField.instance.Element.transform.position.y - x * GameField.instance.Distance;
            cellPos = new Vector2(xx, yy);
        }    
        public Vector2 GetPosXY()//lay vi tri cua o hien tai
        {
            return cellPos;
        }    
        public void SetNumber(int number)
        {
            txtNumber.text = $"{number}";//<=> number.Tostring();
            cellPoint = number;
        }    
        public void  PointerDown()
        {
            GameManager.instance.IsPointerDown = true;
            //LineDraw.instance.posCells.Add(this.transform.position);
            //int pointCell = int.Parse(gameObject.GetComponentInChildren<TextMesh>().text);
            //LineDraw.instance.pointCells.Add(pointCell);
            //SetValueIJ();

        }  
        public void PointerEnter()
        {
            if (GameManager.instance.IsPointerDown == true)
            {
                Vector2 posCell = this.transform.position;
                int count = LineDraw.instance.pointCells.Count;
                if (Vector2.Distance(posCell, LineDraw.instance.posCells[count - 1]) <= 2.25f && posCell != LineDraw.instance.posCells[count - 1])
                {
                    int pointCell = int.Parse(gameObject.GetComponentInChildren<TextMesh>().text);
                    if (count >= 2)
                    {
                        if (posCell == LineDraw.instance.posCells[count - 2])
                        {
                            LineDraw.instance.pointCells.RemoveAt(count - 1);
                            LineDraw.instance.posCells.RemoveAt(count - 1);
                            int sumInt = LineDraw.instance.ExpressionList();
                            string sumString = sumInt.ToString();
                            if(count >2)
                            UIManager.instance.ScoreList.GetComponent<Text>().text = sumString;
                            else
                            {
                                UIManager.instance.ScoreList.GetComponent<Text>().text = UIManager.instance.TotalScore.GetComponent<Text>().text;
                            }    
                            GameManager.instance.cell = this.gameObject;
                            return;
                        }
                          
                    }
                    if (count == 1)
                    {
                        if (pointCell == LineDraw.instance.pointCells[0])
                        {
                            LineDraw.instance.pointCells.Add(pointCell);
                            LineDraw.instance.posCells.Add(this.transform.position);
                            int sumInt = LineDraw.instance.ExpressionList();
                            string sumString = sumInt.ToString();
                            UIManager.instance.ScoreList.GetComponent<Text>().text = sumString;
                            GameManager.instance.cell = this.gameObject;
                            SetValueIJ();
                        }
                    }
                    else//count > 1
                    {
                        if (pointCell == LineDraw.instance.pointCells[count - 1] || pointCell == 2 * LineDraw.instance.pointCells[count - 1])
                        {
                            LineDraw.instance.pointCells.Add(pointCell);
                            LineDraw.instance.posCells.Add(this.transform.position);
                            int sumInt = LineDraw.instance.ExpressionList();
                            string sumString = sumInt.ToString();
                            UIManager.instance.ScoreList.GetComponent<Text>().text = sumString;
                            GameManager.instance.cell = this.gameObject;
                            SetValueIJ();
                        }
                    }
                    
                }
            }
        }    
        public void PointerUp()
        {
            GameManager.instance.IsPointerDown = false;
            if (LineDraw.instance.pointCells.Count > 1)
            {
                int totalScoreInt = int.Parse(UIManager.instance.TotalScore.GetComponent<Text>().text);
                int listScoreInt = LineDraw.instance.ExpressionList();
                totalScoreInt += listScoreInt;
                string totalString = totalScoreInt.ToString();
                UIManager.instance.TotalScore.GetComponent<Text>().text = totalString;
                UIManager.instance.ScoreList.GetComponent<Text>().text = totalString;

                //gameObject.GetComponentInChildren<TextMesh>().text = listScoreInt.ToString();
                GameManager.instance.cell.GetComponentInChildren<TextMesh>().text = listScoreInt.ToString();
                GameObject obj = GameManager.instance.cell;
                int i = (int)((GameField.instance.Element.transform.position.y - obj.transform.position.y) / GameField.instance.Distance);
                int j = (int)((obj.transform.position.x - GameField.instance.Element.transform.position.x) / GameField.instance.Distance);
                GameField.instance.squares[i, j] = listScoreInt;
            }
            //GameField.instance.FillSquare();
            //GameField.instance.FillCells();
            LineDraw.instance.pointCells.Clear();
            LineDraw.instance.posCells.Clear();
            
        }    
        public void PointerExit()
        {
           // Debug.Log(this.transform.position);
        }    
        void SetValueIJ()
        {
            int i = (int)((GameField.instance.Element.transform.position.y - this.transform.position.y) / GameField.instance.Distance);
            int j = (int)((this.transform.position.x-GameField.instance.Element.transform.position.x ) / GameField.instance.Distance);
            GameField.instance.squares[i, j] = 0;
        }    
    }
}
