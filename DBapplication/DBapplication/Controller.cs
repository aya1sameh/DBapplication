using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace DBapplication
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }

      
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Admin Players Functions

        public int UpdatePlayerInfo(int ID, string Fname, string Lname, int Match_ID, int Points, int Assists, int Goals)
        {
            string query = "UPDATE Players" +
                           " SET Fname = '" + Fname + "' , Lname = '" + Lname + "' , Match_ID = '" + Match_ID + "' , Points = '" + Points +
                            "' , Assists = '" + Assists + "' , Goals = '" + Goals + 
                            "' WHERE ID = '" + ID + "';" ;
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertPlayer(int ID, string Fname, string Lname,char position,int Club_ID,int price, int Assists, int Goals, int Match_ID, int Points)
        {
            string query = "INSERT INTO Players" +
                           " Values ('" + ID + "', '" + Fname + "', '" + Lname + "', '" + position + "', '" + Club_ID + "', '" +  price + 
                           "', '" + Assists + "', '" + Goals + "', '" + Match_ID + "', '" + Points + "', '0');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeletePlayer(int ID)
        {
            string query = "DELETE FROM Players WHERE ID = '" + ID + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable ShowPlayers()
        {
            string query = "SELECT * FROM Players;";
            return dbMan.ExecuteReader(query);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Admin Login

        public string AdminLogin(int ID)
        {
            string query = "SELECT job FROM Admins WHERE ID = '" + ID + "';";
            return (string)dbMan.ExecuteScalar(query);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Admin SignUp
        
        public int AdminSignUp(int ID, string Fname, string Lname, string job)
        {
            string query = "INSERT INTO Admins" +
                           " Values ('" + ID + "', '" + Fname + "', '" + Lname + "', '" + char.Parse(job) + "');";
            return dbMan.ExecuteNonQuery(query);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //UserLogin
        public bool UserLogin(int ID, string Fname, string Lname, int pass)
        {
            string query1 = "SELECT COUNT(1) FROM Users WHERE ID = '" + ID + "' AND Fname = '" + Fname + "' AND Lname = '" + Lname + "' AND U_Password = '" + pass + "';";
            bool isExist = (int)dbMan.ExecuteScalar(query1) == 0? false:true;
            return isExist;
        }

        //Clubs control functions

        public int UpdateClubInfo(int club_id, string club_name, int new_points)
        {

            string query = "UPDATE Clubs SET Club_name= '" + club_name + "' , Points= '" + new_points + "' "
            + "WHERE ID='" + club_id + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateClubPoints(int club_id, int new_points)
        {
            string query = "UPDATE Clubs SET Points= '" + new_points + "' "
            + "WHERE ID='" + club_id + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable SelectAllClubs()
        {
            string query = "SELECT * FROM Clubs ORDER BY Points  DESC;";
            return dbMan.ExecuteReader(query);
        }
        public int InsertClub(int club_id, string club_name)
        {
            string query = "INSERT INTO Clubs (ID, Club_name)" +
                            "Values ('" + club_id + "','" + club_name + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeleteClub(int club_id)
        {
            string query = "DELETE FROM Clubs WHERE ID='" + club_id + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeleteAllClubs()
        {
            string query = "DELETE FROM Clubs ;";
            return dbMan.ExecuteNonQuery(query);
        }

        //Fixtures control functions

        public DataTable SelectAllFixtures()
        {
            string query = "SELECT * FROM Fixtures ORDER BY M_Date,M_time DESC;";
            return dbMan.ExecuteReader(query);
        }

        public int UpdateFixture(int match_id, string match_date, string match_time, int home_club_id, int away_club_id, int home_club_score, int away_club_score)
        {
            string query = "UPDATE Fixtures SET M_Date= '" + match_date + "', M_time = '" + match_time + "', Home = '" + home_club_id + "', Away = '" + away_club_id + "' "
            + ", Home_Score = '" + home_club_score + "', Away_Score = '" + away_club_score + "' "
            + "WHERE Match_ID='" + match_id + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateFixtureScore(int match_id, int home_club_score, int away_club_score)
        {
            string query = "UPDATE Fixtures SET Home_Score = '" + home_club_score + "', Away_Score = '" + away_club_score + "' "
            + "WHERE Match_ID='" + match_id + "';";
            return dbMan.ExecuteNonQuery(query);


        }

        public int InsertFixture(int match_id, string match_date, string match_time, int home_club_id, int away_club_id)
        //int home_club_score, int away_club_score
        {
            string query = "INSERT INTO Fixtures (Match_ID, M_Date, M_time, Home, Away)" +
                            "Values ('" + match_id + "' ,'" + match_date + "','" + match_time + "' "
                            + ",'" + home_club_id + "','" + away_club_id + "');";
            return dbMan.ExecuteNonQuery(query);
        }
        public int DeleteFixture(int match_id)
        {
            string query = "DELETE FROM Fixtures WHERE Match_ID='" + match_id + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeleteAllFixtures()
        {
            string query = "DELETE FROM Clubs;";
            return dbMan.ExecuteNonQuery(query);
        }


        //insert new fixtures: Home club score and away club scores are not needed  "NULL-NULL"
        //insert new club: we only check on id, club name.
        //buttons to add to adminc, adminf:
        //1-delete all clubs button
        //2-delete all fixtures button
        //3-Update fixture scores: we may need only to update the score, so we neead a new button "Update fixture score".
        //4-Update club points: we may need only to update the points, so we neead a new button "Update club points".
        //text box to remove: club rank
    }
}
