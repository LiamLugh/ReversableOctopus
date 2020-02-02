using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IHasChanged
{
	[SerializeField] Transform slots;
    GameManager gm;



    // Use this for initialization
    void Start()
	{
        gm = FindObjectOfType<GameManager>();
        HasChanged();
	}

	#region IHasChanged implementation
	public void HasChanged()
	{
		foreach (Transform slotTransform in slots)
		{
			GameObject item = slotTransform.GetComponent<Slot>().item;
			if (item)
			{
                gm.removeAnimal(item.name);
                //here we remove the dropped animal from the inventory(icon) and boot it off the ship via the cannon :D
                Object.Destroy(item);
            }
        }
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