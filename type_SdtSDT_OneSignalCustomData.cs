/*
				   File: type_SdtSDT_OneSignalCustomData
			Description: SDT_OneSignalCustomData
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
	[XmlRoot(ElementName="SDT_OneSignalCustomData")]
	[XmlType(TypeName="SDT_OneSignalCustomData" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_OneSignalCustomData : GxUserType
	{
		public SdtSDT_OneSignalCustomData( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_OneSignalCustomData_Notificationcategory = "";

		}

		public SdtSDT_OneSignalCustomData(IGxContext context)
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
			AddObjectProperty("notificationCategory", gxTpr_Notificationcategory, false);

			if (gxTv_SdtSDT_OneSignalCustomData_Formdetails != null)
			{
				AddObjectProperty("formDetails", gxTv_SdtSDT_OneSignalCustomData_Formdetails, false);
			}
			if (gxTv_SdtSDT_OneSignalCustomData_Discussiondetails != null)
			{
				AddObjectProperty("discussionDetails", gxTv_SdtSDT_OneSignalCustomData_Discussiondetails, false);
			}
			if (gxTv_SdtSDT_OneSignalCustomData_Agendadetails != null)
			{
				AddObjectProperty("agendaDetails", gxTv_SdtSDT_OneSignalCustomData_Agendadetails, false);
			}
			if (gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails != null)
			{
				AddObjectProperty("toolboxDetails", gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="notificationCategory")]
		[XmlElement(ElementName="notificationCategory")]
		public string gxTpr_Notificationcategory
		{
			get {
				return gxTv_SdtSDT_OneSignalCustomData_Notificationcategory; 
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_Notificationcategory = value;
				SetDirty("Notificationcategory");
			}
		}



		[SoapElement(ElementName="formDetails" )]
		[XmlElement(ElementName="formDetails" )]
		public SdtSDT_OneSignalCustomData_formDetails gxTpr_Formdetails
		{
			get {
				if ( gxTv_SdtSDT_OneSignalCustomData_Formdetails == null )
				{
					gxTv_SdtSDT_OneSignalCustomData_Formdetails = new SdtSDT_OneSignalCustomData_formDetails(context);
				}
				gxTv_SdtSDT_OneSignalCustomData_Formdetails_N = false;
				return gxTv_SdtSDT_OneSignalCustomData_Formdetails;
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_Formdetails_N = false;
				gxTv_SdtSDT_OneSignalCustomData_Formdetails = value;
				SetDirty("Formdetails");
			}

		}

		public void gxTv_SdtSDT_OneSignalCustomData_Formdetails_SetNull()
		{
			gxTv_SdtSDT_OneSignalCustomData_Formdetails_N = true;
			gxTv_SdtSDT_OneSignalCustomData_Formdetails = null;
		}

		public bool gxTv_SdtSDT_OneSignalCustomData_Formdetails_IsNull()
		{
			return gxTv_SdtSDT_OneSignalCustomData_Formdetails == null;
		}
		public bool ShouldSerializegxTpr_Formdetails_Json()
		{
				return (gxTv_SdtSDT_OneSignalCustomData_Formdetails != null && gxTv_SdtSDT_OneSignalCustomData_Formdetails.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="discussionDetails" )]
		[XmlElement(ElementName="discussionDetails" )]
		public SdtSDT_OneSignalCustomData_discussionDetails gxTpr_Discussiondetails
		{
			get {
				if ( gxTv_SdtSDT_OneSignalCustomData_Discussiondetails == null )
				{
					gxTv_SdtSDT_OneSignalCustomData_Discussiondetails = new SdtSDT_OneSignalCustomData_discussionDetails(context);
				}
				gxTv_SdtSDT_OneSignalCustomData_Discussiondetails_N = false;
				return gxTv_SdtSDT_OneSignalCustomData_Discussiondetails;
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_Discussiondetails_N = false;
				gxTv_SdtSDT_OneSignalCustomData_Discussiondetails = value;
				SetDirty("Discussiondetails");
			}

		}

		public void gxTv_SdtSDT_OneSignalCustomData_Discussiondetails_SetNull()
		{
			gxTv_SdtSDT_OneSignalCustomData_Discussiondetails_N = true;
			gxTv_SdtSDT_OneSignalCustomData_Discussiondetails = null;
		}

		public bool gxTv_SdtSDT_OneSignalCustomData_Discussiondetails_IsNull()
		{
			return gxTv_SdtSDT_OneSignalCustomData_Discussiondetails == null;
		}
		public bool ShouldSerializegxTpr_Discussiondetails_Json()
		{
				return (gxTv_SdtSDT_OneSignalCustomData_Discussiondetails != null && gxTv_SdtSDT_OneSignalCustomData_Discussiondetails.ShouldSerializeSdtJson());

		}


		[SoapElement(ElementName="agendaDetails" )]
		[XmlElement(ElementName="agendaDetails" )]
		public SdtSDT_OneSignalCustomData_agendaDetails gxTpr_Agendadetails
		{
			get {
				if ( gxTv_SdtSDT_OneSignalCustomData_Agendadetails == null )
				{
					gxTv_SdtSDT_OneSignalCustomData_Agendadetails = new SdtSDT_OneSignalCustomData_agendaDetails(context);
				}
				gxTv_SdtSDT_OneSignalCustomData_Agendadetails_N = false;
				return gxTv_SdtSDT_OneSignalCustomData_Agendadetails;
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_Agendadetails_N = false;
				gxTv_SdtSDT_OneSignalCustomData_Agendadetails = value;
				SetDirty("Agendadetails");
			}

		}

		public void gxTv_SdtSDT_OneSignalCustomData_Agendadetails_SetNull()
		{
			gxTv_SdtSDT_OneSignalCustomData_Agendadetails_N = true;
			gxTv_SdtSDT_OneSignalCustomData_Agendadetails = null;
		}

		public bool gxTv_SdtSDT_OneSignalCustomData_Agendadetails_IsNull()
		{
			return gxTv_SdtSDT_OneSignalCustomData_Agendadetails == null;
		}
		public bool ShouldSerializegxTpr_Agendadetails_Json()
		{
				return (gxTv_SdtSDT_OneSignalCustomData_Agendadetails != null && gxTv_SdtSDT_OneSignalCustomData_Agendadetails.ShouldSerializeSdtJson());

		}



		[SoapElement(ElementName="toolboxDetails" )]
		[XmlArray(ElementName="toolboxDetails"  )]
		[XmlArrayItemAttribute(ElementName="toolboxDetailsItem" , IsNullable=false )]
		public GXBaseCollection<SdtSDT_OneSignalCustomData_toolboxDetailsItem> gxTpr_Toolboxdetails
		{
			get {
				if ( gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails == null )
				{
					gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails = new GXBaseCollection<SdtSDT_OneSignalCustomData_toolboxDetailsItem>( context, "SDT_OneSignalCustomData.toolboxDetailsItem", "");
				}
				return gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails;
			}
			set {
				gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails_N = false;
				gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails = value;
				SetDirty("Toolboxdetails");
			}
		}

		public void gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails_SetNull()
		{
			gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails_N = true;
			gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails = null;
		}

		public bool gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails_IsNull()
		{
			return gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails == null;
		}
		public bool ShouldSerializegxTpr_Toolboxdetails_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails != null && gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails.Count > 0;

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
			gxTv_SdtSDT_OneSignalCustomData_Notificationcategory = "";

			gxTv_SdtSDT_OneSignalCustomData_Formdetails_N = true;


			gxTv_SdtSDT_OneSignalCustomData_Discussiondetails_N = true;


			gxTv_SdtSDT_OneSignalCustomData_Agendadetails_N = true;


			gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_OneSignalCustomData_Notificationcategory;
		 
		protected bool gxTv_SdtSDT_OneSignalCustomData_Formdetails_N;
		protected SdtSDT_OneSignalCustomData_formDetails gxTv_SdtSDT_OneSignalCustomData_Formdetails = null; 

		protected bool gxTv_SdtSDT_OneSignalCustomData_Discussiondetails_N;
		protected SdtSDT_OneSignalCustomData_discussionDetails gxTv_SdtSDT_OneSignalCustomData_Discussiondetails = null; 

		protected bool gxTv_SdtSDT_OneSignalCustomData_Agendadetails_N;
		protected SdtSDT_OneSignalCustomData_agendaDetails gxTv_SdtSDT_OneSignalCustomData_Agendadetails = null; 

		protected bool gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails_N;
		protected GXBaseCollection<SdtSDT_OneSignalCustomData_toolboxDetailsItem> gxTv_SdtSDT_OneSignalCustomData_Toolboxdetails = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_OneSignalCustomData", Namespace="Comforta_version21")]
	public class SdtSDT_OneSignalCustomData_RESTInterface : GxGenericCollectionItem<SdtSDT_OneSignalCustomData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_OneSignalCustomData_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_OneSignalCustomData_RESTInterface( SdtSDT_OneSignalCustomData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="notificationCategory", Order=0)]
		public  string gxTpr_Notificationcategory
		{
			get { 
				return sdt.gxTpr_Notificationcategory;

			}
			set { 
				 sdt.gxTpr_Notificationcategory = value;
			}
		}

		[DataMember(Name="formDetails", Order=1, EmitDefaultValue=false)]
		public SdtSDT_OneSignalCustomData_formDetails_RESTInterface gxTpr_Formdetails
		{
			get {
				if (sdt.ShouldSerializegxTpr_Formdetails_Json())
					return new SdtSDT_OneSignalCustomData_formDetails_RESTInterface(sdt.gxTpr_Formdetails);
				else
					return null;

			}

			set {
				sdt.gxTpr_Formdetails = value.sdt;
			}

		}

		[DataMember(Name="discussionDetails", Order=2, EmitDefaultValue=false)]
		public SdtSDT_OneSignalCustomData_discussionDetails_RESTInterface gxTpr_Discussiondetails
		{
			get {
				if (sdt.ShouldSerializegxTpr_Discussiondetails_Json())
					return new SdtSDT_OneSignalCustomData_discussionDetails_RESTInterface(sdt.gxTpr_Discussiondetails);
				else
					return null;

			}

			set {
				sdt.gxTpr_Discussiondetails = value.sdt;
			}

		}

		[DataMember(Name="agendaDetails", Order=3, EmitDefaultValue=false)]
		public SdtSDT_OneSignalCustomData_agendaDetails_RESTInterface gxTpr_Agendadetails
		{
			get {
				if (sdt.ShouldSerializegxTpr_Agendadetails_Json())
					return new SdtSDT_OneSignalCustomData_agendaDetails_RESTInterface(sdt.gxTpr_Agendadetails);
				else
					return null;

			}

			set {
				sdt.gxTpr_Agendadetails = value.sdt;
			}

		}

		[DataMember(Name="toolboxDetails", Order=4, EmitDefaultValue=false)]
		public GxGenericCollection<SdtSDT_OneSignalCustomData_toolboxDetailsItem_RESTInterface> gxTpr_Toolboxdetails
		{
			get {
				if (sdt.ShouldSerializegxTpr_Toolboxdetails_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtSDT_OneSignalCustomData_toolboxDetailsItem_RESTInterface>(sdt.gxTpr_Toolboxdetails);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Toolboxdetails);
			}
		}


		#endregion

		public SdtSDT_OneSignalCustomData sdt
		{
			get { 
				return (SdtSDT_OneSignalCustomData)Sdt;
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
				sdt = new SdtSDT_OneSignalCustomData() ;
			}
		}
	}
	#endregion
}