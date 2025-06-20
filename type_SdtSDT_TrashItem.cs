/*
				   File: type_SdtSDT_TrashItem
			Description: SDT_TrashItem
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
	[XmlRoot(ElementName="SDT_TrashItem")]
	[XmlType(TypeName="SDT_TrashItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_TrashItem : GxUserType
	{
		public SdtSDT_TrashItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_TrashItem_Type = "";

			gxTv_SdtSDT_TrashItem_Deletedat = (DateTime)(DateTime.MinValue);

		}

		public SdtSDT_TrashItem(IGxContext context)
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
			AddObjectProperty("Type", gxTpr_Type, false);

			if (gxTv_SdtSDT_TrashItem_Page != null)
			{
				AddObjectProperty("Page", gxTv_SdtSDT_TrashItem_Page, false);
			}
			if (gxTv_SdtSDT_TrashItem_Version != null)
			{
				AddObjectProperty("Version", gxTv_SdtSDT_TrashItem_Version, false);
			}

			datetime_STZ = gxTpr_Deletedat;
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
			AddObjectProperty("DeletedAt", sDateCnv, false);



			AddObjectProperty("TrashId", gxTpr_Trashid, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Type")]
		[XmlElement(ElementName="Type")]
		public string gxTpr_Type
		{
			get {
				return gxTv_SdtSDT_TrashItem_Type; 
			}
			set {
				gxTv_SdtSDT_TrashItem_Type = value;
				SetDirty("Type");
			}
		}



		[SoapElement(ElementName="Page")]
		[XmlElement(ElementName="Page")]
		public GeneXus.Programs.SdtSDT_AppVersionPage gxTpr_Page
		{
			get {
				if ( gxTv_SdtSDT_TrashItem_Page == null )
				{
					gxTv_SdtSDT_TrashItem_Page = new GeneXus.Programs.SdtSDT_AppVersionPage(context);
				}
				return gxTv_SdtSDT_TrashItem_Page; 
			}
			set {
				gxTv_SdtSDT_TrashItem_Page = value;
				SetDirty("Page");
			}
		}
		public void gxTv_SdtSDT_TrashItem_Page_SetNull()
		{
			gxTv_SdtSDT_TrashItem_Page_N = true;
			gxTv_SdtSDT_TrashItem_Page = null;
		}

		public bool gxTv_SdtSDT_TrashItem_Page_IsNull()
		{
			return gxTv_SdtSDT_TrashItem_Page == null;
		}
		public bool ShouldSerializegxTpr_Page_Json()
		{
			return gxTv_SdtSDT_TrashItem_Page != null;

		}

		[SoapElement(ElementName="Version")]
		[XmlElement(ElementName="Version")]
		public GeneXus.Programs.SdtSDT_AppVersion gxTpr_Version
		{
			get {
				if ( gxTv_SdtSDT_TrashItem_Version == null )
				{
					gxTv_SdtSDT_TrashItem_Version = new GeneXus.Programs.SdtSDT_AppVersion(context);
				}
				return gxTv_SdtSDT_TrashItem_Version; 
			}
			set {
				gxTv_SdtSDT_TrashItem_Version = value;
				SetDirty("Version");
			}
		}
		public void gxTv_SdtSDT_TrashItem_Version_SetNull()
		{
			gxTv_SdtSDT_TrashItem_Version_N = true;
			gxTv_SdtSDT_TrashItem_Version = null;
		}

		public bool gxTv_SdtSDT_TrashItem_Version_IsNull()
		{
			return gxTv_SdtSDT_TrashItem_Version == null;
		}
		public bool ShouldSerializegxTpr_Version_Json()
		{
			return gxTv_SdtSDT_TrashItem_Version != null;

		}

		[SoapElement(ElementName="DeletedAt")]
		[XmlElement(ElementName="DeletedAt" , IsNullable=true)]
		public string gxTpr_Deletedat_Nullable
		{
			get {
				if ( gxTv_SdtSDT_TrashItem_Deletedat == DateTime.MinValue)
					return null;
				return new GxDatetimeString(gxTv_SdtSDT_TrashItem_Deletedat).value ;
			}
			set {
				gxTv_SdtSDT_TrashItem_Deletedat = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Deletedat
		{
			get {
				return gxTv_SdtSDT_TrashItem_Deletedat; 
			}
			set {
				gxTv_SdtSDT_TrashItem_Deletedat = value;
				SetDirty("Deletedat");
			}
		}



		[SoapElement(ElementName="TrashId")]
		[XmlElement(ElementName="TrashId")]
		public Guid gxTpr_Trashid
		{
			get {
				return gxTv_SdtSDT_TrashItem_Trashid; 
			}
			set {
				gxTv_SdtSDT_TrashItem_Trashid = value;
				SetDirty("Trashid");
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
			gxTv_SdtSDT_TrashItem_Type = "";

			gxTv_SdtSDT_TrashItem_Page_N = true;


			gxTv_SdtSDT_TrashItem_Version_N = true;

			gxTv_SdtSDT_TrashItem_Deletedat = (DateTime)(DateTime.MinValue);

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

		protected string gxTv_SdtSDT_TrashItem_Type;
		 

		protected GeneXus.Programs.SdtSDT_AppVersionPage gxTv_SdtSDT_TrashItem_Page = null;
		protected bool gxTv_SdtSDT_TrashItem_Page_N;
		 

		protected GeneXus.Programs.SdtSDT_AppVersion gxTv_SdtSDT_TrashItem_Version = null;
		protected bool gxTv_SdtSDT_TrashItem_Version_N;
		 

		protected DateTime gxTv_SdtSDT_TrashItem_Deletedat;
		 

		protected Guid gxTv_SdtSDT_TrashItem_Trashid;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_TrashItem", Namespace="Comforta_version2")]
	public class SdtSDT_TrashItem_RESTInterface : GxGenericCollectionItem<SdtSDT_TrashItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_TrashItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_TrashItem_RESTInterface( SdtSDT_TrashItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Type", Order=0)]
		public  string gxTpr_Type
		{
			get { 
				return sdt.gxTpr_Type;

			}
			set { 
				 sdt.gxTpr_Type = value;
			}
		}

		[DataMember(Name="Page", Order=1, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_AppVersionPage_RESTInterface gxTpr_Page
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Page_Json())
					return new GeneXus.Programs.SdtSDT_AppVersionPage_RESTInterface(sdt.gxTpr_Page);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Page = value.sdt;
			}
		}

		[DataMember(Name="Version", Order=2, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_AppVersion_RESTInterface gxTpr_Version
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Version_Json())
					return new GeneXus.Programs.SdtSDT_AppVersion_RESTInterface(sdt.gxTpr_Version);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Version = value.sdt;
			}
		}

		[DataMember(Name="DeletedAt", Order=3)]
		public  string gxTpr_Deletedat
		{
			get { 
				return DateTimeUtil.TToC2( sdt.gxTpr_Deletedat,context);

			}
			set { 
				sdt.gxTpr_Deletedat = DateTimeUtil.CToT2(value,context);
			}
		}

		[DataMember(Name="TrashId", Order=4)]
		public Guid gxTpr_Trashid
		{
			get { 
				return sdt.gxTpr_Trashid;

			}
			set { 
				sdt.gxTpr_Trashid = value;
			}
		}


		#endregion

		public SdtSDT_TrashItem sdt
		{
			get { 
				return (SdtSDT_TrashItem)Sdt;
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
				sdt = new SdtSDT_TrashItem() ;
			}
		}
	}
	#endregion
}