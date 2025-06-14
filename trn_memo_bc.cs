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
   public class trn_memo_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_memo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_memo_bc( IGxContext context )
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
         ReadRow1P100( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1P100( ) ;
         standaloneModal( ) ;
         AddRow1P100( ) ;
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
            E111P2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z549MemoId = A549MemoId;
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

      protected void CONFIRM_1P0( )
      {
         BeforeValidate1P100( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1P100( ) ;
            }
            else
            {
               CheckExtendedTable1P100( ) ;
               if ( AnyError == 0 )
               {
                  ZM1P100( 10) ;
               }
               CloseExtendedTableCursors1P100( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121P2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV31Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV32GXV1 = 1;
            while ( AV32GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV32GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "ResidentId") == 0 )
               {
                  AV26Insert_ResidentId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "SG_OrganisationId") == 0 )
               {
                  AV29Insert_SG_OrganisationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "SG_LocationId") == 0 )
               {
                  AV30Insert_SG_LocationId = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               AV32GXV1 = (int)(AV32GXV1+1);
            }
         }
      }

      protected void E111P2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1P100( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z550MemoTitle = A550MemoTitle;
            Z551MemoDescription = A551MemoDescription;
            Z553MemoDocument = A553MemoDocument;
            Z561MemoStartDateTime = A561MemoStartDateTime;
            Z562MemoEndDateTime = A562MemoEndDateTime;
            Z563MemoDuration = A563MemoDuration;
            Z564MemoRemoveDate = A564MemoRemoveDate;
            Z566MemoBgColorCode = A566MemoBgColorCode;
            Z567MemoForm = A567MemoForm;
            Z624MemoType = A624MemoType;
            Z625MemoName = A625MemoName;
            Z626MemoLeftOffset = A626MemoLeftOffset;
            Z627MemoTopOffset = A627MemoTopOffset;
            Z628MemoTitleAngle = A628MemoTitleAngle;
            Z629MemoTitleScale = A629MemoTitleScale;
            Z637MemoTextFontName = A637MemoTextFontName;
            Z638MemoTextAlignment = A638MemoTextAlignment;
            Z639MemoIsBold = A639MemoIsBold;
            Z640MemoIsItalic = A640MemoIsItalic;
            Z641MemoIsCapitalized = A641MemoIsCapitalized;
            Z642MemoTextColor = A642MemoTextColor;
            Z62ResidentId = A62ResidentId;
            Z528SG_LocationId = A528SG_LocationId;
            Z529SG_OrganisationId = A529SG_OrganisationId;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z72ResidentSalutation = A72ResidentSalutation;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z71ResidentGUID = A71ResidentGUID;
         }
         if ( GX_JID == -9 )
         {
            Z549MemoId = A549MemoId;
            Z550MemoTitle = A550MemoTitle;
            Z551MemoDescription = A551MemoDescription;
            Z552MemoImage = A552MemoImage;
            Z553MemoDocument = A553MemoDocument;
            Z561MemoStartDateTime = A561MemoStartDateTime;
            Z562MemoEndDateTime = A562MemoEndDateTime;
            Z563MemoDuration = A563MemoDuration;
            Z564MemoRemoveDate = A564MemoRemoveDate;
            Z566MemoBgColorCode = A566MemoBgColorCode;
            Z567MemoForm = A567MemoForm;
            Z624MemoType = A624MemoType;
            Z625MemoName = A625MemoName;
            Z626MemoLeftOffset = A626MemoLeftOffset;
            Z627MemoTopOffset = A627MemoTopOffset;
            Z628MemoTitleAngle = A628MemoTitleAngle;
            Z629MemoTitleScale = A629MemoTitleScale;
            Z637MemoTextFontName = A637MemoTextFontName;
            Z638MemoTextAlignment = A638MemoTextAlignment;
            Z639MemoIsBold = A639MemoIsBold;
            Z640MemoIsItalic = A640MemoIsItalic;
            Z641MemoIsCapitalized = A641MemoIsCapitalized;
            Z642MemoTextColor = A642MemoTextColor;
            Z62ResidentId = A62ResidentId;
            Z528SG_LocationId = A528SG_LocationId;
            Z529SG_OrganisationId = A529SG_OrganisationId;
            Z29LocationId = A29LocationId;
            Z11OrganisationId = A11OrganisationId;
            Z72ResidentSalutation = A72ResidentSalutation;
            Z64ResidentGivenName = A64ResidentGivenName;
            Z65ResidentLastName = A65ResidentLastName;
            Z71ResidentGUID = A71ResidentGUID;
         }
      }

      protected void standaloneNotModal( )
      {
         AV31Pgmname = "Trn_Memo_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A549MemoId) )
         {
            A549MemoId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1P100( )
      {
         /* Using cursor BC001P5 */
         pr_default.execute(3, new Object[] {A549MemoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound100 = 1;
            A29LocationId = BC001P5_A29LocationId[0];
            A11OrganisationId = BC001P5_A11OrganisationId[0];
            A550MemoTitle = BC001P5_A550MemoTitle[0];
            A551MemoDescription = BC001P5_A551MemoDescription[0];
            A552MemoImage = BC001P5_A552MemoImage[0];
            n552MemoImage = BC001P5_n552MemoImage[0];
            A553MemoDocument = BC001P5_A553MemoDocument[0];
            n553MemoDocument = BC001P5_n553MemoDocument[0];
            A561MemoStartDateTime = BC001P5_A561MemoStartDateTime[0];
            n561MemoStartDateTime = BC001P5_n561MemoStartDateTime[0];
            A562MemoEndDateTime = BC001P5_A562MemoEndDateTime[0];
            n562MemoEndDateTime = BC001P5_n562MemoEndDateTime[0];
            A563MemoDuration = BC001P5_A563MemoDuration[0];
            n563MemoDuration = BC001P5_n563MemoDuration[0];
            A564MemoRemoveDate = BC001P5_A564MemoRemoveDate[0];
            n564MemoRemoveDate = BC001P5_n564MemoRemoveDate[0];
            A72ResidentSalutation = BC001P5_A72ResidentSalutation[0];
            A64ResidentGivenName = BC001P5_A64ResidentGivenName[0];
            A65ResidentLastName = BC001P5_A65ResidentLastName[0];
            A71ResidentGUID = BC001P5_A71ResidentGUID[0];
            A566MemoBgColorCode = BC001P5_A566MemoBgColorCode[0];
            n566MemoBgColorCode = BC001P5_n566MemoBgColorCode[0];
            A567MemoForm = BC001P5_A567MemoForm[0];
            A624MemoType = BC001P5_A624MemoType[0];
            A625MemoName = BC001P5_A625MemoName[0];
            A626MemoLeftOffset = BC001P5_A626MemoLeftOffset[0];
            A627MemoTopOffset = BC001P5_A627MemoTopOffset[0];
            A628MemoTitleAngle = BC001P5_A628MemoTitleAngle[0];
            A629MemoTitleScale = BC001P5_A629MemoTitleScale[0];
            A637MemoTextFontName = BC001P5_A637MemoTextFontName[0];
            A638MemoTextAlignment = BC001P5_A638MemoTextAlignment[0];
            A639MemoIsBold = BC001P5_A639MemoIsBold[0];
            A640MemoIsItalic = BC001P5_A640MemoIsItalic[0];
            A641MemoIsCapitalized = BC001P5_A641MemoIsCapitalized[0];
            A642MemoTextColor = BC001P5_A642MemoTextColor[0];
            A62ResidentId = BC001P5_A62ResidentId[0];
            A528SG_LocationId = BC001P5_A528SG_LocationId[0];
            A529SG_OrganisationId = BC001P5_A529SG_OrganisationId[0];
            ZM1P100( -9) ;
         }
         pr_default.close(3);
         OnLoadActions1P100( ) ;
      }

      protected void OnLoadActions1P100( )
      {
      }

      protected void CheckExtendedTable1P100( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001P4 */
         pr_default.execute(2, new Object[] {A62ResidentId, A528SG_LocationId, A529SG_OrganisationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Trn_Resident", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "SG_ORGANISATIONID");
            AnyError = 1;
         }
         A72ResidentSalutation = BC001P4_A72ResidentSalutation[0];
         A64ResidentGivenName = BC001P4_A64ResidentGivenName[0];
         A65ResidentLastName = BC001P4_A65ResidentLastName[0];
         A71ResidentGUID = BC001P4_A71ResidentGUID[0];
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A638MemoTextAlignment, "center") == 0 ) || ( StringUtil.StrCmp(A638MemoTextAlignment, "left") == 0 ) || ( StringUtil.StrCmp(A638MemoTextAlignment, "right") == 0 ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Memo Text Alignment", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1P100( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1P100( )
      {
         /* Using cursor BC001P6 */
         pr_default.execute(4, new Object[] {A549MemoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound100 = 1;
         }
         else
         {
            RcdFound100 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001P3 */
         pr_default.execute(1, new Object[] {A549MemoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1P100( 9) ;
            RcdFound100 = 1;
            A549MemoId = BC001P3_A549MemoId[0];
            A550MemoTitle = BC001P3_A550MemoTitle[0];
            A551MemoDescription = BC001P3_A551MemoDescription[0];
            A552MemoImage = BC001P3_A552MemoImage[0];
            n552MemoImage = BC001P3_n552MemoImage[0];
            A553MemoDocument = BC001P3_A553MemoDocument[0];
            n553MemoDocument = BC001P3_n553MemoDocument[0];
            A561MemoStartDateTime = BC001P3_A561MemoStartDateTime[0];
            n561MemoStartDateTime = BC001P3_n561MemoStartDateTime[0];
            A562MemoEndDateTime = BC001P3_A562MemoEndDateTime[0];
            n562MemoEndDateTime = BC001P3_n562MemoEndDateTime[0];
            A563MemoDuration = BC001P3_A563MemoDuration[0];
            n563MemoDuration = BC001P3_n563MemoDuration[0];
            A564MemoRemoveDate = BC001P3_A564MemoRemoveDate[0];
            n564MemoRemoveDate = BC001P3_n564MemoRemoveDate[0];
            A566MemoBgColorCode = BC001P3_A566MemoBgColorCode[0];
            n566MemoBgColorCode = BC001P3_n566MemoBgColorCode[0];
            A567MemoForm = BC001P3_A567MemoForm[0];
            A624MemoType = BC001P3_A624MemoType[0];
            A625MemoName = BC001P3_A625MemoName[0];
            A626MemoLeftOffset = BC001P3_A626MemoLeftOffset[0];
            A627MemoTopOffset = BC001P3_A627MemoTopOffset[0];
            A628MemoTitleAngle = BC001P3_A628MemoTitleAngle[0];
            A629MemoTitleScale = BC001P3_A629MemoTitleScale[0];
            A637MemoTextFontName = BC001P3_A637MemoTextFontName[0];
            A638MemoTextAlignment = BC001P3_A638MemoTextAlignment[0];
            A639MemoIsBold = BC001P3_A639MemoIsBold[0];
            A640MemoIsItalic = BC001P3_A640MemoIsItalic[0];
            A641MemoIsCapitalized = BC001P3_A641MemoIsCapitalized[0];
            A642MemoTextColor = BC001P3_A642MemoTextColor[0];
            A62ResidentId = BC001P3_A62ResidentId[0];
            A528SG_LocationId = BC001P3_A528SG_LocationId[0];
            A529SG_OrganisationId = BC001P3_A529SG_OrganisationId[0];
            Z549MemoId = A549MemoId;
            sMode100 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1P100( ) ;
            if ( AnyError == 1 )
            {
               RcdFound100 = 0;
               InitializeNonKey1P100( ) ;
            }
            Gx_mode = sMode100;
         }
         else
         {
            RcdFound100 = 0;
            InitializeNonKey1P100( ) ;
            sMode100 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode100;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1P100( ) ;
         if ( RcdFound100 == 0 )
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
         CONFIRM_1P0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1P100( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001P2 */
            pr_default.execute(0, new Object[] {A549MemoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Memo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z550MemoTitle, BC001P2_A550MemoTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z551MemoDescription, BC001P2_A551MemoDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z553MemoDocument, BC001P2_A553MemoDocument[0]) != 0 ) || ( Z561MemoStartDateTime != BC001P2_A561MemoStartDateTime[0] ) || ( Z562MemoEndDateTime != BC001P2_A562MemoEndDateTime[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z563MemoDuration != BC001P2_A563MemoDuration[0] ) || ( DateTimeUtil.ResetTime ( Z564MemoRemoveDate ) != DateTimeUtil.ResetTime ( BC001P2_A564MemoRemoveDate[0] ) ) || ( StringUtil.StrCmp(Z566MemoBgColorCode, BC001P2_A566MemoBgColorCode[0]) != 0 ) || ( StringUtil.StrCmp(Z567MemoForm, BC001P2_A567MemoForm[0]) != 0 ) || ( StringUtil.StrCmp(Z624MemoType, BC001P2_A624MemoType[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z625MemoName, BC001P2_A625MemoName[0]) != 0 ) || ( Z626MemoLeftOffset != BC001P2_A626MemoLeftOffset[0] ) || ( Z627MemoTopOffset != BC001P2_A627MemoTopOffset[0] ) || ( Z628MemoTitleAngle != BC001P2_A628MemoTitleAngle[0] ) || ( Z629MemoTitleScale != BC001P2_A629MemoTitleScale[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z637MemoTextFontName, BC001P2_A637MemoTextFontName[0]) != 0 ) || ( StringUtil.StrCmp(Z638MemoTextAlignment, BC001P2_A638MemoTextAlignment[0]) != 0 ) || ( Z639MemoIsBold != BC001P2_A639MemoIsBold[0] ) || ( Z640MemoIsItalic != BC001P2_A640MemoIsItalic[0] ) || ( Z641MemoIsCapitalized != BC001P2_A641MemoIsCapitalized[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z642MemoTextColor, BC001P2_A642MemoTextColor[0]) != 0 ) || ( Z62ResidentId != BC001P2_A62ResidentId[0] ) || ( Z528SG_LocationId != BC001P2_A528SG_LocationId[0] ) || ( Z529SG_OrganisationId != BC001P2_A529SG_OrganisationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_Memo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1P100( )
      {
         BeforeValidate1P100( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1P100( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1P100( 0) ;
            CheckOptimisticConcurrency1P100( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1P100( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1P100( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001P7 */
                     pr_default.execute(5, new Object[] {A549MemoId, A550MemoTitle, A551MemoDescription, n552MemoImage, A552MemoImage, n553MemoDocument, A553MemoDocument, n561MemoStartDateTime, A561MemoStartDateTime, n562MemoEndDateTime, A562MemoEndDateTime, n563MemoDuration, A563MemoDuration, n564MemoRemoveDate, A564MemoRemoveDate, n566MemoBgColorCode, A566MemoBgColorCode, A567MemoForm, A624MemoType, A625MemoName, A626MemoLeftOffset, A627MemoTopOffset, A628MemoTitleAngle, A629MemoTitleScale, A637MemoTextFontName, A638MemoTextAlignment, A639MemoIsBold, A640MemoIsItalic, A641MemoIsCapitalized, A642MemoTextColor, A62ResidentId, A528SG_LocationId, A529SG_OrganisationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Memo");
                     if ( (pr_default.getStatus(5) == 1) )
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
               Load1P100( ) ;
            }
            EndLevel1P100( ) ;
         }
         CloseExtendedTableCursors1P100( ) ;
      }

      protected void Update1P100( )
      {
         BeforeValidate1P100( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1P100( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1P100( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1P100( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1P100( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001P8 */
                     pr_default.execute(6, new Object[] {A550MemoTitle, A551MemoDescription, n552MemoImage, A552MemoImage, n553MemoDocument, A553MemoDocument, n561MemoStartDateTime, A561MemoStartDateTime, n562MemoEndDateTime, A562MemoEndDateTime, n563MemoDuration, A563MemoDuration, n564MemoRemoveDate, A564MemoRemoveDate, n566MemoBgColorCode, A566MemoBgColorCode, A567MemoForm, A624MemoType, A625MemoName, A626MemoLeftOffset, A627MemoTopOffset, A628MemoTitleAngle, A629MemoTitleScale, A637MemoTextFontName, A638MemoTextAlignment, A639MemoIsBold, A640MemoIsItalic, A641MemoIsCapitalized, A642MemoTextColor, A62ResidentId, A528SG_LocationId, A529SG_OrganisationId, A549MemoId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_Memo");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_Memo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1P100( ) ;
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
            EndLevel1P100( ) ;
         }
         CloseExtendedTableCursors1P100( ) ;
      }

      protected void DeferredUpdate1P100( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1P100( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1P100( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1P100( ) ;
            AfterConfirm1P100( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1P100( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001P9 */
                  pr_default.execute(7, new Object[] {A549MemoId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_Memo");
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
         sMode100 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1P100( ) ;
         Gx_mode = sMode100;
      }

      protected void OnDeleteControls1P100( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001P10 */
            pr_default.execute(8, new Object[] {A62ResidentId, A528SG_LocationId, A529SG_OrganisationId});
            A72ResidentSalutation = BC001P10_A72ResidentSalutation[0];
            A64ResidentGivenName = BC001P10_A64ResidentGivenName[0];
            A65ResidentLastName = BC001P10_A65ResidentLastName[0];
            A71ResidentGUID = BC001P10_A71ResidentGUID[0];
            pr_default.close(8);
         }
      }

      protected void EndLevel1P100( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1P100( ) ;
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

      public void ScanKeyStart1P100( )
      {
         /* Scan By routine */
         /* Using cursor BC001P11 */
         pr_default.execute(9, new Object[] {A549MemoId});
         RcdFound100 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound100 = 1;
            A29LocationId = BC001P11_A29LocationId[0];
            A11OrganisationId = BC001P11_A11OrganisationId[0];
            A549MemoId = BC001P11_A549MemoId[0];
            A550MemoTitle = BC001P11_A550MemoTitle[0];
            A551MemoDescription = BC001P11_A551MemoDescription[0];
            A552MemoImage = BC001P11_A552MemoImage[0];
            n552MemoImage = BC001P11_n552MemoImage[0];
            A553MemoDocument = BC001P11_A553MemoDocument[0];
            n553MemoDocument = BC001P11_n553MemoDocument[0];
            A561MemoStartDateTime = BC001P11_A561MemoStartDateTime[0];
            n561MemoStartDateTime = BC001P11_n561MemoStartDateTime[0];
            A562MemoEndDateTime = BC001P11_A562MemoEndDateTime[0];
            n562MemoEndDateTime = BC001P11_n562MemoEndDateTime[0];
            A563MemoDuration = BC001P11_A563MemoDuration[0];
            n563MemoDuration = BC001P11_n563MemoDuration[0];
            A564MemoRemoveDate = BC001P11_A564MemoRemoveDate[0];
            n564MemoRemoveDate = BC001P11_n564MemoRemoveDate[0];
            A72ResidentSalutation = BC001P11_A72ResidentSalutation[0];
            A64ResidentGivenName = BC001P11_A64ResidentGivenName[0];
            A65ResidentLastName = BC001P11_A65ResidentLastName[0];
            A71ResidentGUID = BC001P11_A71ResidentGUID[0];
            A566MemoBgColorCode = BC001P11_A566MemoBgColorCode[0];
            n566MemoBgColorCode = BC001P11_n566MemoBgColorCode[0];
            A567MemoForm = BC001P11_A567MemoForm[0];
            A624MemoType = BC001P11_A624MemoType[0];
            A625MemoName = BC001P11_A625MemoName[0];
            A626MemoLeftOffset = BC001P11_A626MemoLeftOffset[0];
            A627MemoTopOffset = BC001P11_A627MemoTopOffset[0];
            A628MemoTitleAngle = BC001P11_A628MemoTitleAngle[0];
            A629MemoTitleScale = BC001P11_A629MemoTitleScale[0];
            A637MemoTextFontName = BC001P11_A637MemoTextFontName[0];
            A638MemoTextAlignment = BC001P11_A638MemoTextAlignment[0];
            A639MemoIsBold = BC001P11_A639MemoIsBold[0];
            A640MemoIsItalic = BC001P11_A640MemoIsItalic[0];
            A641MemoIsCapitalized = BC001P11_A641MemoIsCapitalized[0];
            A642MemoTextColor = BC001P11_A642MemoTextColor[0];
            A62ResidentId = BC001P11_A62ResidentId[0];
            A528SG_LocationId = BC001P11_A528SG_LocationId[0];
            A529SG_OrganisationId = BC001P11_A529SG_OrganisationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1P100( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound100 = 0;
         ScanKeyLoad1P100( ) ;
      }

      protected void ScanKeyLoad1P100( )
      {
         sMode100 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound100 = 1;
            A29LocationId = BC001P11_A29LocationId[0];
            A11OrganisationId = BC001P11_A11OrganisationId[0];
            A549MemoId = BC001P11_A549MemoId[0];
            A550MemoTitle = BC001P11_A550MemoTitle[0];
            A551MemoDescription = BC001P11_A551MemoDescription[0];
            A552MemoImage = BC001P11_A552MemoImage[0];
            n552MemoImage = BC001P11_n552MemoImage[0];
            A553MemoDocument = BC001P11_A553MemoDocument[0];
            n553MemoDocument = BC001P11_n553MemoDocument[0];
            A561MemoStartDateTime = BC001P11_A561MemoStartDateTime[0];
            n561MemoStartDateTime = BC001P11_n561MemoStartDateTime[0];
            A562MemoEndDateTime = BC001P11_A562MemoEndDateTime[0];
            n562MemoEndDateTime = BC001P11_n562MemoEndDateTime[0];
            A563MemoDuration = BC001P11_A563MemoDuration[0];
            n563MemoDuration = BC001P11_n563MemoDuration[0];
            A564MemoRemoveDate = BC001P11_A564MemoRemoveDate[0];
            n564MemoRemoveDate = BC001P11_n564MemoRemoveDate[0];
            A72ResidentSalutation = BC001P11_A72ResidentSalutation[0];
            A64ResidentGivenName = BC001P11_A64ResidentGivenName[0];
            A65ResidentLastName = BC001P11_A65ResidentLastName[0];
            A71ResidentGUID = BC001P11_A71ResidentGUID[0];
            A566MemoBgColorCode = BC001P11_A566MemoBgColorCode[0];
            n566MemoBgColorCode = BC001P11_n566MemoBgColorCode[0];
            A567MemoForm = BC001P11_A567MemoForm[0];
            A624MemoType = BC001P11_A624MemoType[0];
            A625MemoName = BC001P11_A625MemoName[0];
            A626MemoLeftOffset = BC001P11_A626MemoLeftOffset[0];
            A627MemoTopOffset = BC001P11_A627MemoTopOffset[0];
            A628MemoTitleAngle = BC001P11_A628MemoTitleAngle[0];
            A629MemoTitleScale = BC001P11_A629MemoTitleScale[0];
            A637MemoTextFontName = BC001P11_A637MemoTextFontName[0];
            A638MemoTextAlignment = BC001P11_A638MemoTextAlignment[0];
            A639MemoIsBold = BC001P11_A639MemoIsBold[0];
            A640MemoIsItalic = BC001P11_A640MemoIsItalic[0];
            A641MemoIsCapitalized = BC001P11_A641MemoIsCapitalized[0];
            A642MemoTextColor = BC001P11_A642MemoTextColor[0];
            A62ResidentId = BC001P11_A62ResidentId[0];
            A528SG_LocationId = BC001P11_A528SG_LocationId[0];
            A529SG_OrganisationId = BC001P11_A529SG_OrganisationId[0];
         }
         Gx_mode = sMode100;
      }

      protected void ScanKeyEnd1P100( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1P100( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1P100( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1P100( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1P100( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1P100( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1P100( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1P100( )
      {
      }

      protected void send_integrity_lvl_hashes1P100( )
      {
      }

      protected void AddRow1P100( )
      {
         VarsToRow100( bcTrn_Memo) ;
      }

      protected void ReadRow1P100( )
      {
         RowToVars100( bcTrn_Memo, 1) ;
      }

      protected void InitializeNonKey1P100( )
      {
         A11OrganisationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         A550MemoTitle = "";
         A551MemoDescription = "";
         A552MemoImage = "";
         n552MemoImage = false;
         A553MemoDocument = "";
         n553MemoDocument = false;
         A561MemoStartDateTime = (DateTime)(DateTime.MinValue);
         n561MemoStartDateTime = false;
         A562MemoEndDateTime = (DateTime)(DateTime.MinValue);
         n562MemoEndDateTime = false;
         A563MemoDuration = 0;
         n563MemoDuration = false;
         A564MemoRemoveDate = DateTime.MinValue;
         n564MemoRemoveDate = false;
         A62ResidentId = Guid.Empty;
         A72ResidentSalutation = "";
         A64ResidentGivenName = "";
         A65ResidentLastName = "";
         A71ResidentGUID = "";
         A566MemoBgColorCode = "";
         n566MemoBgColorCode = false;
         A567MemoForm = "";
         A529SG_OrganisationId = Guid.Empty;
         A528SG_LocationId = Guid.Empty;
         A624MemoType = "";
         A625MemoName = "";
         A626MemoLeftOffset = 0;
         A627MemoTopOffset = 0;
         A628MemoTitleAngle = 0;
         A629MemoTitleScale = 0;
         A637MemoTextFontName = "";
         A638MemoTextAlignment = "";
         A639MemoIsBold = false;
         A640MemoIsItalic = false;
         A641MemoIsCapitalized = false;
         A642MemoTextColor = "";
         Z550MemoTitle = "";
         Z551MemoDescription = "";
         Z553MemoDocument = "";
         Z561MemoStartDateTime = (DateTime)(DateTime.MinValue);
         Z562MemoEndDateTime = (DateTime)(DateTime.MinValue);
         Z563MemoDuration = 0;
         Z564MemoRemoveDate = DateTime.MinValue;
         Z566MemoBgColorCode = "";
         Z567MemoForm = "";
         Z624MemoType = "";
         Z625MemoName = "";
         Z626MemoLeftOffset = 0;
         Z627MemoTopOffset = 0;
         Z628MemoTitleAngle = 0;
         Z629MemoTitleScale = 0;
         Z637MemoTextFontName = "";
         Z638MemoTextAlignment = "";
         Z639MemoIsBold = false;
         Z640MemoIsItalic = false;
         Z641MemoIsCapitalized = false;
         Z642MemoTextColor = "";
         Z62ResidentId = Guid.Empty;
         Z528SG_LocationId = Guid.Empty;
         Z529SG_OrganisationId = Guid.Empty;
      }

      protected void InitAll1P100( )
      {
         A549MemoId = Guid.NewGuid( );
         InitializeNonKey1P100( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow100( SdtTrn_Memo obj100 )
      {
         obj100.gxTpr_Mode = Gx_mode;
         obj100.gxTpr_Memotitle = A550MemoTitle;
         obj100.gxTpr_Memodescription = A551MemoDescription;
         obj100.gxTpr_Memoimage = A552MemoImage;
         obj100.gxTpr_Memodocument = A553MemoDocument;
         obj100.gxTpr_Memostartdatetime = A561MemoStartDateTime;
         obj100.gxTpr_Memoenddatetime = A562MemoEndDateTime;
         obj100.gxTpr_Memoduration = A563MemoDuration;
         obj100.gxTpr_Memoremovedate = A564MemoRemoveDate;
         obj100.gxTpr_Residentid = A62ResidentId;
         obj100.gxTpr_Residentsalutation = A72ResidentSalutation;
         obj100.gxTpr_Residentgivenname = A64ResidentGivenName;
         obj100.gxTpr_Residentlastname = A65ResidentLastName;
         obj100.gxTpr_Residentguid = A71ResidentGUID;
         obj100.gxTpr_Memobgcolorcode = A566MemoBgColorCode;
         obj100.gxTpr_Memoform = A567MemoForm;
         obj100.gxTpr_Sg_organisationid = A529SG_OrganisationId;
         obj100.gxTpr_Sg_locationid = A528SG_LocationId;
         obj100.gxTpr_Memotype = A624MemoType;
         obj100.gxTpr_Memoname = A625MemoName;
         obj100.gxTpr_Memoleftoffset = A626MemoLeftOffset;
         obj100.gxTpr_Memotopoffset = A627MemoTopOffset;
         obj100.gxTpr_Memotitleangle = A628MemoTitleAngle;
         obj100.gxTpr_Memotitlescale = A629MemoTitleScale;
         obj100.gxTpr_Memotextfontname = A637MemoTextFontName;
         obj100.gxTpr_Memotextalignment = A638MemoTextAlignment;
         obj100.gxTpr_Memoisbold = A639MemoIsBold;
         obj100.gxTpr_Memoisitalic = A640MemoIsItalic;
         obj100.gxTpr_Memoiscapitalized = A641MemoIsCapitalized;
         obj100.gxTpr_Memotextcolor = A642MemoTextColor;
         obj100.gxTpr_Memoid = A549MemoId;
         obj100.gxTpr_Memoid_Z = Z549MemoId;
         obj100.gxTpr_Memotitle_Z = Z550MemoTitle;
         obj100.gxTpr_Memodescription_Z = Z551MemoDescription;
         obj100.gxTpr_Memodocument_Z = Z553MemoDocument;
         obj100.gxTpr_Memostartdatetime_Z = Z561MemoStartDateTime;
         obj100.gxTpr_Memoenddatetime_Z = Z562MemoEndDateTime;
         obj100.gxTpr_Memoduration_Z = Z563MemoDuration;
         obj100.gxTpr_Memoremovedate_Z = Z564MemoRemoveDate;
         obj100.gxTpr_Residentid_Z = Z62ResidentId;
         obj100.gxTpr_Residentsalutation_Z = Z72ResidentSalutation;
         obj100.gxTpr_Residentgivenname_Z = Z64ResidentGivenName;
         obj100.gxTpr_Residentlastname_Z = Z65ResidentLastName;
         obj100.gxTpr_Residentguid_Z = Z71ResidentGUID;
         obj100.gxTpr_Memobgcolorcode_Z = Z566MemoBgColorCode;
         obj100.gxTpr_Memoform_Z = Z567MemoForm;
         obj100.gxTpr_Sg_organisationid_Z = Z529SG_OrganisationId;
         obj100.gxTpr_Sg_locationid_Z = Z528SG_LocationId;
         obj100.gxTpr_Memotype_Z = Z624MemoType;
         obj100.gxTpr_Memoname_Z = Z625MemoName;
         obj100.gxTpr_Memoleftoffset_Z = Z626MemoLeftOffset;
         obj100.gxTpr_Memotopoffset_Z = Z627MemoTopOffset;
         obj100.gxTpr_Memotitleangle_Z = Z628MemoTitleAngle;
         obj100.gxTpr_Memotitlescale_Z = Z629MemoTitleScale;
         obj100.gxTpr_Memotextfontname_Z = Z637MemoTextFontName;
         obj100.gxTpr_Memotextalignment_Z = Z638MemoTextAlignment;
         obj100.gxTpr_Memoisbold_Z = Z639MemoIsBold;
         obj100.gxTpr_Memoisitalic_Z = Z640MemoIsItalic;
         obj100.gxTpr_Memoiscapitalized_Z = Z641MemoIsCapitalized;
         obj100.gxTpr_Memotextcolor_Z = Z642MemoTextColor;
         obj100.gxTpr_Memoimage_N = (short)(Convert.ToInt16(n552MemoImage));
         obj100.gxTpr_Memodocument_N = (short)(Convert.ToInt16(n553MemoDocument));
         obj100.gxTpr_Memostartdatetime_N = (short)(Convert.ToInt16(n561MemoStartDateTime));
         obj100.gxTpr_Memoenddatetime_N = (short)(Convert.ToInt16(n562MemoEndDateTime));
         obj100.gxTpr_Memoduration_N = (short)(Convert.ToInt16(n563MemoDuration));
         obj100.gxTpr_Memoremovedate_N = (short)(Convert.ToInt16(n564MemoRemoveDate));
         obj100.gxTpr_Memobgcolorcode_N = (short)(Convert.ToInt16(n566MemoBgColorCode));
         obj100.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow100( SdtTrn_Memo obj100 )
      {
         obj100.gxTpr_Memoid = A549MemoId;
         return  ;
      }

      public void RowToVars100( SdtTrn_Memo obj100 ,
                                int forceLoad )
      {
         Gx_mode = obj100.gxTpr_Mode;
         A550MemoTitle = obj100.gxTpr_Memotitle;
         A551MemoDescription = obj100.gxTpr_Memodescription;
         A552MemoImage = obj100.gxTpr_Memoimage;
         n552MemoImage = false;
         A553MemoDocument = obj100.gxTpr_Memodocument;
         n553MemoDocument = false;
         A561MemoStartDateTime = obj100.gxTpr_Memostartdatetime;
         n561MemoStartDateTime = false;
         A562MemoEndDateTime = obj100.gxTpr_Memoenddatetime;
         n562MemoEndDateTime = false;
         A563MemoDuration = obj100.gxTpr_Memoduration;
         n563MemoDuration = false;
         A564MemoRemoveDate = obj100.gxTpr_Memoremovedate;
         n564MemoRemoveDate = false;
         A62ResidentId = obj100.gxTpr_Residentid;
         A72ResidentSalutation = obj100.gxTpr_Residentsalutation;
         A64ResidentGivenName = obj100.gxTpr_Residentgivenname;
         A65ResidentLastName = obj100.gxTpr_Residentlastname;
         A71ResidentGUID = obj100.gxTpr_Residentguid;
         A566MemoBgColorCode = obj100.gxTpr_Memobgcolorcode;
         n566MemoBgColorCode = false;
         A567MemoForm = obj100.gxTpr_Memoform;
         A529SG_OrganisationId = obj100.gxTpr_Sg_organisationid;
         A528SG_LocationId = obj100.gxTpr_Sg_locationid;
         A624MemoType = obj100.gxTpr_Memotype;
         A625MemoName = obj100.gxTpr_Memoname;
         A626MemoLeftOffset = obj100.gxTpr_Memoleftoffset;
         A627MemoTopOffset = obj100.gxTpr_Memotopoffset;
         A628MemoTitleAngle = obj100.gxTpr_Memotitleangle;
         A629MemoTitleScale = obj100.gxTpr_Memotitlescale;
         A637MemoTextFontName = obj100.gxTpr_Memotextfontname;
         A638MemoTextAlignment = obj100.gxTpr_Memotextalignment;
         A639MemoIsBold = obj100.gxTpr_Memoisbold;
         A640MemoIsItalic = obj100.gxTpr_Memoisitalic;
         A641MemoIsCapitalized = obj100.gxTpr_Memoiscapitalized;
         A642MemoTextColor = obj100.gxTpr_Memotextcolor;
         A549MemoId = obj100.gxTpr_Memoid;
         Z549MemoId = obj100.gxTpr_Memoid_Z;
         Z550MemoTitle = obj100.gxTpr_Memotitle_Z;
         Z551MemoDescription = obj100.gxTpr_Memodescription_Z;
         Z553MemoDocument = obj100.gxTpr_Memodocument_Z;
         Z561MemoStartDateTime = obj100.gxTpr_Memostartdatetime_Z;
         Z562MemoEndDateTime = obj100.gxTpr_Memoenddatetime_Z;
         Z563MemoDuration = obj100.gxTpr_Memoduration_Z;
         Z564MemoRemoveDate = obj100.gxTpr_Memoremovedate_Z;
         Z62ResidentId = obj100.gxTpr_Residentid_Z;
         Z72ResidentSalutation = obj100.gxTpr_Residentsalutation_Z;
         Z64ResidentGivenName = obj100.gxTpr_Residentgivenname_Z;
         Z65ResidentLastName = obj100.gxTpr_Residentlastname_Z;
         Z71ResidentGUID = obj100.gxTpr_Residentguid_Z;
         Z566MemoBgColorCode = obj100.gxTpr_Memobgcolorcode_Z;
         Z567MemoForm = obj100.gxTpr_Memoform_Z;
         Z529SG_OrganisationId = obj100.gxTpr_Sg_organisationid_Z;
         Z528SG_LocationId = obj100.gxTpr_Sg_locationid_Z;
         Z624MemoType = obj100.gxTpr_Memotype_Z;
         Z625MemoName = obj100.gxTpr_Memoname_Z;
         Z626MemoLeftOffset = obj100.gxTpr_Memoleftoffset_Z;
         Z627MemoTopOffset = obj100.gxTpr_Memotopoffset_Z;
         Z628MemoTitleAngle = obj100.gxTpr_Memotitleangle_Z;
         Z629MemoTitleScale = obj100.gxTpr_Memotitlescale_Z;
         Z637MemoTextFontName = obj100.gxTpr_Memotextfontname_Z;
         Z638MemoTextAlignment = obj100.gxTpr_Memotextalignment_Z;
         Z639MemoIsBold = obj100.gxTpr_Memoisbold_Z;
         Z640MemoIsItalic = obj100.gxTpr_Memoisitalic_Z;
         Z641MemoIsCapitalized = obj100.gxTpr_Memoiscapitalized_Z;
         Z642MemoTextColor = obj100.gxTpr_Memotextcolor_Z;
         n552MemoImage = (bool)(Convert.ToBoolean(obj100.gxTpr_Memoimage_N));
         n553MemoDocument = (bool)(Convert.ToBoolean(obj100.gxTpr_Memodocument_N));
         n561MemoStartDateTime = (bool)(Convert.ToBoolean(obj100.gxTpr_Memostartdatetime_N));
         n562MemoEndDateTime = (bool)(Convert.ToBoolean(obj100.gxTpr_Memoenddatetime_N));
         n563MemoDuration = (bool)(Convert.ToBoolean(obj100.gxTpr_Memoduration_N));
         n564MemoRemoveDate = (bool)(Convert.ToBoolean(obj100.gxTpr_Memoremovedate_N));
         n566MemoBgColorCode = (bool)(Convert.ToBoolean(obj100.gxTpr_Memobgcolorcode_N));
         Gx_mode = obj100.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A549MemoId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1P100( ) ;
         ScanKeyStart1P100( ) ;
         if ( RcdFound100 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z549MemoId = A549MemoId;
         }
         ZM1P100( -9) ;
         OnLoadActions1P100( ) ;
         AddRow1P100( ) ;
         ScanKeyEnd1P100( ) ;
         if ( RcdFound100 == 0 )
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
         RowToVars100( bcTrn_Memo, 0) ;
         ScanKeyStart1P100( ) ;
         if ( RcdFound100 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z549MemoId = A549MemoId;
         }
         ZM1P100( -9) ;
         OnLoadActions1P100( ) ;
         AddRow1P100( ) ;
         ScanKeyEnd1P100( ) ;
         if ( RcdFound100 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1P100( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1P100( ) ;
         }
         else
         {
            if ( RcdFound100 == 1 )
            {
               if ( A549MemoId != Z549MemoId )
               {
                  A549MemoId = Z549MemoId;
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
                  Update1P100( ) ;
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
                  if ( A549MemoId != Z549MemoId )
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
                        Insert1P100( ) ;
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
                        Insert1P100( ) ;
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
         RowToVars100( bcTrn_Memo, 1) ;
         SaveImpl( ) ;
         VarsToRow100( bcTrn_Memo) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars100( bcTrn_Memo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1P100( ) ;
         AfterTrn( ) ;
         VarsToRow100( bcTrn_Memo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow100( bcTrn_Memo) ;
         }
         else
         {
            SdtTrn_Memo auxBC = new SdtTrn_Memo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A549MemoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_Memo);
               auxBC.Save();
               bcTrn_Memo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars100( bcTrn_Memo, 1) ;
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
         RowToVars100( bcTrn_Memo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1P100( ) ;
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
               VarsToRow100( bcTrn_Memo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow100( bcTrn_Memo) ;
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
         RowToVars100( bcTrn_Memo, 0) ;
         GetKey1P100( ) ;
         if ( RcdFound100 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A549MemoId != Z549MemoId )
            {
               A549MemoId = Z549MemoId;
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
            if ( A549MemoId != Z549MemoId )
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
         context.RollbackDataStores("trn_memo_bc",pr_default);
         VarsToRow100( bcTrn_Memo) ;
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
         Gx_mode = bcTrn_Memo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_Memo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_Memo )
         {
            bcTrn_Memo = (SdtTrn_Memo)(sdt);
            if ( StringUtil.StrCmp(bcTrn_Memo.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Memo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow100( bcTrn_Memo) ;
            }
            else
            {
               RowToVars100( bcTrn_Memo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_Memo.gxTpr_Mode, "") == 0 )
            {
               bcTrn_Memo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars100( bcTrn_Memo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_Memo Trn_Memo_BC
      {
         get {
            return bcTrn_Memo ;
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
            return "trn_memo_Execute" ;
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
         pr_default.close(8);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z549MemoId = Guid.Empty;
         A549MemoId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV31Pgmname = "";
         AV15TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV26Insert_ResidentId = Guid.Empty;
         AV29Insert_SG_OrganisationId = Guid.Empty;
         AV30Insert_SG_LocationId = Guid.Empty;
         Z550MemoTitle = "";
         A550MemoTitle = "";
         Z551MemoDescription = "";
         A551MemoDescription = "";
         Z553MemoDocument = "";
         A553MemoDocument = "";
         Z561MemoStartDateTime = (DateTime)(DateTime.MinValue);
         A561MemoStartDateTime = (DateTime)(DateTime.MinValue);
         Z562MemoEndDateTime = (DateTime)(DateTime.MinValue);
         A562MemoEndDateTime = (DateTime)(DateTime.MinValue);
         Z564MemoRemoveDate = DateTime.MinValue;
         A564MemoRemoveDate = DateTime.MinValue;
         Z566MemoBgColorCode = "";
         A566MemoBgColorCode = "";
         Z567MemoForm = "";
         A567MemoForm = "";
         Z624MemoType = "";
         A624MemoType = "";
         Z625MemoName = "";
         A625MemoName = "";
         Z637MemoTextFontName = "";
         A637MemoTextFontName = "";
         Z638MemoTextAlignment = "";
         A638MemoTextAlignment = "";
         Z642MemoTextColor = "";
         A642MemoTextColor = "";
         Z62ResidentId = Guid.Empty;
         A62ResidentId = Guid.Empty;
         Z528SG_LocationId = Guid.Empty;
         A528SG_LocationId = Guid.Empty;
         Z529SG_OrganisationId = Guid.Empty;
         A529SG_OrganisationId = Guid.Empty;
         Z72ResidentSalutation = "";
         A72ResidentSalutation = "";
         Z64ResidentGivenName = "";
         A64ResidentGivenName = "";
         Z65ResidentLastName = "";
         A65ResidentLastName = "";
         Z71ResidentGUID = "";
         A71ResidentGUID = "";
         Z552MemoImage = "";
         A552MemoImage = "";
         Z29LocationId = Guid.Empty;
         A29LocationId = Guid.Empty;
         Z11OrganisationId = Guid.Empty;
         A11OrganisationId = Guid.Empty;
         BC001P5_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001P5_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001P5_A549MemoId = new Guid[] {Guid.Empty} ;
         BC001P5_A550MemoTitle = new string[] {""} ;
         BC001P5_A551MemoDescription = new string[] {""} ;
         BC001P5_A552MemoImage = new string[] {""} ;
         BC001P5_n552MemoImage = new bool[] {false} ;
         BC001P5_A553MemoDocument = new string[] {""} ;
         BC001P5_n553MemoDocument = new bool[] {false} ;
         BC001P5_A561MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001P5_n561MemoStartDateTime = new bool[] {false} ;
         BC001P5_A562MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001P5_n562MemoEndDateTime = new bool[] {false} ;
         BC001P5_A563MemoDuration = new decimal[1] ;
         BC001P5_n563MemoDuration = new bool[] {false} ;
         BC001P5_A564MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         BC001P5_n564MemoRemoveDate = new bool[] {false} ;
         BC001P5_A72ResidentSalutation = new string[] {""} ;
         BC001P5_A64ResidentGivenName = new string[] {""} ;
         BC001P5_A65ResidentLastName = new string[] {""} ;
         BC001P5_A71ResidentGUID = new string[] {""} ;
         BC001P5_A566MemoBgColorCode = new string[] {""} ;
         BC001P5_n566MemoBgColorCode = new bool[] {false} ;
         BC001P5_A567MemoForm = new string[] {""} ;
         BC001P5_A624MemoType = new string[] {""} ;
         BC001P5_A625MemoName = new string[] {""} ;
         BC001P5_A626MemoLeftOffset = new decimal[1] ;
         BC001P5_A627MemoTopOffset = new decimal[1] ;
         BC001P5_A628MemoTitleAngle = new decimal[1] ;
         BC001P5_A629MemoTitleScale = new decimal[1] ;
         BC001P5_A637MemoTextFontName = new string[] {""} ;
         BC001P5_A638MemoTextAlignment = new string[] {""} ;
         BC001P5_A639MemoIsBold = new bool[] {false} ;
         BC001P5_A640MemoIsItalic = new bool[] {false} ;
         BC001P5_A641MemoIsCapitalized = new bool[] {false} ;
         BC001P5_A642MemoTextColor = new string[] {""} ;
         BC001P5_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001P5_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001P5_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         BC001P4_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001P4_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001P4_A72ResidentSalutation = new string[] {""} ;
         BC001P4_A64ResidentGivenName = new string[] {""} ;
         BC001P4_A65ResidentLastName = new string[] {""} ;
         BC001P4_A71ResidentGUID = new string[] {""} ;
         BC001P6_A549MemoId = new Guid[] {Guid.Empty} ;
         BC001P3_A549MemoId = new Guid[] {Guid.Empty} ;
         BC001P3_A550MemoTitle = new string[] {""} ;
         BC001P3_A551MemoDescription = new string[] {""} ;
         BC001P3_A552MemoImage = new string[] {""} ;
         BC001P3_n552MemoImage = new bool[] {false} ;
         BC001P3_A553MemoDocument = new string[] {""} ;
         BC001P3_n553MemoDocument = new bool[] {false} ;
         BC001P3_A561MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001P3_n561MemoStartDateTime = new bool[] {false} ;
         BC001P3_A562MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001P3_n562MemoEndDateTime = new bool[] {false} ;
         BC001P3_A563MemoDuration = new decimal[1] ;
         BC001P3_n563MemoDuration = new bool[] {false} ;
         BC001P3_A564MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         BC001P3_n564MemoRemoveDate = new bool[] {false} ;
         BC001P3_A566MemoBgColorCode = new string[] {""} ;
         BC001P3_n566MemoBgColorCode = new bool[] {false} ;
         BC001P3_A567MemoForm = new string[] {""} ;
         BC001P3_A624MemoType = new string[] {""} ;
         BC001P3_A625MemoName = new string[] {""} ;
         BC001P3_A626MemoLeftOffset = new decimal[1] ;
         BC001P3_A627MemoTopOffset = new decimal[1] ;
         BC001P3_A628MemoTitleAngle = new decimal[1] ;
         BC001P3_A629MemoTitleScale = new decimal[1] ;
         BC001P3_A637MemoTextFontName = new string[] {""} ;
         BC001P3_A638MemoTextAlignment = new string[] {""} ;
         BC001P3_A639MemoIsBold = new bool[] {false} ;
         BC001P3_A640MemoIsItalic = new bool[] {false} ;
         BC001P3_A641MemoIsCapitalized = new bool[] {false} ;
         BC001P3_A642MemoTextColor = new string[] {""} ;
         BC001P3_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001P3_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001P3_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         sMode100 = "";
         BC001P2_A549MemoId = new Guid[] {Guid.Empty} ;
         BC001P2_A550MemoTitle = new string[] {""} ;
         BC001P2_A551MemoDescription = new string[] {""} ;
         BC001P2_A552MemoImage = new string[] {""} ;
         BC001P2_n552MemoImage = new bool[] {false} ;
         BC001P2_A553MemoDocument = new string[] {""} ;
         BC001P2_n553MemoDocument = new bool[] {false} ;
         BC001P2_A561MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001P2_n561MemoStartDateTime = new bool[] {false} ;
         BC001P2_A562MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001P2_n562MemoEndDateTime = new bool[] {false} ;
         BC001P2_A563MemoDuration = new decimal[1] ;
         BC001P2_n563MemoDuration = new bool[] {false} ;
         BC001P2_A564MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         BC001P2_n564MemoRemoveDate = new bool[] {false} ;
         BC001P2_A566MemoBgColorCode = new string[] {""} ;
         BC001P2_n566MemoBgColorCode = new bool[] {false} ;
         BC001P2_A567MemoForm = new string[] {""} ;
         BC001P2_A624MemoType = new string[] {""} ;
         BC001P2_A625MemoName = new string[] {""} ;
         BC001P2_A626MemoLeftOffset = new decimal[1] ;
         BC001P2_A627MemoTopOffset = new decimal[1] ;
         BC001P2_A628MemoTitleAngle = new decimal[1] ;
         BC001P2_A629MemoTitleScale = new decimal[1] ;
         BC001P2_A637MemoTextFontName = new string[] {""} ;
         BC001P2_A638MemoTextAlignment = new string[] {""} ;
         BC001P2_A639MemoIsBold = new bool[] {false} ;
         BC001P2_A640MemoIsItalic = new bool[] {false} ;
         BC001P2_A641MemoIsCapitalized = new bool[] {false} ;
         BC001P2_A642MemoTextColor = new string[] {""} ;
         BC001P2_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001P2_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001P2_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         BC001P10_A72ResidentSalutation = new string[] {""} ;
         BC001P10_A64ResidentGivenName = new string[] {""} ;
         BC001P10_A65ResidentLastName = new string[] {""} ;
         BC001P10_A71ResidentGUID = new string[] {""} ;
         BC001P11_A29LocationId = new Guid[] {Guid.Empty} ;
         BC001P11_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC001P11_A549MemoId = new Guid[] {Guid.Empty} ;
         BC001P11_A550MemoTitle = new string[] {""} ;
         BC001P11_A551MemoDescription = new string[] {""} ;
         BC001P11_A552MemoImage = new string[] {""} ;
         BC001P11_n552MemoImage = new bool[] {false} ;
         BC001P11_A553MemoDocument = new string[] {""} ;
         BC001P11_n553MemoDocument = new bool[] {false} ;
         BC001P11_A561MemoStartDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001P11_n561MemoStartDateTime = new bool[] {false} ;
         BC001P11_A562MemoEndDateTime = new DateTime[] {DateTime.MinValue} ;
         BC001P11_n562MemoEndDateTime = new bool[] {false} ;
         BC001P11_A563MemoDuration = new decimal[1] ;
         BC001P11_n563MemoDuration = new bool[] {false} ;
         BC001P11_A564MemoRemoveDate = new DateTime[] {DateTime.MinValue} ;
         BC001P11_n564MemoRemoveDate = new bool[] {false} ;
         BC001P11_A72ResidentSalutation = new string[] {""} ;
         BC001P11_A64ResidentGivenName = new string[] {""} ;
         BC001P11_A65ResidentLastName = new string[] {""} ;
         BC001P11_A71ResidentGUID = new string[] {""} ;
         BC001P11_A566MemoBgColorCode = new string[] {""} ;
         BC001P11_n566MemoBgColorCode = new bool[] {false} ;
         BC001P11_A567MemoForm = new string[] {""} ;
         BC001P11_A624MemoType = new string[] {""} ;
         BC001P11_A625MemoName = new string[] {""} ;
         BC001P11_A626MemoLeftOffset = new decimal[1] ;
         BC001P11_A627MemoTopOffset = new decimal[1] ;
         BC001P11_A628MemoTitleAngle = new decimal[1] ;
         BC001P11_A629MemoTitleScale = new decimal[1] ;
         BC001P11_A637MemoTextFontName = new string[] {""} ;
         BC001P11_A638MemoTextAlignment = new string[] {""} ;
         BC001P11_A639MemoIsBold = new bool[] {false} ;
         BC001P11_A640MemoIsItalic = new bool[] {false} ;
         BC001P11_A641MemoIsCapitalized = new bool[] {false} ;
         BC001P11_A642MemoTextColor = new string[] {""} ;
         BC001P11_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC001P11_A528SG_LocationId = new Guid[] {Guid.Empty} ;
         BC001P11_A529SG_OrganisationId = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_memo_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_memo_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_memo_bc__default(),
            new Object[][] {
                new Object[] {
               BC001P2_A549MemoId, BC001P2_A550MemoTitle, BC001P2_A551MemoDescription, BC001P2_A552MemoImage, BC001P2_n552MemoImage, BC001P2_A553MemoDocument, BC001P2_n553MemoDocument, BC001P2_A561MemoStartDateTime, BC001P2_n561MemoStartDateTime, BC001P2_A562MemoEndDateTime,
               BC001P2_n562MemoEndDateTime, BC001P2_A563MemoDuration, BC001P2_n563MemoDuration, BC001P2_A564MemoRemoveDate, BC001P2_n564MemoRemoveDate, BC001P2_A566MemoBgColorCode, BC001P2_n566MemoBgColorCode, BC001P2_A567MemoForm, BC001P2_A624MemoType, BC001P2_A625MemoName,
               BC001P2_A626MemoLeftOffset, BC001P2_A627MemoTopOffset, BC001P2_A628MemoTitleAngle, BC001P2_A629MemoTitleScale, BC001P2_A637MemoTextFontName, BC001P2_A638MemoTextAlignment, BC001P2_A639MemoIsBold, BC001P2_A640MemoIsItalic, BC001P2_A641MemoIsCapitalized, BC001P2_A642MemoTextColor,
               BC001P2_A62ResidentId, BC001P2_A528SG_LocationId, BC001P2_A529SG_OrganisationId
               }
               , new Object[] {
               BC001P3_A549MemoId, BC001P3_A550MemoTitle, BC001P3_A551MemoDescription, BC001P3_A552MemoImage, BC001P3_n552MemoImage, BC001P3_A553MemoDocument, BC001P3_n553MemoDocument, BC001P3_A561MemoStartDateTime, BC001P3_n561MemoStartDateTime, BC001P3_A562MemoEndDateTime,
               BC001P3_n562MemoEndDateTime, BC001P3_A563MemoDuration, BC001P3_n563MemoDuration, BC001P3_A564MemoRemoveDate, BC001P3_n564MemoRemoveDate, BC001P3_A566MemoBgColorCode, BC001P3_n566MemoBgColorCode, BC001P3_A567MemoForm, BC001P3_A624MemoType, BC001P3_A625MemoName,
               BC001P3_A626MemoLeftOffset, BC001P3_A627MemoTopOffset, BC001P3_A628MemoTitleAngle, BC001P3_A629MemoTitleScale, BC001P3_A637MemoTextFontName, BC001P3_A638MemoTextAlignment, BC001P3_A639MemoIsBold, BC001P3_A640MemoIsItalic, BC001P3_A641MemoIsCapitalized, BC001P3_A642MemoTextColor,
               BC001P3_A62ResidentId, BC001P3_A528SG_LocationId, BC001P3_A529SG_OrganisationId
               }
               , new Object[] {
               BC001P4_A29LocationId, BC001P4_A11OrganisationId, BC001P4_A72ResidentSalutation, BC001P4_A64ResidentGivenName, BC001P4_A65ResidentLastName, BC001P4_A71ResidentGUID
               }
               , new Object[] {
               BC001P5_A29LocationId, BC001P5_A11OrganisationId, BC001P5_A549MemoId, BC001P5_A550MemoTitle, BC001P5_A551MemoDescription, BC001P5_A552MemoImage, BC001P5_n552MemoImage, BC001P5_A553MemoDocument, BC001P5_n553MemoDocument, BC001P5_A561MemoStartDateTime,
               BC001P5_n561MemoStartDateTime, BC001P5_A562MemoEndDateTime, BC001P5_n562MemoEndDateTime, BC001P5_A563MemoDuration, BC001P5_n563MemoDuration, BC001P5_A564MemoRemoveDate, BC001P5_n564MemoRemoveDate, BC001P5_A72ResidentSalutation, BC001P5_A64ResidentGivenName, BC001P5_A65ResidentLastName,
               BC001P5_A71ResidentGUID, BC001P5_A566MemoBgColorCode, BC001P5_n566MemoBgColorCode, BC001P5_A567MemoForm, BC001P5_A624MemoType, BC001P5_A625MemoName, BC001P5_A626MemoLeftOffset, BC001P5_A627MemoTopOffset, BC001P5_A628MemoTitleAngle, BC001P5_A629MemoTitleScale,
               BC001P5_A637MemoTextFontName, BC001P5_A638MemoTextAlignment, BC001P5_A639MemoIsBold, BC001P5_A640MemoIsItalic, BC001P5_A641MemoIsCapitalized, BC001P5_A642MemoTextColor, BC001P5_A62ResidentId, BC001P5_A528SG_LocationId, BC001P5_A529SG_OrganisationId
               }
               , new Object[] {
               BC001P6_A549MemoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001P10_A72ResidentSalutation, BC001P10_A64ResidentGivenName, BC001P10_A65ResidentLastName, BC001P10_A71ResidentGUID
               }
               , new Object[] {
               BC001P11_A29LocationId, BC001P11_A11OrganisationId, BC001P11_A549MemoId, BC001P11_A550MemoTitle, BC001P11_A551MemoDescription, BC001P11_A552MemoImage, BC001P11_n552MemoImage, BC001P11_A553MemoDocument, BC001P11_n553MemoDocument, BC001P11_A561MemoStartDateTime,
               BC001P11_n561MemoStartDateTime, BC001P11_A562MemoEndDateTime, BC001P11_n562MemoEndDateTime, BC001P11_A563MemoDuration, BC001P11_n563MemoDuration, BC001P11_A564MemoRemoveDate, BC001P11_n564MemoRemoveDate, BC001P11_A72ResidentSalutation, BC001P11_A64ResidentGivenName, BC001P11_A65ResidentLastName,
               BC001P11_A71ResidentGUID, BC001P11_A566MemoBgColorCode, BC001P11_n566MemoBgColorCode, BC001P11_A567MemoForm, BC001P11_A624MemoType, BC001P11_A625MemoName, BC001P11_A626MemoLeftOffset, BC001P11_A627MemoTopOffset, BC001P11_A628MemoTitleAngle, BC001P11_A629MemoTitleScale,
               BC001P11_A637MemoTextFontName, BC001P11_A638MemoTextAlignment, BC001P11_A639MemoIsBold, BC001P11_A640MemoIsItalic, BC001P11_A641MemoIsCapitalized, BC001P11_A642MemoTextColor, BC001P11_A62ResidentId, BC001P11_A528SG_LocationId, BC001P11_A529SG_OrganisationId
               }
            }
         );
         Z549MemoId = Guid.NewGuid( );
         A549MemoId = Guid.NewGuid( );
         AV31Pgmname = "Trn_Memo_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121P2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound100 ;
      private int trnEnded ;
      private int AV32GXV1 ;
      private decimal Z563MemoDuration ;
      private decimal A563MemoDuration ;
      private decimal Z626MemoLeftOffset ;
      private decimal A626MemoLeftOffset ;
      private decimal Z627MemoTopOffset ;
      private decimal A627MemoTopOffset ;
      private decimal Z628MemoTitleAngle ;
      private decimal A628MemoTitleAngle ;
      private decimal Z629MemoTitleScale ;
      private decimal A629MemoTitleScale ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV31Pgmname ;
      private string Z567MemoForm ;
      private string A567MemoForm ;
      private string Z638MemoTextAlignment ;
      private string A638MemoTextAlignment ;
      private string Z72ResidentSalutation ;
      private string A72ResidentSalutation ;
      private string sMode100 ;
      private DateTime Z561MemoStartDateTime ;
      private DateTime A561MemoStartDateTime ;
      private DateTime Z562MemoEndDateTime ;
      private DateTime A562MemoEndDateTime ;
      private DateTime Z564MemoRemoveDate ;
      private DateTime A564MemoRemoveDate ;
      private bool returnInSub ;
      private bool Z639MemoIsBold ;
      private bool A639MemoIsBold ;
      private bool Z640MemoIsItalic ;
      private bool A640MemoIsItalic ;
      private bool Z641MemoIsCapitalized ;
      private bool A641MemoIsCapitalized ;
      private bool n552MemoImage ;
      private bool n553MemoDocument ;
      private bool n561MemoStartDateTime ;
      private bool n562MemoEndDateTime ;
      private bool n563MemoDuration ;
      private bool n564MemoRemoveDate ;
      private bool n566MemoBgColorCode ;
      private bool Gx_longc ;
      private string Z552MemoImage ;
      private string A552MemoImage ;
      private string Z550MemoTitle ;
      private string A550MemoTitle ;
      private string Z551MemoDescription ;
      private string A551MemoDescription ;
      private string Z553MemoDocument ;
      private string A553MemoDocument ;
      private string Z566MemoBgColorCode ;
      private string A566MemoBgColorCode ;
      private string Z624MemoType ;
      private string A624MemoType ;
      private string Z625MemoName ;
      private string A625MemoName ;
      private string Z637MemoTextFontName ;
      private string A637MemoTextFontName ;
      private string Z642MemoTextColor ;
      private string A642MemoTextColor ;
      private string Z64ResidentGivenName ;
      private string A64ResidentGivenName ;
      private string Z65ResidentLastName ;
      private string A65ResidentLastName ;
      private string Z71ResidentGUID ;
      private string A71ResidentGUID ;
      private Guid Z549MemoId ;
      private Guid A549MemoId ;
      private Guid AV26Insert_ResidentId ;
      private Guid AV29Insert_SG_OrganisationId ;
      private Guid AV30Insert_SG_LocationId ;
      private Guid Z62ResidentId ;
      private Guid A62ResidentId ;
      private Guid Z528SG_LocationId ;
      private Guid A528SG_LocationId ;
      private Guid Z529SG_OrganisationId ;
      private Guid A529SG_OrganisationId ;
      private Guid Z29LocationId ;
      private Guid A29LocationId ;
      private Guid Z11OrganisationId ;
      private Guid A11OrganisationId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001P5_A29LocationId ;
      private Guid[] BC001P5_A11OrganisationId ;
      private Guid[] BC001P5_A549MemoId ;
      private string[] BC001P5_A550MemoTitle ;
      private string[] BC001P5_A551MemoDescription ;
      private string[] BC001P5_A552MemoImage ;
      private bool[] BC001P5_n552MemoImage ;
      private string[] BC001P5_A553MemoDocument ;
      private bool[] BC001P5_n553MemoDocument ;
      private DateTime[] BC001P5_A561MemoStartDateTime ;
      private bool[] BC001P5_n561MemoStartDateTime ;
      private DateTime[] BC001P5_A562MemoEndDateTime ;
      private bool[] BC001P5_n562MemoEndDateTime ;
      private decimal[] BC001P5_A563MemoDuration ;
      private bool[] BC001P5_n563MemoDuration ;
      private DateTime[] BC001P5_A564MemoRemoveDate ;
      private bool[] BC001P5_n564MemoRemoveDate ;
      private string[] BC001P5_A72ResidentSalutation ;
      private string[] BC001P5_A64ResidentGivenName ;
      private string[] BC001P5_A65ResidentLastName ;
      private string[] BC001P5_A71ResidentGUID ;
      private string[] BC001P5_A566MemoBgColorCode ;
      private bool[] BC001P5_n566MemoBgColorCode ;
      private string[] BC001P5_A567MemoForm ;
      private string[] BC001P5_A624MemoType ;
      private string[] BC001P5_A625MemoName ;
      private decimal[] BC001P5_A626MemoLeftOffset ;
      private decimal[] BC001P5_A627MemoTopOffset ;
      private decimal[] BC001P5_A628MemoTitleAngle ;
      private decimal[] BC001P5_A629MemoTitleScale ;
      private string[] BC001P5_A637MemoTextFontName ;
      private string[] BC001P5_A638MemoTextAlignment ;
      private bool[] BC001P5_A639MemoIsBold ;
      private bool[] BC001P5_A640MemoIsItalic ;
      private bool[] BC001P5_A641MemoIsCapitalized ;
      private string[] BC001P5_A642MemoTextColor ;
      private Guid[] BC001P5_A62ResidentId ;
      private Guid[] BC001P5_A528SG_LocationId ;
      private Guid[] BC001P5_A529SG_OrganisationId ;
      private Guid[] BC001P4_A29LocationId ;
      private Guid[] BC001P4_A11OrganisationId ;
      private string[] BC001P4_A72ResidentSalutation ;
      private string[] BC001P4_A64ResidentGivenName ;
      private string[] BC001P4_A65ResidentLastName ;
      private string[] BC001P4_A71ResidentGUID ;
      private Guid[] BC001P6_A549MemoId ;
      private Guid[] BC001P3_A549MemoId ;
      private string[] BC001P3_A550MemoTitle ;
      private string[] BC001P3_A551MemoDescription ;
      private string[] BC001P3_A552MemoImage ;
      private bool[] BC001P3_n552MemoImage ;
      private string[] BC001P3_A553MemoDocument ;
      private bool[] BC001P3_n553MemoDocument ;
      private DateTime[] BC001P3_A561MemoStartDateTime ;
      private bool[] BC001P3_n561MemoStartDateTime ;
      private DateTime[] BC001P3_A562MemoEndDateTime ;
      private bool[] BC001P3_n562MemoEndDateTime ;
      private decimal[] BC001P3_A563MemoDuration ;
      private bool[] BC001P3_n563MemoDuration ;
      private DateTime[] BC001P3_A564MemoRemoveDate ;
      private bool[] BC001P3_n564MemoRemoveDate ;
      private string[] BC001P3_A566MemoBgColorCode ;
      private bool[] BC001P3_n566MemoBgColorCode ;
      private string[] BC001P3_A567MemoForm ;
      private string[] BC001P3_A624MemoType ;
      private string[] BC001P3_A625MemoName ;
      private decimal[] BC001P3_A626MemoLeftOffset ;
      private decimal[] BC001P3_A627MemoTopOffset ;
      private decimal[] BC001P3_A628MemoTitleAngle ;
      private decimal[] BC001P3_A629MemoTitleScale ;
      private string[] BC001P3_A637MemoTextFontName ;
      private string[] BC001P3_A638MemoTextAlignment ;
      private bool[] BC001P3_A639MemoIsBold ;
      private bool[] BC001P3_A640MemoIsItalic ;
      private bool[] BC001P3_A641MemoIsCapitalized ;
      private string[] BC001P3_A642MemoTextColor ;
      private Guid[] BC001P3_A62ResidentId ;
      private Guid[] BC001P3_A528SG_LocationId ;
      private Guid[] BC001P3_A529SG_OrganisationId ;
      private Guid[] BC001P2_A549MemoId ;
      private string[] BC001P2_A550MemoTitle ;
      private string[] BC001P2_A551MemoDescription ;
      private string[] BC001P2_A552MemoImage ;
      private bool[] BC001P2_n552MemoImage ;
      private string[] BC001P2_A553MemoDocument ;
      private bool[] BC001P2_n553MemoDocument ;
      private DateTime[] BC001P2_A561MemoStartDateTime ;
      private bool[] BC001P2_n561MemoStartDateTime ;
      private DateTime[] BC001P2_A562MemoEndDateTime ;
      private bool[] BC001P2_n562MemoEndDateTime ;
      private decimal[] BC001P2_A563MemoDuration ;
      private bool[] BC001P2_n563MemoDuration ;
      private DateTime[] BC001P2_A564MemoRemoveDate ;
      private bool[] BC001P2_n564MemoRemoveDate ;
      private string[] BC001P2_A566MemoBgColorCode ;
      private bool[] BC001P2_n566MemoBgColorCode ;
      private string[] BC001P2_A567MemoForm ;
      private string[] BC001P2_A624MemoType ;
      private string[] BC001P2_A625MemoName ;
      private decimal[] BC001P2_A626MemoLeftOffset ;
      private decimal[] BC001P2_A627MemoTopOffset ;
      private decimal[] BC001P2_A628MemoTitleAngle ;
      private decimal[] BC001P2_A629MemoTitleScale ;
      private string[] BC001P2_A637MemoTextFontName ;
      private string[] BC001P2_A638MemoTextAlignment ;
      private bool[] BC001P2_A639MemoIsBold ;
      private bool[] BC001P2_A640MemoIsItalic ;
      private bool[] BC001P2_A641MemoIsCapitalized ;
      private string[] BC001P2_A642MemoTextColor ;
      private Guid[] BC001P2_A62ResidentId ;
      private Guid[] BC001P2_A528SG_LocationId ;
      private Guid[] BC001P2_A529SG_OrganisationId ;
      private string[] BC001P10_A72ResidentSalutation ;
      private string[] BC001P10_A64ResidentGivenName ;
      private string[] BC001P10_A65ResidentLastName ;
      private string[] BC001P10_A71ResidentGUID ;
      private Guid[] BC001P11_A29LocationId ;
      private Guid[] BC001P11_A11OrganisationId ;
      private Guid[] BC001P11_A549MemoId ;
      private string[] BC001P11_A550MemoTitle ;
      private string[] BC001P11_A551MemoDescription ;
      private string[] BC001P11_A552MemoImage ;
      private bool[] BC001P11_n552MemoImage ;
      private string[] BC001P11_A553MemoDocument ;
      private bool[] BC001P11_n553MemoDocument ;
      private DateTime[] BC001P11_A561MemoStartDateTime ;
      private bool[] BC001P11_n561MemoStartDateTime ;
      private DateTime[] BC001P11_A562MemoEndDateTime ;
      private bool[] BC001P11_n562MemoEndDateTime ;
      private decimal[] BC001P11_A563MemoDuration ;
      private bool[] BC001P11_n563MemoDuration ;
      private DateTime[] BC001P11_A564MemoRemoveDate ;
      private bool[] BC001P11_n564MemoRemoveDate ;
      private string[] BC001P11_A72ResidentSalutation ;
      private string[] BC001P11_A64ResidentGivenName ;
      private string[] BC001P11_A65ResidentLastName ;
      private string[] BC001P11_A71ResidentGUID ;
      private string[] BC001P11_A566MemoBgColorCode ;
      private bool[] BC001P11_n566MemoBgColorCode ;
      private string[] BC001P11_A567MemoForm ;
      private string[] BC001P11_A624MemoType ;
      private string[] BC001P11_A625MemoName ;
      private decimal[] BC001P11_A626MemoLeftOffset ;
      private decimal[] BC001P11_A627MemoTopOffset ;
      private decimal[] BC001P11_A628MemoTitleAngle ;
      private decimal[] BC001P11_A629MemoTitleScale ;
      private string[] BC001P11_A637MemoTextFontName ;
      private string[] BC001P11_A638MemoTextAlignment ;
      private bool[] BC001P11_A639MemoIsBold ;
      private bool[] BC001P11_A640MemoIsItalic ;
      private bool[] BC001P11_A641MemoIsCapitalized ;
      private string[] BC001P11_A642MemoTextColor ;
      private Guid[] BC001P11_A62ResidentId ;
      private Guid[] BC001P11_A528SG_LocationId ;
      private Guid[] BC001P11_A529SG_OrganisationId ;
      private SdtTrn_Memo bcTrn_Memo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_memo_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_memo_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_memo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC001P2;
       prmBC001P2 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001P3;
       prmBC001P3 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001P4;
       prmBC001P4 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001P5;
       prmBC001P5 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001P6;
       prmBC001P6 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001P7;
       prmBC001P7 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MemoTitle",GXType.VarChar,100,0) ,
       new ParDef("MemoDescription",GXType.VarChar,200,0) ,
       new ParDef("MemoImage",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("MemoDocument",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("MemoStartDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoEndDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoDuration",GXType.Number,6,3){Nullable=true} ,
       new ParDef("MemoRemoveDate",GXType.Date,8,0){Nullable=true} ,
       new ParDef("MemoBgColorCode",GXType.VarChar,100,0){Nullable=true} ,
       new ParDef("MemoForm",GXType.Char,20,0) ,
       new ParDef("MemoType",GXType.VarChar,100,0) ,
       new ParDef("MemoName",GXType.VarChar,100,0) ,
       new ParDef("MemoLeftOffset",GXType.Number,6,3) ,
       new ParDef("MemoTopOffset",GXType.Number,6,3) ,
       new ParDef("MemoTitleAngle",GXType.Number,6,3) ,
       new ParDef("MemoTitleScale",GXType.Number,6,3) ,
       new ParDef("MemoTextFontName",GXType.VarChar,100,0) ,
       new ParDef("MemoTextAlignment",GXType.Char,20,0) ,
       new ParDef("MemoIsBold",GXType.Boolean,4,0) ,
       new ParDef("MemoIsItalic",GXType.Boolean,4,0) ,
       new ParDef("MemoIsCapitalized",GXType.Boolean,4,0) ,
       new ParDef("MemoTextColor",GXType.VarChar,40,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001P8;
       prmBC001P8 = new Object[] {
       new ParDef("MemoTitle",GXType.VarChar,100,0) ,
       new ParDef("MemoDescription",GXType.VarChar,200,0) ,
       new ParDef("MemoImage",GXType.LongVarChar,2097152,0){Nullable=true} ,
       new ParDef("MemoDocument",GXType.VarChar,200,0){Nullable=true} ,
       new ParDef("MemoStartDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoEndDateTime",GXType.DateTime,8,5){Nullable=true} ,
       new ParDef("MemoDuration",GXType.Number,6,3){Nullable=true} ,
       new ParDef("MemoRemoveDate",GXType.Date,8,0){Nullable=true} ,
       new ParDef("MemoBgColorCode",GXType.VarChar,100,0){Nullable=true} ,
       new ParDef("MemoForm",GXType.Char,20,0) ,
       new ParDef("MemoType",GXType.VarChar,100,0) ,
       new ParDef("MemoName",GXType.VarChar,100,0) ,
       new ParDef("MemoLeftOffset",GXType.Number,6,3) ,
       new ParDef("MemoTopOffset",GXType.Number,6,3) ,
       new ParDef("MemoTitleAngle",GXType.Number,6,3) ,
       new ParDef("MemoTitleScale",GXType.Number,6,3) ,
       new ParDef("MemoTextFontName",GXType.VarChar,100,0) ,
       new ParDef("MemoTextAlignment",GXType.Char,20,0) ,
       new ParDef("MemoIsBold",GXType.Boolean,4,0) ,
       new ParDef("MemoIsItalic",GXType.Boolean,4,0) ,
       new ParDef("MemoIsCapitalized",GXType.Boolean,4,0) ,
       new ParDef("MemoTextColor",GXType.VarChar,40,0) ,
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001P9;
       prmBC001P9 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001P10;
       prmBC001P10 = new Object[] {
       new ParDef("ResidentId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_LocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("SG_OrganisationId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001P11;
       prmBC001P11 = new Object[] {
       new ParDef("MemoId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001P2", "SELECT MemoId, MemoTitle, MemoDescription, MemoImage, MemoDocument, MemoStartDateTime, MemoEndDateTime, MemoDuration, MemoRemoveDate, MemoBgColorCode, MemoForm, MemoType, MemoName, MemoLeftOffset, MemoTopOffset, MemoTitleAngle, MemoTitleScale, MemoTextFontName, MemoTextAlignment, MemoIsBold, MemoIsItalic, MemoIsCapitalized, MemoTextColor, ResidentId, SG_LocationId, SG_OrganisationId FROM Trn_Memo WHERE MemoId = :MemoId  FOR UPDATE OF Trn_Memo",true, GxErrorMask.GX_NOMASK, false, this,prmBC001P2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001P3", "SELECT MemoId, MemoTitle, MemoDescription, MemoImage, MemoDocument, MemoStartDateTime, MemoEndDateTime, MemoDuration, MemoRemoveDate, MemoBgColorCode, MemoForm, MemoType, MemoName, MemoLeftOffset, MemoTopOffset, MemoTitleAngle, MemoTitleScale, MemoTextFontName, MemoTextAlignment, MemoIsBold, MemoIsItalic, MemoIsCapitalized, MemoTextColor, ResidentId, SG_LocationId, SG_OrganisationId FROM Trn_Memo WHERE MemoId = :MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001P3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001P4", "SELECT LocationId, OrganisationId, ResidentSalutation, ResidentGivenName, ResidentLastName, ResidentGUID FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :SG_LocationId AND OrganisationId = :SG_OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001P4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001P5", "SELECT T2.LocationId, T2.OrganisationId, TM1.MemoId, TM1.MemoTitle, TM1.MemoDescription, TM1.MemoImage, TM1.MemoDocument, TM1.MemoStartDateTime, TM1.MemoEndDateTime, TM1.MemoDuration, TM1.MemoRemoveDate, T2.ResidentSalutation, T2.ResidentGivenName, T2.ResidentLastName, T2.ResidentGUID, TM1.MemoBgColorCode, TM1.MemoForm, TM1.MemoType, TM1.MemoName, TM1.MemoLeftOffset, TM1.MemoTopOffset, TM1.MemoTitleAngle, TM1.MemoTitleScale, TM1.MemoTextFontName, TM1.MemoTextAlignment, TM1.MemoIsBold, TM1.MemoIsItalic, TM1.MemoIsCapitalized, TM1.MemoTextColor, TM1.ResidentId, TM1.SG_LocationId, TM1.SG_OrganisationId FROM (Trn_Memo TM1 INNER JOIN Trn_Resident T2 ON T2.ResidentId = TM1.ResidentId AND T2.LocationId = TM1.SG_LocationId AND T2.OrganisationId = TM1.SG_OrganisationId) WHERE TM1.MemoId = :MemoId ORDER BY TM1.MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001P5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001P6", "SELECT MemoId FROM Trn_Memo WHERE MemoId = :MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001P6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001P7", "SAVEPOINT gxupdate;INSERT INTO Trn_Memo(MemoId, MemoTitle, MemoDescription, MemoImage, MemoDocument, MemoStartDateTime, MemoEndDateTime, MemoDuration, MemoRemoveDate, MemoBgColorCode, MemoForm, MemoType, MemoName, MemoLeftOffset, MemoTopOffset, MemoTitleAngle, MemoTitleScale, MemoTextFontName, MemoTextAlignment, MemoIsBold, MemoIsItalic, MemoIsCapitalized, MemoTextColor, ResidentId, SG_LocationId, SG_OrganisationId) VALUES(:MemoId, :MemoTitle, :MemoDescription, :MemoImage, :MemoDocument, :MemoStartDateTime, :MemoEndDateTime, :MemoDuration, :MemoRemoveDate, :MemoBgColorCode, :MemoForm, :MemoType, :MemoName, :MemoLeftOffset, :MemoTopOffset, :MemoTitleAngle, :MemoTitleScale, :MemoTextFontName, :MemoTextAlignment, :MemoIsBold, :MemoIsItalic, :MemoIsCapitalized, :MemoTextColor, :ResidentId, :SG_LocationId, :SG_OrganisationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001P7)
          ,new CursorDef("BC001P8", "SAVEPOINT gxupdate;UPDATE Trn_Memo SET MemoTitle=:MemoTitle, MemoDescription=:MemoDescription, MemoImage=:MemoImage, MemoDocument=:MemoDocument, MemoStartDateTime=:MemoStartDateTime, MemoEndDateTime=:MemoEndDateTime, MemoDuration=:MemoDuration, MemoRemoveDate=:MemoRemoveDate, MemoBgColorCode=:MemoBgColorCode, MemoForm=:MemoForm, MemoType=:MemoType, MemoName=:MemoName, MemoLeftOffset=:MemoLeftOffset, MemoTopOffset=:MemoTopOffset, MemoTitleAngle=:MemoTitleAngle, MemoTitleScale=:MemoTitleScale, MemoTextFontName=:MemoTextFontName, MemoTextAlignment=:MemoTextAlignment, MemoIsBold=:MemoIsBold, MemoIsItalic=:MemoIsItalic, MemoIsCapitalized=:MemoIsCapitalized, MemoTextColor=:MemoTextColor, ResidentId=:ResidentId, SG_LocationId=:SG_LocationId, SG_OrganisationId=:SG_OrganisationId  WHERE MemoId = :MemoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001P8)
          ,new CursorDef("BC001P9", "SAVEPOINT gxupdate;DELETE FROM Trn_Memo  WHERE MemoId = :MemoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001P9)
          ,new CursorDef("BC001P10", "SELECT ResidentSalutation, ResidentGivenName, ResidentLastName, ResidentGUID FROM Trn_Resident WHERE ResidentId = :ResidentId AND LocationId = :SG_LocationId AND OrganisationId = :SG_OrganisationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001P10,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001P11", "SELECT T2.LocationId, T2.OrganisationId, TM1.MemoId, TM1.MemoTitle, TM1.MemoDescription, TM1.MemoImage, TM1.MemoDocument, TM1.MemoStartDateTime, TM1.MemoEndDateTime, TM1.MemoDuration, TM1.MemoRemoveDate, T2.ResidentSalutation, T2.ResidentGivenName, T2.ResidentLastName, T2.ResidentGUID, TM1.MemoBgColorCode, TM1.MemoForm, TM1.MemoType, TM1.MemoName, TM1.MemoLeftOffset, TM1.MemoTopOffset, TM1.MemoTitleAngle, TM1.MemoTitleScale, TM1.MemoTextFontName, TM1.MemoTextAlignment, TM1.MemoIsBold, TM1.MemoIsItalic, TM1.MemoIsCapitalized, TM1.MemoTextColor, TM1.ResidentId, TM1.SG_LocationId, TM1.SG_OrganisationId FROM (Trn_Memo TM1 INNER JOIN Trn_Resident T2 ON T2.ResidentId = TM1.ResidentId AND T2.LocationId = TM1.SG_LocationId AND T2.OrganisationId = TM1.SG_OrganisationId) WHERE TM1.MemoId = :MemoId ORDER BY TM1.MemoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001P11,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
             ((bool[]) buf[8])[0] = rslt.wasNull(6);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
             ((bool[]) buf[10])[0] = rslt.wasNull(7);
             ((decimal[]) buf[11])[0] = rslt.getDecimal(8);
             ((bool[]) buf[12])[0] = rslt.wasNull(8);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
             ((bool[]) buf[14])[0] = rslt.wasNull(9);
             ((string[]) buf[15])[0] = rslt.getVarchar(10);
             ((bool[]) buf[16])[0] = rslt.wasNull(10);
             ((string[]) buf[17])[0] = rslt.getString(11, 20);
             ((string[]) buf[18])[0] = rslt.getVarchar(12);
             ((string[]) buf[19])[0] = rslt.getVarchar(13);
             ((decimal[]) buf[20])[0] = rslt.getDecimal(14);
             ((decimal[]) buf[21])[0] = rslt.getDecimal(15);
             ((decimal[]) buf[22])[0] = rslt.getDecimal(16);
             ((decimal[]) buf[23])[0] = rslt.getDecimal(17);
             ((string[]) buf[24])[0] = rslt.getVarchar(18);
             ((string[]) buf[25])[0] = rslt.getString(19, 20);
             ((bool[]) buf[26])[0] = rslt.getBool(20);
             ((bool[]) buf[27])[0] = rslt.getBool(21);
             ((bool[]) buf[28])[0] = rslt.getBool(22);
             ((string[]) buf[29])[0] = rslt.getVarchar(23);
             ((Guid[]) buf[30])[0] = rslt.getGuid(24);
             ((Guid[]) buf[31])[0] = rslt.getGuid(25);
             ((Guid[]) buf[32])[0] = rslt.getGuid(26);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
             ((bool[]) buf[8])[0] = rslt.wasNull(6);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(7);
             ((bool[]) buf[10])[0] = rslt.wasNull(7);
             ((decimal[]) buf[11])[0] = rslt.getDecimal(8);
             ((bool[]) buf[12])[0] = rslt.wasNull(8);
             ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
             ((bool[]) buf[14])[0] = rslt.wasNull(9);
             ((string[]) buf[15])[0] = rslt.getVarchar(10);
             ((bool[]) buf[16])[0] = rslt.wasNull(10);
             ((string[]) buf[17])[0] = rslt.getString(11, 20);
             ((string[]) buf[18])[0] = rslt.getVarchar(12);
             ((string[]) buf[19])[0] = rslt.getVarchar(13);
             ((decimal[]) buf[20])[0] = rslt.getDecimal(14);
             ((decimal[]) buf[21])[0] = rslt.getDecimal(15);
             ((decimal[]) buf[22])[0] = rslt.getDecimal(16);
             ((decimal[]) buf[23])[0] = rslt.getDecimal(17);
             ((string[]) buf[24])[0] = rslt.getVarchar(18);
             ((string[]) buf[25])[0] = rslt.getString(19, 20);
             ((bool[]) buf[26])[0] = rslt.getBool(20);
             ((bool[]) buf[27])[0] = rslt.getBool(21);
             ((bool[]) buf[28])[0] = rslt.getBool(22);
             ((string[]) buf[29])[0] = rslt.getVarchar(23);
             ((Guid[]) buf[30])[0] = rslt.getGuid(24);
             ((Guid[]) buf[31])[0] = rslt.getGuid(25);
             ((Guid[]) buf[32])[0] = rslt.getGuid(26);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 20);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
             ((bool[]) buf[10])[0] = rslt.wasNull(8);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(9);
             ((bool[]) buf[12])[0] = rslt.wasNull(9);
             ((decimal[]) buf[13])[0] = rslt.getDecimal(10);
             ((bool[]) buf[14])[0] = rslt.wasNull(10);
             ((DateTime[]) buf[15])[0] = rslt.getGXDate(11);
             ((bool[]) buf[16])[0] = rslt.wasNull(11);
             ((string[]) buf[17])[0] = rslt.getString(12, 20);
             ((string[]) buf[18])[0] = rslt.getVarchar(13);
             ((string[]) buf[19])[0] = rslt.getVarchar(14);
             ((string[]) buf[20])[0] = rslt.getVarchar(15);
             ((string[]) buf[21])[0] = rslt.getVarchar(16);
             ((bool[]) buf[22])[0] = rslt.wasNull(16);
             ((string[]) buf[23])[0] = rslt.getString(17, 20);
             ((string[]) buf[24])[0] = rslt.getVarchar(18);
             ((string[]) buf[25])[0] = rslt.getVarchar(19);
             ((decimal[]) buf[26])[0] = rslt.getDecimal(20);
             ((decimal[]) buf[27])[0] = rslt.getDecimal(21);
             ((decimal[]) buf[28])[0] = rslt.getDecimal(22);
             ((decimal[]) buf[29])[0] = rslt.getDecimal(23);
             ((string[]) buf[30])[0] = rslt.getVarchar(24);
             ((string[]) buf[31])[0] = rslt.getString(25, 20);
             ((bool[]) buf[32])[0] = rslt.getBool(26);
             ((bool[]) buf[33])[0] = rslt.getBool(27);
             ((bool[]) buf[34])[0] = rslt.getBool(28);
             ((string[]) buf[35])[0] = rslt.getVarchar(29);
             ((Guid[]) buf[36])[0] = rslt.getGuid(30);
             ((Guid[]) buf[37])[0] = rslt.getGuid(31);
             ((Guid[]) buf[38])[0] = rslt.getGuid(32);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((string[]) buf[0])[0] = rslt.getString(1, 20);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 9 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
             ((bool[]) buf[6])[0] = rslt.wasNull(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((bool[]) buf[8])[0] = rslt.wasNull(7);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
             ((bool[]) buf[10])[0] = rslt.wasNull(8);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(9);
             ((bool[]) buf[12])[0] = rslt.wasNull(9);
             ((decimal[]) buf[13])[0] = rslt.getDecimal(10);
             ((bool[]) buf[14])[0] = rslt.wasNull(10);
             ((DateTime[]) buf[15])[0] = rslt.getGXDate(11);
             ((bool[]) buf[16])[0] = rslt.wasNull(11);
             ((string[]) buf[17])[0] = rslt.getString(12, 20);
             ((string[]) buf[18])[0] = rslt.getVarchar(13);
             ((string[]) buf[19])[0] = rslt.getVarchar(14);
             ((string[]) buf[20])[0] = rslt.getVarchar(15);
             ((string[]) buf[21])[0] = rslt.getVarchar(16);
             ((bool[]) buf[22])[0] = rslt.wasNull(16);
             ((string[]) buf[23])[0] = rslt.getString(17, 20);
             ((string[]) buf[24])[0] = rslt.getVarchar(18);
             ((string[]) buf[25])[0] = rslt.getVarchar(19);
             ((decimal[]) buf[26])[0] = rslt.getDecimal(20);
             ((decimal[]) buf[27])[0] = rslt.getDecimal(21);
             ((decimal[]) buf[28])[0] = rslt.getDecimal(22);
             ((decimal[]) buf[29])[0] = rslt.getDecimal(23);
             ((string[]) buf[30])[0] = rslt.getVarchar(24);
             ((string[]) buf[31])[0] = rslt.getString(25, 20);
             ((bool[]) buf[32])[0] = rslt.getBool(26);
             ((bool[]) buf[33])[0] = rslt.getBool(27);
             ((bool[]) buf[34])[0] = rslt.getBool(28);
             ((string[]) buf[35])[0] = rslt.getVarchar(29);
             ((Guid[]) buf[36])[0] = rslt.getGuid(30);
             ((Guid[]) buf[37])[0] = rslt.getGuid(31);
             ((Guid[]) buf[38])[0] = rslt.getGuid(32);
             return;
    }
 }

}

}
