/*
				   File: type_SdtWP_ProductServiceData_Step2
			Description: Step2
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
	[XmlRoot(ElementName="WP_ProductServiceData.Step2")]
	[XmlType(TypeName="WP_ProductServiceData.Step2" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtWP_ProductServiceData_Step2 : GxUserType
	{
		public SdtWP_ProductServiceData_Step2( )
		{
			/* Constructor for serialization */
			gxTv_SdtWP_ProductServiceData_Step2_Calltoactiontype = "";

			gxTv_SdtWP_ProductServiceData_Step2_Calltoactionname = "";

			gxTv_SdtWP_ProductServiceData_Step2_Wwpformreferencename = "";

			gxTv_SdtWP_ProductServiceData_Step2_Calltoactionphone = "";

			gxTv_SdtWP_ProductServiceData_Step2_Calltoactionemail = "";

			gxTv_SdtWP_ProductServiceData_Step2_Phonenumber = "";

			gxTv_SdtWP_ProductServiceData_Step2_Phonecode = "";

			gxTv_SdtWP_ProductServiceData_Step2_Calltoactionurl = "";

		}

		public SdtWP_ProductServiceData_Step2(IGxContext context)
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
			AddObjectProperty("CallToActionId", gxTpr_Calltoactionid, false);


			AddObjectProperty("CallToActionType", gxTpr_Calltoactiontype, false);


			AddObjectProperty("CallToActionName", gxTpr_Calltoactionname, false);


			AddObjectProperty("WWPFormReferenceName", gxTpr_Wwpformreferencename, false);


			AddObjectProperty("CallToActionPhone", gxTpr_Calltoactionphone, false);


			AddObjectProperty("CallToActionEmail", gxTpr_Calltoactionemail, false);


			AddObjectProperty("LocationDynamicFormId", gxTpr_Locationdynamicformid, false);


			AddObjectProperty("PhoneNumber", gxTpr_Phonenumber, false);


			AddObjectProperty("PhoneCode", gxTpr_Phonecode, false);


			AddObjectProperty("CallToActionUrl", gxTpr_Calltoactionurl, false);

			if (gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction != null)
			{
				AddObjectProperty("SDT_CallToAction", gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CallToActionId")]
		[XmlElement(ElementName="CallToActionId")]
		public Guid gxTpr_Calltoactionid
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step2_Calltoactionid; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step2_Calltoactionid = value;
				SetDirty("Calltoactionid");
			}
		}




		[SoapElement(ElementName="CallToActionType")]
		[XmlElement(ElementName="CallToActionType")]
		public string gxTpr_Calltoactiontype
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step2_Calltoactiontype; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step2_Calltoactiontype = value;
				SetDirty("Calltoactiontype");
			}
		}




		[SoapElement(ElementName="CallToActionName")]
		[XmlElement(ElementName="CallToActionName")]
		public string gxTpr_Calltoactionname
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step2_Calltoactionname; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step2_Calltoactionname = value;
				SetDirty("Calltoactionname");
			}
		}




		[SoapElement(ElementName="WWPFormReferenceName")]
		[XmlElement(ElementName="WWPFormReferenceName")]
		public string gxTpr_Wwpformreferencename
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step2_Wwpformreferencename; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step2_Wwpformreferencename = value;
				SetDirty("Wwpformreferencename");
			}
		}




		[SoapElement(ElementName="CallToActionPhone")]
		[XmlElement(ElementName="CallToActionPhone")]
		public string gxTpr_Calltoactionphone
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step2_Calltoactionphone; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step2_Calltoactionphone = value;
				SetDirty("Calltoactionphone");
			}
		}




		[SoapElement(ElementName="CallToActionEmail")]
		[XmlElement(ElementName="CallToActionEmail")]
		public string gxTpr_Calltoactionemail
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step2_Calltoactionemail; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step2_Calltoactionemail = value;
				SetDirty("Calltoactionemail");
			}
		}




		[SoapElement(ElementName="LocationDynamicFormId")]
		[XmlElement(ElementName="LocationDynamicFormId")]
		public Guid gxTpr_Locationdynamicformid
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step2_Locationdynamicformid; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step2_Locationdynamicformid = value;
				SetDirty("Locationdynamicformid");
			}
		}




		[SoapElement(ElementName="PhoneNumber")]
		[XmlElement(ElementName="PhoneNumber")]
		public string gxTpr_Phonenumber
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step2_Phonenumber; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step2_Phonenumber = value;
				SetDirty("Phonenumber");
			}
		}




		[SoapElement(ElementName="PhoneCode")]
		[XmlElement(ElementName="PhoneCode")]
		public string gxTpr_Phonecode
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step2_Phonecode; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step2_Phonecode = value;
				SetDirty("Phonecode");
			}
		}




		[SoapElement(ElementName="CallToActionUrl")]
		[XmlElement(ElementName="CallToActionUrl")]
		public string gxTpr_Calltoactionurl
		{
			get {
				return gxTv_SdtWP_ProductServiceData_Step2_Calltoactionurl; 
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step2_Calltoactionurl = value;
				SetDirty("Calltoactionurl");
			}
		}




		[SoapElement(ElementName="SDT_CallToAction" )]
		[XmlArray(ElementName="SDT_CallToAction"  )]
		[XmlArrayItemAttribute(ElementName="SDT_CallToActionItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_CallToAction_SDT_CallToActionItem> gxTpr_Sdt_calltoaction_GXBaseCollection
		{
			get {
				if ( gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction == null )
				{
					gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction = new GXBaseCollection<GeneXus.Programs.SdtSDT_CallToAction_SDT_CallToActionItem>( context, "SDT_CallToAction", "");
				}
				return gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction;
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction_N = false;
				gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_CallToAction_SDT_CallToActionItem> gxTpr_Sdt_calltoaction
		{
			get {
				if ( gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction == null )
				{
					gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction = new GXBaseCollection<GeneXus.Programs.SdtSDT_CallToAction_SDT_CallToActionItem>( context, "SDT_CallToAction", "");
				}
				gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction_N = false;
				return gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction ;
			}
			set {
				gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction_N = false;
				gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction = value;
				SetDirty("Sdt_calltoaction");
			}
		}

		public void gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction_SetNull()
		{
			gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction_N = true;
			gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction = null;
		}

		public bool gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction_IsNull()
		{
			return gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction == null;
		}
		public bool ShouldSerializegxTpr_Sdt_calltoaction_GXBaseCollection_Json()
		{
			return gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction != null && gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction.Count > 0;

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
			gxTv_SdtWP_ProductServiceData_Step2_Calltoactiontype = "";
			gxTv_SdtWP_ProductServiceData_Step2_Calltoactionname = "";
			gxTv_SdtWP_ProductServiceData_Step2_Wwpformreferencename = "";
			gxTv_SdtWP_ProductServiceData_Step2_Calltoactionphone = "";
			gxTv_SdtWP_ProductServiceData_Step2_Calltoactionemail = "";

			gxTv_SdtWP_ProductServiceData_Step2_Phonenumber = "";
			gxTv_SdtWP_ProductServiceData_Step2_Phonecode = "";
			gxTv_SdtWP_ProductServiceData_Step2_Calltoactionurl = "";

			gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtWP_ProductServiceData_Step2_Calltoactionid;
		 

		protected string gxTv_SdtWP_ProductServiceData_Step2_Calltoactiontype;
		 

		protected string gxTv_SdtWP_ProductServiceData_Step2_Calltoactionname;
		 

		protected string gxTv_SdtWP_ProductServiceData_Step2_Wwpformreferencename;
		 

		protected string gxTv_SdtWP_ProductServiceData_Step2_Calltoactionphone;
		 

		protected string gxTv_SdtWP_ProductServiceData_Step2_Calltoactionemail;
		 

		protected Guid gxTv_SdtWP_ProductServiceData_Step2_Locationdynamicformid;
		 

		protected string gxTv_SdtWP_ProductServiceData_Step2_Phonenumber;
		 

		protected string gxTv_SdtWP_ProductServiceData_Step2_Phonecode;
		 

		protected string gxTv_SdtWP_ProductServiceData_Step2_Calltoactionurl;
		 
		protected bool gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_CallToAction_SDT_CallToActionItem> gxTv_SdtWP_ProductServiceData_Step2_Sdt_calltoaction = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WP_ProductServiceData.Step2", Namespace="Comforta_version21")]
	public class SdtWP_ProductServiceData_Step2_RESTInterface : GxGenericCollectionItem<SdtWP_ProductServiceData_Step2>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWP_ProductServiceData_Step2_RESTInterface( ) : base()
		{	
		}

		public SdtWP_ProductServiceData_Step2_RESTInterface( SdtWP_ProductServiceData_Step2 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CallToActionId", Order=0)]
		public Guid gxTpr_Calltoactionid
		{
			get { 
				return sdt.gxTpr_Calltoactionid;

			}
			set { 
				sdt.gxTpr_Calltoactionid = value;
			}
		}

		[DataMember(Name="CallToActionType", Order=1)]
		public  string gxTpr_Calltoactiontype
		{
			get { 
				return sdt.gxTpr_Calltoactiontype;

			}
			set { 
				 sdt.gxTpr_Calltoactiontype = value;
			}
		}

		[DataMember(Name="CallToActionName", Order=2)]
		public  string gxTpr_Calltoactionname
		{
			get { 
				return sdt.gxTpr_Calltoactionname;

			}
			set { 
				 sdt.gxTpr_Calltoactionname = value;
			}
		}

		[DataMember(Name="WWPFormReferenceName", Order=3)]
		public  string gxTpr_Wwpformreferencename
		{
			get { 
				return sdt.gxTpr_Wwpformreferencename;

			}
			set { 
				 sdt.gxTpr_Wwpformreferencename = value;
			}
		}

		[DataMember(Name="CallToActionPhone", Order=4)]
		public  string gxTpr_Calltoactionphone
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Calltoactionphone);

			}
			set { 
				 sdt.gxTpr_Calltoactionphone = value;
			}
		}

		[DataMember(Name="CallToActionEmail", Order=5)]
		public  string gxTpr_Calltoactionemail
		{
			get { 
				return sdt.gxTpr_Calltoactionemail;

			}
			set { 
				 sdt.gxTpr_Calltoactionemail = value;
			}
		}

		[DataMember(Name="LocationDynamicFormId", Order=6)]
		public Guid gxTpr_Locationdynamicformid
		{
			get { 
				return sdt.gxTpr_Locationdynamicformid;

			}
			set { 
				sdt.gxTpr_Locationdynamicformid = value;
			}
		}

		[DataMember(Name="PhoneNumber", Order=7)]
		public  string gxTpr_Phonenumber
		{
			get { 
				return sdt.gxTpr_Phonenumber;

			}
			set { 
				 sdt.gxTpr_Phonenumber = value;
			}
		}

		[DataMember(Name="PhoneCode", Order=8)]
		public  string gxTpr_Phonecode
		{
			get { 
				return sdt.gxTpr_Phonecode;

			}
			set { 
				 sdt.gxTpr_Phonecode = value;
			}
		}

		[DataMember(Name="CallToActionUrl", Order=9)]
		public  string gxTpr_Calltoactionurl
		{
			get { 
				return sdt.gxTpr_Calltoactionurl;

			}
			set { 
				 sdt.gxTpr_Calltoactionurl = value;
			}
		}

		[DataMember(Name="SDT_CallToAction", Order=10, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_CallToAction_SDT_CallToActionItem_RESTInterface> gxTpr_Sdt_calltoaction
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Sdt_calltoaction_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_CallToAction_SDT_CallToActionItem_RESTInterface>(sdt.gxTpr_Sdt_calltoaction);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Sdt_calltoaction);
			}
		}


		#endregion

		public SdtWP_ProductServiceData_Step2 sdt
		{
			get { 
				return (SdtWP_ProductServiceData_Step2)Sdt;
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
				sdt = new SdtWP_ProductServiceData_Step2() ;
			}
		}
	}
	#endregion
}