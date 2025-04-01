using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefabs;                                            //���� ������Ʈ(������)

    public float generateTime = 3f;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(targetPrefabs);                                             //���� ������Ʈ�� Scene�� �����Ѵ�.
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;                                                //timer �������� deltaTime�� ���� ���� �ð� ����

        if(timer < 0)                                                           //timer�� 0���� �۰ų� ���� ��
        {
            timer = generateTime;                                   

            float xPosition = Random.Range(-10f, 10f);                          //-10 ~ 10 ������ ������ �Ǽ����� xPosition�� ����
            Vector3 newPosition = new Vector3(xPosition, 0, 0);                 //������ ���Ӱ� ���� Position ��
            Instantiate(targetPrefabs, newPosition, Quaternion.identity);       //���� �������� newPosition ��ġ�� ������
        }
    }
}
