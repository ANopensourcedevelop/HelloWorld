using System;
using System.Collections.Generic;
using System.Data.SqlClient;

//This app is vulnerable to injection attacks, written purely for educational purposes
//This app is vulnerable to injection attacks, written purely for educational purposes
//This app is vulnerable to injection attacks, written purely for educational purposes
//This app is vulnerable to injection attacks, written purely for educational purposes
//This app can be hacked in a simple way, I'm aware of that
//This app can be hacked in a simple way, I'm aware of that
//This app can be hacked in a simple way, I'm aware of that
//This app can be hacked in a simple way, I'm aware of that


namespace HelloWorld
{
    public partial class _default : System.Web.UI.Page
    {
		string connetionString;
		SqlConnection cnn;
		private String sql;

		protected void Page_Load(object sender, EventArgs e)
        {
			
			connetionString = @"Data Source=DESKTOP-6GVGFKD\SQLEXPRESS;Initial Catalog=Todo ;User ID=sa;Password=123456";

			cnn = new SqlConnection(connetionString);

		}

		//-----------------------------------------------------------------------------------------------------------------

		//Set data to db
		protected void set_data(String name, String password) {
			cnn.Open();
			SqlCommand commandForWrite;
			SqlDataAdapter adapter = new SqlDataAdapter();
			String sqlForWrite = "";

			sql = $"Insert into UserTable(Name,Password) values('{name.ToLower()}'," + $"'{password}')";


			commandForWrite = new SqlCommand(sqlForWrite, cnn);
			adapter.InsertCommand = new SqlCommand(sql, cnn);
			adapter.InsertCommand.ExecuteNonQuery();

			commandForWrite.Dispose();

			cnn.Close();
		}

		//------------------------------------------------------------------------------------------------------------------

		//---------------------------------------------------------------------------------------------------------------

		//Get name from db
		protected String get_name(String name) {
			cnn.Open();
			SqlCommand command;
			SqlDataReader dataReader;
			String output = "";

			sql = $"SELECT * FROM UserTable WHERE Name = '{name.ToLower()}'";

			command = new SqlCommand(sql, cnn);

			dataReader = command.ExecuteReader();

			while (dataReader.Read())
			{
				output = dataReader.GetValue(1).ToString();
			}

			dataReader.Close();
			command.Dispose();
			cnn.Close();

            return output;
		}

		//----------------------------------------------------------------------------------------------------------------

		//Get password from db
		protected String get_password(String password) {
			cnn.Open();
			SqlCommand command;
			SqlDataReader dataReader;
			String output = "";

			sql = $"SELECT * FROM UserTable WHERE Name = '{password}'";

			command = new SqlCommand(sql, cnn);

			dataReader = command.ExecuteReader();

			while (dataReader.Read())
			{
				output = dataReader.GetValue(2).ToString();
			}

			dataReader.Close();
			command.Dispose();
			cnn.Close();

			return output;
		}

		//---------------------------------------------------------------------------------------------------------------

		//Control for- Is there such an account?
		protected String account_control(String name, String password)
		{
			cnn.Open();
			SqlCommand command;
			SqlDataReader dataReader;
			String output = "";

			sql = $"SELECT * FROM UserTable WHERE Name = '{name}' AND CONVERT(VARCHAR,Password) = '{password}'";

			command = new SqlCommand(sql, cnn);

			dataReader = command.ExecuteReader();

			while (dataReader.Read())
			{
				output = dataReader.GetValue(1).ToString();
			}

			dataReader.Close();
			command.Dispose();
			cnn.Close();

			return output;
		}

		//---------------------------------------------------------------------------------------------------------------

		protected void Button1_Click(object sender, EventArgs e)
		{
			String name = TextBox1.Text.Trim().ToLower();
			String password = TextBox2.Text.Trim();

			if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(password))
			{
				Label3.Text = "Please enter name and password!";
			}
			//Login
			else if (!String.IsNullOrEmpty(account_control(name, password))) {
				Label3.Text = "Login";
				Response.Redirect($"account.aspx/{name}?Name={name}");
			}
			//Wrong password
			else if (!String.IsNullOrEmpty(get_name(name)) & String.IsNullOrEmpty(account_control(name, password))) {
				Label3.Text = "Such account already exists, wrong password";
			}
			//Register
			else {
				set_data(name, password);
				Label3.Text = "OK";
				Response.Redirect($"account.aspx/{name}?Name={name}");
			}
		}
	}
}