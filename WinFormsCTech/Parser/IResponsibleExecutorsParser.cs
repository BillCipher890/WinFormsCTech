using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsCTech.Parser
{
    interface IResponsibleExecutorsParser
    {
        public ResponsibleExecutorStorage Parse(string[] textFromFileLines, ResponsibleExecutorStorage responsibleExecutorStorage);
    }
}
