/*
				   File: type_SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem
			Description: SDT_ProductServiceSupplierGroup
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
	[XmlRoot(ElementName="SDT_ProductServiceSupplierGroupItem")]
	[XmlType(TypeName="SDT_ProductServiceSupplierGroupItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem : GxUserType
	{
		public SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem_Sdt_productservicesuppliergroupid = "";

			gxTv_SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem_Sdt_productservicesuppliergroupname = "";

		}

		public SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem(IGxContext context)
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
			AddObjectProperty("SDT_ProductServiceSupplierGroupId", gxTpr_Sdt_productservicesuppliergroupid, false);


			AddObjectProperty("SDT_ProductServiceSupplierGroupName", gxTpr_Sdt_productservicesuppliergroupname, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="SDT_ProductServiceSupplierGroupId")]
		[XmlElement(ElementName="SDT_ProductServiceSupplierGroupId")]
		public string gxTpr_Sdt_productservicesuppliergroupid
		{
			get {
				return gxTv_SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem_Sdt_productservicesuppliergroupid; 
			}
			set {
				gxTv_SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem_Sdt_productservicesuppliergroupid = value;
				SetDirty("Sdt_productservicesuppliergroupid");
			}
		}




		[SoapElement(ElementName="SDT_ProductServiceSupplierGroupName")]
		[XmlElement(ElementName="SDT_ProductServiceSupplierGroupName")]
		public string gxTpr_Sdt_productservicesuppliergroupname
		{
			get {
				return gxTv_SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem_Sdt_productservicesuppliergroupname; 
			}
			set {
				gxTv_SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem_Sdt_productservicesuppliergroupname = value;
				SetDirty("Sdt_productservicesuppliergroupname");
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
			gxTv_SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem_Sdt_productservicesuppliergroupid = "";
			gxTv_SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem_Sdt_productservicesuppliergroupname = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem_Sdt_productservicesuppliergroupid;
		 

		protected string gxTv_SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem_Sdt_productservicesuppliergroupname;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ProductServiceSupplierGroupItem", Namespace="Comforta_version2")]
	public class SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem_RESTInterface : GxGenericCollectionItem<SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem_RESTInterface( SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="SDT_ProductServiceSupplierGroupId", Order=0)]
		public  string gxTpr_Sdt_productservicesuppliergroupid
		{
			get { 
				return sdt.gxTpr_Sdt_productservicesuppliergroupid;

			}
			set { 
				 sdt.gxTpr_Sdt_productservicesuppliergroupid = value;
			}
		}

		[DataMember(Name="SDT_ProductServiceSupplierGroupName", Order=1)]
		public  string gxTpr_Sdt_productservicesuppliergroupname
		{
			get { 
				return sdt.gxTpr_Sdt_productservicesuppliergroupname;

			}
			set { 
				 sdt.gxTpr_Sdt_productservicesuppliergroupname = value;
			}
		}


		#endregion

		public SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem sdt
		{
			get { 
				return (SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem)Sdt;
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
				sdt = new SdtSDT_ProductServiceSupplierGroup_SDT_ProductServiceSupplierGroupItem() ;
			}
		}
	}
	#endregion
}