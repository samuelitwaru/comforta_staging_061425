/*
				   File: type_SdtSDT_Icon
			Description: SDT_Icon
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
	[XmlRoot(ElementName="SDT_Icon")]
	[XmlType(TypeName="SDT_Icon" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Icon : GxUserType
	{
		public SdtSDT_Icon( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_Icon_Iconcodename = "";

			gxTv_SdtSDT_Icon_Iconname = "";

			gxTv_SdtSDT_Icon_Icontags = "";

			gxTv_SdtSDT_Icon_Iconsvg = "";

			gxTv_SdtSDT_Icon_Iconcategory = "";

		}

		public SdtSDT_Icon(IGxContext context)
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


			AddObjectProperty("IconCodeName", gxTpr_Iconcodename, false);


			AddObjectProperty("IconName", gxTpr_Iconname, false);


			AddObjectProperty("IconTags", gxTpr_Icontags, false);


			AddObjectProperty("IconSVG", gxTpr_Iconsvg, false);


			AddObjectProperty("IconCategory", gxTpr_Iconcategory, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="IconId")]
		[XmlElement(ElementName="IconId")]
		public Guid gxTpr_Iconid
		{
			get {
				return gxTv_SdtSDT_Icon_Iconid; 
			}
			set {
				gxTv_SdtSDT_Icon_Iconid = value;
				SetDirty("Iconid");
			}
		}




		[SoapElement(ElementName="IconCodeName")]
		[XmlElement(ElementName="IconCodeName")]
		public string gxTpr_Iconcodename
		{
			get {
				return gxTv_SdtSDT_Icon_Iconcodename; 
			}
			set {
				gxTv_SdtSDT_Icon_Iconcodename = value;
				SetDirty("Iconcodename");
			}
		}




		[SoapElement(ElementName="IconName")]
		[XmlElement(ElementName="IconName")]
		public string gxTpr_Iconname
		{
			get {
				return gxTv_SdtSDT_Icon_Iconname; 
			}
			set {
				gxTv_SdtSDT_Icon_Iconname = value;
				SetDirty("Iconname");
			}
		}




		[SoapElement(ElementName="IconTags")]
		[XmlElement(ElementName="IconTags")]
		public string gxTpr_Icontags
		{
			get {
				return gxTv_SdtSDT_Icon_Icontags; 
			}
			set {
				gxTv_SdtSDT_Icon_Icontags = value;
				SetDirty("Icontags");
			}
		}




		[SoapElement(ElementName="IconSVG")]
		[XmlElement(ElementName="IconSVG")]
		public string gxTpr_Iconsvg
		{
			get {
				return gxTv_SdtSDT_Icon_Iconsvg; 
			}
			set {
				gxTv_SdtSDT_Icon_Iconsvg = value;
				SetDirty("Iconsvg");
			}
		}




		[SoapElement(ElementName="IconCategory")]
		[XmlElement(ElementName="IconCategory")]
		public string gxTpr_Iconcategory
		{
			get {
				return gxTv_SdtSDT_Icon_Iconcategory; 
			}
			set {
				gxTv_SdtSDT_Icon_Iconcategory = value;
				SetDirty("Iconcategory");
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
			gxTv_SdtSDT_Icon_Iconcodename = "";
			gxTv_SdtSDT_Icon_Iconname = "";
			gxTv_SdtSDT_Icon_Icontags = "";
			gxTv_SdtSDT_Icon_Iconsvg = "";
			gxTv_SdtSDT_Icon_Iconcategory = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_Icon_Iconid;
		 

		protected string gxTv_SdtSDT_Icon_Iconcodename;
		 

		protected string gxTv_SdtSDT_Icon_Iconname;
		 

		protected string gxTv_SdtSDT_Icon_Icontags;
		 

		protected string gxTv_SdtSDT_Icon_Iconsvg;
		 

		protected string gxTv_SdtSDT_Icon_Iconcategory;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Icon", Namespace="Comforta_version2")]
	public class SdtSDT_Icon_RESTInterface : GxGenericCollectionItem<SdtSDT_Icon>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Icon_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Icon_RESTInterface( SdtSDT_Icon psdt ) : base(psdt)
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

		[DataMember(Name="IconCodeName", Order=1)]
		public  string gxTpr_Iconcodename
		{
			get { 
				return sdt.gxTpr_Iconcodename;

			}
			set { 
				 sdt.gxTpr_Iconcodename = value;
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

		[DataMember(Name="IconTags", Order=3)]
		public  string gxTpr_Icontags
		{
			get { 
				return sdt.gxTpr_Icontags;

			}
			set { 
				 sdt.gxTpr_Icontags = value;
			}
		}

		[DataMember(Name="IconSVG", Order=4)]
		public  string gxTpr_Iconsvg
		{
			get { 
				return sdt.gxTpr_Iconsvg;

			}
			set { 
				 sdt.gxTpr_Iconsvg = value;
			}
		}

		[DataMember(Name="IconCategory", Order=5)]
		public  string gxTpr_Iconcategory
		{
			get { 
				return sdt.gxTpr_Iconcategory;

			}
			set { 
				 sdt.gxTpr_Iconcategory = value;
			}
		}


		#endregion

		public SdtSDT_Icon sdt
		{
			get { 
				return (SdtSDT_Icon)Sdt;
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
				sdt = new SdtSDT_Icon() ;
			}
		}
	}
	#endregion
}