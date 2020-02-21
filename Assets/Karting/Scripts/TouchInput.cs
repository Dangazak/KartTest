using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

namespace KartGame.KartSystems
{
	//Modificación de la clase input para que rsponda a las entradas tactiles
	public class TouchInput : MonoBehaviour, IInput
	{
		public float Acceleration
		{
			get { return m_Acceleration; }
		}
		public float Steering
		{
			get { return m_Steering; }
		}
		public bool BoostPressed
		{
			get { return m_BoostPressed; }
		}
		public bool FirePressed
		{
			get { return m_FirePressed; }
		}
		public bool HopPressed
		{
			get { return m_HopPressed; }
		}
		public bool HopHeld
		{
			get { return m_HopHeld; }
		}

		float m_Acceleration;
		float m_Steering;
		bool m_HopPressed;
		bool m_HopHeld;
		bool m_BoostPressed;
		bool m_FirePressed;

		bool m_FixedUpdateHappened;

		void Update ()
		{

			m_Steering = 0f;
			m_Acceleration = 0f;
			m_HopHeld = false;
			m_HopPressed = false;

			if (Input.touchCount > 0) {
				for (int i = 0; i < Input.touchCount; i++) {
					
					//comprobar si se esta tocando la parte derecha o izquierda de la pantalla y registrar la entrada de dirección
					if(Input.touches[i].position.x < Screen.width * 0.3) {
						m_Steering = -1f;
					} else if (Input.touches[i].position.x > Screen.width * 0.7) {
						m_Steering = 1f;
					}

					//comprobar si se esta tocando la parte superior o inferior de la pantalla y registrar la entrada de aceleración
					if(Input.touches[i].position.y < Screen.height * 0.3) {
						m_Acceleration = -1f;
					} else if (Input.touches[i].position.y > Screen.height * 0.7) {
						m_Acceleration = 1f;
					}

					//comprobar si se esta tocando la parte central de la pantalla y registrar la entrada de salto
					if((Input.touches[i].position.x > Screen.width * 0.3) && (Input.touches[i].position.x < Screen.width * 0.7) && (Input.touches[i].position.y > Screen.height * 0.3) && (Input.touches[i].position.y < Screen.height * 0.7)){
						m_HopHeld = true;
						//registrar si la entrada tactil acaba de comenzar
						if (Input.touches [i].phase == TouchPhase.Began)
							m_HopPressed = true;
					}
				}
			}
		}
	}
}