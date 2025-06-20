/*
				   File: type_SdtUHomeModulesSDT_UHomeModulesSDTItem
			Description: UHomeModulesSDT
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
	[XmlRoot(ElementName="UHomeModulesSDTItem")]
	[XmlType(TypeName="UHomeModulesSDTItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtUHomeModulesSDT_UHomeModulesSDTItem : GxUserType
	{
		public SdtUHomeModulesSDT_UHomeModulesSDTItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optiontitle = "";

			gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optiondescription = "";

			gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optioniconthemeclass = "";

			gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionbackgroundimage = "";
			gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionbackgroundimage_gxi = "";
			gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionwclink = "";

			gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Rolename = "";

		}

		public SdtUHomeModulesSDT_UHomeModulesSDTItem(IGxContext context)
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
			AddObjectProperty("OptionTitle", gxTpr_Optiontitle, false);


			AddObjectProperty("OptionDescription", gxTpr_Optiondescription, false);


			AddObjectProperty("OptionIconThemeClass", gxTpr_Optioniconthemeclass, false);


			AddObjectProperty("OptionType", gxTpr_Optiontype, false);


			AddObjectProperty("OptionBackgroundImage", gxTpr_Optionbackgroundimage, false);
			AddObjectProperty("OptionBackgroundImage_GXI", gxTpr_Optionbackgroundimage_gxi, false);



			AddObjectProperty("OptionSize", gxTpr_Optionsize, false);


			AddObjectProperty("OptionProgressValue", gxTpr_Optionprogressvalue, false);


			AddObjectProperty("OptionWCLink", gxTpr_Optionwclink, false);


			AddObjectProperty("RoleName", gxTpr_Rolename, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="OptionTitle")]
		[XmlElement(ElementName="OptionTitle")]
		public string gxTpr_Optiontitle
		{
			get {
				return gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optiontitle; 
			}
			set {
				gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optiontitle = value;
				SetDirty("Optiontitle");
			}
		}




		[SoapElement(ElementName="OptionDescription")]
		[XmlElement(ElementName="OptionDescription")]
		public string gxTpr_Optiondescription
		{
			get {
				return gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optiondescription; 
			}
			set {
				gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optiondescription = value;
				SetDirty("Optiondescription");
			}
		}




		[SoapElement(ElementName="OptionIconThemeClass")]
		[XmlElement(ElementName="OptionIconThemeClass")]
		public string gxTpr_Optioniconthemeclass
		{
			get {
				return gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optioniconthemeclass; 
			}
			set {
				gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optioniconthemeclass = value;
				SetDirty("Optioniconthemeclass");
			}
		}




		[SoapElement(ElementName="OptionType")]
		[XmlElement(ElementName="OptionType")]
		public short gxTpr_Optiontype
		{
			get {
				return gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optiontype; 
			}
			set {
				gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optiontype = value;
				SetDirty("Optiontype");
			}
		}




		[SoapElement(ElementName="OptionBackgroundImage")]
		[XmlElement(ElementName="OptionBackgroundImage")]
		[GxUpload()]

		public string gxTpr_Optionbackgroundimage
		{
			get {
				return gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionbackgroundimage; 
			}
			set {
				gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionbackgroundimage = value;
				SetDirty("Optionbackgroundimage");
			}
		}


		[SoapElement(ElementName="OptionBackgroundImage_GXI" )]
		[XmlElement(ElementName="OptionBackgroundImage_GXI" )]
		public string gxTpr_Optionbackgroundimage_gxi
		{
			get {
				return gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionbackgroundimage_gxi ;
			}
			set {
				gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionbackgroundimage_gxi = value;
				SetDirty("Optionbackgroundimage_gxi");
			}
		}

		[SoapElement(ElementName="OptionSize")]
		[XmlElement(ElementName="OptionSize")]
		public short gxTpr_Optionsize
		{
			get {
				return gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionsize; 
			}
			set {
				gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionsize = value;
				SetDirty("Optionsize");
			}
		}




		[SoapElement(ElementName="OptionProgressValue")]
		[XmlElement(ElementName="OptionProgressValue")]
		public short gxTpr_Optionprogressvalue
		{
			get {
				return gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionprogressvalue; 
			}
			set {
				gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionprogressvalue = value;
				SetDirty("Optionprogressvalue");
			}
		}




		[SoapElement(ElementName="OptionWCLink")]
		[XmlElement(ElementName="OptionWCLink")]
		public string gxTpr_Optionwclink
		{
			get {
				return gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionwclink; 
			}
			set {
				gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionwclink = value;
				SetDirty("Optionwclink");
			}
		}




		[SoapElement(ElementName="RoleName")]
		[XmlElement(ElementName="RoleName")]
		public string gxTpr_Rolename
		{
			get {
				return gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Rolename; 
			}
			set {
				gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Rolename = value;
				SetDirty("Rolename");
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
			gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optiontitle = "";
			gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optiondescription = "";
			gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optioniconthemeclass = "";

			gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionbackgroundimage = "";gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionbackgroundimage_gxi = "";


			gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionwclink = "";
			gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Rolename = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optiontitle;
		 

		protected string gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optiondescription;
		 

		protected string gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optioniconthemeclass;
		 

		protected short gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optiontype;
		 
		protected string gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionbackgroundimage_gxi;
		protected string gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionbackgroundimage;
		 

		protected short gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionsize;
		 

		protected short gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionprogressvalue;
		 

		protected string gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Optionwclink;
		 

		protected string gxTv_SdtUHomeModulesSDT_UHomeModulesSDTItem_Rolename;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"UHomeModulesSDTItem", Namespace="Comforta_version2")]
	public class SdtUHomeModulesSDT_UHomeModulesSDTItem_RESTInterface : GxGenericCollectionItem<SdtUHomeModulesSDT_UHomeModulesSDTItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtUHomeModulesSDT_UHomeModulesSDTItem_RESTInterface( ) : base()
		{	
		}

		public SdtUHomeModulesSDT_UHomeModulesSDTItem_RESTInterface( SdtUHomeModulesSDT_UHomeModulesSDTItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="OptionTitle", Order=0)]
		public  string gxTpr_Optiontitle
		{
			get { 
				return sdt.gxTpr_Optiontitle;

			}
			set { 
				 sdt.gxTpr_Optiontitle = value;
			}
		}

		[DataMember(Name="OptionDescription", Order=1)]
		public  string gxTpr_Optiondescription
		{
			get { 
				return sdt.gxTpr_Optiondescription;

			}
			set { 
				 sdt.gxTpr_Optiondescription = value;
			}
		}

		[DataMember(Name="OptionIconThemeClass", Order=2)]
		public  string gxTpr_Optioniconthemeclass
		{
			get { 
				return sdt.gxTpr_Optioniconthemeclass;

			}
			set { 
				 sdt.gxTpr_Optioniconthemeclass = value;
			}
		}

		[DataMember(Name="OptionType", Order=3)]
		public short gxTpr_Optiontype
		{
			get { 
				return sdt.gxTpr_Optiontype;

			}
			set { 
				sdt.gxTpr_Optiontype = value;
			}
		}

		[DataMember(Name="OptionBackgroundImage", Order=4)]
		[GxUpload()]
		public  string gxTpr_Optionbackgroundimage
		{
			get { 
				return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Optionbackgroundimage)) ? PathUtil.RelativePath( sdt.gxTpr_Optionbackgroundimage) : StringUtil.RTrim( sdt.gxTpr_Optionbackgroundimage_gxi));

			}
			set { 
				 sdt.gxTpr_Optionbackgroundimage = value;
			}
		}

		[DataMember(Name="OptionSize", Order=5)]
		public short gxTpr_Optionsize
		{
			get { 
				return sdt.gxTpr_Optionsize;

			}
			set { 
				sdt.gxTpr_Optionsize = value;
			}
		}

		[DataMember(Name="OptionProgressValue", Order=6)]
		public short gxTpr_Optionprogressvalue
		{
			get { 
				return sdt.gxTpr_Optionprogressvalue;

			}
			set { 
				sdt.gxTpr_Optionprogressvalue = value;
			}
		}

		[DataMember(Name="OptionWCLink", Order=7)]
		public  string gxTpr_Optionwclink
		{
			get { 
				return sdt.gxTpr_Optionwclink;

			}
			set { 
				 sdt.gxTpr_Optionwclink = value;
			}
		}

		[DataMember(Name="RoleName", Order=8)]
		public  string gxTpr_Rolename
		{
			get { 
				return sdt.gxTpr_Rolename;

			}
			set { 
				 sdt.gxTpr_Rolename = value;
			}
		}


		#endregion

		public SdtUHomeModulesSDT_UHomeModulesSDTItem sdt
		{
			get { 
				return (SdtUHomeModulesSDT_UHomeModulesSDTItem)Sdt;
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
				sdt = new SdtUHomeModulesSDT_UHomeModulesSDTItem() ;
			}
		}
	}
	#endregion
}