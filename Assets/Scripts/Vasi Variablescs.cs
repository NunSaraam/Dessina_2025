using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VasiVariablescs : MonoBehaviour
{
    public int gold = 0;                        //������
    public float Hp = 100.0f;                   //�Ǽ��� (�Ҽ����� �ִ� ����, ���� 'f'�ʼ�)
    public string playerName = "ȫ�浿";        //���ڿ� (������ ����)
    private bool isAlive = true;                //���� (��/������ ��Ÿ��)


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("���ӽ���");                  //����Ƽ ����׿� �޽��� ���
        // == �� ���� ���� �� true
        // != �� ���� �ٸ��� true
        // > ���� ���� �� ũ�� true
        // < ������ ���� �� ũ�� true
        // >= ���� ���� ũ�ų� ������ true
        // <= ������ ���� ũ�ų� ������ true

        if (gold > 50)
        {
            Debug.Log("�������� ������ �� �ֽ��ϴ�.");
        }
        else if ( gold == 40 )  //if�ȿ� ������ ���� �ƴ� �� �� ������ ���̷���
        {
            Debug.Log("��尡 40�� ���� �� �Դϴ�. 10 ��常 �� ������ �� �� �־��!");
        }
        //else  //if ���� ������ ���� �ƴ� ��
        //{
        //  Debug.Log("��尡 �����մϴ�.");
        //} 
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("���� ������");
        if(Input.GetKeyDown(KeyCode.Space))         //space�� ������ �� true
        {
            gold = gold + 10;                       //gold�� 10�� �߰��Ѵ�.
            Debug.Log("���� ��� : "  +  gold);     //����Ƽ �ֿܼ� ���� gold���� ����ش�.
        }
    }
}
