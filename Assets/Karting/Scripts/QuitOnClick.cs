using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.Track
{
	public class QuitOnClick : MonoBehaviour {


		//Cerrar la aplicacion si se está ejecutando independientemente o para la ejecución si se lanzó desde el editor de Unity
		public void Quit () {
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
			Application.Quit();
			#endif
		}
	}
}
