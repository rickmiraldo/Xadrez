using System;
using System.Collections.Generic;
using System.Text;

namespace Xadrez.TabuleiroEntities
{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string m) : base(m)
        {
        }
    }
}
