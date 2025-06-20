/*
				   File: type_SdtSDT_Media
			Description: SDT_Media
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
	[XmlRoot(ElementName="SDT_Media")]
	[XmlType(TypeName="SDT_Media" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Media : GxUserType
	{
		public SdtSDT_Media( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Media_Medianame = "";

			gxTv_SdtSDT_Media_Mediaimage = "";
			gxTv_SdtSDT_Media_Mediaimage_gxi = "";
			gxTv_SdtSDT_Media_Mediatype = "";

			gxTv_SdtSDT_Media_Mediaurl = "";

		}

		public SdtSDT_Media(IGxContext context)
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
			AddObjectProperty("MediaId", gxTpr_Mediaid, false);


			AddObjectProperty("MediaName", gxTpr_Medianame, false);


			AddObjectProperty("MediaImage", gxTpr_Mediaimage, false);
			AddObjectProperty("MediaImage_GXI", gxTpr_Mediaimage_gxi, false);



			AddObjectProperty("MediaSize", gxTpr_Mediasize, false);


			AddObjectProperty("MediaType", gxTpr_Mediatype, false);


			AddObjectProperty("MediaUrl", gxTpr_Mediaurl, false);


			AddObjectProperty("IsCropped", gxTpr_Iscropped, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MediaId")]
		[XmlElement(ElementName="MediaId")]
		public Guid gxTpr_Mediaid
		{
			get {
				return gxTv_SdtSDT_Media_Mediaid; 
			}
			set {
				gxTv_SdtSDT_Media_Mediaid = value;
				SetDirty("Mediaid");
			}
		}




		[SoapElement(ElementName="MediaName")]
		[XmlElement(ElementName="MediaName")]
		public string gxTpr_Medianame
		{
			get {
				return gxTv_SdtSDT_Media_Medianame; 
			}
			set {
				gxTv_SdtSDT_Media_Medianame = value;
				SetDirty("Medianame");
			}
		}




		[SoapElement(ElementName="MediaImage")]
		[XmlElement(ElementName="MediaImage")]
		[GxUpload()]

		public string gxTpr_Mediaimage
		{
			get {
				return gxTv_SdtSDT_Media_Mediaimage; 
			}
			set {
				gxTv_SdtSDT_Media_Mediaimage = value;
				SetDirty("Mediaimage");
			}
		}


		[SoapElement(ElementName="MediaImage_GXI" )]
		[XmlElement(ElementName="MediaImage_GXI" )]
		public string gxTpr_Mediaimage_gxi
		{
			get {
				return gxTv_SdtSDT_Media_Mediaimage_gxi ;
			}
			set {
				gxTv_SdtSDT_Media_Mediaimage_gxi = value;
				SetDirty("Mediaimage_gxi");
			}
		}

		[SoapElement(ElementName="MediaSize")]
		[XmlElement(ElementName="MediaSize")]
		public int gxTpr_Mediasize
		{
			get {
				return gxTv_SdtSDT_Media_Mediasize; 
			}
			set {
				gxTv_SdtSDT_Media_Mediasize = value;
				SetDirty("Mediasize");
			}
		}




		[SoapElement(ElementName="MediaType")]
		[XmlElement(ElementName="MediaType")]
		public string gxTpr_Mediatype
		{
			get {
				return gxTv_SdtSDT_Media_Mediatype; 
			}
			set {
				gxTv_SdtSDT_Media_Mediatype = value;
				SetDirty("Mediatype");
			}
		}




		[SoapElement(ElementName="MediaUrl")]
		[XmlElement(ElementName="MediaUrl")]
		public string gxTpr_Mediaurl
		{
			get {
				return gxTv_SdtSDT_Media_Mediaurl; 
			}
			set {
				gxTv_SdtSDT_Media_Mediaurl = value;
				SetDirty("Mediaurl");
			}
		}




		[SoapElement(ElementName="IsCropped")]
		[XmlElement(ElementName="IsCropped")]
		public bool gxTpr_Iscropped
		{
			get {
				return gxTv_SdtSDT_Media_Iscropped; 
			}
			set {
				gxTv_SdtSDT_Media_Iscropped = value;
				SetDirty("Iscropped");
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
			gxTv_SdtSDT_Media_Medianame = "";
			gxTv_SdtSDT_Media_Mediaimage = "";gxTv_SdtSDT_Media_Mediaimage_gxi = "";

			gxTv_SdtSDT_Media_Mediatype = "";
			gxTv_SdtSDT_Media_Mediaurl = "";

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Media_Mediaid;
		 

		protected string gxTv_SdtSDT_Media_Medianame;
		 
		protected string gxTv_SdtSDT_Media_Mediaimage_gxi;
		protected string gxTv_SdtSDT_Media_Mediaimage;
		 

		protected int gxTv_SdtSDT_Media_Mediasize;
		 

		protected string gxTv_SdtSDT_Media_Mediatype;
		 

		protected string gxTv_SdtSDT_Media_Mediaurl;
		 

		protected bool gxTv_SdtSDT_Media_Iscropped;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Media", Namespace="Comforta_version2")]
	public class SdtSDT_Media_RESTInterface : GxGenericCollectionItem<SdtSDT_Media>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Media_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Media_RESTInterface( SdtSDT_Media psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="MediaId", Order=0)]
		public Guid gxTpr_Mediaid
		{
			get { 
				return sdt.gxTpr_Mediaid;

			}
			set { 
				sdt.gxTpr_Mediaid = value;
			}
		}

		[DataMember(Name="MediaName", Order=1)]
		public  string gxTpr_Medianame
		{
			get { 
				return sdt.gxTpr_Medianame;

			}
			set { 
				 sdt.gxTpr_Medianame = value;
			}
		}

		[DataMember(Name="MediaImage", Order=2)]
		[GxUpload()]
		public  string gxTpr_Mediaimage
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Mediaimage)) ? PathUtil.RelativePath( sdt.gxTpr_Mediaimage) : StringUtil.RTrim( sdt.gxTpr_Mediaimage_gxi));

			}
			set { 
				 sdt.gxTpr_Mediaimage = value;
			}
		}

		[DataMember(Name="MediaSize", Order=3)]
		public  string gxTpr_Mediasize
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Mediasize, 8, 0));

			}
			set { 
				sdt.gxTpr_Mediasize = (int) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MediaType", Order=4)]
		public  string gxTpr_Mediatype
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mediatype);

			}
			set { 
				 sdt.gxTpr_Mediatype = value;
			}
		}

		[DataMember(Name="MediaUrl", Order=5)]
		public  string gxTpr_Mediaurl
		{
			get { 
				return sdt.gxTpr_Mediaurl;

			}
			set { 
				 sdt.gxTpr_Mediaurl = value;
			}
		}

		[DataMember(Name="IsCropped", Order=6)]
		public bool gxTpr_Iscropped
		{
			get { 
				return sdt.gxTpr_Iscropped;

			}
			set { 
				sdt.gxTpr_Iscropped = value;
			}
		}


		#endregion

		public SdtSDT_Media sdt
		{
			get { 
				return (SdtSDT_Media)Sdt;
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
				sdt = new SdtSDT_Media() ;
			}
		}
	}
	#endregion
}