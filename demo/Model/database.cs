using demo.Areas.Admin.Models;
using demo.Areas.Admin.Models.datatable;
using demo.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using demo.Areas.User.Models;

namespace demo
{
    public class projectConnectionString : DbContext
    {

        public projectConnectionString()
            : base("name=projectConnectionString")
        { }
        public EmployeeModel getUserByID(int fiUserID)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();

            EmployeeModel loUserProfileViewModel = new projectConnectionString().Database.SqlQuery<EmployeeModel>("getuserbyid", loSqlParameters.Cast<object>().ToArray()).FirstOrDefault();

            return loUserProfileViewModel;
        }
        public validateusermodel GetUserByUserName(string fsUserName)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("username", fsUserName.handleDBNull()));
           
            var abc= new projectConnectionString().Database.SqlQuery<validateusermodel>("getuserbyname".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray()).FirstOrDefault();
            return abc;
        }

        public List<CategoryModel> getCategory()
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            return new projectConnectionString().Database.SqlQuery<CategoryModel>("getcategory".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray()).ToList<CategoryModel>();
        }
        public List<subcategoryModel> getsubcategory()
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            return new projectConnectionString().Database.SqlQuery<subcategoryModel>("getsubcategory".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray()).ToList<subcategoryModel>();
        }

        public List<UsersModel> getusersrecored()
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            return new projectConnectionString().Database.SqlQuery<UsersModel>("getusersrecored".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray()).ToList();
        }
        public List<selectuserModel> selectuserbyid()
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            return new projectConnectionString().Database.SqlQuery<selectuserModel>("selectuserbyid".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray()).ToList();
        }
        public List<CategoryModel> getcategorybyid(int CId)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("Categoryid", CId.handleDBNull()));

            return new projectConnectionString().Database.SqlQuery<CategoryModel>("getcategorybyid".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray()).ToList();

        }
        public List<RequestSubCategoryModel> getsubcategoryid(int sId)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("subcategoryid", sId.handleDBNull()));
            

            return new projectConnectionString().Database.SqlQuery<RequestSubCategoryModel>("getsubcategorybyid".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray()).ToList();

        }

        public List<CategoryModel> getcategoryid(int CaId)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("categoryid", CaId.handleDBNull()));

            return new projectConnectionString().Database.SqlQuery<CategoryModel>("getcategoryid".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray()).ToList();

        }
        
        public List<UsercategoryModel> geteditusercategory(int ucid)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("UserCartegoryid", ucid.handleDBNull()));


            return new projectConnectionString().Database.SqlQuery<UsercategoryModel>("geteditusercategory".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray()).ToList();

        }
        public List<CategoryModel> geteditcategoryid(int?caid)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("categoryid", caid.handleDBNull()));


            return new projectConnectionString().Database.SqlQuery<CategoryModel>("geteditcategoryid".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray()).ToList();

        }
      
        public List<UsersModel> getusersid(int?UserId)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("UserId", UserId.handleDBNull()));
            return new projectConnectionString().Database.SqlQuery<UsersModel>("getusersid".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray()).ToList();
        }
        public List<UsercategoryModel> getuserscategoryid(int UserCartegoryid)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("UserCartegoryid", UserCartegoryid.handleDBNull()));
            return new projectConnectionString().Database.SqlQuery<UsercategoryModel>("getuserscategoryid".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray()).ToList<UsercategoryModel>();

        }
        public void updatecategory(CategoryModel loCategoryModel)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("Categoryid", loCategoryModel.Categoryid.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("CategoryName", loCategoryModel.CategoryName.handleDBNull()));
            new projectConnectionString().Database.ExecuteSqlCommand("updatecategory".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray());


        }
        public void updatesubcategory(subcategoryModel losubCategoryModel)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("subcategoryid", losubCategoryModel.SubCategoryid.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("subcategoryname", losubCategoryModel.SubCategoryName.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("categoryid", losubCategoryModel.CategoryName.handleDBNull()));

            new projectConnectionString().Database.ExecuteSqlCommand("updatesubcategory".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray());


        }


        public int updateusers(UsersModel lousermodel)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("Name", lousermodel.Name.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("Phone", lousermodel.Phone.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("Email", lousermodel.Email.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("password", lousermodel.Password.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("userid", SqlDbType.Int) { Direction = ParameterDirection.Output });

            return new projectConnectionString().Database.ExecuteSqlCommand("updateUser".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray());


        }

        public int addcategory(string CategoryName)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("CategoryName", CategoryName.handleDBNull()));
            return new projectConnectionString().Database.ExecuteSqlCommand("AddCategory".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray());
        }

        public int AddSubCategory(string SubCategoryName, int Categoryid)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("SubCategoryName", SubCategoryName.handleDBNull()));

            loSqlParameters.Add(new SqlParameter("Categoryid", Categoryid.handleDBNull()));


            return new projectConnectionString().Database.ExecuteSqlCommand("AddSubCategory".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray());
        }


        public int insertUser(string Name, int? Phone, string Email,string password)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("Name", Name.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("Phone", Phone.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("Email", Email.handleDBNull()));
            loSqlParameters.Add(new SqlParameter("password", password.handleDBNull()));

            loSqlParameters.Add(new SqlParameter("userid", SqlDbType.Int) { Direction = ParameterDirection.Output });


           
            var response =  new projectConnectionString().Database.ExecuteSqlCommand("insertUser".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray());
          


            return (int)loSqlParameters[4].Value;

        }

        public int InsertUserCategory(int categoryids,int returnUserId)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("userid", returnUserId.handleDBNull()));

            loSqlParameters.Add(new SqlParameter("categoryid", categoryids.handleDBNull()));



            return new projectConnectionString().Database.ExecuteSqlCommand("InsertUserCategory".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray());
        }

        
        public int updateusercategorydelete(int duserid)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("userid", duserid.handleDBNull()));
            return new projectConnectionString().Database.ExecuteSqlCommand("updateusercategorydelete".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray());

        }
        public int deletecategory(int CId)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("Categoryid", CId.handleDBNull()));
            return new projectConnectionString().Database.ExecuteSqlCommand("deletecategory".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray());
        }
        public int deletesubcategory(int CId)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("SubCategoryid", CId.handleDBNull()));
            return new projectConnectionString().Database.ExecuteSqlCommand("deletesubcategory".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray());
        }
        public int userdelete(int CId)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("userdelete", CId.handleDBNull()));
            return new projectConnectionString().Database.ExecuteSqlCommand("userdelete".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray());
        }

        public List<listcategory> getlistcategory()
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            return new projectConnectionString().Database.SqlQuery<listcategory>("getlistcategory".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray()).ToList<listcategory>();
        }

        public List<getusersubcategoryModel> getclistbyuid(int uid)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("userid", uid.handleDBNull()));

            return new projectConnectionString().Database.SqlQuery<getusersubcategoryModel>("getclistbyuid".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray()).ToList();
        }


        public List<subcategorylist> getsublistbyuid(int uid)
        {
            List<SqlParameter> loSqlParameters = new List<SqlParameter>();
            loSqlParameters.Add(new SqlParameter("userid", uid.handleDBNull()));

            return new projectConnectionString().Database.SqlQuery<subcategorylist>("getsublistbyuid".getSql(loSqlParameters), loSqlParameters.Cast<object>().ToArray()).ToList();
        }

        public System.Data.Entity.DbSet<demo.Areas.Admin.Models.CategoryModel> categoryModels { get; set; }

        public System.Data.Entity.DbSet<demo.Areas.Admin.Models.datatable.subcategoryModel> subcategoryModels { get; set; }

        public System.Data.Entity.DbSet<demo.Areas.Admin.Models.datatable.UsersModel> UsersModels { get; set; }

    }
}