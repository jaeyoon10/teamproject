    using System;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    public class DBClass
    {
        private OracleDataAdapter dBAdapter;
        private DataSet dS;
        private OracleCommandBuilder myCommandBuilder;
        private DataTable storeOwnerTable;

        public OracleDataAdapter DBAdapter { get { return dBAdapter; } set { dBAdapter = value; } }
        public DataSet DS { get { return dS; } set { dS = value; } }
        public OracleCommandBuilder MyCommandBuilder { get { return myCommandBuilder; } set { myCommandBuilder = value; } }
        public DataTable StoreOwnerTable { get { return storeOwnerTable; } set { storeOwnerTable = value; } }

        public void DB_Open()
        {
            try
            {
                string connectionString = "User Id=rjsgml350; Password=qhdud350; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                string commandString = "select * from storeowner";

                DBAdapter = new OracleDataAdapter(commandString, connectionString);
                MyCommandBuilder = new OracleCommandBuilder(DBAdapter);
                DS = new DataSet();
                DBAdapter.Fill(DS, "StoreOwner");

                StoreOwnerTable = DS.Tables["StoreOwner"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidateStoreOwner(string storeOwnerId, string password)
        {
            DataRow[] foundRows = StoreOwnerTable.Select($"storeownerid = '{storeOwnerId}' AND password = '{password}'");
            return foundRows.Length > 0;
        }

        public void DB_ObjCreate()
        {
            StoreOwnerTable = new DataTable();
        }
        public DataTable GetProductData()
        {
            DataTable productTable = new DataTable();
            try
            {
                string query = @"
            SELECT 
                p.product_id, 
                p.expiration_date, 
                p.product_name, 
                r.registration_id,
                r.registration_date, 
                r.registration_price, 
                r.category, 
                r.remarks
            FROM 
                product p
            JOIN 
                registration r ON p.registration_id = r.registration_id";

                OracleDataAdapter adapter = new OracleDataAdapter(query, dBAdapter.SelectCommand.Connection);
                adapter.Fill(productTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve product data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return productTable;
        }
        // GetReportData 메서드 추가
        public DataTable GetReportData()
        {
            DataTable reportTable = new DataTable();
            try
            {
                string query = @"
            SELECT 
                r.report_id, 
                r.output_content, 
                r.search_content, 
                s.product_name AS stock_name, 
                sh.sales_amount
            FROM 
                report r
            JOIN 
                stock s ON r.stock_id = s.stock_id
            JOIN 
                sales_history sh ON r.sales_id = sh.sales_id";

                OracleDataAdapter adapter = new OracleDataAdapter(query, dBAdapter.SelectCommand.Connection);
                adapter.Fill(reportTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve report data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return reportTable;
        }
        public DataTable GetStockData(string filterQuery = "")
        {
            DataTable stockTable = new DataTable();
            try
            {
                string query = $@"
        SELECT 
            s.stock_id, 
            s.stock_quantity, 
            s.min_stock_quantity, 
            s.expiration_date, 
            r.product_name, 
            r.category, 
            r.registration_date 
        FROM 
            stock s
        JOIN 
            registration r ON s.registration_id = r.registration_id
        {filterQuery}"; // 필터 조건 추가

                OracleDataAdapter adapter = new OracleDataAdapter(query, dBAdapter.SelectCommand.Connection);
                adapter.Fill(stockTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve stock data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return stockTable;
        }

    }
}
 
