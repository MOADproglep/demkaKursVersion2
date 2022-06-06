using demkaKursVersion2.All_Class;
using demkaKursVersion2.All_Page;
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
    public partial class MainTables_Page : Page
    {
        public MainTables_Page()
        {
            InitializeComponent();
        }

        private void BtnEditCompetition_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditCompetition_Page((sender as Button).DataContext as Competitions));
        }

        private void BtnEditSportsman_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSportsman_Page((sender as Button).DataContext as Sportsmen));
        }

        private void BtnEditTrainers_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditTrainers_Page((sender as Button).DataContext as Trainer));
        }

        private void BtnEditSpotrClub_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditSportClub_Page((sender as Button).DataContext as SportClub));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            switch(TabControl_MainTable.SelectedIndex)
            {
                case 0: //Соревнования
                    Manager.MainFrame.Navigate(new AddEditCompetition_Page(null));
                    break;
                case 1: //Спортсмены
                    Manager.MainFrame.Navigate(new AddEditSportsman_Page(null));
                    break;
                case 2: // Тренера
                    Manager.MainFrame.Navigate(new AddEditTrainers_Page(null));
                    break;
                case 3: // Спортивный клуб
                    Manager.MainFrame.Navigate(new AddEditSportClub_Page(null));
                    break;
                default:
                    MessageBox.Show("Ошибка выбора окна");
                    break;
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            switch(TabControl_MainTable.SelectedIndex)
            {
                case 0: //Соревнования
                    var competitionsForRemoving = CompetitionsGrid.SelectedItems.Cast<Competitions>().ToList();
                    if (MessageBox.Show($"Вы точно хотите удалить следующие {competitionsForRemoving.Count()} элементов?", "Внимание",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            demkaItogKursEntities.GetContext().Competitions.RemoveRange(competitionsForRemoving);
                            demkaItogKursEntities.GetContext().SaveChanges();
                            MessageBox.Show("Данные удалены");

                            CompetitionsGrid.ItemsSource = demkaItogKursEntities.GetContext().Competitions.ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                    break;
                case 1: //Спортсмены
                    var sportsMenForRemoving = SportsmenGrid.SelectedItems.Cast<Sportsmen>().ToList();
                    if (MessageBox.Show($"Вы точно хотите удалить следующие {sportsMenForRemoving.Count()} элементов?", "Внимание",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            demkaItogKursEntities.GetContext().Sportsmen.RemoveRange(sportsMenForRemoving);
                            demkaItogKursEntities.GetContext().SaveChanges();
                            MessageBox.Show("Данные удалены");

                            SportsmenGrid.ItemsSource = demkaItogKursEntities.GetContext().Sportsmen.ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                    break;
                case 2: // Тренера
                    var trainerForRemoving = TrainerGrid.SelectedItems.Cast<Trainer>().ToList();
                    if (MessageBox.Show($"Вы точно хотите удалить следующие {trainerForRemoving.Count()} элементов?", "Внимание",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            demkaItogKursEntities.GetContext().Trainer.RemoveRange(trainerForRemoving);
                            demkaItogKursEntities.GetContext().SaveChanges();
                            MessageBox.Show("Данные удалены");

                            TrainerGrid.ItemsSource = demkaItogKursEntities.GetContext().Trainer.ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                    break;
                case 3: // Спортивный клуб
                    var sportClubForRemoving = SportClubGrid.SelectedItems.Cast<SportClub>().ToList();
                    if (MessageBox.Show($"Вы точно хотите удалить следующие {sportClubForRemoving.Count()} элементов?", "Внимание",
                        MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            demkaItogKursEntities.GetContext().SportClub.RemoveRange(sportClubForRemoving);
                            demkaItogKursEntities.GetContext().SaveChanges();
                            MessageBox.Show("Данные удалены");

                            SportClubGrid.ItemsSource = demkaItogKursEntities.GetContext().SportClub.ToList();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                    break;
                default:
                    MessageBox.Show("Ошибка выбора окна для удаления");
                    break;
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                demkaItogKursEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                CompetitionsGrid.ItemsSource = demkaItogKursEntities.GetContext().Competitions.ToList();
                SportsmenGrid.ItemsSource = demkaItogKursEntities.GetContext().Sportsmen.ToList();
                TrainerGrid.ItemsSource = demkaItogKursEntities.GetContext().Trainer.ToList();
                SportClubGrid.ItemsSource = demkaItogKursEntities.GetContext().SportClub.ToList();
            }
        }

        private void TB_ShowOthertable_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new OtherTables_Page());
        }
    }
}
