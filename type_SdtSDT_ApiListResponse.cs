/*
				   File: type_SdtSDT_ApiListResponse
			Description: SDT_ApiListResponse
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
	[XmlRoot(ElementName="SDT_ApiListResponse")]
	[XmlType(TypeName="SDT_ApiListResponse" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ApiListResponse : GxUserType
	{
		public SdtSDT_ApiListResponse( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_ApiListResponse(IGxContext context)
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
			if (gxTv_SdtSDT_ApiListResponse_Notificationhistory != null)
			{
				AddObjectProperty("notificationHistory", gxTv_SdtSDT_ApiListResponse_Notificationhistory, false);
			}
			if (gxTv_SdtSDT_ApiListResponse_Filledforms != null)
			{
				AddObjectProperty("filledForms", gxTv_SdtSDT_ApiListResponse_Filledforms, false);
			}

			AddObjectProperty("pageSize", gxTpr_Pagesize, false);


			AddObjectProperty("pageNumber", gxTpr_Pagenumber, false);


			AddObjectProperty("numberOfPages", gxTpr_Numberofpages, false);

			if (gxTv_SdtSDT_ApiListResponse_Memos != null)
			{
				AddObjectProperty("memos", gxTv_SdtSDT_ApiListResponse_Memos, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="notificationHistory" )]
		[XmlArray(ElementName="notificationHistory"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_ResidentNotification> gxTpr_Notificationhistory_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDT_ApiListResponse_Notificationhistory == null )
				{
					gxTv_SdtSDT_ApiListResponse_Notificationhistory = new GXBaseCollection<GeneXus.Programs.SdtSDT_ResidentNotification>( context, "SDT_ResidentNotification", "");
				}
				return gxTv_SdtSDT_ApiListResponse_Notificationhistory;
			}
			set {
				gxTv_SdtSDT_ApiListResponse_Notificationhistory_N = false;
				gxTv_SdtSDT_ApiListResponse_Notificationhistory = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_ResidentNotification> gxTpr_Notificationhistory
		{
			get {
				if ( gxTv_SdtSDT_ApiListResponse_Notificationhistory == null )
				{
					gxTv_SdtSDT_ApiListResponse_Notificationhistory = new GXBaseCollection<GeneXus.Programs.SdtSDT_ResidentNotification>( context, "SDT_ResidentNotification", "");
				}
				gxTv_SdtSDT_ApiListResponse_Notificationhistory_N = false;
				return gxTv_SdtSDT_ApiListResponse_Notificationhistory ;
			}
			set {
				gxTv_SdtSDT_ApiListResponse_Notificationhistory_N = false;
				gxTv_SdtSDT_ApiListResponse_Notificationhistory = value;
				SetDirty("Notificationhistory");
			}
		}

		public void gxTv_SdtSDT_ApiListResponse_Notificationhistory_SetNull()
		{
			gxTv_SdtSDT_ApiListResponse_Notificationhistory_N = true;
			gxTv_SdtSDT_ApiListResponse_Notificationhistory = null;
		}

		public bool gxTv_SdtSDT_ApiListResponse_Notificationhistory_IsNull()
		{
			return gxTv_SdtSDT_ApiListResponse_Notificationhistory == null;
		}
		public bool ShouldSerializegxTpr_Notificationhistory_GXBaseCollection_Json()
		{
			return gxTv_SdtSDT_ApiListResponse_Notificationhistory != null && gxTv_SdtSDT_ApiListResponse_Notificationhistory.Count > 0;

		}


		[SoapElement(ElementName="filledForms" )]
		[XmlArray(ElementName="filledForms"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_ApiResidentFilledForms> gxTpr_Filledforms_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDT_ApiListResponse_Filledforms == null )
				{
					gxTv_SdtSDT_ApiListResponse_Filledforms = new GXBaseCollection<GeneXus.Programs.SdtSDT_ApiResidentFilledForms>( context, "SDT_ApiResidentFilledForms", "");
				}
				return gxTv_SdtSDT_ApiListResponse_Filledforms;
			}
			set {
				gxTv_SdtSDT_ApiListResponse_Filledforms_N = false;
				gxTv_SdtSDT_ApiListResponse_Filledforms = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_ApiResidentFilledForms> gxTpr_Filledforms
		{
			get {
				if ( gxTv_SdtSDT_ApiListResponse_Filledforms == null )
				{
					gxTv_SdtSDT_ApiListResponse_Filledforms = new GXBaseCollection<GeneXus.Programs.SdtSDT_ApiResidentFilledForms>( context, "SDT_ApiResidentFilledForms", "");
				}
				gxTv_SdtSDT_ApiListResponse_Filledforms_N = false;
				return gxTv_SdtSDT_ApiListResponse_Filledforms ;
			}
			set {
				gxTv_SdtSDT_ApiListResponse_Filledforms_N = false;
				gxTv_SdtSDT_ApiListResponse_Filledforms = value;
				SetDirty("Filledforms");
			}
		}

		public void gxTv_SdtSDT_ApiListResponse_Filledforms_SetNull()
		{
			gxTv_SdtSDT_ApiListResponse_Filledforms_N = true;
			gxTv_SdtSDT_ApiListResponse_Filledforms = null;
		}

		public bool gxTv_SdtSDT_ApiListResponse_Filledforms_IsNull()
		{
			return gxTv_SdtSDT_ApiListResponse_Filledforms == null;
		}
		public bool ShouldSerializegxTpr_Filledforms_GXBaseCollection_Json()
		{
			return gxTv_SdtSDT_ApiListResponse_Filledforms != null && gxTv_SdtSDT_ApiListResponse_Filledforms.Count > 0;

		}


		[SoapElement(ElementName="pageSize")]
		[XmlElement(ElementName="pageSize")]
		public short gxTpr_Pagesize
		{
			get {
				return gxTv_SdtSDT_ApiListResponse_Pagesize; 
			}
			set {
				gxTv_SdtSDT_ApiListResponse_Pagesize = value;
				SetDirty("Pagesize");
			}
		}




		[SoapElement(ElementName="pageNumber")]
		[XmlElement(ElementName="pageNumber")]
		public short gxTpr_Pagenumber
		{
			get {
				return gxTv_SdtSDT_ApiListResponse_Pagenumber; 
			}
			set {
				gxTv_SdtSDT_ApiListResponse_Pagenumber = value;
				SetDirty("Pagenumber");
			}
		}




		[SoapElement(ElementName="numberOfPages")]
		[XmlElement(ElementName="numberOfPages")]
		public short gxTpr_Numberofpages
		{
			get {
				return gxTv_SdtSDT_ApiListResponse_Numberofpages; 
			}
			set {
				gxTv_SdtSDT_ApiListResponse_Numberofpages = value;
				SetDirty("Numberofpages");
			}
		}




		[SoapElement(ElementName="memos" )]
		[XmlArray(ElementName="memos"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Memo> gxTpr_Memos_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDT_ApiListResponse_Memos == null )
				{
					gxTv_SdtSDT_ApiListResponse_Memos = new GXBaseCollection<GeneXus.Programs.SdtSDT_Memo>( context, "SDT_Memo", "");
				}
				return gxTv_SdtSDT_ApiListResponse_Memos;
			}
			set {
				gxTv_SdtSDT_ApiListResponse_Memos_N = false;
				gxTv_SdtSDT_ApiListResponse_Memos = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Memo> gxTpr_Memos
		{
			get {
				if ( gxTv_SdtSDT_ApiListResponse_Memos == null )
				{
					gxTv_SdtSDT_ApiListResponse_Memos = new GXBaseCollection<GeneXus.Programs.SdtSDT_Memo>( context, "SDT_Memo", "");
				}
				gxTv_SdtSDT_ApiListResponse_Memos_N = false;
				return gxTv_SdtSDT_ApiListResponse_Memos ;
			}
			set {
				gxTv_SdtSDT_ApiListResponse_Memos_N = false;
				gxTv_SdtSDT_ApiListResponse_Memos = value;
				SetDirty("Memos");
			}
		}

		public void gxTv_SdtSDT_ApiListResponse_Memos_SetNull()
		{
			gxTv_SdtSDT_ApiListResponse_Memos_N = true;
			gxTv_SdtSDT_ApiListResponse_Memos = null;
		}

		public bool gxTv_SdtSDT_ApiListResponse_Memos_IsNull()
		{
			return gxTv_SdtSDT_ApiListResponse_Memos == null;
		}
		public bool ShouldSerializegxTpr_Memos_GXBaseCollection_Json()
		{
			return gxTv_SdtSDT_ApiListResponse_Memos != null && gxTv_SdtSDT_ApiListResponse_Memos.Count > 0;

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
			gxTv_SdtSDT_ApiListResponse_Notificationhistory_N = true;


			gxTv_SdtSDT_ApiListResponse_Filledforms_N = true;





			gxTv_SdtSDT_ApiListResponse_Memos_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDT_ApiListResponse_Notificationhistory_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_ResidentNotification> gxTv_SdtSDT_ApiListResponse_Notificationhistory = null;  
		protected bool gxTv_SdtSDT_ApiListResponse_Filledforms_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_ApiResidentFilledForms> gxTv_SdtSDT_ApiListResponse_Filledforms = null;  

		protected short gxTv_SdtSDT_ApiListResponse_Pagesize;
		 

		protected short gxTv_SdtSDT_ApiListResponse_Pagenumber;
		 

		protected short gxTv_SdtSDT_ApiListResponse_Numberofpages;
		 
		protected bool gxTv_SdtSDT_ApiListResponse_Memos_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_Memo> gxTv_SdtSDT_ApiListResponse_Memos = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_ApiListResponse", Namespace="Comforta_version2")]
	public class SdtSDT_ApiListResponse_RESTInterface : GxGenericCollectionItem<SdtSDT_ApiListResponse>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ApiListResponse_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ApiListResponse_RESTInterface( SdtSDT_ApiListResponse psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="notificationHistory", Order=0, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_ResidentNotification_RESTInterface> gxTpr_Notificationhistory
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Notificationhistory_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_ResidentNotification_RESTInterface>(sdt.gxTpr_Notificationhistory);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Notificationhistory);
			}
		}

		[DataMember(Name="filledForms", Order=1, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_ApiResidentFilledForms_RESTInterface> gxTpr_Filledforms
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Filledforms_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_ApiResidentFilledForms_RESTInterface>(sdt.gxTpr_Filledforms);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Filledforms);
			}
		}

		[DataMember(Name="pageSize", Order=2)]
		public short gxTpr_Pagesize
		{
			get { 
				return sdt.gxTpr_Pagesize;

			}
			set { 
				sdt.gxTpr_Pagesize = value;
			}
		}

		[DataMember(Name="pageNumber", Order=3)]
		public short gxTpr_Pagenumber
		{
			get { 
				return sdt.gxTpr_Pagenumber;

			}
			set { 
				sdt.gxTpr_Pagenumber = value;
			}
		}

		[DataMember(Name="numberOfPages", Order=4)]
		public short gxTpr_Numberofpages
		{
			get { 
				return sdt.gxTpr_Numberofpages;

			}
			set { 
				sdt.gxTpr_Numberofpages = value;
			}
		}

		[DataMember(Name="memos", Order=5, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_Memo_RESTInterface> gxTpr_Memos
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Memos_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_Memo_RESTInterface>(sdt.gxTpr_Memos);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Memos);
			}
		}


		#endregion

		public SdtSDT_ApiListResponse sdt
		{
			get { 
				return (SdtSDT_ApiListResponse)Sdt;
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
				sdt = new SdtSDT_ApiListResponse() ;
			}
		}
	}
	#endregion
}