using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CodeMaker
{
	public class frmMain : Form
	{
		private IContainer components = null;

		private GroupBox groupBox1;

		private ListBox listBox1;

		private Button BtnLogin;

		private Label label4;

		private TextBox txtPwd;

		private Label label3;

		private TextBox txtName;

		private Label label2;

		private Label label1;

		private TextBox txtSLM;

		private GroupBox groupBox2;

		private RichTextBox richTextBox1;

		private ComboBox cbbDatabase;

		private SqlConnection con;

		private SqlDataAdapter da;

		private DataTable dt;
        private TextBox txtPre;
        private Label label5;
        private Label label6;
        private TextBox txtAfter;
        private TextBox txtUsing;
        private Label label7;
        private Label label9;
        private TextBox txtConn;
        private Label label8;
        private TextBox txtnameSpace;
        private Label label10;
        private TextBox txtPath;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button btnFolderChoose;
        private Button btnSave;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private string sqlstr;

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtConn = new System.Windows.Forms.TextBox();
            this.cbbDatabase = new System.Windows.Forms.ComboBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSLM = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtPre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAfter = new System.Windows.Forms.TextBox();
            this.txtUsing = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtnameSpace = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFolderChoose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtConn);
            this.groupBox1.Controls.Add(this.cbbDatabase);
            this.groupBox1.Controls.Add(this.BtnLogin);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPwd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSLM);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(531, 125);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 32;
            this.label9.Text = "链接字符串";
            // 
            // txtConn
            // 
            this.txtConn.Location = new System.Drawing.Point(71, 25);
            this.txtConn.Multiline = true;
            this.txtConn.Name = "txtConn";
            this.txtConn.Size = new System.Drawing.Size(452, 21);
            this.txtConn.TabIndex = 31;
            // 
            // cbbDatabase
            // 
            this.cbbDatabase.FormattingEnabled = true;
            this.cbbDatabase.Location = new System.Drawing.Point(66, 87);
            this.cbbDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.cbbDatabase.Name = "cbbDatabase";
            this.cbbDatabase.Size = new System.Drawing.Size(159, 20);
            this.cbbDatabase.TabIndex = 24;
            this.cbbDatabase.Text = "BookStore";
            this.cbbDatabase.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(267, 86);
            this.BtnLogin.Margin = new System.Windows.Forms.Padding(2);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(114, 23);
            this.BtnLogin.TabIndex = 23;
            this.BtnLogin.Text = "连接";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "密码:";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(406, 54);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(2);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(116, 21);
            this.txtPwd.TabIndex = 21;
            this.txtPwd.Text = "mmmm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "用户名:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(266, 54);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(91, 21);
            this.txtName.TabIndex = 19;
            this.txtName.Text = "sa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "数据库:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "服务器";
            // 
            // txtSLM
            // 
            this.txtSLM.Location = new System.Drawing.Point(74, 54);
            this.txtSLM.Margin = new System.Windows.Forms.Padding(2);
            this.txtSLM.Name = "txtSLM";
            this.txtSLM.Size = new System.Drawing.Size(135, 21);
            this.txtSLM.TabIndex = 15;
            this.txtSLM.Text = "localhost";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(14, 202);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(224, 448);
            this.listBox1.TabIndex = 24;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Location = new System.Drawing.Point(251, 186);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(796, 468);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "代码";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(4, 18);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(770, 446);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // txtPre
            // 
            this.txtPre.Location = new System.Drawing.Point(603, 32);
            this.txtPre.Multiline = true;
            this.txtPre.Name = "txtPre";
            this.txtPre.Size = new System.Drawing.Size(134, 21);
            this.txtPre.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(561, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "表前缀";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(573, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 28;
            this.label6.Text = "继承";
            // 
            // txtAfter
            // 
            this.txtAfter.Location = new System.Drawing.Point(603, 100);
            this.txtAfter.Multiline = true;
            this.txtAfter.Name = "txtAfter";
            this.txtAfter.Size = new System.Drawing.Size(134, 21);
            this.txtAfter.TabIndex = 27;
            // 
            // txtUsing
            // 
            this.txtUsing.Location = new System.Drawing.Point(744, 32);
            this.txtUsing.Multiline = true;
            this.txtUsing.Name = "txtUsing";
            this.txtUsing.Size = new System.Drawing.Size(300, 131);
            this.txtUsing.TabIndex = 25;
            this.txtUsing.Text = "using System;";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(742, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "Using";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(549, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "命名空间";
            // 
            // txtnameSpace
            // 
            this.txtnameSpace.Location = new System.Drawing.Point(603, 66);
            this.txtnameSpace.Multiline = true;
            this.txtnameSpace.Name = "txtnameSpace";
            this.txtnameSpace.Size = new System.Drawing.Size(134, 21);
            this.txtnameSpace.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 32;
            this.label10.Text = "路径：";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(63, 148);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(474, 21);
            this.txtPath.TabIndex = 31;
            // 
            // btnFolderChoose
            // 
            this.btnFolderChoose.Location = new System.Drawing.Point(544, 146);
            this.btnFolderChoose.Name = "btnFolderChoose";
            this.btnFolderChoose.Size = new System.Drawing.Size(27, 23);
            this.btnFolderChoose.TabIndex = 33;
            this.btnFolderChoose.Text = "...";
            this.btnFolderChoose.UseVisualStyleBackColor = true;
            this.btnFolderChoose.Click += new System.EventHandler(this.btnFolderChoose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(577, 146);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 23);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 642);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1056, 22);
            this.statusStrip1.TabIndex = 35;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 664);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFolderChoose);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtnameSpace);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAfter);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUsing);
            this.Controls.Add(this.txtPre);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "数据库生成实体工具";
            this.Load += new System.EventHandler(this.frmMain_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		public frmMain()
		{
			this.InitializeComponent();
		}

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
                { this.con = new SqlConnection(txtConn.Text);
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
                   if(! this.cbbDatabase.Items.Contains(item[0]))


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
        public  String SavaProcess(string tb)
        {
            string data = getClassContext(tb);
                      
       

            if (string.IsNullOrEmpty(txtPath.Text))
                txtPath.Text = System.AppDomain.CurrentDomain.BaseDirectory;

            string CurDir =  txtPath.Text;

            //判断路径是否存在
            if (!System.IO.Directory.Exists(CurDir))
            {
                System.IO.Directory.CreateDirectory(CurDir);
            }
            //不存在就创建
            String FilePath =Path.Combine( CurDir, tb+".cs");
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
              toolStripStatusLabel1.Text = "保存文件："+ FilePath+"\t"+DateTime.Now;

            return FilePath;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           

            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
             
                string tb=listBox1.SelectedItems[i].ToString();
              

                SavaProcess(tb);

        

            }

        }

        private void frmMain_Load_1(object sender, EventArgs e)
        {

        }
    }
}

