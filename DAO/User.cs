using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;
using System.Web.SessionState;
using System.Web;

namespace DAO
{   
    
    public class User
    {   

        public System.Web.SessionState.HttpSessionState Session { get; }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Model.User user)
        {
            SqlConnection con = new SqlConnection(SqlCon.constring);
            con.Open();
            
            SqlCommand cmd = new SqlCommand("insert into users values(@id,@name,@username,@password,@email,@gender,@mobile,@date,@dob,@role,@address,@image)", con);
            cmd.Parameters.AddWithValue("@id", user.Uid);
            cmd.Parameters.AddWithValue("@name", user.Uname);
            cmd.Parameters.AddWithValue("@username", user.Uusername);
            cmd.Parameters.AddWithValue("@password", user.Upassword);
            cmd.Parameters.AddWithValue("@email", user.Uemail);
            cmd.Parameters.AddWithValue("@gender", user.Ugender);
            cmd.Parameters.AddWithValue("@mobile", user.Umobile);
            cmd.Parameters.AddWithValue("@date", user.Udate);
            cmd.Parameters.AddWithValue("@dob", user.UDOB);
            cmd.Parameters.AddWithValue("@role",user.Urole);
            cmd.Parameters.AddWithValue("@address", user.Uaddress);
            cmd.Parameters.AddWithValue("@image", user.Uimage);
            int cnt=cmd.ExecuteNonQuery();
            con.Close();
            
        }

        public bool CheckUser(Model.User u)
        {
            SqlConnection con = new SqlConnection(SqlCon.constring);
            con.Open();
            bool status;
            SqlCommand cmd1 = new SqlCommand("select count(*) from users where uusername=@username or uemail=@email", con);
            cmd1.Parameters.AddWithValue("@username", u.Uusername);
            cmd1.Parameters.AddWithValue("@email", u.Uemail);
            int cnt1 = int.Parse(cmd1.ExecuteScalar().ToString());
            con.Close();
            if (cnt1 > 0)
                status = true;
            else
                status = false;
            return status;
        }

        public void Update(Model.User user)
        {
            SqlConnection con = new SqlConnection(SqlCon.constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into users values(@id,@name,@username,@password,@email,@gender,@mobile,@date,@dob,@role,@address,@image)", con);
            cmd.Parameters.AddWithValue("@id", user.Uid);
            cmd.Parameters.AddWithValue("@name", user.Uname);
            cmd.Parameters.AddWithValue("@username", user.Uusername);
            cmd.Parameters.AddWithValue("@password", user.Upassword);
            cmd.Parameters.AddWithValue("@email", user.Uemail);
            cmd.Parameters.AddWithValue("@gender", user.Ugender);
            cmd.Parameters.AddWithValue("@mobile", user.Umobile);
            cmd.Parameters.AddWithValue("@date", user.Udate);
            cmd.Parameters.AddWithValue("@dob", user.UDOB);
            cmd.Parameters.AddWithValue("@role", user.Urole);
            cmd.Parameters.AddWithValue("@address", user.Uaddress);
            cmd.Parameters.AddWithValue("@image", user.Uimage);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public Model.User UserLogin(string username)
        {               
            SqlConnection con = new SqlConnection(SqlCon.constring);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from users where uusername=@p1", con);
            cmd.Parameters.AddWithValue("@p1", username);
            SqlDataReader reader = cmd.ExecuteReader();
            Model.User u = new Model.User();            
            while (reader.Read())
            {               
                u.Upassword = reader.GetString(3);
                u.Uname = reader.GetString(1);
                u.Uid = reader.GetInt32(0);
                u.Uusername = reader.GetString(2);
                u.Urole = reader.GetString(9);                                      
            }
            con.Close();
            return u;           
        }
    }
}
