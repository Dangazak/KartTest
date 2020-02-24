using System;
using UnityEngine;

namespace KartGame.Track
{
	
	public class Coin : MonoBehaviour
	{
		//capas en las que puede estar el kart para comprobar si hay colision
		[Tooltip ("The layers to check for a kart passing through this trigger.")]
		public LayerMask kartLayers;
		public GameObject coinController;

		void OnTriggerEnter (Collider other)
		{
			//Comprobar si la colision es con un objeto en las capas de el kart,
			//si es así destruir la moneda y llamar al controlador de monedas para contarla
			if (kartLayers.ContainsGameObjectsLayer (other.gameObject))
			{
				Destroy (gameObject);
				CoinController controller = coinController.GetComponent<CoinController> ();
				if (controller != null)
					controller.AddCoin();
			}
		}
	}
}
