using Assets.Scripts.Engine.AreaEffects;
using Assets.Scripts.Engine.Effects.MinionEffects;
using Assets.Scripts.Engine.Effects.TowerEffects;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Missiles;
using Assets.Scripts.Engine.Skills;
using Assets.Scripts.Engine.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Physics;
using Assets.Scripts.Engine.Minions.Biology;
using Assets.Scripts.Engine.Towers.Physics;
using Assets.Scripts.Engine.Towers.Biology;

namespace Assets.Scripts.Engine.IGUI
{
    public interface IGraphics
    {
        #region Server Connection

        void tryingToConnect();
        void connectionFailed();
        void connectionSuccessful();

        #endregion

        #region Login Screen

        void loadLogin();
        void loginFailed();
        void loginSucceeded();

        #endregion

        #region Lobby Screen

        void loadLobby();
        void displayChatMessage(string senderUsername, string message);
        void displayQueueResult(bool result);
        void displayGReadyStateRequest(float seconds);
        void displayReadyStates(bool result);
		void displayCancelQueueResult(bool result);

        #endregion

        #region Game

        void loadGame();
        void destroyGame();

        void quitGameState(Game.GameState gameState);
        void enterGameState(Game.GameState gameState);
        
        void displayStartCountDown(float seconds);
        void updateCashAndIncome();
        void updateNextRandomMinionTime();
        void updateNextPaymentTime();
        void updatePlayerHealth(Player player);
        
		void displayGameChatMessage(string senderUsername, string message);
		void displayEndGameStatistics();

        // TOWER
        void createTower(Tower tower);
        void addTowerEffect(Tower tower, ITowerEffect effect);
        void upgradeTower(Tower tower);

        // MINION
        void createMinion(Minion minion);
        void addMinionEffect(Minion minion, MinionEffect effect);
        void minionHit(Minion minion, Missile missile);
        void minionDied(Engine.Minions.Minion minion);
        void destroyMinion(Minion minion);
        void upgradeMinion(Type oldMinionType, Type upgradedMinionType);

        // MISSILE
        void createMissile(Missile missile);
        void destroyMissile(Missile missile);

        // AREA EFFECT
        void createAreaEffect(AreaEffect areaEffect);
        void destroyAreaEffect(AreaEffect areaEffect);

        // SKILL
        void skillCooldownEnded(Skill skill);
        void skillActivated(Skill skill);

        // TOWER SPECIFIC
        void tower_laserTower_target(LaserTower tower, Minion targetMinion);
        void tower_laserTower_untarget(LaserTower tower, int untargetMinionId);
        void tower_droseraTower_bite(DroseraTower tower, Minion targetMinion);
        void tower_blackHoleTower_teleportStart(Minion minion);
        void tower_blackHoleTower_teleportEnd(Minion minion);

        // MINION SPECIFIC
        void minion_quantumSoldier_teleport(Minion minion);
        void minion_frankenScientist_spawn(FrankenScientistMinion parentMinion, ScrapGolemMinion spawnedMinion);
        void minion_frankenScientist_stackChanged(FrankenScientistMinion minion, int stackCount);
        void minion_zombie_raise(ZombieMinion zombieMinion);
        void minion_mutantEightLegged_spawn(MutantEightLeggedMinion parentMinion,ICollection<MutantEightLeggedSpawningMinion> spawnings);


        #endregion
    }
}
