using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnThoat : BaseButton
{
    protected string sceneName = "SceneLoading";
    protected override void OnClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(this.sceneName);

    }
}
