
namespace repasoProgEV2
{
    public delegate int Calculator(int value1, int value2);

    public class repasoDelegados
    {
        private static int Calc(int value1, int value2, Calculator calculator)
        {
            return calculator(value1, value2); 
        }

        public static void Repaso()
        {
            Console.WriteLine("LAMBDA CALCUTATOR");
            Console.WriteLine();
            Console.Write("Dame el primer valor....: ");
            int value1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Dame el segundo valor...: ");
            int value2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Elige una opción [1] SUMA [2] RESTAR [3] MUL [4] DIV [5] MOD : ");
            int operation = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (operation)
            {
                case 1:
                    int resultA = Calc(value1, value2, (value1, value2) => value1 + value2);
                    Console.Write("La suma de {0} y {1} es: {2}", value1, value2, resultA);
                    break;
                case 2:
                    int resultB = Calc(value1, value2, (value1, value2) => value1 - value2);
                    Console.Write("La resta de {0} y {1} es: {2}", value1, value2, resultB);
                    break;
                case 3:
                    int resultC = Calc(value1, value2, (value1, value2) => value1 * value2);
                    Console.Write("La multiplicación de {0} y {1} es: {2}", value1, value2, resultC);
                    break;
                case 4:
                    int resultD = Calc(value1, value2, (value1, value2) => value1 / value2);
                    Console.Write("La división de {0} y {1} es: {2}", value1, value2, resultD);
                    break;
                case 5:
                    int resultE = Calc(value1, value2, (value1, value2) => value1 % value2);
                    Console.Write("El resto de la división de {0} y {1} es: {2}", value1, value2, resultE);
                    break;
            }
            Console.WriteLine();
        }
    }
}
