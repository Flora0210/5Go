using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click_Pos : MonoBehaviour
{
    public GameObject go_black;
    public GameObject go_white;
    //public GameObject go_aiBlack;
    //public GameObject go_aiWhite;

    public int index_X;
    public int index_Y;

    public bool IsClicked = false;//�ߺ�����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (GameManager.Instance.isBlackTurn&& !IsClicked && !GameManager.Instance.isGameFinish)
        {
            GameObject black = Instantiate(go_black, transform.position, Quaternion.identity);
            GameManager.Instance.go_Array[index_X,index_Y] = black;
            GameManager.Instance.isBlackTurn = false;
            IsClicked = true;

            GameManager.Instance.CheckGameFinish();
            Debug.Log("�뵹 ��ȯ");

            //StartCoroutine(AiWhiteRock());//
        }
        else if(!GameManager.Instance.isBlackTurn && !IsClicked && !GameManager.Instance.isGameFinish)
        {
            GameObject white = Instantiate(go_white, transform.position, Quaternion.identity);
            GameManager.Instance.go_Array[index_X, index_Y] = white;
            GameManager.Instance.isBlackTurn = true;
            IsClicked = true;

            GameManager.Instance.CheckGameFinish();
            Debug.Log("�鵹 ��ȯ");

            //StartCoroutine(AiBlackRock());//
        }
       
    }
    
}
