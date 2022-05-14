using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void loadSandbox()
    {
        SceneManager.LoadScene(1);
    }
    public void loadLevels()
    {
        SceneManager.LoadScene(2);
    }
}
