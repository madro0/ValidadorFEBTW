// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Validador.Models;

string rutaBase = AppDomain.CurrentDomain.BaseDirectory.ToString();
string log = string.Empty;
DataSet dataSet = new DataSet();


#region Load DataSet from XML
Console.WriteLine($"recuerde que el XML a validar debe estar guardado en la ruta {AppDomain.CurrentDomain.BaseDirectory.ToString()}");
string[] files = Directory.GetFiles(rutaBase, "*.xml");

if (files.Length <=0)
{
    Console.WriteLine($"No existe ningún archivo xml por validar en la ruta {rutaBase}");
    Environment.Exit(0);
}
string pathFile = files[0];

if (!ConvertXMLToDataSet(ref log, pathFile, ref dataSet)) 
{
    showLog(log);
   Console.ReadKey();
}
#endregion


DataTableCollection InvoiceLines = dataSet.Tables;

string[] tablasObligatias = { "InvcHead", "InvcDtl", "InvcTax", "SalesTRC", "Company", "Customer", "COOneTime"};
string[] tablasObligatias2 = { "InvcHead", "InvcDtl",  "Company", "Customer", "COOneTime"};
string[] tablasOpcionales = { "InvcTax", "SalesTRC", "InvcDisc", "InvcMisc"};

foreach (var item in tablasObligatias2)
{
    if (!InvoiceLines.Contains(item))
    {
        log +=  "________________________________________________\n" +
                $"Validación tabla {item}\n\n"+
                $"Error: su xml no contiene la tabla obligatoria {item}\n"+
                $"________________________________________________\n";
    }
    else
    {
        chooseModelValidate(item, dataSet, ref log);
    }
}

foreach (var item in tablasOpcionales)
{
    if (!InvoiceLines.Contains(item))
    {
        log += "________________________________________________\n" +
                $"Validación tabla {item}\n\n" +
                $"Advertencia: su xml no contiene la tabla opcional {item}\n" +
                $"________________________________________________\n";
    }
    else
    {
        chooseModelValidate(item, dataSet, ref log);
    }
}



//intento fallido de convertir dt en arry :(
//DataRow companydr = dataSet.Tables["Company"].Rows[0];

//DataTable dt = new DataTable();

//foreach (var item in companydr.Table.Columns)
//{
//    dt.Columns.Add(item.ToString());

//}
//DataRow dr = dt.NewRow();
//for (int i = 0; i < companydr.ItemArray.Length; i++)
//{
//    dr[i] = companydr[i].ToString();
//}
//dt.Rows.Add(dr);


//CompanyT company = new CompanyT();
//string js = JsonConvert.SerializeObject(dataSet.Tables["Company"].Rows[0].Table);
//company = System.Text.Json.JsonSerializer.Deserialize<CompanyT>(js);
//Console.WriteLine(company.Name, company.StateTaxID, company.Company);



//PropertyInfo[] properties = typeof(Company).GetProperties();


//    //Console.WriteLine(dataSet.Tables["Company"].Rows[0]?["Company"].ToString());
//Company company = new Company();

//string infoEtiquetaDs = string.Empty;
//foreach (PropertyInfo property in properties)
//{
//    dataSet = dataSet;
//    infoEtiquetaDs = string.Empty;
//        dataSet = dataSet;
//    if (dataSet.Tables["Company"].Columns.Contains(property.Name))
//    {
//        infoEtiquetaDs = dataSet.Tables["Company"].Rows[0][property.Name].ToString();
//        typeof(Company).GetProperty(property.Name).SetValue(company, infoEtiquetaDs, null);
//    }
//    //company[property.Name] = dataSet.
//    //company.[]
//}

//    //Console.WriteLine($"{company.Name},{company.StateTaxID},{company.Company}");

//var context = new ValidationContext(company, null, null);
//var results = new List<ValidationResult>();

//var isValid = Validator.TryValidateObject(company, context, results, true);

//if (!isValid)
//{
//    foreach (var validationResult in results)
//    {
//        log+= $"{validationResult.ErrorMessage}\n";
//    }
//}

showLog(log);
Console.ReadKey();
//if ()
//{
//    Console.WriteLine("No existe la table IncHead");
//}


