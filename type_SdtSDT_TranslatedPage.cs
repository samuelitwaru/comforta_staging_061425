/*
				   File: type_SdtSDT_TranslatedPage
			Description: SDT_TranslatedPage
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
	[XmlRoot(ElementName="SDT_TranslatedPage")]
	[XmlType(TypeName="SDT_TranslatedPage" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_TranslatedPage : GxUserType
	{
		public SdtSDT_TranslatedPage( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_TranslatedPage_Pagename = "";

		}

		public SdtSDT_TranslatedPage(IGxContext context)
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
			AddObjectProperty("PageName", gxTpr_Pagename, false);

			if (gxTv_SdtSDT_TranslatedPage_Pagestructure != null)
			{
				AddObjectProperty("PageStructure", gxTv_SdtSDT_TranslatedPage_Pagestructure, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="PageName")]
		[XmlElement(ElementName="PageName")]
		public string gxTpr_Pagename
		{
			get {
				return gxTv_SdtSDT_TranslatedPage_Pagename; 
			}
			set {
				gxTv_SdtSDT_TranslatedPage_Pagename = value;
				SetDirty("Pagename");
			}
		}



		[SoapElement(ElementName="PageStructure")]
		[XmlElement(ElementName="PageStructure")]
		public GeneXus.Programs.SdtSDT_InfoContent gxTpr_Pagestructure
		{
			get {
				if ( gxTv_SdtSDT_TranslatedPage_Pagestructure == null )
				{
					gxTv_SdtSDT_TranslatedPage_Pagestructure = new GeneXus.Programs.SdtSDT_InfoContent(context);
				}
				return gxTv_SdtSDT_TranslatedPage_Pagestructure; 
			}
			set {
				gxTv_SdtSDT_TranslatedPage_Pagestructure = value;
				SetDirty("Pagestructure");
			}
		}
		public void gxTv_SdtSDT_TranslatedPage_Pagestructure_SetNull()
		{
			gxTv_SdtSDT_TranslatedPage_Pagestructure_N = true;
			gxTv_SdtSDT_TranslatedPage_Pagestructure = null;
		}

		public bool gxTv_SdtSDT_TranslatedPage_Pagestructure_IsNull()
		{
			return gxTv_SdtSDT_TranslatedPage_Pagestructure == null;
		}
		public bool ShouldSerializegxTpr_Pagestructure_Json()
		{
			return gxTv_SdtSDT_TranslatedPage_Pagestructure != null;

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
			gxTv_SdtSDT_TranslatedPage_Pagename = "";

			gxTv_SdtSDT_TranslatedPage_Pagestructure_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_TranslatedPage_Pagename;
		 

		protected GeneXus.Programs.SdtSDT_InfoContent gxTv_SdtSDT_TranslatedPage_Pagestructure = null;
		protected bool gxTv_SdtSDT_TranslatedPage_Pagestructure_N;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_TranslatedPage", Namespace="Comforta_version2")]
	public class SdtSDT_TranslatedPage_RESTInterface : GxGenericCollectionItem<SdtSDT_TranslatedPage>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_TranslatedPage_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_TranslatedPage_RESTInterface( SdtSDT_TranslatedPage psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="PageName", Order=0)]
		public  string gxTpr_Pagename
		{
			get { 
				return sdt.gxTpr_Pagename;

			}
			set { 
				 sdt.gxTpr_Pagename = value;
			}
		}

		[DataMember(Name="PageStructure", Order=1, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtSDT_InfoContent_RESTInterface gxTpr_Pagestructure
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Pagestructure_Json())
					return new GeneXus.Programs.SdtSDT_InfoContent_RESTInterface(sdt.gxTpr_Pagestructure);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Pagestructure = value.sdt;
			}
		}


		#endregion

		public SdtSDT_TranslatedPage sdt
		{
			get { 
				return (SdtSDT_TranslatedPage)Sdt;
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
				sdt = new SdtSDT_TranslatedPage() ;
			}
		}
	}
	#endregion
}