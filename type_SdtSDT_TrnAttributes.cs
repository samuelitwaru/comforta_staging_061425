/*
				   File: type_SdtSDT_TrnAttributes
			Description: SDT_TrnAttributes
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
	[XmlRoot(ElementName="SDT_TrnAttributes")]
	[XmlType(TypeName="SDT_TrnAttributes" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_TrnAttributes : GxUserType
	{
		public SdtSDT_TrnAttributes( )
		{
			/* Constructor for serialization */
			gxTv_SdtSDT_TrnAttributes_Trnname = "";

		}

		public SdtSDT_TrnAttributes(IGxContext context)
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
			AddObjectProperty("TrnName", gxTpr_Trnname, false);

			if (gxTv_SdtSDT_TrnAttributes_Transaction != null)
			{
				AddObjectProperty("Transaction", gxTv_SdtSDT_TrnAttributes_Transaction, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TrnName")]
		[XmlElement(ElementName="TrnName")]
		public string gxTpr_Trnname
		{
			get {
				return gxTv_SdtSDT_TrnAttributes_Trnname; 
			}
			set {
				gxTv_SdtSDT_TrnAttributes_Trnname = value;
				SetDirty("Trnname");
			}
		}



		[SoapElement(ElementName="Transaction" )]
		[XmlElement(ElementName="Transaction" )]
		public SdtSDT_TrnAttributes_Transaction gxTpr_Transaction
		{
			get {
				if ( gxTv_SdtSDT_TrnAttributes_Transaction == null )
				{
					gxTv_SdtSDT_TrnAttributes_Transaction = new SdtSDT_TrnAttributes_Transaction(context);
				}
				gxTv_SdtSDT_TrnAttributes_Transaction_N = false;
				return gxTv_SdtSDT_TrnAttributes_Transaction;
			}
			set {
				gxTv_SdtSDT_TrnAttributes_Transaction_N = false;
				gxTv_SdtSDT_TrnAttributes_Transaction = value;
				SetDirty("Transaction");
			}

		}

		public void gxTv_SdtSDT_TrnAttributes_Transaction_SetNull()
		{
			gxTv_SdtSDT_TrnAttributes_Transaction_N = true;
			gxTv_SdtSDT_TrnAttributes_Transaction = null;
		}

		public bool gxTv_SdtSDT_TrnAttributes_Transaction_IsNull()
		{
			return gxTv_SdtSDT_TrnAttributes_Transaction == null;
		}
		public bool ShouldSerializegxTpr_Transaction_Json()
		{
				return (gxTv_SdtSDT_TrnAttributes_Transaction != null && gxTv_SdtSDT_TrnAttributes_Transaction.ShouldSerializeSdtJson());

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
			gxTv_SdtSDT_TrnAttributes_Trnname = "";

			gxTv_SdtSDT_TrnAttributes_Transaction_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSDT_TrnAttributes_Trnname;
		 
		protected bool gxTv_SdtSDT_TrnAttributes_Transaction_N;
		protected SdtSDT_TrnAttributes_Transaction gxTv_SdtSDT_TrnAttributes_Transaction = null; 



		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_TrnAttributes", Namespace="Comforta_version2")]
	public class SdtSDT_TrnAttributes_RESTInterface : GxGenericCollectionItem<SdtSDT_TrnAttributes>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_TrnAttributes_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_TrnAttributes_RESTInterface( SdtSDT_TrnAttributes psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="TrnName", Order=0)]
		public  string gxTpr_Trnname
		{
			get { 
				return sdt.gxTpr_Trnname;

			}
			set { 
				 sdt.gxTpr_Trnname = value;
			}
		}

		[DataMember(Name="Transaction", Order=1, EmitDefaultValue=false)]
		public SdtSDT_TrnAttributes_Transaction_RESTInterface gxTpr_Transaction
		{
			get {
				if (sdt.ShouldSerializegxTpr_Transaction_Json())
					return new SdtSDT_TrnAttributes_Transaction_RESTInterface(sdt.gxTpr_Transaction);
				else
					return null;

			}

			set {
				sdt.gxTpr_Transaction = value.sdt;
			}

		}


		#endregion

		public SdtSDT_TrnAttributes sdt
		{
			get { 
				return (SdtSDT_TrnAttributes)Sdt;
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
				sdt = new SdtSDT_TrnAttributes() ;
			}
		}
	}
	#endregion
}