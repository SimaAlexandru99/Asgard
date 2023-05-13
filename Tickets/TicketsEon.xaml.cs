using System.Windows;
using System.Windows.Controls;

namespace Asgard.Tickets
{
    /// <summary>
    /// Interaction logic for TicketsEon.xaml
    /// </summary>
    public partial class TicketsEon : Page
    {
        public TicketsEon()
        {
            InitializeComponent();
        }

        private void ButtonContract_Click(object sender, RoutedEventArgs e)
        {
            PrimaryWindow window = Window.GetWindow(this) as PrimaryWindow;
            window.Main.Navigate(new EON.TicketContracte());
        }
    }
}
