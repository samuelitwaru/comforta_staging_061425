/*
				   File: type_SdtSDT_Row
			Description: SDT_Row
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
	[XmlRoot(ElementName="SDT_Row")]
	[XmlType(TypeName="SDT_Row" , Namespace="Comforta_version2" )]
	[Serializable]
	public class SdtSDT_Row : GxUserType
	{
		public SdtSDT_Row( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_Row(IGxContext context)
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
			if (gxTv_SdtSDT_Row_Col != null)
			{
				AddObjectProperty("Col", gxTv_SdtSDT_Row_Col, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Col" )]
		[XmlArray(ElementName="Col"  )]
		[XmlArrayItemAttribute(ElementName="ColItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Col> gxTpr_Col_GXBaseCollection
		{
			get {
				if ( gxTv_SdtSDT_Row_Col == null )
				{
					gxTv_SdtSDT_Row_Col = new GXBaseCollection<GeneXus.Programs.SdtSDT_Col>( context, "SDT_Col", "");
				}
				return gxTv_SdtSDT_Row_Col;
			}
			set {
				gxTv_SdtSDT_Row_Col_N = false;
				gxTv_SdtSDT_Row_Col = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtSDT_Col> gxTpr_Col
		{
			get {
				if ( gxTv_SdtSDT_Row_Col == null )
				{
					gxTv_SdtSDT_Row_Col = new GXBaseCollection<GeneXus.Programs.SdtSDT_Col>( context, "SDT_Col", "");
				}
				gxTv_SdtSDT_Row_Col_N = false;
				return gxTv_SdtSDT_Row_Col ;
			}
			set {
				gxTv_SdtSDT_Row_Col_N = false;
				gxTv_SdtSDT_Row_Col = value;
				SetDirty("Col");
			}
		}

		public void gxTv_SdtSDT_Row_Col_SetNull()
		{
			gxTv_SdtSDT_Row_Col_N = true;
			gxTv_SdtSDT_Row_Col = null;
		}

		public bool gxTv_SdtSDT_Row_Col_IsNull()
		{
			return gxTv_SdtSDT_Row_Col == null;
		}
		public bool ShouldSerializegxTpr_Col_GXBaseCollection_Json()
		{
			return gxTv_SdtSDT_Row_Col != null && gxTv_SdtSDT_Row_Col.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Col_GXBaseCollection_Json()||  
				false);
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
			gxTv_SdtSDT_Row_Col_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtSDT_Row_Col_N;
		protected GXBaseCollection<GeneXus.Programs.SdtSDT_Col> gxTv_SdtSDT_Row_Col = null;  


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_Row", Namespace="Comforta_version2")]
	public class SdtSDT_Row_RESTInterface : GxGenericCollectionItem<SdtSDT_Row>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_Row_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_Row_RESTInterface( SdtSDT_Row psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Col", Order=0, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtSDT_Col_RESTInterface> gxTpr_Col
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Col_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtSDT_Col_RESTInterface>(sdt.gxTpr_Col);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Col);
			}
		}


		#endregion

		public SdtSDT_Row sdt
		{
			get { 
				return (SdtSDT_Row)Sdt;
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
				sdt = new SdtSDT_Row() ;
			}
		}
	}
	#endregion
}