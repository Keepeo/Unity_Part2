using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FPS
{
	public class TeammateController : MonoBehaviour
	{
		public static event Action<TeammateModel> TeammateSelected;
		private TeammateModel currentTeammate;

		public void MoveComand()
		{
			RaycastHit hit;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray, out hit))
			{
				var teammate = hit.collider.GetComponent<TeammateModel>();
				if (teammate) SelectTeammate(teammate);
				else if (currentTeammate) currentTeammate.SetDestination(hit.point);
			}
		}

		public void SelectTeammate(TeammateModel teammate)
		{
			currentTeammate = teammate;
			TeammateSelected?.Invoke(currentTeammate);
		}
	}
 
}

