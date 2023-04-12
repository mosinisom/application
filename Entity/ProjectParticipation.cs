//   ParticipationID SERIAL PRIMARY KEY,
//   EmployeeID INTEGER,
//   ProjectID INTEGER,
//   StartDate DATE,
//   EndDate DATE

class ProjectParticipation
{
    public int ParticipationID { get; set; }
    public int EmployeeID { get; set; }
    public int ProjectID { get; set; }
    public System.DateTime StartDate { get; set; }
    public System.DateTime EndDate { get; set; }
}