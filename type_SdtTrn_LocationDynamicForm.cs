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
   [XmlRoot(ElementName = "Trn_LocationDynamicForm" )]
   [XmlType(TypeName =  "Trn_LocationDynamicForm" , Namespace = "Comforta_version2" )]
   [Serializable]
   public class SdtTrn_LocationDynamicForm : GxSilentTrnSdt
   {
      public SdtTrn_LocationDynamicForm( )
      {
      }

      public SdtTrn_LocationDynamicForm( IGxContext context )
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

      public void Load( Guid AV366LocationDynamicFormId ,
                        Guid AV11OrganisationId ,
                        Guid AV29LocationId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(Guid)AV366LocationDynamicFormId,(Guid)AV11OrganisationId,(Guid)AV29LocationId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"LocationDynamicFormId", typeof(Guid)}, new Object[]{"OrganisationId", typeof(Guid)}, new Object[]{"LocationId", typeof(Guid)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Trn_LocationDynamicForm");
         metadata.Set("BT", "Trn_LocationDynamicForm");
         metadata.Set("PK", "[ \"LocationDynamicFormId\",\"OrganisationId\",\"LocationId\" ]");
         metadata.Set("PKAssigned", "[ \"LocationDynamicFormId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"LocationId\",\"OrganisationId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"WWPFormId\",\"WWPFormVersionNumber\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Locationdynamicformid_Z");
         state.Add("gxTpr_Organisationid_Z");
         state.Add("gxTpr_Locationid_Z");
         state.Add("gxTpr_Formpagename_Z");
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
         state.Add("gxTpr_Locationdynamicformid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtTrn_LocationDynamicForm sdt;
         sdt = (SdtTrn_LocationDynamicForm)(source);
         gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid = sdt.gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid ;
         gxTv_SdtTrn_LocationDynamicForm_Organisationid = sdt.gxTv_SdtTrn_LocationDynamicForm_Organisationid ;
         gxTv_SdtTrn_LocationDynamicForm_Locationid = sdt.gxTv_SdtTrn_LocationDynamicForm_Locationid ;
         gxTv_SdtTrn_LocationDynamicForm_Formpagename = sdt.gxTv_SdtTrn_LocationDynamicForm_Formpagename ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformid = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformid ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformdate = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformdate ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformresume = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformresume ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformresumemessage = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformresumemessage ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformvalidations = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformvalidations ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformtype = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformtype ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations ;
         gxTv_SdtTrn_LocationDynamicForm_Mode = sdt.gxTv_SdtTrn_LocationDynamicForm_Mode ;
         gxTv_SdtTrn_LocationDynamicForm_Initialized = sdt.gxTv_SdtTrn_LocationDynamicForm_Initialized ;
         gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Organisationid_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Organisationid_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Locationid_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Locationid_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Formpagename_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Formpagename_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformid_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformid_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformresume_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformresume_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformtype_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformtype_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations_Z = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations_Z ;
         gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_N = sdt.gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_N ;
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
         AddObjectProperty("LocationDynamicFormId", gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid, false, includeNonInitialized);
         AddObjectProperty("LocationDynamicFormId_N", gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_N, false, includeNonInitialized);
         AddObjectProperty("OrganisationId", gxTv_SdtTrn_LocationDynamicForm_Organisationid, false, includeNonInitialized);
         AddObjectProperty("LocationId", gxTv_SdtTrn_LocationDynamicForm_Locationid, false, includeNonInitialized);
         AddObjectProperty("FormPageName", gxTv_SdtTrn_LocationDynamicForm_Formpagename, false, includeNonInitialized);
         AddObjectProperty("WWPFormId", gxTv_SdtTrn_LocationDynamicForm_Wwpformid, false, includeNonInitialized);
         AddObjectProperty("WWPFormVersionNumber", gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber, false, includeNonInitialized);
         AddObjectProperty("WWPFormReferenceName", gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename, false, includeNonInitialized);
         AddObjectProperty("WWPFormTitle", gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtTrn_LocationDynamicForm_Wwpformdate;
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
         AddObjectProperty("WWPFormIsWizard", gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard, false, includeNonInitialized);
         AddObjectProperty("WWPFormResume", gxTv_SdtTrn_LocationDynamicForm_Wwpformresume, false, includeNonInitialized);
         AddObjectProperty("WWPFormResumeMessage", gxTv_SdtTrn_LocationDynamicForm_Wwpformresumemessage, false, includeNonInitialized);
         AddObjectProperty("WWPFormValidations", gxTv_SdtTrn_LocationDynamicForm_Wwpformvalidations, false, includeNonInitialized);
         AddObjectProperty("WWPFormInstantiated", gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated, false, includeNonInitialized);
         AddObjectProperty("WWPFormLatestVersionNumber", gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber, false, includeNonInitialized);
         AddObjectProperty("WWPFormType", gxTv_SdtTrn_LocationDynamicForm_Wwpformtype, false, includeNonInitialized);
         AddObjectProperty("WWPFormSectionRefElements", gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements, false, includeNonInitialized);
         AddObjectProperty("WWPFormIsForDynamicValidations", gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtTrn_LocationDynamicForm_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtTrn_LocationDynamicForm_Initialized, false, includeNonInitialized);
            AddObjectProperty("LocationDynamicFormId_Z", gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_Z, false, includeNonInitialized);
            AddObjectProperty("OrganisationId_Z", gxTv_SdtTrn_LocationDynamicForm_Organisationid_Z, false, includeNonInitialized);
            AddObjectProperty("LocationId_Z", gxTv_SdtTrn_LocationDynamicForm_Locationid_Z, false, includeNonInitialized);
            AddObjectProperty("FormPageName_Z", gxTv_SdtTrn_LocationDynamicForm_Formpagename_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormId_Z", gxTv_SdtTrn_LocationDynamicForm_Wwpformid_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormVersionNumber_Z", gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormReferenceName_Z", gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormTitle_Z", gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z;
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
            AddObjectProperty("WWPFormIsWizard_Z", gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormResume_Z", gxTv_SdtTrn_LocationDynamicForm_Wwpformresume_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormInstantiated_Z", gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormLatestVersionNumber_Z", gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormType_Z", gxTv_SdtTrn_LocationDynamicForm_Wwpformtype_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormSectionRefElements_Z", gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements_Z, false, includeNonInitialized);
            AddObjectProperty("WWPFormIsForDynamicValidations_Z", gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations_Z, false, includeNonInitialized);
            AddObjectProperty("LocationDynamicFormId_N", gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtTrn_LocationDynamicForm sdt )
      {
         if ( sdt.IsDirty("LocationDynamicFormId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid = sdt.gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid ;
         }
         if ( sdt.IsDirty("OrganisationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Organisationid = sdt.gxTv_SdtTrn_LocationDynamicForm_Organisationid ;
         }
         if ( sdt.IsDirty("LocationId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Locationid = sdt.gxTv_SdtTrn_LocationDynamicForm_Locationid ;
         }
         if ( sdt.IsDirty("FormPageName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Formpagename = sdt.gxTv_SdtTrn_LocationDynamicForm_Formpagename ;
         }
         if ( sdt.IsDirty("WWPFormId") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformid = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformid ;
         }
         if ( sdt.IsDirty("WWPFormVersionNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber ;
         }
         if ( sdt.IsDirty("WWPFormReferenceName") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename ;
         }
         if ( sdt.IsDirty("WWPFormTitle") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle ;
         }
         if ( sdt.IsDirty("WWPFormDate") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformdate = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformdate ;
         }
         if ( sdt.IsDirty("WWPFormIsWizard") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard ;
         }
         if ( sdt.IsDirty("WWPFormResume") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformresume = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformresume ;
         }
         if ( sdt.IsDirty("WWPFormResumeMessage") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformresumemessage = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformresumemessage ;
         }
         if ( sdt.IsDirty("WWPFormValidations") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformvalidations = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformvalidations ;
         }
         if ( sdt.IsDirty("WWPFormInstantiated") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated ;
         }
         if ( sdt.IsDirty("WWPFormLatestVersionNumber") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber ;
         }
         if ( sdt.IsDirty("WWPFormType") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformtype = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformtype ;
         }
         if ( sdt.IsDirty("WWPFormSectionRefElements") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements ;
         }
         if ( sdt.IsDirty("WWPFormIsForDynamicValidations") )
         {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations = sdt.gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "LocationDynamicFormId" )]
      [  XmlElement( ElementName = "LocationDynamicFormId"   )]
      public Guid gxTpr_Locationdynamicformid
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid != value )
            {
               gxTv_SdtTrn_LocationDynamicForm_Mode = "INS";
               this.gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Formpagename_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformid_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformresume_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformtype_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations_Z_SetNull( );
            }
            gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid = value;
            SetDirty("Locationdynamicformid");
         }

      }

      [  SoapElement( ElementName = "OrganisationId" )]
      [  XmlElement( ElementName = "OrganisationId"   )]
      public Guid gxTpr_Organisationid
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Organisationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_LocationDynamicForm_Organisationid != value )
            {
               gxTv_SdtTrn_LocationDynamicForm_Mode = "INS";
               this.gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Formpagename_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformid_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformresume_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformtype_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations_Z_SetNull( );
            }
            gxTv_SdtTrn_LocationDynamicForm_Organisationid = value;
            SetDirty("Organisationid");
         }

      }

      [  SoapElement( ElementName = "LocationId" )]
      [  XmlElement( ElementName = "LocationId"   )]
      public Guid gxTpr_Locationid
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Locationid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtTrn_LocationDynamicForm_Locationid != value )
            {
               gxTv_SdtTrn_LocationDynamicForm_Mode = "INS";
               this.gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Organisationid_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Locationid_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Formpagename_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformid_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformresume_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformtype_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements_Z_SetNull( );
               this.gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations_Z_SetNull( );
            }
            gxTv_SdtTrn_LocationDynamicForm_Locationid = value;
            SetDirty("Locationid");
         }

      }

      [  SoapElement( ElementName = "FormPageName" )]
      [  XmlElement( ElementName = "FormPageName"   )]
      public string gxTpr_Formpagename
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Formpagename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Formpagename = value;
            SetDirty("Formpagename");
         }

      }

      [  SoapElement( ElementName = "WWPFormId" )]
      [  XmlElement( ElementName = "WWPFormId"   )]
      public short gxTpr_Wwpformid
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformid = value;
            SetDirty("Wwpformid");
         }

      }

      [  SoapElement( ElementName = "WWPFormVersionNumber" )]
      [  XmlElement( ElementName = "WWPFormVersionNumber"   )]
      public short gxTpr_Wwpformversionnumber
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber = value;
            SetDirty("Wwpformversionnumber");
         }

      }

      [  SoapElement( ElementName = "WWPFormReferenceName" )]
      [  XmlElement( ElementName = "WWPFormReferenceName"   )]
      public string gxTpr_Wwpformreferencename
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename = value;
            SetDirty("Wwpformreferencename");
         }

      }

      [  SoapElement( ElementName = "WWPFormTitle" )]
      [  XmlElement( ElementName = "WWPFormTitle"   )]
      public string gxTpr_Wwpformtitle
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle = value;
            SetDirty("Wwpformtitle");
         }

      }

      [  SoapElement( ElementName = "WWPFormDate" )]
      [  XmlElement( ElementName = "WWPFormDate"  , IsNullable=true )]
      public string gxTpr_Wwpformdate_Nullable
      {
         get {
            if ( gxTv_SdtTrn_LocationDynamicForm_Wwpformdate == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_LocationDynamicForm_Wwpformdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_LocationDynamicForm_Wwpformdate = DateTime.MinValue;
            else
               gxTv_SdtTrn_LocationDynamicForm_Wwpformdate = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpformdate
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformdate = value;
            SetDirty("Wwpformdate");
         }

      }

      [  SoapElement( ElementName = "WWPFormIsWizard" )]
      [  XmlElement( ElementName = "WWPFormIsWizard"   )]
      public bool gxTpr_Wwpformiswizard
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard = value;
            SetDirty("Wwpformiswizard");
         }

      }

      [  SoapElement( ElementName = "WWPFormResume" )]
      [  XmlElement( ElementName = "WWPFormResume"   )]
      public short gxTpr_Wwpformresume
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformresume ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformresume = value;
            SetDirty("Wwpformresume");
         }

      }

      [  SoapElement( ElementName = "WWPFormResumeMessage" )]
      [  XmlElement( ElementName = "WWPFormResumeMessage"   )]
      public string gxTpr_Wwpformresumemessage
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformresumemessage ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformresumemessage = value;
            SetDirty("Wwpformresumemessage");
         }

      }

      [  SoapElement( ElementName = "WWPFormValidations" )]
      [  XmlElement( ElementName = "WWPFormValidations"   )]
      public string gxTpr_Wwpformvalidations
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformvalidations ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformvalidations = value;
            SetDirty("Wwpformvalidations");
         }

      }

      [  SoapElement( ElementName = "WWPFormInstantiated" )]
      [  XmlElement( ElementName = "WWPFormInstantiated"   )]
      public bool gxTpr_Wwpforminstantiated
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated = value;
            SetDirty("Wwpforminstantiated");
         }

      }

      [  SoapElement( ElementName = "WWPFormLatestVersionNumber" )]
      [  XmlElement( ElementName = "WWPFormLatestVersionNumber"   )]
      public short gxTpr_Wwpformlatestversionnumber
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber = value;
            SetDirty("Wwpformlatestversionnumber");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber = 0;
         SetDirty("Wwpformlatestversionnumber");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormType" )]
      [  XmlElement( ElementName = "WWPFormType"   )]
      public short gxTpr_Wwpformtype
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformtype ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformtype = value;
            SetDirty("Wwpformtype");
         }

      }

      [  SoapElement( ElementName = "WWPFormSectionRefElements" )]
      [  XmlElement( ElementName = "WWPFormSectionRefElements"   )]
      public string gxTpr_Wwpformsectionrefelements
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements = value;
            SetDirty("Wwpformsectionrefelements");
         }

      }

      [  SoapElement( ElementName = "WWPFormIsForDynamicValidations" )]
      [  XmlElement( ElementName = "WWPFormIsForDynamicValidations"   )]
      public bool gxTpr_Wwpformisfordynamicvalidations
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations = value;
            SetDirty("Wwpformisfordynamicvalidations");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Mode_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Initialized_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationDynamicFormId_Z" )]
      [  XmlElement( ElementName = "LocationDynamicFormId_Z"   )]
      public Guid gxTpr_Locationdynamicformid_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_Z = value;
            SetDirty("Locationdynamicformid_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_Z = Guid.Empty;
         SetDirty("Locationdynamicformid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "OrganisationId_Z" )]
      [  XmlElement( ElementName = "OrganisationId_Z"   )]
      public Guid gxTpr_Organisationid_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Organisationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Organisationid_Z = value;
            SetDirty("Organisationid_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Organisationid_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Organisationid_Z = Guid.Empty;
         SetDirty("Organisationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Organisationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationId_Z" )]
      [  XmlElement( ElementName = "LocationId_Z"   )]
      public Guid gxTpr_Locationid_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Locationid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Locationid_Z = value;
            SetDirty("Locationid_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Locationid_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Locationid_Z = Guid.Empty;
         SetDirty("Locationid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Locationid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FormPageName_Z" )]
      [  XmlElement( ElementName = "FormPageName_Z"   )]
      public string gxTpr_Formpagename_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Formpagename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Formpagename_Z = value;
            SetDirty("Formpagename_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Formpagename_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Formpagename_Z = "";
         SetDirty("Formpagename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Formpagename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormId_Z" )]
      [  XmlElement( ElementName = "WWPFormId_Z"   )]
      public short gxTpr_Wwpformid_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformid_Z = value;
            SetDirty("Wwpformid_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Wwpformid_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Wwpformid_Z = 0;
         SetDirty("Wwpformid_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Wwpformid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormVersionNumber_Z" )]
      [  XmlElement( ElementName = "WWPFormVersionNumber_Z"   )]
      public short gxTpr_Wwpformversionnumber_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber_Z = value;
            SetDirty("Wwpformversionnumber_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber_Z = 0;
         SetDirty("Wwpformversionnumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormReferenceName_Z" )]
      [  XmlElement( ElementName = "WWPFormReferenceName_Z"   )]
      public string gxTpr_Wwpformreferencename_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename_Z = value;
            SetDirty("Wwpformreferencename_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename_Z = "";
         SetDirty("Wwpformreferencename_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormTitle_Z" )]
      [  XmlElement( ElementName = "WWPFormTitle_Z"   )]
      public string gxTpr_Wwpformtitle_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle_Z = value;
            SetDirty("Wwpformtitle_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle_Z = "";
         SetDirty("Wwpformtitle_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormDate_Z" )]
      [  XmlElement( ElementName = "WWPFormDate_Z"  , IsNullable=true )]
      public string gxTpr_Wwpformdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z = DateTime.MinValue;
            else
               gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Wwpformdate_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z = value;
            SetDirty("Wwpformdate_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Wwpformdate_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormIsWizard_Z" )]
      [  XmlElement( ElementName = "WWPFormIsWizard_Z"   )]
      public bool gxTpr_Wwpformiswizard_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard_Z = value;
            SetDirty("Wwpformiswizard_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard_Z = false;
         SetDirty("Wwpformiswizard_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormResume_Z" )]
      [  XmlElement( ElementName = "WWPFormResume_Z"   )]
      public short gxTpr_Wwpformresume_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformresume_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformresume_Z = value;
            SetDirty("Wwpformresume_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Wwpformresume_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Wwpformresume_Z = 0;
         SetDirty("Wwpformresume_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Wwpformresume_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormInstantiated_Z" )]
      [  XmlElement( ElementName = "WWPFormInstantiated_Z"   )]
      public bool gxTpr_Wwpforminstantiated_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated_Z = value;
            SetDirty("Wwpforminstantiated_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated_Z = false;
         SetDirty("Wwpforminstantiated_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormLatestVersionNumber_Z" )]
      [  XmlElement( ElementName = "WWPFormLatestVersionNumber_Z"   )]
      public short gxTpr_Wwpformlatestversionnumber_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber_Z = value;
            SetDirty("Wwpformlatestversionnumber_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber_Z = 0;
         SetDirty("Wwpformlatestversionnumber_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormType_Z" )]
      [  XmlElement( ElementName = "WWPFormType_Z"   )]
      public short gxTpr_Wwpformtype_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformtype_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformtype_Z = value;
            SetDirty("Wwpformtype_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Wwpformtype_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Wwpformtype_Z = 0;
         SetDirty("Wwpformtype_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Wwpformtype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormSectionRefElements_Z" )]
      [  XmlElement( ElementName = "WWPFormSectionRefElements_Z"   )]
      public string gxTpr_Wwpformsectionrefelements_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements_Z = value;
            SetDirty("Wwpformsectionrefelements_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements_Z = "";
         SetDirty("Wwpformsectionrefelements_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "WWPFormIsForDynamicValidations_Z" )]
      [  XmlElement( ElementName = "WWPFormIsForDynamicValidations_Z"   )]
      public bool gxTpr_Wwpformisfordynamicvalidations_Z
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations_Z = value;
            SetDirty("Wwpformisfordynamicvalidations_Z");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations_Z_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations_Z = false;
         SetDirty("Wwpformisfordynamicvalidations_Z");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "LocationDynamicFormId_N" )]
      [  XmlElement( ElementName = "LocationDynamicFormId_N"   )]
      public short gxTpr_Locationdynamicformid_N
      {
         get {
            return gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_N = value;
            SetDirty("Locationdynamicformid_N");
         }

      }

      public void gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_N_SetNull( )
      {
         gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_N = 0;
         SetDirty("Locationdynamicformid_N");
         return  ;
      }

      public bool gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_N_IsNull( )
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
         gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid = Guid.Empty;
         sdtIsNull = 1;
         gxTv_SdtTrn_LocationDynamicForm_Organisationid = Guid.Empty;
         gxTv_SdtTrn_LocationDynamicForm_Locationid = Guid.Empty;
         gxTv_SdtTrn_LocationDynamicForm_Formpagename = "";
         gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename = "";
         gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle = "";
         gxTv_SdtTrn_LocationDynamicForm_Wwpformdate = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_LocationDynamicForm_Wwpformresumemessage = "";
         gxTv_SdtTrn_LocationDynamicForm_Wwpformvalidations = "";
         gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements = "";
         gxTv_SdtTrn_LocationDynamicForm_Mode = "";
         gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_Z = Guid.Empty;
         gxTv_SdtTrn_LocationDynamicForm_Organisationid_Z = Guid.Empty;
         gxTv_SdtTrn_LocationDynamicForm_Locationid_Z = Guid.Empty;
         gxTv_SdtTrn_LocationDynamicForm_Formpagename_Z = "";
         gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename_Z = "";
         gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle_Z = "";
         gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "trn_locationdynamicform", "GeneXus.Programs.trn_locationdynamicform_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtTrn_LocationDynamicForm_Wwpformid ;
      private short gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber ;
      private short gxTv_SdtTrn_LocationDynamicForm_Wwpformresume ;
      private short gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber ;
      private short gxTv_SdtTrn_LocationDynamicForm_Wwpformtype ;
      private short gxTv_SdtTrn_LocationDynamicForm_Initialized ;
      private short gxTv_SdtTrn_LocationDynamicForm_Wwpformid_Z ;
      private short gxTv_SdtTrn_LocationDynamicForm_Wwpformversionnumber_Z ;
      private short gxTv_SdtTrn_LocationDynamicForm_Wwpformresume_Z ;
      private short gxTv_SdtTrn_LocationDynamicForm_Wwpformlatestversionnumber_Z ;
      private short gxTv_SdtTrn_LocationDynamicForm_Wwpformtype_Z ;
      private short gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_N ;
      private string gxTv_SdtTrn_LocationDynamicForm_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtTrn_LocationDynamicForm_Wwpformdate ;
      private DateTime gxTv_SdtTrn_LocationDynamicForm_Wwpformdate_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard ;
      private bool gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated ;
      private bool gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations ;
      private bool gxTv_SdtTrn_LocationDynamicForm_Wwpformiswizard_Z ;
      private bool gxTv_SdtTrn_LocationDynamicForm_Wwpforminstantiated_Z ;
      private bool gxTv_SdtTrn_LocationDynamicForm_Wwpformisfordynamicvalidations_Z ;
      private string gxTv_SdtTrn_LocationDynamicForm_Wwpformresumemessage ;
      private string gxTv_SdtTrn_LocationDynamicForm_Wwpformvalidations ;
      private string gxTv_SdtTrn_LocationDynamicForm_Formpagename ;
      private string gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename ;
      private string gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle ;
      private string gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements ;
      private string gxTv_SdtTrn_LocationDynamicForm_Formpagename_Z ;
      private string gxTv_SdtTrn_LocationDynamicForm_Wwpformreferencename_Z ;
      private string gxTv_SdtTrn_LocationDynamicForm_Wwpformtitle_Z ;
      private string gxTv_SdtTrn_LocationDynamicForm_Wwpformsectionrefelements_Z ;
      private Guid gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid ;
      private Guid gxTv_SdtTrn_LocationDynamicForm_Organisationid ;
      private Guid gxTv_SdtTrn_LocationDynamicForm_Locationid ;
      private Guid gxTv_SdtTrn_LocationDynamicForm_Locationdynamicformid_Z ;
      private Guid gxTv_SdtTrn_LocationDynamicForm_Organisationid_Z ;
      private Guid gxTv_SdtTrn_LocationDynamicForm_Locationid_Z ;
   }

   [DataContract(Name = @"Trn_LocationDynamicForm", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_LocationDynamicForm_RESTInterface : GxGenericCollectionItem<SdtTrn_LocationDynamicForm>
   {
      public SdtTrn_LocationDynamicForm_RESTInterface( ) : base()
      {
      }

      public SdtTrn_LocationDynamicForm_RESTInterface( SdtTrn_LocationDynamicForm psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "LocationDynamicFormId" , Order = 0 )]
      [GxSeudo()]
      public Guid gxTpr_Locationdynamicformid
      {
         get {
            return sdt.gxTpr_Locationdynamicformid ;
         }

         set {
            sdt.gxTpr_Locationdynamicformid = value;
         }

      }

      [DataMember( Name = "OrganisationId" , Order = 1 )]
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

      [DataMember( Name = "LocationId" , Order = 2 )]
      [GxSeudo()]
      public Guid gxTpr_Locationid
      {
         get {
            return sdt.gxTpr_Locationid ;
         }

         set {
            sdt.gxTpr_Locationid = value;
         }

      }

      [DataMember( Name = "FormPageName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Formpagename
      {
         get {
            return sdt.gxTpr_Formpagename ;
         }

         set {
            sdt.gxTpr_Formpagename = value;
         }

      }

      [DataMember( Name = "WWPFormId" , Order = 4 )]
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

      [DataMember( Name = "WWPFormVersionNumber" , Order = 5 )]
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

      [DataMember( Name = "WWPFormReferenceName" , Order = 6 )]
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

      [DataMember( Name = "WWPFormTitle" , Order = 7 )]
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

      [DataMember( Name = "WWPFormDate" , Order = 8 )]
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

      [DataMember( Name = "WWPFormIsWizard" , Order = 9 )]
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

      [DataMember( Name = "WWPFormResume" , Order = 10 )]
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

      [DataMember( Name = "WWPFormResumeMessage" , Order = 11 )]
      public string gxTpr_Wwpformresumemessage
      {
         get {
            return sdt.gxTpr_Wwpformresumemessage ;
         }

         set {
            sdt.gxTpr_Wwpformresumemessage = value;
         }

      }

      [DataMember( Name = "WWPFormValidations" , Order = 12 )]
      public string gxTpr_Wwpformvalidations
      {
         get {
            return sdt.gxTpr_Wwpformvalidations ;
         }

         set {
            sdt.gxTpr_Wwpformvalidations = value;
         }

      }

      [DataMember( Name = "WWPFormInstantiated" , Order = 13 )]
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

      [DataMember( Name = "WWPFormLatestVersionNumber" , Order = 14 )]
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

      [DataMember( Name = "WWPFormType" , Order = 15 )]
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

      [DataMember( Name = "WWPFormSectionRefElements" , Order = 16 )]
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

      [DataMember( Name = "WWPFormIsForDynamicValidations" , Order = 17 )]
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

      public SdtTrn_LocationDynamicForm sdt
      {
         get {
            return (SdtTrn_LocationDynamicForm)Sdt ;
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
            sdt = new SdtTrn_LocationDynamicForm() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 18 )]
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

   [DataContract(Name = @"Trn_LocationDynamicForm", Namespace = "Comforta_version2")]
   [GxJsonSerialization("default")]
   public class SdtTrn_LocationDynamicForm_RESTLInterface : GxGenericCollectionItem<SdtTrn_LocationDynamicForm>
   {
      public SdtTrn_LocationDynamicForm_RESTLInterface( ) : base()
      {
      }

      public SdtTrn_LocationDynamicForm_RESTLInterface( SdtTrn_LocationDynamicForm psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "WWPFormTitle" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtTrn_LocationDynamicForm sdt
      {
         get {
            return (SdtTrn_LocationDynamicForm)Sdt ;
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
            sdt = new SdtTrn_LocationDynamicForm() ;
         }
      }

   }

}
