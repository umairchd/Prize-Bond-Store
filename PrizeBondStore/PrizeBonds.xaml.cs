using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using PrizeBondStore.Mappers;
using PrizeBondStore.Models;

namespace PrizeBondStore
{
    /// <summary>
    /// Interaction logic for PrizeBonds.xaml
    /// </summary>
    public partial class PrizeBonds : Window
    {
        public PrizeBonds()
        {
            InitializeComponent();
            PopulateGrid();
        }

        private void Single_Checked(object sender, RoutedEventArgs e)
        {
            if (Series.IsChecked.HasValue && Series.IsChecked.Value)
            {
                BondCount.Visibility = Visibility.Visible;
                Label.Visibility = Visibility.Visible;
            }
            if (Single.IsChecked.HasValue && Single.IsChecked.Value)
            {
                BondCount.Visibility = Visibility.Hidden;
                Label.Visibility = Visibility.Hidden;
            }

        }

        private void PrizeBonds_OnClosing(object sender, CancelEventArgs e)
        {
            var d = new MainWindow();
            d.Show();
        }

        private void PrizeBondTypeAddBtn_Click(object sender, RoutedEventArgs e)
        {
            var entities = Repository.GetInstance();
            var count = Convert.ToInt32(BondCount.Text);
            var bondNumber = Convert.ToInt32(PrizeBondTxtBox.Text);
            if (Series.IsChecked.HasValue && Series.IsChecked.Value)
            {
                for (int i = 0; i < count; i++)
                {
                    var prizeBond = new PrizeBond
                    {
                        PrizeBondCode = bondNumber.ToString(),
                        DenominationId = 2
                    };
                    entities.PrizeBonds.Add(prizeBond);
                    bondNumber++;
                }
                
            }
            else
            {
                var prizeBond = new PrizeBond
                {
                    PrizeBondCode = bondNumber.ToString(),
                    DenominationId = 2
                };
                entities.PrizeBonds.Add(prizeBond);
            }
            entities.SaveChanges();
            Series.IsChecked = null;
            Single.IsChecked = null;
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            var entities = Repository.GetInstance();
            //DenominationsGrid.IsReadOnly = true;
            Grid.CanUserAddRows = true;
            Grid.CanUserDeleteRows = true;
            Grid.CanUserResizeColumns = true;
            Grid.CanUserSortColumns = true;
            Grid.ItemsSource = entities.PrizeBonds.ToList().Select(x => x.CreateFrom()).ToList();
        }
    }
}
