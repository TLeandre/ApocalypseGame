using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chargement : MonoBehaviour {

    public Slider slider;
    public Text progressText;



	void Start ()
  {
	   StartCoroutine(LoadAsync());
	 }



    IEnumerator LoadAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Monde_1");

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;

            progressText.text = progress * 100 + "%";

            yield return null;
        }
    }



}
