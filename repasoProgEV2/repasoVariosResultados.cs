
namespace repasoProgEV2
{
    internal class repasoVariosResultados
    {
        public static bool Calculate(int a, int b, out int result1, out int result2, out int result3, out int result4)
        {
            result1 = a + b;
            result2 = a - b;
            result3 = a * b;
            result4 = 0;

            if (b != 0) {
                result4 = a / b;
                return true;
            }

            return false;
        }
    }
}

