using Assets.Scripts.Engine.Effects.MinionEffects;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GUI.MinionEffects
{
    class NitrogenBombEffectGUI : IMinionEffectGUI
    {
        private static GameObject staticSpriteContainer;

        private GameObject spriteContainer ;
        private Minion minion;
        private MinionEffect effect;
        bool destroyable = false;

        public void createMinionEffect(Engine.Minions.Minion minion, Engine.Effects.MinionEffects.MinionEffect minionEffect)
        {
            spriteContainer = (GameObject) GameObject.Instantiate(staticSpriteContainer, minion.getWorldPosition(), Quaternion.identity);
            this.minion = minion;
            this.effect = minionEffect;
        }

        public bool isDestroyable()
        {
            return destroyable;
        }

        public void step()
        {
            if(destroyable == false)
            {
                spriteContainer.transform.position = minion.getWorldPosition();
                if( effect.remainingTime <= 0 || minion.minionState == Minion.MinionState.DEAD || minion.destroyable == true)
                    onDestroy();
            }
        }

        private void onDestroy()
        {
            GameObject.Destroy(spriteContainer,2f);
            destroyable = true;
        }

        public void loadResources()
        {
            staticSpriteContainer = (GameObject)Resources.Load("3Ds/MinionEffects/NitrogenBombEffect/IceExplosion");
        }
    }
}
