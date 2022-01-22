using KEServiceV2.Models;
using KEServiceV2.Models.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KEServiceV2.Services
{
    public class TechnicianService
    {
        string strQuery = "";

        private BaseMySQLDAL objBaseMySQLDAL;
        private List<MySqlParameter> lstMySQLParam;

        private BaseDAL objBaseDAL;
        private List<SqlParameter> lstParam;

        public Tech_LoginRS Tech_login(Tech_LoginRQ objTechLoginRQ)
        {
            Tech_LoginRS objTechLogin = new Tech_LoginRS();
            objTechLogin.user_data = new UserData();

            dynamic objOtherData = new System.Dynamic.ExpandoObject();

            try
            {
                objBaseDAL = new BaseDAL();
                strQuery = "Tech_Login";
                lstParam = new List<SqlParameter>();

                lstParam.AddRange(new SqlParameter[]
                      {
                                new SqlParameter("@mobileno", objTechLoginRQ.mobileno),
                                new SqlParameter("@device_token", objTechLoginRQ.device_token),
                                new SqlParameter("@os_type", objTechLoginRQ.os_type),
                                new SqlParameter("@password", objTechLoginRQ.password),
                      });

                DataSet ResDataSet = objBaseDAL.GetResultDataSet(strQuery, CommandType.StoredProcedure, lstParam);

                if (ResDataSet.Tables.Count > 0)
                {
                    string strLoginType = string.Empty;

                    DataTable tblLoginType = ResDataSet.Tables[0];
                    DataTable tblResData = ResDataSet.Tables[1];

                    if (tblLoginType.Rows.Count > 0)
                    {
                        strLoginType = tblLoginType.Rows[0]["LoginType"] != DBNull.Value ? Convert.ToString(tblLoginType.Rows[0]["LoginType"]) : string.Empty;

                        DataRow dtRow = tblResData.Rows[0];

                        if (strLoginType == "T")
                        {


                            objTechLogin.user_data.userid = dtRow["Oid"] != DBNull.Value ? Convert.ToString(dtRow["Oid"]).ToUpper() : string.Empty;

                            objOtherData.Oid = dtRow["Oid"] != DBNull.Value ? Convert.ToString(dtRow["Oid"]).ToUpper() : string.Empty;
                            objOtherData.OldOid = dtRow["OldOid"] != DBNull.Value ? Convert.ToString(dtRow["OldOid"]) : string.Empty;
                            objOtherData.Technician = dtRow["Technician"] != DBNull.Value ? Convert.ToString(dtRow["Technician"]) : string.Empty;
                            objOtherData.Address = dtRow["Address"] != DBNull.Value ? Convert.ToString(dtRow["Address"]) : string.Empty;
                            objOtherData.City = dtRow["City"] != DBNull.Value ? Convert.ToString(dtRow["City"]) : string.Empty;
                            objOtherData.PhoneH = dtRow["PhoneH"] != DBNull.Value ? Convert.ToString(dtRow["PhoneH"]) : string.Empty;
                            objOtherData.PhoneO = dtRow["PhoneO"] != DBNull.Value ? Convert.ToString(dtRow["PhoneO"]) : string.Empty;
                            objOtherData.Mobile = dtRow["Mobile"] != DBNull.Value ? Convert.ToString(dtRow["Mobile"]) : string.Empty;
                            objOtherData.TechType = dtRow["TechType"] != DBNull.Value ? Convert.ToString(dtRow["TechType"]) : string.Empty;
                            objOtherData.JobType = dtRow["JobType"] != DBNull.Value ? Convert.ToString(dtRow["JobType"]) : string.Empty;
                            objOtherData.UserName = dtRow["UserName"] != DBNull.Value ? Convert.ToString(dtRow["UserName"]) : string.Empty;
                            objOtherData.Modifier = dtRow["Modifier"] != DBNull.Value ? Convert.ToString(dtRow["Modifier"]) : string.Empty;

                            CreationDate objCreatetionDate = new CreationDate();
                            objCreatetionDate.date = dtRow["CreationDate"] != DBNull.Value ? CommonService.FormatDateTime(Convert.ToString(dtRow["CreationDate"])) : "0000-00-00 00:00:00.000000";
                            objCreatetionDate.timezone_type = 3;
                            objCreatetionDate.timezone = "UTC";
                            objOtherData.CreationDate = objCreatetionDate;

                            ModifyDate objModifyDate = new ModifyDate();
                            objModifyDate.date = dtRow["ModifyDate"] != DBNull.Value ? CommonService.FormatDateTime(Convert.ToString(dtRow["ModifyDate"])) : "0000-00-00 00:00:00.000000";
                            objModifyDate.timezone_type = 3;
                            objModifyDate.timezone = "UTC";
                            objOtherData.ModifyDate = objModifyDate;

                            objOtherData.OptimisticLockField = dtRow["OptimisticLockField"] != DBNull.Value ? Convert.ToString(dtRow["OptimisticLockField"]) : string.Empty;
                            objOtherData.GCRecord = dtRow["GCRecord"] != DBNull.Value ? Convert.ToString(dtRow["GCRecord"]) : string.Empty;
                            objOtherData.IsActive = dtRow["IsActive"] != DBNull.Value ? Convert.ToString(dtRow["IsActive"]) : string.Empty;
                            objOtherData.L1 = dtRow["L1"] != DBNull.Value ? Convert.ToString(dtRow["L1"]) : string.Empty;
                            objOtherData.L2 = dtRow["L2"] != DBNull.Value ? Convert.ToString(dtRow["L2"]) : string.Empty;
                            objOtherData.DT = "N/A";//dtRow["DT"] != DBNull.Value ? Convert.ToString(dtRow["DT"]) : string.Empty;
                            objOtherData.os_type = null;//dtRow["os_type"] != DBNull.Value ? Convert.ToString(dtRow["os_type"]) : string.Empty;
                            objOtherData.device_token = dtRow["device_token"] != DBNull.Value ? Convert.ToString(dtRow["device_token"]) : string.Empty;
                            objOtherData.usertype = dtRow["usertype"] != DBNull.Value ? Convert.ToString(dtRow["usertype"]) : string.Empty;
                        }
                        else
                        {
                            objTechLogin.user_data.userid = null;

                            objOtherData.id = dtRow["id"] != DBNull.Value ? Convert.ToString(dtRow["id"]).ToUpper() : string.Empty;
                            objOtherData.Technician = dtRow["Technician"] != DBNull.Value ? Convert.ToString(dtRow["Technician"]) : string.Empty;
                            objOtherData.email = dtRow["email"] != DBNull.Value ? Convert.ToString(dtRow["email"]) : string.Empty;
                            objOtherData.Mobile = dtRow["Mobile"] != DBNull.Value ? Convert.ToString(dtRow["Mobile"]) : string.Empty;
                            objOtherData.apikey = dtRow["apikey"] != DBNull.Value ? Convert.ToString(dtRow["apikey"]) : string.Empty;
                            objOtherData.status = dtRow["status"] != DBNull.Value ? Convert.ToInt32(dtRow["status"]) : 0;
                            objOtherData.usertype = dtRow["usertype"] != DBNull.Value ? Convert.ToString(dtRow["usertype"]) : string.Empty;
                        }

                        objTechLogin.user_data.otherdata = objOtherData;

                    }
                }

            }
            catch (Exception ex)
            {
                objTechLogin = new Tech_LoginRS();
                CommonService.WriteErrorLog(ex);
            }

            return objTechLogin;

        }

        public Techman_JobListRS Techman_JobList(Techman_JobListRQ objTechmanJobListRQ)
        {
            objBaseDAL = new BaseDAL();

            Techman_JobListRS objTechman_JobList = new Techman_JobListRS();

            try
            {
                strQuery = @"SELECT
                                *
                            FROM

                                dbo.callregistration
                            WHERE

                                Technician = @techid

                                AND CallAttn = 0

                                AND(GCRecord IS NULL)

                                AND(JobDone IS NULL or JobDone = '0' or JobDone = 'False')";

                lstParam = new List<SqlParameter>();

                lstParam.AddRange(new SqlParameter[]
                      {
                                new SqlParameter("@techid", objTechmanJobListRQ.techid)
                      });

                DataTable ResData = objBaseDAL.GetResultDataTable(strQuery, CommandType.Text, lstParam);
                //DataRow dr = ResData.Rows[0];

                objTechman_JobList.success = 1;
                List<records> lstRecord = new List<records>();
                records objRecord;

                foreach (DataRow dtRow in ResData.Rows)
                {
                    objRecord = new records();


                    objRecord.Oid = dtRow["Oid"] != DBNull.Value ? Convert.ToString(dtRow["Oid"]).ToUpper() : string.Empty;
                    objRecord.IsNew = dtRow["IsNew"] != DBNull.Value ? Convert.ToString(dtRow["IsNew"]) : string.Empty;
                    objRecord.CallDeleted = dtRow["CallDeleted"] != DBNull.Value ? Convert.ToInt32(dtRow["CallDeleted"]) : 0;
                    objRecord.longitude = dtRow["longitude"] != DBNull.Value ? Convert.ToString(dtRow["longitude"]) : string.Empty;
                    objRecord.latitude = dtRow["latitude"] != DBNull.Value ? Convert.ToString(dtRow["latitude"]) : string.Empty;
                    objRecord.Area = dtRow["Area"] != DBNull.Value ? Convert.ToString(dtRow["Area"]) : string.Empty;
                    objRecord.Root_Priority = dtRow["Root_Priority"] != DBNull.Value ? Convert.ToString(dtRow["Root_Priority"]) : string.Empty;
                    objRecord.ID = dtRow["ID"] != DBNull.Value ? Convert.ToString(dtRow["ID"]) : string.Empty;
                    objRecord.RecipientType = dtRow["RecipientType"] != DBNull.Value ? Convert.ToString(dtRow["RecipientType"]) : string.Empty;
                    objRecord.Desp_Doc_No = dtRow["Desp_Doc_No"] != DBNull.Value ? Convert.ToString(dtRow["Desp_Doc_No"]) : string.Empty;
                    objRecord.Desp_Date = dtRow["Desp_Date"] != DBNull.Value ? Convert.ToString(dtRow["Desp_Date"]) : string.Empty;
                    objRecord.Equipment_Id = dtRow["Equipment_Id"] != DBNull.Value ? Convert.ToString(dtRow["Equipment_Id"]) : string.Empty;


                    objRecord.JobDoneTime = new JobDoneTime();
                    objRecord.JobDoneTime.date = dtRow["JobDoneTime"] != DBNull.Value ? CommonService.FormatDateTime(Convert.ToString(dtRow["JobDoneTime"])) : "0000-00-00 00:00:00.000000";
                    objRecord.JobDoneTime.timezone_type = 3;//Convert.ToString(dtRow["timezone_type"]);
                    objRecord.JobDoneTime.timezone = "UTC";//Convert.ToString(dtRow["timezone"]);

                    objRecord.CallAssignDate = new CallAssignDate();
                    objRecord.CallAssignDate.date = dtRow["CallAssignDate"] != DBNull.Value ? CommonService.FormatDateTime(Convert.ToString(dtRow["CallAssignDate"])) : "0000-00-00 00:00:00.000000";
                    objRecord.CallAssignDate.timezone_type = 3;//Convert.ToString(dtRow["timezone_type"]);
                    objRecord.CallAssignDate.timezone = "UTC";//Convert.ToString(dtRow["timezone"]);


                    objRecord.GodownName = dtRow["GodownName"] != DBNull.Value ? Convert.ToString(dtRow["GodownName"]) : string.Empty;
                    objRecord.Godown = dtRow["Godown"] != DBNull.Value ? Convert.ToString(dtRow["Godown"]) : string.Empty;
                    objRecord.DealerName = dtRow["DealerName"] != DBNull.Value ? Convert.ToString(dtRow["DealerName"]) : string.Empty;
                    objRecord.HomeDelivery = dtRow["HomeDelivery"] != DBNull.Value ? Convert.ToInt32(dtRow["HomeDelivery"]) : 0;
                    objRecord.Display = dtRow["Display"] != DBNull.Value ? Convert.ToInt32(dtRow["Display"]) : 0;
                    objRecord.ExchangeProduct = dtRow["ExchangeProduct"] != DBNull.Value ? Convert.ToString(dtRow["ExchangeProduct"]) : string.Empty;
                    objRecord.PendingExchange = dtRow["PendingExchange"] != DBNull.Value ? Convert.ToInt32(dtRow["PendingExchange"]) : 0;
                    objRecord.EstimateDate = dtRow["EstimateDate"] != DBNull.Value ? CommonService.FormatDateTime(Convert.ToString(dtRow["EstimateDate"])) : "0000-00-00 00:00:00.000000";
                    objRecord.EstConfirmDate = dtRow["EstConfirmDate"] != DBNull.Value ? CommonService.FormatDateTime(Convert.ToString(dtRow["EstConfirmDate"])) : "0000-00-00 00:00:00.000000";
                    objRecord.PaymentBy = dtRow["PaymentBy"] != DBNull.Value ? Convert.ToInt32(dtRow["PaymentBy"]) : 0;
                    objRecord.UserName = dtRow["UserName"] != DBNull.Value ? Convert.ToString(dtRow["UserName"]) : string.Empty;
                    objRecord.Modifier = dtRow["Modifier"] != DBNull.Value ? Convert.ToString(dtRow["Modifier"]) : string.Empty;


                    objRecord.CreationDate = new CreationDate();
                    objRecord.CreationDate.date = dtRow["CreationDate"] != DBNull.Value ? CommonService.FormatDateTime(Convert.ToString(dtRow["CreationDate"])) : "0000-00-00 00:00:00.000000";
                    objRecord.CreationDate.timezone_type = 3; // Convert.ToInt32(dtRow["timezone_type"]);
                    objRecord.CreationDate.timezone = "UTC"; //Convert.ToString(dtRow["timezone"]);


                    objRecord.ModifyDate = new ModifyDate();
                    objRecord.ModifyDate.date = dtRow["ModifyDate"] != DBNull.Value ? CommonService.FormatDateTime(Convert.ToString(dtRow["ModifyDate"])) : "0000-00-00 00:00:00.000000";
                    objRecord.ModifyDate.timezone_type = 3; // Convert.ToInt32(dtRow["timezone_type"]);
                    objRecord.ModifyDate.timezone = "UTC"; //Convert.ToString(dtRow["timezone"]);

                    objRecord.CompComplaintNo = dtRow["CallDate"] != DBNull.Value ? CommonService.FormatDateTime(Convert.ToString(dtRow["CallDate"])) : "0000-00-00 00:00:00.000000";
                    objRecord.JobNo = dtRow["JobNo"] != DBNull.Value ? Convert.ToString(dtRow["JobNo"]) : string.Empty;

                    objRecord.CallDate = new CallDate();
                    objRecord.CallDate.date = dtRow["CallDate"] != DBNull.Value ? CommonService.FormatDateTime(Convert.ToString(dtRow["CallDate"])) : "0000-00-00 00:00:00.000000";
                    objRecord.CallDate.timezone_type = 3; // Convert.ToInt32(dtRow["timezone_type"]);
                    objRecord.CallDate.timezone = "UTC"; //Convert.ToString(dtRow["timezone"]);

                    objRecord.ItemName = dtRow["ItemName"] != DBNull.Value ? Convert.ToString(dtRow["ItemName"]).ToUpper() : string.Empty;
                    objRecord.SrNo = dtRow["SrNo"] != DBNull.Value ? Convert.ToString(dtRow["SrNo"]) : string.Empty;
                    objRecord.FaultDesc = dtRow["FaultDesc"] != DBNull.Value ? Convert.ToString(dtRow["FaultDesc"]) : string.Empty;
                    objRecord.CallType = dtRow["CallType"] != DBNull.Value ? Convert.ToInt32(dtRow["CallType"]) : 0;
                    objRecord.Customer = dtRow["Customer"] != DBNull.Value ? Convert.ToString(dtRow["Customer"]).ToUpper() : string.Empty;
                    objRecord.CustomerName = dtRow["CustomerName"] != DBNull.Value ? Convert.ToString(dtRow["CustomerName"]) : string.Empty;
                    objRecord.MobileNo = dtRow["MobileNo"] != DBNull.Value ? Convert.ToString(dtRow["MobileNo"]) : string.Empty;
                    objRecord.Address = dtRow["Address"] != DBNull.Value ? Convert.ToString(dtRow["Address"]) : string.Empty;
                    objRecord.ProductName = dtRow["ProductName"] != DBNull.Value ? Convert.ToString(dtRow["ProductName"]) : string.Empty;
                    objRecord.ServType = dtRow["ServType"] != DBNull.Value ? Convert.ToInt32(dtRow["ServType"]) : 0;
                    objRecord.SpInst = dtRow["SpInst"] != DBNull.Value ? Convert.ToString(dtRow["SpInst"]) : string.Empty;
                    objRecord.ModelName = dtRow["ModelName"] != DBNull.Value ? Convert.ToString(dtRow["ModelName"]) : string.Empty;
                    objRecord.ItemGroup = dtRow["ItemGroup"] != DBNull.Value ? Convert.ToString(dtRow["ItemGroup"]) : string.Empty;
                    objRecord.PurchaseDate = dtRow["PurchaseDate"] != DBNull.Value ? CommonService.FormatDateTime(Convert.ToString(dtRow["PurchaseDate"])) : "0000-00-00 00:00:00.000000";
                    objRecord.WrExt = dtRow["WrExt"] != DBNull.Value ? Convert.ToInt32(dtRow["WrExt"]) : 0;
                    objRecord.BillNo = dtRow["BillNo"] != DBNull.Value ? Convert.ToString(dtRow["BillNo"]) : string.Empty;
                    objRecord.ShowRoom = dtRow["ShowRoom"] != DBNull.Value ? Convert.ToString(dtRow["ShowRoom"]) : string.Empty;
                    objRecord.TechBillNo = dtRow["TechBillNo"] != DBNull.Value ? Convert.ToString(dtRow["TechBillNo"]) : string.Empty;
                    objRecord.DealRef = dtRow["DealRef"] != DBNull.Value ? Convert.ToString(dtRow["DealRef"]) : string.Empty;
                    objRecord.Technician = dtRow["Technician"] != DBNull.Value ? Convert.ToString(dtRow["Technician"]).ToUpper() : string.Empty;
                    objRecord.Amount = dtRow["Amount"] != DBNull.Value ? Convert.ToInt32(dtRow["Amount"]) : 0;
                    objRecord.SIGN = dtRow["SIGN"] != DBNull.Value ? Convert.ToString(dtRow["SIGN"]) : string.Empty;

                    objRecord.Time_IN = new Time_IN();
                    objRecord.Time_IN.date = dtRow["Time_IN"] != DBNull.Value ? CommonService.FormatDateTime(Convert.ToString(dtRow["Time_IN"])) : "0000-00-00 00:00:00.000000";
                    objRecord.Time_IN.timezone_type = 3; // Convert.ToInt32(dtRow["timezone_type"]);
                    objRecord.Time_IN.timezone = "UTC"; //Convert.ToString(dtRow["timezone"]);

                    objRecord.Time_OUT = new Time_OUT();
                    objRecord.Time_OUT.date = dtRow["Time_OUT"] != DBNull.Value ? CommonService.FormatDateTime(Convert.ToString(dtRow["Time_OUT"])) : "0000-00-00 00:00:00.000000";
                    objRecord.Time_OUT.timezone_type = 3; // Convert.ToInt32(dtRow["timezone_type"]);
                    objRecord.Time_OUT.timezone = "UTC"; //Convert.ToString(dtRow["timezone"]);


                    objRecord.Warranty = dtRow["CallDate"] != DBNull.Value ? CommonService.FormatDateTime(Convert.ToString(dtRow["CallDate"])) : "0000-00-00 00:00:00.000000";
                    objRecord.CallAttn = dtRow["CallAttn"] != DBNull.Value ? Convert.ToInt32(dtRow["CallAttn"]) : 0;
                    objRecord.JobDone = dtRow["JobDone"] != DBNull.Value ? Convert.ToInt32(dtRow["JobDone"]) : 0;
                    objRecord.Deliver = dtRow["Deliver"] != DBNull.Value ? Convert.ToInt32(dtRow["Deliver"]) : 0;
                    objRecord.SMSSent = dtRow["SMSSent"] != DBNull.Value ? Convert.ToInt32(dtRow["SMSSent"]) : 0;
                    objRecord.Estimate = dtRow["Estimate"] != DBNull.Value ? Convert.ToString(dtRow["Estimate"]) : string.Empty;
                    objRecord.DelQty = dtRow["DelQty"] != DBNull.Value ? Convert.ToInt32(dtRow["DelQty"]) : 0;
                    objRecord.Salesman = dtRow["Salesman"] != DBNull.Value ? Convert.ToString(dtRow["Salesman"]) : string.Empty;
                    objRecord.Driver = dtRow["Driver"] != DBNull.Value ? Convert.ToString(dtRow["Driver"]) : string.Empty;
                    objRecord.VehicleNo = dtRow["VehicleNo"] != DBNull.Value ? Convert.ToString(dtRow["VehicleNo"]) : string.Empty;
                    objRecord.Payment = dtRow["Payment"] != DBNull.Value ? Convert.ToString(dtRow["Payment"]) : string.Empty;
                    objRecord.VisitCharge = dtRow["VisitCharge"] != DBNull.Value ? Convert.ToString(dtRow["VisitCharge"]) : string.Empty;
                    objRecord.Rent = dtRow["Rent"] != DBNull.Value ? Convert.ToString(dtRow["Rent"]) : string.Empty;
                    objRecord.CallBack = dtRow["CallBack"] != DBNull.Value ? Convert.ToInt32(dtRow["CallBack"]) : 0;
                    objRecord.WorkShopIN = dtRow["WorkShopIN"] != DBNull.Value ? Convert.ToInt32(dtRow["WorkShopIN"]) : 0;
                    objRecord.PartPanding = dtRow["PartPanding"] != DBNull.Value ? Convert.ToInt32(dtRow["PartPanding"]) : 0;
                    objRecord.GoAfterCall = dtRow["GoAfterCall"] != DBNull.Value ? Convert.ToInt32(dtRow["GoAfterCall"]) : 0;
                    objRecord.Canceled = dtRow["Canceled"] != DBNull.Value ? Convert.ToInt32(dtRow["Canceled"]) : 0;
                    objRecord.PaymentPanding = dtRow["PaymentPanding"] != DBNull.Value ? Convert.ToInt32(dtRow["PaymentPanding"]) : 0;
                    objRecord.Exchange = dtRow["Exchange"] != DBNull.Value ? Convert.ToString(dtRow["Exchange"]) : string.Empty;
                    objRecord.Exchange1 = dtRow["Exchange1"] != DBNull.Value ? Convert.ToInt32(dtRow["Exchange1"]) : 0;
                    objRecord.Repeat = dtRow["Repeat"] != DBNull.Value ? Convert.ToInt32(dtRow["Repeat"]) : 0;

                    objRecord.RepeatFromTech = dtRow["RepeatFromTech"] != DBNull.Value ? Convert.ToInt32(dtRow["RepeatFromTech"]) : 0;
                    objRecord.JobRegion = dtRow["JobRegion"] != DBNull.Value ? Convert.ToString(dtRow["JobRegion"]) : string.Empty;
                    objRecord.JobDoneRegion = dtRow["JobDoneRegion"] != DBNull.Value ? Convert.ToString(dtRow["JobDoneRegion"]) : string.Empty;
                    objRecord.FaultType = dtRow["FaultType"] != DBNull.Value ? Convert.ToString(dtRow["FaultType"]) : string.Empty;
                    objRecord.OptimisticLockField = dtRow["OptimisticLockField"] != DBNull.Value ? Convert.ToInt32(dtRow["OptimisticLockField"]) : 0;
                    objRecord.GCRecord = dtRow["GCRecord"] != DBNull.Value ? Convert.ToString(dtRow["GCRecord"]) : string.Empty;
                    objRecord.TimeIN = dtRow["Time_IN"] != DBNull.Value ? Convert.ToString(dtRow["Time_IN"]) : string.Empty;
                    objRecord.TimeOUT = dtRow["Time_OUT"] != DBNull.Value ? Convert.ToString(dtRow["Time_OUT"]) : string.Empty;
                    objRecord.fault_name1 = dtRow["fault_name1"] != DBNull.Value ? Convert.ToString(dtRow["fault_name1"]) : string.Empty;
                    objRecord.fault_name2 = dtRow["fault_name2"] != DBNull.Value ? Convert.ToString(dtRow["fault_name2"]) : string.Empty;
                    objRecord.fault_name3 = dtRow["fault_name3"] != DBNull.Value ? Convert.ToString(dtRow["fault_name3"]) : string.Empty;
                    objRecord.fault_name4 = dtRow["fault_name4"] != DBNull.Value ? Convert.ToString(dtRow["fault_name4"]) : string.Empty;
                    objRecord.fault_name5 = dtRow["fault_name5"] != DBNull.Value ? Convert.ToString(dtRow["fault_name5"]) : string.Empty;
                    objRecord.fault_name6 = dtRow["fault_name6"] != DBNull.Value ? Convert.ToString(dtRow["fault_name6"]) : string.Empty;
                    objRecord.fault_qty1 = dtRow["fault_qty1"] != DBNull.Value ? Convert.ToString(dtRow["fault_qty1"]) : string.Empty;
                    objRecord.fault_qty2 = dtRow["fault_qty2"] != DBNull.Value ? Convert.ToString(dtRow["fault_qty2"]) : string.Empty;
                    objRecord.fault_qty3 = dtRow["fault_qty3"] != DBNull.Value ? Convert.ToString(dtRow["fault_qty3"]) : string.Empty;
                    objRecord.fault_qty4 = dtRow["fault_qty4"] != DBNull.Value ? Convert.ToString(dtRow["fault_qty4"]) : string.Empty;
                    objRecord.fault_qty5 = dtRow["fault_qty5"] != DBNull.Value ? Convert.ToString(dtRow["fault_qty5"]) : string.Empty;
                    objRecord.fault_qty6 = dtRow["fault_qty6"] != DBNull.Value ? Convert.ToString(dtRow["fault_qty6"]) : string.Empty;
                    objRecord.cu_latitude = dtRow["cu_latitude"] != DBNull.Value ? Convert.ToString(dtRow["cu_latitude"]) : string.Empty;
                    objRecord.cu_longitude = dtRow["cu_longitude"] != DBNull.Value ? Convert.ToString(dtRow["cu_longitude"]) : string.Empty;
                    objRecord.technisian_latitude = dtRow["technisian_latitude"] != DBNull.Value ? Convert.ToString(dtRow["technisian_latitude"]) : string.Empty;
                    objRecord.technisian_longitude = dtRow["technisian_longitude"] != DBNull.Value ? Convert.ToString(dtRow["technisian_longitude"]) : string.Empty;
                    objRecord.time_between = dtRow["time_between"] != DBNull.Value ? Convert.ToString(dtRow["time_between"]) : string.Empty;
                    objRecord.PaymentByCheque = dtRow["PaymentByCheque"] != DBNull.Value ? Convert.ToString(dtRow["PaymentByCheque"]) : string.Empty;
                    objRecord.fault_name7 = dtRow["fault_name7"] != DBNull.Value ? Convert.ToString(dtRow["fault_name7"]) : string.Empty;

                    objRecord.tech_detail = new TechDetail();

                    objRecord.tech_detail = this.TechnicianDetailById(objRecord.Technician);

                    objRecord.Area_detail = new AreaDetail();

                    //objRecord.Area_detail.AreaName = dtRow["AreaName"] != DBNull.Value ? Convert.ToString(dtRow["AreaName"]) : string.Empty;

                    if (!string.IsNullOrEmpty(objRecord.Area))
                    {
                        this.AreaDetailById(objRecord.Technician);
                    }
                    else
                    {
                        objRecord.Area_detail.AreaName = "Local Job";
                    }

                    lstRecord.Add(objRecord);

                }

                objTechman_JobList.records = lstRecord;
            }
            catch (Exception ex)
            {
                objTechman_JobList = new Techman_JobListRS();
                objTechman_JobList.success = 0;
                CommonService.WriteErrorLog(ex);
            }

            return objTechman_JobList;
        }

        public TechDetail TechnicianDetailById(string TechnicianId)
        {
            TechDetail objTechnicianDetail = new TechDetail();

            try
            {
                strQuery = @"SELECT * FROM dbo.Technician WHERE Oid = @Oid";

                lstParam = new List<SqlParameter>();

                lstParam.AddRange(new SqlParameter[]
                      {
                                new SqlParameter("@Oid", TechnicianId)
                      });

                DataTable ResData = objBaseDAL.GetResultDataTable(strQuery, CommandType.Text, lstParam);
                DataRow dr = ResData.Rows[0];

                objTechnicianDetail.Oid = dr["Oid"] != DBNull.Value ? Convert.ToString(dr["Oid"]).ToUpper().ToUpper() : string.Empty;
                objTechnicianDetail.OldOid = dr["OldOid"] != DBNull.Value ? Convert.ToString(dr["OldOid"]) : string.Empty;
                objTechnicianDetail.IsActive = dr["IsActive"] != DBNull.Value ? Convert.ToInt32(dr["IsActive"]) : 0;
                objTechnicianDetail.Technician = dr["Technician"] != DBNull.Value ? Convert.ToString(dr["Technician"]) : string.Empty;
                objTechnicianDetail.Address = dr["Address"] != DBNull.Value ? Convert.ToString(dr["Address"]) : string.Empty;
                objTechnicianDetail.City = dr["City"] != DBNull.Value ? Convert.ToString(dr["City"]).ToUpper() : string.Empty;
                objTechnicianDetail.L1 = dr["L1"] != DBNull.Value ? Convert.ToString(dr["L1"]) : string.Empty;
                objTechnicianDetail.L2 = dr["L2"] != DBNull.Value ? Convert.ToString(dr["L2"]) : string.Empty;
                objTechnicianDetail.PhoneH = dr["PhoneH"] != DBNull.Value ? Convert.ToString(dr["PhoneH"]) : string.Empty;
                objTechnicianDetail.PhoneO = dr["PhoneO"] != DBNull.Value ? Convert.ToString(dr["PhoneO"]) : string.Empty;
                objTechnicianDetail.Mobile = dr["Mobile"] != DBNull.Value ? Convert.ToString(dr["Mobile"]) : string.Empty;
                objTechnicianDetail.TechType = dr["TechType"] != DBNull.Value ? Convert.ToString(dr["TechType"]).ToUpper() : string.Empty;
                objTechnicianDetail.JobType = dr["JobType"] != DBNull.Value ? Convert.ToString(dr["JobType"]) : string.Empty;
                objTechnicianDetail.UserName = dr["UserName"] != DBNull.Value ? Convert.ToString(dr["UserName"]) : string.Empty;
                objTechnicianDetail.Modifier = dr["Modifier"] != DBNull.Value ? Convert.ToString(dr["Modifier"]) : string.Empty;


                objTechnicianDetail.CreationDate = new CreationDate();
                objTechnicianDetail.CreationDate.date = dr["CreationDate"] != DBNull.Value ? Convert.ToString(dr["CreationDate"]) : string.Empty;
                objTechnicianDetail.CreationDate.timezone_type = 3; // Convert.ToInt32(dtRow["timezone_type"]);
                objTechnicianDetail.CreationDate.timezone = "UTC"; //Convert.ToString(dtRow["timezone"]);


                objTechnicianDetail.ModifyDate = new ModifyDate();
                objTechnicianDetail.ModifyDate.date = dr["ModifyDate"] != DBNull.Value ? Convert.ToString(dr["ModifyDate"]) : string.Empty;
                objTechnicianDetail.ModifyDate.timezone_type = 3; // Convert.ToInt32(dtRow["timezone_type"]);
                objTechnicianDetail.ModifyDate.timezone = "UTC"; //Convert.ToString(dtRow["timezone"]);

                objTechnicianDetail.OptimisticLockField = dr["OptimisticLockField"] != DBNull.Value ? Convert.ToInt32(dr["OptimisticLockField"]) : 0;
                objTechnicianDetail.GCRecord = dr["GCRecord"] != DBNull.Value ? Convert.ToString(dr["GCRecord"]) : string.Empty;
                objTechnicianDetail.locationtime = dr["locationtime"] != DBNull.Value ? Convert.ToString(dr["locationtime"]) : string.Empty;
                objTechnicianDetail.device_token = dr["device_token"] != DBNull.Value ? Convert.ToString(dr["device_token"]) : string.Empty;


            }
            catch (Exception ex)
            {
                objTechnicianDetail = new TechDetail();
                CommonService.WriteErrorLog(ex);
            }

            return objTechnicianDetail;
        }

        public AreaDetail AreaDetailById(string AreaId)
        {
            AreaDetail objAreaDetail = new AreaDetail();

            try
            {
                strQuery = @"SELECT * FROM dbo.Area WHERE Oid = @Oid";

                lstParam = new List<SqlParameter>();

                lstParam.AddRange(new SqlParameter[]
                      {
                                new SqlParameter("@Oid", AreaId)
                      });

                DataTable ResData = objBaseDAL.GetResultDataTable(strQuery, CommandType.Text, lstParam);


                if (ResData != null)
                {
                    DataRow dr = ResData.Rows[0];

                    objAreaDetail.AreaName = dr["AreaName"] != DBNull.Value ? Convert.ToString(dr["AreaName"]) : string.Empty;
                }

            }
            catch (Exception ex)
            {
                objAreaDetail = new AreaDetail();
                CommonService.WriteErrorLog(ex);
            }

            return objAreaDetail;
        }

        #region JobDone Verify
        public Jobdone_VerifyRS JobDone_Verify(Jobdone_VerifyRQ objJobdoneVerifyRQ)
        {
            objBaseMySQLDAL = new BaseMySQLDAL();

            Jobdone_VerifyRS objJobdoneVerifyRS = new Jobdone_VerifyRS();
            bool blnCustCodeMatch = false;
            int intRid = 0;
            string strCustomerCode = string.Empty;

            try
            {
                strQuery = @"SELECT rid,cust_code FROM job_done_verify_tbl WHERE order_id = @order_id AND tech_mob= @mob AND cust_code = @cust_code; ";

                lstMySQLParam = new List<MySqlParameter>();

                lstMySQLParam.AddRange(new MySqlParameter[]
                      {
                                new MySqlParameter("@order_id", objJobdoneVerifyRQ.order_id),
                                new MySqlParameter("@mob", objJobdoneVerifyRQ.mob),
                                new MySqlParameter("@cust_code", objJobdoneVerifyRQ.code),
                      });

                DataTable ResData = objBaseMySQLDAL.GetResultDataTable(strQuery, CommandType.Text, lstMySQLParam);

                if (ResData.Rows.Count > 0)
                {
                    DataRow dtRow = ResData.Rows[0];

                    strCustomerCode = dtRow["cust_code"] != DBNull.Value ? Convert.ToString(dtRow["cust_code"]) : string.Empty;
                    intRid = dtRow["rid"] != DBNull.Value ? Convert.ToInt32(dtRow["rid"]) : 0;
                    blnCustCodeMatch = !string.IsNullOrEmpty(strCustomerCode) ? true : false;
                    /*
                    foreach(DataRow dtRow in ResData.Rows)
                    {
                        string strCustomerCode = dtRow["cust_code"] != DBNull.Value ? Convert.ToString(dtRow["cust_code"]) : string.Empty;
                        
                        if (strCustomerCode == objJobdoneVerifyRQ.code)
                        {
                            intRid = dtRow["rid"] != DBNull.Value ? Convert.ToInt32(dtRow["rid"]) : 0;

                            blnCustCodeMatch = true;
                            break;
                        }
                    }
                    */
                }

                UpdateJobSataus(blnCustCodeMatch, intRid);


                if (blnCustCodeMatch)
                {
                    objJobdoneVerifyRS.success_msg = "Successfully Verfied";
                    objJobdoneVerifyRS.success = 1;

                }
                else
                {
                    objJobdoneVerifyRS.success_msg = "Verfication Failed Due to Wrong Code";
                    objJobdoneVerifyRS.success = 0;
                }

            }
            catch (Exception ex)
            {
                objJobdoneVerifyRS = new Jobdone_VerifyRS();
                CommonService.WriteErrorLog(ex);
            }

            return objJobdoneVerifyRS;
        }

        public void UpdateJobSataus(bool blnJobDoneStatus, int rid)
        {
            objBaseMySQLDAL = new BaseMySQLDAL();


            try
            {
                if (blnJobDoneStatus)
                {
                    strQuery = @"UPDATE job_done_verify_tbl SET is_verify_tech = 1 WHERE rid = @rid";
                }
                else
                {
                    strQuery = @"UPDATE job_done_verify_tbl SET is_verify_tech = 0 WHERE rid = @rid";
                }


                lstMySQLParam = new List<MySqlParameter>();

                lstMySQLParam.AddRange(new MySqlParameter[]
                      {
                                new MySqlParameter("@rid", rid)
                      });

                objBaseMySQLDAL.ExeccuteStoreCommand(strQuery, CommandType.Text, lstMySQLParam);



            }
            catch (Exception ex)
            {
                CommonService.WriteErrorLog(ex);
            }

        }

        #endregion

        #region KE_Company_List

        public Company_ListRS Company_List(Company_ListRQ objCompanyListRQ)
        {
            objBaseDAL = new BaseDAL();

            Company_ListRS objCompanyListRS = new Company_ListRS();

            List<CompanyDetail> lstCompanyDetail = new List<CompanyDetail>();


            try
            {
                strQuery = @"SELECT DISTINCT a.CompanyName, a.Oid FROM dbo.Company a, dbo.Item b WHERE b.category like '%' + @var_cat_name + '%' AND b.Company=a.Oid AND (a.CompanyName IS NOT NULL OR a.CompanyName !='')";

                lstParam = new List<SqlParameter>();

                lstParam.AddRange(new SqlParameter[]
                      {
                                new SqlParameter("@var_cat_name", objCompanyListRQ.var_cat_name),
                      });

                DataTable ResData = objBaseDAL.GetResultDataTable(strQuery, CommandType.Text, lstParam);

                if (ResData.Rows.Count > 0)
                {

                    foreach (DataRow drRow in ResData.Rows)
                    {

                        lstCompanyDetail.Add(new CompanyDetail()
                        {
                            Oid = drRow["Oid"] != DBNull.Value ? Convert.ToString(drRow["Oid"]) : string.Empty,
                            CompanyName = drRow["CompanyName"] != DBNull.Value ? Convert.ToString(drRow["CompanyName"]) : string.Empty,
                        });
                    }

                }

                List<Company_Record> lstCompanyRecord = new List<Company_Record>();

                foreach (var companyitem in lstCompanyDetail)
                {
                    Company_Record objCompany_Record = new Company_Record();

                    objCompany_Record.item_details = GetItemDetailByCompanyId(companyitem.Oid);
                    objCompany_Record.Oid = companyitem.Oid;
                    objCompany_Record.CompanyName = companyitem.CompanyName;

                    lstCompanyRecord.Add(objCompany_Record);
                }

                objCompanyListRS.records = lstCompanyRecord;
                objCompanyListRS.success = 1;



            }
            catch (Exception ex)
            {
                objCompanyListRS = new Company_ListRS();
                objCompanyListRS.success = 0;
                CommonService.WriteErrorLog(ex);
            }

            return objCompanyListRS;
        }


        public ItemDetails GetItemDetailByCompanyId(string strCompanyId)
        {
            ItemDetails objItemDetails = new ItemDetails();

            try
            {
                strQuery = @"SELECT TOP 1 * FROM dbo.Item WHERE Company= @Company";

                lstParam = new List<SqlParameter>();

                lstParam.AddRange(new SqlParameter[]
                      {
                                new SqlParameter("@Company", strCompanyId),
                      });

                DataTable ResData = objBaseDAL.GetResultDataTable(strQuery, CommandType.Text, lstParam);

                if (ResData.Rows.Count > 0)
                {
                    DataRow drRow = ResData.Rows[0];

                    objItemDetails.Oid = drRow["Oid"] != DBNull.Value ? Convert.ToString(drRow["Oid"]) : string.Empty;
                    objItemDetails.OldOid = drRow["OldOid"] != DBNull.Value ? Convert.ToString(drRow["OldOid"]) : string.Empty;
                    objItemDetails.ItemName = drRow["ItemName"] != DBNull.Value ? Convert.ToString(drRow["ItemName"]) : string.Empty;
                    objItemDetails.Company = drRow["Company"] != DBNull.Value ? Convert.ToString(drRow["Company"]) : string.Empty;
                    objItemDetails.Brand = drRow["Brand"] != DBNull.Value ? Convert.ToString(drRow["Brand"]) : string.Empty;
                    objItemDetails.ModelName = drRow["ModelName"] != DBNull.Value ? Convert.ToString(drRow["ModelName"]) : string.Empty;
                    objItemDetails.Group = drRow["Group"] != DBNull.Value ? Convert.ToString(drRow["Group"]) : string.Empty;
                    objItemDetails.OptimisticLockField = drRow["OptimisticLockField"] != DBNull.Value ? Convert.ToInt32(drRow["OptimisticLockField"]) : 0;
                    objItemDetails.GCRecord = drRow["GCRecord"] != DBNull.Value ? Convert.ToInt32(drRow["GCRecord"]) : 0;
                    objItemDetails.category = drRow["category"] != DBNull.Value ? Convert.ToString(drRow["category"]) : string.Empty;

                }



            }
            catch (Exception ex)
            {
                objItemDetails = new ItemDetails();
                CommonService.WriteErrorLog(ex);
            }

            return objItemDetails;
        }

        #endregion

        #region Version

        public VersionRS VersionDetail()
        {
            objBaseMySQLDAL = new BaseMySQLDAL();

            VersionRS objVersionRS = new VersionRS();
            objVersionRS.records = new List<VersionRecord>();

            try
            {
                strQuery = @"SELECT * FROM `states`;";

                lstMySQLParam = new List<MySqlParameter>();

                DataTable ResData = objBaseMySQLDAL.GetResultDataTable(strQuery, CommandType.Text, lstMySQLParam);

                if (ResData.Rows.Count > 0)
                {
                    DataRow dtRow = ResData.Rows[0];

                    VersionRecord objVersionRecord = new VersionRecord();

                    objVersionRecord.id = dtRow["id"] != DBNull.Value ? Convert.ToString(dtRow["id"]) : string.Empty;
                    objVersionRecord.states = dtRow["states"] != DBNull.Value ? Convert.ToString(dtRow["states"]) : string.Empty;
                    objVersionRecord.androidversion = dtRow["androidversion"] != DBNull.Value ? Convert.ToString(dtRow["androidversion"]) : string.Empty;
                    objVersionRecord.Iosversion = dtRow["Iosversion"] != DBNull.Value ? Convert.ToString(dtRow["Iosversion"]) : string.Empty;
                    objVersionRecord.Atechversion = dtRow["Atechversion"] != DBNull.Value ? Convert.ToString(dtRow["Atechversion"]) : string.Empty;
                    objVersionRecord.Itechversion = dtRow["Itechversion"] != DBNull.Value ? Convert.ToString(dtRow["Itechversion"]) : string.Empty;

                    objVersionRS.records.Add(objVersionRecord);

                    objVersionRS.success = 1;
                    objVersionRS.success_msg = "Successfully Data Selected";

                }

            }
            catch (Exception ex)
            {
                objVersionRS = new VersionRS();
                objVersionRS.success = 0;
                objVersionRS.success_msg = "Error In Data Selection";
                CommonService.WriteErrorLog(ex);
            }

            return objVersionRS;
        }

        #endregion

        #region Job_Start

        public Job_StartRS Job_Start(Job_StartRQ objJobStartRQ)
        {
            objBaseMySQLDAL = new BaseMySQLDAL();

            Job_StartRS objJobStartRS = new Job_StartRS();
            objJobStartRS.records = new List<object>();

            int LastId = 0;

            try
            {
                strQuery = @"INSERT INTO `job_activity` (`joboid`, `techid`, `date`, `starttime`, `starttimelatitude`, `starttimelongitude`) VALUES (@joboid, @techid, @date, @starttime, @starttimelatitude, @starttimelongitude);";

                lstMySQLParam = new List<MySqlParameter>();



                lstMySQLParam.AddRange(new MySqlParameter[]
                    {
                                new MySqlParameter("@techid", objJobStartRQ.techid),
                                new MySqlParameter("@joboid", objJobStartRQ.order_id),
                                new MySqlParameter("@starttimelatitude", objJobStartRQ.starttimelatitude),
                                new MySqlParameter("@starttimelongitude", objJobStartRQ.starttimelongitude),
                                new MySqlParameter("@date", DateTime.Now),
                                new MySqlParameter("@starttime", DateTime.Now),
                    });

                objBaseMySQLDAL.ExeccuteStoreCommand(strQuery, CommandType.Text, lstMySQLParam);


                objJobStartRS.success = 1;
                objJobStartRS.success_msg = "Job Started...";




            }
            catch (Exception ex)
            {
                objJobStartRS = new Job_StartRS();
                objJobStartRS.success = 0;
                objJobStartRS.success_msg = "Try Again...";
                CommonService.WriteErrorLog(ex);
            }

            return objJobStartRS;
        }

        #endregion

        #region Job Done

        public Job_DoneRS Technician_Job_Done(Job_DoneRQ objJob_DoneRQ)
        {
            Job_DoneRS objJobDoneRS = new Job_DoneRS();

            bool blnSuccess = false;

            string AppDownload = objJob_DoneRQ.AppDownload;
            string AppAlreadyIns = objJob_DoneRQ.AppAlreadyIns;
            string NotPhone = objJob_DoneRQ.NotPhone;

            string jobno = string.Empty, Technicianname = string.Empty, TechnicianMobile = string.Empty, CustomerName = string.Empty, CustomerMobileNo = string.Empty;

            bool blnJobDoneSuccess = false, blnJobDoneTableSuccess = false;

            try
            {
                objBaseDAL = new BaseDAL();
                strQuery = "Job_Done";
                lstParam = new List<SqlParameter>();

                lstParam.AddRange(new SqlParameter[]
                      {
                          new SqlParameter("@order_id", !string.IsNullOrEmpty(objJob_DoneRQ.order_id) ? objJob_DoneRQ.order_id : null),
                          new SqlParameter("@tech_id", !string.IsNullOrEmpty(objJob_DoneRQ.tech_id) ? objJob_DoneRQ.tech_id : null),
                          new SqlParameter("@reasonForJobDone", !string.IsNullOrEmpty(objJob_DoneRQ.reasonForJobDone) ? objJob_DoneRQ.reasonForJobDone : null),
                          new SqlParameter("@reasonForNotJobdone", !string.IsNullOrEmpty(objJob_DoneRQ.reasonForNotJobdone) ? objJob_DoneRQ.reasonForNotJobdone : null),
                          new SqlParameter("@EXCHANGE", !string.IsNullOrEmpty(objJob_DoneRQ.EXCHANGE) ? objJob_DoneRQ.EXCHANGE : null),
                          new SqlParameter("@job_done", objJob_DoneRQ.job_done),
                          new SqlParameter("@CallBack", objJob_DoneRQ.CallBack),
                          new SqlParameter("@PartPanding", objJob_DoneRQ.PartPanding),
                          new SqlParameter("@GoAfterCall", objJob_DoneRQ.GoAfterCall),
                          new SqlParameter("@Repeat", objJob_DoneRQ.Repeat),
                          new SqlParameter("@PaymentPanding", objJob_DoneRQ.PaymentPanding),
                          new SqlParameter("@Exchange1", objJob_DoneRQ.Exchange1),
                          new SqlParameter("@HomeDelivery", objJob_DoneRQ.HomeDelivery),
                          new SqlParameter("@RepeatFromTech", objJob_DoneRQ.RepeatFromTech),
                          new SqlParameter("@PaymentByCheque", !string.IsNullOrEmpty(objJob_DoneRQ.PaymentByCheque) ? objJob_DoneRQ.PaymentByCheque : null),
                          new SqlParameter("@call_attend", !string.IsNullOrEmpty(objJob_DoneRQ.call_attend) ? objJob_DoneRQ.call_attend : null),
                          new SqlParameter("@Canceled", objJob_DoneRQ.Canceled),
                          new SqlParameter("@WorkShopIN", objJob_DoneRQ.WorkShopIN),
                          new SqlParameter("@AMC", objJob_DoneRQ.AMC),
                          //new SqlParameter("@AppDownload", !string.IsNullOrEmpty(objJob_DoneRQ.AppDownload) ? objJob_DoneRQ.AppDownload : null),
                          //new SqlParameter("@AppAlreadyIns", !string.IsNullOrEmpty(objJob_DoneRQ.AppAlreadyIns) ? objJob_DoneRQ.AppAlreadyIns : null),
                          //new SqlParameter("@NotPhone", !string.IsNullOrEmpty(objJob_DoneRQ.NotPhone) ? objJob_DoneRQ.NotPhone : null),
                          new SqlParameter("@srno", !string.IsNullOrEmpty(objJob_DoneRQ.srno) ? objJob_DoneRQ.srno : null),
                          new SqlParameter("@billno", !string.IsNullOrEmpty(objJob_DoneRQ.billno) ? objJob_DoneRQ.billno : null),
                          new SqlParameter("@tech_bill_no", !string.IsNullOrEmpty(objJob_DoneRQ.tech_bill_no) ? objJob_DoneRQ.tech_bill_no : null),
                          new SqlParameter("@modelno", !string.IsNullOrEmpty(objJob_DoneRQ.modelno) ? objJob_DoneRQ.modelno : null),
                          new SqlParameter("@dop", !string.IsNullOrEmpty(objJob_DoneRQ.dop) ? objJob_DoneRQ.dop : null),
                          new SqlParameter("@tech_visit_charge", !string.IsNullOrEmpty(objJob_DoneRQ.tech_visit_charge) ? objJob_DoneRQ.tech_visit_charge : null),
                          new SqlParameter("@final_amount", !string.IsNullOrEmpty(objJob_DoneRQ.final_amount) ? objJob_DoneRQ.final_amount : null),
                          new SqlParameter("@Estimateamount", !string.IsNullOrEmpty(objJob_DoneRQ.Estimateamount) ? objJob_DoneRQ.Estimateamount : null),
                          //new SqlParameter("@ipAddress", !string.IsNullOrEmpty(objJob_DoneRQ.ipAddress) ? objJob_DoneRQ.ipAddress : null),
                          //new SqlParameter("@imei", !string.IsNullOrEmpty(objJob_DoneRQ.imei) ? objJob_DoneRQ.imei : null),
                          //new SqlParameter("@endtimelatitude", !string.IsNullOrEmpty(objJob_DoneRQ.endtimelatitude) ? objJob_DoneRQ.endtimelatitude : null),
                          //new SqlParameter("@endtimelongitude", !string.IsNullOrEmpty(objJob_DoneRQ.endtimelongitude) ? objJob_DoneRQ.endtimelongitude : null)
                      });

                DataSet ResDataSet = objBaseDAL.GetResultDataSet(strQuery, CommandType.StoredProcedure, lstParam);

                if (ResDataSet.Tables.Count > 0)
                {
                    DataTable tblCallregistration = ResDataSet.Tables[0];
                    DataTable tblTechnician = ResDataSet.Tables[1];

                    if (tblCallregistration.Rows.Count > 0)
                    {
                        DataRow dtRowCR = tblCallregistration.Rows[0];

                        jobno = dtRowCR["JobNo"] != DBNull.Value ? Convert.ToString(dtRowCR["JobNo"]) : null;
                        CustomerName = dtRowCR["CustomerName"] != DBNull.Value ? Convert.ToString(dtRowCR["CustomerName"]) : null;
                        CustomerMobileNo = dtRowCR["MobileNo"] != DBNull.Value ? Convert.ToString(dtRowCR["MobileNo"]) : null;

                    }

                    if (tblTechnician.Rows.Count > 0)
                    {
                        DataRow dtRowTech = tblTechnician.Rows[0];

                        Technicianname = dtRowTech["Technician"] != DBNull.Value ? Convert.ToString(dtRowTech["Technician"]) : null; //$getRemoteData['tech_man']["Technician"];
                        TechnicianMobile = dtRowTech["Mobile"] != DBNull.Value ? Convert.ToString(dtRowTech["Mobile"]) : null; //$getRemoteData['tech_man']["Mobile"];
                    }
                }

                blnSuccess = true;


                blnJobDoneSuccess = UpdateJobDoneDataMySQL(AppDownload, AppAlreadyIns, NotPhone, jobno, Technicianname, TechnicianMobile, CustomerName, CustomerMobileNo);
                blnJobDoneTableSuccess = UpdateJobDoneTableDataMySQL(objJob_DoneRQ.order_id, objJob_DoneRQ.tech_id, objJob_DoneRQ.ipAddress, jobno, Technicianname, objJob_DoneRQ.imei);

                if (blnJobDoneSuccess && blnJobDoneTableSuccess)
                {
                    objJobDoneRS.success = 1;
                    objJobDoneRS.success_msg = "Successfully Job Done by Technician";
                }
                else
                {
                    objJobDoneRS.success = 0;
                    objJobDoneRS.success_msg = "Some Error Occure, Please Contact Admin";
                }

            }
            catch (Exception ex)
            {
                objJobDoneRS = new Job_DoneRS();
                objJobDoneRS.success = 0;
                objJobDoneRS.success_msg = "Some Error Occure, Please Contact Admin";
                CommonService.WriteErrorLog(ex);
            }

            return objJobDoneRS;

        }


        public bool UpdateJobDoneDataMySQL(string AppDownload, string AppAlreadyIns, string NotPhone, string jobno, string Technicianname, string TechnicianMobile, string CustomerName, string CustomerMobileNo)
        {

            bool bln_job_done_update_successfuly = false;

            objBaseMySQLDAL = new BaseMySQLDAL();


            try
            {
                strQuery = @"INSERT INTO job_done (AppDownload, AppAlreadyIns, NotPhone, JobNo, Technician, TechnicianMobile, CustomerName, CustomerMobileNo) 
                                        VALUES (@AppDownload, @AppAlreadyIns, @NotPhone, @jobno, @Technicianname, @TechnicianMobile, @CustomerName, @CustomerMobileNo)";



                lstMySQLParam = new List<MySqlParameter>();

                lstMySQLParam.AddRange(new MySqlParameter[]
                      {
                                new MySqlParameter("@AppDownload", AppDownload),
                                new MySqlParameter("@AppAlreadyIns", AppAlreadyIns),
                                new MySqlParameter("@NotPhone", NotPhone),
                                new MySqlParameter("@jobno", jobno),
                                new MySqlParameter("@Technicianname", Technicianname),
                                new MySqlParameter("@TechnicianMobile", TechnicianMobile),
                                new MySqlParameter("@CustomerName", CustomerName),
                                new MySqlParameter("@CustomerMobileNo", CustomerMobileNo),
                      });

                objBaseMySQLDAL.ExeccuteStoreCommand(strQuery, CommandType.Text, lstMySQLParam);

                bln_job_done_update_successfuly = true;

            }
            catch (Exception ex)
            {
                bln_job_done_update_successfuly = false;
                CommonService.WriteErrorLog(ex);
            }

            return bln_job_done_update_successfuly;
        }

        public bool UpdateJobDoneTableDataMySQL(string order_id, string tech_id, string ipAddress, string jobno, string technician, string imei)
        {
            bool bln_job_done_table_update_successfuly = false;


            try
            {
                using (var connection = new MySqlConnection("Datasource=148.72.232.171; Database=keservic_ketan2015; uid=keservic_db; pwd=2lw99iW*;"))
                {
                    var query = @"INSERT INTO Job_done_table (oid, tech_id, date, ipAddress, jobno, technician, imei) 
                                            VALUES (@order_id, @tech_id, @modifydate, @ipAddress, @jobno, @technician, @imei)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        connection.Open();

                        lstMySQLParam = new List<MySqlParameter>();

                        lstMySQLParam.AddRange(new MySqlParameter[]
                             {
                                new MySqlParameter("@order_id", order_id),
                                new MySqlParameter("@tech_id", tech_id),
                                new MySqlParameter("@modifydate", DateTime.Now),
                                new MySqlParameter("@ipAddress", ipAddress),
                                new MySqlParameter("@jobno", jobno),
                                new MySqlParameter("@technician", technician),
                                new MySqlParameter("@imei", imei),
                             });

                        command.Parameters.AddRange(lstMySQLParam.ToArray());

                        command.ExecuteNonQuery();
                    }
                }

                bln_job_done_table_update_successfuly = true;
            }
            catch (Exception ex)
            {
                bln_job_done_table_update_successfuly = false;
                CommonService.WriteErrorLog(ex);
            }

            return bln_job_done_table_update_successfuly;
        }

        #endregion

        #region Insert Exits Product

        public Add_Exis_ProductRS Add_Exis_Productspsr(Add_Exis_ProductRQ objAddExisProductRQ)
        {
            objBaseMySQLDAL = new BaseMySQLDAL();

            Add_Exis_ProductRS objAddExisProductRS = new Add_Exis_ProductRS();

            try
            {
                strQuery = @"INSERT INTO exits_products (customer_name, customer_mno, product_name, product_exi, test_name, test_mno, Date, Time) VALUES (@customer_name, @customer_mno, @product_name, '1', @t_name, @t_mno, @date, @time);";

                lstMySQLParam = new List<MySqlParameter>();



                lstMySQLParam.AddRange(new MySqlParameter[]
                    {
                                new MySqlParameter("@customer_name", objAddExisProductRQ.customer_name),
                                new MySqlParameter("@customer_mno", objAddExisProductRQ.customer_mno),
                                new MySqlParameter("@product_name", objAddExisProductRQ.product_name),
                                new MySqlParameter("@t_name", objAddExisProductRQ.t_name),
                                new MySqlParameter("@t_mno", objAddExisProductRQ.t_mno),
                                new MySqlParameter("@date", DateTime.Now),
                                new MySqlParameter("@time", DateTime.Now),

                    });

                objBaseMySQLDAL.ExeccuteStoreCommand(strQuery, CommandType.Text, lstMySQLParam);

                objAddExisProductRS.success = 1;
                objAddExisProductRS.success_msg = "Product Add Successfuly";

            }
            catch (Exception ex)
            {
                objAddExisProductRS = new Add_Exis_ProductRS();
                objAddExisProductRS.success = 1;
                objAddExisProductRS.success_msg = "Fail To Add Product";
                CommonService.WriteErrorLog(ex);
            }

            return objAddExisProductRS;
        }

        #endregion

        #region Insert avail product

        public Add_Avail_ProductRS Add_Avail_ProductSprs(Add_Avail_ProductRQ objAddAvailProductRQ)
        {

            objBaseMySQLDAL = new BaseMySQLDAL();

            Add_Avail_ProductRS objAddAvailProductRS = new Add_Avail_ProductRS();

            try
            {
                //strQuery = @"INSERT INTO exits_products (customer_name, customer_mno, product_name, product_exi, test_name, test_mno, Date, Time) VALUES (@customer_name, @customer_mno, @product_name, '1', @t_name, @t_mno, @date, @time);";
                strQuery = @"INSERT INTO available_products ( customer_name, customer_mno, product_name, company_name, test_name, test_mno, Date, Time) 
                                                            VALUES (@customer_name, @customer_mno, @product_name, @company_name, @t_name, @t_mno, @date, @time);";

                lstMySQLParam = new List<MySqlParameter>();



                lstMySQLParam.AddRange(new MySqlParameter[]
                    {
                                new MySqlParameter("@customer_name", objAddAvailProductRQ.customer_name),
                                new MySqlParameter("@customer_mno", objAddAvailProductRQ.customer_mno),
                                new MySqlParameter("@product_name", objAddAvailProductRQ.product_name),
                                new MySqlParameter("@company_name", objAddAvailProductRQ.company_name),
                                new MySqlParameter("@t_name", objAddAvailProductRQ.t_name),
                                new MySqlParameter("@t_mno", objAddAvailProductRQ.t_mno),
                                new MySqlParameter("@date", DateTime.Now),
                                new MySqlParameter("@time", DateTime.Now),

                    });

                objBaseMySQLDAL.ExeccuteStoreCommand(strQuery, CommandType.Text, lstMySQLParam);

                objAddAvailProductRS.success = 1;
                objAddAvailProductRS.success_msg = "Product Add Successfuly";

            }
            catch (Exception ex)
            {
                objAddAvailProductRS = new Add_Avail_ProductRS();
                objAddAvailProductRS.success = 0;
                objAddAvailProductRS.success_msg = "Fail To Add Product";
                CommonService.WriteErrorLog(ex);
            }


            return objAddAvailProductRS;



        }

        #endregion

        #region Service List
        public Service_ListRS Service_List()
        {
            Service_ListRS objServiceListRS = new Service_ListRS();

            objBaseMySQLDAL = new BaseMySQLDAL();

            List<Service_Item> lstServiceItem = new List<Service_Item>();

            try
            {
                strQuery = @"SELECT service_id,service_name,service_img FROM main_services ORDER BY service_id ASC";

                lstMySQLParam = new List<MySqlParameter>();



                DataTable ResData = objBaseMySQLDAL.GetResultDataTable(strQuery, CommandType.Text, lstMySQLParam);

                if (ResData.Rows.Count > 0)
                {
                    /*
                    DataRow dtRow = ResData.Rows[0];

                    strCustomerCode = dtRow["cust_code"] != DBNull.Value ? Convert.ToString(dtRow["cust_code"]) : string.Empty;
                    intRid = dtRow["rid"] != DBNull.Value ? Convert.ToInt32(dtRow["rid"]) : 0;
                    blnCustCodeMatch = !string.IsNullOrEmpty(strCustomerCode) ? true : false;
                    */
                    foreach (DataRow dr in ResData.Rows)
                    {
                        Service_Item objServiceItem = new Service_Item();
                        objServiceItem.service_id = dr["service_id"] != DBNull.Value ? Convert.ToString(dr["service_id"]) : string.Empty;
                        objServiceItem.service_name = dr["service_name"] != DBNull.Value ? Convert.ToString(dr["service_name"]) : string.Empty;
                        objServiceItem.service_img = dr["service_img"] != DBNull.Value ? Convert.ToString(dr["service_img"]) : string.Empty;

                        lstServiceItem.Add(objServiceItem);

                    }

                    objServiceListRS.success = 1;
                    objServiceListRS.data = lstServiceItem;

                }


            }
            catch (Exception ex)
            {
                objServiceListRS = new Service_ListRS();
                objServiceListRS.success = 0;
                objServiceListRS.data = new List<Service_Item>();
                CommonService.WriteErrorLog(ex);

            }



            return objServiceListRS;


        }

        #endregion

        #region Exchange Service

        public Exchange_ServiceRS Exchange_Service(Exchange_ServiceRQ objExchangeServiceRQ)
        {

            objBaseMySQLDAL = new BaseMySQLDAL();

            Exchange_ServiceRS objExchangeServiceRS = new Exchange_ServiceRS();

            try
            {
                strQuery = @"INSERT INTO exchange_product_tbl (customer_name, customer_mno, id, Date, Time, t_name, t_mno, Interested) 
                                                VALUES (@customer_name, @customer_mno, @id, @date, @time, @t_name, @t_mno, '1');";

                lstMySQLParam = new List<MySqlParameter>();



                lstMySQLParam.AddRange(new MySqlParameter[]
                    {
                                new MySqlParameter("@customer_name", objExchangeServiceRQ.customer_name),
                                new MySqlParameter("@customer_mno", objExchangeServiceRQ.customer_mno),
                                new MySqlParameter("@id", objExchangeServiceRQ.id),
                                new MySqlParameter("@t_name", objExchangeServiceRQ.t_name),
                                new MySqlParameter("@t_mno", objExchangeServiceRQ.t_mno),
                                new MySqlParameter("@date", DateTime.Now),
                                new MySqlParameter("@time", DateTime.Now),

                    });

                objBaseMySQLDAL.ExeccuteStoreCommand(strQuery, CommandType.Text, lstMySQLParam);

                objExchangeServiceRS.success = 1;
                objExchangeServiceRS.success_msg = "Exchange Product Add Successfuly";

            }
            catch (Exception ex)
            {
                objExchangeServiceRS = new Exchange_ServiceRS();
                objExchangeServiceRS.success = 0;
                objExchangeServiceRS.success_msg = "Fail To Add Exchange Product";
                CommonService.WriteErrorLog(ex);
            }


            return objExchangeServiceRS;



        }

        #endregion

        #region Installation Image
        public Installation_ImgRS Installation_Img(Installation_ImgRQ objInstallationImgRQ)
        {
            int InstalltionId = 0;

            objBaseMySQLDAL = new BaseMySQLDAL();

            Installation_ImgRS objInstallationImgRS = new Installation_ImgRS();

            string strImstallationImage = !string.IsNullOrEmpty(objInstallationImgRQ.img_missing) && objInstallationImgRQ.img_missing == "1" ? "No Image" :  objInstallationImgRQ.image;

            try
            {
                strQuery = @"Image_Send";

                lstMySQLParam = new List<MySqlParameter>();

                lstMySQLParam.AddRange(new MySqlParameter[]
                    {
                                new MySqlParameter("@job_id", objInstallationImgRQ.job_id),
                                new MySqlParameter("@customer_name", objInstallationImgRQ.customer_name),
                                new MySqlParameter("@customer_number", objInstallationImgRQ.customer_number),
                                new MySqlParameter("@image_base64", strImstallationImage),
                                new MySqlParameter("@technician_name", objInstallationImgRQ.technician_name),
                                new MySqlParameter("@technician_no", objInstallationImgRQ.technician_no),
                                new MySqlParameter("@location", objInstallationImgRQ.location),
                                new MySqlParameter("@serviceType", objInstallationImgRQ.serviceType),
                                new MySqlParameter("@create_date", DateTime.Now),
                                new MySqlParameter("@create_time", DateTime.Now),

                    });

                DataTable ResData = objBaseMySQLDAL.GetResultDataTable(strQuery, CommandType.StoredProcedure, lstMySQLParam);

                if (ResData.Rows.Count > 0)
                {
                    DataRow dtRow = ResData.Rows[0];

                    InstalltionId = dtRow["id"] != DBNull.Value ? Convert.ToInt32(dtRow["id"]) : 0;

                }

                if (InstalltionId > 0)
                {
                    objInstallationImgRS.success = 1;
                    objInstallationImgRS.success_msg = "Successfully Added Installations";
                }
                else
                {
                    objInstallationImgRS.success = 0;
                    objInstallationImgRS.success_msg = "Fail To Add Installations";
                }

            }
            catch (Exception ex)
            {
                objInstallationImgRS = new Installation_ImgRS();
                objInstallationImgRS.success = 0;
                objInstallationImgRS.success_msg = "Fail To Add Installations";
                CommonService.WriteErrorLog(ex);
            }

            return objInstallationImgRS;
        }

        #endregion

        #region Add Expence
        public Add_ExpenseRS Add_Expense(Add_ExpenseRQ objAddExpenseRQ)
        {
            int InstalltionId = 0;

            objBaseMySQLDAL = new BaseMySQLDAL();

            Dictionary<string, string> dictExpence = new Dictionary<string, string>();

            Add_ExpenseRS objAddExpenseRS = new Add_ExpenseRS();

            try
            {

                if (!string.IsNullOrEmpty(objAddExpenseRQ.type) && !string.IsNullOrEmpty(objAddExpenseRQ.amount))
                {
                    string[] aryExpenceType = objAddExpenseRQ.type.Split(',');
                    string[] aryExpenceAmount = objAddExpenseRQ.amount.Split(',');


                    for (int i = 0; i < aryExpenceType.Length; i++)
                    {
                        dictExpence.Add(aryExpenceType[i], aryExpenceAmount[i]);
                    }


                }

                strQuery = @"INSERT INTO expense (techid, type, amount, date) VALUES (@techid, @expence_type, @expence_amount, @date);";

                foreach (var expenceItem in dictExpence)
                {
                    lstMySQLParam = new List<MySqlParameter>();

                    lstMySQLParam.AddRange(new MySqlParameter[]
                        {
                                new MySqlParameter("@techid", objAddExpenseRQ.techid),
                                new MySqlParameter("@expence_type", expenceItem.Key),
                                new MySqlParameter("@expence_amount", expenceItem.Value),
                                new MySqlParameter("@date", DateTime.Now),

                        });

                    objBaseMySQLDAL.ExeccuteStoreCommand(strQuery, CommandType.Text, lstMySQLParam);

                }

                objAddExpenseRS.success = 1;
                objAddExpenseRS.success_msg = "Successfully Added Expence";


            }
            catch (Exception ex)
            {
                objAddExpenseRS = new Add_ExpenseRS();
                objAddExpenseRS.success = 0;
                objAddExpenseRS.success_msg = "Fail To Add Expence";
                CommonService.WriteErrorLog(ex);
            }

            return objAddExpenseRS;
        }

        #endregion

        #region Attendance

        public AttadenceRS Attendance(AttadenceRQ objAttadenceRQ)
        {

            objBaseMySQLDAL = new BaseMySQLDAL();

            AttadenceRS objAttadenceRS = new AttadenceRS();

            string TechnicianRole = string.Empty, TechnicianApiKey = string.Empty;

            bool blnTehcnicianStartDay = false, blnTehcnicianEndDay = false;

            bool blnLunchStart = false;
            bool blnLunchEnd = false;
            bool blnEndDay = false;
            bool blnTechnicianAbsent = false;
            bool blnTechnicianTraining = false;

            string ErrorMessage = string.Empty;

            try
            {

                strQuery = @"SELECT apikey,role,name,mobile FROM `dbo.users` where mobile = @tech_mno";

                lstMySQLParam = new List<MySqlParameter>();

                lstMySQLParam.AddRange(new MySqlParameter[]
                    {
                                new MySqlParameter("@tech_mno", objAttadenceRQ.tech_mno)
                    });

                DataTable ResData = objBaseMySQLDAL.GetResultDataTable(strQuery, CommandType.Text, lstMySQLParam);

                if (ResData != null && ResData.Rows.Count > 0)
                {
                    DataRow dtRow = ResData.Rows[0];

                    TechnicianRole = dtRow["role"] != DBNull.Value ? Convert.ToString(dtRow["role"]) : string.Empty;
                    TechnicianApiKey = dtRow["apikey"] != DBNull.Value ? Convert.ToString(dtRow["apikey"]) : string.Empty;
                }
                else
                {
                    TechnicianRole = "Services staff / Technician";
                    TechnicianApiKey = "SERVICE";
                }

                /*
                $day=$row["start_day"];
	            $lunch_start_day=$row["lunch_start"];
	            $lunch_end_day=$row["lunch_end"];
	            $end_day=$row["end"];
	            $testap=$row["test_a"];
	            $testtranning=$row["test_tranning"];

                 */

                AttendanceData objTechnicianAttendanceData = new AttendanceData();
                    


                if(objAttadenceRQ.start_day == "1") // Day Start
                {
                    objTechnicianAttendanceData = GetTechnicianDayStartDetail(objAttadenceRQ.tech_mno);

                    if (objTechnicianAttendanceData != null && objTechnicianAttendanceData.start_day == 1)
                    {
                        blnTehcnicianStartDay = true;
                    }
                    else
                    {
                        int start_day = 0;
                        int.TryParse(objAttadenceRQ.start_day, out start_day);

                        int tech_present = 0;
                        int.TryParse(objAttadenceRQ.tech_present, out tech_present);

                        int tech_absent = 0;
                        //int.TryParse(objAttadenceRQ.tech_absent, out tech_absent);

                        int tech_tranning = 0;
                        //int.TryParse(objAttadenceRQ.tech_tranning, out tech_tranning);

                        blnTehcnicianStartDay = TechnicianDayStart(objAttadenceRQ.tech_name, objAttadenceRQ.tech_mno, start_day, tech_present, objAttadenceRQ.tech_img, objAttadenceRQ.present_location, tech_absent, objAttadenceRQ.absent_reason, tech_tranning, objAttadenceRQ.location, TechnicianRole);
                    }

                }

                if(objAttadenceRQ.endday == "1") // Day End
                {
                    objTechnicianAttendanceData = GetTechnicianDayStartDetail(objAttadenceRQ.tech_mno);

                    if (objTechnicianAttendanceData != null && objTechnicianAttendanceData.start_day == 1)
                    {
                        blnTehcnicianStartDay = true;

                        blnTehcnicianEndDay = TechnicianDayEnd(objTechnicianAttendanceData.attendance_id, Convert.ToInt32(objAttadenceRQ.endday), objAttadenceRQ.endday_location);

                    }
                    else
                    {
                        ErrorMessage = "You havent't started your day, Please start you day in sytem";
                    }

                }

                if(objAttadenceRQ.start_lunch == "1") // lunch break start
                {
                    objTechnicianAttendanceData = GetTechnicianDayStartDetail(objAttadenceRQ.tech_mno);

                    if (objTechnicianAttendanceData != null && objTechnicianAttendanceData.start_day == 1)
                    {
                        blnTehcnicianStartDay = true;
                        TechnicianLunchStart(objTechnicianAttendanceData.attendance_id, Convert.ToInt32(objAttadenceRQ.start_lunch), objAttadenceRQ.start_lunch_location);
                    }
                    else
                    {
                        int start_day = 0;
                        //int.TryParse(objAttadenceRQ.start_day, out start_day);

                        int tech_present = 1;
                        //int.TryParse(objAttadenceRQ.tech_present, out tech_present);

                        int tech_absent = 0;
                        //int.TryParse(objAttadenceRQ.tech_absent, out tech_absent);

                        int tech_tranning = 0;
                        //int.TryParse(objAttadenceRQ.tech_tranning, out tech_tranning);

                        blnTehcnicianStartDay = TechnicianDayStart(objAttadenceRQ.tech_name, objAttadenceRQ.tech_mno, start_day, tech_present, objAttadenceRQ.tech_img, objAttadenceRQ.present_location, tech_absent, objAttadenceRQ.absent_reason, tech_tranning, objAttadenceRQ.location, TechnicianRole);
                        
                        objTechnicianAttendanceData = GetTechnicianDayStartDetail(objAttadenceRQ.tech_mno);

                        TechnicianLunchStart(objTechnicianAttendanceData.attendance_id, Convert.ToInt32(objAttadenceRQ.start_lunch), objAttadenceRQ.start_lunch_location);
                    }

                }


                if (objAttadenceRQ.end_lunch == "1") // lunch break end
                {

                    objTechnicianAttendanceData = GetTechnicianDayStartDetail(objAttadenceRQ.tech_mno);

                    if (objTechnicianAttendanceData != null && objTechnicianAttendanceData.start_day == 1)
                    {
                        blnTehcnicianStartDay = true;
                        TechnicianLunchStart(objTechnicianAttendanceData.attendance_id, Convert.ToInt32(objAttadenceRQ.start_lunch), objAttadenceRQ.start_lunch_location);
                    }
                    else
                    {
                        /*
                        int start_day = 0;
                        int.TryParse(objAttadenceRQ.start_day, out start_day);

                        int tech_present = 0;
                        int.TryParse(objAttadenceRQ.tech_present, out tech_present);

                        int tech_absent = 0;
                        //int.TryParse(objAttadenceRQ.tech_absent, out tech_absent);

                        int tech_tranning = 0;
                        //int.TryParse(objAttadenceRQ.tech_tranning, out tech_tranning);

                        blnTehcnicianStartDay = TechnicianDayStart(objAttadenceRQ.tech_name, objAttadenceRQ.tech_mno, start_day, tech_present, objAttadenceRQ.tech_img, objAttadenceRQ.present_location, tech_absent, objAttadenceRQ.absent_reason, tech_tranning, objAttadenceRQ.location, TechnicianRole);
                        */
                        objTechnicianAttendanceData = GetTechnicianDayStartDetail(objAttadenceRQ.tech_mno);

                        //TechnicianLunchStart(objTechnicianAttendanceData.attendance_id, Convert.ToInt32(objAttadenceRQ.start_lunch), objAttadenceRQ.start_lunch_location);

                        if(objTechnicianAttendanceData != null && objTechnicianAttendanceData.lunch_start == 1)
                        {
                            TechnicianLunchEnd(objTechnicianAttendanceData.attendance_id, Convert.ToInt32(objAttadenceRQ.end_lunch), objAttadenceRQ.end_lunch_location);
                        }
                        else
                        {
                            ErrorMessage = "You havent't started your lunch time, Please start you lunch time in sytem";
                        }

                    }

                }


                if (objAttadenceRQ.tech_absent == "1") // Absent 
                {
                    objTechnicianAttendanceData = GetTechnicianDayStartDetail(objAttadenceRQ.tech_mno);

                    if(objTechnicianAttendanceData != null && objTechnicianAttendanceData.start_day == 1) 
                    {
                        TechnicianAbsent(objTechnicianAttendanceData.attendance_id, Convert.ToInt32(objAttadenceRQ.tech_absent), objAttadenceRQ.absent_reason, true);
                    }
                    else
                    {
                        TechnicianAbsent(objTechnicianAttendanceData.attendance_id, Convert.ToInt32(objAttadenceRQ.tech_absent), objAttadenceRQ.absent_reason, false, objAttadenceRQ.tech_name, objAttadenceRQ.tech_mno, TechnicianRole);
                    }

                }


                if(objAttadenceRQ.tech_tranning == "1") // Training
                {

                    objTechnicianAttendanceData = GetTechnicianDayStartDetail(objAttadenceRQ.tech_mno);

                    if (objTechnicianAttendanceData != null && objTechnicianAttendanceData.start_day == 1)
                    {
                        TechnicianTraining(objTechnicianAttendanceData.attendance_id, Convert.ToInt32(objAttadenceRQ.tech_tranning), objAttadenceRQ.location, true);
                    }
                    else
                    {
                        TechnicianTraining(objTechnicianAttendanceData.attendance_id, Convert.ToInt32(objAttadenceRQ.tech_tranning), objAttadenceRQ.location, false, objAttadenceRQ.tech_name, objAttadenceRQ.tech_mno, TechnicianRole);
                    }

                }



                objAttadenceRS.success = 1;
                objAttadenceRS.success_msg = "Successfully Added Expence";


            }
            catch (Exception ex)
            {
                objAttadenceRS = new AttadenceRS();
                objAttadenceRS.success = 0;
                objAttadenceRS.success_msg = "Fail To Add Expence";
                CommonService.WriteErrorLog(ex);
            }

            return objAttadenceRS;
        }


        public bool TechnicianDayStart(string technician_name, string technician_mno, int start_day, int technician_present, string technician_img, string present_location, int technician_absent, string absent_reason, int technician_tranning, string location, string technician_role)
        {
            int LastInsertedId = 0;

            objBaseMySQLDAL = new BaseMySQLDAL();

            bool blnTechnicianDaystarted = false;

            try
            {

                strQuery = @"INSERT INTO attendance_tbl (technician_name, technician_mno,start_day,technician_present, technician_img,present_location, technician_absent, absent_reason, technician_tranning, location, date, time, role ) 
                                    VALUES (@technician_name, @technician_mno, @start_day, @technician_present, @technician_img, @present_location, @technician_absent, @absent_reason, @technician_tranning, @location, @date, @time, @role)";

                lstMySQLParam = new List<MySqlParameter>();

                lstMySQLParam.AddRange(new MySqlParameter[]
                    {

                                new MySqlParameter("@technician_name", technician_name),
                                new MySqlParameter("@technician_mno", technician_mno),
                                new MySqlParameter("@start_day", start_day),
                                new MySqlParameter("@technician_present", technician_present),
                                new MySqlParameter("@technician_img", technician_img),
                                new MySqlParameter("@present_location", present_location),
                                new MySqlParameter("@technician_absent", technician_absent),
                                new MySqlParameter("@absent_reason", absent_reason),
                                new MySqlParameter("@technician_tranning", technician_tranning),
                                new MySqlParameter("@location", location),
                                new MySqlParameter("@date",  DateTime.Now),
                                new MySqlParameter("@time", DateTime.Now),
                                new MySqlParameter("@role", technician_role),


                    });

                LastInsertedId = objBaseMySQLDAL.ExeccuteStoreCommand(strQuery, CommandType.Text, lstMySQLParam, true);

                if (LastInsertedId > 0)
                {
                    blnTechnicianDaystarted = true;
                }
                else
                {
                    blnTechnicianDaystarted = false;
                }

            }
            catch (Exception ex)
            {
                blnTechnicianDaystarted = false;
                CommonService.WriteErrorLog(ex);
            }

            return blnTechnicianDaystarted;
        }

        public AttendanceData GetTechnicianDayStartDetail(string technician_Mobil_No)
        {
            AttendanceData objAttendanceData = new AttendanceData();

            objBaseMySQLDAL = new BaseMySQLDAL();

            try
            {

                strQuery = @"SELECT * from attendance_tbl WHERE technician_mno = @technician_mno AND start_day = 1;";

                lstMySQLParam = new List<MySqlParameter>();

                lstMySQLParam.AddRange(new MySqlParameter[]
                    {
                          new MySqlParameter("@technician_name", technician_Mobil_No)
                    });

                DataTable ResTable = objBaseMySQLDAL.GetResultDataTable(strQuery, CommandType.Text, lstMySQLParam);



                if (ResTable != null && ResTable.Rows.Count > 0)
                {
                    DataRow dtRow = ResTable.Rows[0];

                    objAttendanceData.attendance_id = dtRow["attendance_id"] != DBNull.Value ? Convert.ToInt32(dtRow["attendance_id"]) : 0;
                    objAttendanceData.technician_name = dtRow["technician_name"] != DBNull.Value ? Convert.ToString(dtRow["technician_name"]) : string.Empty;
                    objAttendanceData.technician_mno = dtRow["technician_mno"] != DBNull.Value ? Convert.ToString(dtRow["technician_mno"]) : string.Empty;
                    objAttendanceData.technician_present = dtRow["technician_present"] != DBNull.Value ? Convert.ToInt32(dtRow["technician_present"]) : 0;
                    objAttendanceData.start_day = dtRow["start_day"] != DBNull.Value ? Convert.ToInt32(dtRow["start_day"]) : 0;
                    objAttendanceData.technician_img = dtRow["technician_img"] != DBNull.Value ? Convert.ToString(dtRow["technician_img"]) : string.Empty;
                    objAttendanceData.present_location = dtRow["present_location"] != DBNull.Value ? Convert.ToString(dtRow["present_location"]) : string.Empty;
                    objAttendanceData.technician_absent = dtRow["technician_absent"] != DBNull.Value ? Convert.ToInt32(dtRow["technician_absent"]) : 0;
                    objAttendanceData.absent_reason = dtRow["absent_reason"] != DBNull.Value ? Convert.ToString(dtRow["absent_reason"]) : string.Empty;
                    objAttendanceData.absent_time = dtRow["absent_time"] != DBNull.Value ? Convert.ToString(dtRow["absent_time"]) : string.Empty;
                    objAttendanceData.technician_tranning = dtRow["technician_tranning"] != DBNull.Value ? Convert.ToInt32(dtRow["technician_tranning"]) : 0;
                    objAttendanceData.location = dtRow["location"] != DBNull.Value ? Convert.ToString(dtRow["location"]) : string.Empty;
                    objAttendanceData.attendance_date = dtRow["attendance_date"] != DBNull.Value ? Convert.ToString(dtRow["attendance_date"]) : string.Empty;
                    objAttendanceData.attendance_time = dtRow["attendance_time"] != DBNull.Value ? Convert.ToString(dtRow["attendance_time"]) : string.Empty;
                    objAttendanceData.lunch_start = dtRow["lunch_start"] != DBNull.Value ? Convert.ToInt32(dtRow["lunch_start"]) : 0;
                    objAttendanceData.lunch_img = dtRow["lunch_img"] != DBNull.Value ? Convert.ToString(dtRow["lunch_img"]) : string.Empty;
                    objAttendanceData.lunch_starttime = dtRow["lunch_starttime"] != DBNull.Value ? Convert.ToString(dtRow["lunch_starttime"]) : string.Empty;
                    objAttendanceData.lunch_start_location = dtRow["lunch_start_location"] != DBNull.Value ? Convert.ToString(dtRow["lunch_start_location"]) : string.Empty;
                    objAttendanceData.lunch_end = dtRow["lunch_end"] != DBNull.Value ? Convert.ToInt32(dtRow["lunch_end"]) : 0;
                    objAttendanceData.lunch_endimg = dtRow["lunch_endimg"] != DBNull.Value ? Convert.ToString(dtRow["lunch_endimg"]) : string.Empty;
                    objAttendanceData.lunch_endtime = dtRow["lunch_endtime"] != DBNull.Value ? Convert.ToString(dtRow["lunch_endtime"]) : string.Empty;
                    objAttendanceData.lunch_end_location = dtRow["lunch_end_location"] != DBNull.Value ? Convert.ToString(dtRow["lunch_end_location"]) : string.Empty;
                    objAttendanceData.end = dtRow["end"] != DBNull.Value ? Convert.ToInt32(dtRow["end"]) : 0;
                    objAttendanceData.end_img = dtRow["end_img"] != DBNull.Value ? Convert.ToString(dtRow["end_img"]) : string.Empty;
                    objAttendanceData.endtime = dtRow["endtime"] != DBNull.Value ? Convert.ToString(dtRow["endtime"]) : string.Empty;
                    objAttendanceData.end_day_location = dtRow["end_day_location"] != DBNull.Value ? Convert.ToString(dtRow["end_day_location"]) : string.Empty;
                    objAttendanceData.locationde = dtRow["locationde"] != DBNull.Value ? Convert.ToString(dtRow["locationde"]) : string.Empty;
                    objAttendanceData.role = dtRow["role"] != DBNull.Value ? Convert.ToString(dtRow["role"]) : string.Empty;
                }

            }
            catch (Exception ex)
            {
                objAttendanceData = new AttendanceData();
                CommonService.WriteErrorLog(ex);
            }

            return objAttendanceData;
        }

        public bool TechnicianDayEnd(int attendance_id, int end_day, string end_day_location)
        {
            objBaseMySQLDAL = new BaseMySQLDAL();

            bool blnTechnicianDayEnded = false;

            try
            {

                strQuery = @"UPDATE attendance_tbl SET `end` = @end_day, endtime = @endtime, end_day_location = @end_day_location WHERE attendance_id = @attendance_id";

                lstMySQLParam = new List<MySqlParameter>();

                lstMySQLParam.AddRange(new MySqlParameter[]
                    {

                                new MySqlParameter("@end", end_day),
                                new MySqlParameter("@endtime", DateTime.Now),
                                new MySqlParameter("@end_day_location", end_day_location),
                                new MySqlParameter("@attendance_id", attendance_id),
                    });

                objBaseMySQLDAL.ExeccuteStoreCommand(strQuery, CommandType.Text, lstMySQLParam);


                blnTechnicianDayEnded = true;


            }
            catch (Exception ex)
            {
                blnTechnicianDayEnded = false;
                CommonService.WriteErrorLog(ex);
            }

            return blnTechnicianDayEnded;

        }

        public bool TechnicianLunchStart(int attendance_id, int lunch_start, string lunch_start_location)
        {
            objBaseMySQLDAL = new BaseMySQLDAL();

            bool blnTechnicianStartLunch = false;

            try
            {
                // DB Side lunch_start,  lunch_starttime , lunch_start_location

                strQuery = @"UPDATE attendance_tbl SET lunch_start = @lunch_start, lunch_starttime = @lunch_starttime, lunch_start_location = @lunch_start_location WHERE attendance_id = @attendance_id";

                lstMySQLParam = new List<MySqlParameter>();

                lstMySQLParam.AddRange(new MySqlParameter[]
                    {

                                new MySqlParameter("@lunch_start", lunch_start),
                                new MySqlParameter("@lunch_starttime", DateTime.Now),
                                new MySqlParameter("@lunch_start_location", lunch_start_location),
                                new MySqlParameter("@attendance_id", attendance_id),
                    });

                objBaseMySQLDAL.ExeccuteStoreCommand(strQuery, CommandType.Text, lstMySQLParam);


                blnTechnicianStartLunch = true;


            }
            catch (Exception ex)
            {
                blnTechnicianStartLunch = false;
                CommonService.WriteErrorLog(ex);
            }

            return blnTechnicianStartLunch;

        }

        public bool TechnicianLunchEnd(int attendance_id, int lunch_end, string lunch_end_location)
        {
            objBaseMySQLDAL = new BaseMySQLDAL();

            bool blnTechnicianEndLunch = false;

            try
            {
                // DB Side lunch_start,  lunch_starttime , lunch_start_location

                strQuery = @"UPDATE attendance_tbl SET lunch_end = @lunch_end, lunch_endtime = @lunch_endtime, lunch_end_location = @lunch_end_location WHERE attendance_id = @attendance_id";

                lstMySQLParam = new List<MySqlParameter>();

                lstMySQLParam.AddRange(new MySqlParameter[]
                    {

                                new MySqlParameter("@lunch_end", lunch_end),
                                new MySqlParameter("@lunch_endtime", DateTime.Now),
                                new MySqlParameter("@lunch_end_location", lunch_end_location),
                                new MySqlParameter("@attendance_id", attendance_id),
                    });

                objBaseMySQLDAL.ExeccuteStoreCommand(strQuery, CommandType.Text, lstMySQLParam);


                blnTechnicianEndLunch = true;


            }
            catch (Exception ex)
            {
                blnTechnicianEndLunch = false;
                CommonService.WriteErrorLog(ex);
            }

            return blnTechnicianEndLunch;

        }

        public bool TechnicianAbsent(int attendance_id, int technician_absent, string absent_reason, bool IsDayStarted = true, string technician_name = "", string technician_mno = "", string technician_role = "")
        {
            objBaseMySQLDAL = new BaseMySQLDAL();

            bool blnTechnicianAbsent = false;

            try
            {

                if(IsDayStarted)
                {
                    strQuery = @"UPDATE attendance_tbl SET technician_absent = @technician_absent, absent_reason = @absent_reason, absent_time = @absent_time WHERE attendance_id = @attendance_id";

                    lstMySQLParam = new List<MySqlParameter>();

                    lstMySQLParam.AddRange(new MySqlParameter[]
                        {

                                new MySqlParameter("@technician_absent", technician_absent),
                                new MySqlParameter("@absent_time", DateTime.Now),
                                new MySqlParameter("@absent_reason", absent_reason),
                                new MySqlParameter("@attendance_id", attendance_id),
                        });
                }
                else
                {
                    strQuery = @"INSERT INTO attendance_tbl (technician_name, technician_mno, technician_present, start_day, technician_absent, absent_reason, absent_time, role)
                                                VALUES(@technician_name, @technician_mno, @technician_present, @start_day, @technician_absent, @absent_reason, @absent_time, @role)";

                    lstMySQLParam = new List<MySqlParameter>();

                    lstMySQLParam.AddRange(new MySqlParameter[]
                        {

                                new MySqlParameter("@technician_name", technician_name),
                                new MySqlParameter("@technician_mno", technician_mno),
                                new MySqlParameter("@technician_present", 0),
                                new MySqlParameter("@start_day", 0),
                                new MySqlParameter("@technician_absent", technician_absent),
                                new MySqlParameter("@absent_reason", absent_reason),
                                new MySqlParameter("@absent_time", DateTime.Now),
                                new MySqlParameter("@role", technician_role)
                        });
                }
                // DB Side lunch_start,  lunch_starttime , lunch_start_location

                

                

                objBaseMySQLDAL.ExeccuteStoreCommand(strQuery, CommandType.Text, lstMySQLParam);


                blnTechnicianAbsent = true;


            }
            catch (Exception ex)
            {
                blnTechnicianAbsent = false;
                CommonService.WriteErrorLog(ex);
            }

            return blnTechnicianAbsent;

        }

        public bool TechnicianTraining(int attendance_id, int technician_tranning, string location, bool IsDayStarted = true, string technician_name = "", string technician_mno = "", string technician_role = "")
        {
            objBaseMySQLDAL = new BaseMySQLDAL();

            bool blnTechnicianTraining = false;

            try
            {

                if (IsDayStarted)
                {
                    strQuery = @"UPDATE attendance_tbl SET technician_tranning = @technician_tranning, location = @location WHERE attendance_id = @attendance_id";

                    lstMySQLParam = new List<MySqlParameter>();

                    lstMySQLParam.AddRange(new MySqlParameter[]
                        {
                                new MySqlParameter("@technician_tranning", technician_tranning),
                                new MySqlParameter("@location", location),
                                new MySqlParameter("@attendance_id", attendance_id),
                        });
                }
                else
                {
                    strQuery = @"INSERT INTO attendance_tbl (technician_name, technician_mno, technician_present, start_day, technician_tranning, location, role)
                                                VALUES(@technician_name, @technician_mno, @technician_present, @start_day, @technician_tranning, @location, @role)";

                    lstMySQLParam = new List<MySqlParameter>();

                    lstMySQLParam.AddRange(new MySqlParameter[]
                        {

                                new MySqlParameter("@technician_name", technician_name),
                                new MySqlParameter("@technician_mno", technician_mno),
                                new MySqlParameter("@technician_present", 0),
                                new MySqlParameter("@start_day", 0),
                                new MySqlParameter("@technician_tranning", technician_tranning),
                                new MySqlParameter("@location", location),
                                new MySqlParameter("@role", technician_role)
                        });
                }
                // DB Side lunch_start,  lunch_starttime , lunch_start_location

                objBaseMySQLDAL.ExeccuteStoreCommand(strQuery, CommandType.Text, lstMySQLParam);


                blnTechnicianTraining = true;


            }
            catch (Exception ex)
            {
                blnTechnicianTraining = false;
                CommonService.WriteErrorLog(ex);
            }

            return blnTechnicianTraining;

        }

        #endregion

    }
}