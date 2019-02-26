using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace FPS 
{
	public class LightModel : MonoBehaviour 
	{
		public event Action<bool> LightStateChanged;

		public bool IsOn {get{ return light.enabled;}}
		private Light light;
		private LightView image;
		
		
		private void Awake() {
			light=GetComponent<Light>();
			image = FindObjectOfType<LightView>();			
		}

		public void On()
		{
			if(!light) return;
			light.enabled=true;
			
			if (LightStateChanged!=null){
				LightStateChanged(true);							
			}			 
		}

		public void Off()
		{
			if(!light) return;
			light.enabled=false;
			if (LightStateChanged!=null){
				LightStateChanged(false);				
			}
		}				
	}
}
