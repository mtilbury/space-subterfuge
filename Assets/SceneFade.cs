using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
    public Animator animator1;
    public Animator animator2;

    private int levelToLoad;

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator1.SetTrigger("FadeOut");
        animator2.SetTrigger("FadeOut");

        StartCoroutine(OnFadeComplete());
    }

    private IEnumerator OnFadeComplete()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(levelToLoad);
    }
}
