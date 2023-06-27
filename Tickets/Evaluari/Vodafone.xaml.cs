using Asgard.Repositories;
using Asgard.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Asgard.Tickets.Evaluari
{
    /// <summary>
    /// Interaction logic for Vodafone.xaml
    /// </summary>
    public partial class Vodafone : Page
    {
        public Vodafone()
        {
            InitializeComponent();
            var user = new MainViewModel();
            emailSuperior.Text = user.CurrentUserAccount.Email;
        }

        
        private void TrimiteEvaluarea_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboProiect_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
        }

        private void tipApel_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
        }
    }
}
