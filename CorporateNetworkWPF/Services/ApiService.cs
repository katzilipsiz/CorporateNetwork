using CorporationNetworkWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CorporationNetworkWPF.Services
{
    public interface IApiService
    {
        Task<bool> TestConnectionAsync();

        // MainDepartments
        Task<List<MainDepartment>> GetMainDepartmentsAsync();
        Task<MainDepartment> GetMainDepartmentAsync(int id);
        Task<MainDepartment> CreateMainDepartmentAsync(CreateMainDepartmentDto dto);
        Task<bool> UpdateMainDepartmentAsync(int id, UpdateMainDepartmentDto dto);
        Task<bool> DeleteMainDepartmentAsync(int id);

        // Departments
        Task<List<Department>> GetDepartmentsAsync();
        Task<Department> GetDepartmentAsync(int id);
        Task<Department> CreateDepartmentAsync(CreateDepartmentDto dto);
        Task<bool> UpdateDepartmentAsync(int id, CreateDepartmentDto dto);
        Task<bool> DeleteDepartmentAsync(int id);

        // Positions
        Task<List<Position>> GetPositionsAsync();
        Task<Position> GetPositionAsync(int id);
        Task<Position> CreatePositionAsync(CreatePositionDto dto);
        Task<bool> UpdatePositionAsync(int id, CreatePositionDto dto);
        Task<bool> DeletePositionAsync(int id);

        // Employees
        Task<List<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeAsync(int id);
        Task<Employee> CreateEmployeeAsync(CreateEmployeeDto dto);
        Task<bool> UpdateEmployeeAsync(int id, CreateEmployeeDto dto);
        Task<bool> DeleteEmployeeAsync(int id);

        // Candidates
        Task<List<Candidate>> GetCandidatesAsync();
        Task<Candidate> GetCandidateAsync(int id);
        Task<Candidate> CreateCandidateAsync(CreateCandidateDto dto);
        Task<bool> UpdateCandidateAsync(int id, CreateCandidateDto dto);
        Task<bool> DeleteCandidateAsync(int id);

        // Vacations
        Task<List<VacationCalendar>> GetVacationsAsync();
        Task<VacationCalendar> GetVacationAsync(int id);
        Task<VacationCalendar> CreateVacationAsync(CreateVacationCalendarDto dto);
        Task<bool> UpdateVacationAsync(int id, CreateVacationCalendarDto dto);
        Task<bool> DeleteVacationAsync(int id);

        // TrainingCalendars
        Task<List<TrainingCalendar>> GetTrainingCalendarsAsync();
        Task<TrainingCalendar> GetTrainingCalendarAsync(int id);
        Task<TrainingCalendar> CreateTrainingCalendarAsync(CreateTrainingCalendarDto dto);
        Task<bool> UpdateTrainingCalendarAsync(int id, CreateTrainingCalendarDto dto);
        Task<bool> DeleteTrainingCalendarAsync(int id);

        // Materials
        Task<List<Material>> GetMaterialsAsync();
        Task<Material> GetMaterialAsync(int id);
        Task<Material> CreateMaterialAsync(CreateMaterialDto dto);
        Task<bool> UpdateMaterialAsync(int id, CreateMaterialDto dto);
        Task<bool> DeleteMaterialAsync(int id);

        // Events
        Task<List<Event>> GetEventsAsync();
        Task<Event> GetEventAsync(int id);
        Task<Event> CreateEventAsync(CreateEventDto dto);
        Task<bool> UpdateEventAsync(int id, CreateEventDto dto);
        Task<bool> DeleteEventAsync(int id);
    }

    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7187/api/";

        public ApiService()
        {
            // Добавьте этот обработчик для игнорирования ошибок SSL
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(_baseUrl)
            };

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Проверка подключения
        public async Task<bool> TestConnectionAsync()
        {
            try
            {
                // Добавьте подробное логирование
                Console.WriteLine($"🔄 Пытаюсь подключиться к {_httpClient.BaseAddress}MainDepartments");

                var response = await _httpClient.GetAsync("MainDepartments");

                Console.WriteLine($"📊 Получен ответ: {response.StatusCode}");
                Console.WriteLine($"📄 Причина: {response.ReasonPhrase}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"❌ Ошибка от сервера: {errorContent}");
                }

                return response.IsSuccessStatusCode;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"🌐 Ошибка сети: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"🔧 Внутренняя ошибка: {ex.InnerException.Message}");
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Общая ошибка: {ex.Message}");
                return false;
            }
        }

        // Общий метод для GET запросов
        private async Task<T> GetAsync<T>(string endpoint)
        {
            try
            {
                var response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error GET {endpoint}: {ex.Message}");
                throw;
            }
        }

        // Общий метод для POST запросов
        private async Task<T> PostAsync<T>(string endpoint, object data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error POST {endpoint}: {ex.Message}");
                throw;
            }
        }

        // Общий метод для PUT запросов
        private async Task<bool> PutAsync(string endpoint, object data)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(endpoint, content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error PUT {endpoint}: {ex.Message}");
                throw;
            }
        }

        // Общий метод для DELETE запросов
        private async Task<bool> DeleteAsync(string endpoint)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(endpoint);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error DELETE {endpoint}: {ex.Message}");
                throw;
            }
        }

        // MainDepartments
        public async Task<List<MainDepartment>> GetMainDepartmentsAsync() =>
            await GetAsync<List<MainDepartment>>("MainDepartments");

        public async Task<MainDepartment> GetMainDepartmentAsync(int id) =>
            await GetAsync<MainDepartment>($"MainDepartments/{id}");

        public async Task<MainDepartment> CreateMainDepartmentAsync(CreateMainDepartmentDto dto) =>
            await PostAsync<MainDepartment>("MainDepartments", dto);

        public async Task<bool> UpdateMainDepartmentAsync(int id, UpdateMainDepartmentDto dto) =>
            await PutAsync($"MainDepartments/{id}", dto);

        public async Task<bool> DeleteMainDepartmentAsync(int id) =>
            await DeleteAsync($"MainDepartments/{id}");

        // Departments
        public async Task<List<Department>> GetDepartmentsAsync() =>
            await GetAsync<List<Department>>("Departments");

        public async Task<Department> GetDepartmentAsync(int id) =>
            await GetAsync<Department>($"Departments/{id}");

        public async Task<Department> CreateDepartmentAsync(CreateDepartmentDto dto) =>
            await PostAsync<Department>("Departments", dto);

        public async Task<bool> UpdateDepartmentAsync(int id, CreateDepartmentDto dto) =>
            await PutAsync($"Departments/{id}", dto);

        public async Task<bool> DeleteDepartmentAsync(int id) =>
            await DeleteAsync($"Departments/{id}");

        // Positions
        public async Task<List<Position>> GetPositionsAsync() =>
            await GetAsync<List<Position>>("Positions");

        public async Task<Position> GetPositionAsync(int id) =>
            await GetAsync<Position>($"Positions/{id}");

        public async Task<Position> CreatePositionAsync(CreatePositionDto dto) =>
            await PostAsync<Position>("Positions", dto);

        public async Task<bool> UpdatePositionAsync(int id, CreatePositionDto dto) =>
            await PutAsync($"Positions/{id}", dto);

        public async Task<bool> DeletePositionAsync(int id) =>
            await DeleteAsync($"Positions/{id}");

        // Employees
        public async Task<List<Employee>> GetEmployeesAsync() =>
            await GetAsync<List<Employee>>("Employees");

        public async Task<Employee> GetEmployeeAsync(int id) =>
            await GetAsync<Employee>($"Employees/{id}");

        public async Task<Employee> CreateEmployeeAsync(CreateEmployeeDto dto) =>
            await PostAsync<Employee>("Employees", dto);

        public async Task<bool> UpdateEmployeeAsync(int id, CreateEmployeeDto dto) =>
            await PutAsync($"Employees/{id}", dto);

        public async Task<bool> DeleteEmployeeAsync(int id) =>
            await DeleteAsync($"Employees/{id}");

        // Candidates
        public async Task<List<Candidate>> GetCandidatesAsync() =>
            await GetAsync<List<Candidate>>("Candidates");

        public async Task<Candidate> GetCandidateAsync(int id) =>
            await GetAsync<Candidate>($"Candidates/{id}");

        public async Task<Candidate> CreateCandidateAsync(CreateCandidateDto dto) =>
            await PostAsync<Candidate>("Candidates", dto);

        public async Task<bool> UpdateCandidateAsync(int id, CreateCandidateDto dto) =>
            await PutAsync($"Candidates/{id}", dto);

        public async Task<bool> DeleteCandidateAsync(int id) =>
            await DeleteAsync($"Candidates/{id}");

        // Vacations
        public async Task<List<VacationCalendar>> GetVacationsAsync() =>
            await GetAsync<List<VacationCalendar>>("VacationCalendars");

        public async Task<VacationCalendar> GetVacationAsync(int id) =>
            await GetAsync<VacationCalendar>($"VacationCalendars/{id}");

        public async Task<VacationCalendar> CreateVacationAsync(CreateVacationCalendarDto dto) =>
            await PostAsync<VacationCalendar>("VacationCalendars", dto);

        public async Task<bool> UpdateVacationAsync(int id, CreateVacationCalendarDto dto) =>
            await PutAsync($"VacationCalendars/{id}", dto);

        public async Task<bool> DeleteVacationAsync(int id) =>
            await DeleteAsync($"VacationCalendars/{id}");

        // TrainingCalendars
        public async Task<List<TrainingCalendar>> GetTrainingCalendarsAsync() =>
            await GetAsync<List<TrainingCalendar>>("TrainingCalendars");

        public async Task<TrainingCalendar> GetTrainingCalendarAsync(int id) =>
            await GetAsync<TrainingCalendar>($"TrainingCalendars/{id}");

        public async Task<TrainingCalendar> CreateTrainingCalendarAsync(CreateTrainingCalendarDto dto) =>
            await PostAsync<TrainingCalendar>("TrainingCalendars", dto);

        public async Task<bool> UpdateTrainingCalendarAsync(int id, CreateTrainingCalendarDto dto) =>
            await PutAsync($"TrainingCalendars/{id}", dto);

        public async Task<bool> DeleteTrainingCalendarAsync(int id) =>
            await DeleteAsync($"TrainingCalendars/{id}");

        // Materials
        public async Task<List<Material>> GetMaterialsAsync() =>
            await GetAsync<List<Material>>("Materials");

        public async Task<Material> GetMaterialAsync(int id) =>
            await GetAsync<Material>($"Materials/{id}");

        public async Task<Material> CreateMaterialAsync(CreateMaterialDto dto) =>
            await PostAsync<Material>("Materials", dto);

        public async Task<bool> UpdateMaterialAsync(int id, CreateMaterialDto dto) =>
            await PutAsync($"Materials/{id}", dto);

        public async Task<bool> DeleteMaterialAsync(int id) =>
            await DeleteAsync($"Materials/{id}");

        // Events
        public async Task<List<Event>> GetEventsAsync() =>
            await GetAsync<List<Event>>("Events");

        public async Task<Event> GetEventAsync(int id) =>
            await GetAsync<Event>($"Events/{id}");

        public async Task<Event> CreateEventAsync(CreateEventDto dto) =>
            await PostAsync<Event>("Events", dto);

        public async Task<bool> UpdateEventAsync(int id, CreateEventDto dto) =>
            await PutAsync($"Events/{id}", dto);

        public async Task<bool> DeleteEventAsync(int id) =>
            await DeleteAsync($"Events/{id}");


    }
}