using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KartGame.Track
{
	
	public class CoinController : MonoBehaviour
	{
		//variable con las monedas recolectadas
		public int coins = 0;
		//referencia al texto con la cuenta de monedas recolectadas
		public Text coinsText;

		//Añadir una moneda a la cuenta de monedas, actualizar el texto con las monedas recolectadas, 
		//actualizar la cuenta de monedas totales en el controlador del juego y guardar localmente los datos de monedas totales
		public void AddCoin(){
			coins++;
			coinsText.text = "Coins: " + coins.ToString();
			GameControl.control.totalCoins++;
			GameControl.control.Save ();
		}
	}
}
