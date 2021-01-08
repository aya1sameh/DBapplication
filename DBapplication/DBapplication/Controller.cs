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
        private DBManager dbMan;
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

        public int UpdateHomeClubInfo(int club_id, string club_name, int new_points)
        {

            string query = "UPDATE HomeClub SET Club_name= '" + club_name + "' , Points= '" + new_points + "' "
            + "WHERE ID='" + club_id + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateHomeClubPoints(int club_id, int new_points)
        {
            string query = "UPDATE HomeClub SET Points= '" + new_points + "' "
            + "WHERE ID='" + club_id + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable SelectAllHomeClubs()
        {
            string query = "SELECT * FROM HomeClub ORDER BY Points  DESC;";
            return dbMan.ExecuteReader(query);
        }
        public int InsertHomeClub(int club_id, string club_name)
        {
            string query = "INSERT INTO HomeClub (ID, Club_name)" +
                            "Values ('" + club_id + "','" + club_name + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeleteHomeClub(int club_id)
        {
            string query = "DELETE FROM HomeClub WHERE ID='" + club_id + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeleteAllHomeClubs()
        {
            string query = "DELETE FROM HomeClub ;";
            return dbMan.ExecuteNonQuery(query);
        }
        //Away clubs

        public int UpdateAwayClubInfo(int club_id, string club_name, int new_points)
        {

            string query = "UPDATE AwayClub SET Club_name= '" + club_name + "' , Points= '" + new_points + "' "
            + "WHERE ID='" + club_id + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateAwayClubPoints(int club_id, int new_points)
        {
            string query = "UPDATE AwayClub SET Points= '" + new_points + "' "
            + "WHERE ID='" + club_id + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable SelectAllAwayClubs()
        {
            string query = "SELECT * FROM AwayClub ORDER BY Points  DESC;";
            return dbMan.ExecuteReader(query);
        }
        public int InsertAwayClub(int club_id, string club_name)
        {
            string query = "INSERT INTO AwayClub (ID, Club_name)" +
                            "Values ('" + club_id + "','" + club_name + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeleteAwayClub(int club_id)
        {
            string query = "DELETE FROM AwayClub WHERE ID='" + club_id + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int DeleteAllAwayClubs()
        {
            string query = "DELETE FROM AwayClub ;";
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

        //USER control functions
        //textBox2.Text=//Query get user rank given id in UserID
        //textBox3.Text =//Query get bank rank given id in UserID
        //textBox4.Text =//Query get Avg score of all users
        //textBox5.Text =//Query get user score given id in UserID
        //textBox6.Text =//Query get Max score of all users
        //textBox7.Text =//Query get user Team Name given id in UserID

         public DataTable  GetUserInfo(int user_id, ref int rank, ref int bank, ref int points, ref int maxpoints, ref int avgpoints)
        {
            string query1 = "SELECT AVG(Global_rank) FROM Users GROUP BY ID HAVING ID= '" + user_id +"';";
            rank = (int)dbMan.ExecuteScalar(query1);

            string query2 = "SELECT AVG(Bank) FROM Users GROUP BY ID HAVING ID= '" + user_id + "';";
            bank = (int)dbMan.ExecuteScalar(query2);

            string query4 = "SELECT AVG(TotalPoints) FROM Users GROUP BY ID HAVING ID= '" + user_id + "';";
            points = (int)dbMan.ExecuteScalar(query4);

            string query5 = "SELECT MAX(TotalPoints) FROM Users;";
            maxpoints = (int)dbMan.ExecuteScalar(query5);

            string query6 = "SELECT AVG(TotalPoints) FROM Users;";
            avgpoints = (int)dbMan.ExecuteScalar(query6);

            string query3 = "SELECT TeamName FROM Users WHERE ID = '" + user_id + "';";
            return dbMan.ExecuteReader(query3);
            
        }
        public int InsertUser(int ID, string Fname, string Lname, int pass)
        {
            string query = "INSERT INTO Users ( ID, Fname, Lname, U_Password,Global_rank,TeamName,Bank,TotalPoints ) " +
                           " Values ('" + ID + "', '" + Fname + "', '" + Lname + "', '" + pass + "',0,'',100,0);";
            return dbMan.ExecuteNonQuery(query);
        }
        //User team 

        public DataTable SelectAllUserTeam(int user_id)
        {
            string query = "SELECT Fname, Lname, Players.Position, Players.Points, Goals, Assists, Fit, HomeClub.Club_name , AwayClub.Club_name   "
                + "FROM Pick_Team , Players ,Fixtures , HomeClub , AwayClub "
                + "WHERE PlayerID=Players.ID and Fixtures.Match_ID=Players.Match_ID and Fixtures.Home=HomeClub.ID and Fixtures.Away=AwayClub.ID and UserID=' " + user_id + " ';";
            // and (P.Club_=F.Away or P.Club_ID=F.Home)
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectAllUserLeagues(int user_id)
        {
            string query = "SELECT L_Name, User_rank, Fname "
                + "FROM Joined, Leagues, Users "
                + "WHERE Joined.League_ID=Leagues.League_ID and Createdby=ID and UserID=' " + user_id + " ';";
            
            return dbMan.ExecuteReader(query);
        }

        

        public DataTable SelectAllUserChips(int user_id)
        {
            string query = "SELECT C_Name, C_Description, Used "
                + "FROM Uses, Chips "
                + "WHERE ChipID=ID and UserID=' " + user_id + " ';";

            return dbMan.ExecuteReader(query);
        }

        public int UpdateUserTeamName(int user_id, string team_name)
        {
            string query = "UPDATE Users SET TeamName= '" + team_name + "' "
            + "WHERE ID='" + user_id + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        
        public int RemovePlayer(int player_id, int user_id)
        {
            string query = "DELETE FROM Pick_Team WHERE PlayerID = '" + player_id + "' AND UserID = '" + user_id + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        public int AddPlayer(int player_id, int user_id)
        {
            string query = "INSERT INTO Pick_Team VALUES ('" + user_id + "' , '" + player_id + "');";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateBank(int user_id, int new_bank,ref int bank)
        {
            string query = "UPDATE Users SET Bank = '" + new_bank + "' WHERE ID = '" + user_id + "';";
            int result = dbMan.ExecuteNonQuery(query);
            if(result != 0)
            {
                string query1 = "SELECT Bank FROM Users WHERE ID = '" + user_id + "';";
                bank = Int32.Parse(dbMan.ExecuteScalar(query1).ToString());
            }
            return dbMan.ExecuteNonQuery(query);
        }
        //query get all un picked players : PlayersTable-UserTeamTable 
        public DataTable SelectAllUserUnpickedTeam(int user_id)
        {
            //ID first,price after position in both picked,unpicked
            string query = "SELECT ID, Fname, Lname, Position, Price, Points, Goals, Assists, Fit FROM Players WHERE NOT EXISTS "
                + "(SELECT * FROM Pick_Team WHERE ID=PlayerID and UserID ='" + user_id + "');";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectAllUserPickedTeam(int user_id)
        {
            string query = "SELECT ID, Fname, Lname, Position, Price ,Points, Goals, Assists, Fit FROM Players, Pick_Team "
                + "WHERE ID=PlayerID and UserID ='" + user_id + "';";
            return dbMan.ExecuteReader(query);
        }

        //Denfenders
        public DataTable SelectAllUserUnpickedDef(int user_id)
        {
            //ID first,price after position in both picked,unpicked
            string query = "SELECT ID, Fname, Lname, Position, Price, Points, Goals, Assists, Fit FROM Players WHERE Position='D' and NOT EXISTS "
                + "(SELECT * FROM Pick_Team WHERE ID=PlayerID and UserID ='" + user_id + "');";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectAllUserPickedDef(int user_id)
        {
            string query = "SELECT ID, Fname, Lname, Position, Price ,Points, Goals, Assists, Fit FROM Players, Pick_Team "
                + "WHERE ID=PlayerID and UserID ='" + user_id + "' and Position='D' ;";
            return dbMan.ExecuteReader(query);
        }

        //Midfielders
        public DataTable SelectAllUserUnpickedMid(int user_id)
        {
            //ID first,price after position in both picked,unpicked
            string query = "SELECT ID, Fname, Lname, Position, Price, Points, Goals, Assists, Fit FROM Players WHERE Position='M' and NOT EXISTS "
                + "(SELECT * FROM Pick_Team WHERE ID=PlayerID and UserID ='" + user_id + "' and Position='M' );";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectAllUserPickedMid(int user_id)
        {
            string query = "SELECT ID, Fname, Lname, Position, Price ,Points, Goals, Assists, Fit FROM Players, Pick_Team "
                + "WHERE ID=PlayerID and UserID ='" + user_id + "' and Position='M' ;";
            return dbMan.ExecuteReader(query);
        }


        //Forwards

        public DataTable SelectAllUserUnpickedFwd(int user_id)
        {
            //ID first,price after position in both picked,unpicked
            string query = "SELECT ID, Fname, Lname, Position, Price, Points, Goals, Assists, Fit FROM Players WHERE Position='F' and NOT EXISTS "
                + "(SELECT * FROM Pick_Team WHERE ID=PlayerID and UserID ='" + user_id + "' and Position='F' );";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectAllUserPickedFwd(int user_id)
        {
            string query = "SELECT ID, Fname, Lname, Position, Price ,Points, Goals, Assists, Fit FROM Players, Pick_Team "
                + "WHERE ID=PlayerID and UserID ='" + user_id + "' and Position='F' ;";
            return dbMan.ExecuteReader(query);
        }



        //Goalkeepers

        public DataTable SelectAllUserUnpickedGK(int user_id)
        {
            //ID first,price after position in both picked,unpicked
            string query = "SELECT ID, Fname, Lname, Position, Price, Points, Goals, Assists, Fit FROM Players WHERE Position='G' and NOT EXISTS "
                + "(SELECT * FROM Pick_Team WHERE ID=PlayerID and UserID ='" + user_id + "' and Position='G' );";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectAllUserPickedGK(int user_id)
        {
            string query = "SELECT ID, Fname, Lname, Position, Price ,Points, Goals, Assists, Fit FROM Players, Pick_Team "
                + "WHERE ID=PlayerID and UserID ='" + user_id + "' and Position='G';";
            return dbMan.ExecuteReader(query);
        }

        //New League
        public int InsertUserInLeague(int user_id, int league_id)
        {
            string query = "INSERT INTO Joined (League_ID, UserID)" +
                            "Values ('" + league_id + "','" + user_id + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int InsertNewLeague(int user_id, int league_id, string league_name)
        {
            string query = "INSERT INTO Leagues (League_ID, L_Name, Createdby)" +
                            "Values ('" + league_id + "','" + league_name + "','" + user_id + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int GetPlayerID(string player_fname)
        {
            string query = "SELECT AVG(ID) FROM Players GROUP BY ID HAVING Fname= '" + player_fname + "';";
            return (int)dbMan.ExecuteScalar(query);

        }


        public DataTable SelectUsersUsedWildcard(int user_id)
        {
            string query = "SELECT Used "
                + "FROM Uses, Chips "
                + "WHERE ChipID=ID and UserID=' " + user_id + " ' and C_Name= 'Wild Card' ;";

            return dbMan.ExecuteReader(query);
            
        }
        
        public DataTable SelectUsersUsedTriplecaptain(int user_id)
        {
            string query = "SELECT Used "
                + "FROM Uses, Chips "
                + "WHERE ChipID=ID and UserID=' " + user_id + " ' and C_Name= 'Triple Captain';";

            return dbMan.ExecuteReader(query);

        }
        public int InsertChips(int id )
        {
            string query = "INSERT INTO Uses" +
                           " Values ('" + id + "',1,0);";
            int r1=dbMan.ExecuteNonQuery(query);
            string query2 = "INSERT INTO Uses" +
                           " Values ('" + id + "',2,0);";
            int r2 = dbMan.ExecuteNonQuery(query2);
            return r1;
        }

        //query update attribute used for triple player to be = 1 given UserID
        //query that updates the user score by + 3*PlayerScore given 

       
        
        public int UpdateUserScore(int user_id, int total_points)
        {
            string query = "UPDATE Users SET TotalPoints= '" + total_points + "' "
            + "WHERE ID='" + user_id + "';";
            return dbMan.ExecuteNonQuery(query);

        }


        public int UpdateUsedTriplecaptain(int user_id)
        {
            string query = "UPDATE Uses SET Used =1 "
             + "WHERE UserID='" + user_id + "' and ChipID IN( SELECT ID FROM Chips WHERE C_Name='Triple Captain');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateUsedWildcard(int user_id)
        {
            string query = "UPDATE Uses SET Used =1 "
             + "WHERE UserID='" + user_id + "' and ChipID IN( SELECT ID FROM Chips WHERE C_Name='Wild Card');";
            return dbMan.ExecuteNonQuery(query);
        }



        /*
        public DataTable SelectAllUserPickedTeam(int user_id)
        {
            string query = "SELECT * FROM Players"
                + "WHERE ID IN ( SELECT PlayerID FROM Pick_Team WHERE UserID ='" + user_id + "';);";
            return dbMan.ExecuteReader(query);
        }
        */

        //insert new fixtures: Home club score and away club scores are not needed  "NULL-NULL" /////make it 0-0 for the user to understand
        //insert new club: we only check on id, club name.

        //buttons to add to adminc, adminf:
        //1-delete all clubs button///////////////////////////////////done but to be tested
        //2-delete all fixtures button///////////////////////////////////done but to be tested
        //3-Update fixture scores: we may need only to update the score, so we neead a new button "Update fixture score".///////////////////////////////////done but to be tested
        //4-Update club points: we may need only to update the points, so we neead a new button "Update club points".///////////////////////////////////done but to be tested
        //text box to remove: club rank
    }
}
