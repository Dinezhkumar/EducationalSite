using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static UnivSite.Models.StudentDetails;

namespace EduSite.SqlDal
{
    public class StudentDetailsDal
    {
        public void AddPersonalDetails(PersonalDetails personalDetails)
        {
            string connectionString = System.Configuration.ConfigurationManager.
             ConnectionStrings["connectionStringName"].ConnectionString;
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                string query = "insert into PersonalDetails(ApplicantName,FatherName,MotherName,RegistrationNo,NatureOfDocument,ReasonOfApplying)values(@ApplicantName,@FatherName,@MotherName,@RegistrationNo,@NatureOfDocument,@ReasonOfApplying)";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.Add("@ApplicantName", System.Data.SqlDbType.NVarChar).Value = personalDetails.ApplicantName;
                sqlCommand.Parameters.Add("@FatherName", System.Data.SqlDbType.NVarChar).Value = personalDetails.FatherName;
                sqlCommand.Parameters.Add("@MotherName", System.Data.SqlDbType.NVarChar).Value = personalDetails.MotherName;
                sqlCommand.Parameters.Add("@RegistrationNo", System.Data.SqlDbType.NVarChar).Value = personalDetails.RegistrationNo;
                sqlCommand.Parameters.Add("@NatureOfDocument", System.Data.SqlDbType.NVarChar).Value = personalDetails.NatureOfDocument;
                sqlCommand.Parameters.Add("@ReasonOfApplying", System.Data.SqlDbType.NVarChar).Value = personalDetails.ReasonOfApplying;
                connection.Open();
                sqlCommand.ExecuteNonQuery();
                
            }
           
        }
        public void AddFeeDetails(FeeDetails feeDetails)
        {
            string connectionString = System.Configuration.ConfigurationManager.
             ConnectionStrings["connectionStringName"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "insert into FeeDetails(TransactionId,Date,PayeeName,FathersName,DOB,PhoneNumberOffice,FeeDescription)values(@TransactionId,@Date,@PayeeName,@FathersName,@DOB,@PhoneNumberOffice,@FeeDescription)";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.Add("@TransactionId", System.Data.SqlDbType.VarChar).Value = feeDetails.TransactionId;
                sqlCommand.Parameters.Add("@Date", System.Data.SqlDbType.VarChar).Value = feeDetails.Date;
                sqlCommand.Parameters.Add("@PayeeName", System.Data.SqlDbType.DateTime).Value = feeDetails.PayeeName;
                sqlCommand.Parameters.Add("@FathersName", System.Data.SqlDbType.VarChar).Value = feeDetails.FathersName;
                sqlCommand.Parameters.Add("@DOB", System.Data.SqlDbType.DateTime).Value = feeDetails.DOB;
                sqlCommand.Parameters.Add("@PhoneNumberOffice", System.Data.SqlDbType.VarChar).Value = feeDetails.PhoneNumberOffice;
                sqlCommand.Parameters.Add("@FeeDescription", System.Data.SqlDbType.VarChar).Value = feeDetails.FeeDescription;
                sqlCommand.Parameters.Add("@Amount", System.Data.SqlDbType.Decimal).Value = feeDetails.Amount;
                connection.Open();
                sqlCommand.ExecuteNonQuery();

            }

        }
        public void SaveAddressDetails(AddressDetails addressDetails)
        {
            string connectionString = System.Configuration.ConfigurationManager.
            ConnectionStrings["connectionStringName"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "insert into AddressDetails(FullAddress,PhoneNumberOffice,PhoneNumberResidence,EmailId) values(@FullAddress,@PhoneNumberOffice,@PhoneNumberResidence,@EmailId)";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.Add("@FullAddress", System.Data.SqlDbType.NVarChar).Value = addressDetails.FullAddress;
                sqlCommand.Parameters.Add("@PhoneNumberOffice", System.Data.SqlDbType.VarChar).Value = addressDetails.PhoneNumberOffice;
                sqlCommand.Parameters.Add("@PhoneNumberResidence", System.Data.SqlDbType.VarChar).Value = addressDetails.PhoneNumberResidence;
                sqlCommand.Parameters.Add("@EmailId", System.Data.SqlDbType.VarChar).Value = addressDetails.EmailId;
             
                connection.Open();
                sqlCommand.ExecuteNonQuery();

            }

        }
    }
}