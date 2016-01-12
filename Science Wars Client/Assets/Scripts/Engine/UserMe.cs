using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.ScienceTrees.ScienceNodes;
namespace Assets.Scripts.Engine
{
    static class UserMe
    {
        static public User self;

        public static int physicsSciencePoint;
        public static int chemSciencePoint;
        public static int biologySciencePoint;

        public static bool[] unlockedTowers;              // TypeIdGenerator.getTowerIds.Count kadarlik yer al. Alttakileri de anlarsin artik. beyin lens degilse
        // Tower Type Id'sine gore 

        public static bool[] unlockedMinions;             // Minion Type Id'sine gore

        public static bool[] unlockedScienceNodes;         // ScienceNode type id'sine gore  

        public static void initializeUserMe(int id, string username, int physicsSciencePoint, int chemSciencePoint, int biologySciencePoint, bool[] unlockedScienceNodes)
        {
			self = new User(username, id, null);
            UserMe.physicsSciencePoint = physicsSciencePoint;
            UserMe.chemSciencePoint = chemSciencePoint;
            UserMe.biologySciencePoint = biologySciencePoint;
            UserMe.unlockedScienceNodes = unlockedScienceNodes;

            setUnlockedMinionsAndTowers(unlockedScienceNodes);
        }

        private static void setUnlockedMinionsAndTowers(bool[] unlockedScienceNodes)
        {
			//for the time being, I sat all the tower and minions as available
			unlockedMinions = new bool[TypeIdGenerator.getMinionCount()];
			unlockedTowers = new bool[TypeIdGenerator.getTowerCount()];
                        
            for (int i = 0; i < unlockedScienceNodes.Length; ++i)
                if (unlockedScienceNodes[i])
                    ScienceNode.scienceNodeInst[TypeIdGenerator.getScienceNodeTypes(i)].unlock();            
        }
        
    }
}
