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
   public class trn_media_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_media_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_media_bc( IGxContext context )
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
         ReadRow1076( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1076( ) ;
         standaloneModal( ) ;
         AddRow1076( ) ;
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
            E11102 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z413MediaId = A413MediaId;
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

      protected void CONFIRM_100( )
      {
         BeforeValidate1076( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1076( ) ;
            }
            else
            {
               CheckExtendedTable1076( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1076( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12102( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11102( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1076( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z646CroppedOriginalMediaId = A646CroppedOriginalMediaId;
            Z29LocationId = A29LocationId;
            Z414MediaName = A414MediaName;
            Z417MediaSize = A417MediaSize;
            Z418MediaType = A418MediaType;
            Z618MediaDateTime = A618MediaDateTime;
            Z416MediaUrl = A416MediaUrl;
            Z636IsCropped = A636IsCropped;
         }
         if ( GX_JID == -9 )
         {
            Z413MediaId = A413MediaId;
            Z646CroppedOriginalMediaId = A646CroppedOriginalMediaId;
            Z29LocationId = A29LocationId;
            Z414MediaName = A414MediaName;
            Z415MediaImage = A415MediaImage;
            Z40000MediaImage_GXI = A40000MediaImage_GXI;
            Z417MediaSize = A417MediaSize;
            Z418MediaType = A418MediaType;
            Z618MediaDateTime = A618MediaDateTime;
            Z416MediaUrl = A416MediaUrl;
            Z636IsCropped = A636IsCropped;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A646CroppedOriginalMediaId) )
         {
            A646CroppedOriginalMediaId = Guid.NewGuid( );
            n646CroppedOriginalMediaId = false;
         }
         if ( IsIns( )  && (Guid.Empty==A29LocationId) )
         {
            A29LocationId = Guid.NewGuid( );
         }
         if ( IsIns( )  && (Guid.Empty==A413MediaId) )
         {
            A413MediaId = Guid.NewGuid( );
         }
         if ( IsIns( )  && (DateTime.MinValue==A618MediaDateTime) && ( Gx_BScreen == 0 ) )
         {
            A618MediaDateTime = DateTimeUtil.Now( context);
            n618MediaDateTime = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1076( )
      {
         /* Using cursor BC00104 */
         pr_default.execute(2, new Object[] {A413MediaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound76 = 1;
            A646CroppedOriginalMediaId = BC00104_A646CroppedOriginalMediaId[0];
            n646CroppedOriginalMediaId = BC00104_n646CroppedOriginalMediaId[0];
            A29LocationId = BC00104_A29LocationId[0];
            A414MediaName = BC00104_A414MediaName[0];
            A40000MediaImage_GXI = BC00104_A40000MediaImage_GXI[0];
            n40000MediaImage_GXI = BC00104_n40000MediaImage_GXI[0];
            A417MediaSize = BC00104_A417MediaSize[0];
            A418MediaType = BC00104_A418MediaType[0];
            A618MediaDateTime = BC00104_A618MediaDateTime[0];
            n618MediaDateTime = BC00104_n618MediaDateTime[0];
            A416MediaUrl = BC00104_A416MediaUrl[0];
            A636IsCropped = BC00104_A636IsCropped[0];
            A415MediaImage = BC00104_A415MediaImage[0];
            n415MediaImage = BC00104_n415MediaImage[0];
            ZM1076( -9) ;
         }
         pr_default.close(2);
         OnLoadActions1076( ) ;
      }

      protected void OnLoadActions1076( )
      {
      }

      protected void CheckExtendedTable1076( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A416MediaUrl,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Media Url", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1076( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1076( )
      {
         /* Using cursor BC00105 */
         pr_default.execute(3, new Object[] {A413MediaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound76 = 1;
         }
         else
         {
            RcdFound76 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00103 */
         pr_default.execute(1, new Object[] {A413MediaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1076( 9) ;
            RcdFound76 = 1;
            A413MediaId = BC00103_A413MediaId[0];
            A646CroppedOriginalMediaId = BC00103_A646CroppedOriginalMediaId[0];
            n646CroppedOriginalMediaId = BC00103_n646CroppedOriginalMediaId[0];
            A29LocationId = BC00103_A29LocationId[0];
            A414MediaName = BC00103_A414MediaName[0];
            A40000MediaImage_GXI = BC00103_A40000MediaImage_GXI[0];
            n40000MediaImage_GXI = BC00103_n40000MediaImage_GXI[0];
            A417MediaSize = BC00103_A417MediaSize[0];
            A418MediaType = BC00103_A418MediaType[0];
            A618MediaDateTime = BC00103_A618MediaDateTime[0];
            n618MediaDateTime = BC00103_n618MediaDateTime[0];
            A416MediaUrl = BC00103_A416MediaUrl[0];
            A636IsCropped = BC00103_A636IsCropped[0];
            A415MediaImage = BC00103_A415MediaImage[0];
            n415MediaImage = BC00103_n415MediaImage[0];
            Z413MediaId = A413MediaId;
            sMode76 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1076( ) ;
            if ( AnyError == 1 )
            {
               RcdFound76 = 0;
               InitializeNonKey1076( ) ;
            }
            Gx_mode = sMode76;
         }
         else
         {
            RcdFound76 = 0;
            InitializeNonKey1076( ) ;
            sMode76 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode76;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1076( ) ;
         if ( RcdFound76 == 0 )
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
         CONFIRM_100( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1076( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00102 */
            pr_default.execute(0, new Object[] {A413MediaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Media"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z646CroppedOriginalMediaId != BC00102_A646CroppedOriginalMediaId[0] ) || ( Z29LocationId != BC00102_A29LocationId[0] ) || ( StringUtil.StrCmp(Z414MediaName, BC00102_A414MediaName[0]) != 0 ) || ( Z417MediaSize != BC00102_A417MediaSize[0] ) || ( StringUtil.StrCmp(Z418MediaType, BC00102_A418MediaType[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z618MediaDateTime != BC00102_A618MediaDateTime[0] ) || ( StringUtil.StrCmp(Z416MediaUrl, BC00102_A416MediaUrl[0]) != 0 ) || ( Z636IsCropped != BC00102_A636IsCropped[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Media"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1076( )
      {
         BeforeValidate1076( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1076( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1076( 0) ;
            CheckOptimisticConcurrency1076( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1076( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1076( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00106 */
                     pr_default.execute(4, new Object[] {A413MediaId, n646CroppedOriginalMediaId, A646CroppedOriginalMediaId, A29LocationId, A414MediaName, n415MediaImage, A415MediaImage, n40000MediaImage_GXI, A40000MediaImage_GXI, A417MediaSize, A418MediaType, n618MediaDateTime, A618MediaDateTime, A416MediaUrl, A636IsCropped});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Media");
                     if ( (pr_default.getStatus(4) == 1) )
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
               Load1076( ) ;
            }
            EndLevel1076( ) ;
         }
         CloseExtendedTableCursors1076( ) ;
      }

      protected void Update1076( )
      {
         BeforeValidate1076( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1076( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1076( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1076( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1076( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00107 */
                     pr_default.execute(5, new Object[] {n646CroppedOriginalMediaId, A646CroppedOriginalMediaId, A29LocationId, A414MediaName, A417MediaSize, A418MediaType, n618MediaDateTime, A618MediaDateTime, A416MediaUrl, A636IsCropped, A413MediaId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Media");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Media"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1076( ) ;
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
            EndLevel1076( ) ;
         }
         CloseExtendedTableCursors1076( ) ;
      }

      protected void DeferredUpdate1076( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC00108 */
            pr_default.execute(6, new Object[] {n415MediaImage, A415MediaImage, n40000MediaImage_GXI, A40000MediaImage_GXI, A413MediaId});
            pr_default.close(6);
            pr_default.SmartCacheProvider.SetUpdated("Trn_Media");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1076( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1076( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1076( ) ;
            AfterConfirm1076( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1076( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00109 */
                  pr_default.execute(7, new Object[] {A413MediaId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Media");
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
         sMode76 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1076( ) ;
         Gx_mode = sMode76;
      }

      protected void OnDeleteControls1076( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001010 */
            pr_default.execute(8, new Object[] {A413MediaId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_CroppedMedia", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel1076( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1076( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
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

      public void ScanKeyStart1076( )
      {
         /* Scan By routine */
         /* Using cursor BC001011 */
         pr_default.execute(9, new Object[] {A413MediaId});
         RcdFound76 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound76 = 1;
            A413MediaId = BC001011_A413MediaId[0];
            A646CroppedOriginalMediaId = BC001011_A646CroppedOriginalMediaId[0];
            n646CroppedOriginalMediaId = BC001011_n646CroppedOriginalMediaId[0];
            A29LocationId = BC001011_A29LocationId[0];
            A414MediaName = BC001011_A414MediaName[0];
            A40000MediaImage_GXI = BC001011_A40000MediaImage_GXI[0];
            n40000MediaImage_GXI = BC001011_n40000MediaImage_GXI[0];
            A417MediaSize = BC001011_A417MediaSize[0];
            A418MediaType = BC001011_A418MediaType[0];
            A618MediaDateTime = BC001011_A618MediaDateTime[0];
            n618MediaDateTime = BC001011_n618MediaDateTime[0];
            A416MediaUrl = BC001011_A416MediaUrl[0];
            A636IsCropped = BC001011_A636IsCropped[0];
            A415MediaImage = BC001011_A415MediaImage[0];
            n415MediaImage = BC001011_n415MediaImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1076( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound76 = 0;
         ScanKeyLoad1076( ) ;
      }

      protected void ScanKeyLoad1076( )
      {
         sMode76 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound76 = 1;
            A413MediaId = BC001011_A413MediaId[0];
            A646CroppedOriginalMediaId = BC001011_A646CroppedOriginalMediaId[0];
            n646CroppedOriginalMediaId = BC001011_n646CroppedOriginalMediaId[0];
            A29LocationId = BC001011_A29LocationId[0];
            A414MediaName = BC001011_A414MediaName[0];
            A40000MediaImage_GXI = BC001011_A40000MediaImage_GXI[0];
            n40000MediaImage_GXI = BC001011_n40000MediaImage_GXI[0];
            A417MediaSize = BC001011_A417MediaSize[0];
            A418MediaType = BC001011_A418MediaType[0];
            A618MediaDateTime = BC001011_A618MediaDateTime[0];
            n618MediaDateTime = BC001011_n618MediaDateTime[0];
            A416MediaUrl = BC001011_A416MediaUrl[0];
            A636IsCropped = BC001011_A636IsCropped[0];
            A415MediaImage = BC001011_A415MediaImage[0];
            n415MediaImage = BC001011_n415MediaImage[0];
         }
         Gx_mode = sMode76;
      }

      protected void ScanKeyEnd1076( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1076( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1076( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1076( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1076( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1076( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1076( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1076( )
      {
      }

      protected void send_integrity_lvl_hashes1076( )
      {
      }

      protected void AddRow1076( )
      {
         VarsToRow76( bcTrn_Media) ;
      }

      protected void ReadRow1076( )
      {
         RowToVars76( bcTrn_Media, 1) ;
      }

      protected void InitializeNonKey1076( )
      {
         A414MediaName = "";
         A415MediaImage = "";
         n415MediaImage = false;
         A40000MediaImage_GXI = "";
         n40000MediaImage_GXI = false;
         A417MediaSize = 0;
         A418MediaType = "";
         A416MediaUrl = "";
         A636IsCropped = false;
         A646CroppedOriginalMediaId = Guid.NewGuid( );
         n646CroppedOriginalMediaId = false;
         A29LocationId = Guid.NewGuid( );
         A618MediaDateTime = DateTimeUtil.Now( context);
         n618MediaDateTime = false;
         Z646CroppedOriginalMediaId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         Z414MediaName = "";
         Z417MediaSize = 0;
         Z418MediaType = "";
         Z618MediaDateTime = (DateTime)(DateTime.MinValue);
         Z416MediaUrl = "";
         Z636IsCropped = false;
      }

      protected void InitAll1076( )
      {
         A413MediaId = Guid.NewGuid( );
         InitializeNonKey1076( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A646CroppedOriginalMediaId = i646CroppedOriginalMediaId;
         n646CroppedOriginalMediaId = false;
         A29LocationId = i29LocationId;
         A618MediaDateTime = i618MediaDateTime;
         n618MediaDateTime = false;
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

      public void VarsToRow76( SdtTrn_Media obj76 )
      {
         obj76.gxTpr_Mode = Gx_mode;
         obj76.gxTpr_Medianame = A414MediaName;
         obj76.gxTpr_Mediaimage = A415MediaImage;
         obj76.gxTpr_Mediaimage_gxi = A40000MediaImage_GXI;
         obj76.gxTpr_Mediasize = A417MediaSize;
         obj76.gxTpr_Mediatype = A418MediaType;
         obj76.gxTpr_Mediaurl = A416MediaUrl;
         obj76.gxTpr_Iscropped = A636IsCropped;
         obj76.gxTpr_Croppedoriginalmediaid = A646CroppedOriginalMediaId;
         obj76.gxTpr_Locationid = A29LocationId;
         obj76.gxTpr_Mediadatetime = A618MediaDateTime;
         obj76.gxTpr_Mediaid = A413MediaId;
         obj76.gxTpr_Mediaid_Z = Z413MediaId;
         obj76.gxTpr_Medianame_Z = Z414MediaName;
         obj76.gxTpr_Mediasize_Z = Z417MediaSize;
         obj76.gxTpr_Mediatype_Z = Z418MediaType;
         obj76.gxTpr_Mediadatetime_Z = Z618MediaDateTime;
         obj76.gxTpr_Mediaurl_Z = Z416MediaUrl;
         obj76.gxTpr_Locationid_Z = Z29LocationId;
         obj76.gxTpr_Iscropped_Z = Z636IsCropped;
         obj76.gxTpr_Croppedoriginalmediaid_Z = Z646CroppedOriginalMediaId;
         obj76.gxTpr_Mediaimage_gxi_Z = Z40000MediaImage_GXI;
         obj76.gxTpr_Mediaimage_N = (short)(Convert.ToInt16(n415MediaImage));
         obj76.gxTpr_Mediadatetime_N = (short)(Convert.ToInt16(n618MediaDateTime));
         obj76.gxTpr_Croppedoriginalmediaid_N = (short)(Convert.ToInt16(n646CroppedOriginalMediaId));
         obj76.gxTpr_Mediaimage_gxi_N = (short)(Convert.ToInt16(n40000MediaImage_GXI));
         obj76.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow76( SdtTrn_Media obj76 )
      {
         obj76.gxTpr_Mediaid = A413MediaId;
         return  ;
      }

      public void RowToVars76( SdtTrn_Media obj76 ,
                               int forceLoad )
      {
         Gx_mode = obj76.gxTpr_Mode;
         A414MediaName = obj76.gxTpr_Medianame;
         A415MediaImage = obj76.gxTpr_Mediaimage;
         n415MediaImage = false;
         A40000MediaImage_GXI = obj76.gxTpr_Mediaimage_gxi;
         n40000MediaImage_GXI = false;
         A417MediaSize = obj76.gxTpr_Mediasize;
         A418MediaType = obj76.gxTpr_Mediatype;
         A416MediaUrl = obj76.gxTpr_Mediaurl;
         A636IsCropped = obj76.gxTpr_Iscropped;
         A646CroppedOriginalMediaId = obj76.gxTpr_Croppedoriginalmediaid;
         n646CroppedOriginalMediaId = false;
         A29LocationId = obj76.gxTpr_Locationid;
         A618MediaDateTime = obj76.gxTpr_Mediadatetime;
         n618MediaDateTime = false;
         A413MediaId = obj76.gxTpr_Mediaid;
         Z413MediaId = obj76.gxTpr_Mediaid_Z;
         Z414MediaName = obj76.gxTpr_Medianame_Z;
         Z417MediaSize = obj76.gxTpr_Mediasize_Z;
         Z418MediaType = obj76.gxTpr_Mediatype_Z;
         Z618MediaDateTime = obj76.gxTpr_Mediadatetime_Z;
         Z416MediaUrl = obj76.gxTpr_Mediaurl_Z;
         Z29LocationId = obj76.gxTpr_Locationid_Z;
         Z636IsCropped = obj76.gxTpr_Iscropped_Z;
         Z646CroppedOriginalMediaId = obj76.gxTpr_Croppedoriginalmediaid_Z;
         Z40000MediaImage_GXI = obj76.gxTpr_Mediaimage_gxi_Z;
         n415MediaImage = (bool)(Convert.ToBoolean(obj76.gxTpr_Mediaimage_N));
         n618MediaDateTime = (bool)(Convert.ToBoolean(obj76.gxTpr_Mediadatetime_N));
         n646CroppedOriginalMediaId = (bool)(Convert.ToBoolean(obj76.gxTpr_Croppedoriginalmediaid_N));
         n40000MediaImage_GXI = (bool)(Convert.ToBoolean(obj76.gxTpr_Mediaimage_gxi_N));
         Gx_mode = obj76.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A413MediaId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1076( ) ;
         ScanKeyStart1076( ) ;
         if ( RcdFound76 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z413MediaId = A413MediaId;
         }
         ZM1076( -9) ;
         OnLoadActions1076( ) ;
         AddRow1076( ) ;
         ScanKeyEnd1076( ) ;
         if ( RcdFound76 == 0 )
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
         RowToVars76( bcTrn_Media, 0) ;
         ScanKeyStart1076( ) ;
         if ( RcdFound76 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z413MediaId = A413MediaId;
         }
         ZM1076( -9) ;
         OnLoadActions1076( ) ;
         AddRow1076( ) ;
         ScanKeyEnd1076( ) ;
         if ( RcdFound76 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1076( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1076( ) ;
         }
         else
         {
            if ( RcdFound76 == 1 )
            {
               if ( A413MediaId != Z413MediaId )
               {
                  A413MediaId = Z413MediaId;
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
                  Update1076( ) ;
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
                  if ( A413MediaId != Z413MediaId )
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
                        Insert1076( ) ;
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
                        Insert1076( ) ;
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
         RowToVars76( bcTrn_Media, 1) ;
         SaveImpl( ) ;
         VarsToRow76( bcTrn_Media) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars76( bcTrn_Media, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1076( ) ;
         AfterTrn( ) ;
         VarsToRow76( bcTrn_Media) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow76( bcTrn_Media) ;
         }
         else
         {
            SdtTrn_Media auxBC = new SdtTrn_Media(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A413MediaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Media);
               auxBC.Save();
               bcTrn_Media.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars76( bcTrn_Media, 1) ;
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
         RowToVars76( bcTrn_Media, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1076( ) ;
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
               VarsToRow76( bcTrn_Media) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow76( bcTrn_Media) ;
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
         RowToVars76( bcTrn_Media, 0) ;
         GetKey1076( ) ;
         if ( RcdFound76 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A413MediaId != Z413MediaId )
            {
               A413MediaId = Z413MediaId;
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
            if ( A413MediaId != Z413MediaId )
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
         context.RollbackDataStores("trn_media_bc",pr_default);
         VarsToRow76( bcTrn_Media) ;
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
         Gx_mode = bcTrn_Media.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Media.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Media )
         {
            bcTrn_Media = (SdtTrn_Media)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Media.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Media.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow76( bcTrn_Media) ;
            }
            else
            {
               RowToVars76( bcTrn_Media, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Media.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Media.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars76( bcTrn_Media, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Media Trn_Media_BC
      {
         get {
            return bcTrn_Media ;
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
            return "trn_media_Execute" ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z413MediaId = Guid.Empty;
         A413MediaId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z646CroppedOriginalMediaId = Guid.Empty;
         A646CroppedOriginalMediaId = Guid.Empty;
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z414MediaName = "";
         A414MediaName = "";
         Z418MediaType = "";
         A418MediaType = "";
         Z618MediaDateTime = (DateTime)(DateTime.MinValue);
         A618MediaDateTime = (DateTime)(DateTime.MinValue);
         Z416MediaUrl = "";
         A416MediaUrl = "";
         Z415MediaImage = "";
         A415MediaImage = "";
         Z40000MediaImage_GXI = "";
         A40000MediaImage_GXI = "";
         BC00104_A413MediaId = new Guid[] {Guid.Empty} ;
         BC00104_A646CroppedOriginalMediaId = new Guid[] {Guid.Empty} ;
         BC00104_n646CroppedOriginalMediaId = new bool[] {false} ;
         BC00104_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00104_A414MediaName = new string[] {""} ;
         BC00104_A40000MediaImage_GXI = new string[] {""} ;
         BC00104_n40000MediaImage_GXI = new bool[] {false} ;
         BC00104_A417MediaSize = new int[1] ;
         BC00104_A418MediaType = new string[] {""} ;
         BC00104_A618MediaDateTime = new DateTime[] {DateTime.MinValue} ;
         BC00104_n618MediaDateTime = new bool[] {false} ;
         BC00104_A416MediaUrl = new string[] {""} ;
         BC00104_A636IsCropped = new bool[] {false} ;
         BC00104_A415MediaImage = new string[] {""} ;
         BC00104_n415MediaImage = new bool[] {false} ;
         BC00105_A413MediaId = new Guid[] {Guid.Empty} ;
         BC00103_A413MediaId = new Guid[] {Guid.Empty} ;
         BC00103_A646CroppedOriginalMediaId = new Guid[] {Guid.Empty} ;
         BC00103_n646CroppedOriginalMediaId = new bool[] {false} ;
         BC00103_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00103_A414MediaName = new string[] {""} ;
         BC00103_A40000MediaImage_GXI = new string[] {""} ;
         BC00103_n40000MediaImage_GXI = new bool[] {false} ;
         BC00103_A417MediaSize = new int[1] ;
         BC00103_A418MediaType = new string[] {""} ;
         BC00103_A618MediaDateTime = new DateTime[] {DateTime.MinValue} ;
         BC00103_n618MediaDateTime = new bool[] {false} ;
         BC00103_A416MediaUrl = new string[] {""} ;
         BC00103_A636IsCropped = new bool[] {false} ;
         BC00103_A415MediaImage = new string[] {""} ;
         BC00103_n415MediaImage = new bool[] {false} ;
         sMode76 = "";
         BC00102_A413MediaId = new Guid[] {Guid.Empty} ;
         BC00102_A646CroppedOriginalMediaId = new Guid[] {Guid.Empty} ;
         BC00102_n646CroppedOriginalMediaId = new bool[] {false} ;
         BC00102_A29LocationId = new Guid[] {Guid.Empty} ;
         BC00102_A414MediaName = new string[] {""} ;
         BC00102_A40000MediaImage_GXI = new string[] {""} ;
         BC00102_n40000MediaImage_GXI = new bool[] {false} ;
         BC00102_A417MediaSize = new int[1] ;
         BC00102_A418MediaType = new string[] {""} ;
         BC00102_A618MediaDateTime = new DateTime[] {DateTime.MinValue} ;
         BC00102_n618MediaDateTime = new bool[] {false} ;
         BC00102_A416MediaUrl = new string[] {""} ;
         BC00102_A636IsCropped = new bool[] {false} ;
         BC00102_A415MediaImage = new string[] {""} ;
         BC00102_n415MediaImage = new bool[] {false} ;
         BC001010_A644CroppedMediaId = new Guid[] {Guid.Empty} ;
         BC001011_A413MediaId = new Guid[] {Guid.Empty} ;
         BC001011_A646CroppedOriginalMediaId = new Guid[] {Guid.Empty} ;
         BC001011_n646CroppedOriginalMediaId = new bool[] {false} ;
         BC001011_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001011_A414MediaName = new string[] {""} ;
         BC001011_A40000MediaImage_GXI = new string[] {""} ;
         BC001011_n40000MediaImage_GXI = new bool[] {false} ;
         BC001011_A417MediaSize = new int[1] ;
         BC001011_A418MediaType = new string[] {""} ;
         BC001011_A618MediaDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001011_n618MediaDateTime = new bool[] {false} ;
         BC001011_A416MediaUrl = new string[] {""} ;
         BC001011_A636IsCropped = new bool[] {false} ;
         BC001011_A415MediaImage = new string[] {""} ;
         BC001011_n415MediaImage = new bool[] {false} ;
         i646CroppedOriginalMediaId = Guid.Empty;
         i29LocationId = Guid.Empty;
         i618MediaDateTime = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_media_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_media_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_media_bc__default(),
            new Object[][] {
                new Object[] {
               BC00102_A413MediaId, BC00102_A646CroppedOriginalMediaId, BC00102_n646CroppedOriginalMediaId, BC00102_A29LocationId, BC00102_A414MediaName, BC00102_A40000MediaImage_GXI, BC00102_n40000MediaImage_GXI, BC00102_A417MediaSize, BC00102_A418MediaType, BC00102_A618MediaDateTime,
               BC00102_n618MediaDateTime, BC00102_A416MediaUrl, BC00102_A636IsCropped, BC00102_A415MediaImage, BC00102_n415MediaImage
               }
               , new Object[] {
               BC00103_A413MediaId, BC00103_A646CroppedOriginalMediaId, BC00103_n646CroppedOriginalMediaId, BC00103_A29LocationId, BC00103_A414MediaName, BC00103_A40000MediaImage_GXI, BC00103_n40000MediaImage_GXI, BC00103_A417MediaSize, BC00103_A418MediaType, BC00103_A618MediaDateTime,
               BC00103_n618MediaDateTime, BC00103_A416MediaUrl, BC00103_A636IsCropped, BC00103_A415MediaImage, BC00103_n415MediaImage
               }
               , new Object[] {
               BC00104_A413MediaId, BC00104_A646CroppedOriginalMediaId, BC00104_n646CroppedOriginalMediaId, BC00104_A29LocationId, BC00104_A414MediaName, BC00104_A40000MediaImage_GXI, BC00104_n40000MediaImage_GXI, BC00104_A417MediaSize, BC00104_A418MediaType, BC00104_A618MediaDateTime,
               BC00104_n618MediaDateTime, BC00104_A416MediaUrl, BC00104_A636IsCropped, BC00104_A415MediaImage, BC00104_n415MediaImage
               }
               , new Object[] {
               BC00105_A413MediaId
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
               BC001010_A644CroppedMediaId
               }
               , new Object[] {
               BC001011_A413MediaId, BC001011_A646CroppedOriginalMediaId, BC001011_n646CroppedOriginalMediaId, BC001011_A29LocationId, BC001011_A414MediaName, BC001011_A40000MediaImage_GXI, BC001011_n40000MediaImage_GXI, BC001011_A417MediaSize, BC001011_A418MediaType, BC001011_A618MediaDateTime,
               BC001011_n618MediaDateTime, BC001011_A416MediaUrl, BC001011_A636IsCropped, BC001011_A415MediaImage, BC001011_n415MediaImage
               }
            }
         );
         Z646CroppedOriginalMediaId = Guid.NewGuid( );
         n646CroppedOriginalMediaId = false;
         A646CroppedOriginalMediaId = Guid.NewGuid( );
         n646CroppedOriginalMediaId = false;
         i646CroppedOriginalMediaId = Guid.NewGuid( );
         n646CroppedOriginalMediaId = false;
         Z29LocationId = Guid.NewGuid( );
         A29LocationId = Guid.NewGuid( );
         i29LocationId = Guid.NewGuid( );
         Z413MediaId = Guid.NewGuid( );
         A413MediaId = Guid.NewGuid( );
         Z618MediaDateTime = DateTimeUtil.Now( context);
         n618MediaDateTime = false;
         A618MediaDateTime = DateTimeUtil.Now( context);
         n618MediaDateTime = false;
         i618MediaDateTime = DateTimeUtil.Now( context);
         n618MediaDateTime = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12102 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound76 ;
      private int trnEnded ;
      private int Z417MediaSize ;
      private int A417MediaSize ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z418MediaType ;
      private string A418MediaType ;
      private string sMode76 ;
      private DateTime Z618MediaDateTime ;
      private DateTime A618MediaDateTime ;
      private DateTime i618MediaDateTime ;
      private bool returnInSub ;
      private bool Z636IsCropped ;
      private bool A636IsCropped ;
      private bool n646CroppedOriginalMediaId ;
      private bool n618MediaDateTime ;
      private bool n40000MediaImage_GXI ;
      private bool n415MediaImage ;
      private bool Gx_longc ;
      private string Z414MediaName ;
      private string A414MediaName ;
      private string Z416MediaUrl ;
      private string A416MediaUrl ;
      private string Z40000MediaImage_GXI ;
      private string A40000MediaImage_GXI ;
      private string Z415MediaImage ;
      private string A415MediaImage ;
      private Guid Z413MediaId ;
      private Guid A413MediaId ;
      private Guid Z646CroppedOriginalMediaId ;
      private Guid A646CroppedOriginalMediaId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid i646CroppedOriginalMediaId ;
      private Guid i29LocationId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00104_A413MediaId ;
      private Guid[] BC00104_A646CroppedOriginalMediaId ;
      private bool[] BC00104_n646CroppedOriginalMediaId ;
      private Guid[] BC00104_A29LocationId ;
      private string[] BC00104_A414MediaName ;
      private string[] BC00104_A40000MediaImage_GXI ;
      private bool[] BC00104_n40000MediaImage_GXI ;
      private int[] BC00104_A417MediaSize ;
      private string[] BC00104_A418MediaType ;
      private DateTime[] BC00104_A618MediaDateTime ;
      private bool[] BC00104_n618MediaDateTime ;
      private string[] BC00104_A416MediaUrl ;
      private bool[] BC00104_A636IsCropped ;
      private string[] BC00104_A415MediaImage ;
      private bool[] BC00104_n415MediaImage ;
      private Guid[] BC00105_A413MediaId ;
      private Guid[] BC00103_A413MediaId ;
      private Guid[] BC00103_A646CroppedOriginalMediaId ;
      private bool[] BC00103_n646CroppedOriginalMediaId ;
      private Guid[] BC00103_A29LocationId ;
      private string[] BC00103_A414MediaName ;
      private string[] BC00103_A40000MediaImage_GXI ;
      private bool[] BC00103_n40000MediaImage_GXI ;
      private int[] BC00103_A417MediaSize ;
      private string[] BC00103_A418MediaType ;
      private DateTime[] BC00103_A618MediaDateTime ;
      private bool[] BC00103_n618MediaDateTime ;
      private string[] BC00103_A416MediaUrl ;
      private bool[] BC00103_A636IsCropped ;
      private string[] BC00103_A415MediaImage ;
      private bool[] BC00103_n415MediaImage ;
      private Guid[] BC00102_A413MediaId ;
      private Guid[] BC00102_A646CroppedOriginalMediaId ;
      private bool[] BC00102_n646CroppedOriginalMediaId ;
      private Guid[] BC00102_A29LocationId ;
      private string[] BC00102_A414MediaName ;
      private string[] BC00102_A40000MediaImage_GXI ;
      private bool[] BC00102_n40000MediaImage_GXI ;
      private int[] BC00102_A417MediaSize ;
      private string[] BC00102_A418MediaType ;
      private DateTime[] BC00102_A618MediaDateTime ;
      private bool[] BC00102_n618MediaDateTime ;
      private string[] BC00102_A416MediaUrl ;
      private bool[] BC00102_A636IsCropped ;
      private string[] BC00102_A415MediaImage ;
      private bool[] BC00102_n415MediaImage ;
      private Guid[] BC001010_A644CroppedMediaId ;
      private Guid[] BC001011_A413MediaId ;
      private Guid[] BC001011_A646CroppedOriginalMediaId ;
      private bool[] BC001011_n646CroppedOriginalMediaId ;
      private Guid[] BC001011_A29LocationId ;
      private string[] BC001011_A414MediaName ;
      private string[] BC001011_A40000MediaImage_GXI ;
      private bool[] BC001011_n40000MediaImage_GXI ;
      private int[] BC001011_A417MediaSize ;
      private string[] BC001011_A418MediaType ;
      private DateTime[] BC001011_A618MediaDateTime ;
      private bool[] BC001011_n618MediaDateTime ;
      private string[] BC001011_A416MediaUrl ;
      private bool[] BC001011_A636IsCropped ;
      private string[] BC001011_A415MediaImage ;
      private bool[] BC001011_n415MediaImage ;
      private SdtTrn_Media bcTrn_Media ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_media_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_media_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_media_bc__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
      ,new ForEachCursor(def[1])
      ,new ForEachCursor(def[2])
      ,new ForEachCursor(def[3])
      ,new UpdateCursor(def[4])
      ,new UpdateCursor(def[5])
      ,new UpdateCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC00102;
       prmBC00102 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00103;
       prmBC00103 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00104;
       prmBC00104 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00105;
       prmBC00105 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00106;
       prmBC00106 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("CroppedOriginalMediaId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MediaName",GXType.VarChar,100,0) ,
       new ParDef("MediaImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("MediaImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=4, Tbl="Trn_Media", Fld="MediaImage"} ,
       new ParDef("MediaSize",GXType.Int32,8,0) ,
       new ParDef("MediaType",GXType.Char,20,0) ,
       new ParDef("MediaDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MediaUrl",GXType.VarChar,1000,0) ,
       new ParDef("IsCropped",GXType.Boolean,4,0)
       };
       Object[] prmBC00107;
       prmBC00107 = new Object[] {
       new ParDef("CroppedOriginalMediaId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MediaName",GXType.VarChar,100,0) ,
       new ParDef("MediaSize",GXType.Int32,8,0) ,
       new ParDef("MediaType",GXType.Char,20,0) ,
       new ParDef("MediaDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MediaUrl",GXType.VarChar,1000,0) ,
       new ParDef("IsCropped",GXType.Boolean,4,0) ,
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00108;
       prmBC00108 = new Object[] {
       new ParDef("MediaImage",GXType.Byte,1024,0){Nullable=true,InDB=false} ,
       new ParDef("MediaImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Trn_Media", Fld="MediaImage"} ,
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00109;
       prmBC00109 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001010;
       prmBC001010 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001011;
       prmBC001011 = new Object[] {
       new ParDef("MediaId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00102", "SELECT MediaId, CroppedOriginalMediaId, LocationId, MediaName, MediaImage_GXI, MediaSize, MediaType, MediaDateTime, MediaUrl, IsCropped, MediaImage FROM Trn_Media WHERE MediaId = :MediaId  FOR UPDATE OF Trn_Media",true, GxErrorMask.GX_NOMASK, false, this,prmBC00102,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00103", "SELECT MediaId, CroppedOriginalMediaId, LocationId, MediaName, MediaImage_GXI, MediaSize, MediaType, MediaDateTime, MediaUrl, IsCropped, MediaImage FROM Trn_Media WHERE MediaId = :MediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00103,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00104", "SELECT TM1.MediaId, TM1.CroppedOriginalMediaId, TM1.LocationId, TM1.MediaName, TM1.MediaImage_GXI, TM1.MediaSize, TM1.MediaType, TM1.MediaDateTime, TM1.MediaUrl, TM1.IsCropped, TM1.MediaImage FROM Trn_Media TM1 WHERE TM1.MediaId = :MediaId ORDER BY TM1.MediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00104,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00105", "SELECT MediaId FROM Trn_Media WHERE MediaId = :MediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00105,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00106", "SAVEPOINT gxupdate;INSERT INTO Trn_Media(MediaId, CroppedOriginalMediaId, LocationId, MediaName, MediaImage, MediaImage_GXI, MediaSize, MediaType, MediaDateTime, MediaUrl, IsCropped) VALUES(:MediaId, :CroppedOriginalMediaId, :LocationId, :MediaName, :MediaImage, :MediaImage_GXI, :MediaSize, :MediaType, :MediaDateTime, :MediaUrl, :IsCropped);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00106)
          ,new CursorDef("BC00107", "SAVEPOINT gxupdate;UPDATE Trn_Media SET CroppedOriginalMediaId=:CroppedOriginalMediaId, LocationId=:LocationId, MediaName=:MediaName, MediaSize=:MediaSize, MediaType=:MediaType, MediaDateTime=:MediaDateTime, MediaUrl=:MediaUrl, IsCropped=:IsCropped  WHERE MediaId = :MediaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00107)
          ,new CursorDef("BC00108", "SAVEPOINT gxupdate;UPDATE Trn_Media SET MediaImage=:MediaImage, MediaImage_GXI=:MediaImage_GXI  WHERE MediaId = :MediaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00108)
          ,new CursorDef("BC00109", "SAVEPOINT gxupdate;DELETE FROM Trn_Media  WHERE MediaId = :MediaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00109)
          ,new CursorDef("BC001010", "SELECT CroppedMediaId FROM Trn_CroppedMedia WHERE MediaId = :MediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001010,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC001011", "SELECT TM1.MediaId, TM1.CroppedOriginalMediaId, TM1.LocationId, TM1.MediaName, TM1.MediaImage_GXI, TM1.MediaSize, TM1.MediaType, TM1.MediaDateTime, TM1.MediaUrl, TM1.IsCropped, TM1.MediaImage FROM Trn_Media TM1 WHERE TM1.MediaId = :MediaId ORDER BY TM1.MediaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001011,100, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             ((string[]) buf[4])[0] = rslt.getVarchar(4);
             ((string[]) buf[5])[0] = rslt.getMultimediaUri(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((int[]) buf[7])[0] = rslt.getInt(6);
             ((string[]) buf[8])[0] = rslt.getString(7, 20);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
             ((bool[]) buf[10])[0] = rslt.wasNull(8);
             ((string[]) buf[11])[0] = rslt.getVarchar(9);
             ((bool[]) buf[12])[0] = rslt.getBool(10);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
             ((bool[]) buf[14])[0] = rslt.wasNull(11);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             ((string[]) buf[4])[0] = rslt.getVarchar(4);
             ((string[]) buf[5])[0] = rslt.getMultimediaUri(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((int[]) buf[7])[0] = rslt.getInt(6);
             ((string[]) buf[8])[0] = rslt.getString(7, 20);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
             ((bool[]) buf[10])[0] = rslt.wasNull(8);
             ((string[]) buf[11])[0] = rslt.getVarchar(9);
             ((bool[]) buf[12])[0] = rslt.getBool(10);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
             ((bool[]) buf[14])[0] = rslt.wasNull(11);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             ((string[]) buf[4])[0] = rslt.getVarchar(4);
             ((string[]) buf[5])[0] = rslt.getMultimediaUri(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((int[]) buf[7])[0] = rslt.getInt(6);
             ((string[]) buf[8])[0] = rslt.getString(7, 20);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
             ((bool[]) buf[10])[0] = rslt.wasNull(8);
             ((string[]) buf[11])[0] = rslt.getVarchar(9);
             ((bool[]) buf[12])[0] = rslt.getBool(10);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
             ((bool[]) buf[14])[0] = rslt.wasNull(11);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((bool[]) buf[2])[0] = rslt.wasNull(2);
             ((Guid[]) buf[3])[0] = rslt.getGuid(3);
             ((string[]) buf[4])[0] = rslt.getVarchar(4);
             ((string[]) buf[5])[0] = rslt.getMultimediaUri(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((int[]) buf[7])[0] = rslt.getInt(6);
             ((string[]) buf[8])[0] = rslt.getString(7, 20);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
             ((bool[]) buf[10])[0] = rslt.wasNull(8);
             ((string[]) buf[11])[0] = rslt.getVarchar(9);
             ((bool[]) buf[12])[0] = rslt.getBool(10);
             ((string[]) buf[13])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(5));
             ((bool[]) buf[14])[0] = rslt.wasNull(11);
             return;
    }
 }

}

}
