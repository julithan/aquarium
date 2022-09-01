using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GamePanel : MonoBehaviour
{

    public Animator[] ins_animator = null;
    public GameObject[] ins_modelArr = null;


    //선택된 인덱스
    private int currentIndex = 0;


    //해당모델 불러오기(껐다키기)
    public void OnClick_Model(int inIndex)
    {
        for (int i = 0; i < ins_modelArr.Length; i++)
            ins_modelArr[i].SetActive(i == inIndex);

        currentIndex = inIndex;
    }


    //해당 애니메이션을 작동한다. => 이건 모델의 에니메이터를 설정하기나름
    public void OnClick_Animation(int inIndex)
    {
        ins_animator[currentIndex].SetInteger("animation", inIndex);
    }

    

}
