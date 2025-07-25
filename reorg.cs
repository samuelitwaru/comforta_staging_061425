using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", false);
      }

      public reorg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void ReorganizeTrn_Location( )
      {
         string cmdBuffer = "";
         /* Indices for table Trn_Location */
         try
         {
            cmdBuffer=" CREATE TABLE GXA0006 (LocationId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , LocationName VARCHAR(100) NOT NULL , LocationEmail VARCHAR(100) NOT NULL , LocationPhone CHAR(20) NOT NULL , LocationDescription TEXT NOT NULL , LocationCity VARCHAR(100) NOT NULL , LocationZipCode VARCHAR(100) NOT NULL , LocationAddressLine1 VARCHAR(100) NOT NULL , LocationAddressLine2 VARCHAR(100) NOT NULL , LocationPhoneCode VARCHAR(40) NOT NULL , LocationPhoneNumber VARCHAR(9) NOT NULL , LocationCountry VARCHAR(100) NOT NULL , LocationImage BYTEA , LocationImage_GXI VARCHAR(2048) , ToolBoxDefaultLogo VARCHAR(200) , ToolBoxDefaultProfileImage VARCHAR(200) , LocationBrandTheme TEXT , LocationCtaTheme TEXT , LocationHasMyCare BOOLEAN NOT NULL , LocationHasMyServices BOOLEAN NOT NULL , LocationHasMyLiving BOOLEAN NOT NULL , LocationHasOwnBrand BOOLEAN NOT NULL , ReceptionImage BYTEA , ReceptionImage_GXI VARCHAR(2048) , ReceptionDescription VARCHAR(200) , LocationThemeId CHAR(36) , ActiveAppVersionId CHAR(36) , PublishedActiveAppVersionId CHAR(36) , ToolBoxLastUpdateReceptionistI CHAR(36) , ToolBoxLastUpdateTime timestamp without time zone , ToolboxHasMultiLingualSupport BOOLEAN , ToolboxSupportedLanguages TEXT )  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP TABLE GXA0006 CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP VIEW GXA0006 CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     cmdBuffer=" DROP FUNCTION GXA0006 CASCADE "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE GXA0006 (LocationId CHAR(36) NOT NULL , OrganisationId CHAR(36) NOT NULL , LocationName VARCHAR(100) NOT NULL , LocationEmail VARCHAR(100) NOT NULL , LocationPhone CHAR(20) NOT NULL , LocationDescription TEXT NOT NULL , LocationCity VARCHAR(100) NOT NULL , LocationZipCode VARCHAR(100) NOT NULL , LocationAddressLine1 VARCHAR(100) NOT NULL , LocationAddressLine2 VARCHAR(100) NOT NULL , LocationPhoneCode VARCHAR(40) NOT NULL , LocationPhoneNumber VARCHAR(9) NOT NULL , LocationCountry VARCHAR(100) NOT NULL , LocationImage BYTEA , LocationImage_GXI VARCHAR(2048) , ToolBoxDefaultLogo VARCHAR(200) , ToolBoxDefaultProfileImage VARCHAR(200) , LocationBrandTheme TEXT , LocationCtaTheme TEXT , LocationHasMyCare BOOLEAN NOT NULL , LocationHasMyServices BOOLEAN NOT NULL , LocationHasMyLiving BOOLEAN NOT NULL , LocationHasOwnBrand BOOLEAN NOT NULL , ReceptionImage BYTEA , ReceptionImage_GXI VARCHAR(2048) , ReceptionDescription VARCHAR(200) , LocationThemeId CHAR(36) , ActiveAppVersionId CHAR(36) , PublishedActiveAppVersionId CHAR(36) , ToolBoxLastUpdateReceptionistI CHAR(36) , ToolBoxLastUpdateTime timestamp without time zone , ToolboxHasMultiLingualSupport BOOLEAN , ToolboxSupportedLanguages TEXT )  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         /* API remote call */
         new trn_locationconversion(context ).execute( ) ;
         try
         {
            cmdBuffer=" DROP TABLE Trn_Location CASCADE "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" DROP VIEW Trn_Location CASCADE "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  cmdBuffer=" DROP FUNCTION Trn_Location CASCADE "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
               }
            }
         }
         cmdBuffer=" ALTER TABLE GXA0006 RENAME TO Trn_Location "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT Trn_Location_pkey PRIMARY KEY(LocationId, OrganisationId) "
         ;
         RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
         RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
         RGZ.ExecuteStmt() ;
         RGZ.Drop();
         try
         {
            cmdBuffer=" CREATE INDEX UTRN_LOCATION ON Trn_Location (LocationName ,LocationEmail ,LocationPhone ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX UTRN_LOCATION "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX UTRN_LOCATION ON Trn_Location (LocationName ,LocationEmail ,LocationPhone ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_LOCATION3 ON Trn_Location (LocationThemeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_LOCATION3 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_LOCATION3 ON Trn_Location (LocationThemeId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_LOCATION4 ON Trn_Location (ActiveAppVersionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_LOCATION4 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_LOCATION4 ON Trn_Location (ActiveAppVersionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_LOCATION5 ON Trn_Location (PublishedActiveAppVersionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_LOCATION5 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_LOCATION5 ON Trn_Location (PublishedActiveAppVersionId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE INDEX ITRN_LOCATION1 ON Trn_Location (ToolBoxLastUpdateReceptionistI ,OrganisationId ,LocationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX ITRN_LOCATION1 "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE INDEX ITRN_LOCATION1 ON Trn_Location (ToolBoxLastUpdateReceptionistI ,OrganisationId ,LocationId ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_SupplierGenTrn_SupplierGenType( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD CONSTRAINT ITRN_SUPPLIERGEN1 FOREIGN KEY (SupplierGenTypeId) REFERENCES Trn_SupplierGenType (SupplierGenTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_SupplierGen DROP CONSTRAINT ITRN_SUPPLIERGEN1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD CONSTRAINT ITRN_SUPPLIERGEN1 FOREIGN KEY (SupplierGenTypeId) REFERENCES Trn_SupplierGenType (SupplierGenTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_SupplierGenTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD CONSTRAINT ITRN_SUPPLIERGEN3 FOREIGN KEY (SG_LocationSupplierLocationId, SG_LocationSupplierOrganisatio) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_SupplierGen DROP CONSTRAINT ITRN_SUPPLIERGEN3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD CONSTRAINT ITRN_SUPPLIERGEN3 FOREIGN KEY (SG_LocationSupplierLocationId, SG_LocationSupplierOrganisatio) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_SupplierGenTrn_Organisation( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD CONSTRAINT ITRN_SUPPLIERGEN2 FOREIGN KEY (SG_OrganisationSupplierId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_SupplierGen DROP CONSTRAINT ITRN_SUPPLIERGEN2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_SupplierGen ADD CONSTRAINT ITRN_SUPPLIERGEN2 FOREIGN KEY (SG_OrganisationSupplierId) REFERENCES Trn_Organisation (OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_MemoTrn_Resident( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Memo ADD CONSTRAINT ITRN_MEMO2 FOREIGN KEY (ResidentId, SG_LocationId, SG_OrganisationId) REFERENCES Trn_Resident (ResidentId, LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Memo DROP CONSTRAINT ITRN_MEMO2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Memo ADD CONSTRAINT ITRN_MEMO2 FOREIGN KEY (ResidentId, SG_LocationId, SG_OrganisationId) REFERENCES Trn_Resident (ResidentId, LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ResidentPackageTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_ResidentPackage ADD CONSTRAINT ITRN_RESIDENTPACKAGE1 FOREIGN KEY (SG_LocationId, SG_OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_ResidentPackage DROP CONSTRAINT ITRN_RESIDENTPACKAGE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_ResidentPackage ADD CONSTRAINT ITRN_RESIDENTPACKAGE1 FOREIGN KEY (SG_LocationId, SG_OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_AppVersionTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_AppVersion ADD CONSTRAINT ITRN_APPVERSION1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_AppVersion DROP CONSTRAINT ITRN_APPVERSION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_AppVersion ADD CONSTRAINT ITRN_APPVERSION1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_AppVersionTrn_Theme( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_AppVersion ADD CONSTRAINT ITRN_APPVERSION2 FOREIGN KEY (Trn_ThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_AppVersion DROP CONSTRAINT ITRN_APPVERSION2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_AppVersion ADD CONSTRAINT ITRN_APPVERSION2 FOREIGN KEY (Trn_ThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_AgendaCalendarTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_AgendaCalendar ADD CONSTRAINT ITRN_AGENDACALENDAR1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_AgendaCalendar DROP CONSTRAINT ITRN_AGENDACALENDAR1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_AgendaCalendar ADD CONSTRAINT ITRN_AGENDACALENDAR1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationDynamicFormTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm ADD CONSTRAINT ITRN_LOCATIONDYNAMICFORM2 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm DROP CONSTRAINT ITRN_LOCATIONDYNAMICFORM2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm ADD CONSTRAINT ITRN_LOCATIONDYNAMICFORM2 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationDynamicFormWWP_Form( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm ADD CONSTRAINT ITRN_LOCATIONDYNAMICFORM1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber) REFERENCES WWP_Form (WWPFormId, WWPFormVersionNumber) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm DROP CONSTRAINT ITRN_LOCATIONDYNAMICFORM1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_LocationDynamicForm ADD CONSTRAINT ITRN_LOCATIONDYNAMICFORM1 FOREIGN KEY (WWPFormId, WWPFormVersionNumber) REFERENCES WWP_Form (WWPFormId, WWPFormVersionNumber) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ProductServiceTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE3 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_ProductService DROP CONSTRAINT ITRN_PRODUCTSERVICE3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE3 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ProductServiceTrn_SupplierGen( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE2 FOREIGN KEY (SupplierGenId) REFERENCES Trn_SupplierGen (SupplierGenId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_ProductService DROP CONSTRAINT ITRN_PRODUCTSERVICE2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE2 FOREIGN KEY (SupplierGenId) REFERENCES Trn_SupplierGen (SupplierGenId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ProductServiceTrn_SupplierAGB( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE1 FOREIGN KEY (SupplierAgbId) REFERENCES Trn_SupplierAGB (SupplierAgbId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_ProductService DROP CONSTRAINT ITRN_PRODUCTSERVICE1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_ProductService ADD CONSTRAINT ITRN_PRODUCTSERVICE1 FOREIGN KEY (SupplierAgbId) REFERENCES Trn_SupplierAGB (SupplierAgbId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ResidentTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT4 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Resident DROP CONSTRAINT ITRN_RESIDENT4 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT4 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ResidentTrn_ResidentType( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT3 FOREIGN KEY (ResidentTypeId) REFERENCES Trn_ResidentType (ResidentTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Resident DROP CONSTRAINT ITRN_RESIDENT3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT3 FOREIGN KEY (ResidentTypeId) REFERENCES Trn_ResidentType (ResidentTypeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ResidentTrn_MedicalIndication( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT2 FOREIGN KEY (MedicalIndicationId) REFERENCES Trn_MedicalIndication (MedicalIndicationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Resident DROP CONSTRAINT ITRN_RESIDENT2 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT2 FOREIGN KEY (MedicalIndicationId) REFERENCES Trn_MedicalIndication (MedicalIndicationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ResidentTrn_ResidentPackage( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT1 FOREIGN KEY (ResidentPackageId) REFERENCES Trn_ResidentPackage (ResidentPackageId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Resident DROP CONSTRAINT ITRN_RESIDENT1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Resident ADD CONSTRAINT ITRN_RESIDENT1 FOREIGN KEY (ResidentPackageId) REFERENCES Trn_ResidentPackage (ResidentPackageId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_ReceptionistTrn_Location( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Receptionist ADD CONSTRAINT ITRN_RECEPTIONIST1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Receptionist DROP CONSTRAINT ITRN_RECEPTIONIST1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Receptionist ADD CONSTRAINT ITRN_RECEPTIONIST1 FOREIGN KEY (LocationId, OrganisationId) REFERENCES Trn_Location (LocationId, OrganisationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationTrn_Receptionist( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION1 FOREIGN KEY (ToolBoxLastUpdateReceptionistI, OrganisationId, LocationId) REFERENCES Trn_Receptionist (ReceptionistId, OrganisationId, LocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Location DROP CONSTRAINT ITRN_LOCATION1 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION1 FOREIGN KEY (ToolBoxLastUpdateReceptionistI, OrganisationId, LocationId) REFERENCES Trn_Receptionist (ReceptionistId, OrganisationId, LocationId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationTrn_Theme( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION3 FOREIGN KEY (LocationThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Location DROP CONSTRAINT ITRN_LOCATION3 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION3 FOREIGN KEY (LocationThemeId) REFERENCES Trn_Theme (Trn_ThemeId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationTrn_AppVersion( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION5 FOREIGN KEY (PublishedActiveAppVersionId) REFERENCES Trn_AppVersion (AppVersionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Location DROP CONSTRAINT ITRN_LOCATION5 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION5 FOREIGN KEY (PublishedActiveAppVersionId) REFERENCES Trn_AppVersion (AppVersionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RITrn_LocationTrn_AppVersion1( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION4 FOREIGN KEY (ActiveAppVersionId) REFERENCES Trn_AppVersion (AppVersionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE Trn_Location DROP CONSTRAINT ITRN_LOCATION4 "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE Trn_Location ADD CONSTRAINT ITRN_LOCATION4 FOREIGN KEY (ActiveAppVersionId) REFERENCES Trn_AppVersion (AppVersionId) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      private void TablesCount( )
      {
         if ( ! IsResumeMode( ) )
         {
            /* Using cursor P00012 */
            pr_default.execute(0);
            Trn_LocationCount = P00012_ATrn_LocationCount[0];
            pr_default.close(0);
            PrintRecordCount ( "Trn_Location" ,  Trn_LocationCount );
         }
      }

      private bool PreviousCheck( )
      {
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         sSchemaVar = GXUtil.UserId( "Server", context, pr_default);
         if ( ! tableexist("Trn_Location",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_not_exist", new   object[]  {"Trn_Location"}) ) ;
            return false ;
         }
         return true ;
      }

      private bool tableexist( string sTableName ,
                               string sMySchemaName )
      {
         bool result;
         result = false;
         /* Using cursor P00023 */
         pr_default.execute(1, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(1) != 101) )
         {
            tablename = P00023_Atablename[0];
            ntablename = P00023_ntablename[0];
            schemaname = P00023_Aschemaname[0];
            nschemaname = P00023_nschemaname[0];
            result = true;
            pr_default.readNext(1);
         }
         pr_default.close(1);
         /* Using cursor P00034 */
         pr_default.execute(2, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(2) != 101) )
         {
            tablename = P00034_Atablename[0];
            ntablename = P00034_ntablename[0];
            schemaname = P00034_Aschemaname[0];
            nschemaname = P00034_nschemaname[0];
            result = true;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         return result ;
      }

      private bool ColumnExist( string sTableName ,
                                string sMySchemaName ,
                                string sMyColumnName )
      {
         bool result;
         result = false;
         /* Using cursor P00045 */
         pr_default.execute(3, new Object[] {sTableName, sMySchemaName, sMyColumnName});
         while ( (pr_default.getStatus(3) != 101) )
         {
            tablename = P00045_Atablename[0];
            ntablename = P00045_ntablename[0];
            schemaname = P00045_Aschemaname[0];
            nschemaname = P00045_nschemaname[0];
            columnname = P00045_Acolumnname[0];
            ncolumnname = P00045_ncolumnname[0];
            attrelid = P00045_Aattrelid[0];
            nattrelid = P00045_nattrelid[0];
            oid = P00045_Aoid[0];
            noid = P00045_noid[0];
            relname = P00045_Arelname[0];
            nrelname = P00045_nrelname[0];
            result = true;
            pr_default.readNext(3);
         }
         pr_default.close(3);
         return result ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "ReorganizeTrn_Location" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "RITrn_SupplierGenTrn_SupplierGenType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "RITrn_SupplierGenTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "RITrn_SupplierGenTrn_Organisation" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "RITrn_MemoTrn_Resident" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 6 ,  "RITrn_ResidentPackageTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 7 ,  "RITrn_AppVersionTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 8 ,  "RITrn_AppVersionTrn_Theme" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 9 ,  "RITrn_AgendaCalendarTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 10 ,  "RITrn_LocationDynamicFormTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 11 ,  "RITrn_LocationDynamicFormWWP_Form" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 12 ,  "RITrn_ProductServiceTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 13 ,  "RITrn_ProductServiceTrn_SupplierGen" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 14 ,  "RITrn_ProductServiceTrn_SupplierAGB" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 15 ,  "RITrn_ResidentTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 16 ,  "RITrn_ResidentTrn_ResidentType" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 17 ,  "RITrn_ResidentTrn_MedicalIndication" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 18 ,  "RITrn_ResidentTrn_ResidentPackage" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 19 ,  "RITrn_ReceptionistTrn_Location" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 20 ,  "RITrn_LocationTrn_Receptionist" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 21 ,  "RITrn_LocationTrn_Theme" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 22 ,  "RITrn_LocationTrn_AppVersion" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 23 ,  "RITrn_LocationTrn_AppVersion1" , new Object[]{ });
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_fileupdate", new   object[]  {"Trn_Location", ""}) );
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_SUPPLIERGEN1"}) );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_SUPPLIERGEN3"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_SupplierGenTrn_Location" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_SUPPLIERGEN2"}) );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_MEMO2"}) );
         GXReorganization.SetMsg( 6 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RESIDENTPACKAGE1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ResidentPackageTrn_Location" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 7 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_APPVERSION1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_AppVersionTrn_Location" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 8 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_APPVERSION2"}) );
         GXReorganization.SetMsg( 9 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_AGENDACALENDAR1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_AgendaCalendarTrn_Location" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 10 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATIONDYNAMICFORM2"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationDynamicFormTrn_Location" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 11 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATIONDYNAMICFORM1"}) );
         GXReorganization.SetMsg( 12 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_PRODUCTSERVICE3"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ProductServiceTrn_Location" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 13 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_PRODUCTSERVICE2"}) );
         GXReorganization.SetMsg( 14 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_PRODUCTSERVICE1"}) );
         GXReorganization.SetMsg( 15 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RESIDENT4"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ResidentTrn_Location" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 16 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RESIDENT3"}) );
         GXReorganization.SetMsg( 17 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RESIDENT2"}) );
         GXReorganization.SetMsg( 18 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RESIDENT1"}) );
         GXReorganization.SetMsg( 19 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_RECEPTIONIST1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_ReceptionistTrn_Location" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 20 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATION1"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationTrn_Receptionist" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 21 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATION3"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationTrn_Theme" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 22 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATION5"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationTrn_AppVersion" ,  "ReorganizeTrn_Location" );
         GXReorganization.SetMsg( 23 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"ITRN_LOCATION4"}) );
         ReorgExecute.RegisterPrecedence( "RITrn_LocationTrn_AppVersion1" ,  "ReorganizeTrn_Location" );
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      public void UtilsCleanup( )
      {
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         P00012_ATrn_LocationCount = new int[1] ;
         sSchemaVar = "";
         sTableName = "";
         sMySchemaName = "";
         tablename = "";
         ntablename = false;
         schemaname = "";
         nschemaname = false;
         P00023_Atablename = new string[] {""} ;
         P00023_ntablename = new bool[] {false} ;
         P00023_Aschemaname = new string[] {""} ;
         P00023_nschemaname = new bool[] {false} ;
         P00034_Atablename = new string[] {""} ;
         P00034_ntablename = new bool[] {false} ;
         P00034_Aschemaname = new string[] {""} ;
         P00034_nschemaname = new bool[] {false} ;
         sMyColumnName = "";
         columnname = "";
         ncolumnname = false;
         attrelid = "";
         nattrelid = false;
         oid = "";
         noid = false;
         relname = "";
         nrelname = false;
         P00045_Atablename = new string[] {""} ;
         P00045_ntablename = new bool[] {false} ;
         P00045_Aschemaname = new string[] {""} ;
         P00045_nschemaname = new bool[] {false} ;
         P00045_Acolumnname = new string[] {""} ;
         P00045_ncolumnname = new bool[] {false} ;
         P00045_Aattrelid = new string[] {""} ;
         P00045_nattrelid = new bool[] {false} ;
         P00045_Aoid = new string[] {""} ;
         P00045_noid = new bool[] {false} ;
         P00045_Arelname = new string[] {""} ;
         P00045_nrelname = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_ATrn_LocationCount
               }
               , new Object[] {
               P00023_Atablename, P00023_Aschemaname
               }
               , new Object[] {
               P00034_Atablename, P00034_Aschemaname
               }
               , new Object[] {
               P00045_Atablename, P00045_Aschemaname, P00045_Acolumnname, P00045_Aattrelid, P00045_Aoid, P00045_Arelname
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected int Trn_LocationCount ;
      protected string sSchemaVar ;
      protected string sTableName ;
      protected string sMySchemaName ;
      protected string sMyColumnName ;
      protected bool ntablename ;
      protected bool nschemaname ;
      protected bool ncolumnname ;
      protected bool nattrelid ;
      protected bool noid ;
      protected bool nrelname ;
      protected string tablename ;
      protected string schemaname ;
      protected string columnname ;
      protected string attrelid ;
      protected string oid ;
      protected string relname ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsGAM ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected int[] P00012_ATrn_LocationCount ;
      protected string[] P00023_Atablename ;
      protected bool[] P00023_ntablename ;
      protected string[] P00023_Aschemaname ;
      protected bool[] P00023_nschemaname ;
      protected string[] P00034_Atablename ;
      protected bool[] P00034_ntablename ;
      protected string[] P00034_Aschemaname ;
      protected bool[] P00034_nschemaname ;
      protected string[] P00045_Atablename ;
      protected bool[] P00045_ntablename ;
      protected string[] P00045_Aschemaname ;
      protected bool[] P00045_nschemaname ;
      protected string[] P00045_Acolumnname ;
      protected bool[] P00045_ncolumnname ;
      protected string[] P00045_Aattrelid ;
      protected bool[] P00045_nattrelid ;
      protected string[] P00045_Aoid ;
      protected bool[] P00045_noid ;
      protected string[] P00045_Arelname ;
      protected bool[] P00045_nrelname ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00012;
          prmP00012 = new Object[] {
          };
          Object[] prmP00023;
          prmP00023 = new Object[] {
          new ParDef("sTableName",GXType.Char,255,0) ,
          new ParDef("sMySchemaName",GXType.Char,255,0)
          };
          Object[] prmP00034;
          prmP00034 = new Object[] {
          new ParDef("sTableName",GXType.Char,255,0) ,
          new ParDef("sMySchemaName",GXType.Char,255,0)
          };
          Object[] prmP00045;
          prmP00045 = new Object[] {
          new ParDef("sTableName",GXType.Char,255,0) ,
          new ParDef("sMySchemaName",GXType.Char,255,0) ,
          new ParDef("sMyColumnName",GXType.Char,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT COUNT(*) FROM Trn_Location ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT TABLENAME, TABLEOWNER FROM PG_TABLES WHERE (UPPER(TABLENAME) = ( UPPER(:sTableName))) AND (UPPER(TABLEOWNER) = ( UPPER(:sMySchemaName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00034", "SELECT VIEWNAME, VIEWOWNER FROM PG_VIEWS WHERE (UPPER(VIEWNAME) = ( UPPER(:sTableName))) AND (UPPER(VIEWOWNER) = ( UPPER(:sMySchemaName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00045", "SELECT T.TABLENAME, T.TABLEOWNER, T1.ATTNAME, T1.ATTRELID, T2.OID, T2.RELNAME FROM PG_TABLES T, PG_ATTRIBUTE T1, PG_CLASS T2 WHERE (UPPER(T.TABLENAME) = ( UPPER(:sTableName))) AND (UPPER(T.TABLEOWNER) = ( UPPER(:sMySchemaName))) AND (UPPER(T1.ATTNAME) = ( UPPER(:sMyColumnName))) AND (T2.OID = ( T1.ATTRELID)) AND (T2.RELNAME = ( T.TABLENAME)) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00045,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                return;
       }
    }

 }

}
