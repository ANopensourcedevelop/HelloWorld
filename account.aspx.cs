using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
	public partial class account : System.Web.UI.Page
    {
		string connetionString;
		SqlConnection cnn;
		private String sql;
		private String Name;
		private List<string> questions = new List<string>();
		private List<string> answersR = new List<string>();
		private List<string> answersW = new List<string>();


		protected void Page_Load(object sender, EventArgs e)
        {
			
			connetionString = @"Data Source=DESKTOP-6GVGFKD\SQLEXPRESS;Initial Catalog=Todo ;User ID=sa;Password=123456";
            cnn = new SqlConnection(connetionString);
			
			Name = Request.QueryString["Name"];
			Label1.Text = $"Hello - {Name}";

			//Add questions
			questions.AddRange(new List<string>() {
				"Who invented the internet?", //Bob Kahn, Vinton Cerf
				"Who invented the first computer?", //Charles Babbage
				"What was the first programming language?", //Fortran
			});

			//Add right answers
			answersR.AddRange(new List<string>() {
				"Bob Kahn, Vinton Cerf", //Internet
				"Charles Babbage", //Computer
				"Fortran" //LAnguage
			});

			//Add wrong answers
			answersW.AddRange(new List<string>() {
				"Antonio meucci, John Peirce", //Phone
				"Carl Benz", //Car
				"Algol"
			});

			//Set index to 0 when page is newly loaded
			if (ViewState["index"] == null)
			{
				//first question
				ViewState["index"] = 0;
				Label2.Text = questions[0];
				RadioButton1.Text = answersR[0];
				RadioButton2.Text = answersW[0];
			}



			//Retrieve data from database and display it to user
			get_all_data();


		}

		//Get all data from db
		protected void get_all_data()
		{
			cnn.Open();
			SqlCommand command;
			SqlDataReader dataReader;

			sql = "Select Name,RightA,WrongA from UserTable";

			command = new SqlCommand(sql, cnn);
			dataReader = command.ExecuteReader();

			ornRepeater.DataSource = dataReader;
			ornRepeater.DataBind();

			dataReader.Close();
			command.Dispose();

			cnn.Close();
		}

		protected String get_Anumber(int index)
		{
			cnn.Open();
			SqlCommand command;
			SqlDataReader dataReader;
			String output = "";

			sql = $"SELECT * FROM UserTable WHERE Name = '{Name}'";

			command = new SqlCommand(sql, cnn);

			dataReader = command.ExecuteReader();

			while (dataReader.Read())
			{
				output = dataReader.GetValue(index).ToString();
			}

			dataReader.Close();
			command.Dispose();
			cnn.Close();

			return output;
		}

		//Update data from db
		protected void update_data(String name) {
			SqlCommand command;
			SqlDataAdapter adapter = new SqlDataAdapter();
			cnn.Open();



			sql = $"UPDATE UserTable SET {name}={name}+1 WHERE Name='{Name}'";


			command = new SqlCommand(sql, cnn);

			adapter.InsertCommand = new SqlCommand(sql, cnn);
			adapter.InsertCommand.ExecuteNonQuery();

			command.Dispose();
			cnn.Close();
		}


		//Next button

        protected void Button1_Click(object sender, EventArgs e)
        {
			//Change the question when the button is clicked
			change_question();

			//Change the answers when the button is clicked
			change_answers();

			//If the first answer is selected
			if (RadioButton1.Checked)
			{
				String text = RadioButton1.Text;
				//If the chosen answer is correct
				if (answersR.Contains(text))
				{
					Label4.Text = "Right";
					update_data("RightA");
				}
				//If the chosen answer is not correct
				else
				{
					Label4.Text = "Wrong";
					update_data("WrongA");
				}
			}

			//If the second answer is selected
			else if (RadioButton2.Checked)
			{
				String text = RadioButton2.Text;
				//If the chosen answer is correct
				if (answersR.Contains(text))
				{
					Label4.Text = "Right";
					update_data("RightA");
				}
				//If the chosen answer is not correct
				else
				{
					Label4.Text = "Wrong";
					update_data("WrongA");
				}
			}

			RadioButton1.Enabled = true;
			RadioButton2.Enabled = true;

			RadioButton1.Checked = false;
			RadioButton2.Checked = false;

		}

		protected void change_question() {
			//Eger cavab secilmedise
			if (!RadioButton1.Checked & !RadioButton2.Checked)
			{
				Label4.Text = "Test reset, please choose an answer!";
				ViewState["index"] = 0;
				Label2.Text = questions[0];
			}
			//Cavab secildise
			else
			{

				if ((int)ViewState["index"] < questions.Count - 1)
				{
					int index = (int)ViewState["index"] + 1;
					ViewState["index"] = index;
					Label2.Text = questions[index];
				}

				//Eger suallar bitdise basa al
				else
				{
					ViewState["index"] = 0;
					Label2.Text = questions[0];
					RadioButton1.Text = answersR[0];
					RadioButton2.Text = answersW[0];
				}

			}
		}

		protected void change_answers() {
			int index = (int)ViewState["index"];
			RadioButton1.Text = answersR[index];
			RadioButton2.Text = answersW[index];
		}
    }
}