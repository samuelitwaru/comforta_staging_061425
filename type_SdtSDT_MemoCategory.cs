/*
				   File: type_SdtSDT_MemoCategory
			Description: SDT_MemoCategory
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
	[XmlRoot(ElementName="SDT_MemoCategory")]
	[XmlType(TypeName="SDT_MemoCategory" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_MemoCategory : GxUserType
	{
		public SdtSDT_MemoCategory( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_MemoCategory_Memocategoryname = "";

		}

		public SdtSDT_MemoCategory(IGxContext context)
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
			AddObjectProperty("MemoCategoryId", gxTpr_Memocategoryid, false);


			AddObjectProperty("MemoCategoryName", gxTpr_Memocategoryname, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="MemoCategoryId")]
		[XmlElement(ElementName="MemoCategoryId")]
		public Guid gxTpr_Memocategoryid
		{
			get {
				return gxTv_SdtSDT_MemoCategory_Memocategoryid; 
			}
			set {
				gxTv_SdtSDT_MemoCategory_Memocategoryid = value;
				SetDirty("Memocategoryid");
			}
		}




		[SoapElement(ElementName="MemoCategoryName")]
		[XmlElement(ElementName="MemoCategoryName")]
		public string gxTpr_Memocategoryname
		{
			get {
				return gxTv_SdtSDT_MemoCategory_Memocategoryname; 
			}
			set {
				gxTv_SdtSDT_MemoCategory_Memocategoryname = value;
				SetDirty("Memocategoryname");
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
			gxTv_SdtSDT_MemoCategory_Memocategoryname = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected Guid gxTv_SdtSDT_MemoCategory_Memocategoryid;
		 

		protected string gxTv_SdtSDT_MemoCategory_Memocategoryname;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_MemoCategory", Namespace="Comforta_version21")]
	public class SdtSDT_MemoCategory_RESTInterface : GxGenericCollectionItem<SdtSDT_MemoCategory>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_MemoCategory_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_MemoCategory_RESTInterface( SdtSDT_MemoCategory psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="MemoCategoryId", Order=0)]
		public Guid gxTpr_Memocategoryid
		{
			get { 
				return sdt.gxTpr_Memocategoryid;

			}
			set { 
				sdt.gxTpr_Memocategoryid = value;
			}
		}

		[DataMember(Name="MemoCategoryName", Order=1)]
		public  string gxTpr_Memocategoryname
		{
			get { 
				return sdt.gxTpr_Memocategoryname;

			}
			set { 
				 sdt.gxTpr_Memocategoryname = value;
			}
		}


		#endregion

		public SdtSDT_MemoCategory sdt
		{
			get { 
				return (SdtSDT_MemoCategory)Sdt;
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
				sdt = new SdtSDT_MemoCategory() ;
			}
		}
	}
	#endregion
}