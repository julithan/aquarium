using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GamePanel : MonoBehaviour
{

    public Animator[] ins_animator = null;
    public GameObject[] ins_modelArr = null;


    //���õ� �ε���
    private int currentIndex = 0;


    //�ش�� �ҷ�����(����Ű��)
    public void OnClick_Model(int inIndex)
    {
        for (int i = 0; i < ins_modelArr.Length; i++)
            ins_modelArr[i].SetActive(i == inIndex);

        currentIndex = inIndex;
    }


    //�ش� �ִϸ��̼��� �۵��Ѵ�. => �̰� ���� ���ϸ����͸� �����ϱ⳪��
    public void OnClick_Animation(int inIndex)
    {
        ins_animator[currentIndex].SetInteger("animation", inIndex);
    }

    

}
