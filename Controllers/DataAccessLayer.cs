using System;    
using System.Collections.Generic;    
using System.Linq;    
using System.Web;   
using InterviewTasks2023.Models;    
using Microsoft.Data.SqlClient;    
using System.Data;    
using System.Configuration;  
   
    public class DataAccessLayer    
    {    
        public string InsertData(Book objcust)    
        {    
            SqlConnection con = null;    
            string result = "";    
            try    
            {    
                con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["conn"].ToString());    
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Book", con);    
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Code", objcust.Code);         
                cmd.Parameters.AddWithValue("@BookName", objcust.BookName);    
                cmd.Parameters.AddWithValue("@Author", objcust.Author);    
                cmd.Parameters.AddWithValue("@IsAvailable", objcust.IsAvailable);    
                cmd.Parameters.AddWithValue("@Price", objcust.Price);    
                cmd.Parameters.AddWithValue("@ShelfId", objcust.ShelfId);    
                cmd.Parameters.AddWithValue("@Query", 1);    
                con.Open();    
                result = cmd.ExecuteScalar().ToString();    
                return result;    
            }    
            catch    
            {    
                return result = "";    
            }    
            finally    
            {    
                con.Close();    
            }    
        }    
        public string UpdateData(Book objcust)    
        {    
            SqlConnection con = null;    
            string result = "";    
            try    
            {    
                con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mycon"].ToString());    
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Book", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
                cmd.Parameters.AddWithValue("@Code", objcust.Code);         
                cmd.Parameters.AddWithValue("@BookName", objcust.BookName);    
                cmd.Parameters.AddWithValue("@Author", objcust.Author);    
                cmd.Parameters.AddWithValue("@IsAvailable", objcust.IsAvailable);    
                cmd.Parameters.AddWithValue("@Price", objcust.Price);    
                cmd.Parameters.AddWithValue("@ShelfId", objcust.ShelfId);    
                cmd.Parameters.AddWithValue("@Query", 2);    
                con.Open();    
                result = cmd.ExecuteScalar().ToString();    
                return result;    
            }    
            catch    
            {    
                return result = "";    
            }    
            finally    
            {    
                con.Close();    
            }    
        }    
        public int DeleteData(int code)    
        {    
            SqlConnection con = null;    
            int result;    
            try    
            {    
                con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mycon"].ToString());    
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Book", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
                cmd.Parameters.AddWithValue("@Code", code);    
                cmd.Parameters.AddWithValue("@BookName", null);    
                cmd.Parameters.AddWithValue("@Author", null);    
                cmd.Parameters.AddWithValue("@IsAvailable", null);    
                cmd.Parameters.AddWithValue("@Price", null);    
                cmd.Parameters.AddWithValue("@ShelfId", null);    
                cmd.Parameters.AddWithValue("@Query", 3);    
                con.Open();    
                result = cmd.ExecuteNonQuery();    
                return result;    
            }    
            catch    
            {    
                return result = 0;    
            }    
            finally    
            {    
                con.Close();    
            }    
        }    
        public List<Book> Selectalldata()    
        {    
            SqlConnection con = null;    
            DataSet ds = null;    
            List<Book> bookList = null;    
            try    
            {    
                con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mycon"].ToString());    
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Book", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
                cmd.Parameters.AddWithValue("@Code", null);    
                cmd.Parameters.AddWithValue("@BookName", null);    
                cmd.Parameters.AddWithValue("@Author", null);    
                cmd.Parameters.AddWithValue("@IsAvailable", null);    
                cmd.Parameters.AddWithValue("@Price", null);    
                cmd.Parameters.AddWithValue("@ShelfId", null);     
                cmd.Parameters.AddWithValue("@Query", 4);    
                con.Open();    
                SqlDataAdapter da = new SqlDataAdapter();    
                da.SelectCommand = cmd;    
                ds = new DataSet();    
                da.Fill(ds);    
                bookList = new List<Book>();    
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)    
                {    
                    Book cobj = new Book();    
                    cobj.Code = (int)ds.Tables[0].Rows[i]["Code"];    
                    cobj.BookName = ds.Tables[0].Rows[i]["BookName"].ToString();    
                    cobj.Author = ds.Tables[0].Rows[i]["Author"].ToString();    
                    cobj.IsAvailable = (bool)ds.Tables[0].Rows[i]["IsAvailable"];    
                    cobj.Price = (decimal)ds.Tables[0].Rows[i]["Price"];    
                    cobj.ShelfId = (int)ds.Tables[0].Rows[i]["ShelfId"];    
    
                    bookList.Add(cobj);    
                }    
                return bookList;    
            }    
            catch    
            {    
                return bookList;    
            }    
            finally    
            {    
                con.Close();    
            }    
        }    
    
        public Book SelectDatabyID(int code)    
        {    
            SqlConnection con = null;    
            DataSet ds = null;    
            Book cobj = null;    
            try    
            {    
                con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["mycon"].ToString());    
                SqlCommand cmd = new SqlCommand("Usp_InsertUpdateDelete_Book", con);    
                cmd.CommandType = CommandType.StoredProcedure;    
                cmd.Parameters.AddWithValue("@Code", code);    
                cmd.Parameters.AddWithValue("@BookName", null);    
                cmd.Parameters.AddWithValue("@Author", null);    
                cmd.Parameters.AddWithValue("@IsAvailable", null);    
                cmd.Parameters.AddWithValue("@Price", null);    
                cmd.Parameters.AddWithValue("@ShelfId", null);      
                cmd.Parameters.AddWithValue("@Query", 5);    
                SqlDataAdapter da = new SqlDataAdapter();    
                da.SelectCommand = cmd;    
                ds = new DataSet();    
                da.Fill(ds);    
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)    
                {    
                    cobj = new Book();    
                    cobj.Code = (int)ds.Tables[0].Rows[i]["Code"];    
                    cobj.BookName = ds.Tables[0].Rows[i]["BookName"].ToString();    
                    cobj.Author = ds.Tables[0].Rows[i]["Author"].ToString();    
                    cobj.IsAvailable = (bool)ds.Tables[0].Rows[i]["IsAvailable"];    
                    cobj.Price = (decimal)ds.Tables[0].Rows[i]["Price"];    
                    cobj.ShelfId = (int)(ds.Tables[0].Rows[i]["ShelfId"]);    
    
                }    
                return cobj;    
            }    
            catch    
            {    
                return cobj;    
            }    
            finally    
            {    
                con.Close();    
            }    
        }    
    }     