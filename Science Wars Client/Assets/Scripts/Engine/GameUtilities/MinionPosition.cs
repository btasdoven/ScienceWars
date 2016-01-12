namespace Assets.Scripts.Engine.GameUtilities
{
    public class MinionPosition
    {
        public PathPosition pathPosition; // suan yurumekte oldugu yolun yuzde kacini yurudugunu tutar.
        public Board board; // suan yurumekte oldugu board

		public UnityEngine.Vector3 getLocalCoordinates()
		{
			return board.getPath().getLocalPosition( pathPosition);
		}

        public UnityEngine.Vector3 getWorldCoordinates()
        {
            return board.getPath().getWorldPosition(this);
        }
    }
}
