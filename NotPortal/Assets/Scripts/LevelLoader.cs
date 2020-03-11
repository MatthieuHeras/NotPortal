using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Animator anim = default;
    [SerializeField] private float animationDelay = 1f;
    public void Win()
    {
        StartCoroutine(WinCoroutine());
    }

    private IEnumerator WinCoroutine()
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(animationDelay);
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
