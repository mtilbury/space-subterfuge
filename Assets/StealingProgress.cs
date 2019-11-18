using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StealingProgress : MonoBehaviour
{

    public Image progressBar;
    [SerializeField] float currentProgress = 0f;
    float _maxProgress = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        progressBar.fillAmount = currentProgress / _maxProgress;
    }

    public bool AddProgress(float progress) {
        currentProgress = Mathf.Min(currentProgress + progress, _maxProgress);
        return currentProgress >= _maxProgress;
    }

    public bool RemoveProgress(float progress) {
        currentProgress = Mathf.Max(currentProgress - progress, 0);
        return currentProgress <= 0;
    }
}
