/*
				   File: type_SdtSDT_Theme_IconsItem
			Description: Icons
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
	[XmlRoot(ElementName="SDT_Theme.IconsItem")]
	[XmlType(TypeName="SDT_Theme.IconsItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Theme_IconsItem : GxUserType
	{
		public SdtSDT_Theme_IconsItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Theme_IconsItem_Iconcategory = "";

			gxTv_SdtSDT_Theme_IconsItem_Iconname = "";

			gxTv_SdtSDT_Theme_IconsItem_Iconsvg = "";

		}

		public SdtSDT_Theme_IconsItem(IGxContext context)
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
			AddObjectProperty("IconId", gxTpr_Iconid, false);


			AddObjectProperty("IconCategory", gxTpr_Iconcategory, false);


			AddObjectProperty("IconName", gxTpr_Iconname, false);


			AddObjectProperty("IconSVG", gxTpr_Iconsvg, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="IconId")]
		[XmlElement(ElementName="IconId")]
		public Guid gxTpr_Iconid
		{
			get {
				return gxTv_SdtSDT_Theme_IconsItem_Iconid; 
			}
			set {
				gxTv_SdtSDT_Theme_IconsItem_Iconid = value;
				SetDirty("Iconid");
			}
		}




		[SoapElement(ElementName="IconCategory")]
		[XmlElement(ElementName="IconCategory")]
		public string gxTpr_Iconcategory
		{
			get {
				return gxTv_SdtSDT_Theme_IconsItem_Iconcategory; 
			}
			set {
				gxTv_SdtSDT_Theme_IconsItem_Iconcategory = value;
				SetDirty("Iconcategory");
			}
		}




		[SoapElement(ElementName="IconName")]
		[XmlElement(ElementName="IconName")]
		public string gxTpr_Iconname
		{
			get {
				return gxTv_SdtSDT_Theme_IconsItem_Iconname; 
			}
			set {
				gxTv_SdtSDT_Theme_IconsItem_Iconname = value;
				SetDirty("Iconname");
			}
		}




		[SoapElement(ElementName="IconSVG")]
		[XmlElement(ElementName="IconSVG")]
		public string gxTpr_Iconsvg
		{
			get {
				return gxTv_SdtSDT_Theme_IconsItem_Iconsvg; 
			}
			set {
				gxTv_SdtSDT_Theme_IconsItem_Iconsvg = value;
				SetDirty("Iconsvg");
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
			gxTv_SdtSDT_Theme_IconsItem_Iconcategory = "";
			gxTv_SdtSDT_Theme_IconsItem_Iconname = "";
			gxTv_SdtSDT_Theme_IconsItem_Iconsvg = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Theme_IconsItem_Iconid;
		 

		protected string gxTv_SdtSDT_Theme_IconsItem_Iconcategory;
		 

		protected string gxTv_SdtSDT_Theme_IconsItem_Iconname;
		 

		protected string gxTv_SdtSDT_Theme_IconsItem_Iconsvg;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_Theme.IconsItem", Namespace="Comforta_version2")]
	public class SdtSDT_Theme_IconsItem_RESTInterface : GxGenericCollectionItem<SdtSDT_Theme_IconsItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Theme_IconsItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Theme_IconsItem_RESTInterface( SdtSDT_Theme_IconsItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="IconId", Order=0)]
		public Guid gxTpr_Iconid
		{
			get { 
				return sdt.gxTpr_Iconid;

			}
			set { 
				sdt.gxTpr_Iconid = value;
			}
		}

		[DataMember(Name="IconCategory", Order=1)]
		public  string gxTpr_Iconcategory
		{
			get { 
				return sdt.gxTpr_Iconcategory;

			}
			set { 
				 sdt.gxTpr_Iconcategory = value;
			}
		}

		[DataMember(Name="IconName", Order=2)]
		public  string gxTpr_Iconname
		{
			get { 
				return sdt.gxTpr_Iconname;

			}
			set { 
				 sdt.gxTpr_Iconname = value;
			}
		}

		[DataMember(Name="IconSVG", Order=3)]
		public  string gxTpr_Iconsvg
		{
			get { 
				return sdt.gxTpr_Iconsvg;

			}
			set { 
				 sdt.gxTpr_Iconsvg = value;
			}
		}


		#endregion

		public SdtSDT_Theme_IconsItem sdt
		{
			get { 
				return (SdtSDT_Theme_IconsItem)Sdt;
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
				sdt = new SdtSDT_Theme_IconsItem() ;
			}
		}
	}
	#endregion
}