using System.Windows;

namespace PrizeBondStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrizeBondBtn_Click(object sender, RoutedEventArgs e)
        {
            
            var p = new PrizeBonds();
            this.Close();
            p.Show();
        }

        private void DenominationBtn_Click(object sender, RoutedEventArgs e)
        {
            var d = new Denominations();
            this.Close();
            d.Show();
            
        }
        
    }
}
