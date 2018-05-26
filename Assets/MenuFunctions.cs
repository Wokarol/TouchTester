using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour {

	[SerializeField] GameObject loadingPage;

	private void Start () {
		if (loadingPage != null) {
			loadingPage.SetActive(false);
		}
	}

	public void LoadScene (string name) {
		if(loadingPage != null) {
			loadingPage.SetActive(true);
		}
		SceneManager.LoadScene(name);
	}

}
