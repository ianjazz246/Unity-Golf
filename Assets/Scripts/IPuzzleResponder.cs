using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityGolf
{
	interface IPuzzleResponder
	{
		void OnSignalOn();
		void OnSignalOff();
	}
}
