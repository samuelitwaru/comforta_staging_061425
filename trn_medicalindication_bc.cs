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
   public class trn_medicalindication_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_medicalindication_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_medicalindication_bc( IGxContext context )
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
         ReadRow0E24( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0E24( ) ;
         standaloneModal( ) ;
         AddRow0E24( ) ;
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
            E110E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z98MedicalIndicationId = A98MedicalIndicationId;
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

      protected void CONFIRM_0E0( )
      {
         BeforeValidate0E24( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0E24( ) ;
            }
            else
            {
               CheckExtendedTable0E24( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0E24( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120E2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0E24( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z99MedicalIndicationName = A99MedicalIndicationName;
         }
         if ( GX_JID == -3 )
         {
            Z98MedicalIndicationId = A98MedicalIndicationId;
            Z99MedicalIndicationName = A99MedicalIndicationName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A98MedicalIndicationId) )
         {
            A98MedicalIndicationId = Guid.NewGuid( );
            n98MedicalIndicationId = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0E24( )
      {
         /* Using cursor BC000E4 */
         pr_default.execute(2, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound24 = 1;
            A99MedicalIndicationName = BC000E4_A99MedicalIndicationName[0];
            ZM0E24( -3) ;
         }
         pr_default.close(2);
         OnLoadActions0E24( ) ;
      }

      protected void OnLoadActions0E24( )
      {
      }

      protected void CheckExtendedTable0E24( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0E24( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0E24( )
      {
         /* Using cursor BC000E5 */
         pr_default.execute(3, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound24 = 1;
         }
         else
         {
            RcdFound24 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000E3 */
         pr_default.execute(1, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E24( 3) ;
            RcdFound24 = 1;
            A98MedicalIndicationId = BC000E3_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC000E3_n98MedicalIndicationId[0];
            A99MedicalIndicationName = BC000E3_A99MedicalIndicationName[0];
            Z98MedicalIndicationId = A98MedicalIndicationId;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0E24( ) ;
            if ( AnyError == 1 )
            {
               RcdFound24 = 0;
               InitializeNonKey0E24( ) ;
            }
            Gx_mode = sMode24;
         }
         else
         {
            RcdFound24 = 0;
            InitializeNonKey0E24( ) ;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode24;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E24( ) ;
         if ( RcdFound24 == 0 )
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
         CONFIRM_0E0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0E24( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000E2 */
            pr_default.execute(0, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_MedicalIndication"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z99MedicalIndicationName, BC000E2_A99MedicalIndicationName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_MedicalIndication"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E24( )
      {
         BeforeValidate0E24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E24( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E24( 0) ;
            CheckOptimisticConcurrency0E24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E6 */
                     pr_default.execute(4, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId, A99MedicalIndicationName});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_MedicalIndication");
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
               Load0E24( ) ;
            }
            EndLevel0E24( ) ;
         }
         CloseExtendedTableCursors0E24( ) ;
      }

      protected void Update0E24( )
      {
         BeforeValidate0E24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E24( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E7 */
                     pr_default.execute(5, new Object[] {A99MedicalIndicationName, n98MedicalIndicationId, A98MedicalIndicationId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_MedicalIndication");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_MedicalIndication"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E24( ) ;
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
            EndLevel0E24( ) ;
         }
         CloseExtendedTableCursors0E24( ) ;
      }

      protected void DeferredUpdate0E24( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0E24( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E24( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E24( ) ;
            AfterConfirm0E24( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E24( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000E8 */
                  pr_default.execute(6, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_MedicalIndication");
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
         sMode24 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0E24( ) ;
         Gx_mode = sMode24;
      }

      protected void OnDeleteControls0E24( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000E9 */
            pr_default.execute(7, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Trn_Resident", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel0E24( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E24( ) ;
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

      public void ScanKeyStart0E24( )
      {
         /* Scan By routine */
         /* Using cursor BC000E10 */
         pr_default.execute(8, new Object[] {n98MedicalIndicationId, A98MedicalIndicationId});
         RcdFound24 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound24 = 1;
            A98MedicalIndicationId = BC000E10_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC000E10_n98MedicalIndicationId[0];
            A99MedicalIndicationName = BC000E10_A99MedicalIndicationName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0E24( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound24 = 0;
         ScanKeyLoad0E24( ) ;
      }

      protected void ScanKeyLoad0E24( )
      {
         sMode24 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound24 = 1;
            A98MedicalIndicationId = BC000E10_A98MedicalIndicationId[0];
            n98MedicalIndicationId = BC000E10_n98MedicalIndicationId[0];
            A99MedicalIndicationName = BC000E10_A99MedicalIndicationName[0];
         }
         Gx_mode = sMode24;
      }

      protected void ScanKeyEnd0E24( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0E24( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E24( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E24( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E24( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E24( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E24( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E24( )
      {
      }

      protected void send_integrity_lvl_hashes0E24( )
      {
      }

      protected void AddRow0E24( )
      {
         VarsToRow24( bcTrn_MedicalIndication) ;
      }

      protected void ReadRow0E24( )
      {
         RowToVars24( bcTrn_MedicalIndication, 1) ;
      }

      protected void InitializeNonKey0E24( )
      {
         A99MedicalIndicationName = "";
         Z99MedicalIndicationName = "";
      }

      protected void InitAll0E24( )
      {
         A98MedicalIndicationId = Guid.NewGuid( );
         n98MedicalIndicationId = false;
         InitializeNonKey0E24( ) ;
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

      public void VarsToRow24( SdtTrn_MedicalIndication obj24 )
      {
         obj24.gxTpr_Mode = Gx_mode;
         obj24.gxTpr_Medicalindicationname = A99MedicalIndicationName;
         obj24.gxTpr_Medicalindicationid = A98MedicalIndicationId;
         obj24.gxTpr_Medicalindicationid_Z = Z98MedicalIndicationId;
         obj24.gxTpr_Medicalindicationname_Z = Z99MedicalIndicationName;
         obj24.gxTpr_Medicalindicationid_N = (short)(Convert.ToInt16(n98MedicalIndicationId));
         obj24.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow24( SdtTrn_MedicalIndication obj24 )
      {
         obj24.gxTpr_Medicalindicationid = A98MedicalIndicationId;
         return  ;
      }

      public void RowToVars24( SdtTrn_MedicalIndication obj24 ,
                               int forceLoad )
      {
         Gx_mode = obj24.gxTpr_Mode;
         A99MedicalIndicationName = obj24.gxTpr_Medicalindicationname;
         A98MedicalIndicationId = obj24.gxTpr_Medicalindicationid;
         n98MedicalIndicationId = false;
         Z98MedicalIndicationId = obj24.gxTpr_Medicalindicationid_Z;
         Z99MedicalIndicationName = obj24.gxTpr_Medicalindicationname_Z;
         n98MedicalIndicationId = (bool)(Convert.ToBoolean(obj24.gxTpr_Medicalindicationid_N));
         Gx_mode = obj24.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A98MedicalIndicationId = (Guid)getParm(obj,0);
         n98MedicalIndicationId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0E24( ) ;
         ScanKeyStart0E24( ) ;
         if ( RcdFound24 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z98MedicalIndicationId = A98MedicalIndicationId;
         }
         ZM0E24( -3) ;
         OnLoadActions0E24( ) ;
         AddRow0E24( ) ;
         ScanKeyEnd0E24( ) ;
         if ( RcdFound24 == 0 )
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
         RowToVars24( bcTrn_MedicalIndication, 0) ;
         ScanKeyStart0E24( ) ;
         if ( RcdFound24 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z98MedicalIndicationId = A98MedicalIndicationId;
         }
         ZM0E24( -3) ;
         OnLoadActions0E24( ) ;
         AddRow0E24( ) ;
         ScanKeyEnd0E24( ) ;
         if ( RcdFound24 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0E24( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0E24( ) ;
         }
         else
         {
            if ( RcdFound24 == 1 )
            {
               if ( A98MedicalIndicationId != Z98MedicalIndicationId )
               {
                  A98MedicalIndicationId = Z98MedicalIndicationId;
                  n98MedicalIndicationId = false;
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
                  Update0E24( ) ;
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
                  if ( A98MedicalIndicationId != Z98MedicalIndicationId )
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
                        Insert0E24( ) ;
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
                        Insert0E24( ) ;
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
         RowToVars24( bcTrn_MedicalIndication, 1) ;
         SaveImpl( ) ;
         VarsToRow24( bcTrn_MedicalIndication) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars24( bcTrn_MedicalIndication, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E24( ) ;
         AfterTrn( ) ;
         VarsToRow24( bcTrn_MedicalIndication) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow24( bcTrn_MedicalIndication) ;
         }
         else
         {
            SdtTrn_MedicalIndication auxBC = new SdtTrn_MedicalIndication(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A98MedicalIndicationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_MedicalIndication);
               auxBC.Save();
               bcTrn_MedicalIndication.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars24( bcTrn_MedicalIndication, 1) ;
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
         RowToVars24( bcTrn_MedicalIndication, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E24( ) ;
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
               VarsToRow24( bcTrn_MedicalIndication) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow24( bcTrn_MedicalIndication) ;
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
         RowToVars24( bcTrn_MedicalIndication, 0) ;
         GetKey0E24( ) ;
         if ( RcdFound24 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A98MedicalIndicationId != Z98MedicalIndicationId )
            {
               A98MedicalIndicationId = Z98MedicalIndicationId;
               n98MedicalIndicationId = false;
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
            if ( A98MedicalIndicationId != Z98MedicalIndicationId )
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
         context.RollbackDataStores("trn_medicalindication_bc",pr_default);
         VarsToRow24( bcTrn_MedicalIndication) ;
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
         Gx_mode = bcTrn_MedicalIndication.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_MedicalIndication.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_MedicalIndication )
         {
            bcTrn_MedicalIndication = (SdtTrn_MedicalIndication)(sdt);
            if ( StringUtil.StrCmp(bcTrn_MedicalIndication.gxTpr_Mode, "") == 0 )
            {
               bcTrn_MedicalIndication.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow24( bcTrn_MedicalIndication) ;
            }
            else
            {
               RowToVars24( bcTrn_MedicalIndication, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_MedicalIndication.gxTpr_Mode, "") == 0 )
            {
               bcTrn_MedicalIndication.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars24( bcTrn_MedicalIndication, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_MedicalIndication Trn_MedicalIndication_BC
      {
         get {
            return bcTrn_MedicalIndication ;
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
            return "trn_medicalindication_Execute" ;
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
         Z98MedicalIndicationId = Guid.Empty;
         A98MedicalIndicationId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z99MedicalIndicationName = "";
         A99MedicalIndicationName = "";
         BC000E4_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC000E4_n98MedicalIndicationId = new bool[] {false} ;
         BC000E4_A99MedicalIndicationName = new string[] {""} ;
         BC000E5_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC000E5_n98MedicalIndicationId = new bool[] {false} ;
         BC000E3_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC000E3_n98MedicalIndicationId = new bool[] {false} ;
         BC000E3_A99MedicalIndicationName = new string[] {""} ;
         sMode24 = "";
         BC000E2_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC000E2_n98MedicalIndicationId = new bool[] {false} ;
         BC000E2_A99MedicalIndicationName = new string[] {""} ;
         BC000E9_A62ResidentId = new Guid[] {Guid.Empty} ;
         BC000E9_A29LocationId = new Guid[] {Guid.Empty} ;
         BC000E9_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000E10_A98MedicalIndicationId = new Guid[] {Guid.Empty} ;
         BC000E10_n98MedicalIndicationId = new bool[] {false} ;
         BC000E10_A99MedicalIndicationName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_medicalindication_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_medicalindication_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_medicalindication_bc__default(),
            new Object[][] {
                new Object[] {
               BC000E2_A98MedicalIndicationId, BC000E2_A99MedicalIndicationName
               }
               , new Object[] {
               BC000E3_A98MedicalIndicationId, BC000E3_A99MedicalIndicationName
               }
               , new Object[] {
               BC000E4_A98MedicalIndicationId, BC000E4_A99MedicalIndicationName
               }
               , new Object[] {
               BC000E5_A98MedicalIndicationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000E9_A62ResidentId, BC000E9_A29LocationId, BC000E9_A11OrganisationId
               }
               , new Object[] {
               BC000E10_A98MedicalIndicationId, BC000E10_A99MedicalIndicationName
               }
            }
         );
         Z98MedicalIndicationId = Guid.NewGuid( );
         n98MedicalIndicationId = false;
         A98MedicalIndicationId = Guid.NewGuid( );
         n98MedicalIndicationId = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120E2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound24 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode24 ;
      private bool returnInSub ;
      private bool n98MedicalIndicationId ;
      private string Z99MedicalIndicationName ;
      private string A99MedicalIndicationName ;
      private Guid Z98MedicalIndicationId ;
      private Guid A98MedicalIndicationId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000E4_A98MedicalIndicationId ;
      private bool[] BC000E4_n98MedicalIndicationId ;
      private string[] BC000E4_A99MedicalIndicationName ;
      private Guid[] BC000E5_A98MedicalIndicationId ;
      private bool[] BC000E5_n98MedicalIndicationId ;
      private Guid[] BC000E3_A98MedicalIndicationId ;
      private bool[] BC000E3_n98MedicalIndicationId ;
      private string[] BC000E3_A99MedicalIndicationName ;
      private Guid[] BC000E2_A98MedicalIndicationId ;
      private bool[] BC000E2_n98MedicalIndicationId ;
      private string[] BC000E2_A99MedicalIndicationName ;
      private Guid[] BC000E9_A62ResidentId ;
      private Guid[] BC000E9_A29LocationId ;
      private Guid[] BC000E9_A11OrganisationId ;
      private Guid[] BC000E10_A98MedicalIndicationId ;
      private bool[] BC000E10_n98MedicalIndicationId ;
      private string[] BC000E10_A99MedicalIndicationName ;
      private SdtTrn_MedicalIndication bcTrn_MedicalIndication ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_medicalindication_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_medicalindication_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_medicalindication_bc__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[8])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC000E2;
       prmBC000E2 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000E3;
       prmBC000E3 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000E4;
       prmBC000E4 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000E5;
       prmBC000E5 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000E6;
       prmBC000E6 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
       new ParDef("MedicalIndicationName",GXType.VarChar,100,0)
       };
       Object[] prmBC000E7;
       prmBC000E7 = new Object[] {
       new ParDef("MedicalIndicationName",GXType.VarChar,100,0) ,
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000E8;
       prmBC000E8 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000E9;
       prmBC000E9 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       Object[] prmBC000E10;
       prmBC000E10 = new Object[] {
       new ParDef("MedicalIndicationId",GXType.UniqueIdentifier,36,0){Nullable=true}
       };
       def= new CursorDef[] {
           new CursorDef("BC000E2", "SELECT MedicalIndicationId, MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId  FOR UPDATE OF Trn_MedicalIndication",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000E3", "SELECT MedicalIndicationId, MedicalIndicationName FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000E4", "SELECT TM1.MedicalIndicationId, TM1.MedicalIndicationName FROM Trn_MedicalIndication TM1 WHERE TM1.MedicalIndicationId = :MedicalIndicationId ORDER BY TM1.MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000E5", "SELECT MedicalIndicationId FROM Trn_MedicalIndication WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC000E6", "SAVEPOINT gxupdate;INSERT INTO Trn_MedicalIndication(MedicalIndicationId, MedicalIndicationName) VALUES(:MedicalIndicationId, :MedicalIndicationName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000E6)
          ,new CursorDef("BC000E7", "SAVEPOINT gxupdate;UPDATE Trn_MedicalIndication SET MedicalIndicationName=:MedicalIndicationName  WHERE MedicalIndicationId = :MedicalIndicationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000E7)
          ,new CursorDef("BC000E8", "SAVEPOINT gxupdate;DELETE FROM Trn_MedicalIndication  WHERE MedicalIndicationId = :MedicalIndicationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000E8)
          ,new CursorDef("BC000E9", "SELECT ResidentId, LocationId, OrganisationId FROM Trn_Resident WHERE MedicalIndicationId = :MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000E10", "SELECT TM1.MedicalIndicationId, TM1.MedicalIndicationName FROM Trn_MedicalIndication TM1 WHERE TM1.MedicalIndicationId = :MedicalIndicationId ORDER BY TM1.MedicalIndicationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E10,100, GxCacheFrequency.OFF ,true,false )
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
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((Guid[]) buf[2])[0] = rslt.getGuid(3);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
    }
 }

}

}
