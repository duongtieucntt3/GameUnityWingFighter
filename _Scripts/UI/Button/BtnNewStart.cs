using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnNewStart : BaseButton
{

    protected string sceneName = "Level1";
    protected override void OnClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(this.sceneName);

    }
}
