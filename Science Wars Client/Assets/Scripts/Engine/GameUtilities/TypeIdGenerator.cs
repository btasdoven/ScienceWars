using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Engine.AreaEffects;
using Assets.Scripts.Engine.Effects.MinionEffects;
using Assets.Scripts.Engine.Effects.TowerEffects;
using Assets.Scripts.Engine.Messages.IncomingMessages;
using Assets.Scripts.Engine.Messages.OutgoingMessages;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Missiles;
using Assets.Scripts.Engine.Skills;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.Engine.ScienceTrees.ScienceNodes;
using Assets.Scripts.Engine.Towers.Physics;
using Assets.Scripts.Engine.Minions.Physics;
using System.IO;

namespace Assets.Scripts.Engine.GameUtilities
{
    public static class TypeIdGenerator
    {
        // yeni bir hashmap yarattiginda getter'ini yazmayi unutma!

        // <int, Type> hashmap'i client'in gonderdigi mesajlardaki id'den type'i bulmak icin
        // <Type, int> hashmap'i client'e id gonderirken Type'in id'sini bulmak icin.
        // o Type'in icinde id'yi tutamiyoruz cunku elimizde instance yok.

        private static Dictionary<int, IIncomingMessage> messageClasses;
        private static Dictionary<Type, int> messageIds;

        private static Dictionary<int, Type> areaEffectTypes;
        private static Dictionary<Type, int> areaEffectIds;

		private static Dictionary<int, Type> minionEffectTypes;
		private static Dictionary<Type, int> minionEffectIds;
		
		private static Dictionary<int, Type> towerEffectTypes;
		private static Dictionary<Type, int> towerEffectIds;

        private static Dictionary<int, Type> boardTypes;
        private static Dictionary<Type, int> boardIds;

        private static Dictionary<Type, MinionNode> minionNodeInsts;
        private static Dictionary<int, Type> minionTypes;
        private static Dictionary<Type, int> minionIds;
		private static Dictionary<int, Minion> minionClasses;

        private static Dictionary<int, Type> missileTypes;
        private static Dictionary<Type, int> missileIds;

        private static Dictionary<int, Type> skillTypes;
        private static Dictionary<Type, int> skillIds;

        private static Dictionary<Type, TowerNode> towerNodeInsts;      // birisi icini doldurmali
        private static Dictionary<int, Type> towerTypes;
        private static Dictionary<Type, int> towerIds;
		private static Dictionary<int, Tower> towerClasses;
                
        private static Dictionary<int, Type> scienceNodeTypes;
        private static Dictionary<Type, int> scienceNodeIds;

		private static Dictionary<int, Minion> minionInsts;
		private static Dictionary<int, Tower> towerInsts;



