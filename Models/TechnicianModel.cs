using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KEServiceV2.Models
{
    public class TechnicianModel
    {
    }

    #region Common
    public class CreationDate
    {
        public string date { get; set; }
        public int timezone_type { get; set; }
        public string timezone { get; set; }
    }

    public class ModifyDate
    {
        public string date { get; set; }
        public int timezone_type { get; set; }
        public string timezone { get; set; }
    }
    #endregion

    #region Tech_Login

    public class Tech_LoginRQ
    {
        public string mobileno { get; set; }
        public string device_token { get; set; }
        public string os_type { get; set; }
        public string password { get; set; }
    }


    public class Otherdata
    {
        public string Oid { get; set; }
        public string OldOid { get; set; }
        public string Technician { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneH { get; set; }
        public string PhoneO { get; set; }
        public string Mobile { get; set; }
        public object TechType { get; set; }
        public string JobType { get; set; }
        public string UserName { get; set; }
        public string Modifier { get; set; }
        public CreationDate CreationDate { get; set; }
        public ModifyDate ModifyDate { get; set; }
        public string OptimisticLockField { get; set; }
        public string GCRecord { get; set; }
        public int IsActive { get; set; }
        public string L1 { get; set; }
        public string L2 { get; set; }
        public string DT { get; set; }
        public object os_type { get; set; }
        public object device_token { get; set; }
        public string usertype { get; set; }
    }

    public class UserData
    {
        public string userid { get; set; }
        public dynamic otherdata { get; set; }
    }

    public class Tech_LoginRS
    {
        public UserData user_data { get; set; }
    }




    #endregion

    #region Techman_JobList

    public class Techman_JobListRQ
    {
        public string techid { get; set; }
    }

    public class JobDoneTime
    {
        public string date { get; set; }
        public int timezone_type { get; set; }
        public string timezone { get; set; }
    }

    public class CallAssignDate
    {
        public string date { get; set; }
        public int timezone_type { get; set; }
        public string timezone { get; set; }
    }



    public class CallDate
    {
        public string date { get; set; }
        public int timezone_type { get; set; }
        public string timezone { get; set; }
    }

    public class Time_IN
    {
        public string date { get; set; }
        public int timezone_type { get; set; }
        public string timezone { get; set; }
    }
    public class Time_OUT
    {
        public string date { get; set; }
        public int timezone_type { get; set; }
        public string timezone { get; set; }
    }

    public class TechDetail
    {
        public string Oid { get; set; }
        public string OldOid { get; set; }
        public int IsActive { get; set; }
        public string Technician { get; set; }
        public object Address { get; set; }
        public string City { get; set; }
        public string L1 { get; set; }
        public string L2 { get; set; }
        public object PhoneH { get; set; }
        public object PhoneO { get; set; }
        public string Mobile { get; set; }
        public string TechType { get; set; }
        public object JobType { get; set; }
        public string UserName { get; set; }
        public string Modifier { get; set; }
        public CreationDate CreationDate { get; set; }
        public ModifyDate ModifyDate { get; set; }
        public int OptimisticLockField { get; set; }
        public object GCRecord { get; set; }
        public string locationtime { get; set; }
        public object device_token { get; set; }
    }

    public class AreaDetail
    {
        public string AreaName { get; set; }
    }

    public class records
    {
        public string Oid { get; set; }
        public string IsNew { get; set; }
        public int CallDeleted { get; set; }
        public object longitude { get; set; }
        public object latitude { get; set; }
        public string Area { get; set; }
        public string Root_Priority { get; set; }
        public string ID { get; set; }
        public string RecipientType { get; set; }
        public string Desp_Doc_No { get; set; }
        public string Desp_Date { get; set; }
        public string Equipment_Id { get; set; }
        public JobDoneTime JobDoneTime { get; set; }
        public CallAssignDate CallAssignDate { get; set; }
        public object GodownName { get; set; }
        public object Godown { get; set; }
        public object DealerName { get; set; }
        public int HomeDelivery { get; set; }
        public int Display { get; set; }
        public object ExchangeProduct { get; set; }
        public int PendingExchange { get; set; }
        public object EstimateDate { get; set; }
        public object EstConfirmDate { get; set; }
        public int PaymentBy { get; set; }
        public string UserName { get; set; }
        public string Modifier { get; set; }
        public CreationDate CreationDate { get; set; }
        public ModifyDate ModifyDate { get; set; }
        public object CompComplaintNo { get; set; }
        public string JobNo { get; set; }
        public CallDate CallDate { get; set; }
        public string ItemName { get; set; }
        public string SrNo { get; set; }
        public string FaultDesc { get; set; }
        public int CallType { get; set; }
        public string Customer { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string ProductName { get; set; }
        public int ServType { get; set; }
        public string SpInst { get; set; }
        public string ModelName { get; set; }
        public string ItemGroup { get; set; }
        public object PurchaseDate { get; set; }
        public int WrExt { get; set; }
        public object BillNo { get; set; }
        public string ShowRoom { get; set; }
        public object TechBillNo { get; set; }
        public string DealRef { get; set; }
        public string Technician { get; set; }
        public int Amount { get; set; }
        public object SIGN { get; set; }
        public Time_IN Time_IN { get; set; }
        public Time_OUT Time_OUT { get; set; }
        public object Warranty { get; set; }
        public int CallAttn { get; set; }
        public int JobDone { get; set; }
        public int Deliver { get; set; }
        public int SMSSent { get; set; }
        public string Estimate { get; set; }
        public int DelQty { get; set; }
        public object Salesman { get; set; }
        public object Driver { get; set; }
        public object VehicleNo { get; set; }
        public string Payment { get; set; }
        public string VisitCharge { get; set; }
        public string Rent { get; set; }
        public int CallBack { get; set; }
        public int WorkShopIN { get; set; }
        public int PartPanding { get; set; }
        public int GoAfterCall { get; set; }
        public int Canceled { get; set; }
        public int PaymentPanding { get; set; }
        public int AMC { get; set; }
        public object Exchange { get; set; }
        public int Exchange1 { get; set; }
        public int Repeat { get; set; }
        public int RepeatFromTech { get; set; }
        public string JobRegion { get; set; }
        public object JobDoneRegion { get; set; }
        public object FaultType { get; set; }
        public int OptimisticLockField { get; set; }
        public object GCRecord { get; set; }
        public object TimeIN { get; set; }
        public object TimeOUT { get; set; }
        public object fault_name1 { get; set; }
        public object fault_name2 { get; set; }
        public object fault_name3 { get; set; }
        public object fault_name4 { get; set; }
        public object fault_name5 { get; set; }
        public object fault_name6 { get; set; }
        public object fault_qty1 { get; set; }
        public object fault_qty2 { get; set; }
        public object fault_qty3 { get; set; }
        public object fault_qty4 { get; set; }
        public object fault_qty5 { get; set; }
        public object fault_qty6 { get; set; }
        public object cu_latitude { get; set; }
        public object cu_longitude { get; set; }
        public object technisian_latitude { get; set; }
        public object technisian_longitude { get; set; }
        public object time_between { get; set; }
        public object PaymentByCheque { get; set; }
        public object fault_name7 { get; set; }
        public TechDetail tech_detail { get; set; }
        public AreaDetail Area_detail { get; set; }
        //public List<records> records { get; set; }
    }

    public class Techman_JobListRS
    {
        public int success { get; set; }
        public List<records> records { get; set; }
    }

    #endregion

    #region Jobdone_Verify

    public class Jobdone_VerifyRQ
    {
        public string user_type { get; set; }
        public string order_id { get; set; }
        public string code { get; set; }
        public string mob { get; set; }
    }

    public class Jobdone_VerifyRS
    {
        public int success { get; set; }
        public string success_msg { get; set; }
    }

    #endregion

    #region Ke_Company_List

    public class Company_ListRQ
    {
        public string var_cat_name { get; set; }
    }

    public class ItemDetails
    {
        public string Oid { get; set; }
        public string OldOid { get; set; }
        public string ItemName { get; set; }
        public string Company { get; set; }
        public string Brand { get; set; }
        public string ModelName { get; set; }
        public string Group { get; set; }
        public int OptimisticLockField { get; set; }
        public int? GCRecord { get; set; }
        public string category { get; set; }
    }

    public class Company_Record
    {
        public string CompanyName { get; set; }
        public string Oid { get; set; }
        public ItemDetails item_details { get; set; }
        //public List<Record> records { get; set; }
    }

    public class Company_ListRS
    {
        public int success { get; set; }
        public List<Company_Record> records { get; set; }
    }

    public class CompanyDetail
    {
        public string Oid { get; set; }
        public string CompanyName { get; set; }
    }




    #endregion

    #region Versoin

    public class VersionRecord
    {
        public string id { get; set; }
        public string states { get; set; }
        public string androidversion { get; set; }
        public string Iosversion { get; set; }
        public string Atechversion { get; set; }
        public string Itechversion { get; set; }
    }

    public class VersionRS
    {
        public int success { get; set; }
        public string success_msg { get; set; }
        public List<VersionRecord> records { get; set; }
    }

    #endregion

    #region Job_Start

    public class Job_StartRQ
    {
        public string techid { get; set; }
        public string order_id { get; set; }
        public string starttimelatitude { get; set; }
        public string starttimelongitude { get; set; }
    }

    public class Job_StartRS
    {
        public int success { get; set; }
        public string success_msg { get; set; }
        public List<object> records { get; set; }
    }


    #endregion

    #region Job Done


    public class Job_DoneRS
    {
        public int success { get; set; }
        public string success_msg { get; set; }
    }

    public class Job_DoneRQ
    {
        public string order_id { get; set; }
        public string tech_id { get; set; }
        public string reasonForJobDone { get; set; }
        public string reasonForNotJobdone { get; set; }
        public string EXCHANGE { get; set; }
        public string job_done { get; set; }
        public string CallBack { get; set; }
        public string PartPanding { get; set; }
        public string GoAfterCall { get; set; }
        public string Repeat { get; set; }
        public string PaymentPanding { get; set; }
        public string Exchange1 { get; set; }
        public string HomeDelivery { get; set; }
        public string RepeatFromTech { get; set; }
        public string PaymentByCheque { get; set; }
        public string call_attend { get; set; }
        public string Canceled { get; set; }
        public string WorkShopIN { get; set; }
        public string AMC { get; set; }
        public string AppDownload { get; set; }
        public string AppAlreadyIns { get; set; }
        public string NotPhone { get; set; }
        public string srno { get; set; }
        public string billno { get; set; }
        public string tech_bill_no { get; set; }
        public string modelno { get; set; }
        public string dop { get; set; }
        public string tech_visit_charge { get; set; }
        public string final_amount { get; set; }
        public string Estimateamount { get; set; }
        public string ipAddress { get; set; }
        public string imei { get; set; }
        public string endtimelatitude { get; set; }
        public string endtimelongitude { get; set; }
    }
    #endregion

    #region Insert Exits Product

    public class Add_Exis_ProductRQ
    {
        public string customer_name { get; set; }
        public string customer_mno { get; set; }
        public string t_name { get; set; }
        public string t_mno { get; set; }
        public string product_name { get; set; }
        public string product_exi { get; set; }
    }

    public class Add_Exis_ProductRS
    {
        public int success { get; set; }
        public string success_msg { get; set; }
    }
    #endregion

    #region Insert avail product

    public class Add_Avail_ProductRQ
    {
        public string customer_name { get; set; }
        public string customer_mno { get; set; }
        public string t_name { get; set; }
        public string t_mno { get; set; }
        public string product_name { get; set; }

        public string company_name { get; set; }

    }
    public class Add_Avail_ProductRS
    {
        public int success { get; set; }
        public string success_msg { get; set; }
    }

    #endregion

    #region Service List
    public class Service_Item
    {
        public string service_id { get; set; }
        public string service_name { get; set; }
        public string service_img { get; set; }
    }

    public class Service_ListRS
    {
        public string tag { get; set; }
        public int success { get; set; }
        public List<Service_Item> data { get; set; }
    }

    #endregion

    #region Exchange Service

    public class Exchange_ServiceRQ
    {
        public string customer_name { get; set; }
        public string customer_mno { get; set; }
        public string t_name { get; set; }
        public string t_mno { get; set; }
        public int id { get; set; }


    }
    public class Exchange_ServiceRS
    {
        public int success { get; set; }
        public string success_msg { get; set; }
    }

    #endregion

    #region Installation Image

    public class Installation_ImgRQ
    {
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string location { get; set; }
        public string img_missing { get; set; }
        public string serviceType { get; set; }
        public string technician_no { get; set; }
        public string technician_name { get; set; }
        public string customer_name { get; set; }
        public string customer_number { get; set; }
        public string image { get; set; }
        public string job_id { get; set; }
    }

    public class Installation_ImgRS
    {
        public int success { get; set; }
        public string success_msg { get; set; }
    }

    #endregion

    #region Add Expense

    public class Add_ExpenseRQ
    {
        public string techid { get; set; }
        public string type { get; set; }
        public string amount { get; set; }
    }

    public class Add_ExpenseRS
    {
        public int success { get; set; }
        public string success_msg { get; set; }
    }
    #endregion

    #region Attendance

    public class AttadenceRQ
    {
        public string tech_name { get; set; }
        public string tech_mno { get; set; }
        public string start_day { get; set; }
        public string tech_present { get; set; }
        public string tech_img { get; set; }
        public string present_location { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string start_lunch { get; set; }
        public string start_lunch_location { get; set; }
        public string start_lunch_latitude { get; set; }
        public string start_lunch_longitude { get; set; }
        public string end_lunch { get; set; }
        public string end_lunch_latitude { get; set; }
        public string end_lunch_longitude { get; set; }
        public string end_lunch_location { get; set; }
        public string endday { get; set; }
        public string endday_latitude { get; set; }
        public string endday_longitude { get; set; }
        public string endday_location { get; set; }
        public string tech_absent { get; set; }
        public string absent_reason { get; set; }
        public string tech_tranning { get; set; }
        public string location { get; set; }
    }

    public class AttadenceRS
    {
        public int success { get; set; }
        public string success_msg { get; set; }
        public int data { get; set; }
    }


    public class AttendanceData
    {
        public int attendance_id { get; set; }
        public string technician_name { get; set; }
        public string technician_mno { get; set; }
        public int technician_present { get; set; }
        public int start_day { get; set; }
        public string technician_img { get; set; }
        public string present_location { get; set; }
        public int technician_absent { get; set; }
        public string absent_reason { get; set; }
        public string absent_time { get; set; }
        public int technician_tranning { get; set; }
        public string location { get; set; }
        public string attendance_date { get; set; }
        public string attendance_time { get; set; }
        public int lunch_start { get; set; }
        public string lunch_img { get; set; }
        public string lunch_starttime { get; set; }
        public string lunch_start_location { get; set; }
        public int lunch_end { get; set; }
        public string lunch_endimg { get; set; }
        public string lunch_endtime { get; set; }
        public string lunch_end_location { get; set; }
        public int end { get; set; }
        public string end_img { get; set; }
        public string endtime { get; set; }
        public string end_day_location { get; set; }
        public string locationde { get; set; }
        public string role { get; set; }
    }

    #endregion



}