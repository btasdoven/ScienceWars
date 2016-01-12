using System;
using System.Collections.Generic;

namespace Assets.Scripts.Engine
{
    static class PlayerMe
    {
        public static int cash;
        public static int income;
        public static Player self;

		public static List<Type> availableMinionTypes;//yapabilecegi minion listesi - userin icindeki availableMinions arrayinin root olan elemanlarini alacak, upgrade edildikce bu liste degisecek.
                                                 //Upgrade edileni true yap, upgrade olani da false yap ki yapilabilecek minionlar listesinden parent olan cikmis olsun.
        
		public static List<Type> availableTowerTypes; // yapabilecegi tower listesi.
    }
}
