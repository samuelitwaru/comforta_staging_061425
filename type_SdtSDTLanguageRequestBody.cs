/*
				   File: type_SdtSDTLanguageRequestBody
			Description: SDTLanguageRequestBody
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
	[XmlRoot(ElementName="SDTLanguageRequestBody")]
	[XmlType(TypeName="SDTLanguageRequestBody" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDTLanguageRequestBody : GxUserType
	{
		public SdtSDTLanguageRequestBody( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDTLanguageRequestBody_From = "";

			gxTv_SdtSDTLanguageRequestBody_To = "";

			gxTv_SdtSDTLanguageRequestBody_Data = "";

			gxTv_SdtSDTLanguageRequestBody_Platform = "";

			gxTv_SdtSDTLanguageRequestBody_Translatemode = "";

		}

		public SdtSDTLanguageRequestBody(IGxContext context)
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
			AddObjectProperty("from", gxTpr_From, false);


			AddObjectProperty("to", gxTpr_To, false);


			AddObjectProperty("data", gxTpr_Data, false);


			AddObjectProperty("platform", gxTpr_Platform, false);


			AddObjectProperty("translateMode", gxTpr_Translatemode, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="from")]
		[XmlElement(ElementName="from")]
		public string gxTpr_From
		{
			get {
				return gxTv_SdtSDTLanguageRequestBody_From; 
			}
			set {
				gxTv_SdtSDTLanguageRequestBody_From = value;
				SetDirty("From");
			}
		}




		[SoapElement(ElementName="to")]
		[XmlElement(ElementName="to")]
		public string gxTpr_To
		{
			get {
				return gxTv_SdtSDTLanguageRequestBody_To; 
			}
			set {
				gxTv_SdtSDTLanguageRequestBody_To = value;
				SetDirty("To");
			}
		}




		[SoapElement(ElementName="data")]
		[XmlElement(ElementName="data")]
		public string gxTpr_Data
		{
			get {
				return gxTv_SdtSDTLanguageRequestBody_Data; 
			}
			set {
				gxTv_SdtSDTLanguageRequestBody_Data = value;
				SetDirty("Data");
			}
		}




		[SoapElement(ElementName="platform")]
		[XmlElement(ElementName="platform")]
		public string gxTpr_Platform
		{
			get {
				return gxTv_SdtSDTLanguageRequestBody_Platform; 
			}
			set {
				gxTv_SdtSDTLanguageRequestBody_Platform = value;
				SetDirty("Platform");
			}
		}




		[SoapElement(ElementName="translateMode")]
		[XmlElement(ElementName="translateMode")]
		public string gxTpr_Translatemode
		{
			get {
				return gxTv_SdtSDTLanguageRequestBody_Translatemode; 
			}
			set {
				gxTv_SdtSDTLanguageRequestBody_Translatemode = value;
				SetDirty("Translatemode");
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
			gxTv_SdtSDTLanguageRequestBody_From = "";
			gxTv_SdtSDTLanguageRequestBody_To = "";
			gxTv_SdtSDTLanguageRequestBody_Data = "";
			gxTv_SdtSDTLanguageRequestBody_Platform = "";
			gxTv_SdtSDTLanguageRequestBody_Translatemode = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDTLanguageRequestBody_From;
		 

		protected string gxTv_SdtSDTLanguageRequestBody_To;
		 

		protected string gxTv_SdtSDTLanguageRequestBody_Data;
		 

		protected string gxTv_SdtSDTLanguageRequestBody_Platform;
		 

		protected string gxTv_SdtSDTLanguageRequestBody_Translatemode;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDTLanguageRequestBody", Namespace="Comforta_version21")]
	public class SdtSDTLanguageRequestBody_RESTInterface : GxGenericCollectionItem<SdtSDTLanguageRequestBody>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDTLanguageRequestBody_RESTInterface( ) : base()
		{	
		}

		public SdtSDTLanguageRequestBody_RESTInterface( SdtSDTLanguageRequestBody psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="from", Order=0)]
		public  string gxTpr_From
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_From);

			}
			set { 
				 sdt.gxTpr_From = value;
			}
		}

		[DataMember(Name="to", Order=1)]
		public  string gxTpr_To
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_To);

			}
			set { 
				 sdt.gxTpr_To = value;
			}
		}

		[DataMember(Name="data", Order=2)]
		public  string gxTpr_Data
		{
			get { 
				return sdt.gxTpr_Data;

			}
			set { 
				 sdt.gxTpr_Data = value;
			}
		}

		[DataMember(Name="platform", Order=3)]
		public  string gxTpr_Platform
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Platform);

			}
			set { 
				 sdt.gxTpr_Platform = value;
			}
		}

		[DataMember(Name="translateMode", Order=4)]
		public  string gxTpr_Translatemode
		{
			get { 
				return sdt.gxTpr_Translatemode;

			}
			set { 
				 sdt.gxTpr_Translatemode = value;
			}
		}


		#endregion

		public SdtSDTLanguageRequestBody sdt
		{
			get { 
				return (SdtSDTLanguageRequestBody)Sdt;
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
				sdt = new SdtSDTLanguageRequestBody() ;
			}
		}
	}
	#endregion
}