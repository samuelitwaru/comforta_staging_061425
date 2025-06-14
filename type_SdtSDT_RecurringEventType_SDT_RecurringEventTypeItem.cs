/*
				   File: type_SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem
			Description: SDT_RecurringEventType
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
	[XmlRoot(ElementName="SDT_RecurringEventTypeItem")]
	[XmlType(TypeName="SDT_RecurringEventTypeItem" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem : GxUserType
	{
		public SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem_Recurringeventtypeid = "";

			gxTv_SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem_Recurringeventtypedescription = "";

		}

		public SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem(IGxContext context)
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
			AddObjectProperty("RecurringEventTypeId", gxTpr_Recurringeventtypeid, false);


			AddObjectProperty("RecurringEventTypeDescription", gxTpr_Recurringeventtypedescription, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="RecurringEventTypeId")]
		[XmlElement(ElementName="RecurringEventTypeId")]
		public string gxTpr_Recurringeventtypeid
		{
			get {
				return gxTv_SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem_Recurringeventtypeid; 
			}
			set {
				gxTv_SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem_Recurringeventtypeid = value;
				SetDirty("Recurringeventtypeid");
			}
		}




		[SoapElement(ElementName="RecurringEventTypeDescription")]
		[XmlElement(ElementName="RecurringEventTypeDescription")]
		public string gxTpr_Recurringeventtypedescription
		{
			get {
				return gxTv_SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem_Recurringeventtypedescription; 
			}
			set {
				gxTv_SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem_Recurringeventtypedescription = value;
				SetDirty("Recurringeventtypedescription");
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
			gxTv_SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem_Recurringeventtypeid = "";
			gxTv_SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem_Recurringeventtypedescription = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem_Recurringeventtypeid;
		 

		protected string gxTv_SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem_Recurringeventtypedescription;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_RecurringEventTypeItem", Namespace="Comforta_version21")]
	public class SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem_RESTInterface : GxGenericCollectionItem<SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem_RESTInterface( SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="RecurringEventTypeId", Order=0)]
		public  string gxTpr_Recurringeventtypeid
		{
			get { 
				return sdt.gxTpr_Recurringeventtypeid;

			}
			set { 
				 sdt.gxTpr_Recurringeventtypeid = value;
			}
		}

		[DataMember(Name="RecurringEventTypeDescription", Order=1)]
		public  string gxTpr_Recurringeventtypedescription
		{
			get { 
				return sdt.gxTpr_Recurringeventtypedescription;

			}
			set { 
				 sdt.gxTpr_Recurringeventtypedescription = value;
			}
		}


		#endregion

		public SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem sdt
		{
			get { 
				return (SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem)Sdt;
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
				sdt = new SdtSDT_RecurringEventType_SDT_RecurringEventTypeItem() ;
			}
		}
	}
	#endregion
}