using System;

namespace taskThirteen
{
    class tastThirteen
    {
        static void Main()
        {
            string fullUrl = Console.ReadLine();

            string protocol = GetProtocol(fullUrl);
            string server = GetServer(fullUrl);
            string resource = GetResource(fullUrl);

            Console.WriteLine("[protocol] = " + protocol);
            Console.WriteLine("[server] = " + server);
            Console.WriteLine("[resource] = " + resource);

        }

        static string GetResource(string fullUrl)
        {
            int indexPre = fullUrl.IndexOf(@"//");
            string resource = null;
            int indexStart = fullUrl.IndexOf(@"/", indexPre + 2);
            resource = fullUrl.Substring(indexStart);
            return resource;
        }

        static string GetServer(string fullUrl)
        {
            int indexStart = fullUrl.IndexOf(@"//");
            string server = null;
            if (indexStart != -1)
            {
                int indexEnd = fullUrl.IndexOf(@"/", indexStart + 2);
                server = fullUrl.Substring(indexStart + 2, indexEnd - (indexStart + 2));
            }
            return server;
        }

        static string GetProtocol(string fullUrl)
        {
            int index = fullUrl.IndexOf(':');
            string protocol = null;
            if (index != -1)
            {
                protocol = fullUrl.Substring(0, index);
            }
            return protocol;
        }
    }
}