        static TypeIdGenerator()
        {
            messageClasses = generateIdClassHashMap<IIncomingMessage>();
            messageIds = generateTypeIdHashMap(typeof(IOutgoingMessage));

            areaEffectTypes = generateIdTypeHashMap<AreaEffect>();
            areaEffectIds = generateTypeIdHashMap(typeof(AreaEffect));

			minionEffectTypes = generateIdTypeHashMap<MinionEffect>();
			minionEffectIds = generateTypeIdHashMap(typeof(MinionEffect));
			
			towerEffectTypes = generateIdTypeHashMap<ITowerEffect>();
			towerEffectIds = generateTypeIdHashMap(typeof(ITowerEffect));

            boardTypes = generateIdTypeHashMap<Board>();
            boardIds = generateTypeIdHashMap(typeof(Board));

            minionTypes = generateIdTypeHashMap<Minion>();
            minionIds = generateTypeIdHashMap(typeof(Minion));
            minionNodeInsts = generateInheritanceMinionTreeHashMap<Minion>();
			minionClasses = generateIdClassHashMap<Minion>();

            missileTypes = generateIdTypeHashMap<Missile>();
            missileIds = generateTypeIdHashMap(typeof(Missile));

            skillTypes = generateIdTypeHashMap<Skill>();
            skillIds = generateTypeIdHashMap(typeof(Skill));

            towerTypes = generateIdTypeHashMap<Tower>();
            towerIds = generateTypeIdHashMap(typeof(Tower));
            towerNodeInsts = generateInheritanceTowerTreeHashMap<Tower>();
			towerClasses = generateIdClassHashMap<Tower>();

			/*
            towerNodeInsts[typeof(BallistaTower)].children.Add(towerNodeInsts[typeof(CatapultTower)]);
			towerNodeInsts[typeof(BallistaTower)].children.Add(towerNodeInsts[typeof(ElectricityTower)]);
			towerNodeInsts[typeof(BallistaTower)].children.Add(towerNodeInsts[typeof(BlackHoleTower)]);

			minionNodeInsts[typeof(PhysicsStudentMinion)].children.Add(minionNodeInsts[typeof(PhysicsMScStudentMinion)]);
			minionNodeInsts[typeof(PhysicsStudentMinion)].children.Add(minionNodeInsts[typeof(RoboHookMinion)]);
			minionNodeInsts[typeof(PhysicsStudentMinion)].children.Add(minionNodeInsts[typeof(QuantumSoldierMinion)]);
			minionNodeInsts[typeof(PhysicsMScStudentMinion)].children.Add(minionNodeInsts[typeof(RetentiveTankMinion)]);
             */

            ScienceNode.scienceNodeInst = generateTypeClassHashMap<ScienceNode>();
            scienceNodeTypes = generateIdTypeHashMap<ScienceNode>();
            scienceNodeIds = generateTypeIdHashMap(typeof(ScienceNode));

			minionInsts = generateIdClassHashMap<Minion>();
			towerInsts = generateIdClassHashMap<Tower> ();

            //TypeIdGenerator.createLogFile("LogClient.txt");
        }


        #region StaticGeneratorFunctions

        private static Dictionary<Type, int> generateTypeIdHashMap(Type type)
        {
            Dictionary<Type, int> resultDictionary = new Dictionary<Type, int>();

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);


            KeyValuePair<string, Type>[] nameTypePairs = new KeyValuePair<string, Type>[types.Count()];

            // and put them in a static dictionary.
            int index = 0;
            foreach (Type t in types)
                nameTypePairs[index++] = new KeyValuePair<string, Type>(t.Name, t);

            Array.Sort(nameTypePairs, keyComparison);

            KeyValuePair<string, Type> pair;

            for (int i = 0; i < nameTypePairs.Count(); i++)
            {
                pair = nameTypePairs[i];

                resultDictionary.Add(pair.Value, i);
            }
            return resultDictionary;
        }

        public static Dictionary<int, T> generateIdClassHashMap<T>()
        {
            Dictionary<int, T> resultDictionary = new Dictionary<int, T>();
            Type type = typeof(T);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);


            KeyValuePair<string, Type>[] nameTypePairs = new KeyValuePair<string, Type>[types.Count()];

            // and put them in a static dictionary.
            int index = 0;
            foreach (Type t in types)
                nameTypePairs[index++] = new KeyValuePair<string, Type>(t.Name, t);

            Array.Sort(nameTypePairs, keyComparison);

            KeyValuePair<string, Type> pair;

