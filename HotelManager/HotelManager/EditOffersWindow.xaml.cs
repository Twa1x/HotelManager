using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelManager
{
    /// <summary>
    /// Interaction logic for EditOffersWindow.xaml
    /// </summary>
    public partial class EditOffersWindow : Window
    {
        public EditOffersWindow()
        {
            InitializeComponent();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DeleteBtn.IsEnabled = true;
            EditBtn.IsEnabled = true;
        }
    }
}
