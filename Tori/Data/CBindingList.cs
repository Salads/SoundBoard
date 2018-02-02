using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundboard.Data
{
	/// <summary>
	/// Alternate version of BindingList that adds a "ItemRemoved" event that passes the removed item in the event.
	/// </summary>
	public class CBindingList<T> : BindingList<T>
	{
		public event EventHandler<ItemRemovedArgs<T>> RemovingItem;

		protected override void RemoveItem(int index)
		{
			T deletedItem = Items[index];
			RemovingItem?.Invoke(this, new ItemRemovedArgs<T>(deletedItem));

			base.RemoveItem(index);
		}
	}

	public class ItemRemovedArgs<T> : EventArgs
	{
		public T RemovedItem { get; private set; }

		public ItemRemovedArgs(T removedItem)
		{
			RemovedItem = removedItem;
		}
	}
}
