using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinFormsCTech.Parser
{
    class ResponsibleExecutorsParserRKK : IResponsibleExecutorsParser
    {
        public ResponsibleExecutorStorage Parse(string[] textFromFileLines, ResponsibleExecutorStorage responsibleExecutorStorage)
        {
            responsibleExecutorStorage ??= new ResponsibleExecutorStorage();

            foreach (string line in textFromFileLines)
            {
                string name = getName(line);

                if (!responsibleExecutorStorage.ContainsEmployee(name))
                    responsibleExecutorStorage.Add(new ResponsibleExecutor(name, 0, 0));

                responsibleExecutorStorage.IncrementRKK(name);
            }

            return responsibleExecutorStorage;
        }

        private string getName(string line)
        {
            try
            {
                if (line.StartsWith("Климов Сергей Александрович"))
                {
                    return line[(line.IndexOf("\t") + 1)..(line.IndexOf(".", line.IndexOf(".")) + 3)];
                }
                else
                {
                    string surName = line[(line.IndexOf(" ", line.IndexOf(" ") + 1) + 1)..(line.IndexOf(" ", line.IndexOf(" ") + 1) + 2)] + ".";
                    string firstName = line[(line.IndexOf(" ") + 1)..(line.IndexOf(" ") + 2)] + ".";
                    string lastName = line[..line.IndexOf(" ")];
                    return lastName + " " + firstName + surName;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Не удалось распарсить имя в списке РКК.");
                throw new Exception("Can't parse name in RKK.");
            }
        }
    }
}
