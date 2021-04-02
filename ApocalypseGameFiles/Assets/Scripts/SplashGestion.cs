using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashGestion : MonoBehaviour {

	// Use this for initialization
	void Start () {

        StartCoroutine (Splash());

	}

    IEnumerator Splash ()
    {
        yield return new WaitForSeconds (3);
        SceneManager.LoadScene("Menu");
    }

}
