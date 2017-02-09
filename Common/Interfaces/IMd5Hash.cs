using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IMd5Hash
    {
        string CalculateMD5Hash(string input);
    }
}
