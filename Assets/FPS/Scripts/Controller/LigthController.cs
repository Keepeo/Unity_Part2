using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
	public class LigthController : BaseController 
	{
		private LightModel model;
		private void Awake() {
			model = FindObjectOfType<LightModel>();
			model.Off();			
		}
		public void SwitchLight()
		{
			if (model.IsOn) model.Off();
			else model.On();
		}

	}
}