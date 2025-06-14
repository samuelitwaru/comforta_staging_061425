/*
				   File: type_SdtSDT_DebugResult_Summary
			Description: Summary
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
	[XmlRoot(ElementName="SDT_DebugResult.Summary")]
	[XmlType(TypeName="SDT_DebugResult.Summary" , Namespace="Comforta_version21" )]
	[Serializable]
	public class SdtSDT_DebugResult_Summary : GxUserType
	{
		public SdtSDT_DebugResult_Summary( )
		{
			/* Constructor for serialization */
		}

		public SdtSDT_DebugResult_Summary(IGxContext context)
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
			AddObjectProperty("TotalUrls", gxTpr_Totalurls, false);


			AddObjectProperty("SuccessCount", gxTpr_Successcount, false);


			AddObjectProperty("FailureCount", gxTpr_Failurecount, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TotalUrls")]
		[XmlElement(ElementName="TotalUrls")]
		public string gxTpr_Totalurls_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_DebugResult_Summary_Totalurls, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_DebugResult_Summary_Totalurls = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Totalurls
		{
			get {
				return gxTv_SdtSDT_DebugResult_Summary_Totalurls; 
			}
			set {
				gxTv_SdtSDT_DebugResult_Summary_Totalurls = value;
				SetDirty("Totalurls");
			}
		}



		[SoapElement(ElementName="SuccessCount")]
		[XmlElement(ElementName="SuccessCount")]
		public string gxTpr_Successcount_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_DebugResult_Summary_Successcount, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_DebugResult_Summary_Successcount = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Successcount
		{
			get {
				return gxTv_SdtSDT_DebugResult_Summary_Successcount; 
			}
			set {
				gxTv_SdtSDT_DebugResult_Summary_Successcount = value;
				SetDirty("Successcount");
			}
		}



		[SoapElement(ElementName="FailureCount")]
		[XmlElement(ElementName="FailureCount")]
		public string gxTpr_Failurecount_double
		{
			get {
				return Convert.ToString(gxTv_SdtSDT_DebugResult_Summary_Failurecount, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSDT_DebugResult_Summary_Failurecount = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Failurecount
		{
			get {
				return gxTv_SdtSDT_DebugResult_Summary_Failurecount; 
			}
			set {
				gxTv_SdtSDT_DebugResult_Summary_Failurecount = value;
				SetDirty("Failurecount");
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
			return  ;
		}



		#endregion

		#region Declaration

		protected decimal gxTv_SdtSDT_DebugResult_Summary_Totalurls;
		 

		protected decimal gxTv_SdtSDT_DebugResult_Summary_Successcount;
		 

		protected decimal gxTv_SdtSDT_DebugResult_Summary_Failurecount;
		 


		#endregion
	}
	#region Rest interface
	[GxJsonSerialization("default")]
	[DataContract(Name=@"SDT_DebugResult.Summary", Namespace="Comforta_version21")]
	public class SdtSDT_DebugResult_Summary_RESTInterface : GxGenericCollectionItem<SdtSDT_DebugResult_Summary>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSDT_DebugResult_Summary_RESTInterface( ) : base()
		{	
		}

		public SdtSDT_DebugResult_Summary_RESTInterface( SdtSDT_DebugResult_Summary psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="TotalUrls", Order=0)]
		public  string gxTpr_Totalurls
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Totalurls, 10, 5));

			}
			set { 
				sdt.gxTpr_Totalurls =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="SuccessCount", Order=1)]
		public  string gxTpr_Successcount
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Successcount, 10, 5));

			}
			set { 
				sdt.gxTpr_Successcount =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="FailureCount", Order=2)]
		public  string gxTpr_Failurecount
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Failurecount, 10, 5));

			}
			set { 
				sdt.gxTpr_Failurecount =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSDT_DebugResult_Summary sdt
		{
			get { 
				return (SdtSDT_DebugResult_Summary)Sdt;
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
				sdt = new SdtSDT_DebugResult_Summary() ;
			}
		}
	}
	#endregion
}