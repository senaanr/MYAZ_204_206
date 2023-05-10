using SortingAlgorithmsApp;
using SortingAlgorithms;
using System.Data.SQLite;

string connection_string = @"Data Source=C:\\Users\\Senanr\\source\\repos\\MYAZ20420623-master\\DataStructuresAlgorithms\\SortingAlgorithmsApp\\Employee.db;Version=3;";

using var connection  = new SQLiteConnection(connection_string);

connection.Open();

string stm = "SELECT * FROM Employees";

using var cmd = new SQLiteCommand(stm, connection);

using SQLiteDataReader rdr = cmd.ExecuteReader();

List<Employee> employees = new List<Employee>();

while (rdr.Read())
{
    employees.Add(new Employee
    {
        Id = Convert.ToInt32(rdr["Id"]),FirstName = rdr.GetString(1).ToString(),LastName = rdr.GetString(2).ToString(),Salary = Convert.ToDouble(rdr["Salary"])
    });
}
connection.Close();
Console.WriteLine("1-4 Arası Bir Sayı Seçin Lütfen!");

var a = Console.ReadKey();
Console.WriteLine();

switch (a.Key)
{
    case ConsoleKey.NumPad1:
        double[] array1 = employees.Select(I => I.Salary).ToArray();
        BubbleSort.Sort(array1);
        foreach(double i in array1)
        {
            Console.WriteLine($"{i}");
        }

        break;
    case ConsoleKey.NumPad2:
        string[] array2 = employees.Select(I => I.FirstName).ToArray();
        InsertionSort.Sort(array2);
        foreach(string s in array2)
        {
            Console.WriteLine($"{s}");
        }
        break;
    case ConsoleKey.NumPad3:
        string[] array3 = employees.Select(L => L.LastName).ToArray();
        MergeSort.Sort(array3);
        foreach (string e in array3)
        {
            Console.WriteLine($"{e}");
        }
        break;
    case ConsoleKey.NumPad4:
        double[] array4 = employees.Select(S => S.Salary).ToArray();
        Quicksort.Sort(array4);
        foreach (double e in array4)
        {
            Console.WriteLine($"{e}");
        }
        break;
    default:
        Console.WriteLine("Geçersiz Seçim");
        break;
}