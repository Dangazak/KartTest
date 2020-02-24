using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace KartGame.Track
{
	
	public class LoadSceneOnClick : MonoBehaviour {


		//Carga la escena selectionada usando el número de escena del indice en las preferencias del build
		public void LoadByIndex (int sceneIndex){
			SceneManager.LoadScene (sceneIndex);
		}
	}
}
