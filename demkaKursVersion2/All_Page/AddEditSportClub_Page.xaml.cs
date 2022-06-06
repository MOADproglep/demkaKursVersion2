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
    public partial class AddEditSportClub_Page : Page
    {
        private SportClub _currentSportClub = new SportClub();
        public AddEditSportClub_Page( SportClub selectedSportClub)
        {
            InitializeComponent();

            if (selectedSportClub != null)
            {
                _currentSportClub = selectedSportClub;
            }

            DataContext = _currentSportClub;
            ComBox_Cytis.ItemsSource = demkaItogKursEntities.GetContext().SportClub.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentSportClub.City_Base == 0)
                errors.AppendLine("Выберите город");
            if (_currentSportClub.Name == null)
                errors.AppendLine("Введите наименование");
          

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentSportClub.ID == 0)
                demkaItogKursEntities.GetContext().SportClub.Add(_currentSportClub);

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
