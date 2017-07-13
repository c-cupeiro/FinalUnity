using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Controller : MonoBehaviour {

	public void ChangeScene(string nameScene){
		print ("Change to Scene --> " + nameScene);
		SceneManager.LoadScene (nameScene);
	}

	public void Exit(){
		print ("Exit game"); 
		Application.Quit ();
	}
}
