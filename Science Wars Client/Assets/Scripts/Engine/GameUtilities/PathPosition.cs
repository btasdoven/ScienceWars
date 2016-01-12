namespace Assets.Scripts.Engine.GameUtilities
{
    public class PathPosition
    {
        public int pointIndex;
        public float ratio;

        public PathPosition(int pointIndex, float ratio)
        {
            this.pointIndex = pointIndex;
            this.ratio = ratio;
        }
    }
}
