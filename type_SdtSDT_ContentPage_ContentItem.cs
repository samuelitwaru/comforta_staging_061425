/*
				   File: type_SdtSDT_ContentPage_ContentItem
			Description: Content
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
	[XmlRoot(ElementName="SDT_ContentPage.ContentItem")]
	[XmlType(TypeName="SDT_ContentPage.ContentItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_ContentPage_ContentItem : GxUserType
	{
		public SdtSDT_ContentPage_ContentItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_ContentPage_ContentItem_Contentid = "";

			gxTv_SdtSDT_ContentPage_ContentItem_Contenttype = "";

			gxTv_SdtSDT_ContentPage_ContentItem_Contentvalue = "";

		}

		public SdtSDT_ContentPage_ContentItem(IGxContext context)
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
			AddObjectProperty("ContentId", gxTpr_Contentid, false);


			AddObjectProperty("ContentType", gxTpr_Contenttype, false);


			AddObjectProperty("ContentValue", gxTpr_Contentvalue, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ContentId")]
		[XmlElement(ElementName="ContentId")]
		public string gxTpr_Contentid
		{
			get {
				return gxTv_SdtSDT_ContentPage_ContentItem_Contentid; 
			}
			set {
				gxTv_SdtSDT_ContentPage_ContentItem_Contentid = value;
				SetDirty("Contentid");
			}
		}




		[SoapElement(ElementName="ContentType")]
		[XmlElement(ElementName="ContentType")]
		public string gxTpr_Contenttype
		{
			get {
				return gxTv_SdtSDT_ContentPage_ContentItem_Contenttype; 
			}
			set {
				gxTv_SdtSDT_ContentPage_ContentItem_Contenttype = value;
				SetDirty("Contenttype");
			}
		}




		[SoapElement(ElementName="ContentValue")]
		[XmlElement(ElementName="ContentValue")]
		public string gxTpr_Contentvalue
		{
			get {
				return gxTv_SdtSDT_ContentPage_ContentItem_Contentvalue; 
			}
			set {
				gxTv_SdtSDT_ContentPage_ContentItem_Contentvalue = value;
				SetDirty("Contentvalue");
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
			gxTv_SdtSDT_ContentPage_ContentItem_Contentid = "";
			gxTv_SdtSDT_ContentPage_ContentItem_Contenttype = "";
			gxTv_SdtSDT_ContentPage_ContentItem_Contentvalue = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_ContentPage_ContentItem_Contentid;
		 

		protected string gxTv_SdtSDT_ContentPage_ContentItem_Contenttype;
		 

		protected string gxTv_SdtSDT_ContentPage_ContentItem_Contentvalue;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_ContentPage.ContentItem", Namespace="Comforta_version2")]
	public class SdtSDT_ContentPage_ContentItem_RESTInterface : GxGenericCollectionItem<SdtSDT_ContentPage_ContentItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_ContentPage_ContentItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_ContentPage_ContentItem_RESTInterface( SdtSDT_ContentPage_ContentItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ContentId", Order=0)]
		public  string gxTpr_Contentid
		{
			get { 
				return sdt.gxTpr_Contentid;

			}
			set { 
				 sdt.gxTpr_Contentid = value;
			}
		}

		[DataMember(Name="ContentType", Order=1)]
		public  string gxTpr_Contenttype
		{
			get { 
				return sdt.gxTpr_Contenttype;

			}
			set { 
				 sdt.gxTpr_Contenttype = value;
			}
		}

		[DataMember(Name="ContentValue", Order=2)]
		public  string gxTpr_Contentvalue
		{
			get { 
				return sdt.gxTpr_Contentvalue;

			}
			set { 
				 sdt.gxTpr_Contentvalue = value;
			}
		}


		#endregion

		public SdtSDT_ContentPage_ContentItem sdt
		{
			get { 
				return (SdtSDT_ContentPage_ContentItem)Sdt;
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
				sdt = new SdtSDT_ContentPage_ContentItem() ;
			}
		}
	}
	#endregion
}