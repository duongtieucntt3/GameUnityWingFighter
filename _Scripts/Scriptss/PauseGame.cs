using UnityEngine;

public class PauseGame : DuongMonoBehaviour
{
    private bool isPaused = false;

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
            {
                ResumeGame();
                UIInventory.Instance.Close();
            }
            else
            {
                Pause();
                UIInventory.Instance.Open();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0f; 
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; 
        isPaused = false;
    }
}
