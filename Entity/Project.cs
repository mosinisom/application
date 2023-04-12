//   ProjectID SERIAL PRIMARY KEY,
//   ProjectName VARCHAR,
//   StartDate DATE,
//   EndDate DATE


class Project
{
    public int ProjectID { get; set; }
    public string ProjectName { get; set; }
    public System.DateTime StartDate { get; set; }
    public System.DateTime EndDate { get; set; }
}