/*
				   File: type_SdtSDT_Country_SDT_CountryItem
			Description: SDT_Country
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
	[XmlRoot(ElementName="SDT_CountryItem")]
	[XmlType(TypeName="SDT_CountryItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Country_SDT_CountryItem : GxUserType
	{
		public SdtSDT_Country_SDT_CountryItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Country_SDT_CountryItem_Countryname = "";

			gxTv_SdtSDT_Country_SDT_CountryItem_Countryflag = "";

			gxTv_SdtSDT_Country_SDT_CountryItem_Countrycode = "";

			gxTv_SdtSDT_Country_SDT_CountryItem_Countrydialcode = "";

		}

		public SdtSDT_Country_SDT_CountryItem(IGxContext context)
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
			AddObjectProperty("CountryName", gxTpr_Countryname, false);


			AddObjectProperty("CountryFlag", gxTpr_Countryflag, false);


			AddObjectProperty("CountryCode", gxTpr_Countrycode, false);


			AddObjectProperty("CountryDialCode", gxTpr_Countrydialcode, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CountryName")]
		[XmlElement(ElementName="CountryName")]
		public string gxTpr_Countryname
		{
			get {
				return gxTv_SdtSDT_Country_SDT_CountryItem_Countryname; 
			}
			set {
				gxTv_SdtSDT_Country_SDT_CountryItem_Countryname = value;
				SetDirty("Countryname");
			}
		}




		[SoapElement(ElementName="CountryFlag")]
		[XmlElement(ElementName="CountryFlag")]
		public string gxTpr_Countryflag
		{
			get {
				return gxTv_SdtSDT_Country_SDT_CountryItem_Countryflag; 
			}
			set {
				gxTv_SdtSDT_Country_SDT_CountryItem_Countryflag = value;
				SetDirty("Countryflag");
			}
		}




		[SoapElement(ElementName="CountryCode")]
		[XmlElement(ElementName="CountryCode")]
		public string gxTpr_Countrycode
		{
			get {
				return gxTv_SdtSDT_Country_SDT_CountryItem_Countrycode; 
			}
			set {
				gxTv_SdtSDT_Country_SDT_CountryItem_Countrycode = value;
				SetDirty("Countrycode");
			}
		}




		[SoapElement(ElementName="CountryDialCode")]
		[XmlElement(ElementName="CountryDialCode")]
		public string gxTpr_Countrydialcode
		{
			get {
				return gxTv_SdtSDT_Country_SDT_CountryItem_Countrydialcode; 
			}
			set {
				gxTv_SdtSDT_Country_SDT_CountryItem_Countrydialcode = value;
				SetDirty("Countrydialcode");
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
			gxTv_SdtSDT_Country_SDT_CountryItem_Countryname = "";
			gxTv_SdtSDT_Country_SDT_CountryItem_Countryflag = "";
			gxTv_SdtSDT_Country_SDT_CountryItem_Countrycode = "";
			gxTv_SdtSDT_Country_SDT_CountryItem_Countrydialcode = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_Country_SDT_CountryItem_Countryname;
		 

		protected string gxTv_SdtSDT_Country_SDT_CountryItem_Countryflag;
		 

		protected string gxTv_SdtSDT_Country_SDT_CountryItem_Countrycode;
		 

		protected string gxTv_SdtSDT_Country_SDT_CountryItem_Countrydialcode;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_CountryItem", Namespace="Comforta_version2")]
	public class SdtSDT_Country_SDT_CountryItem_RESTInterface : GxGenericCollectionItem<SdtSDT_Country_SDT_CountryItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Country_SDT_CountryItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Country_SDT_CountryItem_RESTInterface( SdtSDT_Country_SDT_CountryItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CountryName", Order=0)]
		public  string gxTpr_Countryname
		{
			get { 
				return sdt.gxTpr_Countryname;

			}
			set { 
				 sdt.gxTpr_Countryname = value;
			}
		}

		[DataMember(Name="CountryFlag", Order=1)]
		public  string gxTpr_Countryflag
		{
			get { 
				return sdt.gxTpr_Countryflag;

			}
			set { 
				 sdt.gxTpr_Countryflag = value;
			}
		}

		[DataMember(Name="CountryCode", Order=2)]
		public  string gxTpr_Countrycode
		{
			get { 
				return sdt.gxTpr_Countrycode;

			}
			set { 
				 sdt.gxTpr_Countrycode = value;
			}
		}

		[DataMember(Name="CountryDialCode", Order=3)]
		public  string gxTpr_Countrydialcode
		{
			get { 
				return sdt.gxTpr_Countrydialcode;

			}
			set { 
				 sdt.gxTpr_Countrydialcode = value;
			}
		}


		#endregion

		public SdtSDT_Country_SDT_CountryItem sdt
		{
			get { 
				return (SdtSDT_Country_SDT_CountryItem)Sdt;
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
				sdt = new SdtSDT_Country_SDT_CountryItem() ;
			}
		}
	}
	#endregion
}