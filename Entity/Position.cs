//   PositionID SERIAL PRIMARY KEY,
//   PositionName VARCHAR,
//   Salary NUMERIC

class Position
{
    public int PositionID { get; set; }
    public string PositionName { get; set; }
    public int ObeyTo { get; set; }
}