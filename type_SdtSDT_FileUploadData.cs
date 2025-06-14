/*
				   File: type_SdtSDT_FileUploadData
			Description: SDT_FileUploadData
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
	[XmlRoot(ElementName="SDT_FileUploadData")]
	[XmlType(TypeName="SDT_FileUploadData" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_FileUploadData : GxUserType
	{
		public SdtSDT_FileUploadData( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_FileUploadData_Fullname = "";

			gxTv_SdtSDT_FileUploadData_Name = "";

			gxTv_SdtSDT_FileUploadData_Extension = "";

			gxTv_SdtSDT_FileUploadData_File = "";

		}

		public SdtSDT_FileUploadData(IGxContext context)
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
			AddObjectProperty("FullName", gxTpr_Fullname, false);


			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Extension", gxTpr_Extension, false);


			AddObjectProperty("Size", gxTpr_Size, false);


			AddObjectProperty("File", gxTpr_File, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="FullName")]
		[XmlElement(ElementName="FullName")]
		public string gxTpr_Fullname
		{
			get {
				return gxTv_SdtSDT_FileUploadData_Fullname; 
			}
			set {
				gxTv_SdtSDT_FileUploadData_Fullname = value;
				SetDirty("Fullname");
			}
		}




		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDT_FileUploadData_Name; 
			}
			set {
				gxTv_SdtSDT_FileUploadData_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Extension")]
		[XmlElement(ElementName="Extension")]
		public string gxTpr_Extension
		{
			get {
				return gxTv_SdtSDT_FileUploadData_Extension; 
			}
			set {
				gxTv_SdtSDT_FileUploadData_Extension = value;
				SetDirty("Extension");
			}
		}




		[SoapElement(ElementName="Size")]
		[XmlElement(ElementName="Size")]
		public long gxTpr_Size
		{
			get {
				return gxTv_SdtSDT_FileUploadData_Size; 
			}
			set {
				gxTv_SdtSDT_FileUploadData_Size = value;
				SetDirty("Size");
			}
		}




		[SoapElement(ElementName="File")]
		[XmlElement(ElementName="File")]
		public string gxTpr_File
		{
			get {
				return gxTv_SdtSDT_FileUploadData_File; 
			}
			set {
				gxTv_SdtSDT_FileUploadData_File = value;
				SetDirty("File");
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
			gxTv_SdtSDT_FileUploadData_Fullname = "";
			gxTv_SdtSDT_FileUploadData_Name = "";
			gxTv_SdtSDT_FileUploadData_Extension = "";

			gxTv_SdtSDT_FileUploadData_File = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_FileUploadData_Fullname;
		 

		protected string gxTv_SdtSDT_FileUploadData_Name;
		 

		protected string gxTv_SdtSDT_FileUploadData_Extension;
		 

		protected long gxTv_SdtSDT_FileUploadData_Size;
		 

		protected string gxTv_SdtSDT_FileUploadData_File;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_FileUploadData", Namespace="Comforta_version21")]
	public class SdtSDT_FileUploadData_RESTInterface : GxGenericCollectionItem<SdtSDT_FileUploadData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_FileUploadData_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_FileUploadData_RESTInterface( SdtSDT_FileUploadData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="FullName", Order=0)]
		public  string gxTpr_Fullname
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Fullname);

			}
			set { 
				 sdt.gxTpr_Fullname = value;
			}
		}

		[DataMember(Name="Name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Extension", Order=2)]
		public  string gxTpr_Extension
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Extension);

			}
			set { 
				 sdt.gxTpr_Extension = value;
			}
		}

		[DataMember(Name="Size", Order=3)]
		public  string gxTpr_Size
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Size, 10, 0));

			}
			set { 
				sdt.gxTpr_Size = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="File", Order=4)]
		public  string gxTpr_File
		{
			get { 
				return sdt.gxTpr_File;

			}
			set { 
				 sdt.gxTpr_File = value;
			}
		}


		#endregion

		public SdtSDT_FileUploadData sdt
		{
			get { 
				return (SdtSDT_FileUploadData)Sdt;
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
				sdt = new SdtSDT_FileUploadData() ;
			}
		}
	}
	#endregion
}