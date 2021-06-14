using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace Product_Pack_Manager
{
    class Sql
    {
        string connetionString;
        SqlConnection cnn;
        SqlCommand command;
        SqlDataReader dataReader;
        String sql;

        //creation de la connexion sql
        public Sql()
        {
            connetionString = @"Data Source=sql-pp-01.vtx-pp.ch;Initial Catalog=vtxclients; Integrated Security=true";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
        }
        //Sql querry to create node and edge for vis.js
        public List<Elementclass> requestnode(string Packid)
        {
            //Using dapper to avoid SQL injection
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                var param = new DynamicParameters();
                param.Add("@packid", Packid);
                return con.Query<Elementclass>("PackDefinition_Element_GetAll",param: param,commandType: CommandType.StoredProcedure).AsList();
                
            }
        }
        //request edges for vis.js
        public List<Linkclass> requestedge(string Packid)
        {
            //Using dapper to avoid SQL injection
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                var param = new DynamicParameters();
                param.Add("@packid", Packid);
                return con.Query<Linkclass>("PackDefinition_Link_GetAll", param: param, commandType: CommandType.StoredProcedure).AsList();

            }
        }
        //request edge for a dropdown list
        public List<Linkclassdropdown> requestedgedropdown(string Packid)
        {
            //Using dapper to avoid SQL injection
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                var param = new DynamicParameters();
                param.Add("@packid", Packid);
                return con.Query<Linkclassdropdown>("PackDefinition_Link_GetAll", param: param, commandType: CommandType.StoredProcedure).AsList();
            }
        }
        //make a list of all the pack with id for pack dropdown list
        public List<Dropdownpack> Packlistandid()
        {
            sql = "PackDefinition_Get;";
            return cnn.Query<Dropdownpack>(sql).AsList();
        }
        //element from selected pack
        public List<Elementfrompack> selectedelement(string idpack)
        {
            sql = "PackDefinition_Element_GetAll @packid =" + idpack + ";";
            return cnn.Query<Elementfrompack>(sql).AsList();
        }
        public List<Elementparameter> elementdetail(string idpack)
        {
            sql = "PackDefinition_Element_Get @id =" + idpack + ";";
            return cnn.Query<Elementparameter>(sql).AsList();
        }
        //adding an element
        public string addelement(string packid, string SelectionId, string Elementtype, string Elementid, string Min, string Max, bool Useexisting, bool Usechecker, bool Usepriority, string Prioritylevel, bool Ignoreonvoice, bool Displayitemoninvoice, bool Displaypriceoninvoice, bool Defineofficialprice, string Dependon)
        {
            //Using dapper to avoid SQL injection
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                using (SqlCommand cmd = new SqlCommand("PackDefinition_Element_InsertOrUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@packid", packid);
                    cmd.Parameters.AddWithValue("@SectionId", SelectionId);
                    cmd.Parameters.AddWithValue("@ElementType", Elementtype);
                    cmd.Parameters.AddWithValue("@ElementId", Elementid);
                    cmd.Parameters.AddWithValue("@MIN", Min);
                    cmd.Parameters.AddWithValue("@MAX", Max);
                    cmd.Parameters.AddWithValue("@UseExisting", Useexisting);
                    cmd.Parameters.AddWithValue("@UseChecker", Usechecker);
                    cmd.Parameters.AddWithValue("@UsePriority", Usepriority);
                    cmd.Parameters.AddWithValue("@PriorityLevel", Prioritylevel);
                    cmd.Parameters.AddWithValue("@IgnoreOnInvoice", Ignoreonvoice);
                    cmd.Parameters.AddWithValue("@DisplayItemOnInvoice", Displayitemoninvoice);
                    cmd.Parameters.AddWithValue("@DisplayPriceOnInvoice", Displaypriceoninvoice);
                    cmd.Parameters.AddWithValue("@DefineOfficialPrice", Defineofficialprice);
                    cmd.Parameters.AddWithValue("@DependOn", Dependon);
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    return "";
                }
                
            }
        }
        //modify an element
        public string modifyelement(string packid, string SelectionId, string Elementid, string Min, string Max, bool Useexisting, bool Usechecker, bool Usepriority, string Prioritylevel, bool Ignoreonvoice, bool Displayitemoninvoice, bool Displaypriceoninvoice, bool Defineofficialprice, string Dependon)
        {
            List<Elementidandtype> myidandtype = takeidandtype(Elementid);
            string id = myidandtype[0].Id.ToString();
            string type = myidandtype[0].Type.ToString();
            //Using dapper to avoid SQL injection
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                using (SqlCommand cmd = new SqlCommand("PackDefinition_Element_InsertOrUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@packid", packid);
                    cmd.Parameters.AddWithValue("@SectionId", SelectionId);
                    cmd.Parameters.AddWithValue("@ElementType", type);
                    cmd.Parameters.AddWithValue("@ElementId", id);
                    cmd.Parameters.AddWithValue("@MIN", Min);
                    cmd.Parameters.AddWithValue("@MAX", Max);
                    cmd.Parameters.AddWithValue("@UseExisting", Useexisting);
                    cmd.Parameters.AddWithValue("@UseChecker", Usechecker);
                    cmd.Parameters.AddWithValue("@UsePriority", Usepriority);
                    cmd.Parameters.AddWithValue("@PriorityLevel", Prioritylevel);
                    cmd.Parameters.AddWithValue("@IgnoreOnInvoice", Ignoreonvoice);
                    cmd.Parameters.AddWithValue("@DisplayItemOnInvoice", Displayitemoninvoice);
                    cmd.Parameters.AddWithValue("@DisplayPriceOnInvoice", Displaypriceoninvoice);
                    cmd.Parameters.AddWithValue("@DefineOfficialPrice", Defineofficialprice);
                    cmd.Parameters.AddWithValue("@DependOn", Dependon);
                    cmd.Parameters.AddWithValue("@Id", Elementid);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        //display error as an alert
                        return ex.Message;
                    }
                    return "";
                }

            }
        }
        //delete an element
        public string deleteelement(string packid, string id)
        {
            //Using dapper to avoid SQL injection
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                using (SqlCommand cmd = new SqlCommand("PackDefinition_Element_Delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@packid", packid);
                    cmd.Parameters.AddWithValue("@ID", id);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    return "";
                }
            }
        }
        //take the id and the type from an element
        public List<Elementidandtype> takeidandtype(string id)
        {
            sql = "exec PackDefinition_element_get " + id + ";";
            return cnn.Query<Elementidandtype>(sql).AsList();
        }
        public string linkadd(string packid, string from, string to, string condition, string whentrue, string whenfalse)
        {
            if (condition == "")
            {
                whentrue = "";
                whenfalse = "";
            }
            //Using dapper to avoid SQL injection
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                using (SqlCommand cmd = new SqlCommand("PackDefinition_Link_InsertOrUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@packid", packid);
                    cmd.Parameters.AddWithValue("@ElementIdFrom", from);
                    cmd.Parameters.AddWithValue("@ElementIdTo", to);
                    cmd.Parameters.AddWithValue("@Condition", condition);
                    cmd.Parameters.AddWithValue("@ActionWhenTrue", whentrue);
                    cmd.Parameters.AddWithValue("@ActionWhenFalse", whenfalse);
                    cmd.Parameters.AddWithValue("@Id", DBNull.Value);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    return "";
                }
            }
        }
        //modify a link
        public string linkmodify(string id, string packid, string condition, string whentrue, string whenfalse)
        {
            //take the link from and to so the user don't have to reselect it 
            sql = "select IdElementFrom,IdElementTo from Pack_Liaison where id =" + id + ";";
            List<fromtolink> fromandto = cnn.Query<fromtolink>(sql).AsList();
            if (condition == "")
            {
                whentrue = "";
                whenfalse = "";
            }
            //Using dapper to avoid SQL injection
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                using (SqlCommand cmd = new SqlCommand("PackDefinition_Link_InsertOrUpdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PackID", packid);
                    cmd.Parameters.AddWithValue("@ElementIdFrom", fromandto[0].From.ToString());
                    cmd.Parameters.AddWithValue("@ElementIdTo", fromandto[0].To.ToString());
                    cmd.Parameters.AddWithValue("@Condition", condition);
                    cmd.Parameters.AddWithValue("@ActionWhenTrue", whentrue);
                    cmd.Parameters.AddWithValue("@ActionWhenFalse", whenfalse);
                    cmd.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    return "";
                }
            }
        }
        //delete a link
        public string linkdelete(string id, string packid)
        {
            sql = "PackDefinition_Link_Delete @PackID ="+ packid + ",@ID ="+ id + ";";
            command = new SqlCommand(sql, cnn);
            try
            {
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }
        //close connection to the DB
        public void end()
        {
            cnn.Close();
            cnn.Dispose();
        }
    }
}