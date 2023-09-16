using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void GoToLevel()
    {
        AudioManager.instance.Play("buttonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
