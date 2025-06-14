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
   public class trn_locationimage_bc : GxSilentTrn, IGxSilentTrn
   {
      public trn_locationimage_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public trn_locationimage_bc( IGxContext context )
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
         ReadRow1U105( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1U105( ) ;
         standaloneModal( ) ;
         AddRow1U105( ) ;
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
               Z613LocationImageId = A613LocationImageId;
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

      protected void CONFIRM_1U0( )
      {
         BeforeValidate1U105( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1U105( ) ;
            }
            else
            {
               CheckExtendedTable1U105( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1U105( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1U105( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z614OrganisationLocationId = A614OrganisationLocationId;
         }
         if ( GX_JID == -4 )
         {
            Z613LocationImageId = A613LocationImageId;
            Z614OrganisationLocationId = A614OrganisationLocationId;
            Z615OrganisationLocationImage = A615OrganisationLocationImage;
            Z40000OrganisationLocationImage_GXI = A40000OrganisationLocationImage_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A613LocationImageId) )
         {
            A613LocationImageId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1U105( )
      {
         /* Using cursor BC001U4 */
         pr_default.execute(2, new Object[] {A613LocationImageId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound105 = 1;
            A614OrganisationLocationId = BC001U4_A614OrganisationLocationId[0];
            A40000OrganisationLocationImage_GXI = BC001U4_A40000OrganisationLocationImage_GXI[0];
            A615OrganisationLocationImage = BC001U4_A615OrganisationLocationImage[0];
            ZM1U105( -4) ;
         }
         pr_default.close(2);
         OnLoadActions1U105( ) ;
      }

      protected void OnLoadActions1U105( )
      {
      }

      protected void CheckExtendedTable1U105( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1U105( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1U105( )
      {
         /* Using cursor BC001U5 */
         pr_default.execute(3, new Object[] {A613LocationImageId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound105 = 1;
         }
         else
         {
            RcdFound105 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001U3 */
         pr_default.execute(1, new Object[] {A613LocationImageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1U105( 4) ;
            RcdFound105 = 1;
            A613LocationImageId = BC001U3_A613LocationImageId[0];
            A614OrganisationLocationId = BC001U3_A614OrganisationLocationId[0];
            A40000OrganisationLocationImage_GXI = BC001U3_A40000OrganisationLocationImage_GXI[0];
            A615OrganisationLocationImage = BC001U3_A615OrganisationLocationImage[0];
            Z613LocationImageId = A613LocationImageId;
            sMode105 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1U105( ) ;
            if ( AnyError == 1 )
            {
               RcdFound105 = 0;
               InitializeNonKey1U105( ) ;
            }
            Gx_mode = sMode105;
         }
         else
         {
            RcdFound105 = 0;
            InitializeNonKey1U105( ) ;
            sMode105 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode105;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1U105( ) ;
         if ( RcdFound105 == 0 )
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
         CONFIRM_1U0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1U105( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001U2 */
            pr_default.execute(0, new Object[] {A613LocationImageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_LocationImage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z614OrganisationLocationId != BC001U2_A614OrganisationLocationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trn_LocationImage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1U105( )
      {
         BeforeValidate1U105( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1U105( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1U105( 0) ;
            CheckOptimisticConcurrency1U105( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1U105( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1U105( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001U6 */
                     pr_default.execute(4, new Object[] {A613LocationImageId, A614OrganisationLocationId, A615OrganisationLocationImage, A40000OrganisationLocationImage_GXI});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_LocationImage");
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
               Load1U105( ) ;
            }
            EndLevel1U105( ) ;
         }
         CloseExtendedTableCursors1U105( ) ;
      }

      protected void Update1U105( )
      {
         BeforeValidate1U105( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1U105( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1U105( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1U105( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1U105( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001U7 */
                     pr_default.execute(5, new Object[] {A614OrganisationLocationId, A613LocationImageId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Trn_LocationImage");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trn_LocationImage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1U105( ) ;
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
            EndLevel1U105( ) ;
         }
         CloseExtendedTableCursors1U105( ) ;
      }

      protected void DeferredUpdate1U105( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC001U8 */
            pr_default.execute(6, new Object[] {A615OrganisationLocationImage, A40000OrganisationLocationImage_GXI, A613LocationImageId});
            pr_default.close(6);
            pr_default.SmartCacheProvider.SetUpdated("Trn_LocationImage");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1U105( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1U105( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1U105( ) ;
            AfterConfirm1U105( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1U105( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001U9 */
                  pr_default.execute(7, new Object[] {A613LocationImageId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Trn_LocationImage");
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
         sMode105 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1U105( ) ;
         Gx_mode = sMode105;
      }

      protected void OnDeleteControls1U105( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1U105( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1U105( ) ;
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

      public void ScanKeyStart1U105( )
      {
         /* Using cursor BC001U10 */
         pr_default.execute(8, new Object[] {A613LocationImageId});
         RcdFound105 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound105 = 1;
            A613LocationImageId = BC001U10_A613LocationImageId[0];
            A614OrganisationLocationId = BC001U10_A614OrganisationLocationId[0];
            A40000OrganisationLocationImage_GXI = BC001U10_A40000OrganisationLocationImage_GXI[0];
            A615OrganisationLocationImage = BC001U10_A615OrganisationLocationImage[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1U105( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound105 = 0;
         ScanKeyLoad1U105( ) ;
      }

      protected void ScanKeyLoad1U105( )
      {
         sMode105 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound105 = 1;
            A613LocationImageId = BC001U10_A613LocationImageId[0];
            A614OrganisationLocationId = BC001U10_A614OrganisationLocationId[0];
            A40000OrganisationLocationImage_GXI = BC001U10_A40000OrganisationLocationImage_GXI[0];
            A615OrganisationLocationImage = BC001U10_A615OrganisationLocationImage[0];
         }
         Gx_mode = sMode105;
      }

      protected void ScanKeyEnd1U105( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1U105( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1U105( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1U105( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1U105( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1U105( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1U105( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1U105( )
      {
      }

      protected void send_integrity_lvl_hashes1U105( )
      {
      }

      protected void AddRow1U105( )
      {
         VarsToRow105( bcTrn_LocationImage) ;
      }

      protected void ReadRow1U105( )
      {
         RowToVars105( bcTrn_LocationImage, 1) ;
      }

      protected void InitializeNonKey1U105( )
      {
         A614OrganisationLocationId = Guid.Empty;
         A615OrganisationLocationImage = "";
         A40000OrganisationLocationImage_GXI = "";
         Z614OrganisationLocationId = Guid.Empty;
      }

      protected void InitAll1U105( )
      {
         A613LocationImageId = Guid.NewGuid( );
         InitializeNonKey1U105( ) ;
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

      public void VarsToRow105( SdtTrn_LocationImage obj105 )
      {
         obj105.gxTpr_Mode = Gx_mode;
         obj105.gxTpr_Organisationlocationid = A614OrganisationLocationId;
         obj105.gxTpr_Organisationlocationimage = A615OrganisationLocationImage;
         obj105.gxTpr_Organisationlocationimage_gxi = A40000OrganisationLocationImage_GXI;
         obj105.gxTpr_Locationimageid = A613LocationImageId;
         obj105.gxTpr_Locationimageid_Z = Z613LocationImageId;
         obj105.gxTpr_Organisationlocationid_Z = Z614OrganisationLocationId;
         obj105.gxTpr_Organisationlocationimage_gxi_Z = Z40000OrganisationLocationImage_GXI;
         obj105.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow105( SdtTrn_LocationImage obj105 )
      {
         obj105.gxTpr_Locationimageid = A613LocationImageId;
         return  ;
      }

      public void RowToVars105( SdtTrn_LocationImage obj105 ,
                                int forceLoad )
      {
         Gx_mode = obj105.gxTpr_Mode;
         A614OrganisationLocationId = obj105.gxTpr_Organisationlocationid;
         A615OrganisationLocationImage = obj105.gxTpr_Organisationlocationimage;
         A40000OrganisationLocationImage_GXI = obj105.gxTpr_Organisationlocationimage_gxi;
         A613LocationImageId = obj105.gxTpr_Locationimageid;
         Z613LocationImageId = obj105.gxTpr_Locationimageid_Z;
         Z614OrganisationLocationId = obj105.gxTpr_Organisationlocationid_Z;
         Z40000OrganisationLocationImage_GXI = obj105.gxTpr_Organisationlocationimage_gxi_Z;
         Gx_mode = obj105.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A613LocationImageId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1U105( ) ;
         ScanKeyStart1U105( ) ;
         if ( RcdFound105 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z613LocationImageId = A613LocationImageId;
         }
         ZM1U105( -4) ;
         OnLoadActions1U105( ) ;
         AddRow1U105( ) ;
         ScanKeyEnd1U105( ) ;
         if ( RcdFound105 == 0 )
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
         RowToVars105( bcTrn_LocationImage, 0) ;
         ScanKeyStart1U105( ) ;
         if ( RcdFound105 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z613LocationImageId = A613LocationImageId;
         }
         ZM1U105( -4) ;
         OnLoadActions1U105( ) ;
         AddRow1U105( ) ;
         ScanKeyEnd1U105( ) ;
         if ( RcdFound105 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1U105( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1U105( ) ;
         }
         else
         {
            if ( RcdFound105 == 1 )
            {
               if ( A613LocationImageId != Z613LocationImageId )
               {
                  A613LocationImageId = Z613LocationImageId;
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
                  Update1U105( ) ;
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
                  if ( A613LocationImageId != Z613LocationImageId )
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
                        Insert1U105( ) ;
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
                        Insert1U105( ) ;
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
         RowToVars105( bcTrn_LocationImage, 1) ;
         SaveImpl( ) ;
         VarsToRow105( bcTrn_LocationImage) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars105( bcTrn_LocationImage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1U105( ) ;
         AfterTrn( ) ;
         VarsToRow105( bcTrn_LocationImage) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow105( bcTrn_LocationImage) ;
         }
         else
         {
            SdtTrn_LocationImage auxBC = new SdtTrn_LocationImage(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A613LocationImageId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTrn_LocationImage);
               auxBC.Save();
               bcTrn_LocationImage.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars105( bcTrn_LocationImage, 1) ;
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
         RowToVars105( bcTrn_LocationImage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1U105( ) ;
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
               VarsToRow105( bcTrn_LocationImage) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow105( bcTrn_LocationImage) ;
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
         RowToVars105( bcTrn_LocationImage, 0) ;
         GetKey1U105( ) ;
         if ( RcdFound105 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A613LocationImageId != Z613LocationImageId )
            {
               A613LocationImageId = Z613LocationImageId;
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
            if ( A613LocationImageId != Z613LocationImageId )
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
         context.RollbackDataStores("trn_locationimage_bc",pr_default);
         VarsToRow105( bcTrn_LocationImage) ;
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
         Gx_mode = bcTrn_LocationImage.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTrn_LocationImage.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTrn_LocationImage )
         {
            bcTrn_LocationImage = (SdtTrn_LocationImage)(sdt);
            if ( StringUtil.StrCmp(bcTrn_LocationImage.gxTpr_Mode, "") == 0 )
            {
               bcTrn_LocationImage.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow105( bcTrn_LocationImage) ;
            }
            else
            {
               RowToVars105( bcTrn_LocationImage, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTrn_LocationImage.gxTpr_Mode, "") == 0 )
            {
               bcTrn_LocationImage.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars105( bcTrn_LocationImage, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTrn_LocationImage Trn_LocationImage_BC
      {
         get {
            return bcTrn_LocationImage ;
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
            return "trn_location_Execute" ;
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
         Z613LocationImageId = Guid.Empty;
         A613LocationImageId = Guid.Empty;
         Z614OrganisationLocationId = Guid.Empty;
         A614OrganisationLocationId = Guid.Empty;
         Z615OrganisationLocationImage = "";
         A615OrganisationLocationImage = "";
         Z40000OrganisationLocationImage_GXI = "";
         A40000OrganisationLocationImage_GXI = "";
         BC001U4_A613LocationImageId = new Guid[] {Guid.Empty} ;
         BC001U4_A614OrganisationLocationId = new Guid[] {Guid.Empty} ;
         BC001U4_A40000OrganisationLocationImage_GXI = new string[] {""} ;
         BC001U4_A615OrganisationLocationImage = new string[] {""} ;
         BC001U5_A613LocationImageId = new Guid[] {Guid.Empty} ;
         BC001U3_A613LocationImageId = new Guid[] {Guid.Empty} ;
         BC001U3_A614OrganisationLocationId = new Guid[] {Guid.Empty} ;
         BC001U3_A40000OrganisationLocationImage_GXI = new string[] {""} ;
         BC001U3_A615OrganisationLocationImage = new string[] {""} ;
         sMode105 = "";
         BC001U2_A613LocationImageId = new Guid[] {Guid.Empty} ;
         BC001U2_A614OrganisationLocationId = new Guid[] {Guid.Empty} ;
         BC001U2_A40000OrganisationLocationImage_GXI = new string[] {""} ;
         BC001U2_A615OrganisationLocationImage = new string[] {""} ;
         BC001U10_A613LocationImageId = new Guid[] {Guid.Empty} ;
         BC001U10_A614OrganisationLocationId = new Guid[] {Guid.Empty} ;
         BC001U10_A40000OrganisationLocationImage_GXI = new string[] {""} ;
         BC001U10_A615OrganisationLocationImage = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.trn_locationimage_bc__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.trn_locationimage_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trn_locationimage_bc__default(),
            new Object[][] {
                new Object[] {
               BC001U2_A613LocationImageId, BC001U2_A614OrganisationLocationId, BC001U2_A40000OrganisationLocationImage_GXI, BC001U2_A615OrganisationLocationImage
               }
               , new Object[] {
               BC001U3_A613LocationImageId, BC001U3_A614OrganisationLocationId, BC001U3_A40000OrganisationLocationImage_GXI, BC001U3_A615OrganisationLocationImage
               }
               , new Object[] {
               BC001U4_A613LocationImageId, BC001U4_A614OrganisationLocationId, BC001U4_A40000OrganisationLocationImage_GXI, BC001U4_A615OrganisationLocationImage
               }
               , new Object[] {
               BC001U5_A613LocationImageId
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
               BC001U10_A613LocationImageId, BC001U10_A614OrganisationLocationId, BC001U10_A40000OrganisationLocationImage_GXI, BC001U10_A615OrganisationLocationImage
               }
            }
         );
         Z613LocationImageId = Guid.NewGuid( );
         A613LocationImageId = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound105 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode105 ;
      private string Z40000OrganisationLocationImage_GXI ;
      private string A40000OrganisationLocationImage_GXI ;
      private string Z615OrganisationLocationImage ;
      private string A615OrganisationLocationImage ;
      private Guid Z613LocationImageId ;
      private Guid A613LocationImageId ;
      private Guid Z614OrganisationLocationId ;
      private Guid A614OrganisationLocationId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC001U4_A613LocationImageId ;
      private Guid[] BC001U4_A614OrganisationLocationId ;
      private string[] BC001U4_A40000OrganisationLocationImage_GXI ;
      private string[] BC001U4_A615OrganisationLocationImage ;
      private Guid[] BC001U5_A613LocationImageId ;
      private Guid[] BC001U3_A613LocationImageId ;
      private Guid[] BC001U3_A614OrganisationLocationId ;
      private string[] BC001U3_A40000OrganisationLocationImage_GXI ;
      private string[] BC001U3_A615OrganisationLocationImage ;
      private Guid[] BC001U2_A613LocationImageId ;
      private Guid[] BC001U2_A614OrganisationLocationId ;
      private string[] BC001U2_A40000OrganisationLocationImage_GXI ;
      private string[] BC001U2_A615OrganisationLocationImage ;
      private Guid[] BC001U10_A613LocationImageId ;
      private Guid[] BC001U10_A614OrganisationLocationId ;
      private string[] BC001U10_A40000OrganisationLocationImage_GXI ;
      private string[] BC001U10_A615OrganisationLocationImage ;
      private SdtTrn_LocationImage bcTrn_LocationImage ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
   }

   public class trn_locationimage_bc__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class trn_locationimage_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

public class trn_locationimage_bc__default : DataStoreHelperBase, IDataStoreHelper
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmBC001U2;
       prmBC001U2 = new Object[] {
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U3;
       prmBC001U3 = new Object[] {
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U4;
       prmBC001U4 = new Object[] {
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U5;
       prmBC001U5 = new Object[] {
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U6;
       prmBC001U6 = new Object[] {
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationLocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("OrganisationLocationImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationLocationImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="Trn_LocationImage", Fld="OrganisationLocationImage"}
       };
       Object[] prmBC001U7;
       prmBC001U7 = new Object[] {
       new ParDef("OrganisationLocationId",GXType.UniqueIdentifier,36,0) ,
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U8;
       prmBC001U8 = new Object[] {
       new ParDef("OrganisationLocationImage",GXType.Byte,1024,0){InDB=false} ,
       new ParDef("OrganisationLocationImage_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Trn_LocationImage", Fld="OrganisationLocationImage"} ,
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U9;
       prmBC001U9 = new Object[] {
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       Object[] prmBC001U10;
       prmBC001U10 = new Object[] {
       new ParDef("LocationImageId",GXType.UniqueIdentifier,36,0)
       };
       def= new CursorDef[] {
           new CursorDef("BC001U2", "SELECT LocationImageId, OrganisationLocationId, OrganisationLocationImage_GXI, OrganisationLocationImage FROM Trn_LocationImage WHERE LocationImageId = :LocationImageId  FOR UPDATE OF Trn_LocationImage",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001U3", "SELECT LocationImageId, OrganisationLocationId, OrganisationLocationImage_GXI, OrganisationLocationImage FROM Trn_LocationImage WHERE LocationImageId = :LocationImageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001U4", "SELECT TM1.LocationImageId, TM1.OrganisationLocationId, TM1.OrganisationLocationImage_GXI, TM1.OrganisationLocationImage FROM Trn_LocationImage TM1 WHERE TM1.LocationImageId = :LocationImageId ORDER BY TM1.LocationImageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001U5", "SELECT LocationImageId FROM Trn_LocationImage WHERE LocationImageId = :LocationImageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("BC001U6", "SAVEPOINT gxupdate;INSERT INTO Trn_LocationImage(LocationImageId, OrganisationLocationId, OrganisationLocationImage, OrganisationLocationImage_GXI) VALUES(:LocationImageId, :OrganisationLocationId, :OrganisationLocationImage, :OrganisationLocationImage_GXI);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001U6)
          ,new CursorDef("BC001U7", "SAVEPOINT gxupdate;UPDATE Trn_LocationImage SET OrganisationLocationId=:OrganisationLocationId  WHERE LocationImageId = :LocationImageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001U7)
          ,new CursorDef("BC001U8", "SAVEPOINT gxupdate;UPDATE Trn_LocationImage SET OrganisationLocationImage=:OrganisationLocationImage, OrganisationLocationImage_GXI=:OrganisationLocationImage_GXI  WHERE LocationImageId = :LocationImageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001U8)
          ,new CursorDef("BC001U9", "SAVEPOINT gxupdate;DELETE FROM Trn_LocationImage  WHERE LocationImageId = :LocationImageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001U9)
          ,new CursorDef("BC001U10", "SELECT TM1.LocationImageId, TM1.OrganisationLocationId, TM1.OrganisationLocationImage_GXI, TM1.OrganisationLocationImage FROM Trn_LocationImage TM1 WHERE TM1.LocationImageId = :LocationImageId ORDER BY TM1.LocationImageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U10,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 8 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((Guid[]) buf[1])[0] = rslt.getGuid(2);
             ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
             ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
             return;
    }
 }

}

}
