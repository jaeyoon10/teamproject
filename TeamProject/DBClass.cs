﻿using System;
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
                string connectionString = "User Id=team; Password=1234; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
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
