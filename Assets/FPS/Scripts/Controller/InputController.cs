﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
	public class InputController : BaseController 
	{
		private void Update() {		

			if(Input.GetButtonDown("SwitchLight"))
			Main.Instance.LigthController.SwitchLight();
			if (Input.GetButtonDown("ChangeWeapon"))
			Main.Instance.WeaponsController.ChangeWeapon();
			if (Input.GetButton("Fire1"))
			Main.Instance.WeaponsController.Fire();
			if (Input.GetButtonDown("TeammateCommand"))
			Main.Instance.TeammateController.MoveComand();
			
			
		}
	}
}