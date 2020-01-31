using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, IHasChanged
{
	[SerializeField] Transform slots;

	// Use this for initialization
	void Start()
	{
		HasChanged();
	}

	#region IHasChanged implementation
	public void HasChanged()
	{
		System.Text.StringBuilder builder = new System.Text.StringBuilder();
		foreach (Transform slotTransform in slots)
		{
			GameObject item = slotTransform.GetComponent<Slot>().item;
			if (item)
			{
				builder.Append(item.name);
			}
		}
		//inventoryText.text = builder.ToString();
		//here we remove the dropped animal from the inventory(icon) and boot it off the ship via the cannon :D
	}
	#endregion
}


namespace UnityEngine.EventSystems
{
	public interface IHasChanged : IEventSystemHandler
	{
		void HasChanged();
	}
}