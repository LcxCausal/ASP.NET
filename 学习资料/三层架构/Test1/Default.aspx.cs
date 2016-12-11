using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

using Test1.SystemConfig;

namespace Test1
{
    public partial class _Default : System.Web.UI.Page
    {
        /// <summary>
        /// 定义私有变量
        /// </summary>
        private string strConn = "SERVER=202.115.195.252;DATABASE=crsTest;PWD=Win2008;UID=crstest;"; //SQL Server链接字符串

        private SqlConnection _connSql = new SqlConnection(); //Sql链接类的实例化
        private string strSql = string.Empty;
        private DataSet dstTemptable = new DataSet();

        /// <summary>
        /// 定义公有变量
        /// </summary>
        //public ... 

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)//页面启动时只执行一次
            {
                BindGridView("tbStuinfo");
            }
        }

        /// <summary>
        /// 绑定GridView
        /// 初学的方法
        /// </summary>
        /// <param name="strTableName"></param>
        private void BindGridView(string strTableName)
        {
            try
            {
                string strT = (strTableName.Trim().Length == 0) ? "tbStuinfo" : strTableName;

                //数据库连接
                _connSql = new SqlConnection(strConn);

                //打开数据库
                _connSql.Open();

                //要执行的SQL语句
                string strSQL = "SELECT * FROM " + strT;

                //创建DataAdapter数据适配器实例
                SqlDataAdapter da = new SqlDataAdapter(strSQL, _connSql);

                //创建DataSet实例
                DataSet ds = new DataSet();

                //使用DataAdapter的Fill方法(填充)，调用SELECT命令
                da.Fill(ds, "t1");

                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception err)
            {
                Response.Write(err.Message);
            }
            finally
            {
                //关闭数据库
                _connSql.Close();
            }
        }

        protected string Showsex(object obj)
        {
            try
            {
                return bool.Parse(obj.ToString()) ? "男" : "女";
            }
            catch
            {
                return "null";
            }
        }

        /// <summary>
        /// 根据输入查询表的数据并显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnShowTableData_Click(object sender, EventArgs e)
        {
            if (txtTableName.Text.Trim().Length == 0)
            {
                Response.Write("<script language=javascript>alert('请输入表名')</script>");
                return;
            }

            BindData();
        }

        protected void gvwTableData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwTableData.PageIndex = e.NewPageIndex;
            BindData(); //重新绑定GridView数据的函数
        }
        
        /// <summary>
        /// 绑定并显示数据到gridview中
        /// 两层架构中流行的方法：用类封装数据库的操作
        /// </summary>
        protected void BindData()
        {
            try
            {
                strSql = "SELECT * FROM " + txtTableName.Text;

                //SqlHelper是在网上下载的封装好的操作数据库的类
                //里面有各种操作数据库的方法
                dstTemptable = SqlHelper.ExecuteDataset(SysConfig.GetSqlConnection(), CommandType.Text, strSql);

                if (dstTemptable.Tables.Count > 0)
                {
                    gvwTableData.DataSource = dstTemptable.Tables[0];
                    gvwTableData.DataBind();

                    Response.Write("数据量：" + dstTemptable.Tables[0].Rows.Count.ToString());
                }
            }
            catch (Exception err)
            {
                gvwTableData.DataSource = null;
                gvwTableData.DataBind();

                Response.Write("<script language=javascript>alert('表不存在!!')</script>");
            }
        }
    }
}