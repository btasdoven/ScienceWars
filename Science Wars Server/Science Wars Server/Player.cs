using System;
using System.Collections.Generic;
using Science_Wars_Server.Boards;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Skills;
using Science_Wars_Server.Statistics;

namespace Science_Wars_Server
{
    public class Player
    {
        public int id
        {
            get { return user.id; }            
        }

        public bool readyInQueue;
        public bool loadedTheGame;

        public int healthPoints;
        public int cash;
        public int income;

        public Game game;
        public User user;
        public Board board;

        List<Skill> skills;

        public enum PlayerState
        {
            ALIVE,
            DEAD
        };

        public PlayerState playerState;
        public bool destroyable;    // TODO player oyunu terkettiginde true donmesi gerek.
        
        public bool[] availableMinions;  //yapabilecegi minion listesi - userin icindeki availableMinions arrayinin root olan elemanlarini alacak, upgrade edildikce bu liste degisecek.
                                    // alinan root minionlardan sadece player'in science type'ina uygun olanlari true olacak. Diger minionlar unlocked bile olsalar, science type uygun degilse bu listede false olacaklar.
                                    //Upgrade edileni true yap, upgrade olani da false yap ki yapilabilecek minionlar listesinden parent olan cikmis olsun.

        public Player(User user, Game game)
        {   
            readyInQueue = false;
            loadedTheGame = false;

            this.user = user;
            this.game = game;
            this.board = (Board)Activator.CreateInstance(TypeIdGenerator.getBoardType(user.selectedBoardTypeId));
            board.player = this;

            cash = 20000;
            income = 1200;
            healthPoints = 10; // 5000000;
                
            playerState = PlayerState.ALIVE;

            initializeAvailableMinions();
        }

        public void initializeAvailableMinions()
        {
            Type rootMinionType = null;

            switch (getScienceType())
            {
                case ScienceType.BIO:
                    rootMinionType = typeof(BiologyMinion);
                    break;
                case ScienceType.PHYS:
                    rootMinionType = typeof(PhysicsMinion);
                    break;
                case ScienceType.CHEM:
                    rootMinionType = typeof(ChemistryMinion);
                    break;
            }

            availableMinions = new bool[user.unlockedMinions.Length];

            foreach (MinionNode minionNode in TypeIdGenerator.minionNodeInsts.Values)
            {
                if (minionNode.parent!= null && minionNode.parent.minionType == rootMinionType && user.unlockedMinions[ TypeIdGenerator.getMinionId(minionNode.minionType) ])
                {
                    availableMinions[TypeIdGenerator.getMinionId(minionNode.minionType)] = true;
                }
            }
        }

        public void step()
        {
            if(healthPoints == 0)
                playerState = PlayerState.DEAD;
            
            if (playerState == PlayerState.ALIVE)
            {
                stepSkills();
                stepBoard();
            }
        }

        private void stepBoard()
        {
            if(board != null)
                board.step();
        }

        private void stepSkills()
        {
            if(skills != null)
                foreach (var skill in skills)
                {
                    skill.step();
                }
        }

        public ScienceType getScienceType()
        {
            return user.selectedScienceTypeInQueue;
        }
    
        public bool trySpendCash(int amountToSpend)
        {
            if (cash >= amountToSpend)
            {
                // STATCODE
                PlayerStats pStats = this.game.statTracker.getPlayerStatsOfPlayer(this);
                pStats.moneySpend += amountToSpend;

                cash -= amountToSpend;
                return true;
            }
            return false;
        }

        public void addCash(int amountToAdd, bool notifyPlayer = false)
        {
            cash += amountToAdd;

            // STATCODE
            PlayerStats pStats = this.game.statTracker.getPlayerStatsOfPlayer(this);
            pStats.moneyEarned += amountToAdd;

            if (notifyPlayer)
                Messages.OutgoingMessages.Game.GCashAndIncomeInfo.sendMessage(this);
        }

        public void addIncome(int amountToAdd)
        {
            income += amountToAdd;
        }
        
        public void decreaseHealth(int amountToReduce)
        {
            healthPoints -= amountToReduce;
            if (healthPoints < 0)
                healthPoints = 0;

            Messages.OutgoingMessages.Game.GPlayerHealthInfo.sendMessage(game.players, this);
        }
   
        public void onDestroy()
        {
            // destroyable bu metod cagirildiktan sonra true olacak.
            // yapacagin son islemleri yap.
        }
    
    }
}

