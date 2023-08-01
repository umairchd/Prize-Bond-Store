using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using PrizeBondStore.Mappers;
using PrizeBondStore.Models;

namespace PrizeBondStore
{
    /// <summary>
    /// Interaction logic for Denominations.xaml
    /// </summary>
    public partial class Denominations : Window
    {
        public Denominations()
        {
            InitializeComponent();
            PopulateGrid();
        }

        private void DenominationTypeAddBtn_Click(object sender, RoutedEventArgs e)
        {
            var entities = Repository.GetInstance();
            var type = Convert.ToInt32(DenominationTypeTxtBox.Text);
            if (entities.Denominations.Any(x=>x.Type == type))
            {
                MessageBox.Show("Already added.");
                return;
            }
            var denomination = new DenominationModel {Type = type};
            var newDenomination = entities.Denominations.Add(denomination.CreateFrom());
            entities.SaveChanges();
            DenominationTypeTxtBox.Clear();
            PopulateGrid();

        }

        private void PopulateGrid()
        {
            var entities = Repository.GetInstance();
            //DenominationsGrid.IsReadOnly = true;
            DenominationsGrid.CanUserAddRows = true;
            DenominationsGrid.CanUserDeleteRows = true;
            DenominationsGrid.CanUserResizeColumns = true;
            DenominationsGrid.CanUserSortColumns = true;
            DenominationsGrid.ItemsSource = entities.Denominations.ToList().Select(x=>x.CreateFrom()).ToList();
        }

        private void DenominationTypeRefereshBtn_Click(object sender, RoutedEventArgs e)
        {
            PopulateGrid();
        }

        private void Denominations_OnClosing(object sender, CancelEventArgs e)
        {
            var d = new MainWindow();
            d.Show();

        }
    }
}
