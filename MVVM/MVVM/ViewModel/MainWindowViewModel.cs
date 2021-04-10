using MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM.ViewModel
{
    public class MainWindowViewModel: BaseViewModel
    {
        private IClickModel clickModel;

        public MainWindowViewModel()
        {
            clickModel = new ClickModel();
        }

        public string ShownData
        {
            get
            {
                if (clickModel.Clicks >= 0)
                {
                    return Data.Strings[clickModel.Clicks % Data.Strings.Count];
                }
                else
                {
                    int c = clickModel.Clicks;
                    while(c < 0)
                    {
                        c += Data.Strings.Count;
                    }
                    return Data.Strings[c];
                }
            }

        }

        public void OnClickLeft(object sender, RoutedEventArgs e)
        {
            clickModel.OnClickLeft();
            NotifyPropertyChanged(nameof(ShownData));
        }

        public void OnClickRight(object sender, RoutedEventArgs e)
        {
            clickModel.OnClickRight();
            NotifyPropertyChanged(nameof(ShownData));
        }
    }

}
