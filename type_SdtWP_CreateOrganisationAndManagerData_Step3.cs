/*
				   File: type_SdtWP_CreateOrganisationAndManagerData_Step3
			Description: Step3
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
	[XmlRoot(ElementName="WP_CreateOrganisationAndManagerData.Step3")]
	[XmlType(TypeName="WP_CreateOrganisationAndManagerData.Step3" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtWP_CreateOrganisationAndManagerData_Step3 : GxUserType
	{
		public SdtWP_CreateOrganisationAndManagerData_Step3( )
		{
			/* Constructor for serialization */
		}

		public SdtWP_CreateOrganisationAndManagerData_Step3(IGxContext context)
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
			AddObjectProperty("OrganisationHasMyCare", gxTpr_Organisationhasmycare, false);


			AddObjectProperty("OrganisationHasMyLiving", gxTpr_Organisationhasmyliving, false);


			AddObjectProperty("OrganisationHasMyServices", gxTpr_Organisationhasmyservices, false);


			AddObjectProperty("OrganisationHasDynamicForms", gxTpr_Organisationhasdynamicforms, false);


			AddObjectProperty("OrganisationHasOwnBrand", gxTpr_Organisationhasownbrand, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="OrganisationHasMyCare")]
		[XmlElement(ElementName="OrganisationHasMyCare")]
		public bool gxTpr_Organisationhasmycare
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmycare; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmycare = value;
				SetDirty("Organisationhasmycare");
			}
		}




		[SoapElement(ElementName="OrganisationHasMyLiving")]
		[XmlElement(ElementName="OrganisationHasMyLiving")]
		public bool gxTpr_Organisationhasmyliving
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmyliving; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmyliving = value;
				SetDirty("Organisationhasmyliving");
			}
		}




		[SoapElement(ElementName="OrganisationHasMyServices")]
		[XmlElement(ElementName="OrganisationHasMyServices")]
		public bool gxTpr_Organisationhasmyservices
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmyservices; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmyservices = value;
				SetDirty("Organisationhasmyservices");
			}
		}




		[SoapElement(ElementName="OrganisationHasDynamicForms")]
		[XmlElement(ElementName="OrganisationHasDynamicForms")]
		public bool gxTpr_Organisationhasdynamicforms
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasdynamicforms; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasdynamicforms = value;
				SetDirty("Organisationhasdynamicforms");
			}
		}




		[SoapElement(ElementName="OrganisationHasOwnBrand")]
		[XmlElement(ElementName="OrganisationHasOwnBrand")]
		public bool gxTpr_Organisationhasownbrand
		{
			get {
				return gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasownbrand; 
			}
			set {
				gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasownbrand = value;
				SetDirty("Organisationhasownbrand");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmycare;
		 

		protected bool gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmyliving;
		 

		protected bool gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasmyservices;
		 

		protected bool gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasdynamicforms;
		 

		protected bool gxTv_SdtWP_CreateOrganisationAndManagerData_Step3_Organisationhasownbrand;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WP_CreateOrganisationAndManagerData.Step3", Namespace="Comforta_version21")]
	public class SdtWP_CreateOrganisationAndManagerData_Step3_RESTInterface : GxGenericCollectionItem<SdtWP_CreateOrganisationAndManagerData_Step3>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWP_CreateOrganisationAndManagerData_Step3_RESTInterface( ) : base()
		{	
		}

		public SdtWP_CreateOrganisationAndManagerData_Step3_RESTInterface( SdtWP_CreateOrganisationAndManagerData_Step3 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="OrganisationHasMyCare", Order=0)]
		public bool gxTpr_Organisationhasmycare
		{
			get { 
				return sdt.gxTpr_Organisationhasmycare;

			}
			set { 
				sdt.gxTpr_Organisationhasmycare = value;
			}
		}

		[DataMember(Name="OrganisationHasMyLiving", Order=1)]
		public bool gxTpr_Organisationhasmyliving
		{
			get { 
				return sdt.gxTpr_Organisationhasmyliving;

			}
			set { 
				sdt.gxTpr_Organisationhasmyliving = value;
			}
		}

		[DataMember(Name="OrganisationHasMyServices", Order=2)]
		public bool gxTpr_Organisationhasmyservices
		{
			get { 
				return sdt.gxTpr_Organisationhasmyservices;

			}
			set { 
				sdt.gxTpr_Organisationhasmyservices = value;
			}
		}

		[DataMember(Name="OrganisationHasDynamicForms", Order=3)]
		public bool gxTpr_Organisationhasdynamicforms
		{
			get { 
				return sdt.gxTpr_Organisationhasdynamicforms;

			}
			set { 
				sdt.gxTpr_Organisationhasdynamicforms = value;
			}
		}

		[DataMember(Name="OrganisationHasOwnBrand", Order=4)]
		public bool gxTpr_Organisationhasownbrand
		{
			get { 
				return sdt.gxTpr_Organisationhasownbrand;

			}
			set { 
				sdt.gxTpr_Organisationhasownbrand = value;
			}
		}


		#endregion

		public SdtWP_CreateOrganisationAndManagerData_Step3 sdt
		{
			get { 
				return (SdtWP_CreateOrganisationAndManagerData_Step3)Sdt;
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
				sdt = new SdtWP_CreateOrganisationAndManagerData_Step3() ;
			}
		}
	}
	#endregion
}