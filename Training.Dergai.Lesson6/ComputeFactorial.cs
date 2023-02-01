namespace Training.Dergai.Lesson6
{
    public static class ComputeFactorial
    {
        public static uint Factorial(uint n)
        {
            if (n < 2) return 1;

            return n * Factorial(n - 1);
        }
    }
}
