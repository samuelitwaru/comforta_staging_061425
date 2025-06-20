/*
				   File: type_SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem
			Description: SDT_ReceptionistToNotifiy
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
	[XmlRoot(ElementName="SDT_ReceptionistToNotifiyItem")]
	[XmlType(TypeName="SDT_ReceptionistToNotifiyItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem : GxUserType
	{
		public SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_Receptionistguid = "";

			gxTv_SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_Receptionistlanguage = "";

		}

		public SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem(IGxContext context)
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
			AddObjectProperty("ReceptionistId", gxTpr_Receptionistid, false);


			AddObjectProperty("ReceptionistGUID", gxTpr_Receptionistguid, false);


			AddObjectProperty("ReceptionistLanguage", gxTpr_Receptionistlanguage, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ReceptionistId")]
		[XmlElement(ElementName="ReceptionistId")]
		public Guid gxTpr_Receptionistid
		{
			get {
				return gxTv_SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_Receptionistid; 
			}
			set {
				gxTv_SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_Receptionistid = value;
				SetDirty("Receptionistid");
			}
		}




		[SoapElement(ElementName="ReceptionistGUID")]
		[XmlElement(ElementName="ReceptionistGUID")]
		public string gxTpr_Receptionistguid
		{
			get {
				return gxTv_SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_Receptionistguid; 
			}
			set {
				gxTv_SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_Receptionistguid = value;
				SetDirty("Receptionistguid");
			}
		}




		[SoapElement(ElementName="ReceptionistLanguage")]
		[XmlElement(ElementName="ReceptionistLanguage")]
		public string gxTpr_Receptionistlanguage
		{
			get {
				return gxTv_SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_Receptionistlanguage; 
			}
			set {
				gxTv_SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_Receptionistlanguage = value;
				SetDirty("Receptionistlanguage");
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
			gxTv_SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_Receptionistguid = "";
			gxTv_SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_Receptionistlanguage = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_Receptionistid;
		 

		protected string gxTv_SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_Receptionistguid;
		 

		protected string gxTv_SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_Receptionistlanguage;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ReceptionistToNotifiyItem", Namespace="Comforta_version2")]
	public class SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_RESTInterface : GxGenericCollectionItem<SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem_RESTInterface( SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ReceptionistId", Order=0)]
		public Guid gxTpr_Receptionistid
		{
			get { 
				return sdt.gxTpr_Receptionistid;

			}
			set { 
				sdt.gxTpr_Receptionistid = value;
			}
		}

		[DataMember(Name="ReceptionistGUID", Order=1)]
		public  string gxTpr_Receptionistguid
		{
			get { 
				return sdt.gxTpr_Receptionistguid;

			}
			set { 
				 sdt.gxTpr_Receptionistguid = value;
			}
		}

		[DataMember(Name="ReceptionistLanguage", Order=2)]
		public  string gxTpr_Receptionistlanguage
		{
			get { 
				return sdt.gxTpr_Receptionistlanguage;

			}
			set { 
				 sdt.gxTpr_Receptionistlanguage = value;
			}
		}


		#endregion

		public SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem sdt
		{
			get { 
				return (SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem)Sdt;
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
				sdt = new SdtSDT_ReceptionistToNotifiy_SDT_ReceptionistToNotifiyItem() ;
			}
		}
	}
	#endregion
}