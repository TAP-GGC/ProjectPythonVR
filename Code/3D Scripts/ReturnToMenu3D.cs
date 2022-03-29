using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu3D : MonoBehaviour
{
    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu3D");
    }
}
