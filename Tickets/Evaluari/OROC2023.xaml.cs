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
using Asgard.ViewModels;
using MySql.Data.MySqlClient;

namespace Asgard.Tickets.Evaluari
{
    /// <summary>
    /// Interaction logic for OROC2023.xaml
    /// </summary>
    public partial class OROC2023 : Page
    {
        public OROC2023()
        {
            InitializeComponent();
            var user = new MainViewModel();
            emailSuperior.Text = user.CurrentUserAccount.Email;
        }

        private void Clear()
        {
            emailAngajat.Text = string.Empty;
            emailSuperior.Text = string.Empty;
            numarClient.Text = string.Empty;
            clientCuFibra.Text = string.Empty;
            produsulDePeCerere.Text = string.Empty;
            respectaProcesulDeRetentie.Text = string.Empty;
            informatiileMandatorii.Text = string.Empty;
            produseRetentie.Text = string.Empty;
            ComboProiect.Text = string.Empty;
            dataApel.Text = string.Empty;
            ComboTipApel.Text = string.Empty;
            ComboMotivApel.Text = string.Empty;
            ComboMotivDesfintare.Text = string.Empty;
            notaIntrebare1.Text = string.Empty;
            observatiiIntrebare1.Text = string.Empty;
            notaIntrebare2.Text = string.Empty;
            observatiiIntrebare2.Text = string.Empty;
            notaIntrebare3.Text = string.Empty;
            observatiiIntrebare3.Text = string.Empty;
            notaIntrebare4.Text = string.Empty;
            observatiiIntrebare4.Text= string.Empty;
            notaIntrebare5.Text = string.Empty;
            observatiiIntrebare5.Text = string.Empty;
            notaIntrebare6.Text = string.Empty;
            observatiiIntrebare6.Text = string.Empty;
            notaIntrebare7.Text = string.Empty;
            observatiiIntrebare7.Text= string.Empty;
            notaIntrebare8.Text = string.Empty;
            observatiiIntrebare8.Text= string.Empty;
            notaIntrebare9.Text = string.Empty;
            observatiiIntrebare9.Text= string.Empty;
            notaIntrebare10.Text = string.Empty;
            observatiiIntrebare10.Text= string.Empty;
            notaIntrebare11.Text = string.Empty;
            observatiiIntrebare11.Text= string.Empty;
            observatiiIntrebare12.Text= string.Empty;
        }
        

        private void TrimiteEvaluarea_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ComboProiect_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
        }
    }
}
