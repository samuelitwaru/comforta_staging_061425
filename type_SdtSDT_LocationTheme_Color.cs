/*
				   File: type_SdtSDT_LocationTheme_Color
			Description: Color
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
	[XmlRoot(ElementName="SDT_LocationTheme.Color")]
	[XmlType(TypeName="SDT_LocationTheme.Color" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_LocationTheme_Color : GxUserType
	{
		public SdtSDT_LocationTheme_Color( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_LocationTheme_Color_Colorname = "";

			gxTv_SdtSDT_LocationTheme_Color_Colorcode = "";

		}

		public SdtSDT_LocationTheme_Color(IGxContext context)
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
			AddObjectProperty("ColorId", gxTpr_Colorid, false);


			AddObjectProperty("ColorName", gxTpr_Colorname, false);


			AddObjectProperty("ColorCode", gxTpr_Colorcode, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ColorId")]
		[XmlElement(ElementName="ColorId")]
		public Guid gxTpr_Colorid
		{
			get {
				return gxTv_SdtSDT_LocationTheme_Color_Colorid; 
			}
			set {
				gxTv_SdtSDT_LocationTheme_Color_Colorid = value;
				SetDirty("Colorid");
			}
		}




		[SoapElement(ElementName="ColorName")]
		[XmlElement(ElementName="ColorName")]
		public string gxTpr_Colorname
		{
			get {
				return gxTv_SdtSDT_LocationTheme_Color_Colorname; 
			}
			set {
				gxTv_SdtSDT_LocationTheme_Color_Colorname = value;
				SetDirty("Colorname");
			}
		}




		[SoapElement(ElementName="ColorCode")]
		[XmlElement(ElementName="ColorCode")]
		public string gxTpr_Colorcode
		{
			get {
				return gxTv_SdtSDT_LocationTheme_Color_Colorcode; 
			}
			set {
				gxTv_SdtSDT_LocationTheme_Color_Colorcode = value;
				SetDirty("Colorcode");
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
			gxTv_SdtSDT_LocationTheme_Color_Colorname = "";
			gxTv_SdtSDT_LocationTheme_Color_Colorcode = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_LocationTheme_Color_Colorid;
		 

		protected string gxTv_SdtSDT_LocationTheme_Color_Colorname;
		 

		protected string gxTv_SdtSDT_LocationTheme_Color_Colorcode;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_LocationTheme.Color", Namespace="Comforta_version21")]
	public class SdtSDT_LocationTheme_Color_RESTInterface : GxGenericCollectionItem<SdtSDT_LocationTheme_Color>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_LocationTheme_Color_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_LocationTheme_Color_RESTInterface( SdtSDT_LocationTheme_Color psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ColorId", Order=0)]
		public Guid gxTpr_Colorid
		{
			get { 
				return sdt.gxTpr_Colorid;

			}
			set { 
				sdt.gxTpr_Colorid = value;
			}
		}

		[DataMember(Name="ColorName", Order=1)]
		public  string gxTpr_Colorname
		{
			get { 
				return sdt.gxTpr_Colorname;

			}
			set { 
				 sdt.gxTpr_Colorname = value;
			}
		}

		[DataMember(Name="ColorCode", Order=2)]
		public  string gxTpr_Colorcode
		{
			get { 
				return sdt.gxTpr_Colorcode;

			}
			set { 
				 sdt.gxTpr_Colorcode = value;
			}
		}


		#endregion

		public SdtSDT_LocationTheme_Color sdt
		{
			get { 
				return (SdtSDT_LocationTheme_Color)Sdt;
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
				sdt = new SdtSDT_LocationTheme_Color() ;
			}
		}
	}
	#endregion
}