using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelManager
{
    public class ObservableObject : INotifyPropertyChanged
    /*
     INotifyPropertyChanged :
        -notif a client that the value of a prop has changed
        -obsObj created for handling the updates on property
     */

    {
        public event PropertyChangedEventHandler PropertyChanged;

        //template pentru ca primesc ca parametrii fie double, fie fontStyle, fontFamily etc...
        public void OnPropertyChanged<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            property = value;
            var handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        //CallerMemberName  atribute = orice membru apeleaza functiam acesta preia numele .
    }
}
