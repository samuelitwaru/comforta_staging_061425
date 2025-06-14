/*
				   File: type_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem
			Description: SDT_LocationDynamicForm
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
	[XmlRoot(ElementName="SDT_LocationDynamicFormItem")]
	[XmlType(TypeName="SDT_LocationDynamicFormItem" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem : GxUserType
	{
		public SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformreferencename = "";

			gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformtitle = "";

			gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformdate = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformresumemessage = "";

			gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformvalidations = "";

			gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformsectionrefelements = "";

		}

		public SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem(IGxContext context)
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
			AddObjectProperty("LocationDynamicFormId", gxTpr_Locationdynamicformid, false);


			AddObjectProperty("OrganisationId", gxTpr_Organisationid, false);


			AddObjectProperty("LocationId", gxTpr_Locationid, false);


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

		[SoapElement(ElementName="LocationDynamicFormId")]
		[XmlElement(ElementName="LocationDynamicFormId")]
		public Guid gxTpr_Locationdynamicformid
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Locationdynamicformid; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Locationdynamicformid = value;
				SetDirty("Locationdynamicformid");
			}
		}




		[SoapElement(ElementName="OrganisationId")]
		[XmlElement(ElementName="OrganisationId")]
		public Guid gxTpr_Organisationid
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Organisationid; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Organisationid = value;
				SetDirty("Organisationid");
			}
		}




		[SoapElement(ElementName="LocationId")]
		[XmlElement(ElementName="LocationId")]
		public Guid gxTpr_Locationid
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Locationid; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Locationid = value;
				SetDirty("Locationid");
			}
		}




		[SoapElement(ElementName="WWPFormId")]
		[XmlElement(ElementName="WWPFormId")]
		public short gxTpr_Wwpformid
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformid; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformid = value;
				SetDirty("Wwpformid");
			}
		}




		[SoapElement(ElementName="WWPFormVersionNumber")]
		[XmlElement(ElementName="WWPFormVersionNumber")]
		public short gxTpr_Wwpformversionnumber
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformversionnumber; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformversionnumber = value;
				SetDirty("Wwpformversionnumber");
			}
		}




		[SoapElement(ElementName="WWPFormReferenceName")]
		[XmlElement(ElementName="WWPFormReferenceName")]
		public string gxTpr_Wwpformreferencename
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformreferencename; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformreferencename = value;
				SetDirty("Wwpformreferencename");
			}
		}




		[SoapElement(ElementName="WWPFormTitle")]
		[XmlElement(ElementName="WWPFormTitle")]
		public string gxTpr_Wwpformtitle
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformtitle; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformtitle = value;
				SetDirty("Wwpformtitle");
			}
		}



		[SoapElement(ElementName="WWPFormDate")]
		[XmlElement(ElementName="WWPFormDate" , IsNullable=true)]
		public string gxTpr_Wwpformdate_Nullable
		{
			get {
				if ( gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformdate == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformdate).value ;
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformdate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Wwpformdate
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformdate; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformdate = value;
				SetDirty("Wwpformdate");
			}
		}



		[SoapElement(ElementName="WWPFormIsWizard")]
		[XmlElement(ElementName="WWPFormIsWizard")]
		public bool gxTpr_Wwpformiswizard
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformiswizard; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformiswizard = value;
				SetDirty("Wwpformiswizard");
			}
		}




		[SoapElement(ElementName="WWPFormResume")]
		[XmlElement(ElementName="WWPFormResume")]
		public short gxTpr_Wwpformresume
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformresume; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformresume = value;
				SetDirty("Wwpformresume");
			}
		}




		[SoapElement(ElementName="WWPFormResumeMessage")]
		[XmlElement(ElementName="WWPFormResumeMessage")]
		public string gxTpr_Wwpformresumemessage
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformresumemessage; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformresumemessage = value;
				SetDirty("Wwpformresumemessage");
			}
		}




		[SoapElement(ElementName="WWPFormValidations")]
		[XmlElement(ElementName="WWPFormValidations")]
		public string gxTpr_Wwpformvalidations
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformvalidations; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformvalidations = value;
				SetDirty("Wwpformvalidations");
			}
		}




		[SoapElement(ElementName="WWPFormInstantiated")]
		[XmlElement(ElementName="WWPFormInstantiated")]
		public bool gxTpr_Wwpforminstantiated
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpforminstantiated; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpforminstantiated = value;
				SetDirty("Wwpforminstantiated");
			}
		}




		[SoapElement(ElementName="WWPFormLatestVersionNumber")]
		[XmlElement(ElementName="WWPFormLatestVersionNumber")]
		public short gxTpr_Wwpformlatestversionnumber
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformlatestversionnumber; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformlatestversionnumber = value;
				SetDirty("Wwpformlatestversionnumber");
			}
		}




		[SoapElement(ElementName="WWPFormType")]
		[XmlElement(ElementName="WWPFormType")]
		public short gxTpr_Wwpformtype
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformtype; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformtype = value;
				SetDirty("Wwpformtype");
			}
		}




		[SoapElement(ElementName="WWPFormSectionRefElements")]
		[XmlElement(ElementName="WWPFormSectionRefElements")]
		public string gxTpr_Wwpformsectionrefelements
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformsectionrefelements; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformsectionrefelements = value;
				SetDirty("Wwpformsectionrefelements");
			}
		}




		[SoapElement(ElementName="WWPFormIsForDynamicValidations")]
		[XmlElement(ElementName="WWPFormIsForDynamicValidations")]
		public bool gxTpr_Wwpformisfordynamicvalidations
		{
			get {
				return gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformisfordynamicvalidations; 
			}
			set {
				gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformisfordynamicvalidations = value;
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
			gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformreferencename = "";
			gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformtitle = "";
			gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformdate = (DateTime)(DateTime.MinValue);


			gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformresumemessage = "";
			gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformvalidations = "";



			gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformsectionrefelements = "";

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

		protected Guid gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Locationdynamicformid;
		 

		protected Guid gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Organisationid;
		 

		protected Guid gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Locationid;
		 

		protected short gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformid;
		 

		protected short gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformversionnumber;
		 

		protected string gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformreferencename;
		 

		protected string gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformtitle;
		 

		protected DateTime gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformdate;
		 

		protected bool gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformiswizard;
		 

		protected short gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformresume;
		 

		protected string gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformresumemessage;
		 

		protected string gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformvalidations;
		 

		protected bool gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpforminstantiated;
		 

		protected short gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformlatestversionnumber;
		 

		protected short gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformtype;
		 

		protected string gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformsectionrefelements;
		 

		protected bool gxTv_SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_Wwpformisfordynamicvalidations;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_LocationDynamicFormItem", Namespace="Comforta_version21")]
	public class SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_RESTInterface : GxGenericCollectionItem<SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem_RESTInterface( SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="LocationDynamicFormId", Order=0)]
		public Guid gxTpr_Locationdynamicformid
		{
			get { 
				return sdt.gxTpr_Locationdynamicformid;

			}
			set { 
				sdt.gxTpr_Locationdynamicformid = value;
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

		[DataMember(Name="WWPFormId", Order=3)]
		public short gxTpr_Wwpformid
		{
			get { 
				return sdt.gxTpr_Wwpformid;

			}
			set { 
				sdt.gxTpr_Wwpformid = value;
			}
		}

		[DataMember(Name="WWPFormVersionNumber", Order=4)]
		public short gxTpr_Wwpformversionnumber
		{
			get { 
				return sdt.gxTpr_Wwpformversionnumber;

			}
			set { 
				sdt.gxTpr_Wwpformversionnumber = value;
			}
		}

		[DataMember(Name="WWPFormReferenceName", Order=5)]
		public  string gxTpr_Wwpformreferencename
		{
			get { 
				return sdt.gxTpr_Wwpformreferencename;

			}
			set { 
				 sdt.gxTpr_Wwpformreferencename = value;
			}
		}

		[DataMember(Name="WWPFormTitle", Order=6)]
		public  string gxTpr_Wwpformtitle
		{
			get { 
				return sdt.gxTpr_Wwpformtitle;

			}
			set { 
				 sdt.gxTpr_Wwpformtitle = value;
			}
		}

		[DataMember(Name="WWPFormDate", Order=7)]
		public  string gxTpr_Wwpformdate
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Wwpformdate,context);

			}
			set { 
				sdt.gxTpr_Wwpformdate = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="WWPFormIsWizard", Order=8)]
		public bool gxTpr_Wwpformiswizard
		{
			get { 
				return sdt.gxTpr_Wwpformiswizard;

			}
			set { 
				sdt.gxTpr_Wwpformiswizard = value;
			}
		}

		[DataMember(Name="WWPFormResume", Order=9)]
		public short gxTpr_Wwpformresume
		{
			get { 
				return sdt.gxTpr_Wwpformresume;

			}
			set { 
				sdt.gxTpr_Wwpformresume = value;
			}
		}

		[DataMember(Name="WWPFormResumeMessage", Order=10)]
		public  string gxTpr_Wwpformresumemessage
		{
			get { 
				return sdt.gxTpr_Wwpformresumemessage;

			}
			set { 
				 sdt.gxTpr_Wwpformresumemessage = value;
			}
		}

		[DataMember(Name="WWPFormValidations", Order=11)]
		public  string gxTpr_Wwpformvalidations
		{
			get { 
				return sdt.gxTpr_Wwpformvalidations;

			}
			set { 
				 sdt.gxTpr_Wwpformvalidations = value;
			}
		}

		[DataMember(Name="WWPFormInstantiated", Order=12)]
		public bool gxTpr_Wwpforminstantiated
		{
			get { 
				return sdt.gxTpr_Wwpforminstantiated;

			}
			set { 
				sdt.gxTpr_Wwpforminstantiated = value;
			}
		}

		[DataMember(Name="WWPFormLatestVersionNumber", Order=13)]
		public short gxTpr_Wwpformlatestversionnumber
		{
			get { 
				return sdt.gxTpr_Wwpformlatestversionnumber;

			}
			set { 
				sdt.gxTpr_Wwpformlatestversionnumber = value;
			}
		}

		[DataMember(Name="WWPFormType", Order=14)]
		public short gxTpr_Wwpformtype
		{
			get { 
				return sdt.gxTpr_Wwpformtype;

			}
			set { 
				sdt.gxTpr_Wwpformtype = value;
			}
		}

		[DataMember(Name="WWPFormSectionRefElements", Order=15)]
		public  string gxTpr_Wwpformsectionrefelements
		{
			get { 
				return sdt.gxTpr_Wwpformsectionrefelements;

			}
			set { 
				 sdt.gxTpr_Wwpformsectionrefelements = value;
			}
		}

		[DataMember(Name="WWPFormIsForDynamicValidations", Order=16)]
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

		public SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem sdt
		{
			get { 
				return (SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem)Sdt;
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
				sdt = new SdtSDT_LocationDynamicForm_SDT_LocationDynamicFormItem() ;
			}
		}
	}
	#endregion
}