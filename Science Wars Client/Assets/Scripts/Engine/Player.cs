using System.Collections.Generic;
using System.Security.Policy;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Skills;

namespace Assets.Scripts.Engine
{
    	public class    Player
    {
        public int id
        {
            get { return user.id; }
        }

        public int healthPoints;
        public User user;
        public Board board;
        private List<Skill> skills = new List<Skill>();

        public enum PlayerState
        {
            ALIVE,
            DEAD
        };
        public PlayerState playerState;
        
        public bool destroyable;    // player oyunu terkettiginde true olmasi lazim.

        public Player(int hps, Board board)
        {
            healthPoints = hps;
            this.board = board;
			board.player = this;
            playerState = PlayerState.ALIVE;
        }

        public void step()
        {
            if (healthPoints == 0 && playerState != PlayerState.DEAD)
            {
                playerState = PlayerState.DEAD;

                //you lost
                if (this == PlayerMe.self)
                    Assets.Scripts.Engine.Messages.OutgoingMessages.Game.GEndGameStatisticsRequest.sendMessage();
            }

            if (board != null)
                stepBoard();

            if (playerState == PlayerState.ALIVE)
                stepSkills();
        }

        private void stepBoard()
        {
            if (board != null)
            {
                board.step();
                if (board.tag != null)
                {
                    board.tag.step();
                }
            }
        }

        private void stepSkills()
        {
            foreach (var skill in skills)
            {
                skill.step();
            }
        }

        public ScienceType getScienceType()
        {
            return board.scienceType;
        }
    }
}