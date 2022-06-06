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
    public partial class OtherTables_Page : Page
    {
        public OtherTables_Page()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                demkaItogKursEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());

                TypesSportsGrid.ItemsSource = demkaItogKursEntities.GetContext().TypesSports.ToList();
                CategoriesSportsGrid.ItemsSource = demkaItogKursEntities.GetContext().CategoriesSports.ToList();
                CitysGrid.ItemsSource = demkaItogKursEntities.GetContext().Citys.ToList();
                InfrastructureGrid.ItemsSource = demkaItogKursEntities.GetContext().Infrastructure.ToList();
                OrganizersGrid.ItemsSource = demkaItogKursEntities.GetContext().Organizers.ToList();
                RegistrationCompetitionGrid.ItemsSource = demkaItogKursEntities.GetContext().RegistrationCompetition.ToList();
                SpecificationsGrid.ItemsSource = demkaItogKursEntities.GetContext().Specifications.ToList();
                SpecificationsInfrastructureGrid.ItemsSource = demkaItogKursEntities.GetContext().SpecificationsInfrastructure.ToList();
                TrainerSportsmenGrid.ItemsSource = demkaItogKursEntities.GetContext().TrainerSportsmen.ToList();
                TypesSports_SportsmenGrid.ItemsSource = demkaItogKursEntities.GetContext().TypesSports_Sportsmen.ToList();
                TypeStructureGrid.ItemsSource = demkaItogKursEntities.GetContext().TypeStructure.ToList();
            }
        }
    }
}
