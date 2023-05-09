using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_10_EdytorIkon_Baza
{
    partial class Picture
    {
        public override string ToString()
        {
            return $"{Name} ({Width}, {Height})";
        }
    }
}
