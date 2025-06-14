/*
				   File: type_SdtSDT_InfoTile_SDT_InfoTileItem
			Description: SDT_InfoTile
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
	[XmlRoot(ElementName="SDT_InfoTileItem")]
	[XmlType(TypeName="SDT_InfoTileItem" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_InfoTile_SDT_InfoTileItem : GxUserType
	{
		public SdtSDT_InfoTile_SDT_InfoTileItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Id = "";

			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Name = "";

			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Text = "";

			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Color = "";

			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Align = "";

			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Icon = "";

			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgcolor = "";

			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgimageurl = "";

			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgsize = "";

			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgposition = "";

			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Left = "";

			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Top = "";

			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Originalimageurl = "";

		}

		public SdtSDT_InfoTile_SDT_InfoTileItem(IGxContext context)
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


			AddObjectProperty("BGSize", gxTpr_Bgsize, false);


			AddObjectProperty("BGPosition", gxTpr_Bgposition, false);


			AddObjectProperty("Left", gxTpr_Left, false);


			AddObjectProperty("Top", gxTpr_Top, false);


			AddObjectProperty("OriginalImageUrl", gxTpr_Originalimageurl, false);

			if (gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action != null)
			{
				AddObjectProperty("Action", gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action, false);
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
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Id; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Id = value;
				SetDirty("Id");
			}
		}




		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Name; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Text")]
		[XmlElement(ElementName="Text")]
		public string gxTpr_Text
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Text; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Text = value;
				SetDirty("Text");
			}
		}




		[SoapElement(ElementName="Color")]
		[XmlElement(ElementName="Color")]
		public string gxTpr_Color
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Color; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Color = value;
				SetDirty("Color");
			}
		}




		[SoapElement(ElementName="Align")]
		[XmlElement(ElementName="Align")]
		public string gxTpr_Align
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Align; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Align = value;
				SetDirty("Align");
			}
		}




		[SoapElement(ElementName="Icon")]
		[XmlElement(ElementName="Icon")]
		public string gxTpr_Icon
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Icon; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Icon = value;
				SetDirty("Icon");
			}
		}




		[SoapElement(ElementName="BGColor")]
		[XmlElement(ElementName="BGColor")]
		public string gxTpr_Bgcolor
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgcolor; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgcolor = value;
				SetDirty("Bgcolor");
			}
		}




		[SoapElement(ElementName="BGImageUrl")]
		[XmlElement(ElementName="BGImageUrl")]
		public string gxTpr_Bgimageurl
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgimageurl; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgimageurl = value;
				SetDirty("Bgimageurl");
			}
		}




		[SoapElement(ElementName="Opacity")]
		[XmlElement(ElementName="Opacity")]
		public short gxTpr_Opacity
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Opacity; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Opacity = value;
				SetDirty("Opacity");
			}
		}



		[SoapElement(ElementName="Size")]
		[XmlElement(ElementName="Size")]
		public string gxTpr_Size_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Size, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Size = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Size
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Size; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Size = value;
				SetDirty("Size");
			}
		}




		[SoapElement(ElementName="BGSize")]
		[XmlElement(ElementName="BGSize")]
		public string gxTpr_Bgsize
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgsize; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgsize = value;
				SetDirty("Bgsize");
			}
		}




		[SoapElement(ElementName="BGPosition")]
		[XmlElement(ElementName="BGPosition")]
		public string gxTpr_Bgposition
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgposition; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgposition = value;
				SetDirty("Bgposition");
			}
		}




		[SoapElement(ElementName="Left")]
		[XmlElement(ElementName="Left")]
		public string gxTpr_Left
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Left; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Left = value;
				SetDirty("Left");
			}
		}




		[SoapElement(ElementName="Top")]
		[XmlElement(ElementName="Top")]
		public string gxTpr_Top
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Top; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Top = value;
				SetDirty("Top");
			}
		}




		[SoapElement(ElementName="OriginalImageUrl")]
		[XmlElement(ElementName="OriginalImageUrl")]
		public string gxTpr_Originalimageurl
		{
			get {
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Originalimageurl; 
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Originalimageurl = value;
				SetDirty("Originalimageurl");
			}
		}



		[SoapElement(ElementName="Action" )]
		[XmlElement(ElementName="Action" )]
		public SdtSDT_InfoTile_SDT_InfoTileItem_Action gxTpr_Action
		{
			get {
				if ( gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action == null )
				{
					gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action = new SdtSDT_InfoTile_SDT_InfoTileItem_Action(context);
				}
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_N = false;
				return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action;
			}
			set {
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_N = false;
				gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action = value;
				SetDirty("Action");
			}

		}

		public void gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_SetNull()
		{
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_N = true;
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action = null;
		}

		public bool gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_IsNull()
		{
			return gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action == null;
		}
		public bool ShouldSerializegxTpr_Action_Json()
		{
				return (gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action != null && gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action.ShouldSerializeSdtJson());

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
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Id = "";
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Name = "";
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Text = "";
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Color = "";
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Align = "";
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Icon = "";
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgcolor = "";
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgimageurl = "";


			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgsize = "";
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgposition = "";
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Left = "";
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Top = "";
			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Originalimageurl = "";

			gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Id;
		 

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Name;
		 

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Text;
		 

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Color;
		 

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Align;
		 

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Icon;
		 

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgcolor;
		 

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgimageurl;
		 

		protected short gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Opacity;
		 

		protected decimal gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Size;
		 

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgsize;
		 

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Bgposition;
		 

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Left;
		 

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Top;
		 

		protected string gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Originalimageurl;
		 
		protected bool gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action_N;
		protected SdtSDT_InfoTile_SDT_InfoTileItem_Action gxTv_SdtSDT_InfoTile_SDT_InfoTileItem_Action = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("wrapped")]
	[DataContract(Name=@"SDT_InfoTileItem", Namespace="Comforta_version21")]
	public class SdtSDT_InfoTile_SDT_InfoTileItem_RESTInterface : GxGenericCollectionItem<SdtSDT_InfoTile_SDT_InfoTileItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_InfoTile_SDT_InfoTileItem_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_InfoTile_SDT_InfoTileItem_RESTInterface( SdtSDT_InfoTile_SDT_InfoTileItem psdt ) : base(psdt)
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
		public decimal gxTpr_Size
		{
			get { 
				return sdt.gxTpr_Size;

			}
			set { 
				sdt.gxTpr_Size = value;
			}
		}

		[DataMember(Name="BGSize", Order=10)]
		public  string gxTpr_Bgsize
		{
			get { 
				return sdt.gxTpr_Bgsize;

			}
			set { 
				 sdt.gxTpr_Bgsize = value;
			}
		}

		[DataMember(Name="BGPosition", Order=11)]
		public  string gxTpr_Bgposition
		{
			get { 
				return sdt.gxTpr_Bgposition;

			}
			set { 
				 sdt.gxTpr_Bgposition = value;
			}
		}

		[DataMember(Name="Left", Order=12)]
		public  string gxTpr_Left
		{
			get { 
				return sdt.gxTpr_Left;

			}
			set { 
				 sdt.gxTpr_Left = value;
			}
		}

		[DataMember(Name="Top", Order=13)]
		public  string gxTpr_Top
		{
			get { 
				return sdt.gxTpr_Top;

			}
			set { 
				 sdt.gxTpr_Top = value;
			}
		}

		[DataMember(Name="OriginalImageUrl", Order=14)]
		public  string gxTpr_Originalimageurl
		{
			get { 
				return sdt.gxTpr_Originalimageurl;

			}
			set { 
				 sdt.gxTpr_Originalimageurl = value;
			}
		}

		[DataMember(Name="Action", Order=15, EmitDefaultValue=false)]
		public SdtSDT_InfoTile_SDT_InfoTileItem_Action_RESTInterface gxTpr_Action
		{
			get {
				if (sdt.ShouldSerializegxTpr_Action_Json())
					return new SdtSDT_InfoTile_SDT_InfoTileItem_Action_RESTInterface(sdt.gxTpr_Action);
				else
					return null;

			}

			set {
				sdt.gxTpr_Action = value.sdt;
			}

		}


		#endregion

		public SdtSDT_InfoTile_SDT_InfoTileItem sdt
		{
			get { 
				return (SdtSDT_InfoTile_SDT_InfoTileItem)Sdt;
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
				sdt = new SdtSDT_InfoTile_SDT_InfoTileItem() ;
			}
		}
	}
	#endregion
}