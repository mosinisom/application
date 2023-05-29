using System;
using System.Collections.Generic;

public class Data
{
    UserService _userService;
    // Employee userEmployee = new Employee();
    // List<Department> departments = new List<Department>();
    // List<Position> positions = new List<Position>();
    // List<Project> projects = new List<Project>();
    // List<ProjectParticipation> projectParticipations = new List<ProjectParticipation>();

    public Data(UserService userService)
    {
        _userService = userService;
    }

    // Проверка на существование пользователя с таким email
    public bool CheckExistance(string email) { return _userService.CheckExistance(email); }

    // Добавление нового сотрудника
    public void AddEmployee(Employee user) { _userService.AddEmployee(user); }

    // Получение списка всех сотрудников
    public List<Employee> GetEmployees() { return _userService.GetEmployees(); }

    // Обновление информации о сотруднике
    public void UpdateEmployee(Employee employee) { _userService.UpdateEmployee(employee); }

    // Удаление сотрудника
    public void DeleteEmployee(Employee employee) { _userService.DeleteEmployee(employee); }

    // Получение информации о сотруднике по его идентификатору
    public Employee GetEmployeeById(int id) { return _userService.GetEmployeeById(id); }

    // Получение информации о сотруднике по его email
    public Employee GetEmployeeByEmail(string email) { return _userService.GetEmployeeByEmail(email); }

    // Получение списка сотрудников по идентификатору отдела
    public List<Employee> GetEmployeesByDepartmentId(int departmentId) { return _userService.GetEmployeesByDepartmentId(departmentId); }

    // Получение списка сотрудников по идентификатору должности
    public List<Employee> GetEmployeesByPositionId(int positionId) { return _userService.GetEmployeesByPositionId(positionId); }

    // Получение списка сотрудников по идентификатору проекта
    public List<Employee> GetEmployeesByProjectId(int projectId) { return _userService.GetEmployeesByProjectId(projectId); }

    // Отметка о посещении сотрудником работы
    public void attendWork(int employeeid) { _userService.attendWork(employeeid); }

}