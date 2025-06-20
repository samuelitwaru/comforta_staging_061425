/*
				   File: type_SdtSDT_MenuPage_RowsItem_TilesItem
			Description: Tiles
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
	[XmlRoot(ElementName="SDT_MenuPage.RowsItem.TilesItem")]
	[XmlType(TypeName="SDT_MenuPage.RowsItem.TilesItem" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_MenuPage_RowsItem_TilesItem : GxUserType
	{
		public SdtSDT_MenuPage_RowsItem_TilesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Id = "";

			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Name = "";

			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Text = "";

			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Color = "";

			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Align = "";

			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Icon = "";

			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Bgcolor = "";

			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Bgimageurl = "";

		}

		public SdtSDT_MenuPage_RowsItem_TilesItem(IGxContext context)
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
			AddObjectProperty("Id", gxTpr_Id, false);


			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Text", gxTpr_Text, false);


			AddObjectProperty("Color", gxTpr_Color, false);


			AddObjectProperty("Align", gxTpr_Align, false);


			AddObjectProperty("Icon", gxTpr_Icon, false);


			AddObjectProperty("BGColor", gxTpr_Bgcolor, false);


			AddObjectProperty("BGImageUrl", gxTpr_Bgimageurl, false);


			AddObjectProperty("Opacity", gxTpr_Opacity, false);


			AddObjectProperty("Size", gxTpr_Size, false);

			if (gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions != null)
			{
				AddObjectProperty("Permissions", gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions, false);
			}
			if (gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action != null)
			{
				AddObjectProperty("Action", gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Id")]
		[XmlElement(ElementName="Id")]
		public string gxTpr_Id
		{
			get {
				return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Id; 
			}
			set {
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Name; 
			}
			set {
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Text")]
		[XmlElement(ElementName="Text")]
		public string gxTpr_Text
		{
			get {
				return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Text; 
			}
			set {
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Text = value;
				SetDirty("Text");
			}
		}




		[SoapElement(ElementName="Color")]
		[XmlElement(ElementName="Color")]
		public string gxTpr_Color
		{
			get {
				return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Color; 
			}
			set {
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Color = value;
				SetDirty("Color");
			}
		}




		[SoapElement(ElementName="Align")]
		[XmlElement(ElementName="Align")]
		public string gxTpr_Align
		{
			get {
				return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Align; 
			}
			set {
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Align = value;
				SetDirty("Align");
			}
		}




		[SoapElement(ElementName="Icon")]
		[XmlElement(ElementName="Icon")]
		public string gxTpr_Icon
		{
			get {
				return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Icon; 
			}
			set {
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Icon = value;
				SetDirty("Icon");
			}
		}




		[SoapElement(ElementName="BGColor")]
		[XmlElement(ElementName="BGColor")]
		public string gxTpr_Bgcolor
		{
			get {
				return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Bgcolor; 
			}
			set {
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Bgcolor = value;
				SetDirty("Bgcolor");
			}
		}




		[SoapElement(ElementName="BGImageUrl")]
		[XmlElement(ElementName="BGImageUrl")]
		public string gxTpr_Bgimageurl
		{
			get {
				return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Bgimageurl; 
			}
			set {
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Bgimageurl = value;
				SetDirty("Bgimageurl");
			}
		}




		[SoapElement(ElementName="Opacity")]
		[XmlElement(ElementName="Opacity")]
		public short gxTpr_Opacity
		{
			get {
				return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Opacity; 
			}
			set {
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Opacity = value;
				SetDirty("Opacity");
			}
		}




		[SoapElement(ElementName="Size")]
		[XmlElement(ElementName="Size")]
		public short gxTpr_Size
		{
			get {
				return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Size; 
			}
			set {
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Size = value;
				SetDirty("Size");
			}
		}




		[SoapElement(ElementName="Permissions" )]
		[XmlArray(ElementName="Permissions"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Permissions_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions == null )
				{
					gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions;
			}
			set {
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions_N = false;
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions = value;
			}
		}

		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Permissions
		{
			get {
				if ( gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions == null )
				{
					gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions = new GxSimpleCollection<string>();
				}
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions_N = false;
				return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions ;
			}
			set {
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions_N = false;
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions = value;
				SetDirty("Permissions");
			}
		}

		public void gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions_SetNull()
		{
			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions_N = true;
			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions = null;
		}

		public bool gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions_IsNull()
		{
			return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions == null;
		}
		public bool ShouldSerializegxTpr_Permissions_GxSimpleCollection_Json()
		{
			return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions != null && gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions.Count > 0;

		}

		[SoapElement(ElementName="Action" )]
		[XmlElement(ElementName="Action" )]
		public SdtSDT_MenuPage_RowsItem_TilesItem_Action gxTpr_Action
		{
			get {
				if ( gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action == null )
				{
					gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action = new SdtSDT_MenuPage_RowsItem_TilesItem_Action(context);
				}
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action_N = false;
				return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action;
			}
			set {
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action_N = false;
				gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action = value;
				SetDirty("Action");
			}

		}

		public void gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action_SetNull()
		{
			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action_N = true;
			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action = null;
		}

		public bool gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action_IsNull()
		{
			return gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action == null;
		}
		public bool ShouldSerializegxTpr_Action_Json()
		{
				return (gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action != null && gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action.ShouldSerializeSdtJson());

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
			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Id = "";
			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Name = "";
			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Text = "";
			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Color = "";
			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Align = "";
			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Icon = "";
			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Bgcolor = "";
			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Bgimageurl = "";



			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions_N = true;


			gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Id;
		 

		protected string gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Name;
		 

		protected string gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Text;
		 

		protected string gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Color;
		 

		protected string gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Align;
		 

		protected string gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Icon;
		 

		protected string gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Bgcolor;
		 

		protected string gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Bgimageurl;
		 

		protected short gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Opacity;
		 

		protected short gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Size;
		 
		protected bool gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions_N;
		protected GxSimpleCollection<string> gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Permissions = null;  
		protected bool gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action_N;
		protected SdtSDT_MenuPage_RowsItem_TilesItem_Action gxTv_SdtSDT_MenuPage_RowsItem_TilesItem_Action = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_MenuPage.RowsItem.TilesItem", Namespace="Comforta_version2")]
	public class SdtSDT_MenuPage_RowsItem_TilesItem_RESTInterface : GxGenericCollectionItem<SdtSDT_MenuPage_RowsItem_TilesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_MenuPage_RowsItem_TilesItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_MenuPage_RowsItem_TilesItem_RESTInterface( SdtSDT_MenuPage_RowsItem_TilesItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Id", Order=0)]
		public  string gxTpr_Id
		{
			get { 
				return sdt.gxTpr_Id;

			}
			set { 
				 sdt.gxTpr_Id = value;
			}
		}

		[DataMember(Name="Name", Order=1)]
		public  string gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Text", Order=2)]
		public  string gxTpr_Text
		{
			get { 
				return sdt.gxTpr_Text;

			}
			set { 
				 sdt.gxTpr_Text = value;
			}
		}

		[DataMember(Name="Color", Order=3)]
		public  string gxTpr_Color
		{
			get { 
				return sdt.gxTpr_Color;

			}
			set { 
				 sdt.gxTpr_Color = value;
			}
		}

		[DataMember(Name="Align", Order=4)]
		public  string gxTpr_Align
		{
			get { 
				return sdt.gxTpr_Align;

			}
			set { 
				 sdt.gxTpr_Align = value;
			}
		}

		[DataMember(Name="Icon", Order=5)]
		public  string gxTpr_Icon
		{
			get { 
				return sdt.gxTpr_Icon;

			}
			set { 
				 sdt.gxTpr_Icon = value;
			}
		}

		[DataMember(Name="BGColor", Order=6)]
		public  string gxTpr_Bgcolor
		{
			get { 
				return sdt.gxTpr_Bgcolor;

			}
			set { 
				 sdt.gxTpr_Bgcolor = value;
			}
		}

		[DataMember(Name="BGImageUrl", Order=7)]
		public  string gxTpr_Bgimageurl
		{
			get { 
				return sdt.gxTpr_Bgimageurl;

			}
			set { 
				 sdt.gxTpr_Bgimageurl = value;
			}
		}

		[DataMember(Name="Opacity", Order=8)]
		public short gxTpr_Opacity
		{
			get { 
				return sdt.gxTpr_Opacity;

			}
			set { 
				sdt.gxTpr_Opacity = value;
			}
		}

		[DataMember(Name="Size", Order=9)]
		public short gxTpr_Size
		{
			get { 
				return sdt.gxTpr_Size;

			}
			set { 
				sdt.gxTpr_Size = value;
			}
		}

		[DataMember(Name="Permissions", Order=10, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Permissions
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Permissions_GxSimpleCollection_Json())
					return sdt.gxTpr_Permissions;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Permissions = value ;
			}
		}

		[DataMember(Name="Action", Order=11, EmitDefaultValue=false)]
		public SdtSDT_MenuPage_RowsItem_TilesItem_Action_RESTInterface gxTpr_Action
		{
			get {
				if (sdt.ShouldSerializegxTpr_Action_Json())
					return new SdtSDT_MenuPage_RowsItem_TilesItem_Action_RESTInterface(sdt.gxTpr_Action);
				else
					return null;

			}

			set {
				sdt.gxTpr_Action = value.sdt;
			}

		}


		#endregion

		public SdtSDT_MenuPage_RowsItem_TilesItem sdt
		{
			get { 
				return (SdtSDT_MenuPage_RowsItem_TilesItem)Sdt;
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
				sdt = new SdtSDT_MenuPage_RowsItem_TilesItem() ;
			}
		}
	}
	#endregion
}