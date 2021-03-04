using System.Windows;

namespace Kinetic_Energy_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KineticEnergyCalculator kineticEnergyCalculator = new KineticEnergyCalculator();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = kineticEnergyCalculator;
        }

        private void CalcKineticEnergyButtonClick(object sender, RoutedEventArgs e)
        {
            kineticEnergyCalculator.validateInputAndCalculateEnergy();
        }
    }
}
