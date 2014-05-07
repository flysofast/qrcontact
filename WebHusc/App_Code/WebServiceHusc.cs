using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebServiceHusc
/// </summary>
[WebService(Namespace = "http://husc.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebServiceHusc : System.Web.Services.WebService 
    
{
    DataClassesDataContext db = null;
        

    public WebServiceHusc () 
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
        db = new DataClassesDataContext();
    }

    [WebMethod]
    public int DemSoLuongNguoiDung()
    {
        return db.QR_CONTACTs.Count();
    }
    [WebMethod]
    public List<QR_CONTACT> DanhSachCacNguoiDung()
    {
        List<QR_CONTACT> listDB = db.QR_CONTACTs.ToList();        
        return listDB;
    }
    [WebMethod]
    public int InsertNewUser(string name,string phone,string address)
    {
        QR_CONTACT ct = new QR_CONTACT();

        ct.name = name;
        ct.phone = phone;
        ct.address = address;
        
        
        db.QR_CONTACTs.InsertOnSubmit(ct);
        db.SubmitChanges();
        return 1;
    }

            
}
