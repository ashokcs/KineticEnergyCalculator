using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Kinetic_Energy_Calculator
{
    class KineticEnergyCalculator : INotifyPropertyChanged
    {
        #region Constants
        const string INPUT_VALIDATION_ERROR = "Please enter a valid Input!!";
        const string VALID_INPUT_MESSAGE = "Nice Job!!";
        const string ERROR_COLOR_CODE = "#AA1945";
        const string VALID_INPUT_COLOR_CODE = "#59981A";
        #endregion

        #region Properties
        private string errorLabelVisibility;
        public string ErrorLabelVisibility
        {
            get { return errorLabelVisibility; }
            set { errorLabelVisibility = value; propertyChanged(); }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; propertyChanged(); }
        }

        private string errorColorCode;
        public string ErrorColorCode
        {
            get { return errorColorCode; }
            set { errorColorCode = value; propertyChanged(); }
        }

        private string massInput;
        public string MassInput
        {
            get { return massInput; }
            set { massInput = value; propertyChanged(); }
        }

        private string velocityInput;
        public string VelocityInput
        {
            get { return velocityInput; }
            set { velocityInput = value; propertyChanged(); }
        }

        private Double kineticEnergy;
        public Double KineticEnergy
        {
            get { return kineticEnergy; }
            set { kineticEnergy = value; propertyChanged(); }
        }
        #endregion

        #region Input Validations & Utility
        public void validateInputAndCalculateEnergy()
        {
            try
            {
                Double mass = Double.Parse(MassInput);
                Double velocity = Double.Parse(VelocityInput);
                if (mass < 0 || velocity < 0)
                {
                    showErrorMessage(true);
                    return;
                }
                else
                {
                    CalcKineticEnergy(mass, velocity);
                }

                showErrorMessage(false);
            }
            catch (FormatException e)
            {
                showErrorMessage(true);
            }
            catch (OverflowException e)
            {
                showErrorMessage(true);
            }
            catch (ArgumentNullException e)
            {
                showErrorMessage(true);
            }
        }

        #endregion

        #region Core Functions
        public void CalcKineticEnergy(Double mass, Double velocity)
        {
            KineticEnergy = 0.5 * (mass * (velocity * velocity));
        }
        #endregion


        private void showErrorMessage(bool hasError)
        {
            ErrorLabelVisibility = Visibility.Visible.ToString();
            ErrorColorCode = hasError ? ERROR_COLOR_CODE : VALID_INPUT_COLOR_CODE;
            ErrorMessage = hasError ? INPUT_VALIDATION_ERROR : VALID_INPUT_MESSAGE;
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void propertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
