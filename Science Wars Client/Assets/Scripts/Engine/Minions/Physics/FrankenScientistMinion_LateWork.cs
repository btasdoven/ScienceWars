using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
	public class FrankenScientistMinion_LateWork : FrankenScientistMinion_PennyPincher
	{
        public FrankenScientistMinion_LateWork()
            : base()
		{			
		}
		
		public override string getName ()
		{
			return "Late Work Frankenscientist";
		}
	}
}
