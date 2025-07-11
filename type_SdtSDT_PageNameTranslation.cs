/*
				   File: type_SdtSDT_PageNameTranslation
			Description: SDT_PageNameTranslation
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
	[XmlRoot(ElementName="SDT_PageNameTranslation")]
	[XmlType(TypeName="SDT_PageNameTranslation" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_PageNameTranslation : GxUserType
	{
		public SdtSDT_PageNameTranslation( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_PageNameTranslation_Pagetype = "";

			gxTv_SdtSDT_PageNameTranslation_Pageattributetype = "";

			gxTv_SdtSDT_PageNameTranslation_Pagename = "";

		}

		public SdtSDT_PageNameTranslation(IGxContext context)
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


			AddObjectProperty("PageAttributeType", gxTpr_Pageattributetype, false);


			AddObjectProperty("PageName", gxTpr_Pagename, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PageId")]
		[XmlElement(ElementName="PageId")]
		public Guid gxTpr_Pageid
		{
			get {
				return gxTv_SdtSDT_PageNameTranslation_Pageid; 
			}
			set {
				gxTv_SdtSDT_PageNameTranslation_Pageid = value;
				SetDirty("Pageid");
			}
		}




		[SoapElement(ElementName="PageType")]
		[XmlElement(ElementName="PageType")]
		public string gxTpr_Pagetype
		{
			get {
				return gxTv_SdtSDT_PageNameTranslation_Pagetype; 
			}
			set {
				gxTv_SdtSDT_PageNameTranslation_Pagetype = value;
				SetDirty("Pagetype");
			}
		}




		[SoapElement(ElementName="PageAttributeType")]
		[XmlElement(ElementName="PageAttributeType")]
		public string gxTpr_Pageattributetype
		{
			get {
				return gxTv_SdtSDT_PageNameTranslation_Pageattributetype; 
			}
			set {
				gxTv_SdtSDT_PageNameTranslation_Pageattributetype = value;
				SetDirty("Pageattributetype");
			}
		}




		[SoapElement(ElementName="PageName")]
		[XmlElement(ElementName="PageName")]
		public string gxTpr_Pagename
		{
			get {
				return gxTv_SdtSDT_PageNameTranslation_Pagename; 
			}
			set {
				gxTv_SdtSDT_PageNameTranslation_Pagename = value;
				SetDirty("Pagename");
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
			gxTv_SdtSDT_PageNameTranslation_Pagetype = "";
			gxTv_SdtSDT_PageNameTranslation_Pageattributetype = "";
			gxTv_SdtSDT_PageNameTranslation_Pagename = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_PageNameTranslation_Pageid;
		 

		protected string gxTv_SdtSDT_PageNameTranslation_Pagetype;
		 

		protected string gxTv_SdtSDT_PageNameTranslation_Pageattributetype;
		 

		protected string gxTv_SdtSDT_PageNameTranslation_Pagename;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_PageNameTranslation", Namespace="Comforta_version2")]
	public class SdtSDT_PageNameTranslation_RESTInterface : GxGenericCollectionItem<SdtSDT_PageNameTranslation>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_PageNameTranslation_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_PageNameTranslation_RESTInterface( SdtSDT_PageNameTranslation psdt ) : base(psdt)
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

		[DataMember(Name="PageAttributeType", Order=2)]
		public  string gxTpr_Pageattributetype
		{
			get { 
				return sdt.gxTpr_Pageattributetype;

			}
			set { 
				 sdt.gxTpr_Pageattributetype = value;
			}
		}

		[DataMember(Name="PageName", Order=3)]
		public  string gxTpr_Pagename
		{
			get { 
				return sdt.gxTpr_Pagename;

			}
			set { 
				 sdt.gxTpr_Pagename = value;
			}
		}


		#endregion

		public SdtSDT_PageNameTranslation sdt
		{
			get { 
				return (SdtSDT_PageNameTranslation)Sdt;
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
				sdt = new SdtSDT_PageNameTranslation() ;
			}
		}
	}
	#endregion
}