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
   public class trn_organisationtype_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_organisationtype_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_organisationtype_bc( IGxContext context )
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
         ReadRow024( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey024( ) ;
         standaloneModal( ) ;
         AddRow024( ) ;
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
            E11022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z19OrganisationTypeId = A19OrganisationTypeId;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate024( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls024( ) ;
            }
            else
            {
               CheckExtendedTable024( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors024( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12022( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11022( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM024( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z20OrganisationTypeName = A20OrganisationTypeName;
         }
         if ( GX_JID == -4 )
         {
            Z19OrganisationTypeId = A19OrganisationTypeId;
            Z20OrganisationTypeName = A20OrganisationTypeName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A19OrganisationTypeId) )
         {
            A19OrganisationTypeId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load024( )
      {
         /* Using cursor BC00024 */
         pr_default.execute(2, new Object[] {A19OrganisationTypeId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound4 = 1;
            A20OrganisationTypeName = BC00024_A20OrganisationTypeName[0];
            ZM024( -4) ;
         }
         pr_default.close(2);
         OnLoadActions024( ) ;
      }

      protected void OnLoadActions024( )
      {
      }

      protected void CheckExtendedTable024( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A20OrganisationTypeName)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Organisation Type Name", ""), "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors024( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey024( )
      {
         /* Using cursor BC00025 */
         pr_default.execute(3, new Object[] {A19OrganisationTypeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {A19OrganisationTypeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM024( 4) ;
            RcdFound4 = 1;
            A19OrganisationTypeId = BC00023_A19OrganisationTypeId[0];
            A20OrganisationTypeName = BC00023_A20OrganisationTypeName[0];
            Z19OrganisationTypeId = A19OrganisationTypeId;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load024( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey024( ) ;
            }
            Gx_mode = sMode4;
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey024( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode4;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey024( ) ;
         if ( RcdFound4 == 0 )
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
         CONFIRM_020( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency024( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {A19OrganisationTypeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_OrganisationType"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z20OrganisationTypeName, BC00022_A20OrganisationTypeName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_OrganisationType"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert024( )
      {
         BeforeValidate024( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable024( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM024( 0) ;
            CheckOptimisticConcurrency024( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm024( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert024( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00026 */
                     pr_default.execute(4, new Object[] {A19OrganisationTypeId, A20OrganisationTypeName});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationType");
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
               Load024( ) ;
            }
            EndLevel024( ) ;
         }
         CloseExtendedTableCursors024( ) ;
      }

      protected void Update024( )
      {
         BeforeValidate024( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable024( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency024( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm024( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate024( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00027 */
                     pr_default.execute(5, new Object[] {A20OrganisationTypeName, A19OrganisationTypeId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationType");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_OrganisationType"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate024( ) ;
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
            EndLevel024( ) ;
         }
         CloseExtendedTableCursors024( ) ;
      }

      protected void DeferredUpdate024( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate024( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency024( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls024( ) ;
            AfterConfirm024( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete024( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00028 */
                  pr_default.execute(6, new Object[] {A19OrganisationTypeId});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_OrganisationType");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel024( ) ;
         Gx_mode = sMode4;
      }

      protected void OnDeleteControls024( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC00029 */
            pr_default.execute(7, new Object[] {A19OrganisationTypeId});
            if ( (pr_default.getStatus(7) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Organisations", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(7);
         }
      }

      protected void EndLevel024( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete024( ) ;
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

      public void ScanKeyStart024( )
      {
         /* Scan By routine */
         /* Using cursor BC000210 */
         pr_default.execute(8, new Object[] {A19OrganisationTypeId});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound4 = 1;
            A19OrganisationTypeId = BC000210_A19OrganisationTypeId[0];
            A20OrganisationTypeName = BC000210_A20OrganisationTypeName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext024( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound4 = 0;
         ScanKeyLoad024( ) ;
      }

      protected void ScanKeyLoad024( )
      {
         sMode4 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound4 = 1;
            A19OrganisationTypeId = BC000210_A19OrganisationTypeId[0];
            A20OrganisationTypeName = BC000210_A20OrganisationTypeName[0];
         }
         Gx_mode = sMode4;
      }

      protected void ScanKeyEnd024( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm024( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert024( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate024( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete024( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete024( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate024( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes024( )
      {
      }

      protected void send_integrity_lvl_hashes024( )
      {
      }

      protected void AddRow024( )
      {
         VarsToRow4( bcTrn_OrganisationType) ;
      }

      protected void ReadRow024( )
      {
         RowToVars4( bcTrn_OrganisationType, 1) ;
      }

      protected void InitializeNonKey024( )
      {
         A20OrganisationTypeName = "";
         Z20OrganisationTypeName = "";
      }

      protected void InitAll024( )
      {
         A19OrganisationTypeId = Guid.NewGuid( );
         InitializeNonKey024( ) ;
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

      public void VarsToRow4( SdtTrn_OrganisationType obj4 )
      {
         obj4.gxTpr_Mode = Gx_mode;
         obj4.gxTpr_Organisationtypename = A20OrganisationTypeName;
         obj4.gxTpr_Organisationtypeid = A19OrganisationTypeId;
         obj4.gxTpr_Organisationtypeid_Z = Z19OrganisationTypeId;
         obj4.gxTpr_Organisationtypename_Z = Z20OrganisationTypeName;
         obj4.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow4( SdtTrn_OrganisationType obj4 )
      {
         obj4.gxTpr_Organisationtypeid = A19OrganisationTypeId;
         return  ;
      }

      public void RowToVars4( SdtTrn_OrganisationType obj4 ,
                              int forceLoad )
      {
         Gx_mode = obj4.gxTpr_Mode;
         A20OrganisationTypeName = obj4.gxTpr_Organisationtypename;
         A19OrganisationTypeId = obj4.gxTpr_Organisationtypeid;
         Z19OrganisationTypeId = obj4.gxTpr_Organisationtypeid_Z;
         Z20OrganisationTypeName = obj4.gxTpr_Organisationtypename_Z;
         Gx_mode = obj4.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A19OrganisationTypeId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey024( ) ;
         ScanKeyStart024( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z19OrganisationTypeId = A19OrganisationTypeId;
         }
         ZM024( -4) ;
         OnLoadActions024( ) ;
         AddRow024( ) ;
         ScanKeyEnd024( ) ;
         if ( RcdFound4 == 0 )
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
         RowToVars4( bcTrn_OrganisationType, 0) ;
         ScanKeyStart024( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z19OrganisationTypeId = A19OrganisationTypeId;
         }
         ZM024( -4) ;
         OnLoadActions024( ) ;
         AddRow024( ) ;
         ScanKeyEnd024( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey024( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert024( ) ;
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A19OrganisationTypeId != Z19OrganisationTypeId )
               {
                  A19OrganisationTypeId = Z19OrganisationTypeId;
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
                  Update024( ) ;
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
                  if ( A19OrganisationTypeId != Z19OrganisationTypeId )
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
                        Insert024( ) ;
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
                        Insert024( ) ;
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
         RowToVars4( bcTrn_OrganisationType, 1) ;
         SaveImpl( ) ;
         VarsToRow4( bcTrn_OrganisationType) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars4( bcTrn_OrganisationType, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert024( ) ;
         AfterTrn( ) ;
         VarsToRow4( bcTrn_OrganisationType) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow4( bcTrn_OrganisationType) ;
         }
         else
         {
            SdtTrn_OrganisationType auxBC = new SdtTrn_OrganisationType(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A19OrganisationTypeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_OrganisationType);
               auxBC.Save();
               bcTrn_OrganisationType.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars4( bcTrn_OrganisationType, 1) ;
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
         RowToVars4( bcTrn_OrganisationType, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert024( ) ;
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
               VarsToRow4( bcTrn_OrganisationType) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow4( bcTrn_OrganisationType) ;
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
         RowToVars4( bcTrn_OrganisationType, 0) ;
         GetKey024( ) ;
         if ( RcdFound4 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A19OrganisationTypeId != Z19OrganisationTypeId )
            {
               A19OrganisationTypeId = Z19OrganisationTypeId;
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
            if ( A19OrganisationTypeId != Z19OrganisationTypeId )
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
         context.RollbackDataStores("trn_organisationtype_bc",pr_default);
         VarsToRow4( bcTrn_OrganisationType) ;
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
         Gx_mode = bcTrn_OrganisationType.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_OrganisationType.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_OrganisationType )
         {
            bcTrn_OrganisationType = (SdtTrn_OrganisationType)(sdt);
            if ( StringUtil.StrCmp(bcTrn_OrganisationType.gxTpr_Mode, "") == 0 )
            {
               bcTrn_OrganisationType.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow4( bcTrn_OrganisationType) ;
            }
            else
            {
               RowToVars4( bcTrn_OrganisationType, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_OrganisationType.gxTpr_Mode, "") == 0 )
            {
               bcTrn_OrganisationType.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars4( bcTrn_OrganisationType, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_OrganisationType Trn_OrganisationType_BC
      {
         get {
            return bcTrn_OrganisationType ;
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
            return "trn_organisationtype_Execute" ;
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
         Z19OrganisationTypeId = Guid.Empty;
         A19OrganisationTypeId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z20OrganisationTypeName = "";
         A20OrganisationTypeName = "";
         BC00024_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         BC00024_A20OrganisationTypeName = new string[] {""} ;
         BC00025_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         BC00023_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         BC00023_A20OrganisationTypeName = new string[] {""} ;
         sMode4 = "";
         BC00022_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         BC00022_A20OrganisationTypeName = new string[] {""} ;
         BC00029_A11OrganisationId = new Guid[] {Guid.Empty} ;
         BC000210_A19OrganisationTypeId = new Guid[] {Guid.Empty} ;
         BC000210_A20OrganisationTypeName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationtype_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationtype_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_organisationtype_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A19OrganisationTypeId, BC00022_A20OrganisationTypeName
               }
               , new Object[] {
               BC00023_A19OrganisationTypeId, BC00023_A20OrganisationTypeName
               }
               , new Object[] {
               BC00024_A19OrganisationTypeId, BC00024_A20OrganisationTypeName
               }
               , new Object[] {
               BC00025_A19OrganisationTypeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00029_A11OrganisationId
               }
               , new Object[] {
               BC000210_A19OrganisationTypeId, BC000210_A20OrganisationTypeName
               }
            }
         );
         Z19OrganisationTypeId = Guid.NewGuid( );
         A19OrganisationTypeId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12022 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound4 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode4 ;
      private bool returnInSub ;
      private string Z20OrganisationTypeName ;
      private string A20OrganisationTypeName ;
      private Guid Z19OrganisationTypeId ;
      private Guid A19OrganisationTypeId ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00024_A19OrganisationTypeId ;
      private string[] BC00024_A20OrganisationTypeName ;
      private Guid[] BC00025_A19OrganisationTypeId ;
      private Guid[] BC00023_A19OrganisationTypeId ;
      private string[] BC00023_A20OrganisationTypeName ;
      private Guid[] BC00022_A19OrganisationTypeId ;
      private string[] BC00022_A20OrganisationTypeName ;
      private Guid[] BC00029_A11OrganisationId ;
      private Guid[] BC000210_A19OrganisationTypeId ;
      private string[] BC000210_A20OrganisationTypeName ;
      private SdtTrn_OrganisationType bcTrn_OrganisationType ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_organisationtype_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_organisationtype_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_organisationtype_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmBC00022;
       prmBC00022 = new Object[] {
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00023;
       prmBC00023 = new Object[] {
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00024;
       prmBC00024 = new Object[] {
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00025;
       prmBC00025 = new Object[] {
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00026;
       prmBC00026 = new Object[] {
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationTypeName",GXType.VarChar,100,0)
       };
       Object[] prmBC00027;
       prmBC00027 = new Object[] {
       new ParDef("OrganisationTypeName",GXType.VarChar,100,0) ,
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00028;
       prmBC00028 = new Object[] {
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC00029;
       prmBC00029 = new Object[] {
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC000210;
       prmBC000210 = new Object[] {
       new ParDef("OrganisationTypeId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC00022", "SELECT OrganisationTypeId, OrganisationTypeName FROM Trn_OrganisationType WHERE OrganisationTypeId = :OrganisationTypeId  FOR UPDATE OF Trn_OrganisationType",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00023", "SELECT OrganisationTypeId, OrganisationTypeName FROM Trn_OrganisationType WHERE OrganisationTypeId = :OrganisationTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00024", "SELECT TM1.OrganisationTypeId, TM1.OrganisationTypeName FROM Trn_OrganisationType TM1 WHERE TM1.OrganisationTypeId = :OrganisationTypeId ORDER BY TM1.OrganisationTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00024,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00025", "SELECT OrganisationTypeId FROM Trn_OrganisationType WHERE OrganisationTypeId = :OrganisationTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC00026", "SAVEPOINT gxupdate;INSERT INTO Trn_OrganisationType(OrganisationTypeId, OrganisationTypeName) VALUES(:OrganisationTypeId, :OrganisationTypeName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00026)
          ,new CursorDef("BC00027", "SAVEPOINT gxupdate;UPDATE Trn_OrganisationType SET OrganisationTypeName=:OrganisationTypeName  WHERE OrganisationTypeId = :OrganisationTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00027)
          ,new CursorDef("BC00028", "SAVEPOINT gxupdate;DELETE FROM Trn_OrganisationType  WHERE OrganisationTypeId = :OrganisationTypeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00028)
          ,new CursorDef("BC00029", "SELECT OrganisationId FROM Trn_Organisation WHERE OrganisationTypeId = :OrganisationTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00029,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("BC000210", "SELECT TM1.OrganisationTypeId, TM1.OrganisationTypeName FROM Trn_OrganisationType TM1 WHERE TM1.OrganisationTypeId = :OrganisationTypeId ORDER BY TM1.OrganisationTypeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000210,100, GxCacheFrequency.OFF ,true,false )
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
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             return;
    }
 }

}

}
