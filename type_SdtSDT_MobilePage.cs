/*
				   File: type_SdtSDT_MobilePage
			Description: SDT_MobilePage
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
	[XmlRoot(ElementName="SDT_MobilePage")]
	[XmlType(TypeName="SDT_MobilePage" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_MobilePage : GxUserType
	{
		public SdtSDT_MobilePage( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_MobilePage_Pagename = "";

		}

		public SdtSDT_MobilePage(IGxContext context)
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
			AddObjectProperty("PageId", gxTpr_Pageid, false);


			AddObjectProperty("PageName", gxTpr_Pagename, false);

			if (gxTv_SdtSDT_MobilePage_Row != null)
			{
				AddObjectProperty("Row", gxTv_SdtSDT_MobilePage_Row, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PageId")]
		[XmlElement(ElementName="PageId")]
		public Guid gxTpr_Pageid
		{
			get {
				return gxTv_SdtSDT_MobilePage_Pageid; 
			}
			set {
				gxTv_SdtSDT_MobilePage_Pageid = value;
				SetDirty("Pageid");
			}
		}




		[SoapElement(ElementName="PageName")]
		[XmlElement(ElementName="PageName")]
		public string gxTpr_Pagename
		{
			get {
				return gxTv_SdtSDT_MobilePage_Pagename; 
			}
			set {
				gxTv_SdtSDT_MobilePage_Pagename = value;
				SetDirty("Pagename");
			}
		}




		[SoapElement(ElementName="Row" )]
		[XmlArray(ElementName="Row"  )]
		[XmlArrayItemAttribute(ElementName="RowItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Row> gxTpr_Row_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDT_MobilePage_Row == null )
				{
					gxTv_SdtSDT_MobilePage_Row = new GXBaseCollection<GeneXus.Programs.SdtSDT_Row>( context, "SDT_Row", "");
				}
				return gxTv_SdtSDT_MobilePage_Row;
			}
			set {
				gxTv_SdtSDT_MobilePage_Row_N = false;
				gxTv_SdtSDT_MobilePage_Row = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Row> gxTpr_Row
		{
			get {
				if ( gxTv_SdtSDT_MobilePage_Row == null )
				{
					gxTv_SdtSDT_MobilePage_Row = new GXBaseCollection<GeneXus.Programs.SdtSDT_Row>( context, "SDT_Row", "");
				}
				gxTv_SdtSDT_MobilePage_Row_N = false;
				return gxTv_SdtSDT_MobilePage_Row ;
			}
			set {
				gxTv_SdtSDT_MobilePage_Row_N = false;
				gxTv_SdtSDT_MobilePage_Row = value;
				SetDirty("Row");
			}
		}

		public void gxTv_SdtSDT_MobilePage_Row_SetNull()
		{
			gxTv_SdtSDT_MobilePage_Row_N = true;
			gxTv_SdtSDT_MobilePage_Row = null;
		}

		public bool gxTv_SdtSDT_MobilePage_Row_IsNull()
		{
			return gxTv_SdtSDT_MobilePage_Row == null;
		}
		public bool ShouldSerializegxTpr_Row_GXBaseCollection_Json()
		{
			return gxTv_SdtSDT_MobilePage_Row != null && gxTv_SdtSDT_MobilePage_Row.Count > 0;

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
			gxTv_SdtSDT_MobilePage_Pagename = "";

			gxTv_SdtSDT_MobilePage_Row_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_MobilePage_Pageid;
		 

		protected string gxTv_SdtSDT_MobilePage_Pagename;
		 
		protected bool gxTv_SdtSDT_MobilePage_Row_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_Row> gxTv_SdtSDT_MobilePage_Row = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_MobilePage", Namespace="Comforta_version2")]
	public class SdtSDT_MobilePage_RESTInterface : GxGenericCollectionItem<SdtSDT_MobilePage>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_MobilePage_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_MobilePage_RESTInterface( SdtSDT_MobilePage psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PageId", Order=0)]
		public Guid gxTpr_Pageid
		{
			get { 
				return sdt.gxTpr_Pageid;

			}
			set { 
				sdt.gxTpr_Pageid = value;
			}
		}

		[DataMember(Name="PageName", Order=1)]
		public  string gxTpr_Pagename
		{
			get { 
				return sdt.gxTpr_Pagename;

			}
			set { 
				 sdt.gxTpr_Pagename = value;
			}
		}

		[DataMember(Name="Row", Order=2, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_Row_RESTInterface> gxTpr_Row
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Row_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_Row_RESTInterface>(sdt.gxTpr_Row);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Row);
			}
		}


		#endregion

		public SdtSDT_MobilePage sdt
		{
			get { 
				return (SdtSDT_MobilePage)Sdt;
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
				sdt = new SdtSDT_MobilePage() ;
			}
		}
	}
	#endregion
}