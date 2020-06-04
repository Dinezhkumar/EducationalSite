using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static UnivSite.Models.StudentDetails;

namespace EduSite.SqlDal
{
    public class StudentDetailsDal
    {
        #region AcademicDetails
        public string AddAcademicDetails(AcademicDetails academicDetails)
        {
            string AcademicDetailsId = new Guid().ToString();
            string connectionString = System.Configuration.ConfigurationManager.
             ConnectionStrings["connectionStringName"].ConnectionString;
            string query = "INSERT INTO AcademeicDetails VALUES(@AcademicDetailsId, @Course, @Semester, @Year, @CollegeName, @MarksScored, @MaxMark)";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@AcademicDetailsId", AcademicDetailsId);
                    cmd.Parameters.AddWithValue("@Course", academicDetails.Course);
                    cmd.Parameters.AddWithValue("@Semester", academicDetails.Semester);
                    cmd.Parameters.AddWithValue("@Year", academicDetails.Year);
                    cmd.Parameters.AddWithValue("@CollegeName", academicDetails.CollegeName);
                    cmd.Parameters.AddWithValue("@MarksScored", academicDetails.MarksScored);
                    cmd.Parameters.AddWithValue("@MaxMark", academicDetails.MaxMark);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return AcademicDetailsId;

        }

        public void UpdateAcademicDetails(AcademicDetails academicDetails)
        {
            string connectionString = System.Configuration.ConfigurationManager.
             ConnectionStrings["connectionStringName"].ConnectionString;
            string query = "UPDATE AcademeicDetails SET Course=@Course, Semester=@Semester, Year=@Year, CollegeName=@CollegeName, MarksScored=@MarksScored, MaxMark=@MaxMark WHERE AcademicDetailsId=@AcademicDetailsId";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@AcademicDetailsId", academicDetails.AcademicDetailsId);
                    cmd.Parameters.AddWithValue("@Course", academicDetails.Course);
                    cmd.Parameters.AddWithValue("@Semester", academicDetails.Semester);
                    cmd.Parameters.AddWithValue("@Year", academicDetails.Year);
                    cmd.Parameters.AddWithValue("@CollegeName", academicDetails.CollegeName);
                    cmd.Parameters.AddWithValue("@MarksScored", academicDetails.MarksScored);
                    cmd.Parameters.AddWithValue("@MaxMark", academicDetails.MaxMark);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public void DeleteAcademicDetails(string AcademicDetailsId)
        {
            string connectionString = System.Configuration.ConfigurationManager.
             ConnectionStrings["connectionStringName"].ConnectionString;
            string query = "DELETE FROM AcademeicDetails WHERE AcademicDetailsId=@AcademicDetailsId";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@AcademicDetailsId", AcademicDetailsId);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public List<AcademicDetails> GetAcademicDetails(string studentId)
        {
            List<AcademicDetails> academicDetailsLst = new List<AcademicDetails>();
            string connectionString = System.Configuration.ConfigurationManager.
             ConnectionStrings["connectionStringName"].ConnectionString;
            string query = "select * FROM AcademeicDetails WHERE studentId=@studentId";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Connection = con;
                    con.Open();
                    DbDataReader dbDataReader = cmd.ExecuteReader();
                    while (dbDataReader.Read())
                    {
                        AcademicDetails academicDetails = new AcademicDetails();
                        if (dbDataReader["AcademicDetailsId"] != null && !string.IsNullOrEmpty(dbDataReader["AcademicDetailsId"].ToString()))
                            academicDetails.AcademicDetailsId = dbDataReader["AcademicDetailsId"].ToString();
                        if (dbDataReader["Course"] != null && !string.IsNullOrEmpty(dbDataReader["Course"].ToString()))
                            academicDetails.Course = dbDataReader["Course"].ToString();
                        if (dbDataReader["Semester"] != null && !string.IsNullOrEmpty(dbDataReader["Semester"].ToString()))
                            academicDetails.Semester = dbDataReader["Semester"].ToString();
                        if (dbDataReader["Year"] != null && !string.IsNullOrEmpty(dbDataReader["Year"].ToString()))
                            academicDetails.Year = dbDataReader["Year"].ToString();
                        if (dbDataReader["CollegeName"] != null && !string.IsNullOrEmpty(dbDataReader["CollegeName"].ToString()))
                            academicDetails.CollegeName = dbDataReader["CollegeName"].ToString();
                        if (dbDataReader["MarksScored"] != null && !string.IsNullOrEmpty(dbDataReader["MarksScored"].ToString()))
                            academicDetails.MarksScored = Convert.ToDecimal(dbDataReader["MarksScored"].ToString());
                        if (dbDataReader["MaxMark"] != null && !string.IsNullOrEmpty(dbDataReader["MaxMark"].ToString()))
                            academicDetails.MaxMark = Convert.ToDecimal(dbDataReader["MaxMark"].ToString());
                        academicDetailsLst.Add(academicDetails);
                    }
                    con.Close();
                }
                return academicDetailsLst;
            }

        }

        #endregion

