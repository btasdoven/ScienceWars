namespace Science_Wars_Server.Minions.Physics
{
    class FrankenScientistMinion_LateWork : FrankenScientistMinion_PennyPincher
    {
        private const int _totalSpawnLimit = 2; // omur boyunca max kac scrap golem uretebilir?

        protected override int TOTAL_SPAWN_LIMIT { get { return _totalSpawnLimit; } }

        public FrankenScientistMinion_LateWork(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {            
        }

    }
}
