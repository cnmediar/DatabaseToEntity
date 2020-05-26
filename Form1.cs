using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseToEntity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DataTable dt;
        private SqlConnection con;

        private SqlDataAdapter da;

        private string sqlstr;



        private void BtnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            if (txtnameSpace.Text == "")
                txtnameSpace.Text = cbbDatabase.Text;

            this.listBox1.Items.Clear();

            string slm = this.txtSLM.Text.Trim();
            string user = this.txtName.Text.Trim();
            string pwd = this.txtPwd.Text.Trim();
            string sjk = this.cbbDatabase.Text.Trim();
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = slm;
            sb.InitialCatalog = sjk;
            sb.UserID = user;
            sb.Password = pwd;


            try
            {
                if (!string.IsNullOrEmpty(txtConn.Text))
                {
                    this.con = new SqlConnection(txtConn.Text);
                    this.sqlstr = txtConn.Text;
                }

                else
                {
                    this.con = new SqlConnection(sb.ToString());
                    this.sqlstr = sb.ToString();
                }
                this.con.Open();

                this.dt = this.GetDataTableA("select name from sysobjects where xtype='U' order by name ");
                DataRow[] array = this.dt.Select();
                foreach (DataRow dr in array)
                {
                    this.listBox1.Items.Add(dr[0]);
                }

                var database = this.GetDataTableA("SELECT NAME FROM MASTER.DBO.SYSDATABASES ORDER BY NAME ");

                foreach (var item in database.Select())
                {
                    if (!this.cbbDatabase.Items.Contains(item[0]))


                        this.cbbDatabase.Items.Add(item[0]);

                }
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.Message);
            }
            finally
            {
                this.con.Close();
                this.con.Dispose();
            }
        }

        public DataTable GetDataTableA(string sql)
        {
            using (this.con = new SqlConnection(this.sqlstr))
            {
                this.da = new SqlDataAdapter(sql, this.con);
                this.da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                this.dt = new DataTable();
                this.da.Fill(this.dt);
                return this.dt;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = getClassContext(this.listBox1.Text);

            this.richTextBox1.Text = str;
        }

        private string getClassContext(string tableName)
        {
            StringBuilder str = new StringBuilder();
            //str.Append("using System;" + Environment.NewLine);
            //str.Append("using System.Collections.Generic;" + Environment.NewLine);
            //str.Append("using System.ComponentModel;" + Environment.NewLine);
            //str.Append("using System.Data;" + Environment.NewLine);
            //str.Append("using System.Text;" + Environment.NewLine);



            if (!string.IsNullOrEmpty(txtUsing.Text.Trim()))
                str.Append(txtUsing.Text.Trim() + Environment.NewLine);

            if (!string.IsNullOrEmpty(txtnameSpace.Text.Trim()))
                str.Append("namespace  " + txtnameSpace.Text.Trim() + Environment.NewLine);

            str.Append("{" + Environment.NewLine);


            var className = tableName;
            if (!string.IsNullOrEmpty(txtPre.Text.Trim()))

            {
                var pIndex = className.ToLower().IndexOf(txtPre.Text.ToLower().Trim());
                if (pIndex == 0)
                {
                    className = className.Substring(txtPre.Text.Trim().Length);

                }
            }

            if (!string.IsNullOrEmpty(txtAfter.Text.Trim()))

                className = className + " : " + txtAfter.Text.Trim();


            str.Append("        public class " + className + Environment.NewLine);



            str.Append("        {" + Environment.NewLine);
            this.dt = this.GetDataTableA("select * from " + tableName + " where 1=2 ");
            foreach (DataColumn column in this.dt.Columns)
            {
                DataTable dtDescript = this.GetDataTableA("SELECT\r\n                                                t.[name] AS 表名,\r\n                                                c.[name] AS 字段名,\r\n                                                cast(ep.[value] as nvarchar(200)) AS [字段说明]  \r\n                                                FROM sys.tables AS t  \r\n                                                INNER JOIN sys.columns   \r\n                                                AS c ON t.object_id = c.object_id  \r\n                                                 LEFT JOIN sys.extended_properties AS ep   \r\n                                                ON ep.major_id = c.object_id AND ep.minor_id = c.column_id WHERE ep.class =1   \r\n                                                AND t.name='" + this.listBox1.Text + "' and c.name='" + column.ColumnName + "'");
                if (dtDescript.Rows.Count > 0)
                {
                    str.Append("          /// <summary>" + Environment.NewLine);
                    str.Append("          /// " + dtDescript.Rows[0]["字段说明"].ToString() + Environment.NewLine);
                    str.Append("          /// <summary>" + Environment.NewLine);
                }
                string type = (column.DataType.ToString().Replace("System.", "") == "String") ? "string" : column.DataType.ToString().Replace("System.", "");
                if (column.AllowDBNull && type != "string")
                {
                    str.Append("          public " + type + "? " + column.ColumnName + " { get; set; }" + Environment.NewLine);
                }
                else
                {
                    str.Append("          public " + type + " " + column.ColumnName + " { get; set; }" + Environment.NewLine);
                }
            }
            str.Append("      }" + Environment.NewLine);
            str.Append("}" + Environment.NewLine);
            return str.ToString();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            base.Width = this.groupBox1.Width + this.groupBox2.Width + 30;
            base.Height = this.groupBox1.Height + 50;
            ConnectionStringSettingsCollection conlist = ConfigurationManager.ConnectionStrings;
            foreach (object item in conlist)
            {
                this.cbbDatabase.Items.Add(item.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {



            login();
            return;



            this.listBox1.Items.Clear();
            this.con = new SqlConnection(this.cbbDatabase.Text);
            try
            {
                this.con.Open();
                this.sqlstr = this.cbbDatabase.Text;
                this.dt = this.GetDataTableA("select name from sysobjects where xtype='U' order by name ");
                DataRow[] array = this.dt.Select();
                foreach (DataRow dr in array)
                {
                    this.listBox1.Items.Add(dr[0]);
                }
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.Message);
            }
            finally
            {
                this.con.Close();
                this.con.Dispose();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnFolderChoose_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        /// <summary>
        /// 保存数据data到文件的处理过程；
        /// </summary>
        /// <param name="data"></param>
        public String SavaProcess(string tb)
        {
            string data = getClassContext(tb);



            if (string.IsNullOrEmpty(txtPath.Text))
                txtPath.Text = System.AppDomain.CurrentDomain.BaseDirectory;

            string CurDir = txtPath.Text;

            //判断路径是否存在
            if (!System.IO.Directory.Exists(CurDir))
            {
                System.IO.Directory.CreateDirectory(CurDir);
            }
            //不存在就创建
            String FilePath = Path.Combine(CurDir, tb + ".cs");
            //文件覆盖方式添加内容

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(FilePath, false))
            //保存数据到文件
            {
                file.Write(data);
                file.Close();
                //释放对象
                file.Dispose();
            }
            //关闭文件
            toolStripStatusLabel1.Text = "保存文件：" + FilePath + "\t" + DateTime.Now;

            return FilePath;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {


            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {

                string tb = listBox1.SelectedItems[i].ToString();


                SavaProcess(tb);



            }

        }
    }
}