        public string AddPersonalDetails(PersonalDetails personalDetails)
        {
            string StudentId = new Guid().ToString();
            string connectionString = System.Configuration.ConfigurationManager.
             ConnectionStrings["connectionStringName"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "insert into PersonalDetails(StudentId,ApplicantName,FatherName,MotherName,RegistrationNo,NatureOfDocument,ReasonOfApplying,status)values(@StudentId,@ApplicantName,@FatherName,@MotherName,@RegistrationNo,@NatureOfDocument,@ReasonOfApplying,@status)";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.Add("@StudentId", System.Data.SqlDbType.NVarChar).Value = StudentId;
                sqlCommand.Parameters.Add("@ApplicantName", System.Data.SqlDbType.NVarChar).Value = personalDetails.ApplicantName;
                sqlCommand.Parameters.Add("@FatherName", System.Data.SqlDbType.NVarChar).Value = personalDetails.FatherName;
                sqlCommand.Parameters.Add("@MotherName", System.Data.SqlDbType.NVarChar).Value = personalDetails.MotherName;
                sqlCommand.Parameters.Add("@RegistrationNo", System.Data.SqlDbType.NVarChar).Value = personalDetails.RegistrationNo;
                sqlCommand.Parameters.Add("@NatureOfDocument", System.Data.SqlDbType.NVarChar).Value = personalDetails.NatureOfDocument;
                sqlCommand.Parameters.Add("@ReasonOfApplying", System.Data.SqlDbType.NVarChar).Value = personalDetails.ReasonOfApplying;
                sqlCommand.Parameters.Add("@status", System.Data.SqlDbType.NVarChar).Value = true;
                connection.Open();
                sqlCommand.ExecuteNonQuery();

            }

            return StudentId;


        }
        public string AddFeeDetails(FeeDetails feeDetails)
        {
            string FeeDetailsId = new Guid().ToString();
            string connectionString = System.Configuration.ConfigurationManager.
             ConnectionStrings["connectionStringName"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "insert into FeeDetails(FeeDetailsId,StudentId,TransactionId,Date,PayeeName,FathersName,DOB,PhoneNumberOffice,FeeDescription,status)values(@FeeDetailsId,@StudentId,@TransactionId,@Date,@PayeeName,@FathersName,@DOB,@PhoneNumberOffice,@FeeDescription,@status)";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.Add("@FeeDetailsId", System.Data.SqlDbType.VarChar).Value = FeeDetailsId;
                sqlCommand.Parameters.Add("@TransactionId", System.Data.SqlDbType.VarChar).Value = feeDetails.TransactionId;
                sqlCommand.Parameters.Add("@Date", System.Data.SqlDbType.VarChar).Value = feeDetails.Date;
                sqlCommand.Parameters.Add("@PayeeName", System.Data.SqlDbType.DateTime).Value = feeDetails.PayeeName;
                sqlCommand.Parameters.Add("@FathersName", System.Data.SqlDbType.VarChar).Value = feeDetails.FathersName;
                sqlCommand.Parameters.Add("@DOB", System.Data.SqlDbType.DateTime).Value = feeDetails.DOB;
                sqlCommand.Parameters.Add("@PhoneNumberOffice", System.Data.SqlDbType.VarChar).Value = feeDetails.PhoneNumberOffice;
                sqlCommand.Parameters.Add("@FeeDescription", System.Data.SqlDbType.VarChar).Value = feeDetails.FeeDescription;
                sqlCommand.Parameters.Add("@Amount", System.Data.SqlDbType.Decimal).Value = feeDetails.Amount;

                if (string.IsNullOrEmpty(feeDetails.StudentId))
                    sqlCommand.Parameters.AddWithValue("@StudentId", DBNull.Value); 
                else
                    sqlCommand.Parameters.Add("@StudentId", System.Data.SqlDbType.NVarChar).Value = feeDetails.StudentId;
                sqlCommand.Parameters.Add("@status", System.Data.SqlDbType.Bit).Value = true;
                connection.Open();
                sqlCommand.ExecuteNonQuery();

            }
            return FeeDetailsId;

        }
        public string SaveAddressDetails(AddressDetails addressDetails)
        {
            string AddressDetailsId = new Guid().ToString();
            string connectionString = System.Configuration.ConfigurationManager.
            ConnectionStrings["connectionStringName"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "insert into AddressDetails(AddressDetailsId,StudentId,FullAddress,PhoneNumberOffice,PhoneNumberResidence,EmailId,status) values(@AddressDetailsId,@StudentId,@FullAddress,@PhoneNumberOffice,@PhoneNumberResidence,@EmailId,@status)";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.Add("@AddressDetailsId", System.Data.SqlDbType.NVarChar).Value = addressDetails.AddressDetailsId;
                sqlCommand.Parameters.Add("@FullAddress", System.Data.SqlDbType.NVarChar).Value = addressDetails.FullAddress;
                sqlCommand.Parameters.Add("@PhoneNumberOffice", System.Data.SqlDbType.VarChar).Value = addressDetails.PhoneNumberOffice;
                sqlCommand.Parameters.Add("@PhoneNumberResidence", System.Data.SqlDbType.VarChar).Value = addressDetails.PhoneNumberResidence;
                sqlCommand.Parameters.Add("@EmailId", System.Data.SqlDbType.VarChar).Value = addressDetails.EmailId;
                if (string.IsNullOrEmpty(addressDetails.StudentId))
                    sqlCommand.Parameters.AddWithValue("@StudentId", DBNull.Value);
                else
                    sqlCommand.Parameters.Add("@StudentId", System.Data.SqlDbType.NVarChar).Value = addressDetails.StudentId;
                sqlCommand.Parameters.Add("@status", System.Data.SqlDbType.Bit).Value = true;
                connection.Open();
                sqlCommand.ExecuteNonQuery();

            }
            return AddressDetailsId;
        }
    }
}