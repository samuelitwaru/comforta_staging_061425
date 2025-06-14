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
   public class wwp_entity_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_entity_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_entity_bc( IGxContext context )
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
         ReadRow0I28( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0I28( ) ;
         standaloneModal( ) ;
         AddRow0I28( ) ;
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
               Z125WWPEntityId = A125WWPEntityId;
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

      protected void CONFIRM_0I0( )
      {
         BeforeValidate0I28( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0I28( ) ;
            }
            else
            {
               CheckExtendedTable0I28( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0I28( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0I28( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z126WWPEntityName = A126WWPEntityName;
         }
         if ( GX_JID == -1 )
         {
            Z125WWPEntityId = A125WWPEntityId;
            Z126WWPEntityName = A126WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0I28( )
      {
         /* Using cursor BC000I4 */
         pr_default.execute(2, new Object[] {A125WWPEntityId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound28 = 1;
            A126WWPEntityName = BC000I4_A126WWPEntityName[0];
            ZM0I28( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0I28( ) ;
      }

      protected void OnLoadActions0I28( )
      {
      }

      protected void CheckExtendedTable0I28( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0I28( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0I28( )
      {
         /* Using cursor BC000I5 */
         pr_default.execute(3, new Object[] {A125WWPEntityId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000I3 */
         pr_default.execute(1, new Object[] {A125WWPEntityId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0I28( 1) ;
            RcdFound28 = 1;
            A125WWPEntityId = BC000I3_A125WWPEntityId[0];
            A126WWPEntityName = BC000I3_A126WWPEntityName[0];
            Z125WWPEntityId = A125WWPEntityId;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0I28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey0I28( ) ;
            }
            Gx_mode = sMode28;
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0I28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode28;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0I28( ) ;
         if ( RcdFound28 == 0 )
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
         CONFIRM_0I0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0I28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000I2 */
            pr_default.execute(0, new Object[] {A125WWPEntityId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Entity"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z126WWPEntityName, BC000I2_A126WWPEntityName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Entity"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0I28( )
      {
         BeforeValidate0I28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0I28( 0) ;
            CheckOptimisticConcurrency0I28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0I28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000I6 */
                     pr_default.execute(4, new Object[] {A126WWPEntityName});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000I7 */
                     pr_default.execute(5);
                     A125WWPEntityId = BC000I7_A125WWPEntityId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Entity");
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
               Load0I28( ) ;
            }
            EndLevel0I28( ) ;
         }
         CloseExtendedTableCursors0I28( ) ;
      }

      protected void Update0I28( )
      {
         BeforeValidate0I28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0I28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000I8 */
                     pr_default.execute(6, new Object[] {A126WWPEntityName, A125WWPEntityId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Entity");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Entity"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0I28( ) ;
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
            EndLevel0I28( ) ;
         }
         CloseExtendedTableCursors0I28( ) ;
      }

      protected void DeferredUpdate0I28( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0I28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0I28( ) ;
            AfterConfirm0I28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0I28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000I9 */
                  pr_default.execute(7, new Object[] {A125WWPEntityId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Entity");
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0I28( ) ;
         Gx_mode = sMode28;
      }

      protected void OnDeleteControls0I28( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000I10 */
            pr_default.execute(8, new Object[] {A125WWPEntityId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_DiscussionMessage", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000I11 */
            pr_default.execute(9, new Object[] {A125WWPEntityId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "WWP_NotificationDefinition", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0I28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0I28( ) ;
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

      public void ScanKeyStart0I28( )
      {
         /* Using cursor BC000I12 */
         pr_default.execute(10, new Object[] {A125WWPEntityId});
         RcdFound28 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound28 = 1;
            A125WWPEntityId = BC000I12_A125WWPEntityId[0];
            A126WWPEntityName = BC000I12_A126WWPEntityName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0I28( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound28 = 0;
         ScanKeyLoad0I28( ) ;
      }

      protected void ScanKeyLoad0I28( )
      {
         sMode28 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound28 = 1;
            A125WWPEntityId = BC000I12_A125WWPEntityId[0];
            A126WWPEntityName = BC000I12_A126WWPEntityName[0];
         }
         Gx_mode = sMode28;
      }

      protected void ScanKeyEnd0I28( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0I28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0I28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0I28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0I28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0I28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0I28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0I28( )
      {
      }

      protected void send_integrity_lvl_hashes0I28( )
      {
      }

      protected void AddRow0I28( )
      {
         VarsToRow28( bcwwpbaseobjects_WWP_Entity) ;
      }

      protected void ReadRow0I28( )
      {
         RowToVars28( bcwwpbaseobjects_WWP_Entity, 1) ;
      }

      protected void InitializeNonKey0I28( )
      {
         A126WWPEntityName = "";
         Z126WWPEntityName = "";
      }

      protected void InitAll0I28( )
      {
         A125WWPEntityId = 0;
         InitializeNonKey0I28( ) ;
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

      public void VarsToRow28( GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity obj28 )
      {
         obj28.gxTpr_Mode = Gx_mode;
         obj28.gxTpr_Wwpentityname = A126WWPEntityName;
         obj28.gxTpr_Wwpentityid = A125WWPEntityId;
         obj28.gxTpr_Wwpentityid_Z = Z125WWPEntityId;
         obj28.gxTpr_Wwpentityname_Z = Z126WWPEntityName;
         obj28.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow28( GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity obj28 )
      {
         obj28.gxTpr_Wwpentityid = A125WWPEntityId;
         return  ;
      }

      public void RowToVars28( GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity obj28 ,
                               int forceLoad )
      {
         Gx_mode = obj28.gxTpr_Mode;
         A126WWPEntityName = obj28.gxTpr_Wwpentityname;
         A125WWPEntityId = obj28.gxTpr_Wwpentityid;
         Z125WWPEntityId = obj28.gxTpr_Wwpentityid_Z;
         Z126WWPEntityName = obj28.gxTpr_Wwpentityname_Z;
         Gx_mode = obj28.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A125WWPEntityId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0I28( ) ;
         ScanKeyStart0I28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z125WWPEntityId = A125WWPEntityId;
         }
         ZM0I28( -1) ;
         OnLoadActions0I28( ) ;
         AddRow0I28( ) ;
         ScanKeyEnd0I28( ) ;
         if ( RcdFound28 == 0 )
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
         RowToVars28( bcwwpbaseobjects_WWP_Entity, 0) ;
         ScanKeyStart0I28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z125WWPEntityId = A125WWPEntityId;
         }
         ZM0I28( -1) ;
         OnLoadActions0I28( ) ;
         AddRow0I28( ) ;
         ScanKeyEnd0I28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0I28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0I28( ) ;
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( A125WWPEntityId != Z125WWPEntityId )
               {
                  A125WWPEntityId = Z125WWPEntityId;
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
                  Update0I28( ) ;
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
                  if ( A125WWPEntityId != Z125WWPEntityId )
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
                        Insert0I28( ) ;
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
                        Insert0I28( ) ;
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
         RowToVars28( bcwwpbaseobjects_WWP_Entity, 1) ;
         SaveImpl( ) ;
         VarsToRow28( bcwwpbaseobjects_WWP_Entity) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars28( bcwwpbaseobjects_WWP_Entity, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0I28( ) ;
         AfterTrn( ) ;
         VarsToRow28( bcwwpbaseobjects_WWP_Entity) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow28( bcwwpbaseobjects_WWP_Entity) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity auxBC = new GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A125WWPEntityId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_WWP_Entity);
               auxBC.Save();
               bcwwpbaseobjects_WWP_Entity.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars28( bcwwpbaseobjects_WWP_Entity, 1) ;
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
         RowToVars28( bcwwpbaseobjects_WWP_Entity, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0I28( ) ;
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
               VarsToRow28( bcwwpbaseobjects_WWP_Entity) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow28( bcwwpbaseobjects_WWP_Entity) ;
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
         RowToVars28( bcwwpbaseobjects_WWP_Entity, 0) ;
         GetKey0I28( ) ;
         if ( RcdFound28 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A125WWPEntityId != Z125WWPEntityId )
            {
               A125WWPEntityId = Z125WWPEntityId;
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
            if ( A125WWPEntityId != Z125WWPEntityId )
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
         context.RollbackDataStores("wwpbaseobjects.wwp_entity_bc",pr_default);
         VarsToRow28( bcwwpbaseobjects_WWP_Entity) ;
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
         Gx_mode = bcwwpbaseobjects_WWP_Entity.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_WWP_Entity.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_WWP_Entity )
         {
            bcwwpbaseobjects_WWP_Entity = (GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_Entity.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_Entity.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow28( bcwwpbaseobjects_WWP_Entity) ;
            }
            else
            {
               RowToVars28( bcwwpbaseobjects_WWP_Entity, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_Entity.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_Entity.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars28( bcwwpbaseobjects_WWP_Entity, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtWWP_Entity WWP_Entity_BC
      {
         get {
            return bcwwpbaseobjects_WWP_Entity ;
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
            return "wwpentity_Execute" ;
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
         Z126WWPEntityName = "";
         A126WWPEntityName = "";
         BC000I4_A125WWPEntityId = new long[1] ;
         BC000I4_A126WWPEntityName = new string[] {""} ;
         BC000I5_A125WWPEntityId = new long[1] ;
         BC000I3_A125WWPEntityId = new long[1] ;
         BC000I3_A126WWPEntityName = new string[] {""} ;
         sMode28 = "";
         BC000I2_A125WWPEntityId = new long[1] ;
         BC000I2_A126WWPEntityName = new string[] {""} ;
         BC000I7_A125WWPEntityId = new long[1] ;
         BC000I10_A200WWPDiscussionMessageId = new long[1] ;
         BC000I11_A128WWPNotificationDefinitionId = new long[1] ;
         BC000I12_A125WWPEntityId = new long[1] ;
         BC000I12_A126WWPEntityName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_entity_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_entity_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_entity_bc__default(),
            new Object[][] {
                new Object[] {
               BC000I2_A125WWPEntityId, BC000I2_A126WWPEntityName
               }
               , new Object[] {
               BC000I3_A125WWPEntityId, BC000I3_A126WWPEntityName
               }
               , new Object[] {
               BC000I4_A125WWPEntityId, BC000I4_A126WWPEntityName
               }
               , new Object[] {
               BC000I5_A125WWPEntityId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000I7_A125WWPEntityId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000I10_A200WWPDiscussionMessageId
               }
               , new Object[] {
               BC000I11_A128WWPNotificationDefinitionId
               }
               , new Object[] {
               BC000I12_A125WWPEntityId, BC000I12_A126WWPEntityName
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound28 ;
      private int trnEnded ;
      private long Z125WWPEntityId ;
      private long A125WWPEntityId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode28 ;
      private string Z126WWPEntityName ;
      private string A126WWPEntityName ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000I4_A125WWPEntityId ;
      private string[] BC000I4_A126WWPEntityName ;
      private long[] BC000I5_A125WWPEntityId ;
      private long[] BC000I3_A125WWPEntityId ;
      private string[] BC000I3_A126WWPEntityName ;
      private long[] BC000I2_A125WWPEntityId ;
      private string[] BC000I2_A126WWPEntityName ;
      private long[] BC000I7_A125WWPEntityId ;
      private long[] BC000I10_A200WWPDiscussionMessageId ;
      private long[] BC000I11_A128WWPNotificationDefinitionId ;
      private long[] BC000I12_A125WWPEntityId ;
      private string[] BC000I12_A126WWPEntityName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity bcwwpbaseobjects_WWP_Entity ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_entity_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_entity_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class wwp_entity_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[5])
      ,new UpdateCursor(def[6])
      ,new UpdateCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
      ,new ForEachCursor(def[10])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000I2;
       prmBC000I2 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmBC000I3;
       prmBC000I3 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmBC000I4;
       prmBC000I4 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmBC000I5;
       prmBC000I5 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmBC000I6;
       prmBC000I6 = new Object[] {
       new ParDef("WWPEntityName",GXType.VarChar,100,0)
       };
       Object[] prmBC000I7;
       prmBC000I7 = new Object[] {
       };
       Object[] prmBC000I8;
       prmBC000I8 = new Object[] {
       new ParDef("WWPEntityName",GXType.VarChar,100,0) ,
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmBC000I9;
       prmBC000I9 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmBC000I10;
       prmBC000I10 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmBC000I11;
       prmBC000I11 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       Object[] prmBC000I12;
       prmBC000I12 = new Object[] {
       new ParDef("WWPEntityId",GXType.Int64,10,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC000I2", "SELECT WWPEntityId, WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId  FOR UPDATE OF WWP_Entity",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000I3", "SELECT WWPEntityId, WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000I4", "SELECT TM1.WWPEntityId, TM1.WWPEntityName FROM WWP_Entity TM1 WHERE TM1.WWPEntityId = :WWPEntityId ORDER BY TM1.WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000I5", "SELECT WWPEntityId FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000I6", "SAVEPOINT gxupdate;INSERT INTO WWP_Entity(WWPEntityName) VALUES(:WWPEntityName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000I6)
          ,new CursorDef("BC000I7", "SELECT currval('WWPEntityId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000I8", "SAVEPOINT gxupdate;UPDATE WWP_Entity SET WWPEntityName=:WWPEntityName  WHERE WWPEntityId = :WWPEntityId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000I8)
          ,new CursorDef("BC000I9", "SAVEPOINT gxupdate;DELETE FROM WWP_Entity  WHERE WWPEntityId = :WWPEntityId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000I9)
          ,new CursorDef("BC000I10", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I10,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000I11", "SELECT WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I11,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000I12", "SELECT TM1.WWPEntityId, TM1.WWPEntityName FROM WWP_Entity TM1 WHERE TM1.WWPEntityId = :WWPEntityId ORDER BY TM1.WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I12,100, GxCacheFrequency.OFF ,true,false )
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
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 2 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 3 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 5 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 8 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 9 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 10 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
    }
 }

}

}