static bool ConvertXMLToDataSet(ref string log, string pathFile, ref DataSet dataSet)
{
    try
    {
        dataSet.ReadXml(pathFile);
        //XDocument xDocument = XDocument.Load($"{pathFile}");
        //string strXmlARInvoice = xDocument.ToString();

        //DataSet dataSet = new DataSet();
        //StringReader stringReader = new StringReader(strXmlARInvoice);
        //dataSet.ReadXml(pathFile);

        //dataSet = dataSet;

        //if (dataSet.Tables["Company"].Columns.Contains("Company_Id"))
        //{

        //    string companyIdDs = dataSet.Tables["Company"].Rows[0]["Company_Id"].ToString();
        //    //dataSet.Tables["Company"].Columns.Remove("Company_Id");
        //    //dataSet.Tables["Company"].Columns.Add("Company", typeof(string));
        //    //dataSet.Tables["Company"].Rows[0]["Company"] = companyIdDs;
        //}

        return true;
    }
    catch (Exception Ex)
    {
        log +=$"Error: Ubo un problema cargando el archivo XML \n" +
              $"________________________________________________\n" +
              $"{Ex.Message}\n" +
              $"________________________________________________\n";
        return false;
        //throw;
    }
}

static void showLog(string log)
{
    Console.Write("Log transaccional:\n" + log);
    Console.WriteLine("Done...");
}

static void validCompany(DataSet dataSet, ref string log)
{

    
    Company company = new Company();
    PropertyInfo[] properties = typeof(Company).GetProperties();

    foreach (PropertyInfo property in properties)
    {

        if (dataSet.Tables["Company"].Columns.Contains(property.Name))
        {
            dynamic infoEtiquetaDs;

            try
            {
                infoEtiquetaDs = convertDataInfo(dataSet.Tables["Company"].Rows[0][property.Name].ToString(), property.PropertyType);
                typeof(Company).GetProperty(property.Name).SetValue(company, infoEtiquetaDs, null);
                //infoEtiquetaDs = dataSet.Tables["Company"].Rows[0][property.Name].ToString();
                //typeof(Company).GetProperty(property.Name).SetValue(company, infoEtiquetaDs, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error añadiendo " + property.Name + "\n" + ex);
            }
                        
        }

    }

    var context = new ValidationContext(company, null, null);
    var results = new List<ValidationResult>();
    var isValid = Validator.TryValidateObject(company, context, results, true);

    log += $"________________________________________________\n" +
           $"Validación tabla Company:  \n\n";
    if (!isValid)
    {
        foreach (var validationResult in results)
        {
            log += $"{validationResult.ErrorMessage}\n";   
        }
    }
    else
    {
        log += "No se encontró ningúna novedad en esta tabla\n";
    }

    log += $"________________________________________________\n";
}

