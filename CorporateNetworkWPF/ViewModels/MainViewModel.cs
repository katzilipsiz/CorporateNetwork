using CommunityToolkit.Mvvm.Input;
using CorporateNetworkWPF.Dialogs;
using CorporationNetworkWPF.Models;
using CorporationNetworkWPF.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CorporationNetworkWPF.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IApiService _apiService;

        // Коллекции данных
        public ObservableCollection<MainDepartment> MainDepartments { get; set; }
        public ObservableCollection<Department> Departments { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public ObservableCollection<Position> Positions { get; set; }
        public ObservableCollection<Candidate> Candidates { get; set; }

        // Выбранные элементы
        private MainDepartment _selectedMainDepartment;
        public MainDepartment SelectedMainDepartment
        {
            get => _selectedMainDepartment;
            set
            {
                _selectedMainDepartment = value;
                OnPropertyChanged();
            }
        }

        private Department _selectedDepartment;
        public Department SelectedDepartment
        {
            get => _selectedDepartment;
            set
            {
                _selectedDepartment = value;
                OnPropertyChanged();
            }
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        // Флаги загрузки
        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        // Команды
        public ICommand LoadDataCommand { get; }
        public ICommand LoadMainDepartmentsCommand { get; }
        public ICommand LoadDepartmentsCommand { get; }
        public ICommand LoadEmployeesCommand { get; }
        public ICommand LoadPositionsCommand { get; }
        public ICommand LoadCandidatesCommand { get; }

        public ICommand AddMainDepartmentCommand { get; }
        public ICommand AddDepartmentCommand { get; }
        public ICommand AddEmployeeCommand { get; }

        public MainViewModel(IApiService apiService)
        {
            _apiService = apiService;

            // Инициализация коллекций
            MainDepartments = new ObservableCollection<MainDepartment>();
            Departments = new ObservableCollection<Department>();
            Employees = new ObservableCollection<Employee>();
            Positions = new ObservableCollection<Position>();
            Candidates = new ObservableCollection<Candidate>();

            // Инициализация команд
            LoadDataCommand = new RelayCommand(async () => await LoadAllDataAsync());
            LoadMainDepartmentsCommand = new RelayCommand(async () => await LoadMainDepartmentsAsync());
            LoadDepartmentsCommand = new RelayCommand(async () => await LoadDepartmentsAsync());
            LoadEmployeesCommand = new RelayCommand(async () => await LoadEmployeesAsync());
            LoadPositionsCommand = new RelayCommand(async () => await LoadPositionsAsync());
            LoadCandidatesCommand = new RelayCommand(async () => await LoadCandidatesAsync());

            AddMainDepartmentCommand = new RelayCommand(async () => await AddMainDepartmentAsync());
            AddDepartmentCommand = new RelayCommand(async () => await AddDepartmentAsync());
            AddEmployeeCommand = new RelayCommand(async () => await AddEmployeeAsync());

            // Загрузка данных при старте
            Task.Run(async () => await CheckConnectionAndLoadDataAsync());
        }

        private async Task CheckConnectionAndLoadDataAsync()
        {
            try
            {
                var isConnected = await _apiService.TestConnectionAsync();

                if (!isConnected)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        MessageBox.Show(
                            "Не удалось подключиться к серверу API.\n" +
                            "Убедитесь, что:\n" +
                            "1. Сервер API запущен\n" +
                            "2. URL адрес правильный\n" +
                            "3. CORS настроен на сервере",
                            "Ошибка подключения",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    });
                }
                else
                {
                    await LoadAllDataAsync();
                }
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show($"Ошибка при проверке подключения: {ex.Message}",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                });
            }
        }

        private async Task LoadAllDataAsync()
        {
            IsLoading = true;
            try
            {
                await Task.WhenAll(
                    LoadMainDepartmentsAsync(),
                    LoadDepartmentsAsync(),
                    LoadPositionsAsync()
                );
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task LoadMainDepartmentsAsync()
        {
            try
            {
                var departments = await _apiService.GetMainDepartmentsAsync();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MainDepartments.Clear();
                    foreach (var dept in departments)
                    {
                        MainDepartments.Add(dept);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки главных отделов: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task LoadDepartmentsAsync()
        {
            try
            {
                var departments = await _apiService.GetDepartmentsAsync();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Departments.Clear();
                    foreach (var dept in departments)
                    {
                        Departments.Add(dept);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отделов: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task LoadEmployeesAsync()
        {
            try
            {
                var employees = await _apiService.GetEmployeesAsync();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Employees.Clear();
                    foreach (var emp in employees)
                    {
                        Employees.Add(emp);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки сотрудников: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task LoadPositionsAsync()
        {
            try
            {
                var positions = await _apiService.GetPositionsAsync();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Positions.Clear();
                    foreach (var pos in positions)
                    {
                        Positions.Add(pos);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки должностей: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task LoadCandidatesAsync()
        {
            try
            {
                var candidates = await _apiService.GetCandidatesAsync();
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Candidates.Clear();
                    foreach (var cand in candidates)
                    {
                        Candidates.Add(cand);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки кандидатов: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task AddMainDepartmentAsync()
        {
            try
            {
                var dialog = new InputDialog("Добавить главный отдел", "Введите название отдела:");
                if (dialog.ShowDialog() == true && !string.IsNullOrWhiteSpace(dialog.Answer))
                {
                    var newDept = await _apiService.CreateMainDepartmentAsync(
                        new CreateMainDepartmentDto { MainDepartmentName = dialog.Answer });

                    if (newDept != null)
                    {
                        MainDepartments.Add(newDept);
                        MessageBox.Show("Главный отдел успешно добавлен",
                            "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления главного отдела: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task AddDepartmentAsync()
        {
            try
            {
                var dialog = new DepartmentDialog();
                if (dialog.ShowDialog() == true)
                {
                    var newDept = await _apiService.CreateDepartmentAsync(dialog.Department);

                    if (newDept != null)
                    {
                        Departments.Add(newDept);
                        MessageBox.Show("Отдел успешно добавлен",
                            "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления отдела: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task AddEmployeeAsync()
        {
            try
            {
                var positionsList = Positions.ToList();
                var departmentsList = Departments.ToList();

                var dialog = new EmployeeDialog(positionsList, departmentsList);
                if (dialog.ShowDialog() == true)
                {
                    var newEmp = await _apiService.CreateEmployeeAsync(dialog.Employee);

                    if (newEmp != null)
                    {
                        Employees.Add(newEmp);
                        MessageBox.Show("Сотрудник успешно добавлен",
                            "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления сотрудника: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}