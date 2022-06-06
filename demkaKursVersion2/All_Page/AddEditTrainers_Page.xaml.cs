using demkaKursVersion2.All_Class;
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

namespace demkaKursVersion2.All_Page
{
    public partial class AddEditTrainers_Page : Page
    {
        private Trainer _currentTrainer = new Trainer();
        public AddEditTrainers_Page(Trainer selectedTrainer)
        {
            InitializeComponent();

            if (selectedTrainer != null)
            {
                _currentTrainer = selectedTrainer;
               // DP_Birthdate.SelectedDate = _currentTrainer.Date_birhtday;
            }
            DataContext = _currentTrainer;
            ComBox_Class.ItemsSource = demkaItogKursEntities.GetContext().Trainer.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentTrainer.Surname == null)
                errors.AppendLine("Введите фамилию");
            if (_currentTrainer.Name == null)
                errors.AppendLine("Введите имя");
            if (_currentTrainer.Patronymic == null)
                errors.AppendLine("Введите отчество");

            if (_currentTrainer.Date_birhtday == null)
            {
                if (DP_Birthdate.SelectedDate == null)
                {
                    errors.AppendLine("Выберите дату рождения");
                }
                else
                {
                   // _currentTrainer.Date_birhtday = DP_Birthdate.SelectedDate;
                }
            }

            if (_currentTrainer.Class == 0)
                errors.AppendLine("Введите разряд");
            try
            {
                demkaItogKursEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
