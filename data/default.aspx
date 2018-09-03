<%@ Page Language="c#" Debug="true" trace="false" validateRequest="false"  %>
<%@ import namespace="System" %>
<%@ import namespace="System.IO" %>
<%@ import namespace="System.Xml" %>
<%@ import namespace="System.Data" %>
<%@ import namespace="System.Data.SqlClient" %>
<%-- import namespace="System.Data.SqlServerCe" --%>
<%@ import namespace="Newtonsoft.Json" %>
#define CE
<script Runat="Server" >

void Page_Load(object sender, EventArgs e) {

XmlDocument parms  = new XmlDocument();
XmlNodeList nodeList;
XmlNode cmdnode =null;

//string connStr = "Data Source=" + Server.MapPath("db.sdf")+";";


string connStr = "Data Source=den1.mssql2.gear.host;Initial Catalog=dbindra;user id=dbindra;password=Upc*2018" ;//"Data Source=" + Server.MapPath("db.sdf")+";";


string p = Request.QueryString["p"];
string cmd= Request.QueryString["c"]??"";
string k= Request.QueryString["k"]??"";
string t= Request.QueryString["t"]??"";

bool showXml= Request.QueryString["xml"]=="1"?true:false;

string sqlStr = "";

parms.Load(Server.MapPath(".//pages//"+ p+".xml"));
#if(CE)
SqlCeConnection con = new SqlCeConnection(connStr);
#else
SqlConnection con = new SqlConnection(connStr);
#endif
int tid = 0;
int cmdid = 0;
int iid;
foreach (XmlNode n in parms.DocumentElement.SelectNodes("/form//sql[not(@id)]"))((XmlElement)n).SetAttribute("id","T"+(tid++).ToString());
foreach (XmlNode n in parms.DocumentElement.SelectNodes("/form//cmd"))((XmlElement)n).SetAttribute("id","C"+(cmdid++).ToString());
foreach (XmlNode n in parms.DocumentElement.SelectNodes("/form//sql[select]"))((XmlElement)n.SelectSingleNode("select")).SetAttribute("id",n.Attributes["id"].Value+".select");
if(t==""){
	t = parms.DocumentElement.SelectSingleNode("/form/sql/@id").Value;
}else{
	XmlNode n = parms.DocumentElement.SelectSingleNode(String.Format("/form//sql[@id='{0}']",t));
	((XmlElement)n).RemoveAttribute("parentcols");
	((XmlElement)n).RemoveAttribute("childcols");	
	XmlNode n2 = parms.DocumentElement.SelectSingleNode("/form/sql");
	n2.ParentNode.RemoveChild(n2);
	parms.DocumentElement.SelectSingleNode("/form").AppendChild(n);
}

if(cmd=="upd"){
	string strmContents="" ;
	using(System.IO.StreamReader reader = new System.IO.StreamReader(Request.InputStream))
	{
    	 while (reader.Peek() >= 0)
    	{    
     		strmContents += reader.ReadLine();
    	}
	}
	

	cmdnode = JsonConvert.DeserializeXmlNode(strmContents);
	((XmlDocument) cmdnode).DocumentElement.SetAttribute("xmlns:json", "http://james.newtonking.com/projects/json");
	String xtid = parms.DocumentElement.SelectSingleNode("/form/sql/@id").Value;
	foreach (XmlNode n in (XmlNodeList) cmdnode.SelectNodes("//cmd[@tid='']"))((XmlElement)n).SetAttribute("tid",xtid);
	con.Open();
	foreach (XmlNode n in (XmlNodeList) cmdnode.SelectNodes("//cmd")){	
		if(n.Attributes["cmd"].Value=="update"||n.Attributes["cmd"].Value=="insert"||n.Attributes["cmd"].Value=="delete"||n.Attributes["cmd"].Value=="sql"){
			string query="";
			string errorMessages="";	
			if (n.Attributes["cmd"].Value=="sql"){
				foreach (XmlNode n2 in (XmlNodeList) parms.DocumentElement.SelectNodes(String.Format("/form//cmd[@id='{0}']/text()",n.Attributes["commandid"].Value)))query += n2.Value;
			}else{
				foreach (XmlNode n2 in (XmlNodeList) parms.DocumentElement.SelectNodes(String.Format("/form//sql[@id='{0}']/{1}/text()",n.Attributes["tid"].Value,(String)n.Attributes["cmd"].Value)))query += n2.Value;
			}
        	((XmlElement) n).SetAttribute("Array", "http://james.newtonking.com/projects/json","true"); 

			String fields="";
			String fields2="";			
			String fvalues="";			
			String keys="";
			foreach (XmlNode n2 in (XmlNodeList) n.SelectNodes("./key") ) keys+= (keys==""?"":" and "  ) + String.Format("[{0}] = @{0}",n2.Attributes["name"].Value);			
			foreach (XmlNode n2 in (XmlNodeList) n.SelectNodes("./data") ) fields+= (fields==""?"":", "  ) + String.Format("[{0}] = @{0}",n2.Attributes["name"].Value);					
			foreach (XmlNode n2 in (XmlNodeList) n.SelectNodes("./data") ) fields2+= (fields2==""?"":", "  ) + String.Format("[{0}]",n2.Attributes["name"].Value);								
			foreach (XmlNode n2 in (XmlNodeList) n.SelectNodes("./data") ) fvalues+= (fvalues==""?"":", "  ) + String.Format("@{0}",n2.Attributes["name"].Value);											
			query = query.Replace("%%FIELDVALUE%%",fields);
			query = query.Replace("%%KEY%%",keys);	
			query = query.Replace("%%FIELDS%%",fields2);
			query = query.Replace("%%VALUES%%",fvalues);				
#if(CE)
			using (SqlCeCommand qcmd = new SqlCeCommand(query)){
#else
			using (SqlCommand qcmd = new SqlCommand(query)){
#endif 

 				try {
					foreach (XmlNode n2 in (XmlNodeList) n.SelectNodes("./key[@value]|./data[@value]") ) qcmd.Parameters.AddWithValue(n2.Attributes["name"].Value, n2.Attributes["value"].Value);

					qcmd.Connection = con;					 
					qcmd.ExecuteNonQuery();
					if(n.Attributes["cmd"].Value=="insert" && n.Attributes["tid"].Value==t ){

#if(CE)
						SqlCeCommand cmd1 = new SqlCeCommand(@"SELECT @@IDENTITY AS ID", con);
#else
						SqlCommand cmd1 = new SqlCommand(@"SELECT @@IDENTITY AS ID", con);
#endif 

						object o = cmd1.ExecuteScalar();
						iid = Convert.ToInt32(o);

						foreach (XmlNode n2 in (XmlNodeList) n.SelectNodes("./key") ){
							foreach (XmlNode n3 in (XmlNodeList) n.SelectNodes(String.Format("./aid[@name='{0}']",(string)((XmlElement) n2).GetAttribute("name")))){
								((XmlElement) n2).SetAttribute("value", Convert.ToString(iid));
								continue;
							}
							foreach (XmlNode n3 in (XmlNodeList) n.SelectNodes(String.Format("./data[@name='{0}']",(string)((XmlElement) n2).GetAttribute("name")))){
								((XmlElement) n2).SetAttribute("value", (string)((XmlElement) n2).GetAttribute("name"));
							}
						}
						k="";
						foreach (XmlNode n2 in (XmlNodeList) n.SelectNodes("./key") ){
							k+=(k!=""?"\t":"")+((XmlElement) n2).GetAttribute("name") +"\t"+((XmlElement) n2).GetAttribute("value");
						}


					}
        		}
        		catch (SqlException ex){
            		for (int i = 0; i < ex.Errors.Count; i++){
                		errorMessages+="Index #" + i + "\n" +
                    "Message: " + ex.Errors[i].Message + "\n" +
                    "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                    "Source: " + ex.Errors[i].Source + "\n" +
                    "Procedure: " + ex.Errors[i].Procedure + "\n";

            		}
        		}catch(Exception ex){
                	errorMessages+= ex.Message ;
        		}finally {

        		}
				if(errorMessages!="") {
					((XmlElement) n).SetAttribute("error","-1");
					((XmlElement) n).SetAttribute("errormessage",errorMessages);
					((XmlElement) n).SetAttribute("sqlerror",query);					
				}else{
					((XmlElement) n).SetAttribute("error","0");	
				}
			}
		}
	}
	con.Close();					
	//Response.ContentType = "text/xml; charset=utf-8";
	//Response.Write(cmdnode.OuterXml);	
	//Response.End();




}

DataSet dset = new DataSet();

string ws ="";
foreach (XmlNode n in (XmlNodeList) parms.DocumentElement.SelectNodes("/form//sql")){
	String vSql = "";
	foreach(XmlNode n2 in n.SelectNodes("./text()"))  vSql += n2.Value;

	string[] w = k.Split('\t');	
	if(k!="" && (String) n.Attributes["id"].Value==t ){
         for ( int i = 0; i < w.Length; i+=2 ) {
            ws += (ws==""?"":" AND") + " "+ t +".["+w[i] +"]=@"+w[i] ;
         }
		 vSql= "SELECT "+ t +".* from ("+vSql+") "+ t +" WHERE " + ws ;
	}

	if(k!="" && (String) n.Attributes["id"].Value!=t ){
        String vSql2 = "SELECT "+ (String) n.Attributes["id"].Value +".* from ("+vSql+") "+ (String) n.Attributes["id"].Value;
		String vSql2w = " WHERE " + ws ;
		foreach(XmlNode n2 in n.SelectNodes("./ancestor-or-self::sql[@parentcols and @childcols]")){
			String vSql3 = "";
			foreach(XmlNode n3 in n2.SelectNodes("../text()"))  vSql3 += n3.Value;	
			vSql2 += ",("+vSql3+") "+ (String) n2.SelectSingleNode("../@id").Value;
			String[] pcols = n2.Attributes["parentcols"].Value.Split(',');
			String[] ccols = n2.Attributes["childcols"].Value.Split(',');
			for(int i=0;i<pcols.Length;i++){
				vSql2w+=String.Format(" AND {0}.[{1}]={2}.[{3}]", (String) n2.Attributes["id"].Value,ccols[i],n2.SelectSingleNode("../@id").Value,pcols[i]);
			}			
		}
		vSql = vSql2 + vSql2w;
	}



#if(CE)
	SqlCeDataAdapter adapter = new SqlCeDataAdapter(vSql, con);
#else
	SqlDataAdapter adapter = new SqlDataAdapter(vSql, con);
#endif
	if(k!=""){
         for ( int i = 0; i < w.Length; i+=2 ) {
           adapter.SelectCommand.Parameters.AddWithValue("@"+w[i],w[i+1]);
         }
	}
	adapter.FillSchema(dset, SchemaType.Source,(String) n.Attributes["id"].Value);
	DataColumn[] ucols = new DataColumn[0];
	foreach(XmlNode n2 in n.SelectNodes("./column[@primarykey]")){
		if(ucols.Length==0) dset.Tables[(String) n.Attributes["id"].Value].PrimaryKey = null;			
		Array.Resize(ref ucols,ucols.Length +1 );
		ucols[ucols.Length-1] = dset.Tables[(String) n.Attributes["id"].Value].Columns[(String) n2.Attributes["name"].Value];
	}

	if(ucols.Length>0) dset.Tables[(String) n.Attributes["id"].Value].PrimaryKey = ucols ;

	foreach(XmlNode n2 in n.SelectNodes("./column[@identity]")){
		dset.Tables[(String) n.Attributes["id"].Value].Columns[(String) n2.Attributes["name"].Value].AutoIncrement=true;
	}

	adapter.Fill(dset, (String) n.Attributes["id"].Value);
}				

foreach (XmlNode n in (XmlNodeList) parms.DocumentElement.SelectNodes("//column[@select]")){
#if(CE)
	SqlCeDataAdapter adapter = new SqlCeDataAdapter(n.Attributes["select"].Value,con);
#else
	SqlDataAdapter adapter = new SqlDataAdapter(n.Attributes["select"].Value,con);
#endif
	adapter.Fill(dset, (String) n.SelectSingleNode("../@id").Value+"."+ n.Attributes["name"].Value+".select");
}	

foreach (XmlNode n in (XmlNodeList) parms.DocumentElement.SelectNodes("/form//select")){
	String vSql = "";
	foreach(XmlNode n2 in n.SelectNodes("./text()"))  vSql += n2.Value;
#if(CE)
	SqlCeDataAdapter adapter = new SqlCeDataAdapter(vSql, con);
#else
	SqlDataAdapter adapter = new SqlDataAdapter(vSql, con);
#endif

	adapter.FillSchema(dset, SchemaType.Source,(String) n.SelectSingleNode("../@id").Value+".select");

	adapter.Fill(dset, (String) n.SelectSingleNode("../@id").Value+".select");
}				




foreach (XmlNode n in (XmlNodeList) parms.DocumentElement.SelectNodes("/form//sql[@parentcols and @childcols]")){
	String[] pcols = n.Attributes["parentcols"].Value.Split(',');
	String[] ccols = n.Attributes["childcols"].Value.Split(',');
	DataColumn[] upcols = new DataColumn[0];
	DataColumn[] uccols = new DataColumn[0];
	for(int i=0;i<pcols.Length;i++){
		Array.Resize(ref upcols,upcols.Length +1 );		
		Array.Resize(ref uccols,uccols.Length +1 );		
		upcols[upcols.Length-1] = dset.Tables[(String) n.SelectSingleNode("../@id").Value].Columns[pcols[i]];
		uccols[uccols.Length-1] = dset.Tables[(String) n.Attributes["id"].Value].Columns[ccols[i]];
	}
	dset.Relations.Add(n.Attributes["id"].Value,upcols,uccols,false).Nested=true;

}				


foreach (DataTable dt in dset.Tables){
	foreach (DataColumn dc in dt.Columns)	{
		dc.ColumnMapping = MappingType.Attribute;
	}
}



XmlDocument dat  = new XmlDocument();
XmlDocument sch  = new XmlDocument();
dat.LoadXml(dset.GetXml());
sch.LoadXml(dset.GetXmlSchema());

sch.DocumentElement.SetAttribute("xmlns:json", "http://james.newtonking.com/projects/json");
dat.DocumentElement.SetAttribute("xmlns:json", "http://james.newtonking.com/projects/json");

XmlNamespaceManager nsmgr = new XmlNamespaceManager(sch.NameTable);
nsmgr.AddNamespace("xs", "http://www.w3.org/2001/XMLSchema");
nsmgr.AddNamespace("msdata", "urn:schemas-microsoft-com:xml-msdata");

foreach (XmlNode n in sch.DocumentElement.SelectNodes("//xs:attribute[contains(@name,'_x0')]",nsmgr)){
	((XmlElement) n).SetAttribute("name",XmlConvert.DecodeName((String)n.Attributes["name"].Value));
}
foreach (XmlNode n in parms.DocumentElement.SelectNodes("/form")){
	XmlNode n2 = sch.DocumentElement.SelectSingleNode("//xs:element[@msdata:IsDataSet='true']",nsmgr);
	if (n2!=null){
		foreach (string v in new string[] {"title","subtitle"}){
			if(n.Attributes[v]!=null) ((XmlElement) n2).SetAttribute(v,n.Attributes[v].Value);	
		}
	}
}

foreach (XmlNode n in parms.DocumentElement.SelectNodes("/form//sql")){
	XmlNode n2 = sch.DocumentElement.SelectSingleNode("//xs:element[@name='"+n.SelectSingleNode("@id").Value+"']",nsmgr);
	if (n2!=null){
		foreach (string v in new string[] {"caption","href","data-form","data-filter"}){
			if(n.Attributes[v]!=null) ((XmlElement) n2).SetAttribute(v,n.Attributes[v].Value);	
		}
		XmlNode n3 = n.SelectSingleNode("./select",nsmgr);
		if (n3!=null){
			((XmlElement) n2).SetAttribute("option",n.SelectSingleNode("@id").Value+".select");	
			if(n3.Attributes["caption"]!=null) ((XmlElement) n2).SetAttribute("optioncaption",n3.Attributes["caption"].Value);	
			XmlNode n4 = sch.DocumentElement.SelectSingleNode("//xs:element[@name='"+n.SelectSingleNode("@id").Value+".select"+"']",nsmgr);
			((XmlElement) n4).SetAttribute("selectcols",n3.Attributes["selectcols"].Value);	
			((XmlElement) n4).SetAttribute("tablecols",n3.Attributes["tablecols"].Value);			
		}

	}
    foreach (XmlNode n3 in n.SelectNodes("./cmd")){
        XmlNode n4=sch.CreateElement("command");
    	((XmlElement) n4).SetAttribute("id",n3.Attributes["id"].Value);		
    	if(n3.Attributes["type"]!=null)((XmlElement) n4).SetAttribute("type",n3.Attributes["type"].Value);
    	if(n3.Attributes["caption"]!=null)((XmlElement) n4).SetAttribute("caption",n3.Attributes["caption"].Value);        
    	if(n3.Attributes["message"]!=null)((XmlElement) n4).SetAttribute("message",n3.Attributes["message"].Value);
        if(n3.Attributes["href"]!=null)((XmlElement) n4).SetAttribute("href",n3.Attributes["href"].Value);		
        ((XmlElement) n4).SetAttribute("Array", "http://james.newtonking.com/projects/json","true"); 
        n2.AppendChild(n4); 
        n3.ParentNode.RemoveChild(n3);       
    }

}


foreach (XmlNode n in parms.DocumentElement.SelectNodes("/form//column")){
	XmlNode n2 = sch.DocumentElement.SelectSingleNode("//xs:element[@name='"+n.SelectSingleNode("../@id").Value+"']/xs:complexType/xs:attribute[@name='"+n.SelectSingleNode("@name").Value+"']",nsmgr);
	if (n2!=null){
		foreach (string v in new string[] {"caption","width","multiple","type","visible","readonly"}){
			if(n.Attributes[v]!=null) ((XmlElement) n2).SetAttribute(v,n.Attributes[v].Value);	
		}
	}
}

foreach (XmlNode n in parms.DocumentElement.SelectNodes("/form//column[@select]")){
	XmlNode n2 = sch.DocumentElement.SelectSingleNode("//xs:element[@name='"+n.SelectSingleNode("../@id").Value+"']/xs:complexType/xs:attribute[@name='"+n.SelectSingleNode("@name").Value+"']",nsmgr);
	if (n2!=null){
        foreach (XmlNode n3 in dat.DocumentElement.SelectNodes("//"+n.SelectSingleNode("../@id").Value+"."+ n.Attributes["name"].Value+".select")){
            XmlNode n4=sch.CreateElement("option");
            ((XmlElement) n4).SetAttribute("key",n3.Attributes[0].Value);        
            ((XmlElement) n4).SetAttribute("value",(n3.Attributes.Count>1)?n3.Attributes[1].Value:" ");
            ((XmlElement) n4).SetAttribute("Array", "http://james.newtonking.com/projects/json","true"); 
            n2.AppendChild(n4); 
            n3.ParentNode.RemoveChild(n3);       
        }
	}
}

foreach (XmlNode n in parms.DocumentElement.SelectNodes("/form//column[@values]")){
	XmlNode n2 = sch.DocumentElement.SelectSingleNode("//xs:element[@name='"+n.SelectSingleNode("../@id").Value+"']/xs:complexType/xs:attribute[@name='"+n.SelectSingleNode("@name").Value+"']",nsmgr);
	if (n2!=null){
        foreach (String a1 in n.SelectSingleNode("./@values").Value.Split(';')){
            XmlNode n4=sch.CreateElement("option");
            ((XmlElement) n4).SetAttribute("key",a1.Split(',')[0]);        
            ((XmlElement) n4).SetAttribute("value",a1.Split(',').Length>1?a1.Split(',')[1]:a1.Split(',')[0]);
            ((XmlElement) n4).SetAttribute("Array", "http://james.newtonking.com/projects/json","true"); 
            n2.AppendChild(n4);        
        }
	}
}

foreach (XmlNode n in sch.DocumentElement.SelectNodes("//xs:unique|//xs:unique/xs:field|//xs:keyref|//xs:attribute|//xs:element[not(@msdata:IsDataSet='true')]",nsmgr))((XmlElement)n).SetAttribute("Array", "http://james.newtonking.com/projects/json","true");
foreach (XmlNode n in parms.DocumentElement.SelectNodes("/form//sql")){
    foreach (XmlNode n2 in dat.DocumentElement.SelectNodes("//*[count("+ n.Attributes["id"].Value+")=1]/"+ n.Attributes["id"].Value,nsmgr))
        ((XmlElement)n2).SetAttribute("Array", "http://james.newtonking.com/projects/json","true");
}
foreach (XmlNode n in sch.DocumentElement.SelectNodes("//xs:attribute[xs:simpleType/xs:restriction/@base='xs:string']",nsmgr)){
    ((XmlElement)n).SetAttribute("type", "xs:string");
    ((XmlElement)n).SetAttribute("length", n.SelectSingleNode(".//xs:maxLength/@value",nsmgr).InnerText);

}
if(cmdnode!=null){
   foreach (XmlNode n2 in cmdnode.SelectNodes("//cmd[0]"))
        ((XmlElement)n2).SetAttribute("Array", "http://james.newtonking.com/projects/json","true");	
}



if(showXml){
	Response.ContentType = "text/xml; charset=utf-8";
	Response.Write("<xml><schema>");
	Response.Write(sch.DocumentElement.OuterXml);
	Response.Write("</schema>");	
	if(cmdnode!=null){
		Response.Write("<commands>");	
		Response.Write(cmdnode.OuterXml);				
		Response.Write("<commands>");			
	}
	Response.Write("<data>");		
	Response.Write(dat.DocumentElement.OuterXml);	
	Response.Write("</data></xml>");		
	Response.End();
}

Response.Clear();
string json;
if(cmdnode!=null){
	json = "{\"schema\":"+JsonConvert.SerializeXmlNode(sch)+",\"command\":"+JsonConvert.SerializeXmlNode(cmdnode)+",\"data\":"+JsonConvert.SerializeXmlNode(dat)+"}";	
}else{
	json = "{\"schema\":"+JsonConvert.SerializeXmlNode(sch)+",\"data\":"+JsonConvert.SerializeXmlNode(dat)+"}";
}

Response.ContentType = "application/javascript; charset=utf-8";
Response.Write (json);

Response.End();


Response.ContentType = "text/xml; charset=utf-8";
DataSet customers = new DataSet();
customers.WriteXml(Response.OutputStream);

Response.End();

//SQLiteConnection cnn = new SQLiteConnection("Data Source="+Server.MapPath("test.db"));
//cnn.Open();
//SQLiteCommand mycommand = new SQLiteCommand(cnn);
}
</script>