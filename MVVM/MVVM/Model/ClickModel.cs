using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public class ClickModel : IClickModel
    {
        public int Clicks { get; private set; }

        public void OnClickLeft()
        {
            Clicks--;
        }

        public void OnClickRight()
        {
            Clicks++;
        }


    }
}