            for (int i = 0; i < nameTypePairs.Count(); i++)
            {
                pair = nameTypePairs[i];

                // check uniqueness of the typeId
                T msg = (T)Activator.CreateInstance(pair.Value);
                resultDictionary.Add(i, msg);

            }
            return resultDictionary;
        }

        public static Dictionary<Type, T> generateTypeClassHashMap<T>()
        {
            Dictionary<Type, T> resultDictionary = new Dictionary<Type, T>();
            Type type = typeof(T);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);

            for (int i = 0; i < types.Count(); i++)
            {
                T msg = (T)Activator.CreateInstance(types.ElementAt(i));
                resultDictionary.Add( types.ElementAt(i) , msg);

            }
            return resultDictionary;
        }

        private static Dictionary<int, Type> generateIdTypeHashMap<T>()
        {
            Dictionary<int, Type> resultDictionary = new Dictionary<int, Type>();
            Type type = typeof(T);

            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);


            KeyValuePair<string, Type>[] nameTypePairs = new KeyValuePair<string, Type>[types.Count()];

            // and put them in a static dictionary.
            int index = 0;
            foreach (Type t in types)
                nameTypePairs[index++] = new KeyValuePair<string, Type>(t.Name, t);

            Array.Sort(nameTypePairs, keyComparison);

            for (int i = 0; i < nameTypePairs.Count(); i++)
            {
                resultDictionary.Add(i, nameTypePairs[i].Value);

            }
            return resultDictionary;
        }

		private static Dictionary<Type, TowerNode> generateInheritanceTowerTreeHashMap<T>()
		{
			Dictionary<Type, TowerNode> resultDictionary = new Dictionary<Type, TowerNode>();
			Type type = typeof(T);
			
			var types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
					.Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);
			
			var abstypes = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
					.Where(p => type.IsAssignableFrom(p) && p.IsClass && p.IsAbstract);
			
			List<Type> abstTypes = new List<Type>();
			foreach (Type t in abstypes)
				abstTypes.Add(t);
			
			
			List<Type> typeList = new List<Type>();
			List<Type> typeNodes = new List<Type>();
			List<Type> nextTypes = new List<Type>();
			List<Type> removeList = new List<Type>();
			List<TowerNode> currentNodes = new List<TowerNode>();
			List<TowerNode> nextNodes = new List<TowerNode>();
			
			foreach (Type t in abstTypes)
			{
				TowerNode newNode = new TowerNode();
				newNode.towerType = t;
				newNode.parent = null;
				currentNodes.Add(newNode);
				typeNodes.Add(t);
			}
			
			
			foreach (Type t in types)
				typeList.Add(t);
			
			for (int i = 0; i < abstTypes.Count; i++)
			{
				if (abstTypes[i] != type)
					resultDictionary.Add(abstTypes[i], currentNodes[i]);
			}
			
			while (typeList.Count > 0)
			{
				for(int j = 0; j < typeNodes.Count; j++)
				{
					for (int i = 0; i < typeList.Count; i++)
					{
						if (typeList[i].BaseType == typeNodes[j])
						{
							TowerNode newNode = new TowerNode();
							newNode.towerType = typeList[i];
							newNode.parent = currentNodes[j];
							currentNodes[j].children.Add(newNode);
							
							nextNodes.Add(newNode);
							nextTypes.Add(typeList[i]);
							
							resultDictionary.Add(typeList[i], newNode);
							
							removeList.Add(typeList[i]);
							
						}
					}
					
				}
				
				foreach (Type t in removeList)
					typeList.Remove(t);
				removeList.Clear();
				
				currentNodes.Clear();
				currentNodes.AddRange(nextNodes);
				nextNodes.Clear();
				
				
				typeNodes.Clear();
				typeNodes.AddRange(nextTypes);
				nextTypes.Clear();
			}
			
			
			return resultDictionary;
		}
		
		private static Dictionary<Type, MinionNode> generateInheritanceMinionTreeHashMap<T>()
		{
			Dictionary<Type, MinionNode> resultDictionary = new Dictionary<Type, MinionNode>();
			Type type = typeof(T);
			
			var types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
					.Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);
			
			var abstypes = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
					.Where(p => type.IsAssignableFrom(p) && p.IsClass && p.IsAbstract);
			
			List<Type> abstTypes = new List<Type>();
			foreach (Type t in abstypes)
				abstTypes.Add(t);
			
			
			List<Type> typeList = new List<Type>();
			List<Type> typeNodes = new List<Type>();
			List<Type> nextTypes = new List<Type>();
			List<Type> removeList = new List<Type>();
			List<MinionNode> currentNodes = new List<MinionNode>();
			List<MinionNode> nextNodes = new List<MinionNode>();
			
			foreach (Type t in abstTypes)
			{
				MinionNode newNode = new MinionNode();
				newNode.minionType = t;
				newNode.parent = null;
				currentNodes.Add(newNode);
				typeNodes.Add(t);
			}
			
			
			foreach (Type t in types)
				typeList.Add(t);
			
			for (int i = 0; i < abstTypes.Count; i++)
			{
				if (abstTypes[i] != type)
					resultDictionary.Add(abstTypes[i], currentNodes[i]);
			}
			
			while (typeList.Count > 0)
			{
				for (int j = 0; j < typeNodes.Count; j++)
				{
					for (int i = 0; i < typeList.Count; i++)
					{
						if (typeList[i].BaseType == typeNodes[j])
						{
							MinionNode newNode = new MinionNode();
							newNode.minionType = typeList[i];
							newNode.parent = currentNodes[j];
							currentNodes[j].children.Add(newNode);
							
							nextNodes.Add(newNode);
							nextTypes.Add(typeList[i]);
							
							resultDictionary.Add(typeList[i], newNode);
							
							removeList.Add(typeList[i]);
							
						}
					}
					
				}
				
				foreach (Type t in removeList)
					typeList.Remove(t);
				removeList.Clear();
				
				currentNodes.Clear();
				currentNodes.AddRange(nextNodes);
				nextNodes.Clear();
				
				
				typeNodes.Clear();
				typeNodes.AddRange(nextTypes);
				nextTypes.Clear();
			}
			
			
			return resultDictionary;
		}


        private static int keyComparison(KeyValuePair<string, Type> keyValuePair, KeyValuePair<string, Type> valuePair)
        {
            return String.Compare(keyValuePair.Key, valuePair.Key, System.StringComparison.Ordinal);
        }

        #endregion

        #region StaticGetters

        static public int getMessageId(Type type)
        {
            return messageIds[type];
        }

        static public IIncomingMessage getMessageClass(int id)
        {
            return messageClasses[id];
        }

        static public int getAreaEffectId(Type type)
        {
            return areaEffectIds[type];
        }

        static public Type getAreaEffectClass(int id)
        {
            return areaEffectTypes[id];
        }

		static public int getMinionEffectId(Type type)
		{
			return minionEffectIds[type];
		}
		
		static public Type getMinionEffectClass(int id)
		{
			return minionEffectTypes[id];
		}
		
		static public int getTowerEffectId(Type type)
		{
			return towerEffectIds[type];
		}
		
		static public Type getTowerEffectClass(int id)
		{
			return towerEffectTypes[id];
		}

        static public int getBoardId(Type type)
        {
            return boardIds[type];
        }

        static public Type getBoardType(int id)
        {
            return boardTypes[id];
        }

		static public int getMinionCount()
		{
			return minionIds.Count;
		}

        static public int getMinionId(Type type)
        {
            return minionIds[type];
        }

        static public Type getMinionType(int id)
        {
            return minionTypes[id];
        }

		static public Minion getMinionClass(int id)
		{
			return minionClasses[id];
		}

        static public int getMissileId(Type type)
        {
            return missileIds[type];
        }

        static public Type getMissileType(int id)
        {
            return missileTypes[id];
        }

        static public int getSkillId(Type type)
        {
            return skillIds[type];
        }

        static public Type getSkillType(int id)
        {
            return skillTypes[id];
        }

		static public int getTowerCount()
		{
			return towerIds.Count;
		}

        static public int getTowerId(Type type)
        {
            return towerIds[type];
        }

        static public Type getTowerType(int id)
        {
            return towerTypes[id];
        }

		static public Tower getTowerClass(int id)
		{
			return towerClasses[id];
		}

        static public int getScienceNodeIds(Type type)
        {
            return scienceNodeIds[type];
        }

        static public Type getScienceNodeTypes(int id)
        {
            return scienceNodeTypes[id];
        }

        static public MinionNode getMinionNodeInsts(Type type)
        {
            return minionNodeInsts[type];
        }

        static public TowerNode getTowerNodeInsts(Type type)
        {
            return towerNodeInsts[type];
        }

		static public Minion getMinionInsts(int id)
		{
			return minionInsts [id];
		}

		static public Tower getTowerInsts(int id)
		{
			return towerInsts[id];
		}

        #endregion

        public static void createLogFile(string filename)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                file.WriteLine("===== Incoming Messages =====");
                foreach (var item in messageClasses)
                    file.WriteLine(item.Key.ToString() + ": " + item.Value.ToString());

                file.WriteLine("===== Outgoing Messages =====");
                foreach (var item in messageIds)
                    file.WriteLine(item.Value.ToString() + ": " + item.Key.ToString());

                file.WriteLine("===== Minions =====");
                foreach (var item in minionTypes)
                    file.WriteLine(item.Key.ToString() + ": " + item.Value.ToString());

                file.WriteLine("===== Towers =====");
                foreach (var item in towerTypes)
                    file.WriteLine(item.Key.ToString() + ": " + item.Value.ToString());
            }
        }
    }
}
