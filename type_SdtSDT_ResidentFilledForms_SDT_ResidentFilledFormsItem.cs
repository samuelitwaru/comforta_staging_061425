/*
				   File: type_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem
			Description: SDT_ResidentFilledForms
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
	[XmlRoot(ElementName="SDT_ResidentFilledFormsItem")]
	[XmlType(TypeName="SDT_ResidentFilledFormsItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem : GxUserType
	{
		public SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formreferencename = "";

			gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formtitle = "";

			gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formfilleddate = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formfilledby = "";

		}

		public SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem(IGxContext context)
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
			AddObjectProperty("FormId", gxTpr_Formid, false);


			AddObjectProperty("FormInstanceId", gxTpr_Forminstanceid, false);


			AddObjectProperty("FormReferenceName", gxTpr_Formreferencename, false);


			AddObjectProperty("FormTitle", gxTpr_Formtitle, false);


			datetime_STZ = gxTpr_Formfilleddate;
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
			AddObjectProperty("FormFilledDate", sDateCnv, false);



			AddObjectProperty("FormVersionNumber", gxTpr_Formversionnumber, false);


			AddObjectProperty("FormFilledBy", gxTpr_Formfilledby, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="FormId")]
		[XmlElement(ElementName="FormId")]
		public short gxTpr_Formid
		{
			get {
				return gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formid; 
			}
			set {
				gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formid = value;
				SetDirty("Formid");
			}
		}




		[SoapElement(ElementName="FormInstanceId")]
		[XmlElement(ElementName="FormInstanceId")]
		public short gxTpr_Forminstanceid
		{
			get {
				return gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Forminstanceid; 
			}
			set {
				gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Forminstanceid = value;
				SetDirty("Forminstanceid");
			}
		}




		[SoapElement(ElementName="FormReferenceName")]
		[XmlElement(ElementName="FormReferenceName")]
		public string gxTpr_Formreferencename
		{
			get {
				return gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formreferencename; 
			}
			set {
				gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formreferencename = value;
				SetDirty("Formreferencename");
			}
		}




		[SoapElement(ElementName="FormTitle")]
		[XmlElement(ElementName="FormTitle")]
		public string gxTpr_Formtitle
		{
			get {
				return gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formtitle; 
			}
			set {
				gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formtitle = value;
				SetDirty("Formtitle");
			}
		}



		[SoapElement(ElementName="FormFilledDate")]
		[XmlElement(ElementName="FormFilledDate" , IsNullable=true)]
		public string gxTpr_Formfilleddate_Nullable
		{
			get {
				if ( gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formfilleddate == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formfilleddate).value ;
			}
			set {
				gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formfilleddate = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Formfilleddate
		{
			get {
				return gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formfilleddate; 
			}
			set {
				gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formfilleddate = value;
				SetDirty("Formfilleddate");
			}
		}



		[SoapElement(ElementName="FormVersionNumber")]
		[XmlElement(ElementName="FormVersionNumber")]
		public short gxTpr_Formversionnumber
		{
			get {
				return gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formversionnumber; 
			}
			set {
				gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formversionnumber = value;
				SetDirty("Formversionnumber");
			}
		}




		[SoapElement(ElementName="FormFilledBy")]
		[XmlElement(ElementName="FormFilledBy")]
		public string gxTpr_Formfilledby
		{
			get {
				return gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formfilledby; 
			}
			set {
				gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formfilledby = value;
				SetDirty("Formfilledby");
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
			gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formreferencename = "";
			gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formtitle = "";
			gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formfilleddate = (DateTime)(DateTime.MinValue);

			gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formfilledby = "";
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

		protected short gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formid;
		 

		protected short gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Forminstanceid;
		 

		protected string gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formreferencename;
		 

		protected string gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formtitle;
		 

		protected DateTime gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formfilleddate;
		 

		protected short gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formversionnumber;
		 

		protected string gxTv_SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_Formfilledby;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ResidentFilledFormsItem", Namespace="Comforta_version2")]
	public class SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_RESTInterface : GxGenericCollectionItem<SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem_RESTInterface( SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="FormId", Order=0)]
		public short gxTpr_Formid
		{
			get { 
				return sdt.gxTpr_Formid;

			}
			set { 
				sdt.gxTpr_Formid = value;
			}
		}

		[DataMember(Name="FormInstanceId", Order=1)]
		public short gxTpr_Forminstanceid
		{
			get { 
				return sdt.gxTpr_Forminstanceid;

			}
			set { 
				sdt.gxTpr_Forminstanceid = value;
			}
		}

		[DataMember(Name="FormReferenceName", Order=2)]
		public  string gxTpr_Formreferencename
		{
			get { 
				return sdt.gxTpr_Formreferencename;

			}
			set { 
				 sdt.gxTpr_Formreferencename = value;
			}
		}

		[DataMember(Name="FormTitle", Order=3)]
		public  string gxTpr_Formtitle
		{
			get { 
				return sdt.gxTpr_Formtitle;

			}
			set { 
				 sdt.gxTpr_Formtitle = value;
			}
		}

		[DataMember(Name="FormFilledDate", Order=4)]
		public  string gxTpr_Formfilleddate
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Formfilleddate,context);

			}
			set { 
				sdt.gxTpr_Formfilleddate = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="FormVersionNumber", Order=5)]
		public short gxTpr_Formversionnumber
		{
			get { 
				return sdt.gxTpr_Formversionnumber;

			}
			set { 
				sdt.gxTpr_Formversionnumber = value;
			}
		}

		[DataMember(Name="FormFilledBy", Order=6)]
		public  string gxTpr_Formfilledby
		{
			get { 
				return sdt.gxTpr_Formfilledby;

			}
			set { 
				 sdt.gxTpr_Formfilledby = value;
			}
		}


		#endregion

		public SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem sdt
		{
			get { 
				return (SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem)Sdt;
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
				sdt = new SdtSDT_ResidentFilledForms_SDT_ResidentFilledFormsItem() ;
			}
		}
	}
	#endregion
}