static void validCustomer(DataSet dataSet, ref string log)
{

    Customer customer = new Customer();
    PropertyInfo[] properties = typeof(Customer).GetProperties();

    foreach (PropertyInfo property in properties)
    {
        dynamic infoEtiquetaDs;

        try
        {
            if (dataSet.Tables["Customer"].Columns.Contains(property.Name))
            {
                infoEtiquetaDs = convertDataInfo(dataSet.Tables["Customer"].Rows[0][property.Name].ToString(), property.PropertyType);
                typeof(Customer).GetProperty(property.Name).SetValue(customer, infoEtiquetaDs, null);
                //infoEtiquetaDs = dataSet.Tables["Customer"].Rows[0][property.Name].ToString();
                //typeof(Customer).GetProperty(property.Name).SetValue(customer, infoEtiquetaDs, null);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("error añadiendo " + property.Name + "\n" + ex);
        }
        
        //company[property.Name] = dataSet.
        //company.[]
    }

    var context = new ValidationContext(customer, null, null);
    var results = new List<ValidationResult>();
    var isValid = Validator.TryValidateObject(customer, context, results, true);

    log += $"________________________________________________\n" +
           $"Validación tabla Customer:  \n\n";
    if (!isValid)
    {
        foreach (var validationResult in results)
        {
            log += $"{validationResult.ErrorMessage}\n";
        }
    }
    else
    {
        log += "No se encontró ningúna novedad en esta tabla\n";
    }

    log += $"________________________________________________\n";
}

static void validInvcHead(DataSet dataSet, ref string log)
{
    InvcHead invcHead = new InvcHead();
    PropertyInfo[] properties = typeof(InvcHead).GetProperties();

    foreach (PropertyInfo property in properties)
    {
        //infoEtiquetaDs = string.Empty;

        if (dataSet.Tables["InvcHead"].Columns.Contains(property.Name))
        {
            dynamic infoEtiquetaDs;
            try
            {
                //infoEtiquetaDs =  Convert.ChangeType(dataSet.Tables["InvcHead"].Rows[0][property.Name].ToString(), property.PropertyType);
                infoEtiquetaDs = convertDataInfo(dataSet.Tables["InvcHead"].Rows[0][property.Name].ToString(), property.PropertyType);
                typeof(InvcHead).GetProperty(property.Name).SetValue(invcHead, infoEtiquetaDs, null);
            }
            catch (Exception ex)
            {
                
                //typeof(InvcHead).GetProperty(property.Name).SetValue(invcHead, property.PropertyType.GetTypeInfo()., null);

                Console.WriteLine("error añadiendo " + property.Name + "\n" + ex);
            }
  
        }
        //company[property.Name] = dataSet.
        //company.[]
    }
        Console.WriteLine(invcHead.DueDate);

    var context = new ValidationContext(invcHead, null, null);
    var results = new List<ValidationResult>();
    var isValid = Validator.TryValidateObject(invcHead, context, results, true);

    log += $"________________________________________________\n" +
           $"Validación tabla InvcHead:  \n\n";
    if (!isValid)
    {
        foreach (var validationResult in results)
        {
            log += $"{validationResult.ErrorMessage}\n";
        }
    }
    else
    {
        log += "No se encontró ningúna novedad en esta tabla\n";
    }

    log += $"________________________________________________\n";
}

static void validInvcDtl(DataSet dataSet, ref string log)
{
    //string infoEtiquetaDs = string.Empty;

    DataRow[] listInvcDtl = dataSet.Tables["InvcDtl"].Select();

    log += $"________________________________________________\n" +
               $"Validación tabla InvcDtl:  \n\n";
    foreach (DataRow row in listInvcDtl)
    {
        InvcDtl invcDtl = new InvcDtl();
        PropertyInfo[] properties = typeof(InvcDtl).GetProperties();

        foreach (PropertyInfo property in properties)
        {

            if (dataSet.Tables["InvcDtl"].Columns.Contains(property.Name))
            {
                dynamic infoEtiquetaDs;
                try
                {
                    //infoEtiquetaDs = Convert.ChangeType(dataSet.Tables["InvcDtl"].Rows[0][property.Name].ToString(), property.PropertyType);

                    infoEtiquetaDs = convertDataInfo(row[property.Name].ToString(), property.PropertyType);
                    typeof(InvcDtl).GetProperty(property.Name).SetValue(invcDtl, infoEtiquetaDs, null);
                }
                catch (Exception ex)
                {

                    //typeof(InvcDtl).GetProperty(property.Name).SetValue(invcDtl, property.PropertyType.GetTypeInfo(), null);


                }
                //company[property.Name] = dataSet.
                //company.[]
            }
        }
        var context = new ValidationContext(invcDtl, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(invcDtl, context, results, true);

        log += $"*línea Nro. {invcDtl.InvoiceLine}\n";

        if (!isValid)
        {
            foreach (var validationResult in results)
            {
                log += $"{validationResult.ErrorMessage}\n";
            }
        }
        else
        {
            log += "No se encontró ningúna novedad en esta línea\n";
        }
            log += $"\n";

    }
        log += $"________________________________________________\n";
}

static void validInvcTax(DataSet dataSet, ref string log)
{
    DataRow[] listInvcTax = dataSet.Tables["InvcTax"].Select();

    log += $"________________________________________________\n" +
               $"Validación tabla InvcTax:  \n\n";
    foreach (DataRow row in listInvcTax)
    {
        InvcTax invcTax = new InvcTax();
        PropertyInfo[] properties = typeof(InvcTax).GetProperties();

        foreach (PropertyInfo property in properties)
        {

            if (dataSet.Tables["InvcTax"].Columns.Contains(property.Name))
            {
                dynamic infoEtiquetaDs;
                try
                {
                    //infoEtiquetaDs = Convert.ChangeType(dataSet.Tables["InvcDtl"].Rows[0][property.Name].ToString(), property.PropertyType);

                    infoEtiquetaDs = convertDataInfo(row[property.Name].ToString(), property.PropertyType);
                    typeof(InvcTax).GetProperty(property.Name).SetValue(invcTax, infoEtiquetaDs, null);
                }
                catch (Exception ex)
                {

                }
            }
        }
        var context = new ValidationContext(invcTax, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(invcTax, context, results, true);

        log += $"*Impuestos ref línea Nro. {invcTax.InvoiceLine}\n";

        if (!isValid)
        {
            foreach (var validationResult in results)
            {
                log += $"{validationResult.ErrorMessage}\n";
            }
        }
        else
        {
            log += "No se encontró ningúna novedad en esta línea\n";
        }
            log += $"\n";

    }
    log += $"________________________________________________\n";
}

static void validSalesTrc(DataSet dataSet, ref string log)
{
    DataRow[] listSalesTrc = dataSet.Tables["SalesTrc"].Select();

    log += $"________________________________________________\n" +
               $"Validación tabla SalesTRC:  \n\n";
    foreach (DataRow row in listSalesTrc)
    {
        SalesTrc salesTrc = new SalesTrc();
        PropertyInfo[] properties = typeof(SalesTrc).GetProperties();

        foreach (PropertyInfo property in properties)
        {

            if (dataSet.Tables["SalesTrc"].Columns.Contains(property.Name))
            {
                dynamic infoEtiquetaDs;
                try
                {
                    //infoEtiquetaDs = Convert.ChangeType(dataSet.Tables["InvcDtl"].Rows[0][property.Name].ToString(), property.PropertyType);

                    infoEtiquetaDs = convertDataInfo(row[property.Name].ToString(), property.PropertyType);
                    typeof(SalesTrc).GetProperty(property.Name).SetValue(salesTrc, infoEtiquetaDs, null);
                }
                catch (Exception ex)
                {

                }
            }
        }
        var context = new ValidationContext(salesTrc, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(salesTrc, context, results, true);

        log += $"*Tributo {salesTrc.Description}({salesTrc.IdImpDIAN_c})\n";

        if (!isValid)
        {
            foreach (var validationResult in results)
            {
                log += $"{validationResult.ErrorMessage}\n";
            }
        }
        else
        {
            log += "No se encontró ningúna novedad en esta tributo\n";
        }
        log += $"\n";

    }
    log += $"________________________________________________\n";
}

static void validCOOneTime(DataSet dataSet, ref string log)
{
    COOneTime coOneTime= new COOneTime();
    PropertyInfo[] properties = typeof(COOneTime).GetProperties();

    foreach (PropertyInfo property in properties)
    {

        if (dataSet.Tables["COOneTime"].Columns.Contains(property.Name))
        {
            dynamic infoEtiquetaDs;

            try
            {
                infoEtiquetaDs = convertDataInfo(dataSet.Tables["COOneTime"].Rows[0][property.Name].ToString(), property.PropertyType);
                typeof(COOneTime).GetProperty(property.Name).SetValue(coOneTime, infoEtiquetaDs, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error añadiendo " + property.Name + "\n" + ex);
            }

        }

    }

    var context = new ValidationContext(coOneTime, null, null);
    var results = new List<ValidationResult>();
    var isValid = Validator.TryValidateObject(coOneTime, context, results, true);

    log += $"________________________________________________\n" +
           $"Validación tabla COOneTime:  \n\n";
    if (!isValid)
    {
        foreach (var validationResult in results)
        {
            log += $"{validationResult.ErrorMessage}\n";
        }
    }
    else
    {
        log += "No se encontró ningúna novedad en esta tabla\n";
    }

    log += $"________________________________________________\n";
}

static void validInvcDisc(DataSet dataSet, ref string log)
{
    InvcDisc invcDisc = new InvcDisc();
    PropertyInfo[] properties = typeof(InvcDisc).GetProperties();

    foreach (PropertyInfo property in properties)
    {

        if (dataSet.Tables["InvcDisc"].Columns.Contains(property.Name))
        {
            dynamic infoEtiquetaDs;

            try
            {
                infoEtiquetaDs = convertDataInfo(dataSet.Tables["InvcDisc"].Rows[0][property.Name].ToString(), property.PropertyType);
                typeof(InvcDisc).GetProperty(property.Name).SetValue(invcDisc, infoEtiquetaDs, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error añadiendo " + property.Name + "\n" + ex);
            }

        }

    }

    var context = new ValidationContext(invcDisc, null, null);
    var results = new List<ValidationResult>();
    var isValid = Validator.TryValidateObject(invcDisc, context, results, true);

    log += $"________________________________________________\n" +
           $"Validación tabla InvcDisc:  \n\n";
    if (!isValid)
    {
        foreach (var validationResult in results)
        {
            log += $"{validationResult.ErrorMessage}\n";
        }
    }
    else
    {
        log += "No se encontró ningúna novedad en esta tabla\n";
    }

    log += $"________________________________________________\n";
}

static void validInvcMisc(DataSet dataSet, ref string log)
{
    DataRow[] listInvcMisc = dataSet.Tables["InvcMisc"].Select();

    log += $"________________________________________________\n" +
               $"Validación tabla InvcMisc:  \n\n";
    foreach (DataRow row in listInvcMisc)
    {
        InvcMisc invcMisc = new InvcMisc();
        PropertyInfo[] properties = typeof(InvcMisc).GetProperties();

        foreach (PropertyInfo property in properties)
        {

            if (dataSet.Tables["InvcMisc"].Columns.Contains(property.Name))
            {
                dynamic infoEtiquetaDs;
                try
                {
                    //infoEtiquetaDs = Convert.ChangeType(dataSet.Tables["InvcDtl"].Rows[0][property.Name].ToString(), property.PropertyType);

                    infoEtiquetaDs = convertDataInfo(row[property.Name].ToString(), property.PropertyType);
                    typeof(InvcMisc).GetProperty(property.Name).SetValue(invcMisc, infoEtiquetaDs, null);
                }
                catch (Exception ex)
                {

                }
            }
        }
        var context = new ValidationContext(invcMisc, null, null);
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(invcMisc, context, results, true);

        log += $"*Cargo miscelaneo ref línea Nro. {invcMisc.InvoiceLine}\n";

        if (!isValid)
        {
            foreach (var validationResult in results)
            {
                log += $"{validationResult.ErrorMessage}\n";
            }
        }
        else
        {
            log += "No se encontró ningúna novedad en esta línea\n";
        }
        log += $"\n";

    }
    log += $"________________________________________________\n";
}

static void chooseModelValidate(string nameModel, DataSet dataSet, ref string log)
{
    switch (nameModel.ToUpper())
    {
        case "COMPANY":
            validCompany(dataSet, ref log);
            break;
        case "CUSTOMER":
            validCustomer(dataSet, ref log);
            break;
        case "INVCHEAD":
            validInvcHead(dataSet, ref log);
            break;
        case "INVCDTL":
            validInvcDtl(dataSet, ref log);
            break;
        case "INVCTAX":
            validInvcTax(dataSet, ref log);
            break;
        case "SALESTRC":
            validSalesTrc(dataSet, ref log);
            break;
        case "INVCDISC":
            validInvcDisc(dataSet, ref log);
            break;
        case "INVCMISC":
            validInvcMisc(dataSet, ref log);
            break;
        case "COONETIME":
            validCOOneTime(dataSet, ref log);
            break;

    }
}

static dynamic convertDataInfo(string value, Type tipo)
{
    dynamic result;
    Type t= tipo;

    if (tipo.Name.ToString().Contains("Nullable"))
    {
        t = Nullable.GetUnderlyingType(tipo);
    }
    try
    {
        if (t == typeof(Int32))
            return Convert.ToInt32(value);
    
        if (t == typeof(DateTime))
            return  Convert.ToDateTime(value);

        if (t == typeof(decimal))
            return Convert.ToDecimal(value);

        if (t == typeof(bool))
            return Convert.ToBoolean(value);

        if(t == typeof(string))
            return Convert.ToString(value);

        else
            return null;
    }
    catch (Exception)
    {
        result = null;
    }

    return result;

}