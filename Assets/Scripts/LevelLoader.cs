using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public string nombreNivel;

    public void LoadSceneOnClick() {
        SceneManager.LoadScene(nombreNivel);
    }
}
