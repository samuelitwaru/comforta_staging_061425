/*
				   File: type_SdtSDT_ResidentPackage_SDT_ResidentPackageItem
			Description: SDT_ResidentPackage
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
	[XmlRoot(ElementName="SDT_ResidentPackageItem")]
	[XmlType(TypeName="SDT_ResidentPackageItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ResidentPackage_SDT_ResidentPackageItem : GxUserType
	{
		public SdtSDT_ResidentPackage_SDT_ResidentPackageItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ResidentPackage_SDT_ResidentPackageItem_Residentpackagename = "";

		}

		public SdtSDT_ResidentPackage_SDT_ResidentPackageItem(IGxContext context)
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
			AddObjectProperty("ResidentPackageId", gxTpr_Residentpackageid, false);


			AddObjectProperty("ResidentPackageName", gxTpr_Residentpackagename, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ResidentPackageId")]
		[XmlElement(ElementName="ResidentPackageId")]
		public Guid gxTpr_Residentpackageid
		{
			get {
				return gxTv_SdtSDT_ResidentPackage_SDT_ResidentPackageItem_Residentpackageid; 
			}
			set {
				gxTv_SdtSDT_ResidentPackage_SDT_ResidentPackageItem_Residentpackageid = value;
				SetDirty("Residentpackageid");
			}
		}




		[SoapElement(ElementName="ResidentPackageName")]
		[XmlElement(ElementName="ResidentPackageName")]
		public string gxTpr_Residentpackagename
		{
			get {
				return gxTv_SdtSDT_ResidentPackage_SDT_ResidentPackageItem_Residentpackagename; 
			}
			set {
				gxTv_SdtSDT_ResidentPackage_SDT_ResidentPackageItem_Residentpackagename = value;
				SetDirty("Residentpackagename");
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
			gxTv_SdtSDT_ResidentPackage_SDT_ResidentPackageItem_Residentpackagename = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_ResidentPackage_SDT_ResidentPackageItem_Residentpackageid;
		 

		protected string gxTv_SdtSDT_ResidentPackage_SDT_ResidentPackageItem_Residentpackagename;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ResidentPackageItem", Namespace="Comforta_version2")]
	public class SdtSDT_ResidentPackage_SDT_ResidentPackageItem_RESTInterface : GxGenericCollectionItem<SdtSDT_ResidentPackage_SDT_ResidentPackageItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ResidentPackage_SDT_ResidentPackageItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ResidentPackage_SDT_ResidentPackageItem_RESTInterface( SdtSDT_ResidentPackage_SDT_ResidentPackageItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ResidentPackageId", Order=0)]
		public Guid gxTpr_Residentpackageid
		{
			get { 
				return sdt.gxTpr_Residentpackageid;

			}
			set { 
				sdt.gxTpr_Residentpackageid = value;
			}
		}

		[DataMember(Name="ResidentPackageName", Order=1)]
		public  string gxTpr_Residentpackagename
		{
			get { 
				return sdt.gxTpr_Residentpackagename;

			}
			set { 
				 sdt.gxTpr_Residentpackagename = value;
			}
		}


		#endregion

		public SdtSDT_ResidentPackage_SDT_ResidentPackageItem sdt
		{
			get { 
				return (SdtSDT_ResidentPackage_SDT_ResidentPackageItem)Sdt;
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
				sdt = new SdtSDT_ResidentPackage_SDT_ResidentPackageItem() ;
			}
		}
	}
	#endregion
}