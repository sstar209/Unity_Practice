using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public Slider progressbar;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;

        //play를 비동기식으로 불러옴(본 게임 실행)
        //이때 LoadSceneAsync가 AsycnOperation을 반환하니 담아줌

        AsyncOperation operation = SceneManager.LoadSceneAsync("Demo");
        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            yield return null;
            //로딩바가 꽉 차지 않았을 때
            if(progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }

            //로딩바가 거의 꽉 찼을 때
            else if(operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }

            //로딩바가 꽉 찼을 때
            if(progressbar.value >= 1f)
            {
                operation.allowSceneActivation = true;
            }               
        }
    }
}
