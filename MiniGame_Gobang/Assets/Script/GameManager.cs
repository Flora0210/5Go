using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isBlackTurn = true;
    public Text count_Text;

    public GameObject[,] go_Array = new GameObject[19,19];//C#�迭
    bool isCurrentPosisNull = false;// ������ġ�� null�̴�? = �ƴ�! 
    int count = 0;
    string currentRock = "";
    public bool isGameFinish = false;

    public GameObject finishPopUp;
    private void Awake()
    {
        Instance = this;
        
    }
   

    public void CheckGameFinish()
    {
        // �������� 5���̻��̸� ���� ���� (üũ �Լ�)
        // ���� üũ
        for (int i = 0; i < 19; i++)
        {
            Debug.Log(i + "��° ĭ �� Ž��");
            for (int j = 0; j < 19; j++)
            {
                if(go_Array[i,j] != null)
                {
                    if (currentRock == "")
                    {
                        currentRock = go_Array[i, j].gameObject.tag;
                        count++;
                        checkOverFive(count, currentRock);
                    }
                    else
                    {
                        if (currentRock == go_Array[i, j].gameObject.tag)
                        {
                            count++;
                            checkOverFive(count, currentRock);
                        }
                        else
                        {
                            count = 1;
                            currentRock = go_Array[i, j].gameObject.tag;
                        }
                    }
                }

                else
                {
                    currentRock = "";
                    count = 0;
                    //Debug.Log("�� ã�Ҵ�");
                }
            }
        }

        // ����üũ
        for (int j = 0; j < 19; j++)
        {
            Debug.Log(j + "��° ĭ �� Ž��");
            for (int i = 0; i < 19; i++)
            {
                if (go_Array[i, j] != null) // ���𰡸� �߰��ߴ�!
                {
                    if (currentRock == "") // ���� ã������ �ٵϵ��� ����!(������ ã���ִ� ���� ������)
                    {
                        currentRock = go_Array[i, j].gameObject.tag; // ���� ã������ �ٵϵ��� ���� �߰��� �ٵϵ�(��/��) �� �����Ѵ�.
                        count++; // �ϴ� 1�� �߰������� count ����
                        checkOverFive(count, currentRock);
                    } 
                    else
                    {
                        if (currentRock == go_Array[i, j].gameObject.tag)
                        {
                            count++;
                            checkOverFive(count, currentRock);
                        }
                        else
                        {
                            count = 1;
                            currentRock = go_Array[i, j].gameObject.tag;
                        }
                    }
                }

                else
                {
                    currentRock = "";
                    count = 0;
                    //Debug.Log("�� ã�Ҵ�");
                }
            }
        }

        // �밢��üũ(LeftUp-->RightDown �Ʒ� ����)
        for(int i = 4; i < 18; i++)
        {
            int templ = i;
            for(int j = 0; j <= i; j++)
            {
                if (go_Array[templ, j] != null)
                {
                    if (currentRock == "")
                    {
                        currentRock = go_Array[templ, j].gameObject.tag;
                        count++;
                        checkOverFive(count, currentRock);
                    }
                    else
                    {
                        if (currentRock == go_Array[templ, j].gameObject.tag)
                        {
                            count++;
                            checkOverFive(count, currentRock);
                        }
                        else
                        {
                            currentRock = go_Array[templ, j].gameObject.tag;
                            count++;
                            checkOverFive(count, currentRock);
                        }


                    }
                }
                else
                {
                    currentRock = "";
                    count = 0;
                }
                templ--;
            }
        }

        // �밢��üũ(LeftUp-->RightDown �� ����)
        for (int i=0; i<=14; i++)
        {
            int templ = i;
            for (int j = 18; j>=i ; j--)
            {
                if (go_Array[templ, j] != null)
                {
                    if (currentRock == "")
                    {
                        currentRock = go_Array[templ, j].gameObject.tag;
                        count++;
                        checkOverFive(count, currentRock);
                    }
                    else
                    {
                        if (currentRock == go_Array[templ, j].gameObject.tag)
                        {
                            count++;
                            checkOverFive(count, currentRock);
                        }
                        else
                        {
                            currentRock = go_Array[templ, j].gameObject.tag;
                            count++;
                            checkOverFive(count, currentRock);
                        }


                    }
                }
                else
                {
                    currentRock = "";
                    count = 0;
                }
                templ++;
            }
        }

        // �밢��üũ(RightUp-->LeftDown )

    }

    void checkOverFive(int count, string currentRock)
    {
        if(count >= 5)
        {
            Debug.Log("Finish. count : "+count);
            finishPopUp.SetActive(true);
            finishPopUp.transform.GetChild(0).GetComponent<Text>().text = currentRock+ " �¸�!!";
            Time.timeScale = 0;
            isGameFinish = true;
        }
        
    }
}
