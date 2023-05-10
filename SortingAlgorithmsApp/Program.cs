using SortingAlgorithmsApp;
using SortingAlgorithms;
using System.Data.SQLite;

string con_string = @"Data Source=C:\\Users\\mgull\\source\\repos\\MYAZ20420623-master\\DataStructuresAlgorithms\\SortingAlgorithmsApp\\Employee.db;Version=3;";
using var con  = new SQLiteConnection(con_string);
con.Open();
string stm = "SELECT * FROM Employees";
using var cmd = new SQLiteCommand(stm, con);
using SQLiteDataReader rdr = cmd.ExecuteReader();

List<Employee> employees = new List<Employee>();

while (rdr.Read())
{
    employees.Add(new Employee
    {
        Id = Convert.ToInt32(rdr["Id"]),
        FirstName = rdr.GetString(1).ToString(),
        LastName = rdr.GetString(2).ToString(),
        Salary = Convert.ToDouble(rdr["Salary"]),
        Title = rdr.GetString(4).ToString()
    });
}
con.Close();
Console.WriteLine("1-4 Arası Bir Sayı Seçiniz");

var a = Console.ReadKey();
Console.WriteLine();

switch (a.Key)
{
    case ConsoleKey.NumPad1:
        double[] arr = employees.Select(I => I.Salary).ToArray();
        BubbleSort.Sort(arr);
        foreach(double i in arr)
        {
            Console.WriteLine($"{i}");
        }

        break;
    case ConsoleKey.NumPad2:
        string[] arr1 = employees.Select(I => I.FirstName).ToArray();
        InsertionSort.Sort(arr1);
        foreach(string s in arr1)
        {
            Console.WriteLine($"{s}");
        }
        break;
    case ConsoleKey.NumPad3:
        string[] arr2 = employees.Select(L => L.LastName).ToArray();
        MergeSort.Sort(arr2);
        foreach (string e in arr2)
        {
            Console.WriteLine($"{e}");
        }
        break;
    case ConsoleKey.NumPad4:
        double[] arr3 = employees.Select(S => S.Salary).ToArray();
        Quicksort.Sort(arr3);
        foreach (double e in arr3)
        {
            Console.WriteLine($"{e}");
        }
        break;
    default:
        Console.WriteLine("Geçersiz Seçim");
        break;
}