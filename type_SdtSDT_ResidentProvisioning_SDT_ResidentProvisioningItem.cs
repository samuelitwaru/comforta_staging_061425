/*
				   File: type_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem
			Description: SDT_ResidentProvisioning
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
	[XmlRoot(ElementName="SDT_ResidentProvisioningItem")]
	[XmlType(TypeName="SDT_ResidentProvisioningItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem : GxUserType
	{
		public SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Residentprovisiondescription = "";

			gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Residentprovisionvalue = "";

		}

		public SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem(IGxContext context)
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
			AddObjectProperty("ResidentProvisionDescription", gxTpr_Residentprovisiondescription, false);


			AddObjectProperty("ResidentProvisionValue", gxTpr_Residentprovisionvalue, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ResidentProvisionDescription")]
		[XmlElement(ElementName="ResidentProvisionDescription")]
		public string gxTpr_Residentprovisiondescription
		{
			get {
				return gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Residentprovisiondescription; 
			}
			set {
				gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Residentprovisiondescription = value;
				SetDirty("Residentprovisiondescription");
			}
		}




		[SoapElement(ElementName="ResidentProvisionValue")]
		[XmlElement(ElementName="ResidentProvisionValue")]
		public string gxTpr_Residentprovisionvalue
		{
			get {
				return gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Residentprovisionvalue; 
			}
			set {
				gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Residentprovisionvalue = value;
				SetDirty("Residentprovisionvalue");
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
			gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Residentprovisiondescription = "";
			gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Residentprovisionvalue = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Residentprovisiondescription;
		 

		protected string gxTv_SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_Residentprovisionvalue;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ResidentProvisioningItem", Namespace="Comforta_version2")]
	public class SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_RESTInterface : GxGenericCollectionItem<SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem_RESTInterface( SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ResidentProvisionDescription", Order=0)]
		public  string gxTpr_Residentprovisiondescription
		{
			get { 
				return sdt.gxTpr_Residentprovisiondescription;

			}
			set { 
				 sdt.gxTpr_Residentprovisiondescription = value;
			}
		}

		[DataMember(Name="ResidentProvisionValue", Order=1)]
		public  string gxTpr_Residentprovisionvalue
		{
			get { 
				return sdt.gxTpr_Residentprovisionvalue;

			}
			set { 
				 sdt.gxTpr_Residentprovisionvalue = value;
			}
		}


		#endregion

		public SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem sdt
		{
			get { 
				return (SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem)Sdt;
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
				sdt = new SdtSDT_ResidentProvisioning_SDT_ResidentProvisioningItem() ;
			}
		}
	}
	#endregion
}