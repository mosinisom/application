//   DepartmentID SERIAL PRIMARY KEY,
//   DepartmentName VARCHAR,
//   ManagerID INTEGER

class Department
{
    public int DepartmentID { get; set; }
    public string DepartmentName { get; set; }
    public int ManagerID { get; set; }
}