using System;

namespace Science_Wars_Server.Helpers
{
    static class Chronos
    {
        public static float deltaTime; // son 2 frame arasindaki zaman farkini gosterir. saniye cinsinden.
        static long interval;
        static DateTime lastTickTime = DateTime.MinValue;

        public static void setInterval(long msInterval)
        {
            interval = msInterval*10000;            
        }

        public static void waitForTheRightMoment()
        {
            
            float a = ((DateTime.UtcNow - lastTickTime).Ticks/10000);
            if( a > 10)
                Console.WriteLine(a.ToString());
            
            System.Threading.Thread.Sleep(25);           
            //while ((DateTime.UtcNow - lastTickTime).Ticks < interval);  // dogru zaman gelene kadar busy wait yapiyor. 
            //                                                            // En onemli thread bu oldugu icin polling den kacinmadim.
            //                                                            // gelistirilebilir.
            
            deltaTime = ((float)(DateTime.UtcNow - lastTickTime).Ticks) / (10000.0f*1000.0f); 
            
            lastTickTime = DateTime.UtcNow;
                       
        }
        
    }
}
