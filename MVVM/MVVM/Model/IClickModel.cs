using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public interface IClickModel
    {
        void OnClickLeft();

        void OnClickRight();

        int Clicks { get; }
    }
}
