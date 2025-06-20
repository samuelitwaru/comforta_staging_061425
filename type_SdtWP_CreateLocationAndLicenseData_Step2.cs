/*
				   File: type_SdtWP_CreateLocationAndLicenseData_Step2
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
	[XmlRoot(ElementName="WP_CreateLocationAndLicenseData.Step2")]
	[XmlType(TypeName="WP_CreateLocationAndLicenseData.Step2" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtWP_CreateLocationAndLicenseData_Step2 : GxUserType
	{
		public SdtWP_CreateLocationAndLicenseData_Step2( )
		{
			/* Constructor for serialization */
		}

		public SdtWP_CreateLocationAndLicenseData_Step2(IGxContext context)
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
			AddObjectProperty("LocationHasMyCare", gxTpr_Locationhasmycare, false);


			AddObjectProperty("LocationHasMyLiving", gxTpr_Locationhasmyliving, false);


			AddObjectProperty("LocationHasMyServices", gxTpr_Locationhasmyservices, false);


			AddObjectProperty("LocationHasOwnBrand", gxTpr_Locationhasownbrand, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="LocationHasMyCare")]
		[XmlElement(ElementName="LocationHasMyCare")]
		public bool gxTpr_Locationhasmycare
		{
			get {
				return gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasmycare; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasmycare = value;
				SetDirty("Locationhasmycare");
			}
		}




		[SoapElement(ElementName="LocationHasMyLiving")]
		[XmlElement(ElementName="LocationHasMyLiving")]
		public bool gxTpr_Locationhasmyliving
		{
			get {
				return gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasmyliving; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasmyliving = value;
				SetDirty("Locationhasmyliving");
			}
		}




		[SoapElement(ElementName="LocationHasMyServices")]
		[XmlElement(ElementName="LocationHasMyServices")]
		public bool gxTpr_Locationhasmyservices
		{
			get {
				return gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasmyservices; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasmyservices = value;
				SetDirty("Locationhasmyservices");
			}
		}




		[SoapElement(ElementName="LocationHasOwnBrand")]
		[XmlElement(ElementName="LocationHasOwnBrand")]
		public bool gxTpr_Locationhasownbrand
		{
			get {
				return gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasownbrand; 
			}
			set {
				gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasownbrand = value;
				SetDirty("Locationhasownbrand");
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
			gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasmycare = false;
			gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasmyliving = false;
			gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasmyservices = false;
			gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasownbrand = false;
			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasmycare;
		 

		protected bool gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasmyliving;
		 

		protected bool gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasmyservices;
		 

		protected bool gxTv_SdtWP_CreateLocationAndLicenseData_Step2_Locationhasownbrand;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"WP_CreateLocationAndLicenseData.Step2", Namespace="Comforta_version2")]
	public class SdtWP_CreateLocationAndLicenseData_Step2_RESTInterface : GxGenericCollectionItem<SdtWP_CreateLocationAndLicenseData_Step2>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtWP_CreateLocationAndLicenseData_Step2_RESTInterface( ) : base()
		{	
		}

		public SdtWP_CreateLocationAndLicenseData_Step2_RESTInterface( SdtWP_CreateLocationAndLicenseData_Step2 psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="LocationHasMyCare", Order=0)]
		public bool gxTpr_Locationhasmycare
		{
			get { 
				return sdt.gxTpr_Locationhasmycare;

			}
			set { 
				sdt.gxTpr_Locationhasmycare = value;
			}
		}

		[DataMember(Name="LocationHasMyLiving", Order=1)]
		public bool gxTpr_Locationhasmyliving
		{
			get { 
				return sdt.gxTpr_Locationhasmyliving;

			}
			set { 
				sdt.gxTpr_Locationhasmyliving = value;
			}
		}

		[DataMember(Name="LocationHasMyServices", Order=2)]
		public bool gxTpr_Locationhasmyservices
		{
			get { 
				return sdt.gxTpr_Locationhasmyservices;

			}
			set { 
				sdt.gxTpr_Locationhasmyservices = value;
			}
		}

		[DataMember(Name="LocationHasOwnBrand", Order=3)]
		public bool gxTpr_Locationhasownbrand
		{
			get { 
				return sdt.gxTpr_Locationhasownbrand;

			}
			set { 
				sdt.gxTpr_Locationhasownbrand = value;
			}
		}


		#endregion

		public SdtWP_CreateLocationAndLicenseData_Step2 sdt
		{
			get { 
				return (SdtWP_CreateLocationAndLicenseData_Step2)Sdt;
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
				sdt = new SdtWP_CreateLocationAndLicenseData_Step2() ;
			}
		}
	}
	#endregion
}