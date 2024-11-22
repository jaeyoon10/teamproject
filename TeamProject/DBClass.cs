﻿using Oracle.DataAccess.Client;
using System.Data;
using System.Windows.Forms;
using System;

public class DBClass
{
    private OracleDataAdapter dBAdapter;
    private DataSet dS;
    private OracleCommandBuilder myCommandBuilder;

    public OracleDataAdapter DBAdapter { get { return dBAdapter; } set { dBAdapter = value; } }
    public DataSet DS { get { return dS; } set { dS = value; } }

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

    // storeowner 테이블에서 로그인 검증
    // storeowner 테이블에서 로그인 검증
    public bool ValidateStoreOwner(string storeOwnerId, string password)
    {
        try
        {
            string query = $"SELECT COUNT(*) FROM storeowner WHERE storeownerid = :storeOwnerId AND password = :password";
            using (OracleConnection connection = new OracleConnection("User Id=teamplay; Password=2163; Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));"))
            {
                connection.Open(); // 연결 열기
                using (OracleCommand cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("storeOwnerId", storeOwnerId));
                    cmd.Parameters.Add(new OracleParameter("password", password));

                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result) > 0; // 로그인 성공 여부 반환
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("로그인 중 오류 발생: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }



    // registration 테이블 데이터 가져오기
    public DataTable GetRegistrationData(string filterQuery = "")
    {
        DataTable registrationTable = new DataTable();
        try
        {
            string query = $@"
        SELECT 
            r.registration_id AS 등록ID,  
            r.registration_price AS 등록가격, 
            r.category AS 카테고리, 
            r.product_name AS 상품명, 
            r.expiration_date AS 유통기한, 
            r.remarks AS 비고, 
            s.name AS 공급업체명 -- 공급업체명을 가져옴
        FROM 
            registration r
        LEFT JOIN 
            supplier s ON r.supplier_id = s.supplier_id
        {filterQuery}";

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
