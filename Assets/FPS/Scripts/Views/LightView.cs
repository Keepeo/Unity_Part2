using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
	public class LightView : MonoBehaviour 
	{
		public Color ColorOn;
		public Color ColorOff;

		private LightModel model;
		public Image image;		

		private void Awake() {
			image = GetComponent<Image>();
			model = FindObjectOfType<LightModel>();

			model.LightStateChanged += OnLightStateChanged;
		}

		private void OnLightStateChanged(bool state)	
		{
			image.color = state ? ColorOn : ColorOff;
			
		}
		
		private void OnDestroy() {
			if (model) model.LightStateChanged -=OnLightStateChanged;
		}

		private void Update() {
			if (model.IsOn)
			{
				image.fillAmount-=0.05f*Time.deltaTime;
			}
			else
			{
				image.fillAmount+=0.1f*Time.deltaTime;
			}
			if(image.fillAmount<=0)
			{
				model.Off();
			}
		}	    		
	}
}