using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustsceneManager : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
		StartCoroutine("Cutscene");
	}
	
	IEnumerator Cutscene() {
		text.text = "Hello, my name is Gerald Burke";
		yield return new WaitForSeconds(1);
		yield return new WaitUntil(() => Input.anyKey);
		text.text = "I studied game dev for a few years in college, but stopped when I realized I could learn better (and cheaper) on my own.";
		yield return new WaitForSeconds(1);
		yield return new WaitUntil(() => Input.anyKey);
		text.text = "Unfortunately that left me without a degree, and in America, you need one for just about any job that isn't terrible.";
		yield return new WaitForSeconds(1);
		yield return new WaitUntil(() => Input.anyKey);
		text.text = "Now I'm going back to finish school, this time focusing on computer science and my newfound love of programming.";
		yield return new WaitForSeconds(1);
		yield return new WaitUntil(() => Input.anyKey);
		text.text = "But I have a family and responsibilities, so I need to work full time to support my return to school.";
		yield return new WaitForSeconds(1);
		yield return new WaitUntil(() => Input.anyKey);
		text.text = "This game is about the financial, social, and time management anxiety that has been plaguing me since I started this process";
		yield return new WaitForSeconds(1);
		yield return new WaitUntil(() => Input.anyKey);
		text.text = "If you manage to win this game, let me know what you did, because I need all the help I can get for the next two years";
		yield return new WaitForSeconds(1);
		yield return new WaitUntil(() => Input.anyKey);
		text.text = "Thank you for reading, and thank you for playing.";
		yield return new WaitForSeconds(1);
		yield return new WaitUntil(() => Input.anyKey);
		SceneManager.LoadScene("SampleScene");
	}
}
