/*
				   File: type_SdtSDT_InfoPageTranslation
			Description: SDT_InfoPageTranslation
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
	[XmlRoot(ElementName="SDT_InfoPageTranslation")]
	[XmlType(TypeName="SDT_InfoPageTranslation" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_InfoPageTranslation : GxUserType
	{
		public SdtSDT_InfoPageTranslation( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_InfoPageTranslation_Pagetype = "";

			gxTv_SdtSDT_InfoPageTranslation_Pagepublishedstructure = "";

		}

		public SdtSDT_InfoPageTranslation(IGxContext context)
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
			AddObjectProperty("PageId", gxTpr_Pageid, false);


			AddObjectProperty("PageType", gxTpr_Pagetype, false);


			AddObjectProperty("PagePublishedStructure", gxTpr_Pagepublishedstructure, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PageId")]
		[XmlElement(ElementName="PageId")]
		public Guid gxTpr_Pageid
		{
			get {
				return gxTv_SdtSDT_InfoPageTranslation_Pageid; 
			}
			set {
				gxTv_SdtSDT_InfoPageTranslation_Pageid = value;
				SetDirty("Pageid");
			}
		}




		[SoapElement(ElementName="PageType")]
		[XmlElement(ElementName="PageType")]
		public string gxTpr_Pagetype
		{
			get {
				return gxTv_SdtSDT_InfoPageTranslation_Pagetype; 
			}
			set {
				gxTv_SdtSDT_InfoPageTranslation_Pagetype = value;
				SetDirty("Pagetype");
			}
		}




		[SoapElement(ElementName="PagePublishedStructure")]
		[XmlElement(ElementName="PagePublishedStructure")]
		public string gxTpr_Pagepublishedstructure
		{
			get {
				return gxTv_SdtSDT_InfoPageTranslation_Pagepublishedstructure; 
			}
			set {
				gxTv_SdtSDT_InfoPageTranslation_Pagepublishedstructure = value;
				SetDirty("Pagepublishedstructure");
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
			gxTv_SdtSDT_InfoPageTranslation_Pagetype = "";
			gxTv_SdtSDT_InfoPageTranslation_Pagepublishedstructure = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_InfoPageTranslation_Pageid;
		 

		protected string gxTv_SdtSDT_InfoPageTranslation_Pagetype;
		 

		protected string gxTv_SdtSDT_InfoPageTranslation_Pagepublishedstructure;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_InfoPageTranslation", Namespace="Comforta_version2")]
	public class SdtSDT_InfoPageTranslation_RESTInterface : GxGenericCollectionItem<SdtSDT_InfoPageTranslation>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_InfoPageTranslation_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_InfoPageTranslation_RESTInterface( SdtSDT_InfoPageTranslation psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PageId", Order=0)]
		public Guid gxTpr_Pageid
		{
			get { 
				return sdt.gxTpr_Pageid;

			}
			set { 
				sdt.gxTpr_Pageid = value;
			}
		}

		[DataMember(Name="PageType", Order=1)]
		public  string gxTpr_Pagetype
		{
			get { 
				return sdt.gxTpr_Pagetype;

			}
			set { 
				 sdt.gxTpr_Pagetype = value;
			}
		}

		[DataMember(Name="PagePublishedStructure", Order=2)]
		public  string gxTpr_Pagepublishedstructure
		{
			get { 
				return sdt.gxTpr_Pagepublishedstructure;

			}
			set { 
				 sdt.gxTpr_Pagepublishedstructure = value;
			}
		}


		#endregion

		public SdtSDT_InfoPageTranslation sdt
		{
			get { 
				return (SdtSDT_InfoPageTranslation)Sdt;
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
				sdt = new SdtSDT_InfoPageTranslation() ;
			}
		}
	}
	#endregion
}