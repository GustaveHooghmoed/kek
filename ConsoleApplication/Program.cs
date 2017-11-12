using System;
using System.Collections;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Aquanura.AquaSharp.mysql;
using ConsoleApplication.AquaSharp.Utils;
using MySql.Data.MySqlClient;

namespace Aquanura
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try {
                var dbCon = DBConnection.Instance();
                
                dbCon.DatabaseName = "pieckcraft";
                if (dbCon.IsConnect())
                {
                    Logger.Info("mySQL started.", "Aquanura Developement Program");
                } 
                Logger.Info("Application started.", "Aquanura Developement Program");
                Logger.Info("What is your password.", "Aquanura Developement Program");
                var password = Console.ReadLine();

                if(password.Normalize().Equals("123")){
                    Logger.Info("WELCOME.", "Aquanura Developement Program");
                    var query = "SELECT id,x,y,z,yaw FROM Symbolica";
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    var reader = cmd.ExecuteReader();
                    ArrayList pointsList = new ArrayList();
                    while(reader.Read())
                    {
                        var id = reader.GetString(0);
                        var x = reader.GetString(1);
                        var y = reader.GetString(2);
                        var z = reader.GetString(3);
                        var yaw = reader.GetString(4);
                        var point = new Point(id,x,y,z,yaw);
                        pointsList.Add(point);
                    }
                    reader.Close();
                    foreach(Point point in pointsList)
                    {
                        Logger.Info(
                            String.Format("id {0}; xyzy, {1} {2} {3} {4}",point.id,point.x,point.y,point.z,point.yaw), "Aquanura Developement Program");
                    }
                    Logger.Info("Now lets read the txt file.", "Aquanura Developement Program");
                    string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Michel\Desktop\WriteLines2.txt");
                    foreach (string line in lines)
                    {
                        string[] splitted = line.Split(',');
                        string id = splitted[0];
                        string x = splitted[1];
                        string y = splitted[2];
                        string z = splitted[3];
                        string yaw = splitted[4];
                        if (pointsList.Contains(new Point(id,x,y,z,yaw)))
                        {
                            
                        }
                        MySqlCommand comm = new MySqlCommand(query, dbCon.Connection);
                        comm.CommandText = "INSERT INTO Symbolica(x,y,z,yaw) VALUES(?x, ?y, ?z, ?yaw)";
                        comm.Parameters.Add("?x", x);
                        comm.Parameters.Add("?y", y);
                        comm.Parameters.Add("?z", z);
                        comm.Parameters.Add("?yaw", yaw);
                        comm.ExecuteNonQuery();
                    } 
                }
                else
                {
                    Logger.Error("Wrong password.","Aquanura Developement Program");
                }
            } catch (Exception ex)
            {
                Logger.Error(ex, "MyApp");
            }   
        }
    }
}