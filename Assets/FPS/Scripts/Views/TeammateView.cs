using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FPS
{
	public class TeammateView : BaseSceneObject
	{
		private TeammateModel model;

		protected override void Awake() 
		{
			base.Awake();

			model = GetComponentInParent<TeammateModel>();
			IsVisible = false;

			TeammateController.TeammateSelected +=OnTeammateSelected;
		}

		private void OnTeammateSelected(TeammateModel teammate)
		{
			IsVisible = model == teammate;
		}

		private void OnDestroy() 
		{
			TeammateController.TeammateSelected -= OnTeammateSelected;
		}

	}
}

