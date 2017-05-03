using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Credits : MonoBehaviour {
	public MovieTexture c;

	void Start() {
		GetComponent<RawImage>().texture = c as MovieTexture;
		c.Play();
		StartCoroutine(ReturnToMenu());
	}

	IEnumerator ReturnToMenu() {
		yield return new WaitForSeconds(33);
		SceneManager.LoadScene("Menu");
	}
}
