using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string sceneToChangeTo;

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneToChangeTo);
    }
}
