using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chainedExceptions
{
    class Startup
    {
        static void Main()
        {
            string fileName = "wrongFileName.txt";

            try //handling exception in the main method
            {
                ReadFile(fileName);
            }
            catch (ApplicationException exc)
            {
                Console.WriteLine($"Something EVEN WORSE");
                Console.WriteLine(exc.Message);
            }
        }

        static void ReadFile(string fileName)
        {



            try //handling exception in the main method
            {
            TextReader reader = new StreamReader(fileName);
            string line = reader.ReadLine();
            Console.WriteLine(line);
            reader.Close();
                
            }
            catch (Exception e)
            {
                throw new ApplicationException($"HORRIBLE", e);
            }


        }
    }
}