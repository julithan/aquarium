using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_StartPanel : MonoBehaviour
{



    /// <summary>
    /// ���۹�ư => ���̵� �����ϰ�
    /// </summary>
    public void OnClick_Start()
    {
        SceneManager.LoadScene("Scene_Game");
    }
}
