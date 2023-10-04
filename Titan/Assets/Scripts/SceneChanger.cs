using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    FadeInOut fade;

    private void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    public IEnumerator _ChangeScene(int sceneID)
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneID);
    }

    public void MoveToScene(int sceneID)
    {
        StartCoroutine(_ChangeScene(sceneID));
        /*SceneManager.LoadScene(sceneID);*/
    }
}