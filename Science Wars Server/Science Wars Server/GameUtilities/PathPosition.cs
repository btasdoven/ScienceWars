namespace Science_Wars_Server.GameUtilities
{
    public class PathPosition
    {
        public int pointIndex;  // pointIndex yerine curve index tutarsak, her frame de curveIndex*3 islemini yapmak zorunda kaliyoruz. Verimli olsun diye curveIndex yerine point index tutuyorum, her bir ilerlemede bu deger 3 artiyor.
        public float ratio;

        public PathPosition(int pointIndex, float ratio)
        {
            this.pointIndex = pointIndex;
            this.ratio = ratio;
        }

        public PathPosition clone()
        {
            return new PathPosition(pointIndex, ratio);
        }

    }
}
