using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard
{
	public class Hotkey : HashSet<Keys>
	{
		public static readonly Hotkey Empty = new Hotkey();

		public Hotkey() : base() { }

		public void CopyFrom(Hotkey source)
		{
			Clear();
			foreach(Keys key in source)
			{
				Add(key);
			}
		}

		/// <summary>
		/// From https://codereview.stackexchange.com/questions/139411/hash-calculation-for-array-of-long-values-in-c
		/// </summary>
		public override int GetHashCode()
		{
			int hash = 0;
			foreach(Keys key in this)
			{
				hash ^= ((int)key).GetHashCode();
			}
			
			return hash;
		}

		public override bool Equals(object obj)
		{
			if(GetType() != obj.GetType()) return false;

			Hotkey other = (Hotkey)obj;
			if(Count != other.Count) return false;

			return SetEquals(other);
		}

		public override string ToString()
		{
            if (!this.Any()) { return "∅"; }

			string result = string.Empty;
			for(int x = 0; x < Count; ++x)
			{
				result += this.ElementAt(x); // TODO: Way to get locale sensitive keyname?
				if(x < Count - 1) result += ", ";
			}

			return result;
		}
	}
}
