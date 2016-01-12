using Assets.Scripts.Engine.Missiles;
using Assets.Scripts.GUI.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GUI.Missiles
{
    public abstract class MissileGUIImpl : IMissileGUI
    {
        protected GameObject childStaticMissileObject;
        protected GameObject childStaticMissileHitEffectObject;

        protected Missile missile;
        protected GameObject missileObject;
        
        protected bool destroyable = false;

        public virtual void createMissile(Missile missile)
        {
            this.missile = missile;
            missile.tag = this;
            missileObject = (GameObject)GameObject.Instantiate(childStaticMissileObject, missile.position, Quaternion.identity);
        }

        public virtual void step()
        {
            if (destroyable == false)
            {
                if (checkIfDestroyed())
                    return;
                missileObject.transform.position = missile.position;
                if (missile.targetMinion != null)
                    missileObject.transform.rotation = Quaternion.LookRotation(
                        missile.targetMinion.getWorldHeadPosition() - missile.position, new Vector3(0, 1, 0));
            }
        }

        public abstract void loadResources();

        public bool checkIfDestroyed()
        {
            if (missile.destroyable)
            {
                destroyMissile();
                return true;
            }
            return false;
        }

        public virtual void destroyMissile()
        {
            destroyable = true;
            // missile minion'a carptiginda cikacak olan effect. Bu effectin icindeki script objeyi birkac saniye sonra yok ediyor.
            if (childStaticMissileHitEffectObject != null)
                GameObject.Instantiate(childStaticMissileHitEffectObject, missile.position, Quaternion.identity);

            GameObject.Destroy(missileObject);
        }

        public virtual bool isDestroyable()
        {
            return destroyable;
        }
    }
}
