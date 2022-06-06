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
    public partial class AddEditCompetition_Page : Page
    {
        private Competitions _currentCompetition = new Competitions();
        public AddEditCompetition_Page(Competitions selectedCompetition)
        {
            InitializeComponent();

            if(selectedCompetition != null)
            {
                _currentCompetition = selectedCompetition;
                DP_StartDate.SelectedDate = _currentCompetition.StartDate;
                DP_EndDate.SelectedDate = _currentCompetition.EndDate;
            }

            DataContext = _currentCompetition;

            ComBox_Organizer.ItemsSource = demkaItogKursEntities.GetContext().Competitions.ToList();
            ComBox_Infrastructure.ItemsSource = demkaItogKursEntities.GetContext().Competitions.ToList();
            ComBox_TypeSports.ItemsSource = demkaItogKursEntities.GetContext().Competitions.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentCompetition.ID_Organizers == 0)
                errors.AppendLine("Выберите организатора");

            if (_currentCompetition.StartDate == null)
            {
                if(DP_StartDate.SelectedDate == null)
                {
                    errors.AppendLine("Выберите время начала");
                }
                else
                {
                    _currentCompetition.StartDate = DP_StartDate.SelectedDate;
                }
            }

            if (_currentCompetition.EndDate == null)
            {
                if(DP_EndDate.SelectedDate == null)
                {
                    errors.AppendLine("Выберите время окончания");
                }
                else
                {
                  _currentCompetition.EndDate = DP_EndDate.SelectedDate;
                }
            }


            if (_currentCompetition.ID_Infrastructure == 0)
                errors.AppendLine("Выберите инфраструктуру");
            if (_currentCompetition.ID_TypesSports == 0)
                errors.AppendLine("Выберите тип спорта");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if(_currentCompetition.ID == 0)
                demkaItogKursEntities.GetContext().Competitions.Add(_currentCompetition);
            try
            {
                demkaItogKursEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
