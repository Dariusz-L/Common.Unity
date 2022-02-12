namespace Common.Unity.Physics
{
    public static class AccelerationEquations
    {
        public static float CalculateVelocityX2(float acceleration, float time)
        {
            return acceleration * time * 2;
        }
    }
}
