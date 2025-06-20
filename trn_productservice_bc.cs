using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class trn_productservice_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_productservice_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_productservice_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0868( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0868( ) ;
         standaloneModal( ) ;
         AddRow0868( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11082 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z58ProductServiceId = A58ProductServiceId;
               Z29LocationId = A29LocationId;
               Z11OrganisationId = A11OrganisationId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_080( )
      {
         BeforeValidate0868( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0868( ) ;
            }
            else
            {
               CheckExtendedTable0868( ) ;
               if ( AnyError == 0 )
               {
                  ZM0868( 16) ;
                  ZM0868( 17) ;
                  ZM0868( 18) ;
               }
               CloseExtendedTableCursors0868( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12082( )
      {
         /* Start Routine */
         returnInSub = false;
         GXt_objcol_guid1 = AV41PreferredGenSuppliers;
         new prc_getpreferredgensuppliers(context ).execute( ref  GXt_objcol_guid1) ;
         AV41PreferredGenSuppliers = GXt_objcol_guid1;
         AV67UploadedFiles = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV19WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV16TrnContext.FromXml(AV18WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV16TrnContext.gxTpr_Transactionname, AV71Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV72GXV1 = 1;
            while ( AV72GXV1 <= AV16TrnContext.gxTpr_Attributes.Count )
            {
               AV17TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV16TrnContext.gxTpr_Attributes.Item(AV72GXV1));
               if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "SupplierGenId") == 0 )
               {
                  AV10Insert_SupplierGenId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV17TrnContextAtt.gxTpr_Attributename, "SupplierAgbId") == 0 )
               {
                  AV9Insert_SupplierAgbId = StringUtil.StrToGuid( AV17TrnContextAtt.gxTpr_Attributevalue);
               }
               AV72GXV1 = (int)(AV72GXV1+1);
            }
         }
         /* Execute user subroutine: 'SETSTATEOFSUPPLIER' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV57isManager = (bool)(AV19WWPContext.gxTpr_Isorganisationmanager||AV19WWPContext.gxTpr_Isrootadmin);
      }

      protected void E11082( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV19WWPContext.gxTpr_Isreceptionist )
         {
            AV61RoleName = context.GetMessage( "Receptionist", "");
         }
         if ( AV19WWPContext.gxTpr_Isorganisationmanager )
         {
            AV61RoleName = context.GetMessage( "Manager", "");
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV63SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
            AV63SDT_NotificationMetadata.gxTpr_Isparentnotification = true;
            AV63SDT_NotificationMetadata.gxTpr_Parentnotificationid = A58ProductServiceId.ToString();
            AV63SDT_NotificationMetadata.gxTpr_Notificationtriggeredtimestamp = DateTimeUtil.Now( context);
            AV63SDT_NotificationMetadata.gxTpr_Notificationorigin = "Product/Service";
            AV64WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
            AV64WWPNotificationMetadataSDT.gxTpr_Custommetadata = AV63SDT_NotificationMetadata;
            GXt_char2 = AV62NotificationDescription;
            GXt_char3 = AV62NotificationDescription;
            new uwwp_getloggeduserid(context ).execute( out  GXt_char3) ;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  GXt_char3, out  GXt_char2) ;
            AV62NotificationDescription = StringUtil.Format( context.GetMessage( "%1 added by %2 %3", ""), A59ProductServiceName, AV61RoleName, GXt_char2, "", "", "", "", "", "");
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_productserviceview.aspx"+UrlEncode(A58ProductServiceId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            AV55NotificationLink = formatLink("trn_productserviceview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  "InsertRecord",  "Trn_ProductService",  "",  context.GetMessage( "fas fa-plus NotificationFontIconSuccess", ""),  context.GetMessage( "New Service", ""),  AV62NotificationDescription,  AV62NotificationDescription,  AV55NotificationLink,  AV64WWPNotificationMetadataSDT.ToJSonString(false, true),  "",  AV53IsWeb) ;
         }
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV63SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
            AV63SDT_NotificationMetadata.gxTpr_Isparentnotification = false;
            AV63SDT_NotificationMetadata.gxTpr_Parentnotificationid = A58ProductServiceId.ToString();
            AV63SDT_NotificationMetadata.gxTpr_Notificationtriggeredtimestamp = DateTimeUtil.Now( context);
            AV63SDT_NotificationMetadata.gxTpr_Notificationorigin = "Product/Service";
            AV64WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
            AV64WWPNotificationMetadataSDT.gxTpr_Custommetadata = AV63SDT_NotificationMetadata;
            GXt_char3 = AV62NotificationDescription;
            GXt_char2 = AV62NotificationDescription;
            new uwwp_getloggeduserid(context ).execute( out  GXt_char2) ;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  GXt_char2, out  GXt_char3) ;
            AV62NotificationDescription = StringUtil.Format( context.GetMessage( "%1 updated by %2 %3", ""), A59ProductServiceName, AV61RoleName, GXt_char3, "", "", "", "", "", "");
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "trn_productserviceview.aspx"+UrlEncode(A58ProductServiceId.ToString()) + "," + UrlEncode(A29LocationId.ToString()) + "," + UrlEncode(A11OrganisationId.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            AV55NotificationLink = formatLink("trn_productserviceview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  "UpdateRecord",  "Trn_ProductService",  "",  context.GetMessage( "fas fa-pencil-alt NotificationFontIconWarning", ""),  context.GetMessage( "Service Updated", ""),  AV62NotificationDescription,  AV62NotificationDescription,  AV55NotificationLink,  AV64WWPNotificationMetadataSDT.ToJSonString(false, true),  "",  AV53IsWeb) ;
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV63SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
            AV63SDT_NotificationMetadata.gxTpr_Isparentnotification = false;
            AV63SDT_NotificationMetadata.gxTpr_Parentnotificationid = A58ProductServiceId.ToString();
            AV63SDT_NotificationMetadata.gxTpr_Notificationtriggeredtimestamp = DateTimeUtil.Now( context);
            AV63SDT_NotificationMetadata.gxTpr_Notificationorigin = "Product/Service";
            AV64WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
            AV64WWPNotificationMetadataSDT.gxTpr_Custommetadata = AV63SDT_NotificationMetadata;
            GXt_char3 = AV62NotificationDescription;
            GXt_char2 = AV62NotificationDescription;
            new uwwp_getloggeduserid(context ).execute( out  GXt_char2) ;
            new GeneXus.Programs.wwpbaseobjects.wwp_getuserfullname(context ).execute(  GXt_char2, out  GXt_char3) ;
            AV62NotificationDescription = StringUtil.Format( context.GetMessage( "%1 deleted by %2 %3", ""), A59ProductServiceName, AV61RoleName, GXt_char3, "", "", "", "", "", "");
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_sendnotification(context ).execute(  "DeleteRecord",  "Trn_ProductService",  "",  context.GetMessage( "far fa-trash-alt NotificationFontIconDanger", ""),  context.GetMessage( "Service Deleted", ""),  AV62NotificationDescription,  AV62NotificationDescription,  "",  AV64WWPNotificationMetadataSDT.ToJSonString(false, true),  "",  AV53IsWeb) ;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
         {
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void E13082( )
      {
         /* ProductServiceGroup_Controlvaluechanged Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(A338ProductServiceGroup, " AGB Supplier") == 0 )
         {
            AV26ComboSupplierGenId = Guid.Empty;
         }
         else if ( StringUtil.StrCmp(A338ProductServiceGroup, "Supplier") == 0 )
         {
            AV30ComboSupplierAgbId = Guid.Empty;
         }
         else if ( StringUtil.StrCmp(A338ProductServiceGroup, "Location") == 0 )
         {
            AV30ComboSupplierAgbId = Guid.Empty;
            AV26ComboSupplierGenId = Guid.Empty;
         }
      }

      protected void E14082( )
      {
         /* Listgen_Controlvaluechanged Routine */
         returnInSub = false;
      }

      protected void E15082( )
      {
         /* Listgenpre_Controlvaluechanged Routine */
         returnInSub = false;
      }

      protected void E16082( )
      {
         /* Listagb_Controlvaluechanged Routine */
         returnInSub = false;
         if ( AV42ListAgb )
         {
            AV52ListAgbPre = true;
         }
         else if ( ! AV42ListAgb )
         {
            AV52ListAgbPre = false;
         }
      }

      protected void E17082( )
      {
         /* Listagbpre_Controlvaluechanged Routine */
         returnInSub = false;
         if ( AV52ListAgbPre )
         {
            AV42ListAgb = true;
         }
         else if ( ! AV52ListAgbPre )
         {
            AV42ListAgb = false;
         }
      }

      protected void S122( )
      {
         /* 'SETSTATEOFSUPPLIER' Routine */
         returnInSub = false;
      }

      protected void ZM0868( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z59ProductServiceName = A59ProductServiceName;
            Z266ProductServiceTileName = A266ProductServiceTileName;
            Z370ProductServiceClass = A370ProductServiceClass;
            Z338ProductServiceGroup = A338ProductServiceGroup;
            Z42SupplierGenId = A42SupplierGenId;
            Z49SupplierAgbId = A49SupplierAgbId;
         }
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
         }
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z51SupplierAgbName = A51SupplierAgbName;
         }
         if ( GX_JID == -15 )
         {
            Z58ProductServiceId = A58ProductServiceId;
            Z59ProductServiceName = A59ProductServiceName;
            Z266ProductServiceTileName = A266ProductServiceTileName;
            Z60ProductServiceDescription = A60ProductServiceDescription;
            Z370ProductServiceClass = A370ProductServiceClass;
            Z61ProductServiceImage = A61ProductServiceImage;
            Z40000ProductServiceImage_GXI = A40000ProductServiceImage_GXI;
            Z338ProductServiceGroup = A338ProductServiceGroup;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z42SupplierGenId = A42SupplierGenId;
            Z49SupplierAgbId = A49SupplierAgbId;
            Z44SupplierGenCompanyName = A44SupplierGenCompanyName;
            Z51SupplierAgbName = A51SupplierAgbName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV71Pgmname = "Trn_ProductService_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A58ProductServiceId) )
         {
            A58ProductServiceId = Guid.NewGuid( );
            n58ProductServiceId = false;
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A338ProductServiceGroup)) && ( Gx_BScreen == 0 ) )
         {
            A338ProductServiceGroup = "Location";
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0868( )
      {
         /* Using cursor BC00087 */
         pr_default.execute(5, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound68 = 1;
            A59ProductServiceName = BC00087_A59ProductServiceName[0];
            A266ProductServiceTileName = BC00087_A266ProductServiceTileName[0];
            A60ProductServiceDescription = BC00087_A60ProductServiceDescription[0];
            A370ProductServiceClass = BC00087_A370ProductServiceClass[0];
            A40000ProductServiceImage_GXI = BC00087_A40000ProductServiceImage_GXI[0];
            A338ProductServiceGroup = BC00087_A338ProductServiceGroup[0];
            A44SupplierGenCompanyName = BC00087_A44SupplierGenCompanyName[0];
            A51SupplierAgbName = BC00087_A51SupplierAgbName[0];
            A42SupplierGenId = BC00087_A42SupplierGenId[0];
            n42SupplierGenId = BC00087_n42SupplierGenId[0];
            A49SupplierAgbId = BC00087_A49SupplierAgbId[0];
            n49SupplierAgbId = BC00087_n49SupplierAgbId[0];
            A61ProductServiceImage = BC00087_A61ProductServiceImage[0];
            ZM0868( -15) ;
         }
         pr_default.close(5);
         OnLoadActions0868( ) ;
      }

      protected void OnLoadActions0868( )
      {
      }

      protected void CheckExtendedTable0868( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00084 */
         pr_default.execute(2, new Object[] {A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A59ProductServiceName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Product Service Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A266ProductServiceTileName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Product Service Tile Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00085 */
         pr_default.execute(3, new Object[] {n42SupplierGenId, A42SupplierGenId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A42SupplierGenId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "General Suppliers", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERGENID");
               AnyError = 1;
            }
         }
         A44SupplierGenCompanyName = BC00085_A44SupplierGenCompanyName[0];
         pr_default.close(3);
         /* Using cursor BC00086 */
         pr_default.execute(4, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A49SupplierAgbId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "AGB Suppliers", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SUPPLIERAGBID");
               AnyError = 1;
            }
         }
         A51SupplierAgbName = BC00086_A51SupplierAgbName[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0868( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0868( )
      {
         /* Using cursor BC00088 */
         pr_default.execute(6, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound68 = 1;
         }
         else
         {
            RcdFound68 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00083 */
         pr_default.execute(1, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0868( 15) ;
            RcdFound68 = 1;
            A58ProductServiceId = BC00083_A58ProductServiceId[0];
            n58ProductServiceId = BC00083_n58ProductServiceId[0];
            A59ProductServiceName = BC00083_A59ProductServiceName[0];
            A266ProductServiceTileName = BC00083_A266ProductServiceTileName[0];
            A60ProductServiceDescription = BC00083_A60ProductServiceDescription[0];
            A370ProductServiceClass = BC00083_A370ProductServiceClass[0];
            A40000ProductServiceImage_GXI = BC00083_A40000ProductServiceImage_GXI[0];
            A338ProductServiceGroup = BC00083_A338ProductServiceGroup[0];
            A29LocationId = BC00083_A29LocationId[0];
            A11OrganisationId = BC00083_A11OrganisationId[0];
            A42SupplierGenId = BC00083_A42SupplierGenId[0];
            n42SupplierGenId = BC00083_n42SupplierGenId[0];
            A49SupplierAgbId = BC00083_A49SupplierAgbId[0];
            n49SupplierAgbId = BC00083_n49SupplierAgbId[0];
            A61ProductServiceImage = BC00083_A61ProductServiceImage[0];
            Z58ProductServiceId = A58ProductServiceId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            sMode68 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0868( ) ;
            if ( AnyError == 1 )
            {
               RcdFound68 = 0;
               InitializeNonKey0868( ) ;
            }
            Gx_mode = sMode68;
         }
         else
         {
            RcdFound68 = 0;
            InitializeNonKey0868( ) ;
            sMode68 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode68;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0868( ) ;
         if ( RcdFound68 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_080( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0868( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00082 */
            pr_default.execute(0, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ProductService"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z59ProductServiceName, BC00082_A59ProductServiceName[0]) != 0 ) || ( StringUtil.StrCmp(Z266ProductServiceTileName, BC00082_A266ProductServiceTileName[0]) != 0 ) || ( StringUtil.StrCmp(Z370ProductServiceClass, BC00082_A370ProductServiceClass[0]) != 0 ) || ( StringUtil.StrCmp(Z338ProductServiceGroup, BC00082_A338ProductServiceGroup[0]) != 0 ) || ( Z42SupplierGenId != BC00082_A42SupplierGenId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z49SupplierAgbId != BC00082_A49SupplierAgbId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_ProductService"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0868( )
      {
         BeforeValidate0868( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0868( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0868( 0) ;
            CheckOptimisticConcurrency0868( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0868( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0868( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00089 */
                     pr_default.execute(7, new Object[] {n58ProductServiceId, A58ProductServiceId, A59ProductServiceName, A266ProductServiceTileName, A60ProductServiceDescription, A370ProductServiceClass, A61ProductServiceImage, A40000ProductServiceImage_GXI, A338ProductServiceGroup, A29LocationId, A11OrganisationId, n42SupplierGenId, A42SupplierGenId, n49SupplierAgbId, A49SupplierAgbId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
                     if ( (pr_default.getStatus(7) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0868( ) ;
            }
            EndLevel0868( ) ;
         }
         CloseExtendedTableCursors0868( ) ;
      }

      protected void Update0868( )
      {
         BeforeValidate0868( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0868( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0868( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0868( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0868( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000810 */
                     pr_default.execute(8, new Object[] {A59ProductServiceName, A266ProductServiceTileName, A60ProductServiceDescription, A370ProductServiceClass, A338ProductServiceGroup, n42SupplierGenId, A42SupplierGenId, n49SupplierAgbId, A49SupplierAgbId, n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_ProductService"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0868( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0868( ) ;
         }
         CloseExtendedTableCursors0868( ) ;
      }

      protected void DeferredUpdate0868( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000811 */
            pr_default.execute(9, new Object[] {A61ProductServiceImage, A40000ProductServiceImage_GXI, n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
            pr_default.close(9);
            pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0868( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0868( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0868( ) ;
            AfterConfirm0868( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0868( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000812 */
                  pr_default.execute(10, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_ProductService");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode68 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0868( ) ;
         Gx_mode = sMode68;
      }

      protected void OnDeleteControls0868( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000813 */
            pr_default.execute(11, new Object[] {n42SupplierGenId, A42SupplierGenId});
            A44SupplierGenCompanyName = BC000813_A44SupplierGenCompanyName[0];
            pr_default.close(11);
            /* Using cursor BC000814 */
            pr_default.execute(12, new Object[] {n49SupplierAgbId, A49SupplierAgbId});
            A51SupplierAgbName = BC000814_A51SupplierAgbName[0];
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000815 */
            pr_default.execute(13, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Page", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC000816 */
            pr_default.execute(14, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Call To Actions", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel0868( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0868( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            new prc_addtodynamictransalation(context ).execute(  AV66SDT_TrnAttributes) ;
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0868( )
      {
         /* Scan By routine */
         /* Using cursor BC000817 */
         pr_default.execute(15, new Object[] {n58ProductServiceId, A58ProductServiceId, A29LocationId, A11OrganisationId});
         RcdFound68 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound68 = 1;
            A58ProductServiceId = BC000817_A58ProductServiceId[0];
            n58ProductServiceId = BC000817_n58ProductServiceId[0];
            A59ProductServiceName = BC000817_A59ProductServiceName[0];
            A266ProductServiceTileName = BC000817_A266ProductServiceTileName[0];
            A60ProductServiceDescription = BC000817_A60ProductServiceDescription[0];
            A370ProductServiceClass = BC000817_A370ProductServiceClass[0];
            A40000ProductServiceImage_GXI = BC000817_A40000ProductServiceImage_GXI[0];
            A338ProductServiceGroup = BC000817_A338ProductServiceGroup[0];
            A44SupplierGenCompanyName = BC000817_A44SupplierGenCompanyName[0];
            A51SupplierAgbName = BC000817_A51SupplierAgbName[0];
            A29LocationId = BC000817_A29LocationId[0];
            A11OrganisationId = BC000817_A11OrganisationId[0];
            A42SupplierGenId = BC000817_A42SupplierGenId[0];
            n42SupplierGenId = BC000817_n42SupplierGenId[0];
            A49SupplierAgbId = BC000817_A49SupplierAgbId[0];
            n49SupplierAgbId = BC000817_n49SupplierAgbId[0];
            A61ProductServiceImage = BC000817_A61ProductServiceImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0868( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound68 = 0;
         ScanKeyLoad0868( ) ;
      }

      protected void ScanKeyLoad0868( )
      {
         sMode68 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound68 = 1;
            A58ProductServiceId = BC000817_A58ProductServiceId[0];
            n58ProductServiceId = BC000817_n58ProductServiceId[0];
            A59ProductServiceName = BC000817_A59ProductServiceName[0];
            A266ProductServiceTileName = BC000817_A266ProductServiceTileName[0];
            A60ProductServiceDescription = BC000817_A60ProductServiceDescription[0];
            A370ProductServiceClass = BC000817_A370ProductServiceClass[0];
            A40000ProductServiceImage_GXI = BC000817_A40000ProductServiceImage_GXI[0];
            A338ProductServiceGroup = BC000817_A338ProductServiceGroup[0];
            A44SupplierGenCompanyName = BC000817_A44SupplierGenCompanyName[0];
            A51SupplierAgbName = BC000817_A51SupplierAgbName[0];
            A29LocationId = BC000817_A29LocationId[0];
            A11OrganisationId = BC000817_A11OrganisationId[0];
            A42SupplierGenId = BC000817_A42SupplierGenId[0];
            n42SupplierGenId = BC000817_n42SupplierGenId[0];
            A49SupplierAgbId = BC000817_A49SupplierAgbId[0];
            n49SupplierAgbId = BC000817_n49SupplierAgbId[0];
            A61ProductServiceImage = BC000817_A61ProductServiceImage[0];
         }
         Gx_mode = sMode68;
      }

      protected void ScanKeyEnd0868( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0868( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0868( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0868( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0868( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0868( )
      {
         /* Before Complete Rules */
         GXt_SdtSDT_TrnAttributes4 = AV66SDT_TrnAttributes;
         new prc_addproductserviceattributestosdt(context ).execute(  A58ProductServiceId, out  GXt_SdtSDT_TrnAttributes4) ;
         AV66SDT_TrnAttributes = GXt_SdtSDT_TrnAttributes4;
      }

      protected void BeforeValidate0868( )
      {
         /* Before Validate Rules */
         if ( new prc_uniquelocationservicename(context).executeUdp(  A59ProductServiceName,  A29LocationId,  A58ProductServiceId) )
         {
            GX_msglist.addItem(new WorkWithPlus.workwithplus_web.dvmessagegetbasicnotificationmsg(context).executeUdp(  "Error!",  context.GetMessage( "Service name Already exists", ""),  "error",  "",  "true",  ""), 1, "");
            AnyError = 1;
         }
      }

      protected void DisableAttributes0868( )
      {
      }

      protected void send_integrity_lvl_hashes0868( )
      {
      }

      protected void AddRow0868( )
      {
         VarsToRow68( bcTrn_ProductService) ;
      }

      protected void ReadRow0868( )
      {
         RowToVars68( bcTrn_ProductService, 1) ;
      }

      protected void InitializeNonKey0868( )
      {
         AV66SDT_TrnAttributes = new SdtSDT_TrnAttributes(context);
         A59ProductServiceName = "";
         A266ProductServiceTileName = "";
         A60ProductServiceDescription = "";
         A370ProductServiceClass = "";
         A61ProductServiceImage = "";
         A40000ProductServiceImage_GXI = "";
         A42SupplierGenId = Guid.Empty;
         n42SupplierGenId = false;
         A44SupplierGenCompanyName = "";
         A49SupplierAgbId = Guid.Empty;
         n49SupplierAgbId = false;
         A51SupplierAgbName = "";
         A338ProductServiceGroup = "Location";
         Z59ProductServiceName = "";
         Z266ProductServiceTileName = "";
         Z370ProductServiceClass = "";
         Z338ProductServiceGroup = "";
         Z42SupplierGenId = Guid.Empty;
         Z49SupplierAgbId = Guid.Empty;
      }

      protected void InitAll0868( )
      {
         A58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         A29LocationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         InitializeNonKey0868( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A338ProductServiceGroup = i338ProductServiceGroup;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow68( SdtTrn_ProductService obj68 )
      {
         obj68.gxTpr_Mode = Gx_mode;
         obj68.gxTpr_Productservicename = A59ProductServiceName;
         obj68.gxTpr_Productservicetilename = A266ProductServiceTileName;
         obj68.gxTpr_Productservicedescription = A60ProductServiceDescription;
         obj68.gxTpr_Productserviceclass = A370ProductServiceClass;
         obj68.gxTpr_Productserviceimage = A61ProductServiceImage;
         obj68.gxTpr_Productserviceimage_gxi = A40000ProductServiceImage_GXI;
         obj68.gxTpr_Suppliergenid = A42SupplierGenId;
         obj68.gxTpr_Suppliergencompanyname = A44SupplierGenCompanyName;
         obj68.gxTpr_Supplieragbid = A49SupplierAgbId;
         obj68.gxTpr_Supplieragbname = A51SupplierAgbName;
         obj68.gxTpr_Productservicegroup = A338ProductServiceGroup;
         obj68.gxTpr_Productserviceid = A58ProductServiceId;
         obj68.gxTpr_Locationid = A29LocationId;
         obj68.gxTpr_Organisationid = A11OrganisationId;
         obj68.gxTpr_Productserviceid_Z = Z58ProductServiceId;
         obj68.gxTpr_Locationid_Z = Z29LocationId;
         obj68.gxTpr_Organisationid_Z = Z11OrganisationId;
         obj68.gxTpr_Productservicename_Z = Z59ProductServiceName;
         obj68.gxTpr_Productservicetilename_Z = Z266ProductServiceTileName;
         obj68.gxTpr_Productserviceclass_Z = Z370ProductServiceClass;
         obj68.gxTpr_Productservicegroup_Z = Z338ProductServiceGroup;
         obj68.gxTpr_Suppliergenid_Z = Z42SupplierGenId;
         obj68.gxTpr_Suppliergencompanyname_Z = Z44SupplierGenCompanyName;
         obj68.gxTpr_Supplieragbid_Z = Z49SupplierAgbId;
         obj68.gxTpr_Supplieragbname_Z = Z51SupplierAgbName;
         obj68.gxTpr_Productserviceimage_gxi_Z = Z40000ProductServiceImage_GXI;
         obj68.gxTpr_Productserviceid_N = (short)(Convert.ToInt16(n58ProductServiceId));
         obj68.gxTpr_Suppliergenid_N = (short)(Convert.ToInt16(n42SupplierGenId));
         obj68.gxTpr_Supplieragbid_N = (short)(Convert.ToInt16(n49SupplierAgbId));
         obj68.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow68( SdtTrn_ProductService obj68 )
      {
         obj68.gxTpr_Productserviceid = A58ProductServiceId;
         obj68.gxTpr_Locationid = A29LocationId;
         obj68.gxTpr_Organisationid = A11OrganisationId;
         return  ;
      }

      public void RowToVars68( SdtTrn_ProductService obj68 ,
                               int forceLoad )
      {
         Gx_mode = obj68.gxTpr_Mode;
         A59ProductServiceName = obj68.gxTpr_Productservicename;
         A266ProductServiceTileName = obj68.gxTpr_Productservicetilename;
         A60ProductServiceDescription = obj68.gxTpr_Productservicedescription;
         A370ProductServiceClass = obj68.gxTpr_Productserviceclass;
         A61ProductServiceImage = obj68.gxTpr_Productserviceimage;
         A40000ProductServiceImage_GXI = obj68.gxTpr_Productserviceimage_gxi;
         A42SupplierGenId = obj68.gxTpr_Suppliergenid;
         n42SupplierGenId = false;
         A44SupplierGenCompanyName = obj68.gxTpr_Suppliergencompanyname;
         A49SupplierAgbId = obj68.gxTpr_Supplieragbid;
         n49SupplierAgbId = false;
         A51SupplierAgbName = obj68.gxTpr_Supplieragbname;
         A338ProductServiceGroup = obj68.gxTpr_Productservicegroup;
         A58ProductServiceId = obj68.gxTpr_Productserviceid;
         n58ProductServiceId = false;
         A29LocationId = obj68.gxTpr_Locationid;
         A11OrganisationId = obj68.gxTpr_Organisationid;
         Z58ProductServiceId = obj68.gxTpr_Productserviceid_Z;
         Z29LocationId = obj68.gxTpr_Locationid_Z;
         Z11OrganisationId = obj68.gxTpr_Organisationid_Z;
         Z59ProductServiceName = obj68.gxTpr_Productservicename_Z;
         Z266ProductServiceTileName = obj68.gxTpr_Productservicetilename_Z;
         Z370ProductServiceClass = obj68.gxTpr_Productserviceclass_Z;
         Z338ProductServiceGroup = obj68.gxTpr_Productservicegroup_Z;
         Z42SupplierGenId = obj68.gxTpr_Suppliergenid_Z;
         Z44SupplierGenCompanyName = obj68.gxTpr_Suppliergencompanyname_Z;
         Z49SupplierAgbId = obj68.gxTpr_Supplieragbid_Z;
         Z51SupplierAgbName = obj68.gxTpr_Supplieragbname_Z;
         Z40000ProductServiceImage_GXI = obj68.gxTpr_Productserviceimage_gxi_Z;
         n58ProductServiceId = (bool)(Convert.ToBoolean(obj68.gxTpr_Productserviceid_N));
         n42SupplierGenId = (bool)(Convert.ToBoolean(obj68.gxTpr_Suppliergenid_N));
         n49SupplierAgbId = (bool)(Convert.ToBoolean(obj68.gxTpr_Supplieragbid_N));
         Gx_mode = obj68.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A58ProductServiceId = (Guid)getParm(obj,0);
         n58ProductServiceId = false;
         A29LocationId = (Guid)getParm(obj,1);
         A11OrganisationId = (Guid)getParm(obj,2);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0868( ) ;
         ScanKeyStart0868( ) ;
         if ( RcdFound68 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000818 */
            pr_default.execute(16, new Object[] {A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(16) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(16);
         }
         else
         {
            Gx_mode = "UPD";
            Z58ProductServiceId = A58ProductServiceId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM0868( -15) ;
         OnLoadActions0868( ) ;
         AddRow0868( ) ;
         ScanKeyEnd0868( ) ;
         if ( RcdFound68 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars68( bcTrn_ProductService, 0) ;
         ScanKeyStart0868( ) ;
         if ( RcdFound68 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000818 */
            pr_default.execute(16, new Object[] {A29LocationId, A11OrganisationId});
            if ( (pr_default.getStatus(16) == 101) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Locations", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "ORGANISATIONID");
               AnyError = 1;
            }
            pr_default.close(16);
         }
         else
         {
            Gx_mode = "UPD";
            Z58ProductServiceId = A58ProductServiceId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
         }
         ZM0868( -15) ;
         OnLoadActions0868( ) ;
         AddRow0868( ) ;
         ScanKeyEnd0868( ) ;
         if ( RcdFound68 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0868( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0868( ) ;
         }
         else
         {
            if ( RcdFound68 == 1 )
            {
               if ( ( A58ProductServiceId != Z58ProductServiceId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
               {
                  A58ProductServiceId = Z58ProductServiceId;
                  n58ProductServiceId = false;
                  A29LocationId = Z29LocationId;
                  A11OrganisationId = Z11OrganisationId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0868( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( ( A58ProductServiceId != Z58ProductServiceId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0868( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0868( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars68( bcTrn_ProductService, 1) ;
         SaveImpl( ) ;
         VarsToRow68( bcTrn_ProductService) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars68( bcTrn_ProductService, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0868( ) ;
         AfterTrn( ) ;
         VarsToRow68( bcTrn_ProductService) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow68( bcTrn_ProductService) ;
         }
         else
         {
            SdtTrn_ProductService auxBC = new SdtTrn_ProductService(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A58ProductServiceId, A29LocationId, A11OrganisationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_ProductService);
               auxBC.Save();
               bcTrn_ProductService.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars68( bcTrn_ProductService, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars68( bcTrn_ProductService, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0868( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow68( bcTrn_ProductService) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow68( bcTrn_ProductService) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars68( bcTrn_ProductService, 0) ;
         GetKey0868( ) ;
         if ( RcdFound68 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A58ProductServiceId != Z58ProductServiceId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
            {
               A58ProductServiceId = Z58ProductServiceId;
               n58ProductServiceId = false;
               A29LocationId = Z29LocationId;
               A11OrganisationId = Z11OrganisationId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( ( A58ProductServiceId != Z58ProductServiceId ) || ( A29LocationId != Z29LocationId ) || ( A11OrganisationId != Z11OrganisationId ) )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("trn_productservice_bc",pr_default);
         VarsToRow68( bcTrn_ProductService) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcTrn_ProductService.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_ProductService.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_ProductService )
         {
            bcTrn_ProductService = (SdtTrn_ProductService)(sdt);
            if ( StringUtil.StrCmp(bcTrn_ProductService.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ProductService.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow68( bcTrn_ProductService) ;
            }
            else
            {
               RowToVars68( bcTrn_ProductService, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_ProductService.gxTpr_Mode, "") == 0 )
            {
               bcTrn_ProductService.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars68( bcTrn_ProductService, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_ProductService Trn_ProductService_BC
      {
         get {
            return bcTrn_ProductService ;
         }

      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "trn_productservice_Execute" ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(16);
         pr_default.close(11);
         pr_default.close(12);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z58ProductServiceId = Guid.Empty;
         A58ProductServiceId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         AV41PreferredGenSuppliers = new GxSimpleCollection<Guid>();
         GXt_objcol_guid1 = new GxSimpleCollection<Guid>();
         AV67UploadedFiles = new GXBaseCollection<SdtSDT_FileUploadData>( context, "SDT_FileUploadData", "Comforta_version2");
         AV19WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV16TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV18WebSession = context.GetSession();
         AV71Pgmname = "";
         AV17TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV10Insert_SupplierGenId = Guid.Empty;
         AV9Insert_SupplierAgbId = Guid.Empty;
         AV61RoleName = "";
         AV63SDT_NotificationMetadata = new SdtSDT_NotificationMetadata(context);
         AV64WWPNotificationMetadataSDT = new SdtUSDTNotificationMetadata(context);
         AV62NotificationDescription = "";
         A59ProductServiceName = "";
         AV55NotificationLink = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         GXt_char2 = "";
         A338ProductServiceGroup = "";
         AV26ComboSupplierGenId = Guid.Empty;
         AV30ComboSupplierAgbId = Guid.Empty;
         Z59ProductServiceName = "";
         Z266ProductServiceTileName = "";
         A266ProductServiceTileName = "";
         Z370ProductServiceClass = "";
         A370ProductServiceClass = "";
         Z338ProductServiceGroup = "";
         Z42SupplierGenId = Guid.Empty;
         A42SupplierGenId = Guid.Empty;
         Z49SupplierAgbId = Guid.Empty;
         A49SupplierAgbId = Guid.Empty;
         Z44SupplierGenCompanyName = "";
         A44SupplierGenCompanyName = "";
         Z51SupplierAgbName = "";
         A51SupplierAgbName = "";
         Z60ProductServiceDescription = "";
         A60ProductServiceDescription = "";
         Z61ProductServiceImage = "";
         A61ProductServiceImage = "";
         Z40000ProductServiceImage_GXI = "";
         A40000ProductServiceImage_GXI = "";
         BC00087_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00087_n58ProductServiceId = new bool[] {false} ;
         BC00087_A59ProductServiceName = new string[] {""} ;
         BC00087_A266ProductServiceTileName = new string[] {""} ;
         BC00087_A60ProductServiceDescription = new string[] {""} ;
         BC00087_A370ProductServiceClass = new string[] {""} ;
         BC00087_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC00087_A338ProductServiceGroup = new string[] {""} ;
         BC00087_A44SupplierGenCompanyName = new string[] {""} ;
         BC00087_A51SupplierAgbName = new string[] {""} ;
         BC00087_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00087_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00087_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC00087_n42SupplierGenId = new bool[] {false} ;
         BC00087_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         BC00087_n49SupplierAgbId = new bool[] {false} ;
         BC00087_A61ProductServiceImage = new string[] {""} ;
         BC00084_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00085_A44SupplierGenCompanyName = new string[] {""} ;
         BC00086_A51SupplierAgbName = new string[] {""} ;
         BC00088_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00088_n58ProductServiceId = new bool[] {false} ;
         BC00088_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00088_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00083_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00083_n58ProductServiceId = new bool[] {false} ;
         BC00083_A59ProductServiceName = new string[] {""} ;
         BC00083_A266ProductServiceTileName = new string[] {""} ;
         BC00083_A60ProductServiceDescription = new string[] {""} ;
         BC00083_A370ProductServiceClass = new string[] {""} ;
         BC00083_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC00083_A338ProductServiceGroup = new string[] {""} ;
         BC00083_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00083_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00083_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC00083_n42SupplierGenId = new bool[] {false} ;
         BC00083_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         BC00083_n49SupplierAgbId = new bool[] {false} ;
         BC00083_A61ProductServiceImage = new string[] {""} ;
         sMode68 = "";
         BC00082_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC00082_n58ProductServiceId = new bool[] {false} ;
         BC00082_A59ProductServiceName = new string[] {""} ;
         BC00082_A266ProductServiceTileName = new string[] {""} ;
         BC00082_A60ProductServiceDescription = new string[] {""} ;
         BC00082_A370ProductServiceClass = new string[] {""} ;
         BC00082_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC00082_A338ProductServiceGroup = new string[] {""} ;
         BC00082_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00082_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC00082_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC00082_n42SupplierGenId = new bool[] {false} ;
         BC00082_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         BC00082_n49SupplierAgbId = new bool[] {false} ;
         BC00082_A61ProductServiceImage = new string[] {""} ;
         BC000813_A44SupplierGenCompanyName = new string[] {""} ;
         BC000814_A51SupplierAgbName = new string[] {""} ;
         BC000815_A392Trn_PageId = new Guid[] {Guid.Empty} ;
         BC000815_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000816_A339CallToActionId = new Guid[] {Guid.Empty} ;
         AV66SDT_TrnAttributes = new SdtSDT_TrnAttributes(context);
         BC000817_A58ProductServiceId = new Guid[] {Guid.Empty} ;
         BC000817_n58ProductServiceId = new bool[] {false} ;
         BC000817_A59ProductServiceName = new string[] {""} ;
         BC000817_A266ProductServiceTileName = new string[] {""} ;
         BC000817_A60ProductServiceDescription = new string[] {""} ;
         BC000817_A370ProductServiceClass = new string[] {""} ;
         BC000817_A40000ProductServiceImage_GXI = new string[] {""} ;
         BC000817_A338ProductServiceGroup = new string[] {""} ;
         BC000817_A44SupplierGenCompanyName = new string[] {""} ;
         BC000817_A51SupplierAgbName = new string[] {""} ;
         BC000817_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000817_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000817_A42SupplierGenId = new Guid[] {Guid.Empty} ;
         BC000817_n42SupplierGenId = new bool[] {false} ;
         BC000817_A49SupplierAgbId = new Guid[] {Guid.Empty} ;
         BC000817_n49SupplierAgbId = new bool[] {false} ;
         BC000817_A61ProductServiceImage = new string[] {""} ;
         GXt_SdtSDT_TrnAttributes4 = new SdtSDT_TrnAttributes(context);
         i338ProductServiceGroup = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC000818_A29LocationId = new Guid[] {Guid.Empty} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_productservice_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_productservice_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_productservice_bc__default(),
            new Object[][] {
                new Object[] {
               BC00082_A58ProductServiceId, BC00082_A59ProductServiceName, BC00082_A266ProductServiceTileName, BC00082_A60ProductServiceDescription, BC00082_A370ProductServiceClass, BC00082_A40000ProductServiceImage_GXI, BC00082_A338ProductServiceGroup, BC00082_A29LocationId, BC00082_A11OrganisationId, BC00082_A42SupplierGenId,
               BC00082_n42SupplierGenId, BC00082_A49SupplierAgbId, BC00082_n49SupplierAgbId, BC00082_A61ProductServiceImage
               }
               , new Object[] {
               BC00083_A58ProductServiceId, BC00083_A59ProductServiceName, BC00083_A266ProductServiceTileName, BC00083_A60ProductServiceDescription, BC00083_A370ProductServiceClass, BC00083_A40000ProductServiceImage_GXI, BC00083_A338ProductServiceGroup, BC00083_A29LocationId, BC00083_A11OrganisationId, BC00083_A42SupplierGenId,
               BC00083_n42SupplierGenId, BC00083_A49SupplierAgbId, BC00083_n49SupplierAgbId, BC00083_A61ProductServiceImage
               }
               , new Object[] {
               BC00084_A29LocationId
               }
               , new Object[] {
               BC00085_A44SupplierGenCompanyName
               }
               , new Object[] {
               BC00086_A51SupplierAgbName
               }
               , new Object[] {
               BC00087_A58ProductServiceId, BC00087_A59ProductServiceName, BC00087_A266ProductServiceTileName, BC00087_A60ProductServiceDescription, BC00087_A370ProductServiceClass, BC00087_A40000ProductServiceImage_GXI, BC00087_A338ProductServiceGroup, BC00087_A44SupplierGenCompanyName, BC00087_A51SupplierAgbName, BC00087_A29LocationId,
               BC00087_A11OrganisationId, BC00087_A42SupplierGenId, BC00087_n42SupplierGenId, BC00087_A49SupplierAgbId, BC00087_n49SupplierAgbId, BC00087_A61ProductServiceImage
               }
               , new Object[] {
               BC00088_A58ProductServiceId, BC00088_A29LocationId, BC00088_A11OrganisationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000813_A44SupplierGenCompanyName
               }
               , new Object[] {
               BC000814_A51SupplierAgbName
               }
               , new Object[] {
               BC000815_A392Trn_PageId, BC000815_A29LocationId
               }
               , new Object[] {
               BC000816_A339CallToActionId
               }
               , new Object[] {
               BC000817_A58ProductServiceId, BC000817_A59ProductServiceName, BC000817_A266ProductServiceTileName, BC000817_A60ProductServiceDescription, BC000817_A370ProductServiceClass, BC000817_A40000ProductServiceImage_GXI, BC000817_A338ProductServiceGroup, BC000817_A44SupplierGenCompanyName, BC000817_A51SupplierAgbName, BC000817_A29LocationId,
               BC000817_A11OrganisationId, BC000817_A42SupplierGenId, BC000817_n42SupplierGenId, BC000817_A49SupplierAgbId, BC000817_n49SupplierAgbId, BC000817_A61ProductServiceImage
               }
               , new Object[] {
               BC000818_A29LocationId
               }
            }
         );
         Z58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         A58ProductServiceId = Guid.NewGuid( );
         n58ProductServiceId = false;
         AV71Pgmname = "Trn_ProductService_BC";
         A338ProductServiceGroup = "Location";
         Z338ProductServiceGroup = "Location";
         i338ProductServiceGroup = "Location";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12082 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound68 ;
      private int trnEnded ;
      private int AV72GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV71Pgmname ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string Z266ProductServiceTileName ;
      private string A266ProductServiceTileName ;
      private string sMode68 ;
      private bool returnInSub ;
      private bool AV57isManager ;
      private bool AV53IsWeb ;
      private bool AV42ListAgb ;
      private bool AV52ListAgbPre ;
      private bool n58ProductServiceId ;
      private bool n42SupplierGenId ;
      private bool n49SupplierAgbId ;
      private bool Gx_longc ;
      private string Z60ProductServiceDescription ;
      private string A60ProductServiceDescription ;
      private string AV61RoleName ;
      private string AV62NotificationDescription ;
      private string A59ProductServiceName ;
      private string AV55NotificationLink ;
      private string A338ProductServiceGroup ;
      private string Z59ProductServiceName ;
      private string Z370ProductServiceClass ;
      private string A370ProductServiceClass ;
      private string Z338ProductServiceGroup ;
      private string Z44SupplierGenCompanyName ;
      private string A44SupplierGenCompanyName ;
      private string Z51SupplierAgbName ;
      private string A51SupplierAgbName ;
      private string Z40000ProductServiceImage_GXI ;
      private string A40000ProductServiceImage_GXI ;
      private string i338ProductServiceGroup ;
      private string Z61ProductServiceImage ;
      private string A61ProductServiceImage ;
      private Guid Z58ProductServiceId ;
      private Guid A58ProductServiceId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private Guid AV10Insert_SupplierGenId ;
      private Guid AV9Insert_SupplierAgbId ;
      private Guid AV26ComboSupplierGenId ;
      private Guid AV30ComboSupplierAgbId ;
      private Guid Z42SupplierGenId ;
      private Guid A42SupplierGenId ;
      private Guid Z49SupplierAgbId ;
      private Guid A49SupplierAgbId ;
      private IGxSession AV18WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<Guid> AV41PreferredGenSuppliers ;
      private GxSimpleCollection<Guid> GXt_objcol_guid1 ;
      private GXBaseCollection<SdtSDT_FileUploadData> AV67UploadedFiles ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV19WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV16TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV17TrnContextAtt ;
      private SdtSDT_NotificationMetadata AV63SDT_NotificationMetadata ;
      private SdtUSDTNotificationMetadata AV64WWPNotificationMetadataSDT ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00087_A58ProductServiceId ;
      private bool[] BC00087_n58ProductServiceId ;
      private string[] BC00087_A59ProductServiceName ;
      private string[] BC00087_A266ProductServiceTileName ;
      private string[] BC00087_A60ProductServiceDescription ;
      private string[] BC00087_A370ProductServiceClass ;
      private string[] BC00087_A40000ProductServiceImage_GXI ;
      private string[] BC00087_A338ProductServiceGroup ;
      private string[] BC00087_A44SupplierGenCompanyName ;
      private string[] BC00087_A51SupplierAgbName ;
      private Guid[] BC00087_A29LocationId ;
      private Guid[] BC00087_A11OrganisationId ;
      private Guid[] BC00087_A42SupplierGenId ;
      private bool[] BC00087_n42SupplierGenId ;
      private Guid[] BC00087_A49SupplierAgbId ;
      private bool[] BC00087_n49SupplierAgbId ;
      private string[] BC00087_A61ProductServiceImage ;
      private Guid[] BC00084_A29LocationId ;
      private string[] BC00085_A44SupplierGenCompanyName ;
      private string[] BC00086_A51SupplierAgbName ;
      private Guid[] BC00088_A58ProductServiceId ;
      private bool[] BC00088_n58ProductServiceId ;
      private Guid[] BC00088_A29LocationId ;
      private Guid[] BC00088_A11OrganisationId ;
      private Guid[] BC00083_A58ProductServiceId ;
      private bool[] BC00083_n58ProductServiceId ;
      private string[] BC00083_A59ProductServiceName ;
      private string[] BC00083_A266ProductServiceTileName ;
      private string[] BC00083_A60ProductServiceDescription ;
      private string[] BC00083_A370ProductServiceClass ;
      private string[] BC00083_A40000ProductServiceImage_GXI ;
      private string[] BC00083_A338ProductServiceGroup ;
      private Guid[] BC00083_A29LocationId ;
      private Guid[] BC00083_A11OrganisationId ;
      private Guid[] BC00083_A42SupplierGenId ;
      private bool[] BC00083_n42SupplierGenId ;
      private Guid[] BC00083_A49SupplierAgbId ;
      private bool[] BC00083_n49SupplierAgbId ;
      private string[] BC00083_A61ProductServiceImage ;
      private Guid[] BC00082_A58ProductServiceId ;
      private bool[] BC00082_n58ProductServiceId ;
      private string[] BC00082_A59ProductServiceName ;
      private string[] BC00082_A266ProductServiceTileName ;
      private string[] BC00082_A60ProductServiceDescription ;
      private string[] BC00082_A370ProductServiceClass ;
      private string[] BC00082_A40000ProductServiceImage_GXI ;
      private string[] BC00082_A338ProductServiceGroup ;
      private Guid[] BC00082_A29LocationId ;
      private Guid[] BC00082_A11OrganisationId ;
      private Guid[] BC00082_A42SupplierGenId ;
      private bool[] BC00082_n42SupplierGenId ;
      private Guid[] BC00082_A49SupplierAgbId ;
      private bool[] BC00082_n49SupplierAgbId ;
      private string[] BC00082_A61ProductServiceImage ;
      private string[] BC000813_A44SupplierGenCompanyName ;
      private string[] BC000814_A51SupplierAgbName ;
      private Guid[] BC000815_A392Trn_PageId ;
      private Guid[] BC000815_A29LocationId ;
      private Guid[] BC000816_A339CallToActionId ;
      private SdtSDT_TrnAttributes AV66SDT_TrnAttributes ;
      private Guid[] BC000817_A58ProductServiceId ;
      private bool[] BC000817_n58ProductServiceId ;
      private string[] BC000817_A59ProductServiceName ;
      private string[] BC000817_A266ProductServiceTileName ;
      private string[] BC000817_A60ProductServiceDescription ;
      private string[] BC000817_A370ProductServiceClass ;
      private string[] BC000817_A40000ProductServiceImage_GXI ;
      private string[] BC000817_A338ProductServiceGroup ;
      private string[] BC000817_A44SupplierGenCompanyName ;
      private string[] BC000817_A51SupplierAgbName ;
      private Guid[] BC000817_A29LocationId ;
      private Guid[] BC000817_A11OrganisationId ;
      private Guid[] BC000817_A42SupplierGenId ;
      private bool[] BC000817_n42SupplierGenId ;
      private Guid[] BC000817_A49SupplierAgbId ;
      private bool[] BC000817_n49SupplierAgbId ;
      private string[] BC000817_A61ProductServiceImage ;
      private SdtSDT_TrnAttributes GXt_SdtSDT_TrnAttributes4 ;
      private SdtTrn_ProductService bcTrn_ProductService ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC000818_A29LocationId ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_productservice_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class trn_productservice_bc__gam : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "GAM";
  }

}

public class trn_productservice_bc__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new ForEachCursor(def[4])
      ,new ForEachCursor(def[5])
      ,new ForEachCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00082;
       prmBC00082 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00083;
       prmBC00083 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00084;
       prmBC00084 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00085;
       prmBC00085 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00086;
       prmBC00086 = new Object[] {
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC00087;
       prmBC00087 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00088;
       prmBC00088 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00089;
       prmBC00089 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ProductServiceName",GXType.VarChar,100,0) ,
       new ParDef("ProductServiceTileName",GXType.Char,20,0) ,
       new ParDef("ProductServiceDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("ProductServiceClass",GXType.VarChar,400,0) ,
       new ParDef("ProductServiceImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("ProductServiceImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=5, Tbl="Trn_ProductService", Fld="ProductServiceImage"} ,
       new ParDef("ProductServiceGroup",GXType.VarChar,400,0) ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000810;
       prmBC000810 = new Object[] {
       new ParDef("ProductServiceName",GXType.VarChar,100,0) ,
       new ParDef("ProductServiceTileName",GXType.Char,20,0) ,
       new ParDef("ProductServiceDescription",GXType.LongVarChar,2097152,0) ,
       new ParDef("ProductServiceClass",GXType.VarChar,400,0) ,
       new ParDef("ProductServiceGroup",GXType.VarChar,400,0) ,
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000811;
       prmBC000811 = new Object[] {
       new ParDef("ProductServiceImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("ProductServiceImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_ProductService", Fld="ProductServiceImage"} ,
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000812;
       prmBC000812 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000813;
       prmBC000813 = new Object[] {
       new ParDef("SupplierGenId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000814;
       prmBC000814 = new Object[] {
       new ParDef("SupplierAgbId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000815;
       prmBC000815 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000816;
       prmBC000816 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000817;
       prmBC000817 = new Object[] {
       new ParDef("ProductServiceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000818;
       prmBC000818 = new Object[] {
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00082", "SELECT ProductServiceId, ProductServiceName, ProductServiceTileName, ProductServiceDescription, ProductServiceClass, ProductServiceImage_GXI, ProductServiceGroup, LocationId, OrganisationId, SupplierGenId, SupplierAgbId, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId  FOR UPDATE OF Trn_ProductService",true, GxErrorMask.GX_NOMASK, false, this,prmBC00082,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00083", "SELECT ProductServiceId, ProductServiceName, ProductServiceTileName, ProductServiceDescription, ProductServiceClass, ProductServiceImage_GXI, ProductServiceGroup, LocationId, OrganisationId, SupplierGenId, SupplierAgbId, ProductServiceImage FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00083,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00084", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00084,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00085", "SELECT SupplierGenCompanyName FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00085,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00086", "SELECT SupplierAgbName FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00086,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00087", "SELECT TM1.ProductServiceId, TM1.ProductServiceName, TM1.ProductServiceTileName, TM1.ProductServiceDescription, TM1.ProductServiceClass, TM1.ProductServiceImage_GXI, TM1.ProductServiceGroup, T2.SupplierGenCompanyName, T3.SupplierAgbName, TM1.LocationId, TM1.OrganisationId, TM1.SupplierGenId, TM1.SupplierAgbId, TM1.ProductServiceImage FROM ((Trn_ProductService TM1 LEFT JOIN Trn_SupplierGen T2 ON T2.SupplierGenId = TM1.SupplierGenId) LEFT JOIN Trn_SupplierAGB T3 ON T3.SupplierAgbId = TM1.SupplierAgbId) WHERE TM1.ProductServiceId = :ProductServiceId and TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.ProductServiceId, TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00087,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00088", "SELECT ProductServiceId, LocationId, OrganisationId FROM Trn_ProductService WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00088,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00089", "SAVEPOINT gxupdate;INSERT INTO Trn_ProductService(ProductServiceId, ProductServiceName, ProductServiceTileName, ProductServiceDescription, ProductServiceClass, ProductServiceImage, ProductServiceImage_GXI, ProductServiceGroup, LocationId, OrganisationId, SupplierGenId, SupplierAgbId) VALUES(:ProductServiceId, :ProductServiceName, :ProductServiceTileName, :ProductServiceDescription, :ProductServiceClass, :ProductServiceImage, :ProductServiceImage_GXI, :ProductServiceGroup, :LocationId, :OrganisationId, :SupplierGenId, :SupplierAgbId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00089)
          ,new CursorDef("BC000810", "SAVEPOINT gxupdate;UPDATE Trn_ProductService SET ProductServiceName=:ProductServiceName, ProductServiceTileName=:ProductServiceTileName, ProductServiceDescription=:ProductServiceDescription, ProductServiceClass=:ProductServiceClass, ProductServiceGroup=:ProductServiceGroup, SupplierGenId=:SupplierGenId, SupplierAgbId=:SupplierAgbId  WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000810)
          ,new CursorDef("BC000811", "SAVEPOINT gxupdate;UPDATE Trn_ProductService SET ProductServiceImage=:ProductServiceImage, ProductServiceImage_GXI=:ProductServiceImage_GXI  WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000811)
          ,new CursorDef("BC000812", "SAVEPOINT gxupdate;DELETE FROM Trn_ProductService  WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000812)
          ,new CursorDef("BC000813", "SELECT SupplierGenCompanyName FROM Trn_SupplierGen WHERE SupplierGenId = :SupplierGenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000813,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000814", "SELECT SupplierAgbName FROM Trn_SupplierAGB WHERE SupplierAgbId = :SupplierAgbId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000814,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000815", "SELECT Trn_PageId, LocationId FROM Trn_Page WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000815,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000816", "SELECT CallToActionId FROM Trn_CallToAction WHERE ProductServiceId = :ProductServiceId AND LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000816,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000817", "SELECT TM1.ProductServiceId, TM1.ProductServiceName, TM1.ProductServiceTileName, TM1.ProductServiceDescription, TM1.ProductServiceClass, TM1.ProductServiceImage_GXI, TM1.ProductServiceGroup, T2.SupplierGenCompanyName, T3.SupplierAgbName, TM1.LocationId, TM1.OrganisationId, TM1.SupplierGenId, TM1.SupplierAgbId, TM1.ProductServiceImage FROM ((Trn_ProductService TM1 LEFT JOIN Trn_SupplierGen T2 ON T2.SupplierGenId = TM1.SupplierGenId) LEFT JOIN Trn_SupplierAGB T3 ON T3.SupplierAgbId = TM1.SupplierAgbId) WHERE TM1.ProductServiceId = :ProductServiceId and TM1.LocationId = :LocationId and TM1.OrganisationId = :OrganisationId ORDER BY TM1.ProductServiceId, TM1.LocationId, TM1.OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000817,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000818", "SELECT LocationId FROM Trn_Location WHERE LocationId = :LocationId AND OrganisationId = :OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000818,1, GxCacheFrequency.OFF ,true,false )
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
    switch ( cursor )
    {
          case 0 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((Guid[]) buf[7])[0] = rslt.getGuid(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((Guid[]) buf[11])[0] = rslt.getGuid(11);
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(6));
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((Guid[]) buf[7])[0] = rslt.getGuid(8);
             ((Guid[]) buf[8])[0] = rslt.getGuid(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((bool[]) buf[10])[0] = rslt.wasNull(10);
             ((Guid[]) buf[11])[0] = rslt.getGuid(11);
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(12, rslt.getVarchar(6));
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((Guid[]) buf[10])[0] = rslt.getGuid(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             ((Guid[]) buf[13])[0] = rslt.getGuid(13);
             ((bool[]) buf[14])[0] = rslt.wasNull(13);
             ((string[]) buf[15])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(6));
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 11 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 12 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             return;
          case 14 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 15 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((string[]) buf[8])[0] = rslt.getVarchar(9);
             ((Guid[]) buf[9])[0] = rslt.getGuid(10);
             ((Guid[]) buf[10])[0] = rslt.getGuid(11);
             ((Guid[]) buf[11])[0] = rslt.getGuid(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             ((Guid[]) buf[13])[0] = rslt.getGuid(13);
             ((bool[]) buf[14])[0] = rslt.wasNull(13);
             ((string[]) buf[15])[0] = rslt.getMultimediaFile(14, rslt.getVarchar(6));
             return;
          case 16 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
