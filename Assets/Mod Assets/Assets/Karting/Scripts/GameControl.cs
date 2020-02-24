using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

namespace KartGame.Track
{

	public class GameControl : MonoBehaviour {

		public static GameControl control;
		//referencia a la cadena de mejor tiempo
		public Text bestTimeText;
		//referencia a la cadena de monedas totales recolectadas
		public Text totalCoinsText;
		//Variable del mejor tiempo
		[HideInInspector]public float bestTime;
		//Variable del numero de monedas totales recolectadas
		[HideInInspector]public int totalCoins;


		void Awake () {
			//Comprobar si ya existe una instancia de GameControl, si ya existe destruir esta e inicializar la que ya existe
			//y si no crear una referencia estática de esta e inicializarla
			if (control == null) {
				DontDestroyOnLoad (gameObject);
				control = this;
				inicialize ();
			} else if (control != this) {
				GameControl.control.bestTimeText =  GameObject.Find("BestTime").GetComponent( typeof(Text) ) as Text;
				GameControl.control.totalCoinsText =  GameObject.Find("TotalCoins").GetComponent( typeof(Text) ) as Text;
				GameControl.control.inicialize();
				Destroy (gameObject);
			}
		}

		//Inicializar las variables necesarias, cargar los datos guardados localmente y mostrar el tiempo de la mejor vuelta si existe
		public void inicialize () {
			bestTime = 0;
			totalCoins = 0;

			Load ();

			if (bestTime >= 0)
				bestTimeText.text = bestTime.ToString(".##");
			if (totalCoins >= 0)
				totalCoinsText.text = totalCoins.ToString();
			
		}



		//Guardar datos localmente
		public void Save(){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/gameInfo.dat", FileMode.OpenOrCreate);

			PlayerData data = new PlayerData ();

			data.bestTime = bestTime;
			data.totalCoins = totalCoins;

			bf.Serialize (file, data);
			file.Close();
		}

		//Cargar los datos guardados localmente
		public void Load(){
			if (File.Exists (Application.persistentDataPath + "/gameInfo.dat")) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
				PlayerData data = (PlayerData)bf.Deserialize (file);
				file.Close ();

				bestTime = data.bestTime;
				totalCoins = data.totalCoins;
			}
		}
	}

	//clase usada para guardar los datos del juego localmente
	[Serializable]
	class PlayerData
	{
		//variables publicas
		public float bestTime;
		public int totalCoins;
	}
}