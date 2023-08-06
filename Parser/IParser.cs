using ParserForMyApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserForMyApp.Parser
{
    public interface IParser
    {
        Task StartParse(ParserContext _context);

    }
}
