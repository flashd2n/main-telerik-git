using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace init
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
            catch (FileNotFoundException fnfe)
            {
                // exception handler for FileNotFoundException
                //we just inform then use that no such files was found
                Console.WriteLine($"{fileName} was not found");

            }
            catch (IOException ioe)
            {
                // exception handler for FileNotFoundException
                // we just print the stack trace on the conosle
                Console.WriteLine(ioe.StackTrace);
            }
        }
        
        static void ReadFile(string fileName)
        {

			    TextReader reader = new StreamReader(fileName);
			    string line = reader.ReadLine();
		    	Console.WriteLine(line);
			    reader.Close();
            try // handing the exception in the same method as the one who throws the exception
            {
            }
            catch (FileNotFoundException fnfe)
            {
                // exception handler for FileNotFoundException
                //we just inform then use that no such files was found
                Console.WriteLine($"{fileName} was not found");    
            }
            catch (IOException ioe)
            {
                // exception handler for FileNotFoundException
                // we just print the stack trace on the conosle
                Console.WriteLine(ioe.StackTrace);
            }

        }
    }
}