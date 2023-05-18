// <copyright file="Formular.xaml.cs" company="eOverArt Marketing Agency">
// Copyright (c) eOverArt Marketing Agency. All rights reserved.
// </copyright>

namespace Asgard.Tickets.CEC
{
    using Asgard.Repositories;
    using MySql.Data.MySqlClient;
    using System.Data;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for Formular.xaml.
    /// </summary>
    public partial class Formular : Page
    {
        public Formular()
        {
            InitializeComponent();
        }

        private void T1_Da_Checked(object sender, RoutedEventArgs e)
        {
            Stack3.Visibility = Visibility.Visible;
        }

        private void T1_Da_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack3.Visibility = Visibility.Collapsed;
        }

        private void T1_Da_credit_Checked(object sender, RoutedEventArgs e)
        {
            Stack4.Visibility = Visibility.Visible;
        }

        private void T1_Da_credit_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack4.Visibility = Visibility.Collapsed;
        }

        private void T1_Nu_Checked(object sender, RoutedEventArgs e)
        {
            Stack7.Visibility = Visibility.Visible;
        }

        private void T1_Nu_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack7.Visibility = Visibility.Collapsed;
        }

        private void T2_1_Da_Checked(object sender, RoutedEventArgs e)
        {
            Stack5.Visibility = Visibility.Visible;
        }

        private void T2_1_Da_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack5.Visibility = Visibility.Collapsed;
        }

        private void T2_1_Nu_Checked(object sender, RoutedEventArgs e)
        {
            Stack8.Visibility = Visibility.Visible;
        }

        private void T2_1_Nu_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack8.Visibility = Visibility.Collapsed;
        }

        private void T2_2_Da_Checked(object sender, RoutedEventArgs e)
        {
            Stack5.Visibility = Visibility.Visible;
        }

        private void T2_2_Da_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack5.Visibility = Visibility.Collapsed;
        }

        private void T3_Da_Checked(object sender, RoutedEventArgs e)
        {
            Stack6.Visibility = Visibility.Visible;
        }

        private void T3_Da_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack6.Visibility = Visibility.Collapsed;
        }

        private void T3_Nu_Checked(object sender, RoutedEventArgs e)
        {
            Stack9.Visibility = Visibility.Visible;
        }

        private void T3_Nu_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack9.Visibility = Visibility.Collapsed;
        }

        private void T4_Da_Checked(object sender, RoutedEventArgs e)
        {
            Stack11.Visibility = Visibility.Visible;
            Stack12.Visibility = Visibility.Visible;
            Stack13.Visibility = Visibility.Visible;
        }

        private void T4_Da_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack11.Visibility = Visibility.Collapsed;
            Stack12.Visibility = Visibility.Collapsed;
            Stack13.Visibility = Visibility.Collapsed;
        }

        private void T4_Nu_Checked(object sender, RoutedEventArgs e)
        {
            Stack10.Visibility = Visibility.Visible;
        }

        private void T4_Nu_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack10.Visibility = Visibility.Collapsed;
        }

        private void Drop_produs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Set focus to another element on the page to remove focus from the ComboBox
            Q3_1.Focus();

            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string selectedValue = selectedItem.Content.ToString();
            if (selectedItem.Name == "Var1" || selectedItem.Name == "Var2" || selectedItem.Name == "Var3" || selectedItem.Name == "Var4" || selectedItem.Name == "Var5" || selectedItem.Name == "Var6" || selectedItem.Name == "Var7")
            {
                Stack14.Visibility = Visibility.Visible;
                Stack15.Visibility = Visibility.Visible;
                Stack16.Visibility = Visibility.Visible;
                Stack17.Visibility = Visibility.Visible;
                Stack18.Visibility = Visibility.Visible;
                Stack19.Visibility = Visibility.Visible;
                Stack20.Visibility = Visibility.Visible;
                Stack35.Visibility = Visibility.Visible;
                Stack36.Visibility = Visibility.Visible;
                Stack37.Visibility = Visibility.Visible;
                Stack38.Visibility = Visibility.Visible;
                Stack39.Visibility = Visibility.Visible;
                Stack40.Visibility = Visibility.Visible;
                Stack51.Visibility = Visibility.Visible;
                Stack52.Visibility = Visibility.Visible;
                Stack54.Visibility = Visibility.Visible;
                Stack56.Visibility = Visibility.Visible;
            }
            else
            {
                Stack14.Visibility = Visibility.Collapsed;
                Stack15.Visibility = Visibility.Collapsed;
                Stack16.Visibility = Visibility.Collapsed;
                Stack17.Visibility = Visibility.Collapsed;
                Stack18.Visibility = Visibility.Collapsed;
                Stack19.Visibility = Visibility.Collapsed;
                Stack20.Visibility = Visibility.Collapsed;
                Stack35.Visibility = Visibility.Collapsed;
                Stack36.Visibility = Visibility.Collapsed;
                Stack37.Visibility = Visibility.Collapsed;
                Stack38.Visibility = Visibility.Collapsed;
                Stack39.Visibility = Visibility.Collapsed;
                Stack40.Visibility = Visibility.Collapsed;
            }
            if (selectedItem.Name == "Var8" || selectedItem.Name == "Var9")
            {
                Stack21.Visibility = Visibility.Visible;
                Stack22.Visibility = Visibility.Visible;
                Stack23.Visibility = Visibility.Visible;
                Stack24.Visibility = Visibility.Visible;
                Stack25.Visibility = Visibility.Visible;
                Stack26.Visibility = Visibility.Visible;
                Stack27.Visibility = Visibility.Visible;
                Stack41.Visibility = Visibility.Visible;
                Stack42.Visibility = Visibility.Visible;
                Stack43.Visibility = Visibility.Visible;
                Stack44.Visibility = Visibility.Visible;
                Stack45.Visibility = Visibility.Visible;
                Stack51.Visibility = Visibility.Visible;
                Stack52.Visibility = Visibility.Visible;
                Stack54.Visibility = Visibility.Visible;
                Stack56.Visibility = Visibility.Visible;
            }
            else
            {
                Stack21.Visibility = Visibility.Collapsed;
                Stack22.Visibility = Visibility.Collapsed;
                Stack23.Visibility = Visibility.Collapsed;
                Stack24.Visibility = Visibility.Collapsed;
                Stack25.Visibility = Visibility.Collapsed;
                Stack26.Visibility = Visibility.Collapsed;
                Stack27.Visibility = Visibility.Collapsed;
                Stack41.Visibility = Visibility.Collapsed;
                Stack42.Visibility = Visibility.Collapsed;
                Stack43.Visibility = Visibility.Collapsed;
                Stack44.Visibility = Visibility.Collapsed;
                Stack45.Visibility = Visibility.Collapsed;
            }
            if (selectedItem.Name == "Var10" || selectedItem.Name == "Var11" || selectedItem.Name == "Var12" || selectedItem.Name == "Var13" || selectedItem.Name == "Var14")
            {
                Stack28.Visibility = Visibility.Visible;
                Stack29.Visibility = Visibility.Visible;
                Stack30.Visibility = Visibility.Visible;
                Stack31.Visibility = Visibility.Visible;
                Stack32.Visibility = Visibility.Visible;
                Stack33.Visibility = Visibility.Visible;
                Stack46.Visibility = Visibility.Visible;
                Stack47.Visibility = Visibility.Visible;
                Stack48.Visibility = Visibility.Visible;
                Stack49.Visibility = Visibility.Visible;
                Stack51.Visibility = Visibility.Visible;
                Stack52.Visibility = Visibility.Visible;
                Stack54.Visibility = Visibility.Visible;
                Stack56.Visibility = Visibility.Visible;
            }
            else
            {
                Stack28.Visibility = Visibility.Collapsed;
                Stack29.Visibility = Visibility.Collapsed;
                Stack30.Visibility = Visibility.Collapsed;
                Stack31.Visibility = Visibility.Collapsed;
                Stack32.Visibility = Visibility.Collapsed;
                Stack33.Visibility = Visibility.Collapsed;
                Stack46.Visibility = Visibility.Collapsed;
                Stack47.Visibility = Visibility.Collapsed;
                Stack48.Visibility = Visibility.Collapsed;
                Stack49.Visibility = Visibility.Collapsed;
            }
        }

        private void Q3_1_1_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_1_1_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_1_1_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_1_1_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_1_2_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_1_2_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_1_2_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_1_2_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_1_3_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_1_3_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_1_3_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_1_3_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_1_4_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_1_4_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_1_4_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_1_4_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_1_5_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_1_5_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_1_5_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_1_5_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_1_6_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_1_6_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_1_6_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_1_6_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_2_1_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_2_1_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_2_1_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_2_1_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_2_2_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_2_2_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_2_2_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_2_2_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_2_3_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_2_3_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_2_3_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_2_3_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_2_4_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_2_4_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_2_4_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_2_4_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_2_5_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_2_5_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_2_5_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_2_5_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_2_6_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_2_6_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_2_6_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_2_6_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_3_1_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_3_1_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_3_1_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_3_1_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_3_2_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_3_2_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_3_2_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_3_2_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_3_3_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_3_3_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_3_3_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_3_3_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_3_4_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_3_4_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_3_4_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_3_4_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_3_5_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_3_5_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q3_3_5_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Visible;
        }

        private void Q3_3_5_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack34.Visibility = Visibility.Collapsed;
        }

        private void Q4_1_1_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_1_1_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_1_1_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_1_1_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_1_2_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_1_2_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_1_2_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_1_2_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_1_3_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_1_3_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_1_3_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_1_3_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_1_4_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_1_4_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_1_4_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_1_4_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_1_5_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_1_5_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_1_5_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_1_5_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_2_1_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_2_1_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_2_1_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_2_1_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_2_2_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_2_2_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_2_2_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_2_2_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_2_3_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_2_3_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_2_3_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_2_3_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_2_4_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_2_4_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_2_4_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_2_4_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_3_1_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_3_1_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_3_1_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_3_1_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_3_2_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_3_2_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_3_2_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_3_2_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_3_3_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_3_3_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q4_3_3_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Visible;
        }

        private void Q4_3_3_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack50.Visibility = Visibility.Collapsed;
        }

        private void Q6_bifa_0_Checked(object sender, RoutedEventArgs e)
        {
            Stack53.Visibility = Visibility.Visible;
        }

        private void Q6_bifa_0_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack53.Visibility = Visibility.Collapsed;
        }

        private void Q6_bifa_1_Checked(object sender, RoutedEventArgs e)
        {
            Stack53.Visibility = Visibility.Visible;
        }

        private void Q6_bifa_1_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack53.Visibility = Visibility.Collapsed;
        }

        private void Q6_bifa_2_Checked(object sender, RoutedEventArgs e)
        {
            Stack53.Visibility = Visibility.Visible;
        }

        private void Q6_bifa_2_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack53.Visibility = Visibility.Collapsed;
        }

        private void Q6_bifa_3_Checked(object sender, RoutedEventArgs e)
        {
            Stack53.Visibility = Visibility.Visible;
        }

        private void Q6_bifa_3_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack53.Visibility = Visibility.Collapsed;
        }

        private void Q6_bifa_4_Checked(object sender, RoutedEventArgs e)
        {
            Stack53.Visibility = Visibility.Visible;
        }

        private void Q6_bifa_4_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack53.Visibility = Visibility.Collapsed;
        }

        private void Q6_bifa_5_Checked(object sender, RoutedEventArgs e)
        {
            Stack53.Visibility = Visibility.Visible;
        }

        private void Q6_bifa_5_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack53.Visibility = Visibility.Collapsed;
        }

        private void Q6_bifa_6_Checked(object sender, RoutedEventArgs e)
        {
            Stack53.Visibility = Visibility.Visible;
        }

        private void Q6_bifa_6_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack53.Visibility = Visibility.Collapsed;
        }

        private void B7_Da_Checked(object sender, RoutedEventArgs e)
        {
            Stack55.Visibility = Visibility.Visible;
        }

        private void B7_Da_Unchecked(object sender, RoutedEventArgs e)
        {
            Stack55.Visibility = Visibility.Collapsed;
        }

        private void Drop_tip_sondaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            string selectedValue = selectedItem.Content.ToString();
        }

        private void Clear()
        {
            ID_client_text.Text = string.Empty;
            T1_Da.IsChecked = false;
            T1_Da_credit.IsChecked = false;
            T1_Nu.IsChecked = false;
            T2_1_Da.IsChecked = false;
            T2_1_Nu.IsChecked = false;
            T2_2_Da.IsChecked = false;
            T2_2_Nu.IsChecked = false;
            T3_Da.IsChecked = false;
            T3_Nu.IsChecked = false;
            T4_Da.IsChecked = false;
            T4_Nu.IsChecked = false;
            Q1_bifa1.IsChecked = false;
            Q1_bifa2.IsChecked = false;
            Q1_bifa3.IsChecked = false;
            Q1_bifa4.IsChecked = false;
            Q1_bifa5.IsChecked = false;
            Q1_bifa6.IsChecked = false;
            Q2_bifa1.IsChecked = false;
            Q2_bifa2.IsChecked = false;
            Q2_bifa3.IsChecked = false;
            Q2_bifa4.IsChecked = false;
            Q2_bifa5.IsChecked = false;
            Q2_bifa6.IsChecked = false;
            Drop_produs.Text = " ";
            Q3_1_1_bifa_1.IsChecked = false;
            Q3_1_1_bifa_2.IsChecked = false;
            Q3_1_1_bifa_3.IsChecked = false;
            Q3_1_1_bifa_4.IsChecked = false;
            Q3_1_1_bifa_5.IsChecked = false;
            Q3_1_1_bifa_6.IsChecked = false;
            Q3_1_2_bifa_1.IsChecked = false;
            Q3_1_2_bifa_2.IsChecked = false;
            Q3_1_2_bifa_3.IsChecked = false;
            Q3_1_2_bifa_4.IsChecked = false;
            Q3_1_2_bifa_5.IsChecked = false;
            Q3_1_2_bifa_6.IsChecked = false;
            Q3_1_3_bifa_1.IsChecked = false;
            Q3_1_3_bifa_2.IsChecked = false;
            Q3_1_3_bifa_3.IsChecked = false;
            Q3_1_3_bifa_4.IsChecked = false;
            Q3_1_3_bifa_5.IsChecked = false;
            Q3_1_3_bifa_6.IsChecked = false;
            Q3_1_4_bifa_1.IsChecked = false;
            Q3_1_4_bifa_2.IsChecked = false;
            Q3_1_4_bifa_3.IsChecked = false;
            Q3_1_4_bifa_4.IsChecked = false;
            Q3_1_4_bifa_5.IsChecked = false;
            Q3_1_4_bifa_6.IsChecked = false;
            Q3_1_5_bifa_1.IsChecked = false;
            Q3_1_5_bifa_2.IsChecked = false;
            Q3_1_5_bifa_3.IsChecked = false;
            Q3_1_5_bifa_4.IsChecked = false;
            Q3_1_5_bifa_5.IsChecked = false;
            Q3_1_5_bifa_6.IsChecked = false;
            Q3_1_6_bifa_1.IsChecked = false;
            Q3_1_6_bifa_2.IsChecked = false;
            Q3_1_6_bifa_3.IsChecked = false;
            Q3_1_6_bifa_4.IsChecked = false;
            Q3_1_6_bifa_5.IsChecked = false;
            Q3_1_6_bifa_6.IsChecked = false;
            Q3_2_1_bifa_1.IsChecked = false;
            Q3_2_1_bifa_2.IsChecked = false;
            Q3_2_1_bifa_3.IsChecked = false;
            Q3_2_1_bifa_4.IsChecked = false;
            Q3_2_1_bifa_5.IsChecked = false;
            Q3_2_1_bifa_6.IsChecked = false;
            Q3_2_2_bifa_1.IsChecked = false;
            Q3_2_2_bifa_2.IsChecked = false;
            Q3_2_2_bifa_3.IsChecked = false;
            Q3_2_2_bifa_4.IsChecked = false;
            Q3_2_2_bifa_5.IsChecked = false;
            Q3_2_2_bifa_6.IsChecked = false;
            Q3_2_3_bifa_1.IsChecked = false;
            Q3_2_3_bifa_2.IsChecked = false;
            Q3_2_3_bifa_3.IsChecked = false;
            Q3_2_3_bifa_4.IsChecked = false;
            Q3_2_3_bifa_5.IsChecked = false;
            Q3_2_3_bifa_6.IsChecked = false;
            Q3_2_4_bifa_1.IsChecked = false;
            Q3_2_4_bifa_2.IsChecked = false;
            Q3_2_4_bifa_3.IsChecked = false;
            Q3_2_4_bifa_4.IsChecked = false;
            Q3_2_4_bifa_5.IsChecked = false;
            Q3_2_4_bifa_6.IsChecked = false;
            Q3_2_5_bifa_1.IsChecked = false;
            Q3_2_5_bifa_2.IsChecked = false;
            Q3_2_5_bifa_3.IsChecked = false;
            Q3_2_5_bifa_4.IsChecked = false;
            Q3_2_5_bifa_5.IsChecked = false;
            Q3_2_5_bifa_6.IsChecked = false;
            Q3_2_6_bifa_1.IsChecked = false;
            Q3_2_6_bifa_2.IsChecked = false;
            Q3_2_6_bifa_3.IsChecked = false;
            Q3_2_6_bifa_4.IsChecked = false;
            Q3_2_6_bifa_5.IsChecked = false;
            Q3_2_6_bifa_6.IsChecked = false;
            Q3_3_1_bifa_1.IsChecked = false;
            Q3_3_1_bifa_2.IsChecked = false;
            Q3_3_1_bifa_3.IsChecked = false;
            Q3_3_1_bifa_4.IsChecked = false;
            Q3_3_1_bifa_5.IsChecked = false;
            Q3_3_1_bifa_6.IsChecked = false;
            Q3_3_2_bifa_1.IsChecked = false;
            Q3_3_2_bifa_2.IsChecked = false;
            Q3_3_2_bifa_3.IsChecked = false;
            Q3_3_2_bifa_4.IsChecked = false;
            Q3_3_2_bifa_5.IsChecked = false;
            Q3_3_2_bifa_6.IsChecked = false;
            Q3_3_3_bifa_1.IsChecked = false;
            Q3_3_3_bifa_2.IsChecked = false;
            Q3_3_3_bifa_3.IsChecked = false;
            Q3_3_3_bifa_4.IsChecked = false;
            Q3_3_3_bifa_5.IsChecked = false;
            Q3_3_3_bifa_6.IsChecked = false;
            Q3_3_4_bifa_1.IsChecked = false;
            Q3_3_4_bifa_2.IsChecked = false;
            Q3_3_4_bifa_3.IsChecked = false;
            Q3_3_4_bifa_4.IsChecked = false;
            Q3_3_4_bifa_5.IsChecked = false;
            Q3_3_4_bifa_6.IsChecked = false;
            Q3_3_5_bifa_1.IsChecked = false;
            Q3_3_5_bifa_2.IsChecked = false;
            Q3_3_5_bifa_3.IsChecked = false;
            Q3_3_5_bifa_4.IsChecked = false;
            Q3_3_5_bifa_5.IsChecked = false;
            Q3_3_5_bifa_6.IsChecked = false;
            Freetext_B3.Text = string.Empty;
            Q4_1_1_bifa_1.IsChecked = false;
            Q4_1_1_bifa_2.IsChecked = false;
            Q4_1_1_bifa_3.IsChecked = false;
            Q4_1_1_bifa_4.IsChecked = false;
            Q4_1_1_bifa_5.IsChecked = false;
            Q4_1_1_bifa_6.IsChecked = false;
            Q4_1_2_bifa_1.IsChecked = false;
            Q4_1_2_bifa_2.IsChecked = false;
            Q4_1_2_bifa_3.IsChecked = false;
            Q4_1_2_bifa_4.IsChecked = false;
            Q4_1_2_bifa_5.IsChecked = false;
            Q4_1_2_bifa_6.IsChecked = false;
            Q4_1_3_bifa_1.IsChecked = false;
            Q4_1_3_bifa_2.IsChecked = false;
            Q4_1_3_bifa_3.IsChecked = false;
            Q4_1_3_bifa_4.IsChecked = false;
            Q4_1_3_bifa_5.IsChecked = false;
            Q4_1_3_bifa_6.IsChecked = false;
            Q4_1_4_bifa_1.IsChecked = false;
            Q4_1_4_bifa_2.IsChecked = false;
            Q4_1_4_bifa_3.IsChecked = false;
            Q4_1_4_bifa_4.IsChecked = false;
            Q4_1_4_bifa_5.IsChecked = false;
            Q4_1_4_bifa_6.IsChecked = false;
            Q4_1_5_bifa_1.IsChecked = false;
            Q4_1_5_bifa_2.IsChecked = false;
            Q4_1_5_bifa_3.IsChecked = false;
            Q4_1_5_bifa_4.IsChecked = false;
            Q4_1_5_bifa_5.IsChecked = false;
            Q4_1_5_bifa_6.IsChecked = false;
            Q4_2_1_bifa_1.IsChecked = false;
            Q4_2_1_bifa_2.IsChecked = false;
            Q4_2_1_bifa_3.IsChecked = false;
            Q4_2_1_bifa_4.IsChecked = false;
            Q4_2_1_bifa_5.IsChecked = false;
            Q4_2_1_bifa_6.IsChecked = false;
            Q4_2_2_bifa_1.IsChecked = false;
            Q4_2_2_bifa_2.IsChecked = false;
            Q4_2_2_bifa_3.IsChecked = false;
            Q4_2_2_bifa_4.IsChecked = false;
            Q4_2_2_bifa_5.IsChecked = false;
            Q4_2_2_bifa_6.IsChecked = false;
            Q4_2_3_bifa_1.IsChecked = false;
            Q4_2_3_bifa_2.IsChecked = false;
            Q4_2_3_bifa_3.IsChecked = false;
            Q4_2_3_bifa_4.IsChecked = false;
            Q4_2_3_bifa_5.IsChecked = false;
            Q4_2_3_bifa_6.IsChecked = false;
            Q4_2_4_bifa_1.IsChecked = false;
            Q4_2_4_bifa_2.IsChecked = false;
            Q4_2_4_bifa_3.IsChecked = false;
            Q4_2_4_bifa_4.IsChecked = false;
            Q4_2_4_bifa_5.IsChecked = false;
            Q4_2_4_bifa_6.IsChecked = false;
            Q4_3_1_bifa_1.IsChecked = false;
            Q4_3_1_bifa_2.IsChecked = false;
            Q4_3_1_bifa_3.IsChecked = false;
            Q4_3_1_bifa_4.IsChecked = false;
            Q4_3_1_bifa_5.IsChecked = false;
            Q4_3_1_bifa_6.IsChecked = false;
            Q4_3_2_bifa_1.IsChecked = false;
            Q4_3_2_bifa_2.IsChecked = false;
            Q4_3_2_bifa_3.IsChecked = false;
            Q4_3_2_bifa_4.IsChecked = false;
            Q4_3_2_bifa_5.IsChecked = false;
            Q4_3_2_bifa_6.IsChecked = false;
            Q4_3_3_bifa_1.IsChecked = false;
            Q4_3_3_bifa_2.IsChecked = false;
            Q4_3_3_bifa_3.IsChecked = false;
            Q4_3_3_bifa_4.IsChecked = false;
            Q4_3_3_bifa_5.IsChecked = false;
            Q4_3_3_bifa_6.IsChecked = false;
            Freetext_B4.Text = string.Empty;
            Q5_bifa_1.IsChecked = false;
            Q5_bifa_2.IsChecked = false;
            Q5_bifa_3.IsChecked = false;
            Q5_bifa_4.IsChecked = false;
            Q5_bifa_5.IsChecked = false;
            Q5_bifa_6.IsChecked = false;
            Q6_bifa_0.IsChecked = false;
            Q6_bifa_1.IsChecked = false;
            Q6_bifa_2.IsChecked = false;
            Q6_bifa_3.IsChecked = false;
            Q6_bifa_4.IsChecked = false;
            Q6_bifa_5.IsChecked = false;
            Q6_bifa_6.IsChecked = false;
            Q6_bifa_7.IsChecked = false;
            Q6_bifa_8.IsChecked = false;
            Q6_bifa_9.IsChecked = false;
            Q6_bifa_10.IsChecked = false;
            Freetext_B6.Text = string.Empty;
            B7_Da.IsChecked = false;
            B7_Nu.IsChecked = false;
            Freetext_B8.Text = string.Empty;
            Drop_tip_sondaj.Text = " ";
            Stack51.Visibility = Visibility.Collapsed;
            Stack52.Visibility = Visibility.Collapsed;
            Stack54.Visibility = Visibility.Collapsed;
            Stack56.Visibility = Visibility.Collapsed;
        }

        private void Trimite_Click(object sender, RoutedEventArgs e)
        {
            string T1 = string.Empty;
            if (T1_Da.IsChecked == true)
            {
                T1 = "Da";
            }
            else if (T1_Da_credit.IsChecked == true)
            {
                T1 = "Da credit";
            }
            else if (T1_Nu.IsChecked == true)
            {
                T1 = "Nu";
            }

            string T2_1 = string.Empty;
            if (T2_1_Da.IsChecked == true)
            {
                T2_1 = "Da";
            }
            else if (T2_1_Nu.IsChecked == true)
            {
                T2_1 = "Nu";
            }

            string T2_2 = string.Empty;
            if (T2_2_Da.IsChecked == true)
            {
                T2_2 = "Da";
            }
            else if (T2_2_Nu.IsChecked == true)
            {
                T2_2 = "Nu";
            }

            string T3 = string.Empty;
            if (T3_Da.IsChecked == true)
            {
                T3 = "Da";
            }
            else if (T3_Nu.IsChecked == true)
            {
                T3 = "Nu";
            }

            string T4 = string.Empty;
            if (T4_Da.IsChecked == true)
            {
                T4 = "Da";
            }
            else if (T4_Nu.IsChecked == true)
            {
                T4 = "Nu";
            }

            string Q1 = string.Empty;
            if (Q1_bifa1.IsChecked == true)
            {
                Q1 = "1";
            }
            else if (Q1_bifa2.IsChecked == true)
            {
                Q1 = "2";
            }
            else if (Q1_bifa3.IsChecked == true)
            {
                Q1 = "3";
            }
            else if (Q1_bifa4.IsChecked == true)
            {
                Q1 = "4";
            }
            else if (Q1_bifa5.IsChecked == true)
            {
                Q1 = "5";
            }
            else if (Q1_bifa6.IsChecked == true)
            {
                Q1 = "Nu stiu/ Nu raspund";
            }

            string Q2 = string.Empty;
            if (Q2_bifa1.IsChecked == true)
            {
                Q2 = "1";
            }
            else if (Q2_bifa2.IsChecked == true)
            {
                Q2 = "2";
            }
            else if (Q2_bifa3.IsChecked == true)
            {
                Q2 = "3";
            }
            else if (Q2_bifa4.IsChecked == true)
            {
                Q2 = "4";
            }
            else if (Q2_bifa5.IsChecked == true)
            {
                Q2 = "5";
            }
            else if (Q2_bifa6.IsChecked == true)
            {
                Q2 = "Nu stiu/ nu raspund";
            }

            string Q3_1_1 = string.Empty;
            if (Q3_1_1_bifa_1.IsChecked == true || Q3_2_1_bifa_1.IsChecked == true || Q3_3_1_bifa_1.IsChecked == true)
            {
                Q3_1_1 = "1";
            }
            else if (Q3_1_1_bifa_2.IsChecked == true || Q3_2_1_bifa_2.IsChecked == true || Q3_3_1_bifa_2.IsChecked == true)
            {
                Q3_1_1 = "2";
            }
            else if (Q3_1_1_bifa_3.IsChecked == true || Q3_2_1_bifa_3.IsChecked == true || Q3_3_1_bifa_3.IsChecked == true)
            {
                Q3_1_1 = "3";
            }
            else if (Q3_1_1_bifa_4.IsChecked == true || Q3_2_1_bifa_4.IsChecked == true || Q3_3_1_bifa_4.IsChecked == true)
            {
                Q3_1_1 = "4";
            }
            else if (Q3_1_1_bifa_5.IsChecked == true || Q3_2_1_bifa_5.IsChecked == true || Q3_3_1_bifa_5.IsChecked == true)
            {
                Q3_1_1 = "5";
            }
            else if (Q3_1_1_bifa_6.IsChecked == true || Q3_2_1_bifa_6.IsChecked == true || Q3_3_1_bifa_6.IsChecked == true)
            {
                Q3_1_1 = "Nu stiu/ nu raspund";
            }

            string Q3_1_2 = string.Empty;
            if (Q3_1_2_bifa_1.IsChecked == true || Q3_2_2_bifa_1.IsChecked == true || Q3_3_2_bifa_1.IsChecked == true)
            {
                Q3_1_2 = "1";
            }
            else if (Q3_1_2_bifa_2.IsChecked == true || Q3_2_2_bifa_2.IsChecked == true || Q3_3_2_bifa_2.IsChecked == true)
            {
                Q3_1_2 = "2";
            }
            else if (Q3_1_2_bifa_3.IsChecked == true || Q3_2_2_bifa_3.IsChecked == true || Q3_3_2_bifa_3.IsChecked == true)
            {
                Q3_1_2 = "3";
            }
            else if (Q3_1_2_bifa_4.IsChecked == true || Q3_2_2_bifa_4.IsChecked == true || Q3_3_2_bifa_4.IsChecked == true)
            {
                Q3_1_2 = "4";
            }
            else if (Q3_1_2_bifa_5.IsChecked == true || Q3_2_2_bifa_5.IsChecked == true || Q3_3_2_bifa_5.IsChecked == true)
            {
                Q3_1_2 = "5";
            }
            else if (Q3_1_2_bifa_6.IsChecked == true || Q3_2_2_bifa_6.IsChecked == true || Q3_3_2_bifa_6.IsChecked == true)
            {
                Q3_1_2 = "Nu stiu/ nu raspund";
            }

            string Q3_1_3 = string.Empty;
            if (Q3_1_3_bifa_1.IsChecked == true || Q3_2_3_bifa_1.IsChecked == true || Q3_3_3_bifa_1.IsChecked == true)
            {
                Q3_1_3 = "1";
            }
            else if (Q3_1_3_bifa_2.IsChecked == true || Q3_2_3_bifa_2.IsChecked == true || Q3_3_3_bifa_2.IsChecked == true)
            {
                Q3_1_3 = "2";
            }
            else if (Q3_1_3_bifa_3.IsChecked == true || Q3_2_3_bifa_3.IsChecked == true || Q3_3_3_bifa_3.IsChecked == true)
            {
                Q3_1_3 = "3";
            }
            else if (Q3_1_3_bifa_4.IsChecked == true || Q3_2_3_bifa_4.IsChecked == true || Q3_3_3_bifa_4.IsChecked == true)
            {
                Q3_1_3 = "4";
            }
            else if (Q3_1_3_bifa_5.IsChecked == true || Q3_2_3_bifa_5.IsChecked == true || Q3_3_3_bifa_5.IsChecked == true)
            {
                Q3_1_3 = "5";
            }
            else if (Q3_1_3_bifa_6.IsChecked == true || Q3_2_3_bifa_6.IsChecked == true || Q3_3_3_bifa_6.IsChecked == true)
            {
                Q3_1_3 = "Nu stiu/ nu raspund";
            }

            string Q3_1_4 = string.Empty;
            if (Q3_1_4_bifa_1.IsChecked == true || Q3_2_4_bifa_1.IsChecked == true || Q3_3_4_bifa_1.IsChecked == true)
            {
                Q3_1_4 = "1";
            }
            else if (Q3_1_4_bifa_2.IsChecked == true || Q3_2_4_bifa_2.IsChecked == true || Q3_3_4_bifa_2.IsChecked == true)
            {
                Q3_1_4 = "2";
            }
            else if (Q3_1_4_bifa_3.IsChecked == true || Q3_2_4_bifa_3.IsChecked == true || Q3_3_4_bifa_3.IsChecked == true)
            {
                Q3_1_4 = "3";
            }
            else if (Q3_1_4_bifa_4.IsChecked == true || Q3_2_4_bifa_4.IsChecked == true || Q3_3_4_bifa_4.IsChecked == true)
            {
                Q3_1_4 = "4";
            }
            else if (Q3_1_4_bifa_5.IsChecked == true || Q3_2_4_bifa_5.IsChecked == true || Q3_3_4_bifa_5.IsChecked == true)
            {
                Q3_1_4 = "5";
            }
            else if (Q3_1_4_bifa_6.IsChecked == true || Q3_2_4_bifa_6.IsChecked == true || Q3_3_4_bifa_6.IsChecked == true)
            {
                Q3_1_4 = "Nu stiu/ nu raspund";
            }

            string Q3_1_5 = string.Empty;
            if (Q3_1_5_bifa_1.IsChecked == true || Q3_2_5_bifa_1.IsChecked == true || Q3_3_5_bifa_1.IsChecked == true)
            {
                Q3_1_5 = "1";
            }
            else if (Q3_1_5_bifa_2.IsChecked == true || Q3_2_5_bifa_2.IsChecked == true || Q3_3_5_bifa_2.IsChecked == true)
            {
                Q3_1_5 = "2";
            }
            else if (Q3_1_5_bifa_3.IsChecked == true || Q3_2_5_bifa_3.IsChecked == true || Q3_3_5_bifa_3.IsChecked == true)
            {
                Q3_1_5 = "3";
            }
            else if (Q3_1_5_bifa_4.IsChecked == true || Q3_2_5_bifa_4.IsChecked == true || Q3_3_5_bifa_4.IsChecked == true)
            {
                Q3_1_5 = "4";
            }
            else if (Q3_1_5_bifa_5.IsChecked == true || Q3_2_5_bifa_5.IsChecked == true || Q3_3_5_bifa_5.IsChecked == true)
            {
                Q3_1_5 = "5";
            }
            else if (Q3_1_5_bifa_6.IsChecked == true || Q3_2_5_bifa_6.IsChecked == true || Q3_3_5_bifa_6.IsChecked == true)
            {
                Q3_1_5 = "Nu stiu/ nu raspund";
            }

            string Q3_1_6 = string.Empty;
            if (Q3_1_6_bifa_1.IsChecked == true || Q3_2_6_bifa_1.IsChecked == true)
            {
                Q3_1_6 = "1";
            }
            else if (Q3_1_6_bifa_2.IsChecked == true || Q3_2_6_bifa_2.IsChecked == true)
            {
                Q3_1_6 = "2";
            }
            else if (Q3_1_6_bifa_3.IsChecked == true || Q3_2_6_bifa_3.IsChecked == true)
            {
                Q3_1_6 = "3";
            }
            else if (Q3_1_6_bifa_4.IsChecked == true || Q3_2_6_bifa_4.IsChecked == true)
            {
                Q3_1_6 = "4";
            }
            else if (Q3_1_6_bifa_5.IsChecked == true || Q3_2_6_bifa_5.IsChecked == true)
            {
                Q3_1_6 = "5";
            }
            else if (Q3_1_6_bifa_6.IsChecked == true || Q3_2_6_bifa_6.IsChecked == true)
            {
                Q3_1_6 = "Nu stiu/ nu raspund";
            }

            string Q4_1_1 = string.Empty;
            if (Q4_1_1_bifa_1.IsChecked == true || Q4_2_1_bifa_1.IsChecked == true || Q4_3_1_bifa_1.IsChecked == true)
            {
                Q4_1_1 = "1";
            }
            else if (Q4_1_1_bifa_2.IsChecked == true || Q4_2_1_bifa_2.IsChecked == true || Q4_3_1_bifa_2.IsChecked == true)
            {
                Q4_1_1 = "2";
            }
            else if (Q4_1_1_bifa_3.IsChecked == true || Q4_2_1_bifa_3.IsChecked == true || Q4_3_1_bifa_3.IsChecked == true)
            {
                Q4_1_1 = "3";
            }
            else if (Q4_1_1_bifa_4.IsChecked == true || Q4_2_1_bifa_4.IsChecked == true || Q4_3_1_bifa_4.IsChecked == true)
            {
                Q4_1_1 = "4";
            }
            else if (Q4_1_1_bifa_5.IsChecked == true || Q4_2_1_bifa_5.IsChecked == true || Q4_3_1_bifa_5.IsChecked == true)
            {
                Q4_1_1 = "5";
            }
            else if (Q4_1_1_bifa_6.IsChecked == true || Q4_2_1_bifa_6.IsChecked == true || Q4_3_1_bifa_6.IsChecked == true)
            {
                Q4_1_1 = "Nu stiu/ nu raspund";
            }

            string Q4_1_2 = string.Empty;
            if (Q4_1_2_bifa_1.IsChecked == true || Q4_2_2_bifa_1.IsChecked == true || Q4_3_2_bifa_1.IsChecked == true)
            {
                Q4_1_2 = "1";
            }
            else if (Q4_1_2_bifa_2.IsChecked == true || Q4_2_2_bifa_2.IsChecked == true || Q4_3_2_bifa_2.IsChecked == true)
            {
                Q4_1_2 = "2";
            }
            else if (Q4_1_2_bifa_3.IsChecked == true || Q4_2_2_bifa_3.IsChecked == true || Q4_3_2_bifa_3.IsChecked == true)
            {
                Q4_1_2 = "3";
            }
            else if (Q4_1_2_bifa_4.IsChecked == true || Q4_2_2_bifa_4.IsChecked == true || Q4_3_2_bifa_4.IsChecked == true)
            {
                Q4_1_2 = "4";
            }
            else if (Q4_1_2_bifa_5.IsChecked == true || Q4_2_2_bifa_5.IsChecked == true || Q4_3_2_bifa_5.IsChecked == true)
            {
                Q4_1_2 = "5";
            }
            else if (Q4_1_2_bifa_6.IsChecked == true || Q4_2_2_bifa_6.IsChecked == true || Q4_3_2_bifa_6.IsChecked == true)
            {
                Q4_1_2 = "Nu stiu/ nu raspund";
            }

            string Q4_1_3 = string.Empty;
            if (Q4_1_3_bifa_1.IsChecked == true || Q4_2_3_bifa_1.IsChecked == true || Q4_3_3_bifa_1.IsChecked == true)
            {
                Q4_1_3 = "1";
            }
            else if (Q4_1_3_bifa_2.IsChecked == true || Q4_2_3_bifa_2.IsChecked == true || Q4_3_3_bifa_2.IsChecked == true)
            {
                Q4_1_3 = "2";
            }
            else if (Q4_1_3_bifa_3.IsChecked == true || Q4_2_3_bifa_3.IsChecked == true || Q4_3_3_bifa_3.IsChecked == true)
            {
                Q4_1_3 = "3";
            }
            else if (Q4_1_3_bifa_4.IsChecked == true || Q4_2_3_bifa_4.IsChecked == true || Q4_3_3_bifa_4.IsChecked == true)
            {
                Q4_1_3 = "4";
            }
            else if (Q4_1_3_bifa_5.IsChecked == true || Q4_2_3_bifa_5.IsChecked == true || Q4_3_3_bifa_5.IsChecked == true)
            {
                Q4_1_3 = "5";
            }
            else if (Q4_1_3_bifa_6.IsChecked == true || Q4_2_3_bifa_6.IsChecked == true || Q4_3_3_bifa_6.IsChecked == true)
            {
                Q4_1_3 = "Nu stiu/ nu raspund";
            }

            string Q4_1_4 = string.Empty;
            if (Q4_1_4_bifa_1.IsChecked == true || Q4_2_4_bifa_1.IsChecked == true)
            {
                Q4_1_4 = "1";
            }
            else if (Q4_1_4_bifa_2.IsChecked == true || Q4_2_4_bifa_2.IsChecked == true)
            {
                Q4_1_4 = "2";
            }
            else if (Q4_1_4_bifa_3.IsChecked == true || Q4_2_4_bifa_3.IsChecked == true)
            {
                Q4_1_4 = "3";
            }
            else if (Q4_1_4_bifa_4.IsChecked == true || Q4_2_4_bifa_4.IsChecked == true)
            {
                Q4_1_4 = "4";
            }
            else if (Q4_1_4_bifa_5.IsChecked == true || Q4_2_4_bifa_5.IsChecked == true)
            {
                Q4_1_4 = "5";
            }
            else if (Q4_1_4_bifa_6.IsChecked == true || Q4_2_4_bifa_6.IsChecked == true)
            {
                Q4_1_4 = "Nu stiu/ nu raspund";
            }

            string Q4_1_5 = string.Empty;
            if (Q4_1_5_bifa_1.IsChecked == true)
            {
                Q4_1_5 = "1";
            }
            else if (Q4_1_5_bifa_2.IsChecked == true)
            {
                Q4_1_5 = "2";
            }
            else if (Q4_1_5_bifa_3.IsChecked == true)
            {
                Q4_1_5 = "3";
            }
            else if (Q4_1_5_bifa_4.IsChecked == true)
            {
                Q4_1_5 = "4";
            }
            else if (Q4_1_5_bifa_5.IsChecked == true)
            {
                Q4_1_5 = "5";
            }
            else if (Q4_1_1_bifa_6.IsChecked == true)
            {
                Q4_1_5 = "Nu stiu/ nu raspund";
            }

            string Q5 = string.Empty;
            if (Q5_bifa_1.IsChecked == true)
            {
                Q5 = "1";
            }
            else if (Q5_bifa_2.IsChecked == true)
            {
                Q5 = "2";
            }
            else if (Q5_bifa_3.IsChecked == true)
            {
                Q5 = "3";
            }
            else if (Q5_bifa_4.IsChecked == true)
            {
                Q5 = "4";
            }
            else if (Q5_bifa_5.IsChecked == true)
            {
                Q5 = "5";
            }
            else if (Q5_bifa_6.IsChecked == true)
            {
                Q5 = "Nu stiu/ nu raspund";
            }

            string Q6 = string.Empty;
            if (Q6_bifa_0.IsChecked == true)
            {
                Q6 = "0";
            }
            else if (Q6_bifa_1.IsChecked == true)
            {
                Q6 = "1";
            }
            else if (Q6_bifa_2.IsChecked == true)
            {
                Q6 = "2";
            }
            else if (Q6_bifa_3.IsChecked == true)
            {
                Q6 = "3";
            }
            else if (Q6_bifa_4.IsChecked == true)
            {
                Q6 = "4";
            }
            else if (Q6_bifa_5.IsChecked == true)
            {
                Q6 = "5";
            }
            else if (Q6_bifa_6.IsChecked == true)
            {
                Q6 = "6";
            }
            else if (Q6_bifa_7.IsChecked == true)
            {
                Q6 = "7";
            }
            else if (Q6_bifa_8.IsChecked == true)
            {
                Q6 = "8";
            }
            else if (Q6_bifa_9.IsChecked == true)
            {
                Q6 = "9";
            }
            else if (Q6_bifa_10.IsChecked == true)
            {
                Q6 = "10";
            }

            string B7 = string.Empty;
            if (B7_Da.IsChecked == true)
            {
                B7 = "Da";
            }
            else if (B7_Nu.IsChecked == true)
            {
                B7 = "Nu";
            }

            if (Drop_tip_sondaj.Text == "Sondaj Complet")
            {
                if (ID_client_text.Text != string.Empty && (T1_Da.IsChecked == true || T1_Da_credit.IsChecked == true) && (T2_1_Da.IsChecked == true || T2_2_Da.IsChecked == true) && T3_Da.IsChecked == true && T4_Da.IsChecked == true && (Q1_bifa1.IsChecked == true || Q1_bifa2.IsChecked == true || Q1_bifa3.IsChecked == true || Q1_bifa4.IsChecked == true || Q1_bifa5.IsChecked == true || Q1_bifa6.IsChecked == true) && (Q2_bifa1.IsChecked == true || Q2_bifa2.IsChecked == true || Q2_bifa3.IsChecked == true || Q2_bifa4.IsChecked == true || Q2_bifa5.IsChecked == true || Q2_bifa6.IsChecked == true))
                {
                    if (Drop_produs.Text == "obtinere credit de nevoi personale" || Drop_produs.Text == "obtinere credit ipotecar" || Drop_produs.Text == "obtinere card de credit" || Drop_produs.Text == "deschidere cont curent" || Drop_produs.Text == "deschidere pachet de cont curent" || Drop_produs.Text == "deschide un cont de economii" || Drop_produs.Text == "achizitionare serviciu Mobile Banking]")
                    {
                        if ((Q3_1_1_bifa_1.IsChecked == true || Q3_1_1_bifa_2.IsChecked == true || Q3_1_1_bifa_3.IsChecked == true || Q3_1_1_bifa_4.IsChecked == true || Q3_1_1_bifa_5.IsChecked == true || Q3_1_1_bifa_6.IsChecked == true) && (Q3_1_2_bifa_1.IsChecked == true || Q3_1_2_bifa_2.IsChecked == true || Q3_1_2_bifa_3.IsChecked == true || Q3_1_2_bifa_4.IsChecked == true || Q3_1_2_bifa_5.IsChecked == true || Q3_1_2_bifa_6.IsChecked == true) && (Q3_1_3_bifa_1.IsChecked == true || Q3_1_3_bifa_2.IsChecked == true || Q3_1_3_bifa_3.IsChecked == true || Q3_1_3_bifa_4.IsChecked == true || Q3_1_3_bifa_5.IsChecked == true || Q3_1_3_bifa_6.IsChecked == true) && (Q3_1_4_bifa_1.IsChecked == true || Q3_1_4_bifa_2.IsChecked == true || Q3_1_4_bifa_3.IsChecked == true || Q3_1_4_bifa_4.IsChecked == true || Q3_1_4_bifa_5.IsChecked == true || Q3_1_4_bifa_6.IsChecked == true) && (Q3_1_5_bifa_1.IsChecked == true || Q3_1_5_bifa_2.IsChecked == true || Q3_1_5_bifa_3.IsChecked == true || Q3_1_5_bifa_4.IsChecked == true || Q3_1_5_bifa_5.IsChecked == true || Q3_1_5_bifa_6.IsChecked == true) && (Q3_1_6_bifa_1.IsChecked == true || Q3_1_6_bifa_2.IsChecked == true || Q3_1_6_bifa_3.IsChecked == true || Q3_1_6_bifa_4.IsChecked == true || Q3_1_6_bifa_5.IsChecked == true || Q3_1_6_bifa_6.IsChecked == true) && (Q4_1_1_bifa_1.IsChecked == true || Q4_1_1_bifa_2.IsChecked == true || Q4_1_1_bifa_3.IsChecked == true || Q4_1_1_bifa_4.IsChecked == true || Q4_1_1_bifa_5.IsChecked == true || Q4_1_1_bifa_6.IsChecked == true) && (Q4_1_2_bifa_1.IsChecked == true || Q4_1_2_bifa_2.IsChecked == true || Q4_1_2_bifa_3.IsChecked == true || Q4_1_2_bifa_4.IsChecked == true || Q4_1_2_bifa_5.IsChecked == true || Q4_1_2_bifa_6.IsChecked == true) && (Q4_1_3_bifa_1.IsChecked == true || Q4_1_3_bifa_2.IsChecked == true || Q4_1_3_bifa_3.IsChecked == true || Q4_1_3_bifa_4.IsChecked == true || Q4_1_3_bifa_5.IsChecked == true || Q4_1_3_bifa_6.IsChecked == true) && (Q4_1_4_bifa_1.IsChecked == true || Q4_1_4_bifa_2.IsChecked == true || Q4_1_4_bifa_3.IsChecked == true || Q4_1_4_bifa_4.IsChecked == true || Q4_1_4_bifa_5.IsChecked == true || Q4_1_4_bifa_6.IsChecked == true) && (Q4_1_5_bifa_1.IsChecked == true || Q4_1_5_bifa_2.IsChecked == true || Q4_1_5_bifa_3.IsChecked == true || Q4_1_5_bifa_4.IsChecked == true || Q4_1_5_bifa_5.IsChecked == true || Q4_1_5_bifa_6.IsChecked == true) && (Q5_bifa_1.IsChecked == true || Q5_bifa_2.IsChecked == true || Q5_bifa_3.IsChecked == true || Q5_bifa_4.IsChecked == true || Q5_bifa_5.IsChecked == true || Q5_bifa_6.IsChecked == true) && (Q6_bifa_0.IsChecked == true || Q6_bifa_1.IsChecked == true || Q6_bifa_2.IsChecked == true || Q6_bifa_3.IsChecked == true || Q6_bifa_4.IsChecked == true || Q6_bifa_5.IsChecked == true || Q6_bifa_6.IsChecked == true || Q6_bifa_7.IsChecked == true || Q6_bifa_8.IsChecked == true || Q6_bifa_9.IsChecked == true || Q6_bifa_10.IsChecked == true) && (B7_Da.IsChecked == true || B7_Nu.IsChecked == true))
                        {
                            string sql = "INSERT INTO chestionare_cec VALUES (NULL, @id_client, @t1, @t2_1, @t2_2, @t3, @t4, @q1, @q2, @q3_1_1, @q3_1_2, @q3_1_3, @q3_1_4, @q3_1_5, @q3_1_6, @b3, @q4_1_1, @q4_1_2, @q4_1_3, @q4_1_4, @q4_1_5, @b4, @q5, @q6, @b6, @b7, @b8, @tip_sondaj, NULL)";
                            MySqlConnection connection = RepositoryBase.GetConnectionPublic();
                            MySqlCommand cmd = new MySqlCommand(sql, connection);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add("@id_client", MySqlDbType.VarChar).Value = ID_client_text.Text;
                            cmd.Parameters.Add("@t1", MySqlDbType.VarChar).Value = T1;
                            cmd.Parameters.Add("@t2_1", MySqlDbType.VarChar).Value = T2_1;
                            cmd.Parameters.Add("@t2_2", MySqlDbType.VarChar).Value = T2_2;
                            cmd.Parameters.Add("@t3", MySqlDbType.VarChar).Value = T3;
                            cmd.Parameters.Add("@t4", MySqlDbType.VarChar).Value = T4;
                            cmd.Parameters.Add("@q1", MySqlDbType.VarChar).Value = Q1;
                            cmd.Parameters.Add("@q2", MySqlDbType.VarChar).Value = Q2;
                            cmd.Parameters.Add("@q3_1_1", MySqlDbType.VarChar).Value = Q3_1_1;
                            cmd.Parameters.Add("@q3_1_2", MySqlDbType.VarChar).Value = Q3_1_2;
                            cmd.Parameters.Add("@q3_1_3", MySqlDbType.VarChar).Value = Q3_1_3;
                            cmd.Parameters.Add("@q3_1_4", MySqlDbType.VarChar).Value = Q3_1_4;
                            cmd.Parameters.Add("@q3_1_5", MySqlDbType.VarChar).Value = Q3_1_5;
                            cmd.Parameters.Add("@q3_1_6", MySqlDbType.VarChar).Value = Q3_1_6;
                            cmd.Parameters.Add("@b3", MySqlDbType.VarChar).Value = Freetext_B3.Text;
                            cmd.Parameters.Add("@q4_1_1", MySqlDbType.VarChar).Value = Q4_1_1;
                            cmd.Parameters.Add("@q4_1_2", MySqlDbType.VarChar).Value = Q4_1_2;
                            cmd.Parameters.Add("@q4_1_3", MySqlDbType.VarChar).Value = Q4_1_3;
                            cmd.Parameters.Add("@q4_1_4", MySqlDbType.VarChar).Value = Q4_1_4;
                            cmd.Parameters.Add("@q4_1_5", MySqlDbType.VarChar).Value = Q4_1_5;
                            cmd.Parameters.Add("@b4", MySqlDbType.VarChar).Value = Freetext_B4.Text;
                            cmd.Parameters.Add("@q5", MySqlDbType.VarChar).Value = Q5;
                            cmd.Parameters.Add("@q6", MySqlDbType.VarChar).Value = Q6;
                            cmd.Parameters.Add("@b6", MySqlDbType.VarChar).Value = Freetext_B6.Text;
                            cmd.Parameters.Add("@b7", MySqlDbType.VarChar).Value = B7;
                            cmd.Parameters.Add("@b8", MySqlDbType.VarChar).Value = Freetext_B8.Text;
                            cmd.Parameters.Add("@tip_sondaj", MySqlDbType.VarChar).Value = Drop_tip_sondaj.Text;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (MySqlException)
                            {
                                CustomControls.Prompt dialog = new CustomControls.Prompt();
                                dialog.Loaded += (s, ea) =>
                                {
                                    dialog.Title = "Eroare";
                                    dialog.Status.Text = "Eroare conectare baza";
                                    dialog.Descriere.Text = "Eroare conectare baza, te rog sa iei legatura cu administratorul de retea";
                                };
                                dialog.ShowDialog();
                                return;
                            }
                            finally
                            {
                                connection.Close();

                                CustomControls.Prompt dialog = new CustomControls.Prompt();
                                dialog.Loaded += (s, ea) =>
                                {
                                    dialog.Title = "Felicitări";
                                    dialog.Status.Text = "Ai înregistrat un formular";
                                    dialog.Descriere.Text = "Felicitari, ai trimis un sondaj complet \n Apasa pe ok pentru a introduce un alt sondaj";
                                };
                                dialog.ShowDialog();

                                Clear();
                            }
                        }
                        else
                        {
                            CustomControls.Prompt dialog = new CustomControls.Prompt();
                            dialog.Loaded += (s, ea) =>
                            {
                                dialog.Title = "Eroare";
                                dialog.Status.Text = "Ai uitat să completezi ceva";
                                dialog.Descriere.Text = "Verifică formularul și completează câmpul gol";
                            };
                            dialog.ShowDialog();
                            return;
                        }

                    }
                    else if (Drop_produs.Text == "retragere numerar" || Drop_produs.Text == "efectuarea unei plati prin ordin de plata]")
                    {
                        if ((Q3_2_1_bifa_1.IsChecked == true || Q3_2_1_bifa_2.IsChecked == true || Q3_2_1_bifa_3.IsChecked == true || Q3_2_1_bifa_4.IsChecked == true || Q3_2_1_bifa_5.IsChecked == true || Q3_2_1_bifa_6.IsChecked == true) && (Q3_2_2_bifa_1.IsChecked == true || Q3_2_2_bifa_2.IsChecked == true || Q3_2_2_bifa_3.IsChecked == true || Q3_2_2_bifa_4.IsChecked == true || Q3_2_2_bifa_5.IsChecked == true || Q3_2_2_bifa_6.IsChecked == true) && (Q3_2_3_bifa_1.IsChecked == true || Q3_2_3_bifa_2.IsChecked == true || Q3_2_3_bifa_3.IsChecked == true || Q3_2_3_bifa_4.IsChecked == true || Q3_2_3_bifa_5.IsChecked == true || Q3_2_3_bifa_6.IsChecked == true) && (Q3_2_4_bifa_1.IsChecked == true || Q3_2_4_bifa_2.IsChecked == true || Q3_2_4_bifa_3.IsChecked == true || Q3_2_4_bifa_4.IsChecked == true || Q3_2_4_bifa_5.IsChecked == true || Q3_2_4_bifa_6.IsChecked == true) && (Q3_2_5_bifa_1.IsChecked == true || Q3_2_5_bifa_2.IsChecked == true || Q3_2_5_bifa_3.IsChecked == true || Q3_2_5_bifa_4.IsChecked == true || Q3_2_5_bifa_5.IsChecked == true || Q3_2_5_bifa_6.IsChecked == true) && (Q3_2_6_bifa_1.IsChecked == true || Q3_2_6_bifa_2.IsChecked == true || Q3_2_6_bifa_3.IsChecked == true || Q3_2_6_bifa_4.IsChecked == true || Q3_2_6_bifa_5.IsChecked == true || Q3_2_6_bifa_6.IsChecked == true) && (Q4_2_1_bifa_1.IsChecked == true || Q4_2_1_bifa_2.IsChecked == true || Q4_2_1_bifa_3.IsChecked == true || Q4_2_1_bifa_4.IsChecked == true || Q4_2_1_bifa_5.IsChecked == true || Q4_2_1_bifa_6.IsChecked == true) && (Q4_2_2_bifa_1.IsChecked == true || Q4_2_2_bifa_2.IsChecked == true || Q4_2_2_bifa_3.IsChecked == true || Q4_2_2_bifa_4.IsChecked == true || Q4_2_2_bifa_5.IsChecked == true || Q4_2_2_bifa_6.IsChecked == true) && (Q4_2_3_bifa_1.IsChecked == true || Q4_2_3_bifa_2.IsChecked == true || Q4_2_3_bifa_3.IsChecked == true || Q4_2_3_bifa_4.IsChecked == true || Q4_2_3_bifa_5.IsChecked == true || Q4_2_3_bifa_6.IsChecked == true) && (Q4_2_4_bifa_1.IsChecked == true || Q4_2_4_bifa_2.IsChecked == true || Q4_2_4_bifa_3.IsChecked == true || Q4_2_4_bifa_4.IsChecked == true || Q4_2_4_bifa_5.IsChecked == true || Q4_2_4_bifa_6.IsChecked == true) && (Q5_bifa_1.IsChecked == true || Q5_bifa_2.IsChecked == true || Q5_bifa_3.IsChecked == true || Q5_bifa_4.IsChecked == true || Q5_bifa_5.IsChecked == true || Q5_bifa_6.IsChecked == true) && (Q6_bifa_0.IsChecked == true || Q6_bifa_1.IsChecked == true || Q6_bifa_2.IsChecked == true || Q6_bifa_3.IsChecked == true || Q6_bifa_4.IsChecked == true || Q6_bifa_5.IsChecked == true || Q6_bifa_6.IsChecked == true || Q6_bifa_7.IsChecked == true || Q6_bifa_8.IsChecked == true || Q6_bifa_9.IsChecked == true || Q6_bifa_10.IsChecked == true) && (B7_Da.IsChecked == true || B7_Nu.IsChecked == true))
                        {
                            string sql = "INSERT INTO chestionare_cec VALUES (NULL, @id_client, @t1, @t2_1, @t2_2, @t3, @t4, @q1, @q2, @q3_1_1, @q3_1_2, @q3_1_3, @q3_1_4, @q3_1_5, @q3_1_6, @b3, @q4_1_1, @q4_1_2, @q4_1_3, @q4_1_4, @q4_1_5, @b4, @q5, @q6, @b6, @b7, @b8, @tip_sondaj, NULL)";
                            MySqlConnection connection = RepositoryBase.GetConnectionPublic();
                            MySqlCommand cmd = new MySqlCommand(sql, connection);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add("@id_client", MySqlDbType.VarChar).Value = ID_client_text.Text;
                            cmd.Parameters.Add("@t1", MySqlDbType.VarChar).Value = T1;
                            cmd.Parameters.Add("@t2_1", MySqlDbType.VarChar).Value = T2_1;
                            cmd.Parameters.Add("@t2_2", MySqlDbType.VarChar).Value = T2_2;
                            cmd.Parameters.Add("@t3", MySqlDbType.VarChar).Value = T3;
                            cmd.Parameters.Add("@t4", MySqlDbType.VarChar).Value = T4;
                            cmd.Parameters.Add("@q1", MySqlDbType.VarChar).Value = Q1;
                            cmd.Parameters.Add("@q2", MySqlDbType.VarChar).Value = Q2;
                            cmd.Parameters.Add("@q3_1_1", MySqlDbType.VarChar).Value = Q3_1_1;
                            cmd.Parameters.Add("@q3_1_2", MySqlDbType.VarChar).Value = Q3_1_2;
                            cmd.Parameters.Add("@q3_1_3", MySqlDbType.VarChar).Value = Q3_1_3;
                            cmd.Parameters.Add("@q3_1_4", MySqlDbType.VarChar).Value = Q3_1_4;
                            cmd.Parameters.Add("@q3_1_5", MySqlDbType.VarChar).Value = Q3_1_5;
                            cmd.Parameters.Add("@q3_1_6", MySqlDbType.VarChar).Value = Q3_1_6;
                            cmd.Parameters.Add("@b3", MySqlDbType.VarChar).Value = Freetext_B3.Text;
                            cmd.Parameters.Add("@q4_1_1", MySqlDbType.VarChar).Value = Q4_1_1;
                            cmd.Parameters.Add("@q4_1_2", MySqlDbType.VarChar).Value = Q4_1_2;
                            cmd.Parameters.Add("@q4_1_3", MySqlDbType.VarChar).Value = Q4_1_3;
                            cmd.Parameters.Add("@q4_1_4", MySqlDbType.VarChar).Value = Q4_1_4;
                            cmd.Parameters.Add("@q4_1_5", MySqlDbType.VarChar).Value = Q4_1_5;
                            cmd.Parameters.Add("@b4", MySqlDbType.VarChar).Value = Freetext_B4.Text;
                            cmd.Parameters.Add("@q5", MySqlDbType.VarChar).Value = Q5;
                            cmd.Parameters.Add("@q6", MySqlDbType.VarChar).Value = Q6;
                            cmd.Parameters.Add("@b6", MySqlDbType.VarChar).Value = Freetext_B6.Text;
                            cmd.Parameters.Add("@b7", MySqlDbType.VarChar).Value = B7;
                            cmd.Parameters.Add("@b8", MySqlDbType.VarChar).Value = Freetext_B8.Text;
                            cmd.Parameters.Add("@tip_sondaj", MySqlDbType.VarChar).Value = Drop_tip_sondaj.Text;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (MySqlException)
                            {
                                CustomControls.Prompt dialog = new CustomControls.Prompt();
                                dialog.Loaded += (s, ea) =>
                                {
                                    dialog.Title = "Eroare";
                                    dialog.Status.Text = "Eroare conectare baza";
                                    dialog.Descriere.Text = "Eroare conectare baza, te rog sa iei legatura cu administratorul de retea";
                                };
                                dialog.ShowDialog();
                                return;
                            }
                            finally
                            {
                                connection.Close();

                                CustomControls.Prompt dialog = new CustomControls.Prompt();
                                dialog.Loaded += (s, ea) =>
                                {
                                    dialog.Title = "Felicitări";
                                    dialog.Status.Text = "Ai înregistrat un formular";
                                    dialog.Descriere.Text = "Felicitari, ai trimis un sondaj complet \n Apasa pe ok pentru a introduce un alt sondaj";
                                };
                                dialog.ShowDialog();

                                Clear();
                            }
                        }
                        else
                        {
                            CustomControls.Prompt dialog = new CustomControls.Prompt();
                            dialog.Loaded += (s, ea) =>
                            {
                                dialog.Title = "Eroare";
                                dialog.Status.Text = "Ai uitat să completezi ceva";
                                dialog.Descriere.Text = "Verifică formularul și completează câmpul gol";
                            };
                            dialog.ShowDialog();
                            return;
                        }
                    }
                    else if (Drop_produs.Text == "depunere numerar" || Drop_produs.Text == "lichidare depozit" || Drop_produs.Text == "efectuarea unui schimb valutar" || Drop_produs.Text == "solicitarea unui extras de cont" || Drop_produs.Text == "constituirea unui depozit]")
                    {
                        if ((Q3_3_1_bifa_1.IsChecked == true || Q3_3_1_bifa_2.IsChecked == true || Q3_3_1_bifa_3.IsChecked == true || Q3_3_1_bifa_4.IsChecked == true || Q3_3_1_bifa_5.IsChecked == true || Q3_3_1_bifa_6.IsChecked == true) && (Q3_3_2_bifa_1.IsChecked == true || Q3_3_2_bifa_2.IsChecked == true || Q3_3_2_bifa_3.IsChecked == true || Q3_3_2_bifa_4.IsChecked == true || Q3_3_2_bifa_5.IsChecked == true || Q3_3_2_bifa_6.IsChecked == true) && (Q3_3_3_bifa_1.IsChecked == true || Q3_3_3_bifa_2.IsChecked == true || Q3_3_3_bifa_3.IsChecked == true || Q3_3_3_bifa_4.IsChecked == true || Q3_3_3_bifa_5.IsChecked == true || Q3_3_3_bifa_6.IsChecked == true) && (Q3_3_4_bifa_1.IsChecked == true || Q3_3_4_bifa_2.IsChecked == true || Q3_3_4_bifa_3.IsChecked == true || Q3_3_4_bifa_4.IsChecked == true || Q3_3_4_bifa_5.IsChecked == true || Q3_3_4_bifa_6.IsChecked == true) && (Q3_3_5_bifa_1.IsChecked == true || Q3_3_5_bifa_2.IsChecked == true || Q3_3_5_bifa_3.IsChecked == true || Q3_3_5_bifa_4.IsChecked == true || Q3_3_5_bifa_5.IsChecked == true || Q3_3_5_bifa_6.IsChecked == true) && (Q4_3_1_bifa_1.IsChecked == true || Q4_3_1_bifa_2.IsChecked == true || Q4_3_1_bifa_3.IsChecked == true || Q4_3_1_bifa_4.IsChecked == true || Q4_3_1_bifa_5.IsChecked == true || Q4_3_1_bifa_6.IsChecked == true) && (Q4_3_2_bifa_1.IsChecked == true || Q4_3_2_bifa_2.IsChecked == true || Q4_3_2_bifa_3.IsChecked == true || Q4_3_2_bifa_4.IsChecked == true || Q4_3_2_bifa_5.IsChecked == true || Q4_3_2_bifa_6.IsChecked == true) && (Q4_3_3_bifa_1.IsChecked == true || Q4_3_3_bifa_2.IsChecked == true || Q4_3_3_bifa_3.IsChecked == true || Q4_3_3_bifa_4.IsChecked == true || Q4_3_3_bifa_5.IsChecked == true || Q4_3_3_bifa_6.IsChecked == true) && (Q5_bifa_1.IsChecked == true || Q5_bifa_2.IsChecked == true || Q5_bifa_3.IsChecked == true || Q5_bifa_4.IsChecked == true || Q5_bifa_5.IsChecked == true || Q5_bifa_6.IsChecked == true) && (Q6_bifa_0.IsChecked == true || Q6_bifa_1.IsChecked == true || Q6_bifa_2.IsChecked == true || Q6_bifa_3.IsChecked == true || Q6_bifa_4.IsChecked == true || Q6_bifa_5.IsChecked == true || Q6_bifa_6.IsChecked == true || Q6_bifa_7.IsChecked == true || Q6_bifa_8.IsChecked == true || Q6_bifa_9.IsChecked == true || Q6_bifa_10.IsChecked == true) && (B7_Da.IsChecked == true || B7_Nu.IsChecked == true))
                        {
                            string sql = "INSERT INTO chestionare_cec VALUES (NULL, @id_client, @t1, @t2_1, @t2_2, @t3, @t4, @q1, @q2, @q3_1_1, @q3_1_2, @q3_1_3, @q3_1_4, @q3_1_5, @q3_1_6, @b3, @q4_1_1, @q4_1_2, @q4_1_3, @q4_1_4, @q4_1_5, @b4, @q5, @q6, @b6, @b7, @b8, @tip_sondaj, NULL)";
                            MySqlConnection connection = RepositoryBase.GetConnectionPublic();
                            MySqlCommand cmd = new MySqlCommand(sql, connection);
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.Add("@id_client", MySqlDbType.VarChar).Value = ID_client_text.Text;
                            cmd.Parameters.Add("@t1", MySqlDbType.VarChar).Value = T1;
                            cmd.Parameters.Add("@t2_1", MySqlDbType.VarChar).Value = T2_1;
                            cmd.Parameters.Add("@t2_2", MySqlDbType.VarChar).Value = T2_2;
                            cmd.Parameters.Add("@t3", MySqlDbType.VarChar).Value = T3;
                            cmd.Parameters.Add("@t4", MySqlDbType.VarChar).Value = T4;
                            cmd.Parameters.Add("@q1", MySqlDbType.VarChar).Value = Q1;
                            cmd.Parameters.Add("@q2", MySqlDbType.VarChar).Value = Q2;
                            cmd.Parameters.Add("@q3_1_1", MySqlDbType.VarChar).Value = Q3_1_1;
                            cmd.Parameters.Add("@q3_1_2", MySqlDbType.VarChar).Value = Q3_1_2;
                            cmd.Parameters.Add("@q3_1_3", MySqlDbType.VarChar).Value = Q3_1_3;
                            cmd.Parameters.Add("@q3_1_4", MySqlDbType.VarChar).Value = Q3_1_4;
                            cmd.Parameters.Add("@q3_1_5", MySqlDbType.VarChar).Value = Q3_1_5;
                            cmd.Parameters.Add("@q3_1_6", MySqlDbType.VarChar).Value = Q3_1_6;
                            cmd.Parameters.Add("@b3", MySqlDbType.VarChar).Value = Freetext_B3.Text;
                            cmd.Parameters.Add("@q4_1_1", MySqlDbType.VarChar).Value = Q4_1_1;
                            cmd.Parameters.Add("@q4_1_2", MySqlDbType.VarChar).Value = Q4_1_2;
                            cmd.Parameters.Add("@q4_1_3", MySqlDbType.VarChar).Value = Q4_1_3;
                            cmd.Parameters.Add("@q4_1_4", MySqlDbType.VarChar).Value = Q4_1_4;
                            cmd.Parameters.Add("@q4_1_5", MySqlDbType.VarChar).Value = Q4_1_5;
                            cmd.Parameters.Add("@b4", MySqlDbType.VarChar).Value = Freetext_B4.Text;
                            cmd.Parameters.Add("@q5", MySqlDbType.VarChar).Value = Q5;
                            cmd.Parameters.Add("@q6", MySqlDbType.VarChar).Value = Q6;
                            cmd.Parameters.Add("@b6", MySqlDbType.VarChar).Value = Freetext_B6.Text;
                            cmd.Parameters.Add("@b7", MySqlDbType.VarChar).Value = B7;
                            cmd.Parameters.Add("@b8", MySqlDbType.VarChar).Value = Freetext_B8.Text;
                            cmd.Parameters.Add("@tip_sondaj", MySqlDbType.VarChar).Value = Drop_tip_sondaj.Text;
                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (MySqlException)
                            {
                                CustomControls.Prompt dialog = new CustomControls.Prompt();
                                dialog.Loaded += (s, ea) =>
                                {
                                    dialog.Title = "Eroare";
                                    dialog.Status.Text = "Eroare conectare baza";
                                    dialog.Descriere.Text = "Eroare conectare baza, te rog sa iei legatura cu administratorul de retea";
                                };
                                dialog.ShowDialog();
                                return;
                            }
                            finally
                            {
                                connection.Close();

                                CustomControls.Prompt dialog = new CustomControls.Prompt();
                                dialog.Loaded += (s, ea) =>
                                {
                                    dialog.Title = "Felicitări";
                                    dialog.Status.Text = "Ai înregistrat un formular";
                                    dialog.Descriere.Text = "Felicitari, ai trimis un sondaj complet \n Apasa pe ok pentru a introduce un alt sondaj";
                                };
                                dialog.ShowDialog();

                                Clear();
                            }
                        }
                        else
                        {
                            CustomControls.Prompt dialog = new CustomControls.Prompt();
                            dialog.Loaded += (s, ea) =>
                            {
                                dialog.Title = "Eroare";
                                dialog.Status.Text = "Ai uitat să completezi ceva";
                                dialog.Descriere.Text = "Verifică formularul și completează câmpul gol";
                            };
                            dialog.ShowDialog();
                            return;
                        }
                    }
                }
                else
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Ai uitat să completezi ceva";
                        dialog.Descriere.Text = "Verifică formularul și completează câmpul gol";
                    };
                    dialog.ShowDialog();
                    return;
                }

            }
            else if (Drop_tip_sondaj.Text == "Sondaj Incomplet" && ID_client_text.Text != string.Empty)
            {
                string sql = "INSERT INTO chestionare_cec VALUES (NULL, @id_client, @t1, @t2_1, @t2_2, @t3, @t4, @q1, @q2, @q3_1_1, @q3_1_2, @q3_1_3, @q3_1_4, @q3_1_5, @q3_1_6, @b3, @q4_1_1, @q4_1_2, @q4_1_3, @q4_1_4, @q4_1_5, @b4, @q5, @q6, @b6, @b7, @b8, @tip_sondaj, NULL)";
                MySqlConnection connection = RepositoryBase.GetConnectionPublic();
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@id_client", MySqlDbType.VarChar).Value = ID_client_text.Text;
                cmd.Parameters.Add("@t1", MySqlDbType.VarChar).Value = T1;
                cmd.Parameters.Add("@t2_1", MySqlDbType.VarChar).Value = T2_1;
                cmd.Parameters.Add("@t2_2", MySqlDbType.VarChar).Value = T2_2;
                cmd.Parameters.Add("@t3", MySqlDbType.VarChar).Value = T3;
                cmd.Parameters.Add("@t4", MySqlDbType.VarChar).Value = T4;
                cmd.Parameters.Add("@q1", MySqlDbType.VarChar).Value = Q1;
                cmd.Parameters.Add("@q2", MySqlDbType.VarChar).Value = Q2;
                cmd.Parameters.Add("@q3_1_1", MySqlDbType.VarChar).Value = Q3_1_1;
                cmd.Parameters.Add("@q3_1_2", MySqlDbType.VarChar).Value = Q3_1_2;
                cmd.Parameters.Add("@q3_1_3", MySqlDbType.VarChar).Value = Q3_1_3;
                cmd.Parameters.Add("@q3_1_4", MySqlDbType.VarChar).Value = Q3_1_4;
                cmd.Parameters.Add("@q3_1_5", MySqlDbType.VarChar).Value = Q3_1_5;
                cmd.Parameters.Add("@q3_1_6", MySqlDbType.VarChar).Value = Q3_1_6;
                cmd.Parameters.Add("@b3", MySqlDbType.VarChar).Value = Freetext_B3.Text;
                cmd.Parameters.Add("@q4_1_1", MySqlDbType.VarChar).Value = Q4_1_1;
                cmd.Parameters.Add("@q4_1_2", MySqlDbType.VarChar).Value = Q4_1_2;
                cmd.Parameters.Add("@q4_1_3", MySqlDbType.VarChar).Value = Q4_1_3;
                cmd.Parameters.Add("@q4_1_4", MySqlDbType.VarChar).Value = Q4_1_4;
                cmd.Parameters.Add("@q4_1_5", MySqlDbType.VarChar).Value = Q4_1_5;
                cmd.Parameters.Add("@b4", MySqlDbType.VarChar).Value = Freetext_B4.Text;
                cmd.Parameters.Add("@q5", MySqlDbType.VarChar).Value = Q5;
                cmd.Parameters.Add("@q6", MySqlDbType.VarChar).Value = Q6;
                cmd.Parameters.Add("@b6", MySqlDbType.VarChar).Value = Freetext_B6.Text;
                cmd.Parameters.Add("@b7", MySqlDbType.VarChar).Value = B7;
                cmd.Parameters.Add("@b8", MySqlDbType.VarChar).Value = Freetext_B8.Text;
                cmd.Parameters.Add("@tip_sondaj", MySqlDbType.VarChar).Value = Drop_tip_sondaj.Text;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException)
                {
                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Eroare";
                        dialog.Status.Text = "Eroare conectare baza";
                        dialog.Descriere.Text = "Eroare conectare baza, te rog sa iei legatura cu administratorul de retea";
                    };
                    dialog.ShowDialog();
                    return;
                }
                finally
                {
                    connection.Close();

                    CustomControls.Prompt dialog = new CustomControls.Prompt();
                    dialog.Loaded += (s, ea) =>
                    {
                        dialog.Title = "Felicitări";
                        dialog.Status.Text = "Ai înregistrat un formular";
                        dialog.Descriere.Text = "Felicitari, ai trimis un sondaj complet \n Apasa pe ok pentru a introduce un alt sondaj";
                    };
                    dialog.ShowDialog();

                    Clear();
                }
            }
            else if (Drop_tip_sondaj.Text == "Sondaj Incomplet" && ID_client_text.Text == string.Empty)
            {
                CustomControls.Prompt dialog = new CustomControls.Prompt();
                dialog.Loaded += (s, ea) =>
                {
                    dialog.Title = "Eroare";
                    dialog.Status.Text = "Ai uitat să completezi ceva";
                    dialog.Descriere.Text = "Verifică formularul și completează câmpul gol";
                };
                dialog.ShowDialog();
                return;
            }
        }

        private void Drop_produs_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            e.Handled = true;
        }
    }
}
