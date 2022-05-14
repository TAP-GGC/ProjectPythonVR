using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController3D : MonoBehaviour
{
    [SerializeField] int sceneNum;
    public void loadLevel()
    {
        SceneManager.LoadScene(sceneNum);
    }
}
