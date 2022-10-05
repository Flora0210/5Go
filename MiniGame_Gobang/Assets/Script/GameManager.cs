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

<<<<<<< HEAD
        // �밢��üũ(LeftUp-->RightDown �Ʒ��κ�)
        for(int i = 4; i < 19; i++)
=======
        // �밢��üũ(LeftUp-->RightDown �Ʒ� ����)
        for(int i = 4; i < 18; i++)
>>>>>>> be852d85d814db17cefdafec6bb6f4b92c03f100
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
<<<<<<< HEAD
                            count = 1;
=======
                            currentRock = go_Array[templ, j].gameObject.tag;
                            count++;
>>>>>>> be852d85d814db17cefdafec6bb6f4b92c03f100
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

<<<<<<< HEAD
        // �밢��üũ(LeftUp-->RightDown ���κ�)___________������ʿ���!!
        for (int i =14 ; i>0 ; i--)
        {
            int templ = i;
           
            for (int j = 18; j >=i; j--)
=======
        // �밢��üũ(LeftUp-->RightDown �� ����)
        for (int i=0; i<=14; i++)
        {
            int templ = i;
            for (int j = 18; j>=i ; j--)
>>>>>>> be852d85d814db17cefdafec6bb6f4b92c03f100
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
<<<<<<< HEAD
                            count = 1;
=======
                            currentRock = go_Array[templ, j].gameObject.tag;
                            count++;
>>>>>>> be852d85d814db17cefdafec6bb6f4b92c03f100
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
<<<<<<< HEAD
                
            }
            
        }


        // �밢��üũ(RightUp-->LeftDown �Ʒ��κ�)
        for(int i = 0; i <=14; i++)
        {
            int templ = i;
            for(int j = 0; j <=18-i; j++)
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
                        if (currentRock == go_Array[templ, j].gameObject.tag)//
                        {
                            count++;
                            checkOverFive(count, currentRock);
                        }
                        else
                        {
                            count = 1;//
                            checkOverFive(count, currentRock);
                        }
                    }

                }
                else
                {
                    currentRock = "";//
                    count = 0;

                }
                templ++;
            }
        }

        // �밢��üũ(LeftUp-->RightDown ���κ�)

=======
            }
        }

        // �밢��üũ(RightUp-->LeftDown )
>>>>>>> be852d85d814db17cefdafec6bb6f4b92c03f100

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
