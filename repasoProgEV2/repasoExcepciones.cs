
namespace repasoProgEV2
{
    public class repasoExcepciones
    {

        public void respasoExcepcion(int value1, int value2)
        {
            try
            {
                repasoDelegados.Calc(value1, value2, (value1, value2) => value1 + value2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Fin");
            }
        }
    }
}

