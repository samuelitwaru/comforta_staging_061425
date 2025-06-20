/*
				   File: type_SdtWWPContext
			Description: WWPContext
				 Author: Nemo 🐠 for C# (.NET) version 18.0.10.184260
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using GeneXus.Programs;
namespace GeneXus.Programs.wwpbaseobjects
{
	[XmlRoot(ElementName="WWPContext")]
	[XmlType(TypeName="WWPContext" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWWPContext : GxUserType
	{
		public SdtWWPContext( )
		{
			/* Constructor for serialization */
			gxTv_SdtWWPContext_Gamuserguid = "";

			gxTv_SdtWWPContext_Gamusername = "";

			gxTv_SdtWWPContext_Gamuserfirstname = "";

			gxTv_SdtWWPContext_Gamuserlastname = "";

			gxTv_SdtWWPContext_Gamuseremail = "";

			gxTv_SdtWWPContext_Gamuserphone = "";

			gxTv_SdtWWPContext_Organisationname = "";

			gxTv_SdtWWPContext_Locationname = "";

			gxTv_SdtWWPContext_Organisationsettinglogo = "";
			gxTv_SdtWWPContext_Organisationsettinglogo_gxi = "";
			gxTv_SdtWWPContext_Organisationsettingfavicon = "";
			gxTv_SdtWWPContext_Organisationsettingfavicon_gxi = "";
			gxTv_SdtWWPContext_Organisationsettingbasecolor = "";

			gxTv_SdtWWPContext_Organisationsettingfontsize = "";

			gxTv_SdtWWPContext_Organisationsettinglanguage = "";

			gxTv_SdtWWPContext_Organisationsettingtrnmode = "";

			gxTv_SdtWWPContext_Organisationbrandtheme = "";

			gxTv_SdtWWPContext_Organisationctatheme = "";

			gxTv_SdtWWPContext_Footertext = "";

			gxTv_SdtWWPContext_Profileurl = "";

		}

		public SdtWWPContext(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("GAMUserGUID", gxTpr_Gamuserguid, false);


			AddObjectProperty("GAMUserName", gxTpr_Gamusername, false);


			AddObjectProperty("GAMUserFirstName", gxTpr_Gamuserfirstname, false);


			AddObjectProperty("GAMUserLastName", gxTpr_Gamuserlastname, false);


			AddObjectProperty("GAMUserEmail", gxTpr_Gamuseremail, false);


			AddObjectProperty("GAMUserPhone", gxTpr_Gamuserphone, false);


			AddObjectProperty("isComfortaAdmin", gxTpr_Iscomfortaadmin, false);


			AddObjectProperty("isOrganisationManager", gxTpr_Isorganisationmanager, false);


			AddObjectProperty("isReceptionist", gxTpr_Isreceptionist, false);


			AddObjectProperty("isResident", gxTpr_Isresident, false);


			AddObjectProperty("isRootAdmin", gxTpr_Isrootadmin, false);


			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("OrganisationName", gxTpr_Organisationname, false);


			AddObjectProperty("OrganisationTypeId", gxTpr_Organisationtypeid, false);


			AddObjectProperty("LocationId", gxTpr_Locationid, false);


			AddObjectProperty("LocationName", gxTpr_Locationname, false);


			AddObjectProperty("OrganisationSettingid", gxTpr_Organisationsettingid, false);


			AddObjectProperty("OrganisationSettingLogo", gxTpr_Organisationsettinglogo, false);
			AddObjectProperty("OrganisationSettingLogo_GXI", gxTpr_Organisationsettinglogo_gxi, false);



			AddObjectProperty("OrganisationSettingFavicon", gxTpr_Organisationsettingfavicon, false);
			AddObjectProperty("OrganisationSettingFavicon_GXI", gxTpr_Organisationsettingfavicon_gxi, false);



			AddObjectProperty("OrganisationSettingBaseColor", gxTpr_Organisationsettingbasecolor, false);


			AddObjectProperty("OrganisationSettingFontSize", gxTpr_Organisationsettingfontsize, false);


			AddObjectProperty("OrganisationSettingLanguage", gxTpr_Organisationsettinglanguage, false);


			AddObjectProperty("OrganisationSettingTrnMode", gxTpr_Organisationsettingtrnmode, false);


			AddObjectProperty("OrganisationHasMyCare", gxTpr_Organisationhasmycare, false);


			AddObjectProperty("OrganisationHasMyServices", gxTpr_Organisationhasmyservices, false);


			AddObjectProperty("OrganisationHasDynamicForms", gxTpr_Organisationhasdynamicforms, false);


			AddObjectProperty("OrganisationHasMyLiving", gxTpr_Organisationhasmyliving, false);


			AddObjectProperty("OrganisationBrandTheme", gxTpr_Organisationbrandtheme, false);


			AddObjectProperty("OrganisationCtaTheme", gxTpr_Organisationctatheme, false);


			AddObjectProperty("ManagerId", gxTpr_Managerid, false);


			AddObjectProperty("ManagerIsMainManager", gxTpr_Managerismainmanager, false);


			AddObjectProperty("ManagerIsActive", gxTpr_Managerisactive, false);


			AddObjectProperty("ReceptionistId", gxTpr_Receptionistid, false);


			AddObjectProperty("ReceptionistIsActive", gxTpr_Receptionistisactive, false);


			AddObjectProperty("ResidentId", gxTpr_Residentid, false);

			if (gxTv_SdtWWPContext_Filtereddashboarditems != null)
			{
				AddObjectProperty("FilteredDashboardItems", gxTv_SdtWWPContext_Filtereddashboarditems, false);
			}

			AddObjectProperty("FooterText", gxTpr_Footertext, false);


			AddObjectProperty("IsContextSet", gxTpr_Iscontextset, false);


			AddObjectProperty("ProfileUrl", gxTpr_Profileurl, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="GAMUserGUID")]
		[XmlElement(ElementName="GAMUserGUID")]
		public string gxTpr_Gamuserguid
		{
			get {
				return gxTv_SdtWWPContext_Gamuserguid; 
			}
			set {
				gxTv_SdtWWPContext_Gamuserguid = value;
				SetDirty("Gamuserguid");
			}
		}




		[SoapElement(ElementName="GAMUserName")]
		[XmlElement(ElementName="GAMUserName")]
		public string gxTpr_Gamusername
		{
			get {
				return gxTv_SdtWWPContext_Gamusername; 
			}
			set {
				gxTv_SdtWWPContext_Gamusername = value;
				SetDirty("Gamusername");
			}
		}




		[SoapElement(ElementName="GAMUserFirstName")]
		[XmlElement(ElementName="GAMUserFirstName")]
		public string gxTpr_Gamuserfirstname
		{
			get {
				return gxTv_SdtWWPContext_Gamuserfirstname; 
			}
			set {
				gxTv_SdtWWPContext_Gamuserfirstname = value;
				SetDirty("Gamuserfirstname");
			}
		}




		[SoapElement(ElementName="GAMUserLastName")]
		[XmlElement(ElementName="GAMUserLastName")]
		public string gxTpr_Gamuserlastname
		{
			get {
				return gxTv_SdtWWPContext_Gamuserlastname; 
			}
			set {
				gxTv_SdtWWPContext_Gamuserlastname = value;
				SetDirty("Gamuserlastname");
			}
		}




		[SoapElement(ElementName="GAMUserEmail")]
		[XmlElement(ElementName="GAMUserEmail")]
		public string gxTpr_Gamuseremail
		{
			get {
				return gxTv_SdtWWPContext_Gamuseremail; 
			}
			set {
				gxTv_SdtWWPContext_Gamuseremail = value;
				SetDirty("Gamuseremail");
			}
		}




		[SoapElement(ElementName="GAMUserPhone")]
		[XmlElement(ElementName="GAMUserPhone")]
		public string gxTpr_Gamuserphone
		{
			get {
				return gxTv_SdtWWPContext_Gamuserphone; 
			}
			set {
				gxTv_SdtWWPContext_Gamuserphone = value;
				SetDirty("Gamuserphone");
			}
		}




		[SoapElement(ElementName="isComfortaAdmin")]
		[XmlElement(ElementName="isComfortaAdmin")]
		public bool gxTpr_Iscomfortaadmin
		{
			get {
				return gxTv_SdtWWPContext_Iscomfortaadmin; 
			}
			set {
				gxTv_SdtWWPContext_Iscomfortaadmin = value;
				SetDirty("Iscomfortaadmin");
			}
		}




		[SoapElement(ElementName="isOrganisationManager")]
		[XmlElement(ElementName="isOrganisationManager")]
		public bool gxTpr_Isorganisationmanager
		{
			get {
				return gxTv_SdtWWPContext_Isorganisationmanager; 
			}
			set {
				gxTv_SdtWWPContext_Isorganisationmanager = value;
				SetDirty("Isorganisationmanager");
			}
		}




		[SoapElement(ElementName="isReceptionist")]
		[XmlElement(ElementName="isReceptionist")]
		public bool gxTpr_Isreceptionist
		{
			get {
				return gxTv_SdtWWPContext_Isreceptionist; 
			}
			set {
				gxTv_SdtWWPContext_Isreceptionist = value;
				SetDirty("Isreceptionist");
			}
		}




		[SoapElement(ElementName="isResident")]
		[XmlElement(ElementName="isResident")]
		public bool gxTpr_Isresident
		{
			get {
				return gxTv_SdtWWPContext_Isresident; 
			}
			set {
				gxTv_SdtWWPContext_Isresident = value;
				SetDirty("Isresident");
			}
		}




		[SoapElement(ElementName="isRootAdmin")]
		[XmlElement(ElementName="isRootAdmin")]
		public bool gxTpr_Isrootadmin
		{
			get {
				return gxTv_SdtWWPContext_Isrootadmin; 
			}
			set {
				gxTv_SdtWWPContext_Isrootadmin = value;
				SetDirty("Isrootadmin");
			}
		}




		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtWWPContext_Organisationid; 
			}
			set {
				gxTv_SdtWWPContext_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="OrganisationName")]
		[XmlElement(ElementName="OrganisationName")]
		public string gxTpr_Organisationname
		{
			get {
				return gxTv_SdtWWPContext_Organisationname; 
			}
			set {
				gxTv_SdtWWPContext_Organisationname = value;
				SetDirty("Organisationname");
			}
		}




		[SoapElement(ElementName="OrganisationTypeId")]
		[XmlElement(ElementName="OrganisationTypeId")]
		public Guid gxTpr_Organisationtypeid
		{
			get {
				return gxTv_SdtWWPContext_Organisationtypeid; 
			}
			set {
				gxTv_SdtWWPContext_Organisationtypeid = value;
				SetDirty("Organisationtypeid");
			}
		}




		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtWWPContext_Locationid; 
			}
			set {
				gxTv_SdtWWPContext_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="LocationName")]
		[XmlElement(ElementName="LocationName")]
		public string gxTpr_Locationname
		{
			get {
				return gxTv_SdtWWPContext_Locationname; 
			}
			set {
				gxTv_SdtWWPContext_Locationname = value;
				SetDirty("Locationname");
			}
		}




		[SoapElement(ElementName="OrganisationSettingid")]
		[XmlElement(ElementName="OrganisationSettingid")]
		public Guid gxTpr_Organisationsettingid
		{
			get {
				return gxTv_SdtWWPContext_Organisationsettingid; 
			}
			set {
				gxTv_SdtWWPContext_Organisationsettingid = value;
				SetDirty("Organisationsettingid");
			}
		}




		[SoapElement(ElementName="OrganisationSettingLogo")]
		[XmlElement(ElementName="OrganisationSettingLogo")]
		[GxUpload()]

		public string gxTpr_Organisationsettinglogo
		{
			get {
				return gxTv_SdtWWPContext_Organisationsettinglogo; 
			}
			set {
				gxTv_SdtWWPContext_Organisationsettinglogo = value;
				SetDirty("Organisationsettinglogo");
			}
		}


		[SoapElement(ElementName="OrganisationSettingLogo_GXI" )]
		[XmlElement(ElementName="OrganisationSettingLogo_GXI" )]
		public string gxTpr_Organisationsettinglogo_gxi
		{
			get {
				return gxTv_SdtWWPContext_Organisationsettinglogo_gxi ;
			}
			set {
				gxTv_SdtWWPContext_Organisationsettinglogo_gxi = value;
				SetDirty("Organisationsettinglogo_gxi");
			}
		}

		[SoapElement(ElementName="OrganisationSettingFavicon")]
		[XmlElement(ElementName="OrganisationSettingFavicon")]
		[GxUpload()]

		public string gxTpr_Organisationsettingfavicon
		{
			get {
				return gxTv_SdtWWPContext_Organisationsettingfavicon; 
			}
			set {
				gxTv_SdtWWPContext_Organisationsettingfavicon = value;
				SetDirty("Organisationsettingfavicon");
			}
		}


		[SoapElement(ElementName="OrganisationSettingFavicon_GXI" )]
		[XmlElement(ElementName="OrganisationSettingFavicon_GXI" )]
		public string gxTpr_Organisationsettingfavicon_gxi
		{
			get {
				return gxTv_SdtWWPContext_Organisationsettingfavicon_gxi ;
			}
			set {
				gxTv_SdtWWPContext_Organisationsettingfavicon_gxi = value;
				SetDirty("Organisationsettingfavicon_gxi");
			}
		}

		[SoapElement(ElementName="OrganisationSettingBaseColor")]
		[XmlElement(ElementName="OrganisationSettingBaseColor")]
		public string gxTpr_Organisationsettingbasecolor
		{
			get {
				return gxTv_SdtWWPContext_Organisationsettingbasecolor; 
			}
			set {
				gxTv_SdtWWPContext_Organisationsettingbasecolor = value;
				SetDirty("Organisationsettingbasecolor");
			}
		}




		[SoapElement(ElementName="OrganisationSettingFontSize")]
		[XmlElement(ElementName="OrganisationSettingFontSize")]
		public string gxTpr_Organisationsettingfontsize
		{
			get {
				return gxTv_SdtWWPContext_Organisationsettingfontsize; 
			}
			set {
				gxTv_SdtWWPContext_Organisationsettingfontsize = value;
				SetDirty("Organisationsettingfontsize");
			}
		}




		[SoapElement(ElementName="OrganisationSettingLanguage")]
		[XmlElement(ElementName="OrganisationSettingLanguage")]
		public string gxTpr_Organisationsettinglanguage
		{
			get {
				return gxTv_SdtWWPContext_Organisationsettinglanguage; 
			}
			set {
				gxTv_SdtWWPContext_Organisationsettinglanguage = value;
				SetDirty("Organisationsettinglanguage");
			}
		}




		[SoapElement(ElementName="OrganisationSettingTrnMode")]
		[XmlElement(ElementName="OrganisationSettingTrnMode")]
		public string gxTpr_Organisationsettingtrnmode
		{
			get {
				return gxTv_SdtWWPContext_Organisationsettingtrnmode; 
			}
			set {
				gxTv_SdtWWPContext_Organisationsettingtrnmode = value;
				SetDirty("Organisationsettingtrnmode");
			}
		}




		[SoapElement(ElementName="OrganisationHasMyCare")]
		[XmlElement(ElementName="OrganisationHasMyCare")]
		public bool gxTpr_Organisationhasmycare
		{
			get {
				return gxTv_SdtWWPContext_Organisationhasmycare; 
			}
			set {
				gxTv_SdtWWPContext_Organisationhasmycare = value;
				SetDirty("Organisationhasmycare");
			}
		}




		[SoapElement(ElementName="OrganisationHasMyServices")]
		[XmlElement(ElementName="OrganisationHasMyServices")]
		public bool gxTpr_Organisationhasmyservices
		{
			get {
				return gxTv_SdtWWPContext_Organisationhasmyservices; 
			}
			set {
				gxTv_SdtWWPContext_Organisationhasmyservices = value;
				SetDirty("Organisationhasmyservices");
			}
		}




		[SoapElement(ElementName="OrganisationHasDynamicForms")]
		[XmlElement(ElementName="OrganisationHasDynamicForms")]
		public bool gxTpr_Organisationhasdynamicforms
		{
			get {
				return gxTv_SdtWWPContext_Organisationhasdynamicforms; 
			}
			set {
				gxTv_SdtWWPContext_Organisationhasdynamicforms = value;
				SetDirty("Organisationhasdynamicforms");
			}
		}




		[SoapElement(ElementName="OrganisationHasMyLiving")]
		[XmlElement(ElementName="OrganisationHasMyLiving")]
		public bool gxTpr_Organisationhasmyliving
		{
			get {
				return gxTv_SdtWWPContext_Organisationhasmyliving; 
			}
			set {
				gxTv_SdtWWPContext_Organisationhasmyliving = value;
				SetDirty("Organisationhasmyliving");
			}
		}




		[SoapElement(ElementName="OrganisationBrandTheme")]
		[XmlElement(ElementName="OrganisationBrandTheme")]
		public string gxTpr_Organisationbrandtheme
		{
			get {
				return gxTv_SdtWWPContext_Organisationbrandtheme; 
			}
			set {
				gxTv_SdtWWPContext_Organisationbrandtheme = value;
				SetDirty("Organisationbrandtheme");
			}
		}




		[SoapElement(ElementName="OrganisationCtaTheme")]
		[XmlElement(ElementName="OrganisationCtaTheme")]
		public string gxTpr_Organisationctatheme
		{
			get {
				return gxTv_SdtWWPContext_Organisationctatheme; 
			}
			set {
				gxTv_SdtWWPContext_Organisationctatheme = value;
				SetDirty("Organisationctatheme");
			}
		}




		[SoapElement(ElementName="ManagerId")]
		[XmlElement(ElementName="ManagerId")]
		public Guid gxTpr_Managerid
		{
			get {
				return gxTv_SdtWWPContext_Managerid; 
			}
			set {
				gxTv_SdtWWPContext_Managerid = value;
				SetDirty("Managerid");
			}
		}




		[SoapElement(ElementName="ManagerIsMainManager")]
		[XmlElement(ElementName="ManagerIsMainManager")]
		public bool gxTpr_Managerismainmanager
		{
			get {
				return gxTv_SdtWWPContext_Managerismainmanager; 
			}
			set {
				gxTv_SdtWWPContext_Managerismainmanager = value;
				SetDirty("Managerismainmanager");
			}
		}




		[SoapElement(ElementName="ManagerIsActive")]
		[XmlElement(ElementName="ManagerIsActive")]
		public bool gxTpr_Managerisactive
		{
			get {
				return gxTv_SdtWWPContext_Managerisactive; 
			}
			set {
				gxTv_SdtWWPContext_Managerisactive = value;
				SetDirty("Managerisactive");
			}
		}




		[SoapElement(ElementName="ReceptionistId")]
		[XmlElement(ElementName="ReceptionistId")]
		public Guid gxTpr_Receptionistid
		{
			get {
				return gxTv_SdtWWPContext_Receptionistid; 
			}
			set {
				gxTv_SdtWWPContext_Receptionistid = value;
				SetDirty("Receptionistid");
			}
		}




		[SoapElement(ElementName="ReceptionistIsActive")]
		[XmlElement(ElementName="ReceptionistIsActive")]
		public bool gxTpr_Receptionistisactive
		{
			get {
				return gxTv_SdtWWPContext_Receptionistisactive; 
			}
			set {
				gxTv_SdtWWPContext_Receptionistisactive = value;
				SetDirty("Receptionistisactive");
			}
		}




		[SoapElement(ElementName="ResidentId")]
		[XmlElement(ElementName="ResidentId")]
		public Guid gxTpr_Residentid
		{
			get {
				return gxTv_SdtWWPContext_Residentid; 
			}
			set {
				gxTv_SdtWWPContext_Residentid = value;
				SetDirty("Residentid");
			}
		}




		[SoapElement(ElementName="FilteredDashboardItems" )]
		[XmlArray(ElementName="FilteredDashboardItems"  )]
		[XmlArrayItemAttribute(ElementName="UHomeModulesSDTItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtUHomeModulesSDT_UHomeModulesSDTItem> gxTpr_Filtereddashboarditems_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWWPContext_Filtereddashboarditems == null )
				{
					gxTv_SdtWWPContext_Filtereddashboarditems = new GXBaseCollection<GeneXus.Programs.SdtUHomeModulesSDT_UHomeModulesSDTItem>( context, "UHomeModulesSDT", "");
				}
				return gxTv_SdtWWPContext_Filtereddashboarditems;
			}
			set {
				gxTv_SdtWWPContext_Filtereddashboarditems_N = false;
				gxTv_SdtWWPContext_Filtereddashboarditems = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtUHomeModulesSDT_UHomeModulesSDTItem> gxTpr_Filtereddashboarditems
		{
			get {
				if ( gxTv_SdtWWPContext_Filtereddashboarditems == null )
				{
					gxTv_SdtWWPContext_Filtereddashboarditems = new GXBaseCollection<GeneXus.Programs.SdtUHomeModulesSDT_UHomeModulesSDTItem>( context, "UHomeModulesSDT", "");
				}
				gxTv_SdtWWPContext_Filtereddashboarditems_N = false;
				return gxTv_SdtWWPContext_Filtereddashboarditems ;
			}
			set {
				gxTv_SdtWWPContext_Filtereddashboarditems_N = false;
				gxTv_SdtWWPContext_Filtereddashboarditems = value;
				SetDirty("Filtereddashboarditems");
			}
		}

		public void gxTv_SdtWWPContext_Filtereddashboarditems_SetNull()
		{
			gxTv_SdtWWPContext_Filtereddashboarditems_N = true;
			gxTv_SdtWWPContext_Filtereddashboarditems = null;
		}

		public bool gxTv_SdtWWPContext_Filtereddashboarditems_IsNull()
		{
			return gxTv_SdtWWPContext_Filtereddashboarditems == null;
		}
		public bool ShouldSerializegxTpr_Filtereddashboarditems_GXBaseCollection_Json()
		{
			return gxTv_SdtWWPContext_Filtereddashboarditems != null && gxTv_SdtWWPContext_Filtereddashboarditems.Count > 0;

		}


		[SoapElement(ElementName="FooterText")]
		[XmlElement(ElementName="FooterText")]
		public string gxTpr_Footertext
		{
			get {
				return gxTv_SdtWWPContext_Footertext; 
			}
			set {
				gxTv_SdtWWPContext_Footertext = value;
				SetDirty("Footertext");
			}
		}




		[SoapElement(ElementName="IsContextSet")]
		[XmlElement(ElementName="IsContextSet")]
		public bool gxTpr_Iscontextset
		{
			get {
				return gxTv_SdtWWPContext_Iscontextset; 
			}
			set {
				gxTv_SdtWWPContext_Iscontextset = value;
				SetDirty("Iscontextset");
			}
		}




		[SoapElement(ElementName="ProfileUrl")]
		[XmlElement(ElementName="ProfileUrl")]
		public string gxTpr_Profileurl
		{
			get {
				return gxTv_SdtWWPContext_Profileurl; 
			}
			set {
				gxTv_SdtWWPContext_Profileurl = value;
				SetDirty("Profileurl");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Static Type Properties

		[XmlIgnore]
		private static GXTypeInfo _typeProps;
		protected override GXTypeInfo TypeInfo { get { return _typeProps; } set { _typeProps = value; } }

		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtWWPContext_Gamuserguid = "";
			gxTv_SdtWWPContext_Gamusername = "";
			gxTv_SdtWWPContext_Gamuserfirstname = "";
			gxTv_SdtWWPContext_Gamuserlastname = "";
			gxTv_SdtWWPContext_Gamuseremail = "";
			gxTv_SdtWWPContext_Gamuserphone = "";
			gxTv_SdtWWPContext_Iscomfortaadmin = false;
			gxTv_SdtWWPContext_Isorganisationmanager = false;
			gxTv_SdtWWPContext_Isreceptionist = false;
			gxTv_SdtWWPContext_Isresident = false;
			gxTv_SdtWWPContext_Isrootadmin = false;

			gxTv_SdtWWPContext_Organisationname = "";


			gxTv_SdtWWPContext_Locationname = "";

			gxTv_SdtWWPContext_Organisationsettinglogo = "";gxTv_SdtWWPContext_Organisationsettinglogo_gxi = "";
			gxTv_SdtWWPContext_Organisationsettingfavicon = "";gxTv_SdtWWPContext_Organisationsettingfavicon_gxi = "";
			gxTv_SdtWWPContext_Organisationsettingbasecolor = "";
			gxTv_SdtWWPContext_Organisationsettingfontsize = "";
			gxTv_SdtWWPContext_Organisationsettinglanguage = "";
			gxTv_SdtWWPContext_Organisationsettingtrnmode = "";




			gxTv_SdtWWPContext_Organisationbrandtheme = "";
			gxTv_SdtWWPContext_Organisationctatheme = "";

			gxTv_SdtWWPContext_Managerismainmanager = false;





			gxTv_SdtWWPContext_Filtereddashboarditems_N = true;

			gxTv_SdtWWPContext_Footertext = "";
			gxTv_SdtWWPContext_Iscontextset = false;
			gxTv_SdtWWPContext_Profileurl = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtWWPContext_Gamuserguid;
		 

		protected string gxTv_SdtWWPContext_Gamusername;
		 

		protected string gxTv_SdtWWPContext_Gamuserfirstname;
		 

		protected string gxTv_SdtWWPContext_Gamuserlastname;
		 

		protected string gxTv_SdtWWPContext_Gamuseremail;
		 

		protected string gxTv_SdtWWPContext_Gamuserphone;
		 

		protected bool gxTv_SdtWWPContext_Iscomfortaadmin;
		 

		protected bool gxTv_SdtWWPContext_Isorganisationmanager;
		 

		protected bool gxTv_SdtWWPContext_Isreceptionist;
		 

		protected bool gxTv_SdtWWPContext_Isresident;
		 

		protected bool gxTv_SdtWWPContext_Isrootadmin;
		 

		protected Guid gxTv_SdtWWPContext_Organisationid;
		 

		protected string gxTv_SdtWWPContext_Organisationname;
		 

		protected Guid gxTv_SdtWWPContext_Organisationtypeid;
		 

		protected Guid gxTv_SdtWWPContext_Locationid;
		 

		protected string gxTv_SdtWWPContext_Locationname;
		 

		protected Guid gxTv_SdtWWPContext_Organisationsettingid;
		 
		protected string gxTv_SdtWWPContext_Organisationsettinglogo_gxi;
		protected string gxTv_SdtWWPContext_Organisationsettinglogo;
		 
		protected string gxTv_SdtWWPContext_Organisationsettingfavicon_gxi;
		protected string gxTv_SdtWWPContext_Organisationsettingfavicon;
		 

		protected string gxTv_SdtWWPContext_Organisationsettingbasecolor;
		 

		protected string gxTv_SdtWWPContext_Organisationsettingfontsize;
		 

		protected string gxTv_SdtWWPContext_Organisationsettinglanguage;
		 

		protected string gxTv_SdtWWPContext_Organisationsettingtrnmode;
		 

		protected bool gxTv_SdtWWPContext_Organisationhasmycare;
		 

		protected bool gxTv_SdtWWPContext_Organisationhasmyservices;
		 

		protected bool gxTv_SdtWWPContext_Organisationhasdynamicforms;
		 

		protected bool gxTv_SdtWWPContext_Organisationhasmyliving;
		 

		protected string gxTv_SdtWWPContext_Organisationbrandtheme;
		 

		protected string gxTv_SdtWWPContext_Organisationctatheme;
		 

		protected Guid gxTv_SdtWWPContext_Managerid;
		 

		protected bool gxTv_SdtWWPContext_Managerismainmanager;
		 

		protected bool gxTv_SdtWWPContext_Managerisactive;
		 

		protected Guid gxTv_SdtWWPContext_Receptionistid;
		 

		protected bool gxTv_SdtWWPContext_Receptionistisactive;
		 

		protected Guid gxTv_SdtWWPContext_Residentid;
		 
		protected bool gxTv_SdtWWPContext_Filtereddashboarditems_N;
		protected GXBaseCollection<GeneXus.Programs.SdtUHomeModulesSDT_UHomeModulesSDTItem> gxTv_SdtWWPContext_Filtereddashboarditems = null;  

		protected string gxTv_SdtWWPContext_Footertext;
		 

		protected bool gxTv_SdtWWPContext_Iscontextset;
		 

		protected string gxTv_SdtWWPContext_Profileurl;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WWPContext", Namespace="Comforta_version2")]
	public class SdtWWPContext_RESTInterface : GxGenericCollectionItem<SdtWWPContext>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWWPContext_RESTInterface( ) : base()
		{	
		}

		public SdtWWPContext_RESTInterface( SdtWWPContext psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="GAMUserGUID", Order=0)]
		public  string gxTpr_Gamuserguid
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Gamuserguid);

			}
			set { 
				 sdt.gxTpr_Gamuserguid = value;
			}
		}

		[DataMember(Name="GAMUserName", Order=1)]
		public  string gxTpr_Gamusername
		{
			get { 
				return sdt.gxTpr_Gamusername;

			}
			set { 
				 sdt.gxTpr_Gamusername = value;
			}
		}

		[DataMember(Name="GAMUserFirstName", Order=2)]
		public  string gxTpr_Gamuserfirstname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Gamuserfirstname);

			}
			set { 
				 sdt.gxTpr_Gamuserfirstname = value;
			}
		}

		[DataMember(Name="GAMUserLastName", Order=3)]
		public  string gxTpr_Gamuserlastname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Gamuserlastname);

			}
			set { 
				 sdt.gxTpr_Gamuserlastname = value;
			}
		}

		[DataMember(Name="GAMUserEmail", Order=4)]
		public  string gxTpr_Gamuseremail
		{
			get { 
				return sdt.gxTpr_Gamuseremail;

			}
			set { 
				 sdt.gxTpr_Gamuseremail = value;
			}
		}

		[DataMember(Name="GAMUserPhone", Order=5)]
		public  string gxTpr_Gamuserphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Gamuserphone);

			}
			set { 
				 sdt.gxTpr_Gamuserphone = value;
			}
		}

		[DataMember(Name="isComfortaAdmin", Order=6)]
		public bool gxTpr_Iscomfortaadmin
		{
			get { 
				return sdt.gxTpr_Iscomfortaadmin;

			}
			set { 
				sdt.gxTpr_Iscomfortaadmin = value;
			}
		}

		[DataMember(Name="isOrganisationManager", Order=7)]
		public bool gxTpr_Isorganisationmanager
		{
			get { 
				return sdt.gxTpr_Isorganisationmanager;

			}
			set { 
				sdt.gxTpr_Isorganisationmanager = value;
			}
		}

		[DataMember(Name="isReceptionist", Order=8)]
		public bool gxTpr_Isreceptionist
		{
			get { 
				return sdt.gxTpr_Isreceptionist;

			}
			set { 
				sdt.gxTpr_Isreceptionist = value;
			}
		}

		[DataMember(Name="isResident", Order=9)]
		public bool gxTpr_Isresident
		{
			get { 
				return sdt.gxTpr_Isresident;

			}
			set { 
				sdt.gxTpr_Isresident = value;
			}
		}

		[DataMember(Name="isRootAdmin", Order=10)]
		public bool gxTpr_Isrootadmin
		{
			get { 
				return sdt.gxTpr_Isrootadmin;

			}
			set { 
				sdt.gxTpr_Isrootadmin = value;
			}
		}

		[DataMember(Name="OrganisationId", Order=11)]
		public Guid gxTpr_Organisationid
		{
			get { 
				return sdt.gxTpr_Organisationid;

			}
			set { 
				sdt.gxTpr_Organisationid = value;
			}
		}

		[DataMember(Name="OrganisationName", Order=12)]
		public  string gxTpr_Organisationname
		{
			get { 
				return sdt.gxTpr_Organisationname;

			}
			set { 
				 sdt.gxTpr_Organisationname = value;
			}
		}

		[DataMember(Name="OrganisationTypeId", Order=13)]
		public Guid gxTpr_Organisationtypeid
		{
			get { 
				return sdt.gxTpr_Organisationtypeid;

			}
			set { 
				sdt.gxTpr_Organisationtypeid = value;
			}
		}

		[DataMember(Name="LocationId", Order=14)]
		public Guid gxTpr_Locationid
		{
			get { 
				return sdt.gxTpr_Locationid;

			}
			set { 
				sdt.gxTpr_Locationid = value;
			}
		}

		[DataMember(Name="LocationName", Order=15)]
		public  string gxTpr_Locationname
		{
			get { 
				return sdt.gxTpr_Locationname;

			}
			set { 
				 sdt.gxTpr_Locationname = value;
			}
		}

		[DataMember(Name="OrganisationSettingid", Order=16)]
		public Guid gxTpr_Organisationsettingid
		{
			get { 
				return sdt.gxTpr_Organisationsettingid;

			}
			set { 
				sdt.gxTpr_Organisationsettingid = value;
			}
		}

		[DataMember(Name="OrganisationSettingLogo", Order=17)]
		[GxUpload()]
		public  string gxTpr_Organisationsettinglogo
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Organisationsettinglogo)) ? PathUtil.RelativePath( sdt.gxTpr_Organisationsettinglogo) : StringUtil.RTrim( sdt.gxTpr_Organisationsettinglogo_gxi));

			}
			set { 
				 sdt.gxTpr_Organisationsettinglogo = value;
			}
		}

		[DataMember(Name="OrganisationSettingFavicon", Order=18)]
		[GxUpload()]
		public  string gxTpr_Organisationsettingfavicon
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Organisationsettingfavicon)) ? PathUtil.RelativePath( sdt.gxTpr_Organisationsettingfavicon) : StringUtil.RTrim( sdt.gxTpr_Organisationsettingfavicon_gxi));

			}
			set { 
				 sdt.gxTpr_Organisationsettingfavicon = value;
			}
		}

		[DataMember(Name="OrganisationSettingBaseColor", Order=19)]
		public  string gxTpr_Organisationsettingbasecolor
		{
			get { 
				return sdt.gxTpr_Organisationsettingbasecolor;

			}
			set { 
				 sdt.gxTpr_Organisationsettingbasecolor = value;
			}
		}

		[DataMember(Name="OrganisationSettingFontSize", Order=20)]
		public  string gxTpr_Organisationsettingfontsize
		{
			get { 
				return sdt.gxTpr_Organisationsettingfontsize;

			}
			set { 
				 sdt.gxTpr_Organisationsettingfontsize = value;
			}
		}

		[DataMember(Name="OrganisationSettingLanguage", Order=21)]
		public  string gxTpr_Organisationsettinglanguage
		{
			get { 
				return sdt.gxTpr_Organisationsettinglanguage;

			}
			set { 
				 sdt.gxTpr_Organisationsettinglanguage = value;
			}
		}

		[DataMember(Name="OrganisationSettingTrnMode", Order=22)]
		public  string gxTpr_Organisationsettingtrnmode
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Organisationsettingtrnmode);

			}
			set { 
				 sdt.gxTpr_Organisationsettingtrnmode = value;
			}
		}

		[DataMember(Name="OrganisationHasMyCare", Order=23)]
		public bool gxTpr_Organisationhasmycare
		{
			get { 
				return sdt.gxTpr_Organisationhasmycare;

			}
			set { 
				sdt.gxTpr_Organisationhasmycare = value;
			}
		}

		[DataMember(Name="OrganisationHasMyServices", Order=24)]
		public bool gxTpr_Organisationhasmyservices
		{
			get { 
				return sdt.gxTpr_Organisationhasmyservices;

			}
			set { 
				sdt.gxTpr_Organisationhasmyservices = value;
			}
		}

		[DataMember(Name="OrganisationHasDynamicForms", Order=25)]
		public bool gxTpr_Organisationhasdynamicforms
		{
			get { 
				return sdt.gxTpr_Organisationhasdynamicforms;

			}
			set { 
				sdt.gxTpr_Organisationhasdynamicforms = value;
			}
		}

		[DataMember(Name="OrganisationHasMyLiving", Order=26)]
		public bool gxTpr_Organisationhasmyliving
		{
			get { 
				return sdt.gxTpr_Organisationhasmyliving;

			}
			set { 
				sdt.gxTpr_Organisationhasmyliving = value;
			}
		}

		[DataMember(Name="OrganisationBrandTheme", Order=27)]
		public  string gxTpr_Organisationbrandtheme
		{
			get { 
				return sdt.gxTpr_Organisationbrandtheme;

			}
			set { 
				 sdt.gxTpr_Organisationbrandtheme = value;
			}
		}

		[DataMember(Name="OrganisationCtaTheme", Order=28)]
		public  string gxTpr_Organisationctatheme
		{
			get { 
				return sdt.gxTpr_Organisationctatheme;

			}
			set { 
				 sdt.gxTpr_Organisationctatheme = value;
			}
		}

		[DataMember(Name="ManagerId", Order=29)]
		public Guid gxTpr_Managerid
		{
			get { 
				return sdt.gxTpr_Managerid;

			}
			set { 
				sdt.gxTpr_Managerid = value;
			}
		}

		[DataMember(Name="ManagerIsMainManager", Order=30)]
		public bool gxTpr_Managerismainmanager
		{
			get { 
				return sdt.gxTpr_Managerismainmanager;

			}
			set { 
				sdt.gxTpr_Managerismainmanager = value;
			}
		}

		[DataMember(Name="ManagerIsActive", Order=31)]
		public bool gxTpr_Managerisactive
		{
			get { 
				return sdt.gxTpr_Managerisactive;

			}
			set { 
				sdt.gxTpr_Managerisactive = value;
			}
		}

		[DataMember(Name="ReceptionistId", Order=32)]
		public Guid gxTpr_Receptionistid
		{
			get { 
				return sdt.gxTpr_Receptionistid;

			}
			set { 
				sdt.gxTpr_Receptionistid = value;
			}
		}

		[DataMember(Name="ReceptionistIsActive", Order=33)]
		public bool gxTpr_Receptionistisactive
		{
			get { 
				return sdt.gxTpr_Receptionistisactive;

			}
			set { 
				sdt.gxTpr_Receptionistisactive = value;
			}
		}

		[DataMember(Name="ResidentId", Order=34)]
		public Guid gxTpr_Residentid
		{
			get { 
				return sdt.gxTpr_Residentid;

			}
			set { 
				sdt.gxTpr_Residentid = value;
			}
		}

		[DataMember(Name="FilteredDashboardItems", Order=35, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtUHomeModulesSDT_UHomeModulesSDTItem_RESTInterface> gxTpr_Filtereddashboarditems
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Filtereddashboarditems_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtUHomeModulesSDT_UHomeModulesSDTItem_RESTInterface>(sdt.gxTpr_Filtereddashboarditems);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Filtereddashboarditems);
			}
		}

		[DataMember(Name="FooterText", Order=36)]
		public  string gxTpr_Footertext
		{
			get { 
				return sdt.gxTpr_Footertext;

			}
			set { 
				 sdt.gxTpr_Footertext = value;
			}
		}

		[DataMember(Name="IsContextSet", Order=37)]
		public bool gxTpr_Iscontextset
		{
			get { 
				return sdt.gxTpr_Iscontextset;

			}
			set { 
				sdt.gxTpr_Iscontextset = value;
			}
		}

		[DataMember(Name="ProfileUrl", Order=38)]
		public  string gxTpr_Profileurl
		{
			get { 
				return sdt.gxTpr_Profileurl;

			}
			set { 
				 sdt.gxTpr_Profileurl = value;
			}
		}


		#endregion

		public SdtWWPContext sdt
		{
			get { 
				return (SdtWWPContext)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtWWPContext() ;
			}
		}
	}
	#endregion
}