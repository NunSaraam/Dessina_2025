using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaycastShooter : MonoBehaviour
{
    public ParticleSystem flashEffect;                                                  //�߻� ����Ʈ ���� ����

    public AudioSource audioSource;                                                     //����� �ҽ�
    public AudioClip audioClip;                                                          //����� Ŭ��

    public int magazineCapcity = 30;                                                    //źâ�� ũ��
    private int currentAmmo;                                                            //���� �Ѿ� ����

    public TextMeshProUGUI ammoUI;                                                      //�Ѿ� ������ ��Ÿ�� TextMashProUGUI ����
    
    public Image relodingUI;                                                            //������ UI
    public float reloadTime = 2f;                                                       //������ �ð�
    private float timer = 0;                                                            //�ð� Ȯ�ο� Ÿ�̸� 
    private bool isReloading = false;                                                   //������ Ȯ�ο� bool ����

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = magazineCapcity;                                                  //���� �Ѿ��� ������ źâ�� ũ�⸸ŭ���� ����
        //ammoUI.text = currentAmmo + "/" + magazineCapcity;                          
        ammoUI.text = $"{currentAmmo}/{magazineCapcity}";                               //���� �Ѿ� ������ UI�� ǥ��
        relodingUI.gameObject.SetActive(false);                                         //������ UI ��Ȱ��ȭ
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentAmmo > 0 && isReloading == false)     //���� �Ѿ��� 0������ Ŭ ��
        {
            audioSource.PlayOneShot(audioClip);                                         //�߻� ���� ���
            currentAmmo--;                                                              //�Ѿ��� 1�� �Һ��Ѵ�.
            flashEffect.Play();                                                         //����Ʈ ���
            ammoUI.text = $"{currentAmmo}/{magazineCapcity}";                           //���� �Ѿ� ������ UI�� ǥ�� (�Ѿ� �Һ� �� ǥ��!!!)
            ShootRay();
        }

        if (Input.GetKeyDown(KeyCode.R))                                                //RŰ�� ������
        {
            isReloading = true;                                                         //������ ������ ����
            relodingUI.gameObject.SetActive(true);                                      //������ UI Ȱ��ȭ
        }

        if (currentAmmo <= 0)
        {
            isReloading = true;
            relodingUI.gameObject.SetActive(true);
        }

        if (isReloading == true)
        {
            Reloding();
        }
    }

    //���̰� �߻�Ǵ� �Լ�
    void ShootRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);                       //�߻��� Ray�� ������, ���� ���� (���� ī�޶󿡼� ���콺 Ŀ�� �������� �߻�)
        RaycastHit hit;                                                                 //Ray�� ���� ����� ������ ������ �����

        if(Physics.Raycast(ray, out hit))                                               //Raycast�� ��ȯ���� bool��, Ray�� �¾Ҵٸ� true ��ȯ
        {
            Destroy(hit.collider.gameObject);                                           //���� ��� ������Ʈ�� ����
        }
    }

    void Reloding()
    {
        timer += Time.deltaTime;

        relodingUI.fillAmount = timer / reloadTime;                                     //������ UI�� fill���� ���� ������� ������Ʈ

        if (timer >= reloadTime)                                                        //������ �ð��� ������ ���
        {
            timer = 0;
            isReloading = false;                                                        //�������� �Ϸ� ������ ǥ��
            currentAmmo = magazineCapcity;                                              //�Ѿ��� ä���ش�.
            ammoUI.text = $"{currentAmmo}/{magazineCapcity}";                           //���� �Ѿ� ������ ǥ��
            relodingUI.gameObject.SetActive(false);                                     //������ UI ������Ʈ�� ��Ȱ��ȭ
        }
    }
}
