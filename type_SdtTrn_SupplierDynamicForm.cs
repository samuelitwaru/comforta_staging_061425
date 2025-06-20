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
   [XmlRoot(ElementName = "Trn_SupplierDynamicForm" )]
   [XmlType(TypeName =  "Trn_SupplierDynamicForm" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_SupplierDynamicForm : GxSilentTrnSdt
   {
      public SdtTrn_SupplierDynamicForm( )
      {
      }

      public SdtTrn_SupplierDynamicForm( IGxContext context )
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

      public void Load( Guid AV616SupplierDynamicFormId ,
                        Guid AV42SupplierGenId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV616SupplierDynamicFormId,(Guid)AV42SupplierGenId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SupplierDynamicFormId", typeof(Guid)}, new Object[]{"SupplierGenId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_SupplierDynamicForm");
         metadata.Set("BT", "Trn_SupplierDynamicForm");
         metadata.Set("PK", "[ \"SupplierDynamicFormId\",\"SupplierGenId\" ]");
         metadata.Set("PKAssigned", "[ \"SupplierDynamicFormId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SupplierGenId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"WWPFormId\",\"WWPFormVersionNumber\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Supplierdynamicformid_Z");
         state.Add("gxTpr_Suppliergenid_Z");
         state.Add("gxTpr_Wwpformid_Z");
         state.Add("gxTpr_Wwpformversionnumber_Z");
         state.Add("gxTpr_Wwpformreferencename_Z");
         state.Add("gxTpr_Wwpformtitle_Z");
         state.Add("gxTpr_Wwpformdate_Z_Nullable");
         state.Add("gxTpr_Wwpformiswizard_Z");
         state.Add("gxTpr_Wwpformresume_Z");
         state.Add("gxTpr_Wwpforminstantiated_Z");
         state.Add("gxTpr_Wwpformlatestversionnumber_Z");
         state.Add("gxTpr_Wwpformtype_Z");
         state.Add("gxTpr_Wwpformsectionrefelements_Z");
         state.Add("gxTpr_Wwpformisfordynamicvalidations_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_SupplierDynamicForm sdt;
         sdt = (SdtTrn_SupplierDynamicForm)(source);
         gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid = sdt.gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid ;
         gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid = sdt.gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformid = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformid ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformresumemessage = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformresumemessage ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformvalidations = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformvalidations ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations ;
         gxTv_SdtTrn_SupplierDynamicForm_Mode = sdt.gxTv_SdtTrn_SupplierDynamicForm_Mode ;
         gxTv_SdtTrn_SupplierDynamicForm_Initialized = sdt.gxTv_SdtTrn_SupplierDynamicForm_Initialized ;
         gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid_Z = sdt.gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid_Z ;
         gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid_Z = sdt.gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid_Z ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformid_Z = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformid_Z ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber_Z = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber_Z ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename_Z = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename_Z ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle_Z = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle_Z ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard_Z = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard_Z ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume_Z = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume_Z ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated_Z = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated_Z ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber_Z = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber_Z ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype_Z = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype_Z ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements_Z = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements_Z ;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations_Z = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations_Z ;
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
         AddObjectProperty("SupplierDynamicFormId", gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid, false, includeNonInitialized);
         AddObjectProperty("SupplierGenId", gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid, false, includeNonInitialized);
         AddObjectProperty("WWPFormId", gxTv_SdtTrn_SupplierDynamicForm_Wwpformid, false, includeNonInitialized);
         AddObjectProperty("WWPFormVersionNumber", gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber, false, includeNonInitialized);
         AddObjectProperty("WWPFormReferenceName", gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename, false, includeNonInitialized);
         AddObjectProperty("WWPFormTitle", gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate;
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
         AddObjectProperty("WWPFormDate", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("WWPFormIsWizard", gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard, false, includeNonInitialized);
         AddObjectProperty("WWPFormResume", gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume, false, includeNonInitialized);
         AddObjectProperty("WWPFormResumeMessage", gxTv_SdtTrn_SupplierDynamicForm_Wwpformresumemessage, false, includeNonInitialized);
         AddObjectProperty("WWPFormValidations", gxTv_SdtTrn_SupplierDynamicForm_Wwpformvalidations, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstantiated", gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated, false, includeNonInitialized);
         AddObjectProperty("WWPFormLatestVersionNumber", gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber, false, includeNonInitialized);
         AddObjectProperty("WWPFormType", gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype, false, includeNonInitialized);
         AddObjectProperty("WWPFormSectionRefElements", gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements, false, includeNonInitialized);
         AddObjectProperty("WWPFormIsForDynamicValidations", gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_SupplierDynamicForm_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_SupplierDynamicForm_Initialized, false, includeNonInitialized);
            AddObjectProperty("SupplierDynamicFormId_Z", gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid_Z, false, includeNonInitialized);
            AddObjectProperty("SupplierGenId_Z", gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormId_Z", gxTv_SdtTrn_SupplierDynamicForm_Wwpformid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormVersionNumber_Z", gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormReferenceName_Z", gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormTitle_Z", gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z;
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
            AddObjectProperty("WWPFormDate_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("WWPFormIsWizard_Z", gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormResume_Z", gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstantiated_Z", gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormLatestVersionNumber_Z", gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormType_Z", gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormSectionRefElements_Z", gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormIsForDynamicValidations_Z", gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_SupplierDynamicForm sdt )
      {
         if ( sdt.IsDirty("SupplierDynamicFormId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid = sdt.gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid ;
         }
         if ( sdt.IsDirty("SupplierGenId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid = sdt.gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid ;
         }
         if ( sdt.IsDirty("WWPFormId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformid = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformid ;
         }
         if ( sdt.IsDirty("WWPFormVersionNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber ;
         }
         if ( sdt.IsDirty("WWPFormReferenceName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename ;
         }
         if ( sdt.IsDirty("WWPFormTitle") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle ;
         }
         if ( sdt.IsDirty("WWPFormDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate ;
         }
         if ( sdt.IsDirty("WWPFormIsWizard") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard ;
         }
         if ( sdt.IsDirty("WWPFormResume") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume ;
         }
         if ( sdt.IsDirty("WWPFormResumeMessage") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformresumemessage = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformresumemessage ;
         }
         if ( sdt.IsDirty("WWPFormValidations") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformvalidations = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformvalidations ;
         }
         if ( sdt.IsDirty("WWPFormInstantiated") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated ;
         }
         if ( sdt.IsDirty("WWPFormLatestVersionNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber ;
         }
         if ( sdt.IsDirty("WWPFormType") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype ;
         }
         if ( sdt.IsDirty("WWPFormSectionRefElements") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements ;
         }
         if ( sdt.IsDirty("WWPFormIsForDynamicValidations") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations = sdt.gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SupplierDynamicFormId" )]
      [  XmlElement( ElementName = "SupplierDynamicFormId"   )]
      public Guid gxTpr_Supplierdynamicformid
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid != value )
            {
               gxTv_SdtTrn_SupplierDynamicForm_Mode = "INS";
               this.gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformid_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations_Z_SetNull( );
            }
            gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid = value;
            SetDirty("Supplierdynamicformid");
         }

      }

      [  SoapElement( ElementName = "SupplierGenId" )]
      [  XmlElement( ElementName = "SupplierGenId"   )]
      public Guid gxTpr_Suppliergenid
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid != value )
            {
               gxTv_SdtTrn_SupplierDynamicForm_Mode = "INS";
               this.gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformid_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements_Z_SetNull( );
               this.gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations_Z_SetNull( );
            }
            gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid = value;
            SetDirty("Suppliergenid");
         }

      }

      [  SoapElement( ElementName = "WWPFormId" )]
      [  XmlElement( ElementName = "WWPFormId"   )]
      public short gxTpr_Wwpformid
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformid = value;
            SetDirty("Wwpformid");
         }

      }

      [  SoapElement( ElementName = "WWPFormVersionNumber" )]
      [  XmlElement( ElementName = "WWPFormVersionNumber"   )]
      public short gxTpr_Wwpformversionnumber
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber = value;
            SetDirty("Wwpformversionnumber");
         }

      }

      [  SoapElement( ElementName = "WWPFormReferenceName" )]
      [  XmlElement( ElementName = "WWPFormReferenceName"   )]
      public string gxTpr_Wwpformreferencename
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename = value;
            SetDirty("Wwpformreferencename");
         }

      }

      [  SoapElement( ElementName = "WWPFormTitle" )]
      [  XmlElement( ElementName = "WWPFormTitle"   )]
      public string gxTpr_Wwpformtitle
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle = value;
            SetDirty("Wwpformtitle");
         }

      }

      [  SoapElement( ElementName = "WWPFormDate" )]
      [  XmlElement( ElementName = "WWPFormDate"  , IsNullable=true )]
      public string gxTpr_Wwpformdate_Nullable
      {
         get {
            if ( gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate = DateTime.MinValue;
            else
               gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpformdate
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate = value;
            SetDirty("Wwpformdate");
         }

      }

      [  SoapElement( ElementName = "WWPFormIsWizard" )]
      [  XmlElement( ElementName = "WWPFormIsWizard"   )]
      public bool gxTpr_Wwpformiswizard
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard = value;
            SetDirty("Wwpformiswizard");
         }

      }

      [  SoapElement( ElementName = "WWPFormResume" )]
      [  XmlElement( ElementName = "WWPFormResume"   )]
      public short gxTpr_Wwpformresume
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume = value;
            SetDirty("Wwpformresume");
         }

      }

      [  SoapElement( ElementName = "WWPFormResumeMessage" )]
      [  XmlElement( ElementName = "WWPFormResumeMessage"   )]
      public string gxTpr_Wwpformresumemessage
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformresumemessage ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformresumemessage = value;
            SetDirty("Wwpformresumemessage");
         }

      }

      [  SoapElement( ElementName = "WWPFormValidations" )]
      [  XmlElement( ElementName = "WWPFormValidations"   )]
      public string gxTpr_Wwpformvalidations
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformvalidations ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformvalidations = value;
            SetDirty("Wwpformvalidations");
         }

      }

      [  SoapElement( ElementName = "WWPFormInstantiated" )]
      [  XmlElement( ElementName = "WWPFormInstantiated"   )]
      public bool gxTpr_Wwpforminstantiated
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated = value;
            SetDirty("Wwpforminstantiated");
         }

      }

      [  SoapElement( ElementName = "WWPFormLatestVersionNumber" )]
      [  XmlElement( ElementName = "WWPFormLatestVersionNumber"   )]
      public short gxTpr_Wwpformlatestversionnumber
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber = value;
            SetDirty("Wwpformlatestversionnumber");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber = 0;
         SetDirty("Wwpformlatestversionnumber");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormType" )]
      [  XmlElement( ElementName = "WWPFormType"   )]
      public short gxTpr_Wwpformtype
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype = value;
            SetDirty("Wwpformtype");
         }

      }

      [  SoapElement( ElementName = "WWPFormSectionRefElements" )]
      [  XmlElement( ElementName = "WWPFormSectionRefElements"   )]
      public string gxTpr_Wwpformsectionrefelements
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements = value;
            SetDirty("Wwpformsectionrefelements");
         }

      }

      [  SoapElement( ElementName = "WWPFormIsForDynamicValidations" )]
      [  XmlElement( ElementName = "WWPFormIsForDynamicValidations"   )]
      public bool gxTpr_Wwpformisfordynamicvalidations
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations = value;
            SetDirty("Wwpformisfordynamicvalidations");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Mode_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Initialized_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierDynamicFormId_Z" )]
      [  XmlElement( ElementName = "SupplierDynamicFormId_Z"   )]
      public Guid gxTpr_Supplierdynamicformid_Z
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid_Z = value;
            SetDirty("Supplierdynamicformid_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid_Z = Guid.Empty;
         SetDirty("Supplierdynamicformid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SupplierGenId_Z" )]
      [  XmlElement( ElementName = "SupplierGenId_Z"   )]
      public Guid gxTpr_Suppliergenid_Z
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid_Z = value;
            SetDirty("Suppliergenid_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid_Z = Guid.Empty;
         SetDirty("Suppliergenid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormId_Z" )]
      [  XmlElement( ElementName = "WWPFormId_Z"   )]
      public short gxTpr_Wwpformid_Z
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformid_Z = value;
            SetDirty("Wwpformid_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Wwpformid_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformid_Z = 0;
         SetDirty("Wwpformid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormVersionNumber_Z" )]
      [  XmlElement( ElementName = "WWPFormVersionNumber_Z"   )]
      public short gxTpr_Wwpformversionnumber_Z
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber_Z = value;
            SetDirty("Wwpformversionnumber_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber_Z = 0;
         SetDirty("Wwpformversionnumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormReferenceName_Z" )]
      [  XmlElement( ElementName = "WWPFormReferenceName_Z"   )]
      public string gxTpr_Wwpformreferencename_Z
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename_Z = value;
            SetDirty("Wwpformreferencename_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename_Z = "";
         SetDirty("Wwpformreferencename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormTitle_Z" )]
      [  XmlElement( ElementName = "WWPFormTitle_Z"   )]
      public string gxTpr_Wwpformtitle_Z
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle_Z = value;
            SetDirty("Wwpformtitle_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle_Z = "";
         SetDirty("Wwpformtitle_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormDate_Z" )]
      [  XmlElement( ElementName = "WWPFormDate_Z"  , IsNullable=true )]
      public string gxTpr_Wwpformdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z = DateTime.MinValue;
            else
               gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpformdate_Z
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z = value;
            SetDirty("Wwpformdate_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Wwpformdate_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormIsWizard_Z" )]
      [  XmlElement( ElementName = "WWPFormIsWizard_Z"   )]
      public bool gxTpr_Wwpformiswizard_Z
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard_Z = value;
            SetDirty("Wwpformiswizard_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard_Z = false;
         SetDirty("Wwpformiswizard_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormResume_Z" )]
      [  XmlElement( ElementName = "WWPFormResume_Z"   )]
      public short gxTpr_Wwpformresume_Z
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume_Z = value;
            SetDirty("Wwpformresume_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume_Z = 0;
         SetDirty("Wwpformresume_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstantiated_Z" )]
      [  XmlElement( ElementName = "WWPFormInstantiated_Z"   )]
      public bool gxTpr_Wwpforminstantiated_Z
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated_Z = value;
            SetDirty("Wwpforminstantiated_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated_Z = false;
         SetDirty("Wwpforminstantiated_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormLatestVersionNumber_Z" )]
      [  XmlElement( ElementName = "WWPFormLatestVersionNumber_Z"   )]
      public short gxTpr_Wwpformlatestversionnumber_Z
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber_Z = value;
            SetDirty("Wwpformlatestversionnumber_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber_Z = 0;
         SetDirty("Wwpformlatestversionnumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormType_Z" )]
      [  XmlElement( ElementName = "WWPFormType_Z"   )]
      public short gxTpr_Wwpformtype_Z
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype_Z = value;
            SetDirty("Wwpformtype_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype_Z = 0;
         SetDirty("Wwpformtype_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormSectionRefElements_Z" )]
      [  XmlElement( ElementName = "WWPFormSectionRefElements_Z"   )]
      public string gxTpr_Wwpformsectionrefelements_Z
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements_Z = value;
            SetDirty("Wwpformsectionrefelements_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements_Z = "";
         SetDirty("Wwpformsectionrefelements_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormIsForDynamicValidations_Z" )]
      [  XmlElement( ElementName = "WWPFormIsForDynamicValidations_Z"   )]
      public bool gxTpr_Wwpformisfordynamicvalidations_Z
      {
         get {
            return gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations_Z = value;
            SetDirty("Wwpformisfordynamicvalidations_Z");
         }

      }

      public void gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations_Z_SetNull( )
      {
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations_Z = false;
         SetDirty("Wwpformisfordynamicvalidations_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations_Z_IsNull( )
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
         gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid = Guid.Empty;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename = "";
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle = "";
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformresumemessage = "";
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformvalidations = "";
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements = "";
         gxTv_SdtTrn_SupplierDynamicForm_Mode = "";
         gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid_Z = Guid.Empty;
         gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid_Z = Guid.Empty;
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename_Z = "";
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle_Z = "";
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_supplierdynamicform", "GeneXus.Programs.trn_supplierdynamicform_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_SupplierDynamicForm_Wwpformid ;
      private short gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber ;
      private short gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume ;
      private short gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber ;
      private short gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype ;
      private short gxTv_SdtTrn_SupplierDynamicForm_Initialized ;
      private short gxTv_SdtTrn_SupplierDynamicForm_Wwpformid_Z ;
      private short gxTv_SdtTrn_SupplierDynamicForm_Wwpformversionnumber_Z ;
      private short gxTv_SdtTrn_SupplierDynamicForm_Wwpformresume_Z ;
      private short gxTv_SdtTrn_SupplierDynamicForm_Wwpformlatestversionnumber_Z ;
      private short gxTv_SdtTrn_SupplierDynamicForm_Wwpformtype_Z ;
      private string gxTv_SdtTrn_SupplierDynamicForm_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate ;
      private DateTime gxTv_SdtTrn_SupplierDynamicForm_Wwpformdate_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard ;
      private bool gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated ;
      private bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations ;
      private bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformiswizard_Z ;
      private bool gxTv_SdtTrn_SupplierDynamicForm_Wwpforminstantiated_Z ;
      private bool gxTv_SdtTrn_SupplierDynamicForm_Wwpformisfordynamicvalidations_Z ;
      private string gxTv_SdtTrn_SupplierDynamicForm_Wwpformresumemessage ;
      private string gxTv_SdtTrn_SupplierDynamicForm_Wwpformvalidations ;
      private string gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename ;
      private string gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle ;
      private string gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements ;
      private string gxTv_SdtTrn_SupplierDynamicForm_Wwpformreferencename_Z ;
      private string gxTv_SdtTrn_SupplierDynamicForm_Wwpformtitle_Z ;
      private string gxTv_SdtTrn_SupplierDynamicForm_Wwpformsectionrefelements_Z ;
      private Guid gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid ;
      private Guid gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid ;
      private Guid gxTv_SdtTrn_SupplierDynamicForm_Supplierdynamicformid_Z ;
      private Guid gxTv_SdtTrn_SupplierDynamicForm_Suppliergenid_Z ;
   }

   [DataContract(Name = @"Trn_SupplierDynamicForm", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_SupplierDynamicForm_RESTInterface : GxGenericCollectionItem<SdtTrn_SupplierDynamicForm>
   {
      public SdtTrn_SupplierDynamicForm_RESTInterface( ) : base()
      {
      }

      public SdtTrn_SupplierDynamicForm_RESTInterface( SdtTrn_SupplierDynamicForm psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SupplierDynamicFormId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Supplierdynamicformid
      {
         get {
            return sdt.gxTpr_Supplierdynamicformid ;
         }

         set {
            sdt.gxTpr_Supplierdynamicformid = value;
         }

      }

      [DataMember( Name = "SupplierGenId" , Order = 1 )]
      [GxSeudo()]
      public Guid gxTpr_Suppliergenid
      {
         get {
            return sdt.gxTpr_Suppliergenid ;
         }

         set {
            sdt.gxTpr_Suppliergenid = value;
         }

      }

      [DataMember( Name = "WWPFormId" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformid
      {
         get {
            return sdt.gxTpr_Wwpformid ;
         }

         set {
            sdt.gxTpr_Wwpformid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormVersionNumber" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformversionnumber
      {
         get {
            return sdt.gxTpr_Wwpformversionnumber ;
         }

         set {
            sdt.gxTpr_Wwpformversionnumber = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormReferenceName" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Wwpformreferencename
      {
         get {
            return sdt.gxTpr_Wwpformreferencename ;
         }

         set {
            sdt.gxTpr_Wwpformreferencename = value;
         }

      }

      [DataMember( Name = "WWPFormTitle" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Wwpformtitle
      {
         get {
            return sdt.gxTpr_Wwpformtitle ;
         }

         set {
            sdt.gxTpr_Wwpformtitle = value;
         }

      }

      [DataMember( Name = "WWPFormDate" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Wwpformdate
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Wwpformdate, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Wwpformdate = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "WWPFormIsWizard" , Order = 7 )]
      [GxSeudo()]
      public bool gxTpr_Wwpformiswizard
      {
         get {
            return sdt.gxTpr_Wwpformiswizard ;
         }

         set {
            sdt.gxTpr_Wwpformiswizard = value;
         }

      }

      [DataMember( Name = "WWPFormResume" , Order = 8 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformresume
      {
         get {
            return sdt.gxTpr_Wwpformresume ;
         }

         set {
            sdt.gxTpr_Wwpformresume = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormResumeMessage" , Order = 9 )]
      public string gxTpr_Wwpformresumemessage
      {
         get {
            return sdt.gxTpr_Wwpformresumemessage ;
         }

         set {
            sdt.gxTpr_Wwpformresumemessage = value;
         }

      }

      [DataMember( Name = "WWPFormValidations" , Order = 10 )]
      public string gxTpr_Wwpformvalidations
      {
         get {
            return sdt.gxTpr_Wwpformvalidations ;
         }

         set {
            sdt.gxTpr_Wwpformvalidations = value;
         }

      }

      [DataMember( Name = "WWPFormInstantiated" , Order = 11 )]
      [GxSeudo()]
      public bool gxTpr_Wwpforminstantiated
      {
         get {
            return sdt.gxTpr_Wwpforminstantiated ;
         }

         set {
            sdt.gxTpr_Wwpforminstantiated = value;
         }

      }

      [DataMember( Name = "WWPFormLatestVersionNumber" , Order = 12 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformlatestversionnumber
      {
         get {
            return sdt.gxTpr_Wwpformlatestversionnumber ;
         }

         set {
            sdt.gxTpr_Wwpformlatestversionnumber = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormType" , Order = 13 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Wwpformtype
      {
         get {
            return sdt.gxTpr_Wwpformtype ;
         }

         set {
            sdt.gxTpr_Wwpformtype = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "WWPFormSectionRefElements" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Wwpformsectionrefelements
      {
         get {
            return sdt.gxTpr_Wwpformsectionrefelements ;
         }

         set {
            sdt.gxTpr_Wwpformsectionrefelements = value;
         }

      }

      [DataMember( Name = "WWPFormIsForDynamicValidations" , Order = 15 )]
      [GxSeudo()]
      public bool gxTpr_Wwpformisfordynamicvalidations
      {
         get {
            return sdt.gxTpr_Wwpformisfordynamicvalidations ;
         }

         set {
            sdt.gxTpr_Wwpformisfordynamicvalidations = value;
         }

      }

      public SdtTrn_SupplierDynamicForm sdt
      {
         get {
            return (SdtTrn_SupplierDynamicForm)Sdt ;
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
            sdt = new SdtTrn_SupplierDynamicForm() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 16 )]
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

   [DataContract(Name = @"Trn_SupplierDynamicForm", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_SupplierDynamicForm_RESTLInterface : GxGenericCollectionItem<SdtTrn_SupplierDynamicForm>
   {
      public SdtTrn_SupplierDynamicForm_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_SupplierDynamicForm_RESTLInterface( SdtTrn_SupplierDynamicForm psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "uri", Order = 0 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtTrn_SupplierDynamicForm sdt
      {
         get {
            return (SdtTrn_SupplierDynamicForm)Sdt ;
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
            sdt = new SdtTrn_SupplierDynamicForm() ;
         }
      }

   }

}
