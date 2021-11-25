using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class PascalmainFlyoutMenuItem
    {
        public PascalmainFlyoutMenuItem()
        {
            TargetType = typeof(PascalmainFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}