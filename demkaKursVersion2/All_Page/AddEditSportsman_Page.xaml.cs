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
    public partial class AddEditSportsman_Page : Page
    {
        private Sportsmen _currentSportsmen = new Sportsmen();
        public AddEditSportsman_Page(Sportsmen selectedSportsmen)
        {
            InitializeComponent();

            if (selectedSportsmen != null)
            {
                _currentSportsmen = selectedSportsmen;
                DP_Birthdate.SelectedDate = _currentSportsmen.Date_birhtday;
            }

            DataContext = _currentSportsmen;
            ComBox_SportClub.ItemsSource = demkaItogKursEntities.GetContext().Sportsmen.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentSportsmen.Surname == null)
                errors.AppendLine("Введите фамилию");
            if (_currentSportsmen.Name == null)
                errors.AppendLine("Введите имя");
            if (_currentSportsmen.Patronymic == null)
                errors.AppendLine("Введите отчество");

            if (_currentSportsmen.Date_birhtday == null)
            {
                if (DP_Birthdate.SelectedDate == null)
                {
                    errors.AppendLine("Выберите дату рождения");
                }
                else
                {
                    _currentSportsmen.Date_birhtday = DP_Birthdate.SelectedDate;
                }
            }

            if (_currentSportsmen.Sport_Club_ID == null)
                errors.AppendLine("Введите спортивный клуб");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentSportsmen.ID == 0)
                demkaItogKursEntities.GetContext().Sportsmen.Add(_currentSportsmen);

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
