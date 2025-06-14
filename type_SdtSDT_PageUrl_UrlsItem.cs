/*
				   File: type_SdtSDT_PageUrl_UrlsItem
			Description: Urls
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
	[XmlRoot(ElementName="SDT_PageUrl.UrlsItem")]
	[XmlType(TypeName="SDT_PageUrl.UrlsItem" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_PageUrl_UrlsItem : GxUserType
	{
		public SdtSDT_PageUrl_UrlsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_PageUrl_UrlsItem_Url = "";

			gxTv_SdtSDT_PageUrl_UrlsItem_Affectedtype = "";

			gxTv_SdtSDT_PageUrl_UrlsItem_Affectedname = "";

		}

		public SdtSDT_PageUrl_UrlsItem(IGxContext context)
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
			AddObjectProperty("Url", gxTpr_Url, false);


			AddObjectProperty("AffectedType", gxTpr_Affectedtype, false);


			AddObjectProperty("AffectedName", gxTpr_Affectedname, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Url")]
		[XmlElement(ElementName="Url")]
		public string gxTpr_Url
		{
			get {
				return gxTv_SdtSDT_PageUrl_UrlsItem_Url; 
			}
			set {
				gxTv_SdtSDT_PageUrl_UrlsItem_Url = value;
				SetDirty("Url");
			}
		}




		[SoapElement(ElementName="AffectedType")]
		[XmlElement(ElementName="AffectedType")]
		public string gxTpr_Affectedtype
		{
			get {
				return gxTv_SdtSDT_PageUrl_UrlsItem_Affectedtype; 
			}
			set {
				gxTv_SdtSDT_PageUrl_UrlsItem_Affectedtype = value;
				SetDirty("Affectedtype");
			}
		}




		[SoapElement(ElementName="AffectedName")]
		[XmlElement(ElementName="AffectedName")]
		public string gxTpr_Affectedname
		{
			get {
				return gxTv_SdtSDT_PageUrl_UrlsItem_Affectedname; 
			}
			set {
				gxTv_SdtSDT_PageUrl_UrlsItem_Affectedname = value;
				SetDirty("Affectedname");
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
			gxTv_SdtSDT_PageUrl_UrlsItem_Url = "";
			gxTv_SdtSDT_PageUrl_UrlsItem_Affectedtype = "";
			gxTv_SdtSDT_PageUrl_UrlsItem_Affectedname = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_PageUrl_UrlsItem_Url;
		 

		protected string gxTv_SdtSDT_PageUrl_UrlsItem_Affectedtype;
		 

		protected string gxTv_SdtSDT_PageUrl_UrlsItem_Affectedname;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_PageUrl.UrlsItem", Namespace="Comforta_version21")]
	public class SdtSDT_PageUrl_UrlsItem_RESTInterface : GxGenericCollectionItem<SdtSDT_PageUrl_UrlsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_PageUrl_UrlsItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_PageUrl_UrlsItem_RESTInterface( SdtSDT_PageUrl_UrlsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Url", Order=0)]
		public  string gxTpr_Url
		{
			get { 
				return sdt.gxTpr_Url;

			}
			set { 
				 sdt.gxTpr_Url = value;
			}
		}

		[DataMember(Name="AffectedType", Order=1)]
		public  string gxTpr_Affectedtype
		{
			get { 
				return sdt.gxTpr_Affectedtype;

			}
			set { 
				 sdt.gxTpr_Affectedtype = value;
			}
		}

		[DataMember(Name="AffectedName", Order=2)]
		public  string gxTpr_Affectedname
		{
			get { 
				return sdt.gxTpr_Affectedname;

			}
			set { 
				 sdt.gxTpr_Affectedname = value;
			}
		}


		#endregion

		public SdtSDT_PageUrl_UrlsItem sdt
		{
			get { 
				return (SdtSDT_PageUrl_UrlsItem)Sdt;
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
				sdt = new SdtSDT_PageUrl_UrlsItem() ;
			}
		}
	}
	#endregion
}