using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Physics_Metrology
{
    public class Impulse_NavigationFlyoutMenuItem
    {
        public Impulse_NavigationFlyoutMenuItem()
        {
            TargetType = typeof(Impulse_NavigationFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}