using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "Trn_Audit" )]
   [XmlType(TypeName =  "Trn_Audit" , Namespace = "Comforta_version21" )]
   [Serializable]
   public class SdtTrn_Audit : GxSilentTrnSdt
   {
      public SdtTrn_Audit( )
      {
      }

      public SdtTrn_Audit( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( Guid AV371AuditId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV371AuditId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"AuditId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_Audit");
         metadata.Set("BT", "Trn_Audit");
         metadata.Set("PK", "[ \"AuditId\" ]");
         metadata.Set("PKAssigned", "[ \"AuditId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"OrganisationId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Auditid_Z");
         state.Add("gxTpr_Auditdate_Z_Nullable");
         state.Add("gxTpr_Audittablename_Z");
         state.Add("gxTpr_Audittablediaplayname_Z");
         state.Add("gxTpr_Auditshortdescription_Z");
         state.Add("gxTpr_Gamuserid_Z");
         state.Add("gxTpr_Auditusername_Z");
         state.Add("gxTpr_Auditaction_Z");
         state.Add("gxTpr_Auditdisplaydescription_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Organisationid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_Audit sdt;
         sdt = (SdtTrn_Audit)(source);
         gxTv_SdtTrn_Audit_Auditid = sdt.gxTv_SdtTrn_Audit_Auditid ;
         gxTv_SdtTrn_Audit_Auditdate = sdt.gxTv_SdtTrn_Audit_Auditdate ;
         gxTv_SdtTrn_Audit_Audittablename = sdt.gxTv_SdtTrn_Audit_Audittablename ;
         gxTv_SdtTrn_Audit_Audittablediaplayname = sdt.gxTv_SdtTrn_Audit_Audittablediaplayname ;
         gxTv_SdtTrn_Audit_Auditdescription = sdt.gxTv_SdtTrn_Audit_Auditdescription ;
         gxTv_SdtTrn_Audit_Auditshortdescription = sdt.gxTv_SdtTrn_Audit_Auditshortdescription ;
         gxTv_SdtTrn_Audit_Gamuserid = sdt.gxTv_SdtTrn_Audit_Gamuserid ;
         gxTv_SdtTrn_Audit_Auditusername = sdt.gxTv_SdtTrn_Audit_Auditusername ;
         gxTv_SdtTrn_Audit_Auditaction = sdt.gxTv_SdtTrn_Audit_Auditaction ;
         gxTv_SdtTrn_Audit_Auditdisplaydescription = sdt.gxTv_SdtTrn_Audit_Auditdisplaydescription ;
         gxTv_SdtTrn_Audit_Organisationid = sdt.gxTv_SdtTrn_Audit_Organisationid ;
         gxTv_SdtTrn_Audit_Mode = sdt.gxTv_SdtTrn_Audit_Mode ;
         gxTv_SdtTrn_Audit_Initialized = sdt.gxTv_SdtTrn_Audit_Initialized ;
         gxTv_SdtTrn_Audit_Auditid_Z = sdt.gxTv_SdtTrn_Audit_Auditid_Z ;
         gxTv_SdtTrn_Audit_Auditdate_Z = sdt.gxTv_SdtTrn_Audit_Auditdate_Z ;
         gxTv_SdtTrn_Audit_Audittablename_Z = sdt.gxTv_SdtTrn_Audit_Audittablename_Z ;
         gxTv_SdtTrn_Audit_Audittablediaplayname_Z = sdt.gxTv_SdtTrn_Audit_Audittablediaplayname_Z ;
         gxTv_SdtTrn_Audit_Auditshortdescription_Z = sdt.gxTv_SdtTrn_Audit_Auditshortdescription_Z ;
         gxTv_SdtTrn_Audit_Gamuserid_Z = sdt.gxTv_SdtTrn_Audit_Gamuserid_Z ;
         gxTv_SdtTrn_Audit_Auditusername_Z = sdt.gxTv_SdtTrn_Audit_Auditusername_Z ;
         gxTv_SdtTrn_Audit_Auditaction_Z = sdt.gxTv_SdtTrn_Audit_Auditaction_Z ;
         gxTv_SdtTrn_Audit_Auditdisplaydescription_Z = sdt.gxTv_SdtTrn_Audit_Auditdisplaydescription_Z ;
         gxTv_SdtTrn_Audit_Organisationid_Z = sdt.gxTv_SdtTrn_Audit_Organisationid_Z ;
         gxTv_SdtTrn_Audit_Organisationid_N = sdt.gxTv_SdtTrn_Audit_Organisationid_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("AuditId", gxTv_SdtTrn_Audit_Auditid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTrn_Audit_Auditdate;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("AuditDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("AuditTableName", gxTv_SdtTrn_Audit_Audittablename, false, includeNonInitialized);
         AddObjectProperty("AuditTableDiaplayName", gxTv_SdtTrn_Audit_Audittablediaplayname, false, includeNonInitialized);
         AddObjectProperty("AuditDescription", gxTv_SdtTrn_Audit_Auditdescription, false, includeNonInitialized);
         AddObjectProperty("AuditShortDescription", gxTv_SdtTrn_Audit_Auditshortdescription, false, includeNonInitialized);
         AddObjectProperty("GAMUserId", gxTv_SdtTrn_Audit_Gamuserid, false, includeNonInitialized);
         AddObjectProperty("AuditUserName", gxTv_SdtTrn_Audit_Auditusername, false, includeNonInitialized);
         AddObjectProperty("AuditAction", gxTv_SdtTrn_Audit_Auditaction, false, includeNonInitialized);
         AddObjectProperty("AuditDisplayDescription", gxTv_SdtTrn_Audit_Auditdisplaydescription, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_Audit_Organisationid, false, includeNonInitialized);
         AddObjectProperty("OrganisationId_N", gxTv_SdtTrn_Audit_Organisationid_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_Audit_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_Audit_Initialized, false, includeNonInitialized);
            AddObjectProperty("AuditId_Z", gxTv_SdtTrn_Audit_Auditid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTrn_Audit_Auditdate_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("AuditDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("AuditTableName_Z", gxTv_SdtTrn_Audit_Audittablename_Z, false, includeNonInitialized);
            AddObjectProperty("AuditTableDiaplayName_Z", gxTv_SdtTrn_Audit_Audittablediaplayname_Z, false, includeNonInitialized);
            AddObjectProperty("AuditShortDescription_Z", gxTv_SdtTrn_Audit_Auditshortdescription_Z, false, includeNonInitialized);
            AddObjectProperty("GAMUserId_Z", gxTv_SdtTrn_Audit_Gamuserid_Z, false, includeNonInitialized);
            AddObjectProperty("AuditUserName_Z", gxTv_SdtTrn_Audit_Auditusername_Z, false, includeNonInitialized);
            AddObjectProperty("AuditAction_Z", gxTv_SdtTrn_Audit_Auditaction_Z, false, includeNonInitialized);
            AddObjectProperty("AuditDisplayDescription_Z", gxTv_SdtTrn_Audit_Auditdisplaydescription_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_Audit_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_N", gxTv_SdtTrn_Audit_Organisationid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_Audit sdt )
      {
         if ( sdt.IsDirty("AuditId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditid = sdt.gxTv_SdtTrn_Audit_Auditid ;
         }
         if ( sdt.IsDirty("AuditDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditdate = sdt.gxTv_SdtTrn_Audit_Auditdate ;
         }
         if ( sdt.IsDirty("AuditTableName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Audittablename = sdt.gxTv_SdtTrn_Audit_Audittablename ;
         }
         if ( sdt.IsDirty("AuditTableDiaplayName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Audittablediaplayname = sdt.gxTv_SdtTrn_Audit_Audittablediaplayname ;
         }
         if ( sdt.IsDirty("AuditDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditdescription = sdt.gxTv_SdtTrn_Audit_Auditdescription ;
         }
         if ( sdt.IsDirty("AuditShortDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditshortdescription = sdt.gxTv_SdtTrn_Audit_Auditshortdescription ;
         }
         if ( sdt.IsDirty("GAMUserId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Gamuserid = sdt.gxTv_SdtTrn_Audit_Gamuserid ;
         }
         if ( sdt.IsDirty("AuditUserName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditusername = sdt.gxTv_SdtTrn_Audit_Auditusername ;
         }
         if ( sdt.IsDirty("AuditAction") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditaction = sdt.gxTv_SdtTrn_Audit_Auditaction ;
         }
         if ( sdt.IsDirty("AuditDisplayDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditdisplaydescription = sdt.gxTv_SdtTrn_Audit_Auditdisplaydescription ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            gxTv_SdtTrn_Audit_Organisationid_N = (short)(sdt.gxTv_SdtTrn_Audit_Organisationid_N);
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Organisationid = sdt.gxTv_SdtTrn_Audit_Organisationid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "AuditId" )]
      [  XmlElement( ElementName = "AuditId"   )]
      public Guid gxTpr_Auditid
      {
         get {
            return gxTv_SdtTrn_Audit_Auditid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_Audit_Auditid != value )
            {
               gxTv_SdtTrn_Audit_Mode = "INS";
               this.gxTv_SdtTrn_Audit_Auditid_Z_SetNull( );
               this.gxTv_SdtTrn_Audit_Auditdate_Z_SetNull( );
               this.gxTv_SdtTrn_Audit_Audittablename_Z_SetNull( );
               this.gxTv_SdtTrn_Audit_Audittablediaplayname_Z_SetNull( );
               this.gxTv_SdtTrn_Audit_Auditshortdescription_Z_SetNull( );
               this.gxTv_SdtTrn_Audit_Gamuserid_Z_SetNull( );
               this.gxTv_SdtTrn_Audit_Auditusername_Z_SetNull( );
               this.gxTv_SdtTrn_Audit_Auditaction_Z_SetNull( );
               this.gxTv_SdtTrn_Audit_Auditdisplaydescription_Z_SetNull( );
               this.gxTv_SdtTrn_Audit_Organisationid_Z_SetNull( );
            }
            gxTv_SdtTrn_Audit_Auditid = value;
            SetDirty("Auditid");
         }

      }

      [  SoapElement( ElementName = "AuditDate" )]
      [  XmlElement( ElementName = "AuditDate"  , IsNullable=true )]
      public string gxTpr_Auditdate_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Audit_Auditdate == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_Audit_Auditdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_Audit_Auditdate = DateTime.MinValue;
            else
               gxTv_SdtTrn_Audit_Auditdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Auditdate
      {
         get {
            return gxTv_SdtTrn_Audit_Auditdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditdate = value;
            SetDirty("Auditdate");
         }

      }

      [  SoapElement( ElementName = "AuditTableName" )]
      [  XmlElement( ElementName = "AuditTableName"   )]
      public string gxTpr_Audittablename
      {
         get {
            return gxTv_SdtTrn_Audit_Audittablename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Audittablename = value;
            SetDirty("Audittablename");
         }

      }

      [  SoapElement( ElementName = "AuditTableDiaplayName" )]
      [  XmlElement( ElementName = "AuditTableDiaplayName"   )]
      public string gxTpr_Audittablediaplayname
      {
         get {
            return gxTv_SdtTrn_Audit_Audittablediaplayname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Audittablediaplayname = value;
            SetDirty("Audittablediaplayname");
         }

      }

      public void gxTv_SdtTrn_Audit_Audittablediaplayname_SetNull( )
      {
         gxTv_SdtTrn_Audit_Audittablediaplayname = "";
         SetDirty("Audittablediaplayname");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Audittablediaplayname_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditDescription" )]
      [  XmlElement( ElementName = "AuditDescription"   )]
      public string gxTpr_Auditdescription
      {
         get {
            return gxTv_SdtTrn_Audit_Auditdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditdescription = value;
            SetDirty("Auditdescription");
         }

      }

      [  SoapElement( ElementName = "AuditShortDescription" )]
      [  XmlElement( ElementName = "AuditShortDescription"   )]
      public string gxTpr_Auditshortdescription
      {
         get {
            return gxTv_SdtTrn_Audit_Auditshortdescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditshortdescription = value;
            SetDirty("Auditshortdescription");
         }

      }

      [  SoapElement( ElementName = "GAMUserId" )]
      [  XmlElement( ElementName = "GAMUserId"   )]
      public string gxTpr_Gamuserid
      {
         get {
            return gxTv_SdtTrn_Audit_Gamuserid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Gamuserid = value;
            SetDirty("Gamuserid");
         }

      }

      [  SoapElement( ElementName = "AuditUserName" )]
      [  XmlElement( ElementName = "AuditUserName"   )]
      public string gxTpr_Auditusername
      {
         get {
            return gxTv_SdtTrn_Audit_Auditusername ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditusername = value;
            SetDirty("Auditusername");
         }

      }

      [  SoapElement( ElementName = "AuditAction" )]
      [  XmlElement( ElementName = "AuditAction"   )]
      public string gxTpr_Auditaction
      {
         get {
            return gxTv_SdtTrn_Audit_Auditaction ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditaction = value;
            SetDirty("Auditaction");
         }

      }

      [  SoapElement( ElementName = "AuditDisplayDescription" )]
      [  XmlElement( ElementName = "AuditDisplayDescription"   )]
      public string gxTpr_Auditdisplaydescription
      {
         get {
            return gxTv_SdtTrn_Audit_Auditdisplaydescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditdisplaydescription = value;
            SetDirty("Auditdisplaydescription");
         }

      }

      public void gxTv_SdtTrn_Audit_Auditdisplaydescription_SetNull( )
      {
         gxTv_SdtTrn_Audit_Auditdisplaydescription = "";
         SetDirty("Auditdisplaydescription");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Auditdisplaydescription_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_Audit_Organisationid ;
         }

         set {
            gxTv_SdtTrn_Audit_Organisationid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      public void gxTv_SdtTrn_Audit_Organisationid_SetNull( )
      {
         gxTv_SdtTrn_Audit_Organisationid_N = 1;
         gxTv_SdtTrn_Audit_Organisationid = Guid.Empty;
         SetDirty("Organisationid");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Organisationid_IsNull( )
      {
         return (gxTv_SdtTrn_Audit_Organisationid_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_Audit_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_Audit_Mode_SetNull( )
      {
         gxTv_SdtTrn_Audit_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_Audit_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_Audit_Initialized_SetNull( )
      {
         gxTv_SdtTrn_Audit_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditId_Z" )]
      [  XmlElement( ElementName = "AuditId_Z"   )]
      public Guid gxTpr_Auditid_Z
      {
         get {
            return gxTv_SdtTrn_Audit_Auditid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditid_Z = value;
            SetDirty("Auditid_Z");
         }

      }

      public void gxTv_SdtTrn_Audit_Auditid_Z_SetNull( )
      {
         gxTv_SdtTrn_Audit_Auditid_Z = Guid.Empty;
         SetDirty("Auditid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Auditid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditDate_Z" )]
      [  XmlElement( ElementName = "AuditDate_Z"  , IsNullable=true )]
      public string gxTpr_Auditdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrn_Audit_Auditdate_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_Audit_Auditdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_Audit_Auditdate_Z = DateTime.MinValue;
            else
               gxTv_SdtTrn_Audit_Auditdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Auditdate_Z
      {
         get {
            return gxTv_SdtTrn_Audit_Auditdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditdate_Z = value;
            SetDirty("Auditdate_Z");
         }

      }

      public void gxTv_SdtTrn_Audit_Auditdate_Z_SetNull( )
      {
         gxTv_SdtTrn_Audit_Auditdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Auditdate_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Auditdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditTableName_Z" )]
      [  XmlElement( ElementName = "AuditTableName_Z"   )]
      public string gxTpr_Audittablename_Z
      {
         get {
            return gxTv_SdtTrn_Audit_Audittablename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Audittablename_Z = value;
            SetDirty("Audittablename_Z");
         }

      }

      public void gxTv_SdtTrn_Audit_Audittablename_Z_SetNull( )
      {
         gxTv_SdtTrn_Audit_Audittablename_Z = "";
         SetDirty("Audittablename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Audittablename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditTableDiaplayName_Z" )]
      [  XmlElement( ElementName = "AuditTableDiaplayName_Z"   )]
      public string gxTpr_Audittablediaplayname_Z
      {
         get {
            return gxTv_SdtTrn_Audit_Audittablediaplayname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Audittablediaplayname_Z = value;
            SetDirty("Audittablediaplayname_Z");
         }

      }

      public void gxTv_SdtTrn_Audit_Audittablediaplayname_Z_SetNull( )
      {
         gxTv_SdtTrn_Audit_Audittablediaplayname_Z = "";
         SetDirty("Audittablediaplayname_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Audittablediaplayname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditShortDescription_Z" )]
      [  XmlElement( ElementName = "AuditShortDescription_Z"   )]
      public string gxTpr_Auditshortdescription_Z
      {
         get {
            return gxTv_SdtTrn_Audit_Auditshortdescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditshortdescription_Z = value;
            SetDirty("Auditshortdescription_Z");
         }

      }

      public void gxTv_SdtTrn_Audit_Auditshortdescription_Z_SetNull( )
      {
         gxTv_SdtTrn_Audit_Auditshortdescription_Z = "";
         SetDirty("Auditshortdescription_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Auditshortdescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GAMUserId_Z" )]
      [  XmlElement( ElementName = "GAMUserId_Z"   )]
      public string gxTpr_Gamuserid_Z
      {
         get {
            return gxTv_SdtTrn_Audit_Gamuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Gamuserid_Z = value;
            SetDirty("Gamuserid_Z");
         }

      }

      public void gxTv_SdtTrn_Audit_Gamuserid_Z_SetNull( )
      {
         gxTv_SdtTrn_Audit_Gamuserid_Z = "";
         SetDirty("Gamuserid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Gamuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditUserName_Z" )]
      [  XmlElement( ElementName = "AuditUserName_Z"   )]
      public string gxTpr_Auditusername_Z
      {
         get {
            return gxTv_SdtTrn_Audit_Auditusername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditusername_Z = value;
            SetDirty("Auditusername_Z");
         }

      }

      public void gxTv_SdtTrn_Audit_Auditusername_Z_SetNull( )
      {
         gxTv_SdtTrn_Audit_Auditusername_Z = "";
         SetDirty("Auditusername_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Auditusername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditAction_Z" )]
      [  XmlElement( ElementName = "AuditAction_Z"   )]
      public string gxTpr_Auditaction_Z
      {
         get {
            return gxTv_SdtTrn_Audit_Auditaction_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditaction_Z = value;
            SetDirty("Auditaction_Z");
         }

      }

      public void gxTv_SdtTrn_Audit_Auditaction_Z_SetNull( )
      {
         gxTv_SdtTrn_Audit_Auditaction_Z = "";
         SetDirty("Auditaction_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Auditaction_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "AuditDisplayDescription_Z" )]
      [  XmlElement( ElementName = "AuditDisplayDescription_Z"   )]
      public string gxTpr_Auditdisplaydescription_Z
      {
         get {
            return gxTv_SdtTrn_Audit_Auditdisplaydescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Auditdisplaydescription_Z = value;
            SetDirty("Auditdisplaydescription_Z");
         }

      }

      public void gxTv_SdtTrn_Audit_Auditdisplaydescription_Z_SetNull( )
      {
         gxTv_SdtTrn_Audit_Auditdisplaydescription_Z = "";
         SetDirty("Auditdisplaydescription_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Auditdisplaydescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_Audit_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_Audit_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_Audit_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_N" )]
      [  XmlElement( ElementName = "OrganisationId_N"   )]
      public short gxTpr_Organisationid_N
      {
         get {
            return gxTv_SdtTrn_Audit_Organisationid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_Audit_Organisationid_N = value;
            SetDirty("Organisationid_N");
         }

      }

      public void gxTv_SdtTrn_Audit_Organisationid_N_SetNull( )
      {
         gxTv_SdtTrn_Audit_Organisationid_N = 0;
         SetDirty("Organisationid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_Audit_Organisationid_N_IsNull( )
      {
         return false ;
      }

      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         gxTv_SdtTrn_Audit_Auditid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_Audit_Auditdate = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_Audit_Audittablename = "";
         gxTv_SdtTrn_Audit_Audittablediaplayname = "";
         gxTv_SdtTrn_Audit_Auditdescription = "";
         gxTv_SdtTrn_Audit_Auditshortdescription = "";
         gxTv_SdtTrn_Audit_Gamuserid = "";
         gxTv_SdtTrn_Audit_Auditusername = "";
         gxTv_SdtTrn_Audit_Auditaction = "";
         gxTv_SdtTrn_Audit_Auditdisplaydescription = "";
         gxTv_SdtTrn_Audit_Organisationid = Guid.Empty;
         gxTv_SdtTrn_Audit_Mode = "";
         gxTv_SdtTrn_Audit_Auditid_Z = Guid.Empty;
         gxTv_SdtTrn_Audit_Auditdate_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_Audit_Audittablename_Z = "";
         gxTv_SdtTrn_Audit_Audittablediaplayname_Z = "";
         gxTv_SdtTrn_Audit_Auditshortdescription_Z = "";
         gxTv_SdtTrn_Audit_Gamuserid_Z = "";
         gxTv_SdtTrn_Audit_Auditusername_Z = "";
         gxTv_SdtTrn_Audit_Auditaction_Z = "";
         gxTv_SdtTrn_Audit_Auditdisplaydescription_Z = "";
         gxTv_SdtTrn_Audit_Organisationid_Z = Guid.Empty;
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_audit", "GeneXus.Programs.trn_audit_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtTrn_Audit_Initialized ;
      private short gxTv_SdtTrn_Audit_Organisationid_N ;
      private string gxTv_SdtTrn_Audit_Gamuserid ;
      private string gxTv_SdtTrn_Audit_Mode ;
      private string gxTv_SdtTrn_Audit_Gamuserid_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTrn_Audit_Auditdate ;
      private DateTime gxTv_SdtTrn_Audit_Auditdate_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtTrn_Audit_Auditdescription ;
      private string gxTv_SdtTrn_Audit_Audittablename ;
      private string gxTv_SdtTrn_Audit_Audittablediaplayname ;
      private string gxTv_SdtTrn_Audit_Auditshortdescription ;
      private string gxTv_SdtTrn_Audit_Auditusername ;
      private string gxTv_SdtTrn_Audit_Auditaction ;
      private string gxTv_SdtTrn_Audit_Auditdisplaydescription ;
      private string gxTv_SdtTrn_Audit_Audittablename_Z ;
      private string gxTv_SdtTrn_Audit_Audittablediaplayname_Z ;
      private string gxTv_SdtTrn_Audit_Auditshortdescription_Z ;
      private string gxTv_SdtTrn_Audit_Auditusername_Z ;
      private string gxTv_SdtTrn_Audit_Auditaction_Z ;
      private string gxTv_SdtTrn_Audit_Auditdisplaydescription_Z ;
      private Guid gxTv_SdtTrn_Audit_Auditid ;
      private Guid gxTv_SdtTrn_Audit_Organisationid ;
      private Guid gxTv_SdtTrn_Audit_Auditid_Z ;
      private Guid gxTv_SdtTrn_Audit_Organisationid_Z ;
   }

   [DataContract(Name = @"Trn_Audit", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Audit_RESTInterface : GxGenericCollectionItem<SdtTrn_Audit>
   {
      public SdtTrn_Audit_RESTInterface( ) : base()
      {
      }

      public SdtTrn_Audit_RESTInterface( SdtTrn_Audit psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AuditId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Auditid
      {
         get {
            return sdt.gxTpr_Auditid ;
         }

         set {
            sdt.gxTpr_Auditid = value;
         }

      }

      [DataMember( Name = "AuditDate" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Auditdate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Auditdate, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Auditdate = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "AuditTableName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Audittablename
      {
         get {
            return sdt.gxTpr_Audittablename ;
         }

         set {
            sdt.gxTpr_Audittablename = value;
         }

      }

      [DataMember( Name = "AuditTableDiaplayName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Audittablediaplayname
      {
         get {
            return sdt.gxTpr_Audittablediaplayname ;
         }

         set {
            sdt.gxTpr_Audittablediaplayname = value;
         }

      }

      [DataMember( Name = "AuditDescription" , Order = 4 )]
      public string gxTpr_Auditdescription
      {
         get {
            return sdt.gxTpr_Auditdescription ;
         }

         set {
            sdt.gxTpr_Auditdescription = value;
         }

      }

      [DataMember( Name = "AuditShortDescription" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Auditshortdescription
      {
         get {
            return sdt.gxTpr_Auditshortdescription ;
         }

         set {
            sdt.gxTpr_Auditshortdescription = value;
         }

      }

      [DataMember( Name = "GAMUserId" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Gamuserid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gamuserid) ;
         }

         set {
            sdt.gxTpr_Gamuserid = value;
         }

      }

      [DataMember( Name = "AuditUserName" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Auditusername
      {
         get {
            return sdt.gxTpr_Auditusername ;
         }

         set {
            sdt.gxTpr_Auditusername = value;
         }

      }

      [DataMember( Name = "AuditAction" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Auditaction
      {
         get {
            return sdt.gxTpr_Auditaction ;
         }

         set {
            sdt.gxTpr_Auditaction = value;
         }

      }

      [DataMember( Name = "AuditDisplayDescription" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Auditdisplaydescription
      {
         get {
            return sdt.gxTpr_Auditdisplaydescription ;
         }

         set {
            sdt.gxTpr_Auditdisplaydescription = value;
         }

      }

      [DataMember( Name = "OrganisationId" , Order = 10 )]
      [GxSeudo()]
      public Guid gxTpr_Organisationid
      {
         get {
            return sdt.gxTpr_Organisationid ;
         }

         set {
            sdt.gxTpr_Organisationid = value;
         }

      }

      public SdtTrn_Audit sdt
      {
         get {
            return (SdtTrn_Audit)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtTrn_Audit() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 11 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Trn_Audit", Namespace = "Comforta_version21")]
   [GxJsonSerialization("default")]
   public class SdtTrn_Audit_RESTLInterface : GxGenericCollectionItem<SdtTrn_Audit>
   {
      public SdtTrn_Audit_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_Audit_RESTLInterface( SdtTrn_Audit psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "AuditDate" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Auditdate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Auditdate, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Auditdate = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtTrn_Audit sdt
      {
         get {
            return (SdtTrn_Audit)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtTrn_Audit() ;
         }
      }

   }

}
