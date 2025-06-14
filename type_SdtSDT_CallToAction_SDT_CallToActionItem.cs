/*
				   File: type_SdtSDT_CallToAction_SDT_CallToActionItem
			Description: SDT_CallToAction
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


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="SDT_CallToActionItem")]
	[XmlType(TypeName="SDT_CallToActionItem" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_CallToAction_SDT_CallToActionItem : GxUserType
	{
		public SdtSDT_CallToAction_SDT_CallToActionItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionname = "";

			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactiontype = "";

			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionphone = "";

			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionphonecode = "";

			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionphonenumber = "";

			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionurl = "";

			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionemail = "";

			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformreferencename = "";

			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformtitle = "";

			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformdate = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformresumemessage = "";

			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformvalidations = "";

			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformsectionrefelements = "";

		}

		public SdtSDT_CallToAction_SDT_CallToActionItem(IGxContext context)
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
			AddObjectProperty("CallToActionId", gxTpr_Calltoactionid, false);


			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("LocationId", gxTpr_Locationid, false);


			AddObjectProperty("ProductServiceId", gxTpr_Productserviceid, false);


			AddObjectProperty("CallToActionName", gxTpr_Calltoactionname, false);


			AddObjectProperty("CallToActionType", gxTpr_Calltoactiontype, false);


			AddObjectProperty("CallToActionPhone", gxTpr_Calltoactionphone, false);


			AddObjectProperty("CallToActionPhoneCode", gxTpr_Calltoactionphonecode, false);


			AddObjectProperty("CallToActionPhoneNumber", gxTpr_Calltoactionphonenumber, false);


			AddObjectProperty("CallToActionUrl", gxTpr_Calltoactionurl, false);


			AddObjectProperty("CallToActionEmail", gxTpr_Calltoactionemail, false);


			AddObjectProperty("LocationDynamicFormId", gxTpr_Locationdynamicformid, false);


			AddObjectProperty("WWPFormId", gxTpr_Wwpformid, false);


			AddObjectProperty("WWPFormVersionNumber", gxTpr_Wwpformversionnumber, false);


			AddObjectProperty("WWPFormReferenceName", gxTpr_Wwpformreferencename, false);


			AddObjectProperty("WWPFormTitle", gxTpr_Wwpformtitle, false);


			datetime_STZ = gxTpr_Wwpformdate;
			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim( StringUtil.Str((decimal)(DateTimeUtil.Month(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "T";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Hour(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Minute(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + ":";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Second(datetime_STZ)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("WWPFormDate", sDateCnv, false);



			AddObjectProperty("WWPFormIsWizard", gxTpr_Wwpformiswizard, false);


			AddObjectProperty("WWPFormResume", gxTpr_Wwpformresume, false);


			AddObjectProperty("WWPFormResumeMessage", gxTpr_Wwpformresumemessage, false);


			AddObjectProperty("WWPFormValidations", gxTpr_Wwpformvalidations, false);


			AddObjectProperty("WWPFormInstantiated", gxTpr_Wwpforminstantiated, false);


			AddObjectProperty("WWPFormLatestVersionNumber", gxTpr_Wwpformlatestversionnumber, false);


			AddObjectProperty("WWPFormType", gxTpr_Wwpformtype, false);


			AddObjectProperty("WWPFormSectionRefElements", gxTpr_Wwpformsectionrefelements, false);


			AddObjectProperty("WWPFormIsForDynamicValidations", gxTpr_Wwpformisfordynamicvalidations, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CallToActionId")]
		[XmlElement(ElementName="CallToActionId")]
		public Guid gxTpr_Calltoactionid
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionid; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionid = value;
				SetDirty("Calltoactionid");
			}
		}




		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Organisationid; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Locationid; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="ProductServiceId")]
		[XmlElement(ElementName="ProductServiceId")]
		public Guid gxTpr_Productserviceid
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Productserviceid; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Productserviceid = value;
				SetDirty("Productserviceid");
			}
		}




		[SoapElement(ElementName="CallToActionName")]
		[XmlElement(ElementName="CallToActionName")]
		public string gxTpr_Calltoactionname
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionname; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionname = value;
				SetDirty("Calltoactionname");
			}
		}




		[SoapElement(ElementName="CallToActionType")]
		[XmlElement(ElementName="CallToActionType")]
		public string gxTpr_Calltoactiontype
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactiontype; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactiontype = value;
				SetDirty("Calltoactiontype");
			}
		}




		[SoapElement(ElementName="CallToActionPhone")]
		[XmlElement(ElementName="CallToActionPhone")]
		public string gxTpr_Calltoactionphone
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionphone; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionphone = value;
				SetDirty("Calltoactionphone");
			}
		}




		[SoapElement(ElementName="CallToActionPhoneCode")]
		[XmlElement(ElementName="CallToActionPhoneCode")]
		public string gxTpr_Calltoactionphonecode
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionphonecode; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionphonecode = value;
				SetDirty("Calltoactionphonecode");
			}
		}




		[SoapElement(ElementName="CallToActionPhoneNumber")]
		[XmlElement(ElementName="CallToActionPhoneNumber")]
		public string gxTpr_Calltoactionphonenumber
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionphonenumber; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionphonenumber = value;
				SetDirty("Calltoactionphonenumber");
			}
		}




		[SoapElement(ElementName="CallToActionUrl")]
		[XmlElement(ElementName="CallToActionUrl")]
		public string gxTpr_Calltoactionurl
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionurl; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionurl = value;
				SetDirty("Calltoactionurl");
			}
		}




		[SoapElement(ElementName="CallToActionEmail")]
		[XmlElement(ElementName="CallToActionEmail")]
		public string gxTpr_Calltoactionemail
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionemail; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionemail = value;
				SetDirty("Calltoactionemail");
			}
		}




		[SoapElement(ElementName="LocationDynamicFormId")]
		[XmlElement(ElementName="LocationDynamicFormId")]
		public Guid gxTpr_Locationdynamicformid
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Locationdynamicformid; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Locationdynamicformid = value;
				SetDirty("Locationdynamicformid");
			}
		}




		[SoapElement(ElementName="WWPFormId")]
		[XmlElement(ElementName="WWPFormId")]
		public short gxTpr_Wwpformid
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformid; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformid = value;
				SetDirty("Wwpformid");
			}
		}




		[SoapElement(ElementName="WWPFormVersionNumber")]
		[XmlElement(ElementName="WWPFormVersionNumber")]
		public short gxTpr_Wwpformversionnumber
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformversionnumber; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformversionnumber = value;
				SetDirty("Wwpformversionnumber");
			}
		}




		[SoapElement(ElementName="WWPFormReferenceName")]
		[XmlElement(ElementName="WWPFormReferenceName")]
		public string gxTpr_Wwpformreferencename
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformreferencename; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformreferencename = value;
				SetDirty("Wwpformreferencename");
			}
		}




		[SoapElement(ElementName="WWPFormTitle")]
		[XmlElement(ElementName="WWPFormTitle")]
		public string gxTpr_Wwpformtitle
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformtitle; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformtitle = value;
				SetDirty("Wwpformtitle");
			}
		}



		[SoapElement(ElementName="WWPFormDate")]
		[XmlElement(ElementName="WWPFormDate" , IsNullable=true)]
		public string gxTpr_Wwpformdate_Nullable
		{
			get {
				if ( gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformdate == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformdate).value ;
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Wwpformdate
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformdate; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformdate = value;
				SetDirty("Wwpformdate");
			}
		}



		[SoapElement(ElementName="WWPFormIsWizard")]
		[XmlElement(ElementName="WWPFormIsWizard")]
		public bool gxTpr_Wwpformiswizard
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformiswizard; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformiswizard = value;
				SetDirty("Wwpformiswizard");
			}
		}




		[SoapElement(ElementName="WWPFormResume")]
		[XmlElement(ElementName="WWPFormResume")]
		public short gxTpr_Wwpformresume
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformresume; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformresume = value;
				SetDirty("Wwpformresume");
			}
		}




		[SoapElement(ElementName="WWPFormResumeMessage")]
		[XmlElement(ElementName="WWPFormResumeMessage")]
		public string gxTpr_Wwpformresumemessage
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformresumemessage; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformresumemessage = value;
				SetDirty("Wwpformresumemessage");
			}
		}




		[SoapElement(ElementName="WWPFormValidations")]
		[XmlElement(ElementName="WWPFormValidations")]
		public string gxTpr_Wwpformvalidations
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformvalidations; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformvalidations = value;
				SetDirty("Wwpformvalidations");
			}
		}




		[SoapElement(ElementName="WWPFormInstantiated")]
		[XmlElement(ElementName="WWPFormInstantiated")]
		public bool gxTpr_Wwpforminstantiated
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpforminstantiated; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpforminstantiated = value;
				SetDirty("Wwpforminstantiated");
			}
		}




		[SoapElement(ElementName="WWPFormLatestVersionNumber")]
		[XmlElement(ElementName="WWPFormLatestVersionNumber")]
		public short gxTpr_Wwpformlatestversionnumber
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformlatestversionnumber; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformlatestversionnumber = value;
				SetDirty("Wwpformlatestversionnumber");
			}
		}




		[SoapElement(ElementName="WWPFormType")]
		[XmlElement(ElementName="WWPFormType")]
		public short gxTpr_Wwpformtype
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformtype; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformtype = value;
				SetDirty("Wwpformtype");
			}
		}




		[SoapElement(ElementName="WWPFormSectionRefElements")]
		[XmlElement(ElementName="WWPFormSectionRefElements")]
		public string gxTpr_Wwpformsectionrefelements
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformsectionrefelements; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformsectionrefelements = value;
				SetDirty("Wwpformsectionrefelements");
			}
		}




		[SoapElement(ElementName="WWPFormIsForDynamicValidations")]
		[XmlElement(ElementName="WWPFormIsForDynamicValidations")]
		public bool gxTpr_Wwpformisfordynamicvalidations
		{
			get {
				return gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformisfordynamicvalidations; 
			}
			set {
				gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformisfordynamicvalidations = value;
				SetDirty("Wwpformisfordynamicvalidations");
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
			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionname = "";
			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactiontype = "";
			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionphone = "";
			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionphonecode = "";
			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionphonenumber = "";
			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionurl = "";
			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionemail = "";



			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformreferencename = "";
			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformtitle = "";
			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformdate = (DateTime)(DateTime.MinValue);


			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformresumemessage = "";
			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformvalidations = "";



			gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformsectionrefelements = "";

			datetime_STZ = (DateTime)(DateTime.MinValue);
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected DateTime datetime_STZ ;

		protected Guid gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionid;
		 

		protected Guid gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Organisationid;
		 

		protected Guid gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Locationid;
		 

		protected Guid gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Productserviceid;
		 

		protected string gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionname;
		 

		protected string gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactiontype;
		 

		protected string gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionphone;
		 

		protected string gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionphonecode;
		 

		protected string gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionphonenumber;
		 

		protected string gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionurl;
		 

		protected string gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Calltoactionemail;
		 

		protected Guid gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Locationdynamicformid;
		 

		protected short gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformid;
		 

		protected short gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformversionnumber;
		 

		protected string gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformreferencename;
		 

		protected string gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformtitle;
		 

		protected DateTime gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformdate;
		 

		protected bool gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformiswizard;
		 

		protected short gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformresume;
		 

		protected string gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformresumemessage;
		 

		protected string gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformvalidations;
		 

		protected bool gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpforminstantiated;
		 

		protected short gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformlatestversionnumber;
		 

		protected short gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformtype;
		 

		protected string gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformsectionrefelements;
		 

		protected bool gxTv_SdtSDT_CallToAction_SDT_CallToActionItem_Wwpformisfordynamicvalidations;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_CallToActionItem", Namespace="Comforta_version21")]
	public class SdtSDT_CallToAction_SDT_CallToActionItem_RESTInterface : GxGenericCollectionItem<SdtSDT_CallToAction_SDT_CallToActionItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_CallToAction_SDT_CallToActionItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_CallToAction_SDT_CallToActionItem_RESTInterface( SdtSDT_CallToAction_SDT_CallToActionItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CallToActionId", Order=0)]
		public Guid gxTpr_Calltoactionid
		{
			get { 
				return sdt.gxTpr_Calltoactionid;

			}
			set { 
				sdt.gxTpr_Calltoactionid = value;
			}
		}

		[DataMember(Name="OrganisationId", Order=1)]
		public Guid gxTpr_Organisationid
		{
			get { 
				return sdt.gxTpr_Organisationid;

			}
			set { 
				sdt.gxTpr_Organisationid = value;
			}
		}

		[DataMember(Name="LocationId", Order=2)]
		public Guid gxTpr_Locationid
		{
			get { 
				return sdt.gxTpr_Locationid;

			}
			set { 
				sdt.gxTpr_Locationid = value;
			}
		}

		[DataMember(Name="ProductServiceId", Order=3)]
		public Guid gxTpr_Productserviceid
		{
			get { 
				return sdt.gxTpr_Productserviceid;

			}
			set { 
				sdt.gxTpr_Productserviceid = value;
			}
		}

		[DataMember(Name="CallToActionName", Order=4)]
		public  string gxTpr_Calltoactionname
		{
			get { 
				return sdt.gxTpr_Calltoactionname;

			}
			set { 
				 sdt.gxTpr_Calltoactionname = value;
			}
		}

		[DataMember(Name="CallToActionType", Order=5)]
		public  string gxTpr_Calltoactiontype
		{
			get { 
				return sdt.gxTpr_Calltoactiontype;

			}
			set { 
				 sdt.gxTpr_Calltoactiontype = value;
			}
		}

		[DataMember(Name="CallToActionPhone", Order=6)]
		public  string gxTpr_Calltoactionphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Calltoactionphone);

			}
			set { 
				 sdt.gxTpr_Calltoactionphone = value;
			}
		}

		[DataMember(Name="CallToActionPhoneCode", Order=7)]
		public  string gxTpr_Calltoactionphonecode
		{
			get { 
				return sdt.gxTpr_Calltoactionphonecode;

			}
			set { 
				 sdt.gxTpr_Calltoactionphonecode = value;
			}
		}

		[DataMember(Name="CallToActionPhoneNumber", Order=8)]
		public  string gxTpr_Calltoactionphonenumber
		{
			get { 
				return sdt.gxTpr_Calltoactionphonenumber;

			}
			set { 
				 sdt.gxTpr_Calltoactionphonenumber = value;
			}
		}

		[DataMember(Name="CallToActionUrl", Order=9)]
		public  string gxTpr_Calltoactionurl
		{
			get { 
				return sdt.gxTpr_Calltoactionurl;

			}
			set { 
				 sdt.gxTpr_Calltoactionurl = value;
			}
		}

		[DataMember(Name="CallToActionEmail", Order=10)]
		public  string gxTpr_Calltoactionemail
		{
			get { 
				return sdt.gxTpr_Calltoactionemail;

			}
			set { 
				 sdt.gxTpr_Calltoactionemail = value;
			}
		}

		[DataMember(Name="LocationDynamicFormId", Order=11)]
		public Guid gxTpr_Locationdynamicformid
		{
			get { 
				return sdt.gxTpr_Locationdynamicformid;

			}
			set { 
				sdt.gxTpr_Locationdynamicformid = value;
			}
		}

		[DataMember(Name="WWPFormId", Order=12)]
		public short gxTpr_Wwpformid
		{
			get { 
				return sdt.gxTpr_Wwpformid;

			}
			set { 
				sdt.gxTpr_Wwpformid = value;
			}
		}

		[DataMember(Name="WWPFormVersionNumber", Order=13)]
		public short gxTpr_Wwpformversionnumber
		{
			get { 
				return sdt.gxTpr_Wwpformversionnumber;

			}
			set { 
				sdt.gxTpr_Wwpformversionnumber = value;
			}
		}

		[DataMember(Name="WWPFormReferenceName", Order=14)]
		public  string gxTpr_Wwpformreferencename
		{
			get { 
				return sdt.gxTpr_Wwpformreferencename;

			}
			set { 
				 sdt.gxTpr_Wwpformreferencename = value;
			}
		}

		[DataMember(Name="WWPFormTitle", Order=15)]
		public  string gxTpr_Wwpformtitle
		{
			get { 
				return sdt.gxTpr_Wwpformtitle;

			}
			set { 
				 sdt.gxTpr_Wwpformtitle = value;
			}
		}

		[DataMember(Name="WWPFormDate", Order=16)]
		public  string gxTpr_Wwpformdate
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Wwpformdate,context);

			}
			set { 
				sdt.gxTpr_Wwpformdate = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="WWPFormIsWizard", Order=17)]
		public bool gxTpr_Wwpformiswizard
		{
			get { 
				return sdt.gxTpr_Wwpformiswizard;

			}
			set { 
				sdt.gxTpr_Wwpformiswizard = value;
			}
		}

		[DataMember(Name="WWPFormResume", Order=18)]
		public short gxTpr_Wwpformresume
		{
			get { 
				return sdt.gxTpr_Wwpformresume;

			}
			set { 
				sdt.gxTpr_Wwpformresume = value;
			}
		}

		[DataMember(Name="WWPFormResumeMessage", Order=19)]
		public  string gxTpr_Wwpformresumemessage
		{
			get { 
				return sdt.gxTpr_Wwpformresumemessage;

			}
			set { 
				 sdt.gxTpr_Wwpformresumemessage = value;
			}
		}

		[DataMember(Name="WWPFormValidations", Order=20)]
		public  string gxTpr_Wwpformvalidations
		{
			get { 
				return sdt.gxTpr_Wwpformvalidations;

			}
			set { 
				 sdt.gxTpr_Wwpformvalidations = value;
			}
		}

		[DataMember(Name="WWPFormInstantiated", Order=21)]
		public bool gxTpr_Wwpforminstantiated
		{
			get { 
				return sdt.gxTpr_Wwpforminstantiated;

			}
			set { 
				sdt.gxTpr_Wwpforminstantiated = value;
			}
		}

		[DataMember(Name="WWPFormLatestVersionNumber", Order=22)]
		public short gxTpr_Wwpformlatestversionnumber
		{
			get { 
				return sdt.gxTpr_Wwpformlatestversionnumber;

			}
			set { 
				sdt.gxTpr_Wwpformlatestversionnumber = value;
			}
		}

		[DataMember(Name="WWPFormType", Order=23)]
		public short gxTpr_Wwpformtype
		{
			get { 
				return sdt.gxTpr_Wwpformtype;

			}
			set { 
				sdt.gxTpr_Wwpformtype = value;
			}
		}

		[DataMember(Name="WWPFormSectionRefElements", Order=24)]
		public  string gxTpr_Wwpformsectionrefelements
		{
			get { 
				return sdt.gxTpr_Wwpformsectionrefelements;

			}
			set { 
				 sdt.gxTpr_Wwpformsectionrefelements = value;
			}
		}

		[DataMember(Name="WWPFormIsForDynamicValidations", Order=25)]
		public bool gxTpr_Wwpformisfordynamicvalidations
		{
			get { 
				return sdt.gxTpr_Wwpformisfordynamicvalidations;

			}
			set { 
				sdt.gxTpr_Wwpformisfordynamicvalidations = value;
			}
		}


		#endregion

		public SdtSDT_CallToAction_SDT_CallToActionItem sdt
		{
			get { 
				return (SdtSDT_CallToAction_SDT_CallToActionItem)Sdt;
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
				sdt = new SdtSDT_CallToAction_SDT_CallToActionItem() ;
			}
		}
	}
	#endregion
}