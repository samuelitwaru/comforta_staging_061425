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
namespace GeneXus.Programs.wwpbaseobjects {
   public class usercustomizations_bc : GxSilentTrn, IGxSilentTrn
   {
      public usercustomizations_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usercustomizations_bc( IGxContext context )
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
         ReadRow0V44( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0V44( ) ;
         standaloneModal( ) ;
         AddRow0V44( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z244UserCustomizationsId = A244UserCustomizationsId;
               Z245UserCustomizationsKey = A245UserCustomizationsKey;
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

      protected void CONFIRM_0V0( )
      {
         BeforeValidate0V44( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0V44( ) ;
            }
            else
            {
               CheckExtendedTable0V44( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0V44( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0V44( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z244UserCustomizationsId = A244UserCustomizationsId;
            Z245UserCustomizationsKey = A245UserCustomizationsKey;
            Z246UserCustomizationsValue = A246UserCustomizationsValue;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0V44( )
      {
         /* Using cursor BC000V4 */
         pr_default.execute(2, new Object[] {A244UserCustomizationsId, A245UserCustomizationsKey});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound44 = 1;
            A246UserCustomizationsValue = BC000V4_A246UserCustomizationsValue[0];
            ZM0V44( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0V44( ) ;
      }

      protected void OnLoadActions0V44( )
      {
      }

      protected void CheckExtendedTable0V44( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0V44( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0V44( )
      {
         /* Using cursor BC000V5 */
         pr_default.execute(3, new Object[] {A244UserCustomizationsId, A245UserCustomizationsKey});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound44 = 1;
         }
         else
         {
            RcdFound44 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000V3 */
         pr_default.execute(1, new Object[] {A244UserCustomizationsId, A245UserCustomizationsKey});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0V44( 1) ;
            RcdFound44 = 1;
            A244UserCustomizationsId = BC000V3_A244UserCustomizationsId[0];
            A245UserCustomizationsKey = BC000V3_A245UserCustomizationsKey[0];
            A246UserCustomizationsValue = BC000V3_A246UserCustomizationsValue[0];
            Z244UserCustomizationsId = A244UserCustomizationsId;
            Z245UserCustomizationsKey = A245UserCustomizationsKey;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0V44( ) ;
            if ( AnyError == 1 )
            {
               RcdFound44 = 0;
               InitializeNonKey0V44( ) ;
            }
            Gx_mode = sMode44;
         }
         else
         {
            RcdFound44 = 0;
            InitializeNonKey0V44( ) ;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode44;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0V44( ) ;
         if ( RcdFound44 == 0 )
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
         CONFIRM_0V0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0V44( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000V2 */
            pr_default.execute(0, new Object[] {A244UserCustomizationsId, A245UserCustomizationsKey});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserCustomizations"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"UserCustomizations"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0V44( )
      {
         BeforeValidate0V44( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0V44( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0V44( 0) ;
            CheckOptimisticConcurrency0V44( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0V44( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0V44( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000V6 */
                     pr_default.execute(4, new Object[] {A244UserCustomizationsId, A245UserCustomizationsKey, A246UserCustomizationsValue});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("UserCustomizations");
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
               Load0V44( ) ;
            }
            EndLevel0V44( ) ;
         }
         CloseExtendedTableCursors0V44( ) ;
      }

      protected void Update0V44( )
      {
         BeforeValidate0V44( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0V44( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0V44( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0V44( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0V44( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000V7 */
                     pr_default.execute(5, new Object[] {A246UserCustomizationsValue, A244UserCustomizationsId, A245UserCustomizationsKey});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("UserCustomizations");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserCustomizations"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0V44( ) ;
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
            EndLevel0V44( ) ;
         }
         CloseExtendedTableCursors0V44( ) ;
      }

      protected void DeferredUpdate0V44( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0V44( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0V44( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0V44( ) ;
            AfterConfirm0V44( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0V44( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000V8 */
                  pr_default.execute(6, new Object[] {A244UserCustomizationsId, A245UserCustomizationsKey});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("UserCustomizations");
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
         sMode44 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0V44( ) ;
         Gx_mode = sMode44;
      }

      protected void OnDeleteControls0V44( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0V44( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0V44( ) ;
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

      public void ScanKeyStart0V44( )
      {
         /* Using cursor BC000V9 */
         pr_default.execute(7, new Object[] {A244UserCustomizationsId, A245UserCustomizationsKey});
         RcdFound44 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound44 = 1;
            A244UserCustomizationsId = BC000V9_A244UserCustomizationsId[0];
            A245UserCustomizationsKey = BC000V9_A245UserCustomizationsKey[0];
            A246UserCustomizationsValue = BC000V9_A246UserCustomizationsValue[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0V44( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound44 = 0;
         ScanKeyLoad0V44( ) ;
      }

      protected void ScanKeyLoad0V44( )
      {
         sMode44 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound44 = 1;
            A244UserCustomizationsId = BC000V9_A244UserCustomizationsId[0];
            A245UserCustomizationsKey = BC000V9_A245UserCustomizationsKey[0];
            A246UserCustomizationsValue = BC000V9_A246UserCustomizationsValue[0];
         }
         Gx_mode = sMode44;
      }

      protected void ScanKeyEnd0V44( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0V44( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0V44( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0V44( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0V44( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0V44( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0V44( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0V44( )
      {
      }

      protected void send_integrity_lvl_hashes0V44( )
      {
      }

      protected void AddRow0V44( )
      {
         VarsToRow44( bcwwpbaseobjects_UserCustomizations) ;
      }

      protected void ReadRow0V44( )
      {
         RowToVars44( bcwwpbaseobjects_UserCustomizations, 1) ;
      }

      protected void InitializeNonKey0V44( )
      {
         A246UserCustomizationsValue = "";
      }

      protected void InitAll0V44( )
      {
         A244UserCustomizationsId = "";
         A245UserCustomizationsKey = "";
         InitializeNonKey0V44( ) ;
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

      public void VarsToRow44( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj44 )
      {
         obj44.gxTpr_Mode = Gx_mode;
         obj44.gxTpr_Usercustomizationsvalue = A246UserCustomizationsValue;
         obj44.gxTpr_Usercustomizationsid = A244UserCustomizationsId;
         obj44.gxTpr_Usercustomizationskey = A245UserCustomizationsKey;
         obj44.gxTpr_Usercustomizationsid_Z = Z244UserCustomizationsId;
         obj44.gxTpr_Usercustomizationskey_Z = Z245UserCustomizationsKey;
         obj44.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow44( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj44 )
      {
         obj44.gxTpr_Usercustomizationsid = A244UserCustomizationsId;
         obj44.gxTpr_Usercustomizationskey = A245UserCustomizationsKey;
         return  ;
      }

      public void RowToVars44( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj44 ,
                               int forceLoad )
      {
         Gx_mode = obj44.gxTpr_Mode;
         A246UserCustomizationsValue = obj44.gxTpr_Usercustomizationsvalue;
         A244UserCustomizationsId = obj44.gxTpr_Usercustomizationsid;
         A245UserCustomizationsKey = obj44.gxTpr_Usercustomizationskey;
         Z244UserCustomizationsId = obj44.gxTpr_Usercustomizationsid_Z;
         Z245UserCustomizationsKey = obj44.gxTpr_Usercustomizationskey_Z;
         Gx_mode = obj44.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A244UserCustomizationsId = (string)getParm(obj,0);
         A245UserCustomizationsKey = (string)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0V44( ) ;
         ScanKeyStart0V44( ) ;
         if ( RcdFound44 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z244UserCustomizationsId = A244UserCustomizationsId;
            Z245UserCustomizationsKey = A245UserCustomizationsKey;
         }
         ZM0V44( -1) ;
         OnLoadActions0V44( ) ;
         AddRow0V44( ) ;
         ScanKeyEnd0V44( ) ;
         if ( RcdFound44 == 0 )
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
         RowToVars44( bcwwpbaseobjects_UserCustomizations, 0) ;
         ScanKeyStart0V44( ) ;
         if ( RcdFound44 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z244UserCustomizationsId = A244UserCustomizationsId;
            Z245UserCustomizationsKey = A245UserCustomizationsKey;
         }
         ZM0V44( -1) ;
         OnLoadActions0V44( ) ;
         AddRow0V44( ) ;
         ScanKeyEnd0V44( ) ;
         if ( RcdFound44 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0V44( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0V44( ) ;
         }
         else
         {
            if ( RcdFound44 == 1 )
            {
               if ( ( StringUtil.StrCmp(A244UserCustomizationsId, Z244UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A245UserCustomizationsKey, Z245UserCustomizationsKey) != 0 ) )
               {
                  A244UserCustomizationsId = Z244UserCustomizationsId;
                  A245UserCustomizationsKey = Z245UserCustomizationsKey;
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
                  Update0V44( ) ;
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
                  if ( ( StringUtil.StrCmp(A244UserCustomizationsId, Z244UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A245UserCustomizationsKey, Z245UserCustomizationsKey) != 0 ) )
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
                        Insert0V44( ) ;
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
                        Insert0V44( ) ;
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
         RowToVars44( bcwwpbaseobjects_UserCustomizations, 1) ;
         SaveImpl( ) ;
         VarsToRow44( bcwwpbaseobjects_UserCustomizations) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars44( bcwwpbaseobjects_UserCustomizations, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0V44( ) ;
         AfterTrn( ) ;
         VarsToRow44( bcwwpbaseobjects_UserCustomizations) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow44( bcwwpbaseobjects_UserCustomizations) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations auxBC = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A244UserCustomizationsId, A245UserCustomizationsKey);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_UserCustomizations);
               auxBC.Save();
               bcwwpbaseobjects_UserCustomizations.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars44( bcwwpbaseobjects_UserCustomizations, 1) ;
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
         RowToVars44( bcwwpbaseobjects_UserCustomizations, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0V44( ) ;
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
               VarsToRow44( bcwwpbaseobjects_UserCustomizations) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow44( bcwwpbaseobjects_UserCustomizations) ;
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
         RowToVars44( bcwwpbaseobjects_UserCustomizations, 0) ;
         GetKey0V44( ) ;
         if ( RcdFound44 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( StringUtil.StrCmp(A244UserCustomizationsId, Z244UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A245UserCustomizationsKey, Z245UserCustomizationsKey) != 0 ) )
            {
               A244UserCustomizationsId = Z244UserCustomizationsId;
               A245UserCustomizationsKey = Z245UserCustomizationsKey;
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
            if ( ( StringUtil.StrCmp(A244UserCustomizationsId, Z244UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A245UserCustomizationsKey, Z245UserCustomizationsKey) != 0 ) )
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
         context.RollbackDataStores("wwpbaseobjects.usercustomizations_bc",pr_default);
         VarsToRow44( bcwwpbaseobjects_UserCustomizations) ;
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
         Gx_mode = bcwwpbaseobjects_UserCustomizations.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_UserCustomizations )
         {
            bcwwpbaseobjects_UserCustomizations = (GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_UserCustomizations.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow44( bcwwpbaseobjects_UserCustomizations) ;
            }
            else
            {
               RowToVars44( bcwwpbaseobjects_UserCustomizations, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_UserCustomizations.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars44( bcwwpbaseobjects_UserCustomizations, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtUserCustomizations UserCustomizations_BC
      {
         get {
            return bcwwpbaseobjects_UserCustomizations ;
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
            return "usercustomizations_Execute" ;
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
         Z244UserCustomizationsId = "";
         A244UserCustomizationsId = "";
         Z245UserCustomizationsKey = "";
         A245UserCustomizationsKey = "";
         Z246UserCustomizationsValue = "";
         A246UserCustomizationsValue = "";
         BC000V4_A244UserCustomizationsId = new string[] {""} ;
         BC000V4_A245UserCustomizationsKey = new string[] {""} ;
         BC000V4_A246UserCustomizationsValue = new string[] {""} ;
         BC000V5_A244UserCustomizationsId = new string[] {""} ;
         BC000V5_A245UserCustomizationsKey = new string[] {""} ;
         BC000V3_A244UserCustomizationsId = new string[] {""} ;
         BC000V3_A245UserCustomizationsKey = new string[] {""} ;
         BC000V3_A246UserCustomizationsValue = new string[] {""} ;
         sMode44 = "";
         BC000V2_A244UserCustomizationsId = new string[] {""} ;
         BC000V2_A245UserCustomizationsKey = new string[] {""} ;
         BC000V2_A246UserCustomizationsValue = new string[] {""} ;
         BC000V9_A244UserCustomizationsId = new string[] {""} ;
         BC000V9_A245UserCustomizationsKey = new string[] {""} ;
         BC000V9_A246UserCustomizationsValue = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.usercustomizations_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.usercustomizations_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.usercustomizations_bc__default(),
            new Object[][] {
                new Object[] {
               BC000V2_A244UserCustomizationsId, BC000V2_A245UserCustomizationsKey, BC000V2_A246UserCustomizationsValue
               }
               , new Object[] {
               BC000V3_A244UserCustomizationsId, BC000V3_A245UserCustomizationsKey, BC000V3_A246UserCustomizationsValue
               }
               , new Object[] {
               BC000V4_A244UserCustomizationsId, BC000V4_A245UserCustomizationsKey, BC000V4_A246UserCustomizationsValue
               }
               , new Object[] {
               BC000V5_A244UserCustomizationsId, BC000V5_A245UserCustomizationsKey
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000V9_A244UserCustomizationsId, BC000V9_A245UserCustomizationsKey, BC000V9_A246UserCustomizationsValue
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound44 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z244UserCustomizationsId ;
      private string A244UserCustomizationsId ;
      private string sMode44 ;
      private string Z246UserCustomizationsValue ;
      private string A246UserCustomizationsValue ;
      private string Z245UserCustomizationsKey ;
      private string A245UserCustomizationsKey ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000V4_A244UserCustomizationsId ;
      private string[] BC000V4_A245UserCustomizationsKey ;
      private string[] BC000V4_A246UserCustomizationsValue ;
      private string[] BC000V5_A244UserCustomizationsId ;
      private string[] BC000V5_A245UserCustomizationsKey ;
      private string[] BC000V3_A244UserCustomizationsId ;
      private string[] BC000V3_A245UserCustomizationsKey ;
      private string[] BC000V3_A246UserCustomizationsValue ;
      private string[] BC000V2_A244UserCustomizationsId ;
      private string[] BC000V2_A245UserCustomizationsKey ;
      private string[] BC000V2_A246UserCustomizationsValue ;
      private string[] BC000V9_A244UserCustomizationsId ;
      private string[] BC000V9_A245UserCustomizationsKey ;
      private string[] BC000V9_A246UserCustomizationsValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations bcwwpbaseobjects_UserCustomizations ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class usercustomizations_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class usercustomizations_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class usercustomizations_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[7])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000V2;
       prmBC000V2 = new Object[] {
       new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
       new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
       };
       Object[] prmBC000V3;
       prmBC000V3 = new Object[] {
       new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
       new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
       };
       Object[] prmBC000V4;
       prmBC000V4 = new Object[] {
       new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
       new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
       };
       Object[] prmBC000V5;
       prmBC000V5 = new Object[] {
       new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
       new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
       };
       Object[] prmBC000V6;
       prmBC000V6 = new Object[] {
       new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
       new ParDef("UserCustomizationsKey",GXType.VarChar,200,0) ,
       new ParDef("UserCustomizationsValue",GXType.LongVarChar,2097152,0)
       };
       Object[] prmBC000V7;
       prmBC000V7 = new Object[] {
       new ParDef("UserCustomizationsValue",GXType.LongVarChar,2097152,0) ,
       new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
       new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
       };
       Object[] prmBC000V8;
       prmBC000V8 = new Object[] {
       new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
       new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
       };
       Object[] prmBC000V9;
       prmBC000V9 = new Object[] {
       new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
       new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000V2", "SELECT UserCustomizationsId, UserCustomizationsKey, UserCustomizationsValue FROM UserCustomizations WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey  FOR UPDATE OF UserCustomizations",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000V3", "SELECT UserCustomizationsId, UserCustomizationsKey, UserCustomizationsValue FROM UserCustomizations WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000V4", "SELECT TM1.UserCustomizationsId, TM1.UserCustomizationsKey, TM1.UserCustomizationsValue FROM UserCustomizations TM1 WHERE TM1.UserCustomizationsId = ( :UserCustomizationsId) and TM1.UserCustomizationsKey = ( :UserCustomizationsKey) ORDER BY TM1.UserCustomizationsId, TM1.UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000V5", "SELECT UserCustomizationsId, UserCustomizationsKey FROM UserCustomizations WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000V6", "SAVEPOINT gxupdate;INSERT INTO UserCustomizations(UserCustomizationsId, UserCustomizationsKey, UserCustomizationsValue) VALUES(:UserCustomizationsId, :UserCustomizationsKey, :UserCustomizationsValue);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000V6)
          ,new CursorDef("BC000V7", "SAVEPOINT gxupdate;UPDATE UserCustomizations SET UserCustomizationsValue=:UserCustomizationsValue  WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000V7)
          ,new CursorDef("BC000V8", "SAVEPOINT gxupdate;DELETE FROM UserCustomizations  WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000V8)
          ,new CursorDef("BC000V9", "SELECT TM1.UserCustomizationsId, TM1.UserCustomizationsKey, TM1.UserCustomizationsValue FROM UserCustomizations TM1 WHERE TM1.UserCustomizationsId = ( :UserCustomizationsId) and TM1.UserCustomizationsKey = ( :UserCustomizationsKey) ORDER BY TM1.UserCustomizationsId, TM1.UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V9,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 7 :
             ((string[]) buf[0])[0] = rslt.getString(1, 40);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
             return;
    }
 }

}

}
