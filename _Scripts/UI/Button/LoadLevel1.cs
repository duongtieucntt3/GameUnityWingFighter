using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1 : BaseButton
{
    protected override void OnClick()
    {
        SceneManager.LoadScene("Level1");
    }
}
